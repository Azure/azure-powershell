using Microsoft.CLU.Metadata;
using Microsoft.CLU.Common.Properties;
using System;

namespace Microsoft.CLU.CommandBinder.ValueSetter
{
    /// <summary>
    /// Implementation of IValue for a given primitive property, implementation knows how to
    /// 1. validate JSON string representaion of primitive property value
    /// 2. set property value instance to property member of an object
    /// </summary>
    internal class PrimitiveTypePropertyValue : IValueSetter
    {
        /// <summary>
        /// Constructs PrimitiveTypePropertyValue instance.
        /// </summary>
        /// <param name="property">The primitive property whose value this instance manages.</param>
        public PrimitiveTypePropertyValue(Property property)
        {
            if (!property.IsPrimitive(out _typeCode))
            {
                throw new ArgumentException(Strings.PrimitiveTypePropertyValue_Ctor_PropertyMustBePrimitiveType);
            }

            _property = property;
        }

        /// <summary>
        /// Try to parse string value representation of a primitive property. If successful 
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
            return PrimitiveType.TryParse(_typeCode, strValue, out value);
        }

        /// <summary>
        /// Sets 'value' as value of property of 'target' object (the property represented by
        /// this IValueSetter implementation)
        /// </summary>
        /// <param name="target">The target object</param>
        /// <param name="value">The value to set</param>
        public void Set(object target, object value)
        {
            _property.PropertyInfo.SetValue(target, value);
        }

        #region Private fields

        /// <summary>
        /// Represents primitive property of a type instance.
        /// </summary>
        private Property _property;

        /// <summary>
        /// The property primtive type code.
        /// </summary>
        private PrimitiveTypeCode _typeCode;

        #endregion
    }
}
