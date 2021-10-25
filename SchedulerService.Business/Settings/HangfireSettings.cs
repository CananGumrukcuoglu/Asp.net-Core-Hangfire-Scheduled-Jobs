namespace SchedulerService.Business.Settings
{
    public class HangfireSettings
    {
        public HangfireServer Server { get; set; }
    }

    public class HangfireServer
    {
        public string Name { get; set; }
        public int WorkerCount { get; set; }
        public string[] QueueList { get; set; }
    }
}