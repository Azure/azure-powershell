using Microsoft.CLU.Helpers;
using Microsoft.CLU.Metadata;
using Microsoft.CLU.Common.Properties;
using Newtonsoft.Json;
using System;

namespace Microsoft.CLU.CommandBinder.ValueSetter
{
    /// <summary>
    /// Implementation of IValueSetter for a given complex property, implementation knows how to
    /// 1. validate JSON string representaion of complex property value
    /// 2. set property value instance to corrosponding property member of an object
    /// </summary>
    internal class ObjectTypePropertyValue : IValueSetter
    {
        /// <summary>
        /// Constructs ObjectTypePropertyValue instance
        /// </summary>
        /// <param name="property">The complex property whose value this instance manages.</param>
        public ObjectTypePropertyValue(Property property)
        {
            PrimitiveTypeCode t;
            if (property.Type.IsPrimitive(out t))
            {
                throw new ArgumentException(Strings.ObjectTypePropertyValue_Ctor_PropertyMustBeObjectType);
            }

            _property = property;
        }

        /// Try to parse string value representation of a complex property. If successful 
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
                value = JsonConvert.DeserializeObject(strValue, _property.Type);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            return exception == null;
        }

        /// <summary>
        /// Sets 'value' as value of property of 'target' object (the property represented by
        /// this IValueSetter implementation)
        /// </summary>
        /// <param name="target">The target object</param>
        /// <param name="value">The value to set</param>
        /// <summary>
        public void Set(object target, object value)
        {
            _property.PropertyInfo.SetValue(target, value);
        }

        #region Private fields

        /// <summary>
        /// Represents complex property of a type instance.
        /// </summary>
        private Property _property;

        #endregion
    }
}
