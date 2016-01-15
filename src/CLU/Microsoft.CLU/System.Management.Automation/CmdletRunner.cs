using Microsoft.CLU;
using Microsoft.CLU.CommandBinder;
using Microsoft.CLU.Common;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace System.Management.Automation.Runspaces
{
    /// <summary>
    /// The type which can run a given command.
    /// </summary>
    internal class CmdletRunner
    {
        /// <summary>
        /// The input pipe for the command.
        /// </summary>
        public IPipe<string> PipeIn
        {
            get; private set;
        }

        /// <summary>
        /// The output pipe for the command.
        /// </summary>
        public IPipe<string> PipeOut
        {
            get; private set;
        }

        /// <summary>
        /// The data streams associated with the command.
        /// </summary>
        public PSDataStream PSDataStream
        {
            get; private set;
        }

        /// <summary>
        /// The details of the cmdlet that runner runs.
        /// </summary>
        public CmdletInfo CmdletInfo { get; private set; }

        /// <summary>
        /// Creates an instance of CmdletRunner.
        /// </summary>
        /// <param name="command">The command to run</param>
        /// <param name="sessionState">The session state for the command</param>
        public CmdletRunner(Command command, InitialSessionState sessionState)
        {
            _command = command;
            _sessionState = sessionState;
            var pipe = new InMemorySyncPipe();
            PipeIn = pipe;
            PipeOut = pipe;
        }

        /// <summary>
        /// Creates an instance of CmdletRunner.
        /// </summary>
        /// <param name="command">The command to run</param>
        /// <param name="sessionState">The session state for the command</param>
        /// <param name="pipeSource">The instance of CmdletRunner that provide source pipe for the command</param>
        public CmdletRunner(Command command, InitialSessionState sessionState, CmdletRunner pipeSource)
        {
            Debug.Assert(command != null);
            Debug.Assert(sessionState != null);
            Debug.Assert(pipeSource != null);

            _command = command;
            _sessionState = sessionState;
            PipeIn = pipeSource.PipeOut;
            PipeOut = new InMemorySyncPipe();
        }

        /// <summary>
        /// Creates an instance of CmdletRunner.
        /// </summary>
        /// <param name="command">The command to run</param>
        /// <param name="sessionState">The session state for the command</param>
        /// <param name="pipeSource">The source pipe for the command</param>
        public CmdletRunner(Command command, InitialSessionState sessionState, IPipe<string> pipeSource)
        {
            Debug.Assert(command != null);
            Debug.Assert(sessionState != null);
            Debug.Assert(pipeSource != null);

            _command = command;
            _sessionState = sessionState;
            PipeIn = pipeSource;
            PipeOut = new InMemorySyncPipe();
        }

        /// <summary>
        /// Run the command.
        /// </summary>
        public void Invoke()
        {
            CLUEnvironment.IsThreadSafe = true;
            var assemblyLocation = typeof(Microsoft.CLU.Common.EntryPoint).GetTypeInfo().Assembly.Location;
            var rootPath = @"C:\azure-powershell\drop\clurun\win7-x64";//System.IO.Path.GetDirectoryName(assemblyLocation);
            CLUEnvironment.SetRootPaths(rootPath);

            PSDataStream = new PSDataStream(new PSDataStreams());
            HostStreamInfo hostStreamInfo = new HostStreamInfo
            {
                DataStream = PSDataStream,
                IsInputRedirected = true,
                IsOutputRedirected = true,
                ReadFromPipe = PipeIn,
                WriteToPipe = PipeOut
            };

            try
            {
                // We support only one configuration
                var commandConfiguration = _sessionState.ModulesConfigurations.FirstOrDefault();
                if (commandConfiguration == null)
                {
                    return;
                }

                var modules = commandConfiguration.GetListValue(Constants.CmdletModulesConfigKey);
                var cmdletValue = CmdletLocalPackage.FindCmdlet(modules, _command.CommandDiscriminators);
                if (cmdletValue == null || cmdletValue.LoadCmdlet() == null)
                {
                    throw new InvalidOperationException($"Could not find matching Cmdlet for the command '{_command.CommandText}' in the modules { string.Join(", ", modules) }");
                }

                var doDebug = _command.Parameters
                    .Where(p => p.Value == null && string.Equals(p.Name, "debug", StringComparison.OrdinalIgnoreCase))
                    .Any();
                var doVerbose = _command.Parameters
                    .Where(p => p.Value == null && string.Equals(p.Name, "verbose", StringComparison.OrdinalIgnoreCase))
                    .Any();
                string debugPreference = Constants.CmdletPreferencesSilentlyContinue;
                if (doDebug)
                {
                    debugPreference = Constants.CmdletPreferencesContinue;
                }
                string verbosePreference = Constants.CmdletPreferencesSilentlyContinue;
                if (doVerbose)
                {
                    verbosePreference = Constants.CmdletPreferencesContinue;
                }

                var runtimeHost = new System.Management.Automation.Host.CLUHost(new string[] { },
                    hostStreamInfo, debugPreference,
                    verbosePreference);

                var binderAndCommand = new CmdletBinderAndCommand(commandConfiguration, runtimeHost, cmdletValue);
                binderAndCommand.ParserSeekBeginAndRun += () =>
                {
                    // Bind dynamic parameters.
                    BindParameters(binderAndCommand);
                };

                BindParameters(binderAndCommand);
                binderAndCommand.MarkStaticParameterBindFinished();
                // Bind pipeline parameters and others and run the command.
                binderAndCommand.Invoke();
                CmdletInfo = binderAndCommand.CmdletInfo;
            }
            finally
            {
                PipeOut.SetReadable();
            }
        }

        /// <summary>
        /// Bind the parameters
        /// </summary>
        /// <param name="cmdletBinder">The cmdlet binder</param>
        private void BindParameters(ICommandBinder cmdletBinder)
        {
            int position = 0;
            foreach (var parameter in _command.Parameters)
            {
                if (parameter.Name == null)
                {
                    string value = ObjectToJsonString(parameter.Value);
                    cmdletBinder.BindArgument(position, value);
                    position++;
                }
                else
                {
                    if (parameter.IsSwitch)
                    {
                        cmdletBinder.TryBindSwitch(parameter.Name);
                    }
                    else
                    {
                        string value = ObjectToJsonString(parameter.Value);
                        cmdletBinder.BindArgument(parameter.Name, value);
                    }
                }
            }
        }

        /// <summary>
        /// Convert an object to json string.
        /// </summary>
        /// <param name="obj">The object to convert</param>
        /// <returns></returns>
        private string ObjectToJsonString(object obj)
        {
            if (obj == null)
            {
                // If user passes null value, during binding time if the parameter
                // is a reference type then null be assigned. If it's a value type
                // binder throws convertion exception, value type cannot have null
                // value.
                return null;
            }

            var typeInfo = obj.GetType().GetTypeInfo();
            if (typeInfo.IsPrimitive || typeInfo.IsEnum || obj.GetType() == typeof(string))
            {
                return obj.ToString();
            }

            return JsonConvert.SerializeObject(obj);
        }

        #region Private fields

        /// <summary>
        /// The command to run.
        /// </summary>
        private Command _command;

        /// <summary>
        /// The session state for the command.
        /// </summary>
        private InitialSessionState _sessionState;

        #endregion
    }
}
