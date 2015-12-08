using Microsoft.CLU.Metadata;
using Microsoft.CLU.Common.Properties;
using System;

namespace Microsoft.CLU.CommandBinder.ValueSetter
{
    /// <summary>
    /// Implementation of IValueSetter for a given primitive parameter, implementation knows how to
    /// 1. validate JSON string representaion of primitive parameter value
    /// 2. set parameter value instance to parameters object array
    /// </summary>
    internal class PrimitiveTypeParameterValue : IValueSetter
    {
        /// <summary>
        /// Constructs PrimitiveTypeParameterValue instance.
        /// </summary>
        /// <param name="property">The primitive property whose value this instance manages.</param>
        public PrimitiveTypeParameterValue(Parameter parameter)
        {
            if (!parameter.IsPrimitive(out _typeCode))
            {
                throw new ArgumentException(Strings.PrimitiveTypeParameterValue_Ctor_ParameterMustBePrimitiveType);
            }

            _parameter = parameter;
        }

        /// <summary>
        /// Try to parse string value representation of a primitive parameter. If successful 
        /// set the parsed value to 'value'.
        /// </summary>
        /// <param name="strValue">The primitive value to parse</param>
        /// <param name="value">The parse result</param>
        /// <param name="exception">Exception if any while parsing</param>
        /// <returns>True, if successfully parsed, False othewise</returns>
        public bool TryParse(string strValue, out object value, out Exception exception)
        {
            value = null;
            exception = null;
            //TODO: #19 Add support for URI, FileInfo, DirectoryInfo, maybe some others?
            return PrimitiveType.TryParse(_typeCode, strValue, out value);
        }

        /// <summary>
        /// Sets 'value' to target object array at an index corrosponding to the position
        /// of the parameter this IValueSetter implementation wraps.
        /// </summary>
        /// <param name="target">The target object</param>
        /// <param name="value">The value to set</param>
        public void Set(object target, object value)
        {
            (target as object [])[_parameter.Position] = value;
        }

        #region Private fields

        /// <summary>
        /// Represents primtive parameter of some commmand entry method.
        /// </summary>
        private Parameter _parameter;

        /// <summary>
        /// The parameter primtive type code.
        /// </summary>
        private PrimitiveTypeCode _typeCode;

        #endregion
    }
}
