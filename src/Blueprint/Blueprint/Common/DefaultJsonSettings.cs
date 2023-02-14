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

using Microsoft.Azure.Management.Blueprint.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Blueprint.Common
{
    public static class DefaultJsonSettings
    {
        /// <summary>
        /// Serializer settings for JSON schemas owned by Blueprint RP. Use this to (de)serialize doc db entities,
        /// blueprint rp resource bodies, or any objects whose schema we control.
        /// </summary>
        public static JsonSerializerSettings DeserializerSettings
        {
            get
            {
                var settings = new JsonSerializerSettings
                {
                    DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat,
                    DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc,
                    NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize,
                    ContractResolver = new ReadOnlyJsonContractResolver(),
                    Converters = new List<JsonConverter>
                    {
                        new Iso8601TimeSpanConverter()
                    }
                };

                settings.Converters.Add(new PolymorphicDeserializeJsonConverter<Artifact>("kind"));
                settings.Converters.Add(new TransformationJsonConverter());
                settings.Converters.Add(new CloudErrorJsonConverter());

                return settings;
            }
        }
        public static JsonSerializerSettings SerializerSettings
        {
            get
            {
                var settings = new JsonSerializerSettings
                {
                    Formatting = Newtonsoft.Json.Formatting.Indented,
                    DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat,
                    DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc,
                    NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize,
                    ContractResolver = new ReadOnlyJsonContractResolver(),
                    Converters = new List<JsonConverter>
                    {
                        new Iso8601TimeSpanConverter()
                    }
                };

                settings.Converters.Add(new TransformationJsonConverter());
                settings.Converters.Add(new PolymorphicSerializeJsonConverter<Artifact>("kind"));

                return settings;
            }
        }
    }
}
