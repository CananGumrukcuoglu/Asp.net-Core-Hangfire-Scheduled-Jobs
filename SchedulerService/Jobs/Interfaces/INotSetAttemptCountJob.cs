using Hangfire;

namespace SchedulerService.Jobs.Interfaces
{
    public interface INotSetAttemptCountJob
    {
        [AutomaticRetry(Attempts = 5)]
        [Queue("general")]
        void Run();
    }
}