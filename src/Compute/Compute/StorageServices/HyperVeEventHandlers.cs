using System;
using System.Collections.Generic;
using System.Management;
using System.Text;

namespace Microsoft.Azure.Commands.Compute.StorageServices
{
    public class CompletionHandler 
    {
        public bool isCompleted { get; set; } = false; 
        public void onCompletion(object source, CompletedEventArgs e)
        {
            this.isCompleted = true;
            Console.WriteLine("Object Complete handler " + e.Status);
        }
    }

    public class ProgressHandler
    {
        public int current { get; set; }
        public int upperBound { get; set; }

        public void onProgress(object source, ProgressEventArgs e)
        {
            this.current = e.Current;
            this.upperBound = e.UpperBound;
            Console.WriteLine("progress event handler" + this.current + " " + this.upperBound);

        }
    }
}
