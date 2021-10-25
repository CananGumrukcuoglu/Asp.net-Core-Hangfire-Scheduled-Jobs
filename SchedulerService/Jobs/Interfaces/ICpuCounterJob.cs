using System.Threading.Tasks;
using Hangfire;

namespace SchedulerService.Jobs.Interfaces
{
    public interface ICpuCounterJob
    {
        [AutomaticRetry(Attempts = 0, LogEvents = false, OnAttemptsExceeded = AttemptsExceededAction.Delete)]
        [JobDisplayName("Get Cpu Performance")]
        Task Run();
    }
}