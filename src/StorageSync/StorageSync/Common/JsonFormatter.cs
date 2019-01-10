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

#if !NETSTANDARD
namespace Microsoft.Azure.Commands.StorageSync.Common
{

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Linq;
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Threading.Tasks;
    
    /// <summary>
    /// Json formatter use JSON.NET
    /// </summary>
    public class JsonFormatter : MediaTypeFormatter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonFormatter"/> class.
        /// </summary>
        public JsonFormatter()
        {
            this.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("application/json"));
        }

        /// <summary>
        /// Queries whether this MediaTypeFormatter can serialize object of the specified type.
        /// </summary>
        /// <param name="type">The type to serialize.</param>
        /// <returns>true if the MediaTypeFormatter can serialize the type; otherwise, false.</returns>
        public override bool CanWriteType(Type type)
        {
            // don't serialize JsonValue structure use default for that
            if (type == typeof(JValue) || type == typeof(JObject) || type == typeof(JArray))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Queries whether this MediaTypeFormatter can deserialize object of the specified type.
        /// </summary>
        /// <param name="type">The type to deserialize.</param>
        /// <returns>true if the MediaTypeFormatter can deserialize the type; otherwise, false.</returns>
        public override bool CanReadType(Type type)
        {
            return true;
        }

        /// <summary>
        /// Asynchronously deserializes an object of the specified type.
        /// </summary>
        /// <param name="type">The type of the object to deserialize.</param>
        /// <param name="stream">The Stream to read.</param>
        /// <param name="content">The HttpContent, if available. It may be null.</param>
        /// <param name="formatterLogger">The IFormatterLogger to log events to.</param>
        /// <returns>A Task whose result will be an object of the given type.</returns>
        public override Task<object> ReadFromStreamAsync(
            Type type,
            Stream stream,
            HttpContent content,
            IFormatterLogger formatterLogger)
        {
            var sr = new StreamReader(stream);
            var result = this.ReadAsync(type, sr);

            // This enables us to read the content stream multiple times.
            result.ContinueWith((a) => stream.Seek(0, SeekOrigin.Begin));

            return result;
        }

        /// <summary>
        /// Asynchronously writes an object of the specified type.
        /// </summary>
        /// <param name="type">The type of the object to write.</param>
        /// <param name="value">The object value to write. It may be null.</param>
        /// <param name="stream">The Stream to which to write.</param>
        /// <param name="content">The HttpContent if available. It may be null.</param>
        /// <param name="transportContext">The TransportContext if available. It may be null.</param>
        /// <returns>A Task that will perform the write.</returns>
        public override Task WriteToStreamAsync(
            Type type,
            object value,
            Stream stream,
            HttpContent content,
            TransportContext transportContext)
        {
            var task = Task.Factory.StartNew(() =>
            {
                var settings = new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                };

                string json = JsonConvert.SerializeObject(
                value,
                Formatting.Indented,
                settings);

                byte[] buf = System.Text.Encoding.UTF8.GetBytes(json);
                stream.Write(buf, 0, buf.Length);
                stream.Flush();
            });

            return task;
        }

        /// <summary>
        /// Asynchronously deserializes an object of the specified type.
        /// </summary>
        /// <param name="type">The type of the object to deserialize.</param>
        /// <param name="value">The string to read.</param>
        /// <returns>A Task whose result will be an object of the given type.</returns>
        public Task<object> ReadFromBase64StringAsync(Type type, string value)
        {
            byte[] buf = Convert.FromBase64String(value);
            string str = System.Text.Encoding.UTF8.GetString(buf);

            var sr = new StringReader(str);
            return this.ReadAsync(type, sr);
        }

        /// <summary>
        /// Deserializes an object of the specified type.
        /// </summary>
        /// <param name="type">The type of the object to deserialize.</param>
        /// <param name="value">The string to read.</param>
        /// <returns>A Task whose result will be an object of the given type.</returns>
        public object ReadFromBase64String(Type type, string value)
        {
            byte[] buf = Convert.FromBase64String(value);
            string str = System.Text.Encoding.UTF8.GetString(buf);

            var sr = new StringReader(str);
            return this.ReadAsync(type, sr);
        }

        /// <summary>
        /// Asynchronously writes an object of the specified type to base64 string.
        /// </summary>
        /// <param name="type">The type of the object to write.</param>
        /// <param name="value">The object value to write. It may be null.</param>
        /// <returns>A Task that will perform the write.</returns>
        public Task<string> WriteToBase64StringAsync(Type type, object value)
        {
            var task = Task<string>.Factory.StartNew(() =>
            {
                var settings = new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                };

                string json = JsonConvert.SerializeObject(
                        value,
                        Formatting.None,
                        settings);

                byte[] buf = System.Text.Encoding.UTF8.GetBytes(json);
                return Convert.ToBase64String(buf);
            });

            return task;
        }

        /// <summary>
        /// Asynchronously deserializes an object of the specified type.
        /// </summary>
        /// <param name="type">The type of the object to deserialize.</param>
        /// <param name="reader">The test reader.</param>
        /// <returns>A Task whose result will be an object of the given type.</returns>
        private Task<object> ReadAsync(Type type, TextReader reader)
        {
            var task = Task<object>.Factory.StartNew(() =>
            {
                return this.Read(type, reader);
            });

            return task;
        }

        /// <summary>
        /// Deserializes an object of the specified type.
        /// </summary>
        /// <param name="type">The type of the object to deserialize.</param>
        /// <param name="reader">The test reader.</param>
        /// <returns>A Task whose result will be an object of the given type.</returns>
        private object Read(Type type, TextReader reader)
        {
            var jsonTextReader = new JsonTextReader(reader);
            var jsonSerializer = new JsonSerializer();
            jsonSerializer.Converters.Add(new IsoDateTimeConverter());
            return jsonSerializer.Deserialize(jsonTextReader, type);
        }
    }
}
#endif