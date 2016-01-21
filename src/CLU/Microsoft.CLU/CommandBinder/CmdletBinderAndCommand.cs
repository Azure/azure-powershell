using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using Microsoft.CLU.Common;
using Microsoft.CLU.Help;
using Microsoft.CLU.Metadata;
using Microsoft.CLU.Common.Properties;
using Microsoft.ApplicationInsights;
using System.Management.Automation.Host;

namespace Microsoft.CLU.CommandBinder
{
    /// <summary>
    /// Implementation of ICommandBinder and ICommand interfaces to support the "Cmdlet programming model".
    /// </summary>
    internal class CmdletBinderAndCommand : ICommandBinder, ICommand
    {
        #region Public properties

        /// <summary>
        /// The call-back to model (cmdletCommandModel instance) for seeking the parser back to begin and to run the parser.
        /// </summary>
        public Action ParserSeekBeginAndRun;

        /// <summary>
        /// The call-back to model (cmdletCommandModel instance) for seeking the parser back by an offset and to run the parser.
        /// </summary>
        public Action<uint> ParserSeekBackAndRun;

        /// <summary>
        /// The details of Cmdlet that this binder instance associated with.
        /// </summary>
        public CmdletInfo CmdletInfo { get; private set; }

        /// <summary>
        /// The discriminators used to resolve the Cmdlet that this binder instance associated with.
        /// </summary>
        public IEnumerable<string> Discriminators
        {
            get { return _discriminatorBinder.Discriminators; }
        }

        #endregion

        /// <summary>
        /// Creates an instance of CmdletBinderAndCommand with an alreadly rsolved Cmdlet.
        /// </summary>
        /// <param name="commandConfiguration">The command configuration</param>
        /// <param name="runtime">The runtime</param>
        /// <param name="cmdletValue">The resolved Cmdlet</param>
        public CmdletBinderAndCommand(ConfigurationDictionary commandConfiguration, ICommandRuntime runtime, CmdletValue cmdletValue)
        {
            Debug.Assert(commandConfiguration != null);
            Debug.Assert(runtime != null);
            Debug.Assert(cmdletValue != null);
            Debug.Assert(cmdletValue.Package != null);
            Debug.Assert(cmdletValue.LoadCmdlet() != null);

            _runtime = runtime;
            _commandConfiguration = commandConfiguration;
            _staticParameterBindInProgress = true;
            InitTelemetry();
            InitCmdlet(cmdletValue.LoadCmdlet(), cmdletValue.PackageAssembly.FullPath);
            Action<Type, uint, string> discriminatorBindFinished = (Type cmdletType, uint seekBackOffset, string fullPath) =>
            {
                // NOP
            };

            _discriminatorBinder = new DiscriminatorBinder(_commandConfiguration.GetListValue(Constants.CmdletModulesConfigKey), discriminatorBindFinished, cmdletValue);
        }

        /// <summary>
        /// Creates an instance of CmdletBinderAndCommand.
        /// </summary>
        /// <param name="commandConfiguration">The command configuration</param>
        /// <param name="runtime">The runtime</param>
        public CmdletBinderAndCommand(ConfigurationDictionary commandConfiguration, ICommandRuntime runtime)
        {
            Debug.Assert(commandConfiguration != null);
            Debug.Assert(runtime != null);
            _runtime = runtime;
            _commandConfiguration = commandConfiguration;
            InitTelemetry();
            Action<Type, uint, string> discriminatorBindFinished = (Type cmdletType, uint seekBackOffset, string fullPath) =>
            {
                _staticParameterBindInProgress = true;
                InitCmdlet(cmdletType, fullPath);
                if (seekBackOffset > 0)
                {
                    ParserSeekBackAndRun(seekBackOffset);
                    _staticParameterBindInProgress = false;
                }
            };

            _discriminatorBinder = new DiscriminatorBinder(_commandConfiguration.GetListValue(Constants.CmdletModulesConfigKey), discriminatorBindFinished);
        }

        #region ICommandBinder implementation

        /// <summary>
        /// Bind a positonal argument.
        /// </summary>
        /// <param name="position">The argument position in the command line</param>
        /// <param name="value">The value of the argument</param>
        public void BindArgument(int position, string value)
        {
            _discriminatorBinder.BindIfInProgress(position, value);
            if (_staticParameterBindInProgress)
            {
                _staticParametersBindHandler.Bind(position, value);
            }
            else if (_dynamicParameterBindInProgress)
            {
                _dynmicParametersBindHandler.Bind(position, value);
            }
        }

        /// <summary>
        /// Bind a named argument.
        /// </summary>
        /// <param name="name">The argument name</param>
        /// <param name="value">The argument value</param>
        public void BindArgument(string name, string value)
        {
            _discriminatorBinder.EnsureBound();
            if (_staticParameterBindInProgress)
            {
                _staticParametersBindHandler.Bind(name, value);
            }
            else if (_dynamicParameterBindInProgress)
            {
                _dynmicParametersBindHandler.Bind(name, value);
            }
        }

        /// <summary>
        /// Attempt to bind an argument name switch.
        /// </summary>
        /// <param name="name">The argument name</param>
        /// <returns>true if the argument is known and is a switch</returns>
        public bool TryBindSwitch(string name)
        {
            _discriminatorBinder.EnsureBound();
            // This EnsureBind call MAY cause ICommandLineParser::Parse to be invoked again.
            // Model -> ICommandLineParser::Parse -> [..] -> TryBindSwitch
            //       -> EnsureBound -> discriminatorBindFinished -> ParserSeekBackAndRun
            //                      -> ICommandLineParser::Parse
            // that result in recursive 'Parse' call. When control return back to
            // the first 'Parse' call we are ensuring we don't do anything wrong.
            // When control return to first Parse call both staticParameterBindInProgress
            // and _dynamicParameterBindInProgress guaranteed to be FALSE.
            if (_staticParameterBindInProgress)
            {
                return _staticParametersBindHandler.TryBindSwitch(name);
            }
            else if (_dynamicParameterBindInProgress)
            {
                return _dynmicParametersBindHandler.TryBindSwitch(name);
            }

            return false;
        }

        /// <summary>
        /// Generates a list of matching commands for the given set of parameters
        /// </summary>
        /// <param name="args">The command-line arguments to be considered in the help logic.</param>
        /// <returns>A list of lines containing help information.</returns>
        public IEnumerable<string> ListCommands(string[] args)
        {
#if PSCMDLET_HELP
            return CmdletHelp.Generate(parser.FormatParameterName, _discriminatorBinder.Modules, args, prefix);
#else
            var commands = CommandDispatchHelper
                .CompleteCommands(new HelpPackageFinder(CLUEnvironment.GetPackagesRootPath()), args).ToArray();
            if (commands.Length > 0)
            {
                foreach (var command in commands)
                {
                    yield return command.Discriminators.Replace(';', ' ');
                }
            }
            else
            {
                yield return string.Format(Strings.CmdletHelp_Generate_NoCommandAvailable, CLUEnvironment.ScriptName, String.Join(" ", args));
            }
#endif
        }

#endregion

#region ICommand implementation

        /// <summary>
        /// Tells whether the command is synchronous or asynchronous.
        /// </summary>
        public bool IsAsync
        {
            get
            {
                // The Cmdlet programming model is synchronous.
                return false;
            }
        }

        public bool SupportsAutomaticHelp
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Invokes the command synchronously. This method perform following actions
        /// 1. Bind dynamic and other types of parameters
        /// 2. Invoke System.Management.Automation.Cmdlets methods in following order
        ///       a. BeginProcessing
        ///       b. ProcessRecord
        ///       c. EndProcessing
        /// </summary>
        public void Invoke()
        {
            _discriminatorBinder.EnsureBound();

            try
            {
                BindDynamicParameters();
                FailIfAnyUnknownArguments();
                BindFromPositionalFiles();

                _cmdlet.BeginProcessing();
                BindPipelineAndPositionalParameters();
                _cmdlet.EndProcessing();

                _cmdlet.FlushPipeline(_discriminatorBinder.Package);

                // Ideally, we should only save if there is one or more
                // setting that has been modified (or added or removed)
                // However, since the session state
                // has the ability to store objects of arbitrary types, there is no 
                // good way to detect exactly when changes made to complex objects. 
                // We could consider moving the save to the Set methods of the 
                // the PSVariablesInstrinsics class (but that still wouldn't 
                // catch modifications made to complex objects), so for that, we would
                // still have to save here...
                var psCmdlet = _cmdlet as PSCmdlet;
                if (psCmdlet != null)
                {
                    psCmdlet.SessionState.Save();
                }
            }
            catch (CmdletTerminateException terminateException)
            {
                _telemetryClient.TrackException(terminateException, GetErrorTelemetryProperties());
                _cmdlet.CommandRuntime.WriteError(terminateException.ErrorRecord);
            }
            catch (Exception exception)
            {
                _telemetryClient.TrackException(exception, GetErrorTelemetryProperties());
                _cmdlet.CommandRuntime.WriteError(new ErrorRecord(exception, "", ErrorCategory.InvalidResult, _cmdlet));
            }
            finally
            {
                Task.Run(() => _telemetryClient.Flush()).Wait(TimeSpan.FromSeconds(5));
            }
        }

        /// <summary>
        /// Invokes an asynchronous command.
        /// </summary>
        public Task InvokeAsync()
        {
            throw new InvalidOperationException(Strings.CmdletBinderAndCommand_InvokeAsync_CmdletNotSupportAsyncInvoke);
        }

#endregion

        public void MarkStaticParameterBindFinished()
        {
            Debug.Assert(_staticParameterBindInProgress);
            _staticParameterBindInProgress = false;
        }

        /// <summary>
        /// Creates a Cmdlet instance of the given type.
        /// This method throws InvalidCmdletException if the cmdlet is not invokable.
        /// </summary>
        /// <returns>The cmdlet instance</returns>
        private Cmdlet CreateCmdlet(Type cmdletType, string assemblyLocation)
        {
            var nounPrefix = _commandConfiguration.Get(Constants.CmdletNounPrefixConfigKey, false);

            var ctors = cmdletType.GetConstructors();
            if (ctors == null || ctors.Length == 0)
            {
                throw new InvalidCmdletException(string.Format(Strings.CmdletBinderAndCommand_CreateCmdlet_CmdletMissingConstructor, cmdletType.FullName));
            }

            var defaultCtor = ctors.FirstOrDefault(c => c.GetParameters().Length == 0);
            if (defaultCtor == null)
            {
                throw new InvalidCmdletException(string.Format(Strings.CmdletBinderAndCommand_CreateCmdlet_CmdletMissingDefaultConstructor, cmdletType.FullName));
            }

            // Create the Cmdlet instance

            var instance = defaultCtor.Invoke(new Object[0]) as Cmdlet;

            // Associate the instance with its runtime and a few other pieces of data if it is a PSCmdlet

            var moduleInfo = new PSModuleInfo(cmdletType.GetTypeInfo().Assembly, assemblyLocation, _runtime);
            CmdletInfo = new CmdletInfo(cmdletType, moduleInfo, _runtime, nounPrefix);

            instance.CommandRuntime = _runtime;

            var psCmdlet = instance as PSCmdlet;

            if (psCmdlet != null)
            {
                psCmdlet.MyInvocation = new InvocationInfo()
                {
                    MyCommand = CmdletInfo,
                    InvocationName = CmdletInfo.Name,
                    PipelineLength = 1,
                    PipelinePosition = 1,
                    CommandOrigin = CommandOrigin.Runspace
                };

                psCmdlet.SessionState = new SessionState();
                psCmdlet.SessionState.Load();
            }

            return instance;
        }

        /// <summary>
        /// Load the Cmdlet instance, metadata and initialize static parameter binder.
        /// </summary>
        /// <param name="cmdletType">The cmdlet types</param>
        private void InitCmdlet(Type cmdletType, string assemblyLocation)
        {
            _cmdlet = CreateCmdlet(cmdletType,assemblyLocation);
            _cmdletMetadata = CmdletMetadata.Load(_cmdlet);
            _staticParametersBindState = new ParameterBindState(_cmdletMetadata.Type);
            _staticParametersBindHandler = new BindHandler(_cmdlet, _staticParametersBindState);
        }

        private IDictionary<string, string> GetErrorTelemetryProperties()
        {
            Dictionary<string, string> eventProperties = new Dictionary<string, string>();
            eventProperties.Add("IsSuccess", "False");
            if (_cmdlet != null)
            {
                eventProperties.Add("ModuleName", _cmdlet.GetType().GetTypeInfo().Assembly.GetName().Name);
                eventProperties.Add("ModuleVersion", _cmdlet.GetType().GetTypeInfo().Assembly.GetName().Version.ToString());
                var cmdletAliasAttribute = _cmdlet.GetType().GetTypeInfo().GetCustomAttributes()
                         .FirstOrDefault((at) => at.GetType().FullName.Equals("System.Management.Automation.CliCommandAliasAttribute"));

                if (cmdletAliasAttribute != null)
                {
                    var attrType = cmdletAliasAttribute.GetType();
                    eventProperties.Add("CommandName", "az " + (string)attrType.GetProperty("CommandName").GetValue(cmdletAliasAttribute));
                }
            }
            var _cluHost = _runtime as CLUHost;
            if (_cluHost != null)
            {
                eventProperties.Add("HostVersion", _cluHost.Version.ToString());
                eventProperties.Add("InputFromPipeline", _cluHost.IsInputRedirected.ToString());
                eventProperties.Add("OutputToPipeline", _cluHost.IsOutputRedirected.ToString());
            }
            if (CLUEnvironment.Platform.IsMacOSX)
            {
                eventProperties.Add("OS", "MacOS");
            }
            else if (CLUEnvironment.Platform.IsUnix)
            {
                eventProperties.Add("OS", "Unix");
            }
            else
            {
                eventProperties.Add("OS", "Windows");
            }
            return eventProperties;
        }

        /// <summary>
        /// Initializes TelemetryClient using default channel.
        /// </summary>
        private void InitTelemetry()
        {
            _telemetryClient = new TelemetryClient
            {
                InstrumentationKey = "963c4276-ec20-48ad-b9ab-3968e9da5578"
            };
        }

        /// <summary>
        /// Bind the dynamic parameters if cmdlet instance supports dynamic parameters.
        /// </summary>
        private void BindDynamicParameters()
        {
            _dynamicParametersBindState = new ParameterBindState(_cmdletMetadata.Instance);
            _dynmicParametersBindHandler =
                new BindHandler(_cmdletMetadata.Instance.DynamicParametersInstance, _dynamicParametersBindState);
            _staticParameterBindInProgress = false;
            if (_cmdletMetadata.Instance.SupportsDynamicParameters)
            {
                // If Cmdlet instance support dynamic parameters then rerun the parser to bind dynamic parameters.
                _dynamicParameterBindInProgress = true;
                this.ParserSeekBeginAndRun();
                var psCmdlet = _cmdlet as PSCmdlet;
                if (psCmdlet != null)
                {
                    // We need to add all dynamic parameters that were bound
                    foreach (var boundParam in _cmdletMetadata.Instance.Parameters)
                    {
                        if (boundParam.Value.IsBound && boundParam.Value.IsDynamic && !psCmdlet.MyInvocation.BoundParameters.ContainsKey(boundParam.Value.Name))
                        {
                            psCmdlet.MyInvocation.BoundParameters[boundParam.Value.Name] = boundParam.Value;
                        }
                    }
                }
                _dynamicParameterBindInProgress = false;
            }
        }

        /// <summary>
        /// Check any of the named argument received from the parser is unknown.
        /// </summary>
        private void FailIfAnyUnknownArguments()
        {
            var arguments = _staticParametersBindState.AllArgumentNames;
            var unknownArguments = arguments
                .Where(argument => !_cmdletMetadata.Type.Parameters.ContainsKey(argument) && !_cmdletMetadata.Instance.Parameters.ContainsKey(argument))
                .Select(argument => argument);
            if (unknownArguments.Any())
            {
                throw new PSArgumentException(string.Format(Strings.CmdletBinderAndCommand_FailIfAnyUnknownArguments_FoundUnknownArgument, string.Join(",", unknownArguments)));
            }
        }

        /// <summary>
        /// Binds the parameters of the cmdlet instance and dynamic parameter instance from positional files
        /// received from the parser.
        /// </summary>
        private void BindFromPositionalFiles()
        {
            PositionalFilesBinder.Bind(_cmdlet, _cmdletMetadata.Instance.DynamicParametersInstance,
                _staticParametersBindState, _dynamicParametersBindState);
        }

        /// <summary>
        /// Bind the pipeline and positional parameters.
        /// </summary>
        private void BindPipelineAndPositionalParameters()
        {
            var hasEmptyParameterSets = !_cmdletMetadata.Instance.AllParameterSets.Any();
            var pipelineBinder = new PipelineBinder(_cmdlet, _cmdletMetadata.Instance.DynamicParametersInstance,
                _staticParametersBindState, _dynamicParametersBindState, hasEmptyParameterSets, HandleRecordInit());
            pipelineBinder.Bind();
        }

        /// <summary>
        /// Initialize binder for positional arguments and returns rference to the RecordHandler method.
        /// </summary>
        /// <returns>Reference to RecordHandler method</returns>
        private Action<HashSet<string>> HandleRecordInit()
        {
            var hasEmptyParameterSets = !_cmdletMetadata.Instance.AllParameterSets.Any();
            _positionalArgumentsBinder = new PositionalArgumentsBinder(_cmdlet, _cmdletMetadata.Instance.DynamicParametersInstance,
                _staticParametersBindState, _dynamicParametersBindState, hasEmptyParameterSets);
            return HandleRecord;
        }

        /// <summary>
        /// Handle the call-back from pipeline processing logic.
        /// This method will kick-off the positional parameter binding and check for parameter-sets conflict and resolution failure.
        /// </summary>
        /// <param name="parameterSets"></param>
        private void HandleRecord(HashSet<string> parameterSets)
        {
            if (_positionalArgumentsBounded)
            {
                _cmdlet.ProcessRecord();
                return;
            }

            var parameterSetsUpdated = _positionalArgumentsBinder.BindOnce(parameterSets);
            int parameterSetsCount = parameterSetsUpdated.Count;
            var hasEmptyParameterSets = !_cmdletMetadata.Instance.AllParameterSets.Any();
            if (parameterSetsCount == 0 && !hasEmptyParameterSets)
            {
                throw new PSArgumentException(Strings.CmdletBinderAndCommand_HandleRecord_ConflictingParameterSet);
            }

            bool errors = false;
            string parameterSet = parameterSetsUpdated.FirstOrDefault();

            if (parameterSetsCount > 1)
            {
                parameterSet = BreakParameterSetTie(parameterSetsUpdated);
            }

            var builder = new System.Text.StringBuilder();
            var missingParameters = _cmdletMetadata.Type.Parameters.Values
                .Where(p => !p.IsBound && p.IsMandatory(parameterSet) && MatchesParameterSet(p, parameterSet));
            if (missingParameters.Any())
            {
                errors = true;
                foreach (var parameter in missingParameters)
                {
                    builder.Append(parameter.Name).Append(' ');
                }
            }

            if (_cmdletMetadata.Instance.SupportsDynamicParameters)
            {
                missingParameters = _cmdletMetadata.Instance.Parameters.Values
                    .Where(p => !p.IsBound && p.IsMandatory(parameterSet) && MatchesParameterSet(p, parameterSet));
                if (missingParameters.Any())
                {
                    errors = true;
                    foreach (var parameter in missingParameters)
                    {
                        builder.Append(parameter.Name).Append(' ');
                    }
                }
            }

            if (errors)
            {
                throw new PSArgumentException(string.Format(Strings.CmdletBinderAndCommand_HandleRecord_MissingMandatoryArguments, builder.ToString()));
            }

            if (_cmdlet is PSCmdlet)
            {
                (_cmdlet as PSCmdlet).ParameterSetName = parameterSet;
            }

            _positionalArgumentsBounded = true;
            _cmdlet.ProcessRecord();
        }

        /// <summary>
        /// Try to resolve the parameter-set from the given parameter-sets.
        //  Here, we have more than one parameter set candidate, but all the named arguments have been bound.
        //  We might still be able to resolve the parameter set if there's a default parameter set, or if there's
        //  exactly one set for which all the unbound parameters are optional.
        /// </summary>
        /// <param name="parameterSets"></param>
        /// <returns>The resolved parameter-set name</returns>
        private string BreakParameterSetTie(HashSet<string> parameterSets)
        {
            // Look for a parameter set that allows any unbound parameters to be optional
            var unbound = _cmdletMetadata.Type.Parameters.Where(p => !p.Value.IsBound).Select(p => p.Key).ToSet();

            foreach (var setInfo in _cmdletMetadata.Type.ParameterSets.Where(set => parameterSets.Contains(set.Name)))
            {
                var ps = setInfo.Parameters.Select(p => p.Name).ToArray();

                foreach (var p in setInfo.Parameters.Where(p => p.IsMandatory && unbound.Contains(p.Name.ToLowerInvariant())))
                {
                    parameterSets.Remove(setInfo.Name);
                }
            }

            if (parameterSets.Count == 1)
                return parameterSets.First();

            // No? Check if there's a default parameter set.
            var defaultSet = _cmdletMetadata.Type.DefaultParameterSet;
            if (!string.IsNullOrEmpty(defaultSet))
                return defaultSet;

            throw new PSArgumentException(Strings.CmdletBinderAndCommand_BreakParameterSetTie_ParameterSetCannotBeResolved);
        }

        /// <summary>
        /// Checks the given parameter belongs to the a parameter-set.
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <param name="parameterSet">The parameter set</param>
        /// <returns>True if parameter belongs to the given parameter-set, false otherwise.</returns>
        private static bool MatchesParameterSet(ParameterMetadata parameter, string parameterSet)
        {
            return parameterSet == null || parameter.ParameterSets.ContainsKey(parameterSet);
        }

        #region Private fields
        /// <summary>
        /// Telemetry client.
        /// </summary>
        private TelemetryClient _telemetryClient;

        /// <summary>
        /// Configuration of the current command.
        /// </summary>
        private ConfigurationDictionary _commandConfiguration;

        /// <summary>
        /// Ges access to console.
        /// </summary>
        private ICommandRuntime _runtime;

        /// <summary>
        /// The cmdlet instance representing current command.
        /// </summary>
        private Cmdlet _cmdlet;

        /// <summary>
        /// The metadata data provider for cmdlet type and it's instance.
        /// </summary>
        private CmdletMetadata _cmdletMetadata;

        /// <summary>
        /// Binder that resolves Cmdlet from the command line discriminators.
        /// </summary>
        private DiscriminatorBinder _discriminatorBinder;

        /// <summary>
        /// The parser event handler for static parameters.
        /// </summary>
        private BindHandler _staticParametersBindHandler;

        /// <summary>
        /// Indicates whether the static binding is in progress.
        /// </summary>
        private bool _staticParameterBindInProgress = false;

        /// <summary>
        /// Holds the state of parameters of cmdlet instance.
        /// </summary>
        private ParameterBindState _staticParametersBindState;

        /// <summary>
        /// The parser event handler for dynamic parameters.
        /// </summary>
        private BindHandler _dynmicParametersBindHandler = null;

        /// <summary>
        /// Indicates whether the dynamic binding is in progress.
        /// </summary>
        private bool _dynamicParameterBindInProgress = false;

        /// <summary>
        /// Holds the state of parameters of dynamic-parameter instance.
        /// </summary>
        private ParameterBindState _dynamicParametersBindState;

        /// <summary>
        /// The positional argument binder.
        /// </summary>
        private PositionalArgumentsBinder _positionalArgumentsBinder;

        /// <summary>
        /// Indicates whether positional arguments are already bounded.
        /// </summary>
        private bool _positionalArgumentsBounded;

#endregion
    }
}
