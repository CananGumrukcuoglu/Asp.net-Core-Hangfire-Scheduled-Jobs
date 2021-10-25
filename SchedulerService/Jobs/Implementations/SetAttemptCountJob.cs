using System.Threading;
using SchedulerService.Jobs.Interfaces;

namespace SchedulerService.Jobs.Implementations
{
    public class SetAttemptCountJob:ISetAttemptCountJob
    {
        public void Run()
        {
            Thread.Sleep(5000);
        }
    }
}