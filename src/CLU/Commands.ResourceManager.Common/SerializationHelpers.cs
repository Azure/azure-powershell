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
using System.IO;
using System.Linq;
using System.Management.Automation;
using Newtonsoft.Json;
using System.Reflection;

namespace Microsoft.Azure.Commands.Common.Resources
{
    public static class SerializationHelpers
    {
        public static string SerializeJson<T>(this T property) where T : class
        {
            if (property == null)
            {
                return null;
            }

            using (var stringWriter = new StringWriter())
            using (var writer = new JsonTextWriter(stringWriter))
            {

                var serializer = new JsonSerializer {Formatting = Formatting.Indented};
                stringWriter.NewLine += "    ";
                stringWriter.WriteLine();
                serializer.Serialize(writer, property);
                writer.Flush();
                return stringWriter.ToString();
            }
        }

        public static IDictionary<string, object> GetDictionary(this PSObject other)
        {
            var result = new Dictionary<string, object>();
            foreach (var property in other.Properties)
            {
                object objValue = property.Value;
                PSObject psValue = objValue as PSObject;
                if (psValue != null)
                {
                    objValue = psValue.GetDictionary();
                }

                result.Add(property.Name, objValue);
            }

            return result;
        }
        public static string SerializeAsJson(this PSObject psProperty)
        {
            if (psProperty == null)
            {
                return null;
            }

            using (var stringWriter = new StringWriter())
            using (var writer = new JsonTextWriter(stringWriter))
            {
                IDictionary<string, object> property = psProperty.GetDictionary();
                var serializer = new JsonSerializer { Formatting = Formatting.Indented };
                stringWriter.NewLine += "    ";
                stringWriter.WriteLine();
                serializer.Serialize(writer, property);
                writer.Flush();
                return stringWriter.ToString();
            }
        }

        public static string SerializeJsonCollection<T>(this IEnumerable<T> property) 
        {
            if (property == null)
            {
                return null;
            }
            if (property.Count() < 3 && typeof (T) == typeof (string) || typeof (T).GetTypeInfo().IsValueType)
            {
                return JsonConvert.SerializeObject(property);
            }

            using (var stringWriter = new StringWriter())
            using (var writer = new JsonTextWriter(stringWriter))
            {
                var serializer = new JsonSerializer { Formatting = Formatting.Indented };
                stringWriter.NewLine += "    ";
                stringWriter.WriteLine();
                serializer.Serialize(writer, property);
                writer.Flush();
                return stringWriter.ToString();
            }
        }
    }
}
