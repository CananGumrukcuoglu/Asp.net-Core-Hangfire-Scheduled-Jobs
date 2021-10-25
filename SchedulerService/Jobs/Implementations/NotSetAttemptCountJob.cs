using Hangfire;
using SchedulerService.Jobs.Interfaces;

namespace SchedulerService.Jobs.Implementations
{
    public class NotSetAttemptCountJob:INotSetAttemptCountJob
    {
        [Queue("general")]
        public void Run()
        {
            throw new System.NotImplementedException("It will be retried for 10 times by default");
        }
    }
}