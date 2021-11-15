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

using System.IO;
using System.Reflection;
using System.Text.Json;

namespace Microsoft.Azure.Commands.Synapse.Common
{
    internal static class JsonConvert
    {
        internal static T DeserializeObject<T>(string rawJsonContent)
        {
            var document = JsonDocument.Parse(rawJsonContent);
            MethodInfo deserializer = typeof(T).GetMethod($"Deserialize{typeof(T).Name}", BindingFlags.NonPublic | BindingFlags.Static);
            return (T) deserializer.Invoke(null, new object[] { document.RootElement });
        }

        internal static string SerializeObject(object obj)
        {
            // TODO: in future, we might consider to add option to allow users to specify JSON writer options.
            using (MemoryStream memoryStream = new MemoryStream())
            using (Utf8JsonWriter writer = new Utf8JsonWriter(memoryStream, new JsonWriterOptions { Indented = true }))
            {
                SerializeObject(obj, writer);
                return memoryStream.ToString();
            }
        }

        internal static void SerializeObject(object obj, string outputPath)
        {
            using (FileStream writeStream = File.Open(outputPath, FileMode.Create))
            using (Utf8JsonWriter writer = new Utf8JsonWriter(writeStream))
            {
                SerializeObject(obj, writer);
            }
        }

        internal static void SerializeObject(object obj, Utf8JsonWriter writer)
        {
            MethodInfo serializer = obj.GetType().GetMethod("Write", BindingFlags.NonPublic);
            serializer.Invoke(obj, new object[] { writer });
        }
    }
}
