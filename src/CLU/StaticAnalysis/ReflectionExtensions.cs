// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Utilities.Common;

namespace StaticAnalysis
{
    public static class ReflectionExtensions
    {
        public static T GetAttribute<T>(this Type decoratedType) where T : Attribute
        {
            return decoratedType.GetTypeInfo().GetCustomAttribute(typeof(T), true) as T;
        }

        public static T GetAttribute<T>(this PropertyInfo decoratedProperty) where T : Attribute
        {
            return decoratedProperty.GetCustomAttribute(typeof(T), true) as T;
        }

        public static IEnumerable<T> GetAttributes<T>(this Type decoratedType) where T : Attribute
        {
            return decoratedType.GetTypeInfo().GetCustomAttributes(typeof(T), false).Select(a => a as T);
        }

        public static IEnumerable<T> GetAttributes<T>(this PropertyInfo decoratedProeprty) where T : Attribute
        {
            return decoratedProeprty.GetCustomAttributes(typeof(T), false).Select(a => a as T);
        }

        public static bool HasAttribute<T>(this Type decoratedType) where T : Attribute
        {
            return decoratedType.GetTypeInfo().CustomAttributes.Any(d => d.AttributeType == typeof (T));

        }

        public static bool HasAttribute<T>(this PropertyInfo decoratedProperty) where T : Attribute
        {
            return decoratedProperty.CustomAttributes.Any(d => d.AttributeType == typeof(T));

        }

        public static IEnumerable<Type> GetCmdletTypes(this Assembly assembly)
        {
            return assembly.ExportedTypes.Where(t => t.HasAttribute<CmdletAttribute>());
        }

        public static string GetDisplayName(this Type type)
        {
            var displayName = type.Name.ToCamelCase();
            var typeInfo = type.GetTypeInfo();
            if (string.Equals(displayName, "SwitchParameter", StringComparison.OrdinalIgnoreCase))
            {
                displayName = "flag";
            }
            if (typeInfo.IsGenericType)
            {
                if (!type.IsConstructedGenericType)
                {
                    throw new InvalidOperationException("Cannot use a generic type defintion");
                }
                var args = type.GetGenericArguments();
                var baseType = type.GetGenericTypeDefinition();
                if (type.Name.StartsWith("Nullable", StringComparison.OrdinalIgnoreCase))
                {
                    displayName = args.First().Name.ToCamelCase();
                }
                else if (type.Name.StartsWith("List", StringComparison.OrdinalIgnoreCase) 
                    || type.Name.StartsWith("IList", StringComparison.OrdinalIgnoreCase))
                {
                    displayName = $"{args.First().GetDisplayName()}[]";
                }
                else if (type.Name.StartsWith("Dictionary", StringComparison.OrdinalIgnoreCase)
                    || type.Name.StartsWith("IDictionary", StringComparison.OrdinalIgnoreCase))
                {
                    displayName = "hashtable";
                }
                else if (displayName.Contains("`"))
                {
                    var index = displayName.LastIndexOf('`');
                    displayName = $"{displayName.Substring(0, index).ToCamelCase()}[{string.Join(", ", args.Select(t => t.GetDisplayName()))}]";
                }

            }
            else if (!typeInfo.IsPrimitive && !type.Namespace.StartsWith("System"))
            {
                displayName = "object";
            }

            return displayName;
        }
        public static bool IsComplex(this Type type)
        {
            var info = type.GetTypeInfo();
            return (!info.IsPrimitive && !type.Namespace.StartsWith("System") &&
                    !type.Namespace.StartsWith("Newtonsoft", StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Determine if a type could produce the given output type
        /// </summary>
        /// <param name="type">The type to check</param>
        /// <param name="targetType">The target type</param>
        /// <returns>true if targetType cna be produced from type, otherwise false.</returns>
        public static bool Produces(this Type type, Type targetType)
        {
            return type == targetType
                   || (type.IsConstructedGenericType && type.GetGenericArguments().Contains(targetType))
                   || (targetType.IsConstructedGenericType && targetType.GetGenericArguments().Contains(type));
        }
    }
}
