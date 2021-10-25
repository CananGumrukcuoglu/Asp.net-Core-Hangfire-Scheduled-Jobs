using Hangfire;

namespace SchedulerService.Jobs.Interfaces
{
    public interface IManualSemaphoreJob
    {
        [AutomaticRetry(Attempts = 0, LogEvents = false, OnAttemptsExceeded = AttemptsExceededAction.Delete)]
        [JobDisplayName("Manual Semaphore Job")]
        void Run();
    }
}