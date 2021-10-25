using Hangfire;

namespace SchedulerService.Jobs.Interfaces
{
    public interface IHangfireStartedNotificationJob
    {
        [AutomaticRetry(Attempts = 0, LogEvents = false, OnAttemptsExceeded = AttemptsExceededAction.Delete)]
        [JobDisplayName("Hangfire Started Notification Job")]
        void Run();
    }
}