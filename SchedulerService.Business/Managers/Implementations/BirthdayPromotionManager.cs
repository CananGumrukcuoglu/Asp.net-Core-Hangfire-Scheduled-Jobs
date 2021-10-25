using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using SchedulerService.Business.Managers.Interfaces;
using SchedulerService.Data.Model;

namespace SchedulerService.Business.Managers.Implementations
{
    public class BirthdayPromotionManager:IBirthdayPromotionManager
    {
        private readonly ILogger<BirthdayPromotionManager> _logger;

        public BirthdayPromotionManager(ILogger<BirthdayPromotionManager> logger)
        {
            _logger = logger;
        }
        public void CreateBirthdayPromotion()
        {
            var userList = new List<User>()
            {
                new User {IdUser = 1, DsEmail = "xyz@gmail.com", DsName = "Ada", DsSurname = "Lovelace"},
                new User {IdUser = 2, DsEmail = "xyz@gmail.com", DsName = "Grace", DsSurname = "Hopper"},
                new User {IdUser = 3, DsEmail = "xyz@gmail.com", DsName = "Erna", DsSurname = "Hoover"},
                new User {IdUser = 4, DsEmail = "xyz@gmail.com", DsName = "Marissa", DsSurname = "Mayer"}
            };
            foreach (var user in userList)
            {
                var discountRate = new Random().Next(1, 15);
                _logger.LogInformation($"For {user.DsName} {user.DsSurname}, %{discountRate} discount is defined.");
            }
        }
    }
}