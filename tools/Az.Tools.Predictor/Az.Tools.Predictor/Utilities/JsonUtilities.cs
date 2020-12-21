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
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor.Utilities
{
    /// <summary>
    /// A utility class for json serialization/deserialization.
    /// </summary>
    internal static class JsonUtilities
    {
        private sealed class VersionConverter : JsonConverter<Version>
        {
            public override Version Read (ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (Version.TryParse(reader.GetString(), out var version))
                {
                    return version;
                }

                throw new JsonException();
            }

            public override void Write (Utf8JsonWriter writer, Version value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value.ToString());
            }
        }

        /// <summary>
        /// The default serialization options:
        /// 1. Use camel case in the naming.
        /// 2. Use string instead of number for enums.
        /// </summary>
        public static readonly JsonSerializerOptions DefaultSerializerOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters =
            {
                new JsonStringEnumConverter(JsonNamingPolicy.CamelCase),
                new VersionConverter(),
            },
        };

        /// <summary>
        /// The serialization options for sending the telemetry.
        /// </summary>
        /// <remarks>
        /// The options are based on <see cref="DefaultSerializerOptions"/> except:
        /// 1. Uses <see cref="JavaScriptEncoder.UnsafeRelaxedJsonEscaping"/> The result is treated as a string in the
        ///    telemetry and we don't want to use the default encoder which escape characters such as ', ", &lt;, &gt;, +.
        /// </remarks>
        public static readonly JsonSerializerOptions TelemetrySerializerOptions = new JsonSerializerOptions(JsonUtilities.DefaultSerializerOptions)
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        };
    }
}
