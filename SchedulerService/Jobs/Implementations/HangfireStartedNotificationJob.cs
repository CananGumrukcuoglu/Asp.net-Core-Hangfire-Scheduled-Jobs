using System.Threading.Tasks;
using SchedulerService.Jobs.Interfaces;
using Serilog;

namespace SchedulerService.Jobs.Implementations
{
    public class HangfireStartedNotificationJob:IHangfireStartedNotificationJob
    {
        private readonly ILogger _logger;

        public HangfireStartedNotificationJob(ILogger logger)
        {
            _logger = logger;
        }
        public void Run()
        {
            _logger.Information("Hangire is up and running");
        }
    }
}