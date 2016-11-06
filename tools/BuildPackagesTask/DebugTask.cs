namespace Microsoft.Azure.Build.Tasks
{
    using Microsoft.Build.Utilities;
    using System;
    using ThreadTask = System.Threading.Tasks;



    /// <summary>
    /// Utility task to help debug
    /// </summary>
    public class DebugTask : Microsoft.Build.Utilities.Task
    {
        public int Timeoutmiliseconds { get; set; }
        public override bool Execute()
        {
            if (Timeoutmiliseconds == 0) Timeoutmiliseconds = 20000;
            Console.WriteLine("Press any key to continue or it will continue in {0} miliseconds", Timeoutmiliseconds);
            System.Threading.Thread.Sleep(Timeoutmiliseconds);
            return true;
        }
    }
}
