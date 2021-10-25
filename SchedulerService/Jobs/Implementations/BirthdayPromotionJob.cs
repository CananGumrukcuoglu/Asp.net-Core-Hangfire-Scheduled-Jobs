using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.Server;
using SchedulerService.Business.Managers.Interfaces;
using SchedulerService.Data.Model;
using SchedulerService.Jobs.Interfaces;
using Serilog;

namespace SchedulerService.Jobs.Implementations
{
    public class BirthdayPromotionJob : IBirthdayPromotionJob
    {
        private readonly ILogger _logger;
        private readonly IBirthdayPromotionManager _birthdayPromotionManager;

        public BirthdayPromotionJob(ILogger logger,IBirthdayPromotionManager birthdayPromotionManager
        )
        {
            _logger = logger;
            _birthdayPromotionManager = birthdayPromotionManager;
        }

        public void Run(PerformContext context)
        {
            _birthdayPromotionManager.CreateBirthdayPromotion();
            //ContinueWith Job Sample
             BackgroundJob.ContinueJobWith<IBirthdayMailJob>(context.BackgroundJob.Id, m => m.Run());
        }
        
    }
}