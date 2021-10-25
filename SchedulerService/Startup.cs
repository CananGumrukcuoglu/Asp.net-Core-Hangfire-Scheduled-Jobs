using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.Dashboard;
using Hangfire.PostgreSql;
using HangfireBasicAuthenticationFilter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SchedulerService.Business.Managers.Implementations;
using SchedulerService.Business.Managers.Interfaces;
using SchedulerService.Business.Settings;
using SchedulerService.Data.Context;
using SchedulerService.Data.HfModel;
using SchedulerService.Jobs;
using SchedulerService.Jobs.Implementations;
using SchedulerService.Jobs.Interfaces;
using SchedulerService.Services.Implementations;
using SchedulerService.Services.Interfaces;

namespace SchedulerService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            StartupExtensions.Configuration = Configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSettings();
            services.AddHangfire();
            services.AddDbContexts();
            services.AddManagers();
            services.AddJobs();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            /* starts service with getting singleton service object */
            var cronJobStarter = app.ApplicationServices.GetService<ICronJobStarter>();
            cronJobStarter.StartJobs();
            app.UseAuthorization();
            app.UseHangfireDashboard("/hangfire", new DashboardOptions()
            {
                AppPath =
                    "http://dotnetkonf.com/", //The path for the Back To Site link. Set to null in order to hide the Back To  Site link.
                DashboardTitle = "BookCorner Scheduled Jobs",
                //  IsReadOnlyFunc = (DashboardContext context) => true, // If it is true, user can not delete/ enqueue the jobs.
                Authorization = new[]
                {
                    new HangfireCustomBasicAuthenticationFilter
                    {
                        User = Configuration.GetSection("HangfireSettings:UserName").Value,
                        Pass = Configuration.GetSection("HangfireSettings:Password").Value
                    }
                }
            });
            // app.UseHangfireServer(
            //     new BackgroundJobServerOptions()
            //     {
            //         ServerName = "canan",
            //         WorkerCount = 10,
            //         CancellationCheckInterval = TimeSpan.FromSeconds(10),
            //         Queues = Configuration.GetSection("HangfireSettings:QueueList").Get<string[]>()
            //     }
            // );
            app.UseHangfireServers();
            logger.LogInformation("hangfire test log");
        }
        
    }

    public static class StartupExtensions
    {
        public static IConfiguration Configuration { get; set; }

        public static void AddHangfire(this IServiceCollection services)
        {
            // Add Hangfire services.
            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseDefaultTypeSerializer()
                .UseStorage(GetPostgreSqlStorage()));
            // Add the processing server as IHostedService
            services.AddHangfireServer();
        }
        private static PostgreSqlStorage GetPostgreSqlStorage()
        {
            return new PostgreSqlStorage(
                Configuration.GetConnectionString("HangfireConnection"),
                new PostgreSqlStorageOptions()
                {
                    QueuePollInterval = TimeSpan.FromSeconds(10),
                    PrepareSchemaIfNecessary = true,
                    SchemaName = "hangfire",
                    InvisibilityTimeout = TimeSpan.FromMinutes(1)
                });
        }

        public static void AddDbContexts(this IServiceCollection services)
        {
            services.AddDbContext<BookContext>(opt =>
                opt.UseNpgsql(Configuration.GetConnectionString("BookConnection"), b => b.CommandTimeout(150)));
            services.AddDbContext<HfContext>(opt =>
                opt.UseNpgsql(Configuration.GetConnectionString("HangfireConnection"), b => b.CommandTimeout(150)));
        }

        public static void AddJobs(this IServiceCollection services)
        {
            services.AddSingleton<ICronJobStarter, CronJobStarter>();
            services.AddScoped<ISetAttemptCountJob, SetAttemptCountJob>();
            services.AddScoped<INotSetAttemptCountJob, NotSetAttemptCountJob>();
            services.AddScoped<IHangfireStartedNotificationJob, HangfireStartedNotificationJob>();
            services.AddScoped<ICpuCounterJob, CpuCounterJob>();
            services.AddScoped<IBirthdayPromotionJob, BirthdayPromotionJob>();
            services.AddScoped<IBirthdayMailJob, BirthdayMailJob>();
            services.AddScoped<ICancellationJob, CancellationJob>();
            services.AddScoped<IManualSemaphoreJob, ManualSemaphoreJob>();
        }

        public static void AddManagers(this IServiceCollection services)
        {
            services.AddScoped<IBirthdayPromotionManager,BirthdayPromotionManager>();
        }

        public static void AddSettings(this IServiceCollection services)
        {
            services.Configure<JobSettings>(Configuration.GetSection("JobSettings"));
        }

        public static void UseHangfireServers(this IApplicationBuilder app)
        {
            var serverList = Configuration.GetSection("HangfireSettings:ServerList").Get<List<HangfireServer>>();
            foreach (var server in serverList)
            {
                app.UseHangfireServer(
                    new BackgroundJobServerOptions()
                    {
                        ServerName = server.Name,
                        WorkerCount = server.WorkerCount,
                        CancellationCheckInterval = TimeSpan.FromSeconds(10),
                        Queues = server.QueueList
                    }
                );
            }
        }
    }
}