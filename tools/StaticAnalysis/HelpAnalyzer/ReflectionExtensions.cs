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

namespace StaticAnalysis.help

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

        public static IEnumerable<PropertyInfo> GetParameters(this Type cmdletType)
        {
            return cmdletType.GetProperties().Where(p => p.HasAttribute<ParameterAttribute>());
        }

        public static IEnumerable<Type> GetCmdletTypes(this Assembly assembly)
        {
            return assembly.GetTypes().Where(t => t.HasAttribute<CmdletAttribute>());
        }

    }
}
