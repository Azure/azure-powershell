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

namespace Microsoft.AzureStack.Commands.Common
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// The extension methods for managing JSON requests and responses.
    /// </summary>
    public static class JsonExtensions
    {
        /// <summary>
        /// The json serialization maximum depth
        /// </summary>
        private const int JsonSerializationMaxDepth = 512;

        /// <summary>
        /// The serialization settings used for request/response related serialization and deserialization.
        /// </summary>
        private static readonly JsonSerializerSettings MediaTypeFormatterSettings = CreateMediaTypeSerializerSettings();

        /// <summary>
        /// The json media type serializer
        /// </summary>
        private static readonly JsonSerializer JsonMediaTypeSerializer = JsonSerializer.Create(JsonExtensions.MediaTypeFormatterSettings);


        /// <summary>
        /// The serialization settings used for request/response related serialization and deserialization.
        /// </summary>
        public static JsonSerializerSettings CreateMediaTypeSerializerSettings()
        {
            return new JsonSerializerSettings()
            {
                MaxDepth = JsonSerializationMaxDepth,
                TypeNameHandling = TypeNameHandling.None,
                DateParseHandling = DateParseHandling.None,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Error,
                ContractResolver = new CamelCasePropertyNamesWithOverridesContractResolver(),
                Converters = new List<JsonConverter>()
                {
                    new LineInfoJsonConverter(),
                    new TimeSpanJsonConverter(),
                    new StringEnumConverter()
                    {
                        CamelCaseText = false
                    },
                    new AdjustToUniversalIsoDateTimeConverter(),
                }
            };
        }

        /// <summary>
        /// Deserialize object from its JSON representation.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="json">The json.</param>
        public static T FromJson<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json, MediaTypeFormatterSettings);
        }

    }
}
