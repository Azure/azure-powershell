// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Data encryption properties of a server.</summary>
    public partial class DataEncryption :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDataEncryption,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDataEncryptionInternal
    {

        /// <summary>Backing field for <see cref="GeoBackupEncryptionKeyStatus" /> property.</summary>
        private string _geoBackupEncryptionKeyStatus;

        /// <summary>
        /// Status of key used by a server configured with data encryption based on customer managed key, to encrypt the geographically
        /// redundant storage associated to the server when it is configured to support geographically redundant backups.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string GeoBackupEncryptionKeyStatus { get => this._geoBackupEncryptionKeyStatus; }

        /// <summary>Backing field for <see cref="GeoBackupKeyUri" /> property.</summary>
        private string _geoBackupKeyUri;

        /// <summary>
        /// Identifier of the user assigned managed identity used to access the key in Azure Key Vault for data encryption of the
        /// geographically redundant storage associated to a server that is configured to support geographically redundant backups.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string GeoBackupKeyUri { get => this._geoBackupKeyUri; set => this._geoBackupKeyUri = value; }

        /// <summary>Backing field for <see cref="GeoBackupUserAssignedIdentityId" /> property.</summary>
        private string _geoBackupUserAssignedIdentityId;

        /// <summary>
        /// Identifier of the user assigned managed identity used to access the key in Azure Key Vault for data encryption of the
        /// geographically redundant storage associated to a server that is configured to support geographically redundant backups.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string GeoBackupUserAssignedIdentityId { get => this._geoBackupUserAssignedIdentityId; set => this._geoBackupUserAssignedIdentityId = value; }

        /// <summary>Internal Acessors for GeoBackupEncryptionKeyStatus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDataEncryptionInternal.GeoBackupEncryptionKeyStatus { get => this._geoBackupEncryptionKeyStatus; set { {_geoBackupEncryptionKeyStatus = value;} } }

        /// <summary>Internal Acessors for PrimaryEncryptionKeyStatus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDataEncryptionInternal.PrimaryEncryptionKeyStatus { get => this._primaryEncryptionKeyStatus; set { {_primaryEncryptionKeyStatus = value;} } }

        /// <summary>Backing field for <see cref="PrimaryEncryptionKeyStatus" /> property.</summary>
        private string _primaryEncryptionKeyStatus;

        /// <summary>
        /// Status of key used by a server configured with data encryption based on customer managed key, to encrypt the primary storage
        /// associated to the server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string PrimaryEncryptionKeyStatus { get => this._primaryEncryptionKeyStatus; }

        /// <summary>Backing field for <see cref="PrimaryKeyUri" /> property.</summary>
        private string _primaryKeyUri;

        /// <summary>
        /// URI of the key in Azure Key Vault used for data encryption of the primary storage associated to a server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string PrimaryKeyUri { get => this._primaryKeyUri; set => this._primaryKeyUri = value; }

        /// <summary>Backing field for <see cref="PrimaryUserAssignedIdentityId" /> property.</summary>
        private string _primaryUserAssignedIdentityId;

        /// <summary>
        /// Identifier of the user assigned managed identity used to access the key in Azure Key Vault for data encryption of the
        /// primary storage associated to a server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string PrimaryUserAssignedIdentityId { get => this._primaryUserAssignedIdentityId; set => this._primaryUserAssignedIdentityId = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Data encryption type used by a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="DataEncryption" /> instance.</summary>
        public DataEncryption()
        {

        }
    }
    /// Data encryption properties of a server.
    public partial interface IDataEncryption :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Status of key used by a server configured with data encryption based on customer managed key, to encrypt the geographically
        /// redundant storage associated to the server when it is configured to support geographically redundant backups.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Status of key used by a server configured with data encryption based on customer managed key, to encrypt the geographically redundant storage associated to the server when it is configured to support geographically redundant backups.",
        SerializedName = @"geoBackupEncryptionKeyStatus",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Valid", "Invalid")]
        string GeoBackupEncryptionKeyStatus { get;  }
        /// <summary>
        /// Identifier of the user assigned managed identity used to access the key in Azure Key Vault for data encryption of the
        /// geographically redundant storage associated to a server that is configured to support geographically redundant backups.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Identifier of the user assigned managed identity used to access the key in Azure Key Vault for data encryption of the geographically redundant storage associated to a server that is configured to support geographically redundant backups.",
        SerializedName = @"geoBackupKeyURI",
        PossibleTypes = new [] { typeof(string) })]
        string GeoBackupKeyUri { get; set; }
        /// <summary>
        /// Identifier of the user assigned managed identity used to access the key in Azure Key Vault for data encryption of the
        /// geographically redundant storage associated to a server that is configured to support geographically redundant backups.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Identifier of the user assigned managed identity used to access the key in Azure Key Vault for data encryption of the geographically redundant storage associated to a server that is configured to support geographically redundant backups.",
        SerializedName = @"geoBackupUserAssignedIdentityId",
        PossibleTypes = new [] { typeof(string) })]
        string GeoBackupUserAssignedIdentityId { get; set; }
        /// <summary>
        /// Status of key used by a server configured with data encryption based on customer managed key, to encrypt the primary storage
        /// associated to the server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Status of key used by a server configured with data encryption based on customer managed key, to encrypt the primary storage associated to the server.",
        SerializedName = @"primaryEncryptionKeyStatus",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Valid", "Invalid")]
        string PrimaryEncryptionKeyStatus { get;  }
        /// <summary>
        /// URI of the key in Azure Key Vault used for data encryption of the primary storage associated to a server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"URI of the key in Azure Key Vault used for data encryption of the primary storage associated to a server.",
        SerializedName = @"primaryKeyURI",
        PossibleTypes = new [] { typeof(string) })]
        string PrimaryKeyUri { get; set; }
        /// <summary>
        /// Identifier of the user assigned managed identity used to access the key in Azure Key Vault for data encryption of the
        /// primary storage associated to a server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Identifier of the user assigned managed identity used to access the key in Azure Key Vault for data encryption of the primary storage associated to a server.",
        SerializedName = @"primaryUserAssignedIdentityId",
        PossibleTypes = new [] { typeof(string) })]
        string PrimaryUserAssignedIdentityId { get; set; }
        /// <summary>Data encryption type used by a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Data encryption type used by a server.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("SystemManaged", "AzureKeyVault")]
        string Type { get; set; }

    }
    /// Data encryption properties of a server.
    internal partial interface IDataEncryptionInternal

    {
        /// <summary>
        /// Status of key used by a server configured with data encryption based on customer managed key, to encrypt the geographically
        /// redundant storage associated to the server when it is configured to support geographically redundant backups.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Valid", "Invalid")]
        string GeoBackupEncryptionKeyStatus { get; set; }
        /// <summary>
        /// Identifier of the user assigned managed identity used to access the key in Azure Key Vault for data encryption of the
        /// geographically redundant storage associated to a server that is configured to support geographically redundant backups.
        /// </summary>
        string GeoBackupKeyUri { get; set; }
        /// <summary>
        /// Identifier of the user assigned managed identity used to access the key in Azure Key Vault for data encryption of the
        /// geographically redundant storage associated to a server that is configured to support geographically redundant backups.
        /// </summary>
        string GeoBackupUserAssignedIdentityId { get; set; }
        /// <summary>
        /// Status of key used by a server configured with data encryption based on customer managed key, to encrypt the primary storage
        /// associated to the server.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Valid", "Invalid")]
        string PrimaryEncryptionKeyStatus { get; set; }
        /// <summary>
        /// URI of the key in Azure Key Vault used for data encryption of the primary storage associated to a server.
        /// </summary>
        string PrimaryKeyUri { get; set; }
        /// <summary>
        /// Identifier of the user assigned managed identity used to access the key in Azure Key Vault for data encryption of the
        /// primary storage associated to a server.
        /// </summary>
        string PrimaryUserAssignedIdentityId { get; set; }
        /// <summary>Data encryption type used by a server.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("SystemManaged", "AzureKeyVault")]
        string Type { get; set; }

    }
}