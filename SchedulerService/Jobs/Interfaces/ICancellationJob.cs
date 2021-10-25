using Hangfire;

namespace SchedulerService.Jobs.Interfaces
{
    public interface ICancellationJob
    {
        [AutomaticRetry(Attempts = 0, LogEvents = false, OnAttemptsExceeded = AttemptsExceededAction.Delete)]
        [JobDisplayName("Cancellation Job")]
        [Queue("general")]
        void Run(IJobCancellationToken cancellationToken);
    }
}