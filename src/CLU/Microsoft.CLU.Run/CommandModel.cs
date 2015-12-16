using Microsoft.CLU.Common;
using Microsoft.CLU.Common.Properties;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Microsoft.CLU.Run
{
    /// <summary>
    /// The type responsible for locating the model entry point and bootstraping the command
    /// execution.
    /// </summary>
    internal class CommandModel
    {
        /// <summary>
        /// Uses command configuration to load the model package and invokes the model entry
        /// point by passing the model arguments and command configuration.
        /// </summary>
        /// <param name="commandConfiguration"></param>
        /// <param name="modelArguments"></param>
        public static Microsoft.CLU.CommandModelErrorCode Run(CommandConfig commandConfiguration, string[] modelArguments)
        {
            CommandModel commandModel = new CommandModel()
            {
                _commandConfiguration = commandConfiguration,
                _modelArguments = modelArguments
            };
            commandModel.ResolveModel();
            return commandModel.Run();
        }

        /// <summary>
        /// Resolve the model entry point using the command configuration.
        /// </summary>
        private void ResolveModel()
        {
            _modelPackage = LocalPackage.Load(_commandConfiguration.RtPackage);
            if (_modelPackage == null)
            {
                throw new LocalPackageNotFoundException(_commandConfiguration.RtPackage);
            }

            var modelAssembly = _modelPackage.LoadAssembly(_commandConfiguration.RtAssembly);
            if (modelAssembly.Assembly == null)
            {
                throw new FileLoadException(string.Format(Strings.CommandModel_ResolveModel_CouldNotLoadAssemblyFromPackage, _commandConfiguration.RtAssembly, _commandConfiguration.RtPackage));
            }

            _entryPoint = modelAssembly.GetEntryPoint(_commandConfiguration.RtEntry);
            if (_entryPoint.ClassType == null)
            {
                throw new ArgumentException(string.Format(Strings.CommandModel_ResolveModel_EntryPointTypeNotFound, _commandConfiguration.RtEntry));
            }

            if (_entryPoint.Method == null)
            {
                throw new ArgumentException(string.Format(Strings.CommandModel_ResolveModel_EntryPointMethodNotFound, _commandConfiguration.RtEntry));
            }
        }

        /// <summary>
        /// Runs the model
        /// </summary>
        private CommandModelErrorCode Run()
        {
            object returnValue = null;
            if (_entryPoint.ClassType.GetInterfaces().Where(t => String.Equals(t.FullName, Common.Constants.CommandModelInterface, StringComparison.Ordinal)).FirstOrDefault() != null)
            {
                var model = Activator.CreateInstance(_entryPoint.ClassType);
                var configDict = ConfigurationDictionary.Create(_commandConfiguration.Items);
                returnValue = _entryPoint.Method.Invoke(model, new object[] { configDict, _modelArguments });
            }
            else
            {
                ValidateCustomEntryPoint();
                returnValue = _entryPoint.Method.Invoke(null, new object[] { _modelArguments });
            }
            return (CommandModelErrorCode) returnValue;
        }

        /// <summary>
        /// Creates an instance of "Microsoft.CLU.ConfigurationDictionary" from the command configuration.
        /// This is the type that standard Microsoft.CLU.CommandModel.ICommandModel.Run implementations
        /// accepts.
        /// </summary>
        /// <returns></returns>
        private object CreateCLUModelCommandDictionary()
        {
            var runTimePackage = _modelPackage;
            var runtimeAssembly = runTimePackage.LoadAssembly("Microsoft.CLU.Common");
            if (runtimeAssembly.Assembly == null)
            {
                throw new FileLoadException(string.Format(Strings.CommandModel_CreateCLUModelCommandDictionary_CouldNotLocateDefaultPackageAssembly, runTimePackage.FullPath));
            }

            Type configuationDictionaryType = runtimeAssembly.Assembly.GetType(Constants.ConfigurationDictionaryTypeFullName);
            if (configuationDictionaryType == null)
            {
                throw new TypeLoadException(string.Format(Strings.CommandModel_CreateCLUModelCommandDictionary_CouldNotLoadType, Constants.ConfigurationDictionaryTypeFullName, runtimeAssembly.Name));
            }

            var commandConfiguration = configuationDictionaryType
                .GetMethod("CreateFromDictionary")
                .Invoke(null, new object[] { _commandConfiguration.Items });
            return commandConfiguration;
        }

        /// <summary>
        /// Ensure entry point conforms to base model.
        /// </summary>
        /// <param name="entryPoint"></param>
        private void ValidateCustomEntryPoint()
        {
            var method = _entryPoint.Method;
            if (!method.IsStatic || !method.IsPublic)
            {
                throw new InvalidOperationException(string.Format(Strings.CommandModel_ValidateCustomEntryPoint_EntryPointMustBePulicAndStatic, _entryPoint.FullName));
            }

            var entryPointParameters = method.GetParameters();
            var paramCount = entryPointParameters.Count();
            if (paramCount == 0)
            {
                return;
            }

            var parameterType = entryPointParameters.First().ParameterType;
            if (paramCount > 1 || !parameterType.IsArray || parameterType.GetElementType() != typeof(string) || parameterType.GetArrayRank() != 1)
            {
                throw new ArgumentException(string.Format(Strings.CommandModel_ValidateCustomEntryPoint_EntryPointInvalidArgument, _entryPoint.FullName));
            }
        }

        #region Private fields

        /// <summary>
        /// The command configuration
        /// </summary>
        private CommandConfig _commandConfiguration;

        /// <summary>
        /// The arguments to be passed to model entry point method.
        /// </summary>
        private string[] _modelArguments;

        /// <summary>
        /// The package containing the assembly in which the model entry point is defined.
        /// </summary>
        private LocalPackage _modelPackage { get; set; }

        /// <summary>
        /// The model entry point.
        /// </summary>
        private EntryPoint _entryPoint { get; set; }

        #endregion
    }
}
