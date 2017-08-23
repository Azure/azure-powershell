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
    using System.Xml;
    using Newtonsoft.Json;

    /// <summary>
    /// The TimeSpan converter based on ISO 8601 format.
    /// </summary>
    internal sealed class TimeSpanJsonConverter : JsonConverter
    {
        /// <summary>
        /// Writes the <c>JSON</c>.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            ArgumentValidator.ValidateNotNull("serializer", serializer);

            serializer.Serialize(writer, XmlConvert.ToString((TimeSpan)value));
        }

        /// <summary>
        /// Reads the <c>JSON</c>.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value.</param>
        /// <param name="serializer">The serializer.</param>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            ArgumentValidator.ValidateNotNull("reader", reader);
            ArgumentValidator.ValidateNotNull("serializer", serializer);

            return reader.TokenType != JsonToken.Null ? (object)XmlConvert.ToTimeSpan(serializer.Deserialize<string>(reader)) : null;
        }

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(TimeSpan) || objectType == typeof(TimeSpan?);
        }
    }
}