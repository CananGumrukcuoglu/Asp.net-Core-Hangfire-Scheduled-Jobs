using Hangfire;
using Microsoft.Extensions.Configuration;

namespace SchedulerService.Jobs.Interfaces
{
    public interface ISetAttemptCountJob
    {
        // [AutomaticRetry(Attempts = 0)]
        [AutomaticRetry(Attempts = 0, LogEvents = false, OnAttemptsExceeded = AttemptsExceededAction.Delete)]
        [JobDisplayName("Set Attempt Count")]
        void Run();
    }
}