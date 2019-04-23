using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace QuartzWithCore.Tasks
{
    public class CheckAvailabilityTask : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            try
            {
                var dataMap = context.JobDetail.JobDataMap;
                var timeRequested = dataMap.GetDateTime("Current Date Time");
                var ticketsNeeded = dataMap.GetInt("Tickets needed");
                var concertName = dataMap.GetString("Concert Name");
                Debug.WriteLine($"{ticketsNeeded} Tickets to the {concertName} concert on {timeRequested.ToString("MM-dd-yyyy")} are available");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Task.FromResult(0);
        }
    }
}
