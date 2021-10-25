using System;
using Hangfire;
using Microsoft.Extensions.Options;
using SchedulerService.Business.Settings;
using SchedulerService.Jobs.Interfaces;
using SchedulerService.Services.Interfaces;

namespace SchedulerService.Services.Implementations
{
    internal class CronJobStarter : ICronJobStarter
    {
        private readonly RecurringJobSettings _recurringJobSettings;
        private readonly OneTimeJobSettings _onetimeJobSettings;

        public CronJobStarter(IOptions<JobSettings> jobSettingsOptions)
        {
            _recurringJobSettings = jobSettingsOptions.Value.RecurringJobSettings;
            _onetimeJobSettings = jobSettingsOptions.Value.OneTimeJobSettings;
        }

        private RepetitiveJob SetAttemptCountJob => _recurringJobSettings.SetAttemptCountJob;
        private RepetitiveJob NotSetAttemptCountJob => _recurringJobSettings.NotSetAttemptCountJob;
        private RepetitiveJob BirthdayPromotionJob => _recurringJobSettings.BirthdayPromotionJob;
        private RepetitiveJob ManualSemaphoreJob => _recurringJobSettings.ManualSemaphoreJob;

        private Job HangfireStartedNotificationJob => _onetimeJobSettings.HangfireStartedNotificationJob;

        public void StartJobs()
        {
            //Fire and Forget Job Sample
            BackgroundJob.Enqueue<IHangfireStartedNotificationJob>(m => m.Run());
            //Delayed Job Sample
            BackgroundJob.Schedule<ICpuCounterJob>(m => m.Run(), TimeSpan.FromSeconds(20));
            BackgroundJob.Schedule<ICancellationJob>(m => m.Run(JobCancellationToken.Null), TimeSpan.FromMinutes(2));
            //Recurring Job Samples
            RecurringJob.AddOrUpdate<ISetAttemptCountJob>
            (SetAttemptCountJob.JobId,
                m => m.Run(), SetAttemptCountJob.IntervalPattern,
                TimeZoneInfo.Local, SetAttemptCountJob.Queue);

            RecurringJob.AddOrUpdate<INotSetAttemptCountJob>
            (NotSetAttemptCountJob.JobId,
                m => m.Run(), NotSetAttemptCountJob.IntervalPattern,
                TimeZoneInfo.Local, NotSetAttemptCountJob.Queue);
            RecurringJob.AddOrUpdate<IBirthdayPromotionJob>(BirthdayPromotionJob.JobId,
                m => m.Run(null), BirthdayPromotionJob.IntervalPattern, TimeZoneInfo.Local,
                BirthdayPromotionJob.Queue);
            
            RecurringJob.AddOrUpdate<IManualSemaphoreJob>
            (ManualSemaphoreJob.JobId,
                m => m.Run(), ManualSemaphoreJob.IntervalPattern,
                TimeZoneInfo.Local, ManualSemaphoreJob.Queue);
        }
    }
}