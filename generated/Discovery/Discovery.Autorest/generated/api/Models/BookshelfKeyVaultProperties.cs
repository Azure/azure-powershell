// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Extensions;

    /// <summary>Key Vault Properties with clientId selection</summary>
    public partial class BookshelfKeyVaultProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfKeyVaultProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfKeyVaultPropertiesInternal
    {

        /// <summary>Backing field for <see cref="IdentityClientId" /> property.</summary>
        private string _identityClientId;

        /// <summary>
        /// The client ID of the identity to use for accessing the Key Vault. Must be a workload identity assigned to the Bookshelf
        /// resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string IdentityClientId { get => this._identityClientId; set => this._identityClientId = value; }

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

        /// <summary>Creates an new <see cref="BookshelfKeyVaultProperties" /> instance.</summary>
        public BookshelfKeyVaultProperties()
        {

        }
    }
    /// Key Vault Properties with clientId selection
    public partial interface IBookshelfKeyVaultProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The client ID of the identity to use for accessing the Key Vault. Must be a workload identity assigned to the Bookshelf
        /// resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"The client ID of the identity to use for accessing the Key Vault. Must be a workload identity assigned to the Bookshelf resource.",
        SerializedName = @"identityClientId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityClientId { get; set; }
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
    /// Key Vault Properties with clientId selection
    internal partial interface IBookshelfKeyVaultPropertiesInternal

    {
        /// <summary>
        /// The client ID of the identity to use for accessing the Key Vault. Must be a workload identity assigned to the Bookshelf
        /// resource.
        /// </summary>
        string IdentityClientId { get; set; }
        /// <summary>The Key Name in Key Vault</summary>
        string KeyName { get; set; }
        /// <summary>The Key Vault URI</summary>
        string KeyVaultUri { get; set; }
        /// <summary>The Key Version in Key Vault</summary>
        string KeyVersion { get; set; }

    }
}