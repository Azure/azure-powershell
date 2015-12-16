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
        public static void Main(string[] args) { }

        /// <summary>
        /// Microsoft.CLU.Run (clurun.exe) main entry point.
        /// </summary>
        /// <param name="args">The commandline arguments</param>
        public static Microsoft.CLU.CommandModelErrorCode Execute(string[] args)
        {
            CLUEnvironment.Console = new ConsoleInputOutput(args);

            try
            {
                Stopwatch sw = Stopwatch.StartNew();

                CLURun cluRun = new CLURun();
                var result = cluRun.Parse(args);

                sw.Stop();
                CLUEnvironment.Console.WriteDebugLine($"The command executed in {sw.ElapsedMilliseconds} ms");
                return result;
            }
            catch (Exception exc)
            {
                CLUEnvironment.Console.WriteErrorLine(exc.Message);
                CLUEnvironment.Console.WriteDebugLine(exc.StackTrace);
                return Microsoft.CLU.CommandModelErrorCode.InternalFailure;
            }
        }

        /// <summary>
        /// Parse the commandline argument and bootstrap the command execution.
        /// </summary>
        /// <param name="arguments">The commandline arguments</param>
        private Microsoft.CLU.CommandModelErrorCode Parse(string [] arguments)
        {
            if (arguments.Count() == 0)
            {
                DisplayHelp();
                return CommandModelErrorCode.MissingParameters;
            }

            var mode = GetMode(arguments);
            //TODO: #26 Decide the best way to find rootPath
            var assemblyLocation = typeof(Microsoft.CLU.Common.EntryPoint).GetTypeInfo().Assembly.Location;
            var rootPath = System.IO.Path.GetDirectoryName(assemblyLocation);
            CLUEnvironment.SetRootPaths(rootPath);  

            // Run the command.
            return mode.Run(arguments);
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
