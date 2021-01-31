using System;
using System.Diagnostics;
using System.IO;
using Services.Interface;

namespace Services
{
    public class PrintReceiptStep : IStep
    {
        public void Start()
        {
            Debug.WriteLine("Print Receipt");
            using (StreamWriter writer = File.AppendText(@"C:\Temp\app.log"))
            {
                writer.WriteLine($"[{DateTime.Now}]: Print Receipt");
            }
        }
    }
}
