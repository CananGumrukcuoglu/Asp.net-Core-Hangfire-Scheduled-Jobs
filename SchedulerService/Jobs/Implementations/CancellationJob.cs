using System;
using System.Threading;
using System.Threading.Tasks;
using Hangfire;
using SchedulerService.Jobs.Interfaces;

namespace SchedulerService.Jobs.Implementations
{
    public class CancellationJob : ICancellationJob
    {
        public void Run(IJobCancellationToken cancellationToken)
        {
            Thread.Sleep(TimeSpan.FromMinutes(2));
        }
    }
}