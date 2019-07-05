using System;
using System.Diagnostics;
using System.IO;
using WorkflowSteps.Interface;

namespace WorkflowSteps
{
    public class GetPriceStep : IStep
    {
        public void Start()
        {
            Debug.WriteLine("Get Ticket Price");
            using (StreamWriter writer = File.AppendText(@"C:\Temp\app.log"))
            {
                writer.WriteLine($"[{DateTime.Now}]: Get Ticket Price");
            }
        }
    }
}
