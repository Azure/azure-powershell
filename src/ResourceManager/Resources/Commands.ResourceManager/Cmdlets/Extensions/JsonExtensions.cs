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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions
{
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Json;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;

    /// <summary>
    /// <c>JSON</c> extensions
    /// </summary>
    public static class JsonExtensions
    {
        /// <summary>
        /// The JSON content type for HTTP requests.
        /// </summary>
        public const string JsonContentType = "application/json";

        /// <summary>
        /// The JSON object serialization settings.
        /// </summary>
        public static readonly JsonSerializerSettings ObjectSerializationSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.None,
            DateParseHandling = DateParseHandling.None,
            DateTimeZoneHandling = DateTimeZoneHandling.Utc,
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesWithOverridesContractResolver(),
            Converters = new List<JsonConverter>
            {
                new TimeSpanConverter(),
                new StringEnumConverter { CamelCaseText = false },
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AdjustToUniversal },
            },
        };

        /// <summary>
        /// The JSON media serialization settings.
        /// </summary>
        public static readonly JsonSerializerSettings MediaSerializationSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.None,
            DateParseHandling = DateParseHandling.None,
            DateTimeZoneHandling = DateTimeZoneHandling.Utc,
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesWithOverridesContractResolver(),
            Converters = new List<JsonConverter>
            {
                new TimeSpanConverter(),
                new StringEnumConverter { CamelCaseText = false },
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AdjustToUniversal },
            },
        };

        /// <summary>
        /// The JSON media type serializer.
        /// </summary>
        public static readonly JsonSerializer JsonMediaTypeSerializer = JsonSerializer.Create(JsonExtensions.MediaSerializationSettings);

        /// <summary>
        /// The JSON object type serializer.
        /// </summary>
        public static readonly JsonSerializer JsonObjectTypeSerializer = JsonSerializer.Create(JsonExtensions.ObjectSerializationSettings);

        /// <summary>
        /// Serialize object to the JSON.
        /// </summary>
        /// <param name="obj">The object.</param>
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj, JsonExtensions.ObjectSerializationSettings);
        }

        /// <summary>
        /// Serialize object to formatted JSON.
        /// </summary>
        /// <param name="obj">The object.</param>
        public static string ToFormattedJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }

        /// <summary>
        /// Deserialize object from the JSON.
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="json">JSON representation of object</param>
        public static T FromJson<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json, JsonExtensions.ObjectSerializationSettings);
        }

        /// <summary>
        /// Deserialize object from a JSON stream.
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="stream">A <see cref="Stream"/> that contains a JSON representation of object</param>
        public static T FromJson<T>(this Stream stream)
        {
            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return JsonExtensions.JsonObjectTypeSerializer.Deserialize<T>(jsonReader);
            }
        }

        /// <summary>
        /// Serialize object to JToken.
        /// </summary>
        /// <param name="obj">The object.</param>
        public static JToken ToJToken(this object obj)
        {
            if (obj == null)
            {
                return null;
            }

            return JToken.FromObject(obj, JsonExtensions.JsonObjectTypeSerializer);
        }

        /// <summary>
        /// Checks if a conversion from the supplied <see cref="JToken"/> to a <typeparamref name="TType"/> can be made.
        /// </summary>
        /// <typeparam name="TType">The type to convert to.</typeparam>
        /// <param name="jobject">The <see cref="JObject"/>.</param>
        public static bool CanConvertTo<TType>(this JToken jobject)
        {
            TType ignored;
            return jobject.TryConvertTo(out ignored);
        }

        /// <summary>
        /// Checks if a conversion from the supplied <see cref="JToken"/> to a <typeparamref name="TType"/> can be made.
        /// </summary>
        /// <typeparam name="TType">The type to convert to.</typeparam>
        /// <param name="str">The string.</param>
        /// <param name="result">The result.</param>
        public static bool TryConvertTo<TType>(this string str, out TType result)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                result = default(TType);
                return true;
            }

            try
            {
                result = str.FromJson<TType>();
                return !object.Equals(result, default(TType));
            }
            catch (FormatException)
            {
            }
            catch (ArgumentException)
            {
            }
            catch (JsonException)
            {
            }

            result = default(TType);
            return false;
        }

        /// <summary>
        /// Checks if a conversion from the supplied <see cref="JToken"/> to a <typeparamref name="TType"/> can be made.
        /// </summary>
        /// <typeparam name="TType">The type to convert to.</typeparam>
        /// <param name="jobject">The <see cref="JObject"/>.</param>
        /// <param name="result">The result.</param>
        public static bool TryConvertTo<TType>(this JToken jobject, out TType result)
        {
            if (jobject == null)
            {
                result = default(TType);
                return true;
            }

            try
            {
                result = jobject.ToObject<TType>(JsonExtensions.JsonMediaTypeSerializer);
                return !object.Equals(result, default(TType));
            }
            catch (FormatException)
            {
            }
            catch (ArgumentException)
            {
            }
            catch (JsonException)
            {
            }

            result = default(TType);
            return false;
        }
    }
}