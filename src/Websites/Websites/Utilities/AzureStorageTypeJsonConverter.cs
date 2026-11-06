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

using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;
using System;

namespace Microsoft.Azure.Commands.WebApps.Utilities
{
    /// <summary>
    /// The service can return azureStorageAccounts.*.type values, such as "FileShare", that are not
    /// present in the Microsoft.Azure.Management.WebSites.Models.AzureStorageType enum. Since that enum is
    /// decorated with a type-level StringEnumConverter, deserialization otherwise throws for any unknown
    /// value instead of leaving the property unset. This converter tolerates unrecognized values by
    /// returning null rather than failing the whole response deserialization (see GitHub issue #29979).
    /// </summary>
    public class AzureStorageTypeJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (Nullable.GetUnderlyingType(objectType) ?? objectType) == typeof(AzureStorageType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            string value = reader.Value?.ToString();
            AzureStorageType result;
            if (!string.IsNullOrEmpty(value) && Enum.TryParse(value, ignoreCase: true, result: out result))
            {
                return result;
            }

            // Unknown/unsupported storage type value (e.g. "FileShare"); leave it unset instead of throwing.
            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // This converter is only registered on DeserializationSettings; serialization of AzureStorageType
            // should continue to go through the SDK's own StringEnumConverter attribute.
            new Newtonsoft.Json.Converters.StringEnumConverter().WriteJson(writer, value, serializer);
        }
    }

    /// <summary>
    /// Contract resolver that ignores the type-level [JsonConverter(typeof(StringEnumConverter))] attribute on
    /// AzureStorageType so that the lenient <see cref="AzureStorageTypeJsonConverter"/> registered on
    /// JsonSerializerSettings.Converters can be used instead. Without this, the attribute-level converter always
    /// takes precedence and unrecognized enum values would still cause a SerializationException. This extends
    /// ReadOnlyJsonContractResolver (the resolver used by the generated WebSiteManagementClient by default) so
    /// that its existing read-only property handling is preserved.
    /// </summary>
    public class AzureStorageTypeContractResolver : ReadOnlyJsonContractResolver
    {
        protected override JsonConverter ResolveContractConverter(Type objectType)
        {
            if (objectType == typeof(AzureStorageType))
            {
                return null;
            }

            return base.ResolveContractConverter(objectType);
        }
    }
}
