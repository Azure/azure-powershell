using Microsoft.CLU.CommandBinder.ValueSetter;
using Microsoft.CLU.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Microsoft.CLU.Metadata
{
    /// <summary>
    /// Represents a serializable property of complex type.
    /// </summary>
    internal class Property
    {
        /// <summary>
        /// Property name
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// The type of the parameter
        /// </summary>
        public Type Type
        {
            get;
            private set;
        }

        /// <summary>
        /// Provide full access to property metadata
        /// </summary>
        public PropertyInfo PropertyInfo
        {
            get;
            private set;
        }

        IValueSetter _value;
        /// <summary>
        /// Reference to IValueSetter instance aware of how to set value for the property
        /// </summary>
        internal IValueSetter Value
        {
            get
            {
                if (_value == null)
                {
                    PrimitiveTypeCode code;
                    if (IsPrimitive(out code))
                    {
                        _value = new PrimitiveTypePropertyValue(this);
                    }
                    else
                    {
                        _value = new ObjectTypePropertyValue(this);
                    }
                }

                return _value;
            }
        }

        /// <summary>
        /// Checks the property is primitive or not
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool IsPrimitive(out PrimitiveTypeCode code)
        {
            if (_primitveTypeCode == null)
            {
                Type.IsPrimitive(out code);
                _primitveTypeCode = code;
            }

            code = _primitveTypeCode.Value;
            return code != PrimitiveTypeCode.None;
        }

        /// <summary>
        /// Constructs Property instance
        /// </summary>
        /// <param name="name"></param>
        /// <param
        public Property(string name, PropertyInfo propertyInfo)
        {
            Debug.Assert(name != null);
            Debug.Assert(propertyInfo != null);

            Name = name.ToLowerInvariant();
            PropertyInfo = propertyInfo;
            Type = propertyInfo.PropertyType;
        }

        /// <summary>
        /// Gets the collection of property's child properties. When the property is complex type
        /// (such as class) this method returns all serializable properties of the complex
        /// type
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, Property> GetSerializableChildProperties()
        {
            var propertyInfos = Reflector.GetPropertyInfosWithPublicGetSet(Type);
            return propertyInfos.ToDictionary(p => p.Name, p => new Property(p.Name, p));
        }

        #region Private fields

        /// <summary>
        /// The property primitive type code.
        /// </summary>
        private Nullable<PrimitiveTypeCode> _primitveTypeCode;

        #endregion
    }
}
