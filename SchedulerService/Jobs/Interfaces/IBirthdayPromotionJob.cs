using System.Threading.Tasks;
using Hangfire;
using Hangfire.Server;

namespace SchedulerService.Jobs.Interfaces
{
    public interface IBirthdayPromotionJob
    {
        [AutomaticRetry(Attempts = 0, LogEvents = false, OnAttemptsExceeded = AttemptsExceededAction.Delete)]
        [JobDisplayName("Create Birthday Promotion")]
        void Run(PerformContext context);
    }
}