using Microsoft.CLU.Common.Properties;
using System;
using System.Diagnostics;
using System.Linq;

namespace CLURun
{
    /// <summary>
    /// Type responsible for parsing and bootstrapping command execution.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Microsoft.CLU.Run (clurun.exe) main entry point.
        /// </summary>
        /// <param name="args">The commandline arguments</param>
        public static void Main(string[] args)
        {
            var envVarName = "DebugCLU";
            var debugClu = Environment.GetEnvironmentVariable(envVarName);
            if (!String.IsNullOrEmpty(debugClu))
            {
                System.Console.WriteLine(string.Format("This is your chance to attach a debugger.." + 
                    "(to get rid of this prompt use {0} env variable ))", envVarName));
                System.Console.ReadLine();
            }
            Microsoft.CLU.Run.CLURun.Main(args);
        }
    }
}
