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

using Microsoft.Azure.PowerShell.Tools.AzPredictor.Utilities.Converters;
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
        /// <summary>
        /// The default serialization options:
        /// 1. Use camel case in the naming.
        /// 2. Use string instead of number for enums.
        /// 3. Use the string values (camel case) for enum.
        /// 4. Use the string values for the type <see cref="System.Version"/> in the properties and <see cref="System.Collections.Generic.IDictionary&lt;TKey, TValue>"/> keys.
        /// 5. Skip the property if the value is null.
        /// </summary>
        public static readonly JsonSerializerOptions DefaultSerializerOptions = new JsonSerializerOptions()
        {
            Converters =
            {
                new JsonStringEnumConverter(JsonNamingPolicy.CamelCase),
                new VersionConverter(),
                new DictionaryTKeyVersionTValueConverter()
            },
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
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
