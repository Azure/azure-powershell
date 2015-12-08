using Microsoft.CLU.Metadata;
using Microsoft.CLU.Common.Properties;
using Newtonsoft.Json;
using System;

namespace Microsoft.CLU.CommandBinder.ValueSetter
{
    /// <summary>
    /// Implementation of IValue for a given complex parameter, implementation knows how to
    /// 1. validate JSON string representaion of complex parameter value
    /// 2. set parameter value instance to parameters object array
    /// </summary>
    internal class ObjectTypeParameterValue : IValueSetter
    {
        /// <summary>
        /// Constructs ObjectTypeParameterValue instance
        /// </summary>
        /// <param name="property">The complex parameter whose value this instance manages.</param>
        public ObjectTypeParameterValue(Parameter parameter)
        {
            PrimitiveTypeCode code;
            if (parameter.Type.IsPrimitive(out code))
            {
                throw new ArgumentException(Strings.ObjectTypeParameterValue_Ctor_ParameterMustBeObjectType);
            }

            _parameter = parameter;
        }

        /// <summary>
        /// Try to parse string value representation of a complex parameter. If successful 
        /// set the parsed value to 'value' out parameter.
        /// </summary>
        /// <param name="strValue">The complex value to parse</param>
        /// <param name="value">The parse result</param>
        /// <param name="exception">Exception if any while parsing</param>
        /// <returns>True, if successfully parsed, False othewise</returns>
        public bool TryParse(string strValue, out object value, out Exception exception)
        {
            value = null;
            exception = null;
            try
            {
                value = JsonConvert.DeserializeObject(strValue, _parameter.Type);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            return exception == null;
        }

        /// <summary>
        /// Sets 'value' to target object array at an index corrosponding to the position
        /// of the parameter this IValue implementation wraps.
        /// </summary>
        /// <param name="target">The target object</param>
        /// <param name="value">The value to set</param>
        public void Set(object target, object value)
        {
            (target as object[])[_parameter.Position] = value;
        }

        #region Private fields

        /// <summary>
        /// Represents complex parameter of some commmand entry method
        /// </summary>
        private Parameter _parameter;

        #endregion
    }
}
