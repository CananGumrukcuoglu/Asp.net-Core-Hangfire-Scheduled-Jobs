using Hangfire;

namespace SchedulerService.Jobs.Interfaces
{
    public interface IBirthdayMailJob
    {
        [AutomaticRetry(Attempts = 0, LogEvents = false, OnAttemptsExceeded = AttemptsExceededAction.Delete)]
        [JobDisplayName("Send Birthday Mail")]
        void Run();
    }
}