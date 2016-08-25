// Copyright Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// 
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Microsoft.Azure.Commands.ServerManagement.Utility
{
    using System;
    using System.Reflection;
    using System.Text.RegularExpressions;

    internal static class Extensions
    {
        private static void SetMember<T>(this T target, string memberName, object value)
        {
            var dField = typeof(T).GetField(memberName,
                BindingFlags.NonPublic | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.IgnoreCase);
            if (dField != null)
            {
                try
                {
                    dField.SetValue(target, value);
                    return;
                }
                catch
                {
                    // skip it
                }
            }
            try
            {
                var dProp = typeof(T).GetProperty(memberName,
                    BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                if (dProp != null)
                {
                    if (dProp.DeclaringType != null)
                    {
                        dProp = dProp.DeclaringType.GetProperty(memberName,
                            BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance |
                            BindingFlags.IgnoreCase) ?? dProp;
                    }

                    dProp.GetSetMethod(true).Invoke(target, new[] {value});
                }
            }
            catch
            {
            }
        }

        internal static string ExtractFieldFromResourceId(this string resourceId, string prefix)
        {
            try
            {
                return Regex.Match(resourceId + "/", string.Format("/{0}/(.*?)/", prefix)).Groups[1].Value;
            }
            catch
            {
            }

            return null;
        }

        internal static TDest CloneInto<TSrc, TDest>(this TSrc source, TDest destination)
        {
            // run thru public properties
            foreach (var property in typeof(TSrc).GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                destination.SetMember(property.Name, property.GetValue(source));
            }

            // run thru public fields
            foreach (var field in typeof(TSrc).GetFields(BindingFlags.Instance | BindingFlags.Public))
            {
                destination.SetMember(field.Name, field.GetValue(source));
            }
            return destination;
        }
    }
}