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
                Debug.WriteLine("Tickets to the concert are available");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Task.FromResult(0);
        }
    }
}
