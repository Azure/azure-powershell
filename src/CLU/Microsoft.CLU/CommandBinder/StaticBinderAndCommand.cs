using Microsoft.CLU.Common;
using Microsoft.CLU.Helpers;
using Microsoft.CLU.Metadata;
using Microsoft.CLU.Common.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Microsoft.CLU.CommandBinder
{
    /// <summary>
    /// Implementation of ICommandBinder and Icommand interfaces to support "Static Progamming Model"
    /// </summary>
    internal class StaticBinderAndCommand : ICommandBinder, ICommand
    {
        /// <summary>
        /// Creates an instance of StaticBinderAndCommand.
        /// </summary>
        /// <param name="commandConfiguration">Represents configurations in command configuration file.</param>
        public StaticBinderAndCommand(ConfigurationDictionary commandConfiguration)
        {
            _commandConfiguration = commandConfiguration;
            EntryPoint = CommandEntryPointHelper.GetEntryPoint(_commandConfiguration, null);
        }

        /// <summary>
        /// Creates StaticBinderAndCommand.
        /// </summary>
        /// <param name="commandConfiguration">Date from the command configuration file.</param>
        /// <param name="resolver">An assembly resolver instance</param>
        public StaticBinderAndCommand(ConfigurationDictionary commandConfiguration, AssemblyResolver resolver)
        {
            _commandConfiguration = commandConfiguration;
            EntryPoint = CommandEntryPointHelper.GetEntryPoint(_commandConfiguration, resolver);
        }

        /// <summary>
        /// The command entry point method
        /// </summary>
        MethodInfo EntryPoint
        {
            get
            {
                return _entryPoint;
            }

            set
            {
                _entryPoint = value;
                if (!_entryPoint.IsStatic)
                {
                    throw new ArgumentException(Strings.StaticBinderAndCommand_EntryPoint_EntryPointMethodMustBeStatic);
                }

                var entryPointParameters = _entryPoint.GetParameters();
                var lastParameter = entryPointParameters.Where(p => p.Position == entryPointParameters.Length - 1).Select(p => p).FirstOrDefault();
                if (lastParameter == null)
                {
                    throw new ArgumentException(Strings.StaticBinderAndCommand_EntryPoint_EntryPointMethodMustAcceptAtleastOneArgument);
                }

                if (!lastParameter.ParameterType.IsArrayOfElementType(typeof(string)) || lastParameter.ParameterType.GetArrayRank() != 1)
                {
                    throw new ArgumentException(Strings.StaticBinderAndCommand_EntryPoint_EntryPointMethodLastArgumentMustBeStringArray);
                }
            }
        }

        #region ICommandBinder implementation

        /// <summary>
        /// Bind a positonal argument.
        /// </summary>
        /// <param name="position">The argument position in the command line</param>
        /// <param name="value">The value of the argument</param>
        public void BindArgument(int position, string value)
        {
            _positionalArguments.Add(position, value);
        }

        /// <summary>
        /// Bind a named argument.
        /// </summary>
        /// <param name="name">The argument name</param>
        /// <param name="value">The argument value</param>
        public void BindArgument(string name, string value)
        {
            _namedArguments.Add(name, value);
        }

        /// <summary>
        /// Attempt to bind an argument name switch.
        /// </summary>
        /// <param name="name">The argument name</param>
        /// <returns>true if the argument is known and is a switch</returns>
        public bool TryBindSwitch(string name)
        {
            return false;
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
                if (!_isAsync.HasValue)
                {
                    _isAsync = typeof(Task).IsAssignableFrom(EntryPoint.ReturnType);
                }

                return _isAsync.Value;
            }
        }

        public bool SupportsAutomaticHelp
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Calls the entry point synchronously by passing the arguments.
        /// </summary>
        public void Invoke()
        {
            object[] boundArguments = GetBoundParameters();
            EntryPoint.Invoke(null, boundArguments);
        }

        /// <summary>
        /// Calls the entry point asynchronously by passing the arguments.
        /// </summary>
        public Task InvokeAsync()
        {
            object[] boundArguments = GetBoundParameters();
            return (Task)EntryPoint.Invoke(null, boundArguments);
        }

        #endregion

        /// <summary>
        /// Gets all bound parameters.
        /// </summary>
        /// <returns>The bounded parameters.</returns>
        public object[] GetBoundParameters()
        {
            var parametersForNamedArguments = GetParametersForNamedArguments();
            var boundNamedParameters = PopulateNamedParameters(parametersForNamedArguments, _namedArguments);
            var boundPositionalParameters = _positionalArguments.OrderBy(p => p.Key).Select(p => p.Value).ToArray<string>();
            return boundNamedParameters.Concat(new object[] { boundPositionalParameters }).ToArray<object>();
        }

        /// <summary>
        /// Gets the named parameters from the entry point prototype.
        /// </summary>
        /// <returns>The metadata of named parameters</returns>
        private IDictionary<string, Parameter> GetParametersForNamedArguments()
        {
            var entryPointMethodParameters = Reflector.GetParameters(EntryPoint);
            var lastParameter = entryPointMethodParameters.Where(p => p.Value.Position == entryPointMethodParameters.Count - 1).Select(p => p).First();
            entryPointMethodParameters.Remove(lastParameter.Key);
            return entryPointMethodParameters;
        }

        /// <summary>
        /// Populate the named parameters.
        /// </summary>
        /// <param name="parameters">The metadata of named parameters</param>
        /// <param name="namedArguments">The named arguments and its values.</param>
        /// <returns></returns>
        private static object[] PopulateNamedParameters(IDictionary<string, Parameter> parameters, IDictionary<string, string> namedArguments)
        {
            object[] parameterValues = new object[parameters.Count];
            IDictionary<string, Parameter> unBindedParameters = new Dictionary<string, Parameter>();
            PrimitiveTypeCode code;
            foreach (var parameter in parameters.Values)
            {
                bool canBind = true;
                bool argumentMatched = namedArguments.ContainsKey(parameter.Name);
                if (!argumentMatched)
                {
                    if (!parameter.Type.IsNullable() && parameter.IsPrimitive(out code))
                    {
                        throw new ArgumentException(string.Format(Strings.StaticBinderAndCommand_PopulateNamedParameters_MatchingArgumentNotFound, parameter.Name));
                    }
                    unBindedParameters.Add(parameter.Name, parameter);
                }
                else
                {
                    object parsedValue;
                    Exception exception;
                    canBind = parameter.Value.TryParse(namedArguments[parameter.Name], out parsedValue, out exception);
                    if (canBind)
                    {
                        parameter.Value.Set(parameterValues, parsedValue);
                        namedArguments.Remove(parameter.Name);
                    }
                    else
                    {
                        if (!parameter.Type.IsNullable() && parameter.IsPrimitive(out code))
                        {
                            throw new ArgumentException(string.Format(Strings.StaticBinderAndCommand_PopulateNamedParameters_CouldNotBindParameter, parameter.Name, parameter.Name));
                        }
                        unBindedParameters.Add(parameter.Name, parameter);
                    }
                }
            }

            foreach (var parameter in unBindedParameters.Values)
            {
                object target = Activator.CreateInstance(parameter.Type);
                parameterValues[parameter.Position] = PopulateProperties(target, parameter.GetSerializableChildProperties(), namedArguments);
            }

            return parameterValues;
        }

        /// <summary>
        /// Populate properties of a target object.
        /// </summary>
        /// <param name="target">The target object</param>
        /// <param name="properties">The properties to be populated</param>
        /// <param name="arguments">The argument to be bound</param>
        /// <returns></returns>
        private static object PopulateProperties(object target, IDictionary<string, Property> properties, IDictionary<string, string> arguments)
        {
            bool objectSet = false;
            IDictionary<string, Property> unBindedProperties = new Dictionary<string, Property>();
            PrimitiveTypeCode code;
            foreach (var property in properties.Values)
            {
                if (arguments.Count == 0)
                {
                    break;
                }

                bool canBind = true;
                bool argumentMatched = arguments.ContainsKey(property.Name);
                if (argumentMatched)
                {
                    object parsedValue;
                    Exception exception;
                    canBind = property.Value.TryParse(arguments[property.Name], out parsedValue, out exception);
                    if (canBind)
                    {
                        property.Value.Set(target, parsedValue);
                        arguments.Remove(property.Name);
                        objectSet = true;
                    }
                    else
                    {
                        if (!property.IsPrimitive(out code))
                        {
                            unBindedProperties.Add(property.Name, property);
                        }
                    }
                }
                else
                {
                    if (!property.IsPrimitive(out code))
                    {
                        unBindedProperties.Add(property.Name, property);
                    }
                }
            }

            foreach (var property in unBindedProperties.Values)
            {
                object propertyObj = Activator.CreateInstance(property.Type);
                propertyObj = PopulateProperties(propertyObj, property.GetSerializableChildProperties(), arguments);
                if (propertyObj != null)
                {
                    property.Value.Set(target, propertyObj);
                }
            }

            return objectSet ? target : null;
        }

        public IEnumerable<string> GenerateCommandHelp(ICommandLineParser parser, string[] args, bool prefix)
        {
            throw new NotImplementedException();
        }

        #region Private fields

        /// <summary>
        /// The command configuration.
        /// </summary>
        private ConfigurationDictionary _commandConfiguration;

        /// <summary>
        /// The named arguments and its values.
        /// </summary>
        private IDictionary<string, string> _namedArguments = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// The position of positional arguments and its values.
        /// </summary>
        private IDictionary<int, string> _positionalArguments = new Dictionary<int, string>();

        /// <summary>
        /// The command entry point method.
        /// </summary>
        private MethodInfo _entryPoint;

        /// <summary>
        /// Indicates whether the command is synchronous or asynchronous.
        /// </summary>
        private bool? _isAsync;

        #endregion
    }
}
