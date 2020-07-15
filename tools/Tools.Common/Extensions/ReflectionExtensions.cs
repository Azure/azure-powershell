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

namespace Tools.Common.Extensions

{
    public static class ReflectionExtensions
    {
        public static T GetAttribute<T>(this Type decoratedType) where T : Attribute
        {
            return decoratedType.GetTypeInfo().GetCustomAttribute(typeof(T), true) as T;
        }

        public static T GetAttribute<T>(this ParameterInfo decoratedParameter) where T : Attribute
        {
            return decoratedParameter.MemberInfo.GetCustomAttribute(typeof(T), true) as T;
        }

        public static IEnumerable<T> GetAttributes<T>(this Type decoratedType) where T : Attribute
        {
            return decoratedType.GetTypeInfo().GetCustomAttributes(typeof(T), false).Select(a => a as T);
        }

        public static IEnumerable<T> GetAttributes<T>(this ParameterInfo decoratedParameter) where T : Attribute
        {
            return decoratedParameter.MemberInfo.GetCustomAttributes(typeof(T), false).Select(a => a as T);
        }

        public static bool HasAttribute<T>(this Type decoratedType) where T : Attribute
        {
            return decoratedType.GetTypeInfo().CustomAttributes.Any(d => d.AttributeType == typeof(T));

        }

        public static bool HasAttribute<T>(this ParameterInfo decoratedParameter) where T : Attribute
        {
            return decoratedParameter.MemberInfo.CustomAttributes.Any(d => d.AttributeType == typeof(T));

        }

        public class ParameterInfo
        {
            public ParameterInfo(MemberInfo memberInfo, Type parameterType)
            {
                MemberInfo = memberInfo;
                ParameterType = parameterType;
            }
            public MemberInfo MemberInfo;
            public Type ParameterType;
        }

        public static IEnumerable<ParameterInfo> GetParameters(this Type cmdletType)
        {
            var properties = cmdletType.GetProperties().Select(p => new ParameterInfo((MemberInfo)p, p.PropertyType)).Where(p => p.HasAttribute<ParameterAttribute>());
            var fields = cmdletType.GetFields().Select(f => new ParameterInfo((MemberInfo)f, f.FieldType)).Where(f => f.HasAttribute<ParameterAttribute>());
            return properties.Concat(fields);
        }

        public static IEnumerable<Type> GetCmdletTypes(this Assembly assembly)
        {
            return assembly.GetTypes().Where(t => t.HasAttribute<CmdletAttribute>());
        }

    }
}
