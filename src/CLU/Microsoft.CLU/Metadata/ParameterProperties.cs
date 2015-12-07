using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;
using System.Reflection;

namespace Microsoft.CLU.Metadata
{
    /// <summary>
    /// Class represents the type properties those are declared as parameters.
    /// </summary>
    internal class ParameterProperties
    {
        /// <summary>
        /// Gets the parameter properties defined in the given type.
        /// </summary>
        /// <param name="cmdletType"></param>
        /// <returns></returns>
        public static IList<ParameterProperty> Get(Type cmdletType)
        {
            return cmdletType.GetProperties().Select(p => new ParameterProperty(p)).Where(p => p.Attributes.Length > 0).ToList();
        }

        /// <summary>
        /// Type represents a parameter property.
        /// </summary>
        internal class ParameterProperty
        {
            /// <summary>
            /// The property,
            /// </summary>
            public PropertyInfo Property { get; internal set; }

            /// <summary>
            /// Parameter attributes.
            /// </summary>
            public ParameterAttribute[] Attributes { get; internal set; }

            /// <summary>
            /// Creates an ParameterProperty instance for the given property.
            /// </summary>
            /// <param name="property">The property</param>
            public ParameterProperty(PropertyInfo property)
            {
                Debug.Assert(property != null);
                Property = property;
                Attributes = property.GetCustomAttributes(typeof(ParameterAttribute), true) as ParameterAttribute[];
            }
        }
    }
}
