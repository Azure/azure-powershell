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
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Common.Strategies.Json
{
    class TypedObjectConverter : IConverter
    {
        public object Deserialize(Converters converters, Type type, JToken token)
        {
            var jObject = token as JObject;
            var result = Activator.CreateInstance(type);
            foreach (var pInfo in type.GetProperties())
            {
                var names = GetProperty(pInfo);
                var property = names.Aggregate(
                    null, 
                    (Property p, string name) => p == null 
                        ? new Property(jObject, name) 
                        : p.GetProperty(name));
                var jValue = property == null ? null : property.Get();
                var value = converters.Deserialize(pInfo.PropertyType, jValue);
                if (value != null)
                {
                    pInfo.SetValue(result, value);
                }
            }
            return result;
        }

        public bool Match(Type type)
            => true;

        public JToken Serialize(Converters converters, Type type, object value)
        {
            var jObject = new JObject();
            foreach (var pInfo in type.GetProperties())
            {
                var jValue = converters.Serialize(pInfo.PropertyType, pInfo.GetValue(value));
                if (jValue != null)
                {
                    var names = GetProperty(pInfo);
                    var property = names.Aggregate(
                        null, 
                        (Property p, string name) => 
                            new Property(p == null ? jObject : p.GetOrCreateJObject(), name));
                    property.Set(jValue);
                }
            }
            return jObject;
        }

        sealed class Property
        {
            public JObject JObject { get; }

            public string Name { get; }

            public Property(JObject jObject, string name)
            {
                JObject = jObject;
                Name = name;
            }

            public void Set(JToken value)
            {
                JObject[Name] = value;
            }

            public JToken Get()
                => JObject[Name];

            public JObject GetJObject()
                => Get() as JObject;

            public JObject GetOrCreateJObject()
            {
                var result = GetJObject();
                if (result == null)
                {
                    result = new JObject();
                    Set(result);
                }
                return result;
            }

            public Property GetProperty(string name)
            {
                var jObject = GetJObject();
                return jObject == null ? null : new Property(jObject, name);
            }
        }

        static IEnumerable<string> GetProperty(PropertyInfo info)
        {
            var a = info
                .GetCustomAttributes(typeof(JsonPropertyAttribute), true)
                .OfType<JsonPropertyAttribute>()
                .FirstOrDefault();
            return a == null
                ? new[] { info.Name }
                : Parse(a.PropertyName);
        }

        static IEnumerable<string> Parse(string property)
        {
            var result = string.Empty;
            bool escape = false;
            foreach (var c in property)
            {
                if (c == '\\')
                {
                    escape = true;
                }
                else
                {
                    if (!escape && c == '.')
                    {
                        yield return result;
                        result = string.Empty;
                    }
                    else
                    {
                        result += c;
                    }
                    escape = false;
                }
            }
            yield return result;
        }
    }
}
