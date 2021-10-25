using System;
using System.Runtime.InteropServices;
using System.Threading;
using SchedulerService.Jobs.Interfaces;
using Serilog;

namespace SchedulerService.Jobs.Implementations
{
    public class ManualSemaphoreJob : IManualSemaphoreJob
    {
        private readonly Semaphore _customSemaphore;
        private readonly ILogger _logger;


        public ManualSemaphoreJob(ILogger logger)
        {
            _logger = logger;
            _customSemaphore = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? new Semaphore(1, 1, nameof(ManualSemaphoreJob)) : new Semaphore(1, 1);
        }

        public void Run()
        {
            if (_customSemaphore.WaitOne(5000))
            {
                try
                {
                    _logger.Information("I'm a sample for custom semaphore");
                    Thread.Sleep(TimeSpan.FromMinutes(32));
                    _logger.Information("Finally I finished my job, but another job is already started.");
                }
                finally
                {
                    _customSemaphore.Release();
                }
            }
        }
    }
}