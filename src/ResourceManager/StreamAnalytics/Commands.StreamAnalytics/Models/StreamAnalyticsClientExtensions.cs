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

using Microsoft.Azure.Management.StreamAnalytics.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.StreamAnalytics
{
    internal static class StreamAnalyticsClientExtensions
    {
        /// <summary>
        /// Gets or sets json serialization settings.
        /// </summary>
        public static JsonSerializerSettings SerializationSettings { get; private set; }

        /// <summary>
        /// Gets or sets json deserialization settings.
        /// </summary>
        public static JsonSerializerSettings DeserializationSettings { get; private set; }

        static StreamAnalyticsClientExtensions()
        {
            SerializationSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new DefaultContractResolver(),
                Converters = new List<JsonConverter>
                    {
                        new Iso8601TimeSpanConverter()
                    }
            };
            SerializationSettings.Converters.Add(new TransformationJsonConverter());
            DeserializationSettings = new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver(),
                Converters = new List<JsonConverter>
                    {
                        new Iso8601TimeSpanConverter()
                    }
            };
            SerializationSettings.Converters.Add(new PolymorphicSerializeJsonConverter<Serialization>("type"));
            DeserializationSettings.Converters.Add(new PolymorphicDeserializeJsonConverter<Serialization>("type"));
            SerializationSettings.Converters.Add(new PolymorphicSerializeJsonConverter<InputProperties>("type"));
            DeserializationSettings.Converters.Add(new PolymorphicDeserializeJsonConverter<InputProperties>("type"));
            SerializationSettings.Converters.Add(new PolymorphicSerializeJsonConverter<OutputDataSource>("type"));
            DeserializationSettings.Converters.Add(new PolymorphicDeserializeJsonConverter<OutputDataSource>("type"));
            SerializationSettings.Converters.Add(new PolymorphicSerializeJsonConverter<FunctionProperties>("type"));
            DeserializationSettings.Converters.Add(new PolymorphicDeserializeJsonConverter<FunctionProperties>("type"));
            SerializationSettings.Converters.Add(new PolymorphicSerializeJsonConverter<StreamInputDataSource>("type"));
            DeserializationSettings.Converters.Add(new PolymorphicDeserializeJsonConverter<StreamInputDataSource>("type"));
            SerializationSettings.Converters.Add(new PolymorphicSerializeJsonConverter<ReferenceInputDataSource>("type"));
            DeserializationSettings.Converters.Add(new PolymorphicDeserializeJsonConverter<ReferenceInputDataSource>("type"));
            SerializationSettings.Converters.Add(new PolymorphicSerializeJsonConverter<FunctionBinding>("type"));
            DeserializationSettings.Converters.Add(new PolymorphicDeserializeJsonConverter<FunctionBinding>("type"));
            SerializationSettings.Converters.Add(new PolymorphicSerializeJsonConverter<FunctionRetrieveDefaultDefinitionParameters>("bindingType"));
            DeserializationSettings.Converters.Add(new PolymorphicDeserializeJsonConverter<FunctionRetrieveDefaultDefinitionParameters>("bindingType"));
            DeserializationSettings.Converters.Add(new TransformationJsonConverter());
            DeserializationSettings.Converters.Add(new CloudErrorJsonConverter());
        }

        public static string ToFormattedString(this StreamingJob properties)
        {
            return SafeJsonConvert.SerializeObject(properties, SerializationSettings);
        }

        public static string ToFormattedString<T>(this T objectToSerialize)
        {
            return SafeJsonConvert.SerializeObject(objectToSerialize, SerializationSettings);
        }
    }
}
