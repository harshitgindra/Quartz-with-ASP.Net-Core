using Quartz;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity;

namespace Services
{
    public class ReserveTicketsTask : IJob
    {
        private List<IStep> _workflowSteps;
        public ReserveTicketsTask()
        {
            var container = new UnityContainer();
            _workflowSteps = new List<IStep>
            {
                container.Resolve<GetPriceStep>(),
                container.Resolve<ReserveTickets>(),
                container.Resolve<PrintReceiptStep>(),
            };
        }

        public Task Execute(IJobExecutionContext context)
        {
            try
            {
                foreach (var step in _workflowSteps)
                {
                    step.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Task.FromResult(0);
        }
    }
}
