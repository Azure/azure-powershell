using Microsoft.CLU.Common;
using Microsoft.CLU.Helpers;
using Microsoft.CLU.Common.Properties;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Microsoft.CLU.CommandBinder
{
    /// <summary>
    /// Implementation of ICommand contract that represents an entrypoint in "Base Programming Model".
    /// </summary>
    internal class BaseCommand : ICommand
    {
        /// <summary>
        /// Creates an instance of BaseCommand.
        /// </summary>
        /// <param name="commandConfiguration">Date from the command configuration file.</param>
        /// <param name="resolver">An assembly resolver instance</param>
        /// <param name="arguments">The command-line arguments array</param>
        public BaseCommand(ConfigurationDictionary commandConfiguration, AssemblyResolver resolver, string [] arguments)
        {
            _argument = arguments;
            EntryPoint = CommandEntryPointHelper.GetEntryPoint(commandConfiguration, resolver);
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
                    throw new ArgumentException(Strings.BaseCommand_EntryPoint_EntryPointMethodMustBeStatic);
                }

                var entryPointParameters = _entryPoint.GetParameters();
                var paramCount = entryPointParameters.Count();
                if (paramCount == 0)
                {
                    return;
                }

                if (paramCount > 1)
                {
                    throw new ArgumentException(Strings.BaseCommand_EntryPoint_EntryPointMethodMustAcceptZeroOrOneArgument);
                }

                _entryPointAcceptsZeroParams = false;
                var parameter = entryPointParameters.First();
                if (!parameter.ParameterType.IsArrayOfElementType(typeof(string)) || parameter.ParameterType.GetArrayRank() != 1)
                {
                    throw new ArgumentException(Strings.BaseCommand_EntryPoint_EntryPointMethodArgumentMustBeStringArray);
                }
            }
        }

        #region ICommand implementation

        /// <summary>
        /// Tells whether the entry point is asynchronous
        /// </summary>
        public bool IsAsync
        {
            get
            {
                if (!_isAsync.HasValue)
                {
                    _isAsync = typeof(Task).GetTypeInfo().IsAssignableFrom(EntryPoint.ReturnType.GetTypeInfo());
                }

                return _isAsync.Value;
            }
        }

        /// <summary>
        /// Calls the entry point synchronously by passing the arguments.
        /// </summary>
        public void Invoke()
        {
            if (_entryPointAcceptsZeroParams)
            {
                EntryPoint.Invoke(null, null);
            }
            else
            {
                EntryPoint.Invoke(null, new object[] { _argument });
            }
        }


        /// <summary>
        /// Calls the entry point asynchronously by passing the arguments.
        /// </summary>
        public Task InvokeAsync()
        {
            if (_entryPointAcceptsZeroParams)
            {
                return (Task)EntryPoint.Invoke(null, null);
            }
            else
            {
                return (Task)EntryPoint.Invoke(null, new object[] { _argument });
            }
        }

        #endregion

        #region Private fields

        /// <summary>
        /// The command arguments.
        /// </summary>
        private string[] _argument;

        /// <summary>
        /// Indicates whether the command is synchronous or asynchronous.
        /// </summary>
        private bool? _isAsync;

        /// <summary>
        /// Indicates the command entry point accepts no parameter.
        /// </summary>
        private bool _entryPointAcceptsZeroParams = true;

        /// <summary>
        /// Reference to the command entry point.
        /// </summary>
        private MethodInfo _entryPoint;

        #endregion
    }
}
