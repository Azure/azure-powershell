using Microsoft.CLU.Common.Properties;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Microsoft.CLU.Run
{
    /// <summary>
    /// Type responsible for parsing and bootstrapping command execution.
    /// </summary>
    public class CLURun
    {
        /// <summary>
        /// Microsoft.CLU.Run (clurun.exe) main entry point.
        /// </summary>
        /// <param name="args">The commandline arguments</param>
        public static void Main(string[] args)
        {
            CLUEnvironment.Console = new ConsoleInputOutput(args);

            try
            {
                Stopwatch sw = Stopwatch.StartNew();

                CLURun cluRun = new CLURun();
                cluRun.Parse(args);

                sw.Stop();
                CLUEnvironment.Console.WriteDebugLine($"The command executed in {sw.ElapsedMilliseconds} ms");
            }
            catch (Exception exc)
            {
                CLUEnvironment.Console.WriteErrorLine(exc.Message);
                CLUEnvironment.Console.WriteDebugLine(exc.StackTrace);
            }
        }

        /// <summary>
        /// Parse the commandline argument and bootstrap the command execution.
        /// </summary>
        /// <param name="arguments">The commandline arguments</param>
        private void Parse(string [] arguments)
        {
            if (arguments.Count() == 0)
            {
                DisplayHelp();
                return;
            }

            var mode = GetMode(arguments);
            //TODO: #26 Decide the best way to find rootPath
            var assemblyLocation = typeof(Microsoft.CLU.Common.EntryPoint).GetTypeInfo().Assembly.Location;
            var rootPath = System.IO.Path.GetDirectoryName(assemblyLocation);
            CLUEnvironment.SetRootPaths(rootPath);  

            // Run the command.
            mode.Run(arguments);
        }


        private void DisplayHelp()
        {
            CLUEnvironment.Console.Write(Strings.CLURun_DisplayHelp_HelpMessage);
        }

        /// <summary>
        /// Lookup the commandline argument to find the run mode.
        /// </summary>
        /// <param name="arguments">The commandline arguments</param>
        /// <returns>The run mode</returns>
        private IRunMode GetMode(string [] arguments)
        {
            IRunMode[] modes =
            {
                new PackageManagementMode(),
                new CommandExecMode()
            };

            IRunMode selectedMode = modes.FirstOrDefault(m => m.CanHandle(arguments));
            if (selectedMode == null)
            {
                throw new ArgumentException("Unable to find a mode that can handle the given command-line arguments");
            }

            return selectedMode;
        }
    }
}
