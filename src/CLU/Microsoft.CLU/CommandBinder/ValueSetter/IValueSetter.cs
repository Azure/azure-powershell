using System;

namespace Microsoft.CLU.CommandBinder.ValueSetter
{
    /// <summary>
    /// The contract that all parameter value setters needs to implement.
    /// </summary>
    internal interface IValueSetter
    {
        /// <summary>
        /// Try to identify the underlying type of the given string value and parse it.
        /// </summary>
        /// <param name="strValue">The string value to parse</param>
        /// <param name="value">The parsed value</param>
        /// <param name="exception">Exceptions if any while parsing</param>
        /// <returns>True, if successfully parsed False otherwise</returns>
        bool TryParse(string strValue, out object value, out Exception exception);

        /// <summary>
        /// Set the value in the given target
        /// </summary>
        /// <param name="target">The target object</param>
        /// <param name="value">The value</param>
        void Set(object target, object value);
    }
}
