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
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Internal;
using System.Management.Automation.Language;
using System.Reflection;
using System.Security;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
using Microsoft.WindowsAzure.Commands.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Json
{
    public static class PSJsonSerializer
    {
        public struct SerializeContext
        {
            public SerializeContext(int maxDepth, bool serializeSecureString)
            {
                this.MaxDepth = maxDepth;
                this.SerializeSecureString = serializeSecureString;
            }

            public int MaxDepth { get; }

            public bool SerializeSecureString { get; }
        }

        public static string Serialize(object value, bool serializeSecureString = false)
        {
            var context = new SerializeContext(1024, serializeSecureString);

            return Serialize(value, context);
        }

        public static string Serialize(object value, SerializeContext context)
        {
            try
            {
                object processed = ProcessValue(value, 0, context);

                // NOTE(jcotillo): JsonExtensions.ToJson() extension uses a custom serialization settings
                // that preserves DateTime values as string (DateParseHandling = DateParseHandling.None),
                // plus other custom settings.
                return processed.ToJson();
            }
            catch (OperationCanceledException)
            {
                return null;
            }
        }

        private static object ProcessValue(object value, int currentDepth, SerializeContext context)
        {
            if (value == null || value == AutomationNull.Value)
            {
                return null;
            }

            var psObject = value as PSObject;

            if (psObject != null)
            {
                value = psObject.BaseObject;
            }

            if (value is SecureString secureString)
            {
                // This requires a conscious opt-in, rather than being the default behavior - to avoid accidentally leaking sensitive information.
                if (context.SerializeSecureString)
                {
                    return secureString.ConvertToString();
                }
                else
                {
                    throw new InvalidOperationException("Unable to serialize secure string value");
                }
            }

            if (value == NullString.Value || value == DBNull.Value)
            {
                return null;
            }

            if (IsPrimitive(value))
            {
                return value;
            }

            if (value is JValue jValue)
            {
                return jValue.Value<object>();
            }

            if (value is JObject jObject)
            {
                return jObject.Properties().ToDictionary(x => x.Name, x => x.Value);
            }

            Type type = value.GetType();

            if (type.IsPrimitive)
            {
                return value;
            }

            if (type.IsEnum)
            {
                // Win8:378368 Enums based on System.Int64 or System.UInt64 are not JSON-serializable
                // because JavaScript does not support the necessary precision.
                Type enumUnderlyingType = Enum.GetUnderlyingType(value.GetType());

                return enumUnderlyingType.Equals(typeof(long)) || enumUnderlyingType.Equals(typeof(ulong))
                    ? value.ToString()
                    : value;
            }

            if (currentDepth > context.MaxDepth)
            {
                object valueToConvert = IsPurePsObject(psObject) ? psObject : value;

                return LanguagePrimitives.ConvertTo(valueToConvert, typeof(string), CultureInfo.InvariantCulture);
            }

            if (value is IDictionary dict)
            {
                return ProcessDictionary(dict, currentDepth, context);
            }

            if (value is IEnumerable enumerable)
            {
                return ProcessEnumerable(enumerable, currentDepth, context);
            }

            return ProcessObject(value, currentDepth, context);
        }

        private static object ProcessDictionary(IDictionary dictionary, int depth, SerializeContext context)
        {
            var result = new Dictionary<string, object>(dictionary.Count);

            foreach (DictionaryEntry entry in dictionary)
            {
                if (!(entry.Key is string name))
                {
                    throw new InvalidOperationException("Non-string key in dictionary");
                }

                result.Add(name, ProcessValue(entry.Value, depth + 1, context));
            }

            return result;
        }

        private static object ProcessEnumerable(IEnumerable enumerable, int depth, SerializeContext context)
        {
            var result = new List<object>();

            foreach (object o in enumerable)
            {
                result.Add(ProcessValue(o, depth + 1, context));
            }

            return result;
        }

        private static object ProcessObject(object @object, int depth, SerializeContext context)
        {
            var result = new Dictionary<string, object>();
            Type type = @object.GetType();
            BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            foreach (FieldInfo info in type.GetFields(bindingFlags).Where(HasNoJsonIgnoreAttribute))
            {
                object value;

                try
                {
                    value = info.GetValue(@object);
                }
                catch (Exception)
                {
                    value = null;
                }

                result.Add(info.Name, ProcessValue(value, depth + 1, context));
            }

            foreach (PropertyInfo info in type.GetProperties(bindingFlags).Where(HasNoJsonIgnoreAttribute))
            {
                MethodInfo getMethod = info.GetGetMethod();

                if (getMethod != null && getMethod.GetParameters().Length == 0)
                {
                    object value;

                    try
                    {
                        value = getMethod.Invoke(@object, Array.Empty<object>());
                    }
                    catch (Exception)
                    {
                        value = null;
                    }

                    result.Add(info.Name, ProcessValue(value, depth + 1, context));
                }
            }

            return result;
        }

        private static bool IsPurePsObject(PSObject psObject)
        {
            return psObject != null && !(psObject.BaseObject is PSCustomObject);
        }

        private static bool IsPrimitive(object value)
        {
            return value is string
                || value is char
                || value is bool
                || value is DateTime
                || value is DateTimeOffset
                || value is Guid
                || value is Uri
                || value is double
                || value is float
                || value is decimal;
        }

        private static bool HasNoJsonIgnoreAttribute(MemberInfo info)
        {
            return !info.IsDefined(typeof(JsonIgnoreAttribute), true);
        }
    }
}