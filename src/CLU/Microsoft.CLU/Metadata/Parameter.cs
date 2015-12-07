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
    /// Represents a parameter of command entry method
    /// </summary>
    internal class Parameter
    {
        /// <summary>
        /// Parameter name
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// Position of the parameter in the parameter set
        /// </summary>
        public int Position
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
        /// Provide full access to parameter metadata
        /// </summary>
        public ParameterInfo ParameterInfo
        {
            get;
            private set;
        }

        IValueSetter _value;
        /// <summary>
        /// Reference to IValueSetter instance aware of how to set value for the parameter
        /// </summary>
        internal IValueSetter Value {
            get
            {
                if (_value == null)
                {
                    PrimitiveTypeCode code;
                    if (IsPrimitive(out code))
                    {
                        _value = new PrimitiveTypeParameterValue(this);
                    }
                    else
                    {
                        _value = new ObjectTypeParameterValue(this);
                    }
                }

                return _value;
            }
        }

        /// <summary>
        /// Checks the parameter is primitive or not
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
        /// Constructs Parameter instance
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parameterInfo"></param>
        public Parameter(string name, ParameterInfo parameterInfo)
        {
            Debug.Assert(name != null);
            Debug.Assert(parameterInfo != null);

            Name = name.ToLowerInvariant();
            ParameterInfo = parameterInfo;
            Type = parameterInfo.ParameterType;
            Position = ParameterInfo.Position;
        }

        /// <summary>
        /// Gets the collection of parameter properties. When the parameter is complex type
        /// (such as class) this method returns all serializable properties of the complex
        /// type
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, Property> GetSerializableChildProperties()
        {
            var propertyInfos = Reflector.GetPropertyInfosWithPublicGetSet(Type);
            return propertyInfos.ToDictionary(p => p.Name, p=> new Property(p.Name, p));
        }

        #region Private fields

        /// <summary>
        /// The parameter primitive type code.
        /// </summary>
        private PrimitiveTypeCode? _primitveTypeCode;

        #endregion
    }
}
