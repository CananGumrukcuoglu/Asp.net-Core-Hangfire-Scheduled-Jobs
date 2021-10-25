using System;
using System.Collections.Generic;
using SchedulerService.Data.Model;
using SchedulerService.Jobs.Interfaces;
using Serilog;

namespace SchedulerService.Jobs.Implementations
{
    public class BirthdayMailJob:IBirthdayMailJob
    {
        private readonly ILogger _logger;

        public BirthdayMailJob(ILogger logger)
        {
            _logger = logger;
        }
        public void Run()
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
                _logger.Information($"Happy birthday {user.DsName} {user.DsSurname}. We created a special promotion for you today.");
            }
        }
    }
}