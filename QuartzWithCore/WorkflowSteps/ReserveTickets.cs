using System;
using System.Diagnostics;
using System.IO;
using WorkflowSteps.Interface;

namespace WorkflowSteps
{
    public class ReserveTickets : IStep
    {
        public void Start()
        {
            Debug.WriteLine("Reserve Tickets");
            using (StreamWriter writer = File.AppendText(@"C:\Temp\app.log"))
            {
                writer.WriteLine($"[{DateTime.Now}]: Reserve Tickets");
            }
        }
    }
}
