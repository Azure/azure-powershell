using System.Collections.ObjectModel;

namespace System.Management.Automation.Runspaces
{
    /// <summary>
    /// Represents a Cmdlet's parameter collection.
    /// </summary>
    public sealed class CommandParameterCollection : Collection<CommandParameter>
    {
        /// <summary>
        /// Create an instance of CommandParameterCollection.
        /// </summary>
        public CommandParameterCollection()
        {}

        /// <summary>
        /// Add a parameter.
        /// </summary>
        /// <param name="name">Parameter name</param>
        public void Add(string name)
        {
            Add(new CommandParameter(name));
        }

        /// <summary>
        /// Add a parameter.
        /// </summary>
        /// <param name="name">Parameter name</param>
        /// <param name="value">Parameter value</param>
        public void Add(string name, object value)
        {
            Add(new CommandParameter(name, value));
        }
    }

    /// <summary>
    /// Type represents a Cmdlet parameter.
    /// </summary>
    public sealed class CommandParameter
    {
        /// <summary>
        /// Create an instance of CommandParameter.
        /// </summary>
        /// <param name="name">The parameter name</param>
        public CommandParameter(string name)
        {
            Name = name;
            IsSwitch = true;
        }

        /// <summary>
        /// Create an instance of CommandParameter.
        /// </summary>
        /// <param name="name">The parameter name</param>
        /// <param name="value">The parameter value</param>
        public CommandParameter(string name, object value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Parameter name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Parameter value.
        /// </summary>
        public object Value { get; }

        /// <summary>
        /// Value property can be null in two cases
        /// 1. instance created using CommandParameter(string)
        /// 2. instance created using CommandParameter(string, null)
        /// #1 is for switch parameter, since value is null is both cases
        ///    we need an additional flag.
        /// </summary>
        internal bool IsSwitch { get; }
    }
}
