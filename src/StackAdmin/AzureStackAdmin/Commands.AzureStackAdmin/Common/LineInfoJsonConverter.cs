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
    using Newtonsoft.Json;

    /// <summary>
    /// The line info converter.
    /// </summary>
    internal sealed class LineInfoJsonConverter : JsonConverter
    {
        /// <summary>
        /// Gets a value indicating whether this converter can write JSON.
        /// </summary>
        public override bool CanWrite
        {
            get { return false; }
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException(message: "Converter is not writable. Method should not be invoked");
        }

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        public override bool CanConvert(Type objectType)
        {
            return typeof(JsonLineInfo).IsAssignableFrom(objectType);
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

            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            int lineNumber = 0;
            int linePosition = 0;
            var jsonLineInfo = reader as IJsonLineInfo;
            if (jsonLineInfo != null && jsonLineInfo.HasLineInfo())
            {
                lineNumber = jsonLineInfo.LineNumber;
                linePosition = jsonLineInfo.LinePosition;
            }

            var lineInfoObject = Activator.CreateInstance(objectType) as JsonLineInfo;
            serializer.Populate(reader, lineInfoObject);

            lineInfoObject.LineNumber = lineNumber;
            lineInfoObject.LinePosition = linePosition;

            return lineInfoObject;
        }
    }
}
