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

using System.Collections.Generic;
using System.Runtime.Serialization;
using Microsoft.Azure.Commands.KeyVault.WebKey;
using Microsoft.Azure.Commands.KeyVault.WebKey.Json;
using Newtonsoft.Json;
using System.Security;

namespace Microsoft.Azure.Commands.KeyVault.Client.Protocol
{
    public static class MessagePropertyNames
    {
        public const string Algorithm    = "alg";
        public const string Attributes   = "attributes";
        public const string Digest       = "digest";
        public const string Hsm          = "hsm";
        public const string Key          = "key";
        public const string KeySize      = "key_size";
        public const string KeyOps       = "key_ops";
        public const string Kid          = "kid";
        public const string Kty          = "kty";
        public const string Value        = "value";
        public const string Id           = "id";
    }

    #region Error Response Messages

    [JsonObject]
    public class Error
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, 
            NullValueHandling = NullValueHandling.Ignore, PropertyName = "code", Required = Required.Default)]
        public string Code { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, 
            NullValueHandling = NullValueHandling.Ignore, PropertyName = "message", Required = Required.Default)]
        public string Message { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalInfo { get; set; }
    }

    [JsonObject]
    public class ErrorResponseMessage
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, 
            NullValueHandling = NullValueHandling.Ignore, PropertyName = "error", Required = Required.Default)]
        public Error Error { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalInfo { get; set; }
    }

    #endregion

    #region Key Management Messages
    [JsonObject]
    public class GetKeyResponseMessage
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, 
            NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.Key, Required = Required.Always)]
        public JsonWebKey Key { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, 
            NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.Attributes, Required = Required.Always)]
        public KeyAttributes Attributes { get; set; }
    }

    [JsonObject]
    public class BackupKeyResponseMessage
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, 
            NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.Value, Required = Required.Always)]
        [JsonConverter(typeof(Base64UrlConverter))]
        public byte[] Value { get; set; }
    }

    [JsonObject]
    public class CreateKeyRequestMessage
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, 
            NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.Kty, Required = Required.Always)]
        public string Kty { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, 
            NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.KeySize, Required = Required.Default)]
        public int? KeySize { get; set; }

        /// <summary>
        /// Supported Key Operations
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, 
            NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.KeyOps, Required = Required.Default)]
        public string[] KeyOps { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, 
            NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.Attributes, Required = Required.Default)]
        public KeyAttributes Attributes { get; set; }
    }

    [JsonObject]
    public class ImportKeyRequestMessage
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, 
            NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.Key, Required = Required.Always)]
        public JsonWebKey Key { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, 
            NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.Attributes, Required = Required.Always)]
        public KeyAttributes Attributes { get; set; }

        /// <summary>
        /// Is this key protected by an HSM?
        /// </summary>
        /// <remarks>This attribute is only meaningul at IMPORT requests. In future versions, it may be removed from this structure.</remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, 
            NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.Hsm, Required = Required.Default)]
        public bool? Hsm { get; set; }
    }

    [JsonObject]
    public class RestoreKeyRequestMessage
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, 
            NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.Value, Required = Required.Always)]
        [JsonConverter(typeof(Base64UrlConverter))]
        public byte[] Value { get; set; }
    }

    [JsonObject]
    public class UpdateKeyRequestMessage
    {
        /// <summary>
        /// Supported Key Operations
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, 
            NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.KeyOps, Required = Required.Default)]
        public string[] KeyOps { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, 
            NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.Attributes, Required = Required.Always)]
        public KeyAttributes Attributes { get; set; }
    }

    [JsonObject]
    public class DeleteKeyRequestMessage
    {
        // Since DELETE is a POST operation, it must have a body.
        // But so far there is no field.
    }

    #endregion

    [JsonObject]
    public class SecretRequestMessage
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, 
            NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.Value, Required = Required.Always)]
        [JsonConverter(typeof(SecureStringConverter))]
        public SecureString Value { get; set; }
    }

    [JsonObject]
    public class SecretResponseMessage
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, 
            NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.Value, Required = Required.Always)]
        [JsonConverter(typeof(SecureStringConverter))]
        public SecureString Value { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, 
            NullValueHandling = NullValueHandling.Ignore, PropertyName = MessagePropertyNames.Id, Required = Required.Default)]
        public string Id { get; set; }
    }
}