namespace SchedulerService.Business.Settings
{
    public class RecurringJobSettings
    {
        public RepetitiveJob SetAttemptCountJob { get; set; }
        public RepetitiveJob NotSetAttemptCountJob { get; set; }
        public RepetitiveJob BirthdayPromotionJob { get; set; }
        public RepetitiveJob ManualSemaphoreJob { get; set; }
    }

    
}