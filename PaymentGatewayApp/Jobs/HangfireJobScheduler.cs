using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGatewayApp.Jobs
{
    public class HangfireJobScheduler
    {
        public static void ScheduleJobs()
        {
            RecurringJob.RemoveIfExists(nameof(ReportJob));
            RecurringJob.AddOrUpdate<ReportJob>(nameof(ReportJob),job=>job.Run(JobCancellationToken.Null), Cron.Daily(12,0),TimeZoneInfo.Local);
          //  RecurringJob.AddOrUpdate<ReportJob>(nameof(ReportJob), job => job.Run(JobCancellationToken.Null), Cron.Minutely, TimeZoneInfo.Local);
        }
    }
}
