// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Extensions;

    /// <summary>For Key Vault Key references</summary>
    public partial class KeyVaultProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IKeyVaultProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IKeyVaultPropertiesInternal
    {

        /// <summary>Backing field for <see cref="KeyName" /> property.</summary>
        private string _keyName;

        /// <summary>The Key Name in Key Vault</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string KeyName { get => this._keyName; set => this._keyName = value; }

        /// <summary>Backing field for <see cref="KeyVaultUri" /> property.</summary>
        private string _keyVaultUri;

        /// <summary>The Key Vault URI</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string KeyVaultUri { get => this._keyVaultUri; set => this._keyVaultUri = value; }

        /// <summary>Backing field for <see cref="KeyVersion" /> property.</summary>
        private string _keyVersion;

        /// <summary>The Key Version in Key Vault</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string KeyVersion { get => this._keyVersion; set => this._keyVersion = value; }

        /// <summary>Creates an new <see cref="KeyVaultProperties" /> instance.</summary>
        public KeyVaultProperties()
        {

        }
    }
    /// For Key Vault Key references
    public partial interface IKeyVaultProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.IJsonSerializable
    {
        /// <summary>The Key Name in Key Vault</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The Key Name in Key Vault",
        SerializedName = @"keyName",
        PossibleTypes = new [] { typeof(string) })]
        string KeyName { get; set; }
        /// <summary>The Key Vault URI</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"The Key Vault URI",
        SerializedName = @"keyVaultUri",
        PossibleTypes = new [] { typeof(string) })]
        string KeyVaultUri { get; set; }
        /// <summary>The Key Version in Key Vault</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The Key Version in Key Vault",
        SerializedName = @"keyVersion",
        PossibleTypes = new [] { typeof(string) })]
        string KeyVersion { get; set; }

    }
    /// For Key Vault Key references
    internal partial interface IKeyVaultPropertiesInternal

    {
        /// <summary>The Key Name in Key Vault</summary>
        string KeyName { get; set; }
        /// <summary>The Key Vault URI</summary>
        string KeyVaultUri { get; set; }
        /// <summary>The Key Version in Key Vault</summary>
        string KeyVersion { get; set; }

    }
}