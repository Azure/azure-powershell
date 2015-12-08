using Microsoft.CLU.Metadata;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Microsoft.CLU.Helpers
{
    /// <summary>
    /// Helper utility to make reflecion API calls
    /// </summary>
    internal static class Reflector
    {
        /// <summary>
        /// Gets the collection of serializable properties of a give type. A property is serializable if it has public
        /// get and set accessors.
        /// 
        /// When a class inherits from base class, if the class designer intended to override a property in the derived 
        /// class but forgot to specify new or override keyword then Type::GetProperties returns proprty from the base 
        /// class and the same property from the derived class. The removeHiddenProperties flag indicates whether to 
        /// include such properties from the base class. 
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="removeHiddenProperties">Whether to remove the overriden properties or not</param>
        /// <returns></returns>
        public static IEnumerable<PropertyInfo> GetPropertyInfosWithPublicGetSet(Type type, bool removeHiddenProperties = true)
        {
            Debug.Assert(type != null);

            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.CanRead && p.CanWrite);
            if (!removeHiddenProperties)
            {
                return properties;
            }

            IList<PropertyInfo> distinctProperties = new List<PropertyInfo>();
            var propertiesGroups = from property in properties 
                                    group property by property.Name.ToLowerInvariant() into propertiesGroup 
                                    select propertiesGroup;
            IDictionary<Type, int> parents = new Dictionary<Type, int>();
            int level = 0;
            for (var current = type; current != null; current = current.GetTypeInfo().BaseType, level++)
            {
                parents.Add(current, level);
            }

            foreach (var propertiesGroup in propertiesGroups)
            {
                if (propertiesGroup.Count() == 1)
                {
                    distinctProperties.Add(propertiesGroup.First());
                }
                else
                {
                    PropertyInfo selectedProperty = propertiesGroup.First();
                    level = parents[selectedProperty.DeclaringType];
                    foreach (var property in propertiesGroup)
                    {
                        int l = parents[property.DeclaringType];
                        if (l < level)
                        {
                            level = l;
                            selectedProperty = property;
                        }
                    }

                    distinctProperties.Add(selectedProperty);
                }
            }

            return distinctProperties;
        }

        /// <summary>
        /// Get method paramters
        /// </summary>
        /// <param name="methodInfo"></param>
        /// <returns></returns>
        public static IEnumerable<ParameterInfo> GetParameterInfos(MethodInfo methodInfo)
        {
            return methodInfo.GetParameters();
        }

        /// <summary>
        /// Gets method paramters as Parameter collection
        /// </summary>
        /// <param name="methodInfo"></param>
        /// <returns></returns>
        public static IDictionary<string, Parameter> GetParameters(MethodInfo methodInfo)
        {
            return GetParameterInfos(methodInfo).ToDictionary(p => p.Name.ToLowerInvariant(), p => new Parameter(p.Name, p));
        }
    }
}
