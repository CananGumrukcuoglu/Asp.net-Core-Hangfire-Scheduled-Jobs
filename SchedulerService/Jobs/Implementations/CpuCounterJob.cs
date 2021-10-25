using System;
using System.Diagnostics;
using System.Threading.Tasks;
using SchedulerService.Jobs.Interfaces;
using Serilog;

namespace SchedulerService.Jobs.Implementations
{
    public class CpuCounterJob : ICpuCounterJob
    {
        private readonly ILogger _logger;

        public CpuCounterJob(ILogger logger)
        {
            _logger = logger;
        }

        public async Task Run()
        {
            var startTime = DateTime.UtcNow;
            var startCpuUsage = Process.GetCurrentProcess().TotalProcessorTime;
            await Task.Delay(500);

            var endTime = DateTime.UtcNow;
            var endCpuUsage = Process.GetCurrentProcess().TotalProcessorTime;
            var cpuUsedMs = (endCpuUsage - startCpuUsage).TotalMilliseconds;
            var totalMsPassed = (endTime - startTime).TotalMilliseconds;
            var cpuUsageTotal = cpuUsedMs / (Environment.ProcessorCount * totalMsPassed);
            _logger.Information($"CPU usage :{cpuUsageTotal * 100}");
        }
    }
}