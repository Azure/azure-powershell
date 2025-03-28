// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Extensions;

    /// <summary>Mapping of data connector credentials.</summary>
    public partial class DataConnectorCredentialMap :
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataConnectorCredentialMap,
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataConnectorCredentialMapInternal
    {

        /// <summary>Backing field for <see cref="Key" /> property.</summary>
        private string _key;

        /// <summary>The key representing the credential.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Owned)]
        public string Key { get => this._key; set => this._key = value; }

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataConnectorCredentials Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataConnectorCredentialMapInternal.Value { get => (this._value = this._value ?? new Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.DataConnectorCredentials()); set { {_value = value;} } }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataConnectorCredentials _value;

        /// <summary>The data connector credential value.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataConnectorCredentials Value { get => (this._value = this._value ?? new Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.DataConnectorCredentials()); set => this._value = value; }

        /// <summary>
        /// Client Id associated with the provider, if type of credentials is OAuthClientCredentials.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inlined)]
        public string ValueClientId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataConnectorCredentialsInternal)Value).ClientId; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataConnectorCredentialsInternal)Value).ClientId = value ?? null; }

        /// <summary>Name of the key vault key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inlined)]
        public string ValueKeyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataConnectorCredentialsInternal)Value).KeyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataConnectorCredentialsInternal)Value).KeyName = value ?? null; }

        /// <summary>Uri of the key vault</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inlined)]
        public string ValueKeyVaultUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataConnectorCredentialsInternal)Value).KeyVaultUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataConnectorCredentialsInternal)Value).KeyVaultUri = value ?? null; }

        /// <summary>Version of the key vault key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inlined)]
        public string ValueKeyVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataConnectorCredentialsInternal)Value).KeyVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataConnectorCredentialsInternal)Value).KeyVersion = value ?? null; }

        /// <summary>Type of credential.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inlined)]
        public string ValueKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataConnectorCredentialsInternal)Value).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataConnectorCredentialsInternal)Value).Kind = value ?? null; }

        /// <summary>Creates an new <see cref="DataConnectorCredentialMap" /> instance.</summary>
        public DataConnectorCredentialMap()
        {

        }
    }
    /// Mapping of data connector credentials.
    public partial interface IDataConnectorCredentialMap :
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.IJsonSerializable
    {
        /// <summary>The key representing the credential.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The key representing the credential.",
        SerializedName = @"key",
        PossibleTypes = new [] { typeof(string) })]
        string Key { get; set; }
        /// <summary>
        /// Client Id associated with the provider, if type of credentials is OAuthClientCredentials.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Client Id associated with the provider, if type of credentials is OAuthClientCredentials.",
        SerializedName = @"clientId",
        PossibleTypes = new [] { typeof(string) })]
        string ValueClientId { get; set; }
        /// <summary>Name of the key vault key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Name of the key vault key.",
        SerializedName = @"keyName",
        PossibleTypes = new [] { typeof(string) })]
        string ValueKeyName { get; set; }
        /// <summary>Uri of the key vault</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Uri of the key vault",
        SerializedName = @"keyVaultUri",
        PossibleTypes = new [] { typeof(string) })]
        string ValueKeyVaultUri { get; set; }
        /// <summary>Version of the key vault key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Version of the key vault key.",
        SerializedName = @"keyVersion",
        PossibleTypes = new [] { typeof(string) })]
        string ValueKeyVersion { get; set; }
        /// <summary>Type of credential.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Type of credential.",
        SerializedName = @"kind",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PSArgumentCompleterAttribute("OAuthClientCredentials", "ApiKeyAuthCredentials")]
        string ValueKind { get; set; }

    }
    /// Mapping of data connector credentials.
    internal partial interface IDataConnectorCredentialMapInternal

    {
        /// <summary>The key representing the credential.</summary>
        string Key { get; set; }
        /// <summary>The data connector credential value.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataConnectorCredentials Value { get; set; }
        /// <summary>
        /// Client Id associated with the provider, if type of credentials is OAuthClientCredentials.
        /// </summary>
        string ValueClientId { get; set; }
        /// <summary>Name of the key vault key.</summary>
        string ValueKeyName { get; set; }
        /// <summary>Uri of the key vault</summary>
        string ValueKeyVaultUri { get; set; }
        /// <summary>Version of the key vault key.</summary>
        string ValueKeyVersion { get; set; }
        /// <summary>Type of credential.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PSArgumentCompleterAttribute("OAuthClientCredentials", "ApiKeyAuthCredentials")]
        string ValueKind { get; set; }

    }
}