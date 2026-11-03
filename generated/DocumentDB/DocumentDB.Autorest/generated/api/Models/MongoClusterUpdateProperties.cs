// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Extensions;

    /// <summary>The updatable properties of the MongoCluster.</summary>
    public partial class MongoClusterUpdateProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdateProperties,
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal
    {

        /// <summary>Backing field for <see cref="Administrator" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IAdministratorProperties _administrator;

        /// <summary>The local administrator properties for the mongo cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IAdministratorProperties Administrator { get => (this._administrator = this._administrator ?? new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.AdministratorProperties()); set => this._administrator = value; }

        /// <summary>The administrator password.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public System.Security.SecureString AdministratorPassword { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IAdministratorPropertiesInternal)Administrator).Password; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IAdministratorPropertiesInternal)Administrator).Password = value ?? null; }

        /// <summary>The administrator user name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string AdministratorUserName { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IAdministratorPropertiesInternal)Administrator).UserName; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IAdministratorPropertiesInternal)Administrator).UserName = value ?? null; }

        /// <summary>Backing field for <see cref="AuthConfig" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IAuthConfigProperties _authConfig;

        /// <summary>The authentication configuration for the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IAuthConfigProperties AuthConfig { get => (this._authConfig = this._authConfig ?? new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.AuthConfigProperties()); set => this._authConfig = value; }

        /// <summary>Allowed authentication modes for data access on the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<string> AuthConfigAllowedMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IAuthConfigPropertiesInternal)AuthConfig).AllowedMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IAuthConfigPropertiesInternal)AuthConfig).AllowedMode = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="Backup" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IBackupProperties _backup;

        /// <summary>The backup properties of the mongo cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IBackupProperties Backup { get => (this._backup = this._backup ?? new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.BackupProperties()); set => this._backup = value; }

        /// <summary>Earliest restore timestamp in UTC ISO8601 format.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string BackupEarliestRestoreTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IBackupPropertiesInternal)Backup).EarliestRestoreTime; }

        /// <summary>Backing field for <see cref="Compute" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IComputeProperties _compute;

        /// <summary>The compute properties of the mongo cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IComputeProperties Compute { get => (this._compute = this._compute ?? new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ComputeProperties()); set => this._compute = value; }

        /// <summary>
        /// The compute tier to assign to the cluster, where each tier maps to a virtual-core and memory size. Example values: 'M30',
        /// 'M40'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string ComputeTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IComputePropertiesInternal)Compute).Tier; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IComputePropertiesInternal)Compute).Tier = value ?? null; }

        /// <summary>The URI of the key vault key used for encryption.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string CustomerManagedKeyEncryptionKeyUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IEncryptionPropertiesInternal)Encryption).CustomerManagedKeyEncryptionKeyUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IEncryptionPropertiesInternal)Encryption).CustomerManagedKeyEncryptionKeyUrl = value ?? null; }

        /// <summary>Backing field for <see cref="DataApi" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IDataApiProperties _dataApi;

        /// <summary>The Data API properties of the mongo cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IDataApiProperties DataApi { get => (this._dataApi = this._dataApi ?? new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.DataApiProperties()); set => this._dataApi = value; }

        /// <summary>The mode to indicate whether the Mongo Data API is enabled for a cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string DataApiMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IDataApiPropertiesInternal)DataApi).Mode; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IDataApiPropertiesInternal)DataApi).Mode = value ?? null; }

        /// <summary>Backing field for <see cref="Encryption" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IEncryptionProperties _encryption;

        /// <summary>
        /// The encryption configuration for the cluster. Depends on identity being configured.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IEncryptionProperties Encryption { get => (this._encryption = this._encryption ?? new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.EncryptionProperties()); set => this._encryption = value; }

        /// <summary>Backing field for <see cref="HighAvailability" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IHighAvailabilityProperties _highAvailability;

        /// <summary>The high availability properties of the mongo cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IHighAvailabilityProperties HighAvailability { get => (this._highAvailability = this._highAvailability ?? new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.HighAvailabilityProperties()); set => this._highAvailability = value; }

        /// <summary>The target high availability mode requested for the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string HighAvailabilityTargetMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IHighAvailabilityPropertiesInternal)HighAvailability).TargetMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IHighAvailabilityPropertiesInternal)HighAvailability).TargetMode = value ?? null; }

        /// <summary>The type of identity. Only 'UserAssignedIdentity' is supported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string KeyEncryptionKeyIdentityType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IEncryptionPropertiesInternal)Encryption).KeyEncryptionKeyIdentityType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IEncryptionPropertiesInternal)Encryption).KeyEncryptionKeyIdentityType = value ?? null; }

        /// <summary>The user assigned identity resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string KeyEncryptionKeyIdentityUserAssignedIdentityResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IEncryptionPropertiesInternal)Encryption).KeyEncryptionKeyIdentityUserAssignedIdentityResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IEncryptionPropertiesInternal)Encryption).KeyEncryptionKeyIdentityUserAssignedIdentityResourceId = value ?? null; }

        /// <summary>Internal Acessors for Administrator</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IAdministratorProperties Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal.Administrator { get => (this._administrator = this._administrator ?? new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.AdministratorProperties()); set { {_administrator = value;} } }

        /// <summary>Internal Acessors for AuthConfig</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IAuthConfigProperties Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal.AuthConfig { get => (this._authConfig = this._authConfig ?? new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.AuthConfigProperties()); set { {_authConfig = value;} } }

        /// <summary>Internal Acessors for Backup</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IBackupProperties Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal.Backup { get => (this._backup = this._backup ?? new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.BackupProperties()); set { {_backup = value;} } }

        /// <summary>Internal Acessors for BackupEarliestRestoreTime</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal.BackupEarliestRestoreTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IBackupPropertiesInternal)Backup).EarliestRestoreTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IBackupPropertiesInternal)Backup).EarliestRestoreTime = value ?? null; }

        /// <summary>Internal Acessors for Compute</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IComputeProperties Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal.Compute { get => (this._compute = this._compute ?? new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ComputeProperties()); set { {_compute = value;} } }

        /// <summary>Internal Acessors for CustomerManagedKeyEncryptionKeyIdentity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IKeyEncryptionKeyIdentity Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal.CustomerManagedKeyEncryptionKeyIdentity { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IEncryptionPropertiesInternal)Encryption).CustomerManagedKeyEncryptionKeyIdentity; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IEncryptionPropertiesInternal)Encryption).CustomerManagedKeyEncryptionKeyIdentity = value ?? null /* model class */; }

        /// <summary>Internal Acessors for DataApi</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IDataApiProperties Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal.DataApi { get => (this._dataApi = this._dataApi ?? new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.DataApiProperties()); set { {_dataApi = value;} } }

        /// <summary>Internal Acessors for Encryption</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IEncryptionProperties Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal.Encryption { get => (this._encryption = this._encryption ?? new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.EncryptionProperties()); set { {_encryption = value;} } }

        /// <summary>Internal Acessors for EncryptionCustomerManagedKeyEncryption</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ICustomerManagedKeyEncryptionProperties Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal.EncryptionCustomerManagedKeyEncryption { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IEncryptionPropertiesInternal)Encryption).CustomerManagedKeyEncryption; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IEncryptionPropertiesInternal)Encryption).CustomerManagedKeyEncryption = value ?? null /* model class */; }

        /// <summary>Internal Acessors for HighAvailability</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IHighAvailabilityProperties Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal.HighAvailability { get => (this._highAvailability = this._highAvailability ?? new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.HighAvailabilityProperties()); set { {_highAvailability = value;} } }

        /// <summary>Internal Acessors for Sharding</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IShardingProperties Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal.Sharding { get => (this._sharding = this._sharding ?? new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ShardingProperties()); set { {_sharding = value;} } }

        /// <summary>Internal Acessors for Storage</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IStorageProperties Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal.Storage { get => (this._storage = this._storage ?? new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.StorageProperties()); set { {_storage = value;} } }

        /// <summary>Backing field for <see cref="NetworkBypassMode" /> property.</summary>
        private string _networkBypassMode;

        /// <summary>
        /// The network bypass mode for the cluster. Setting to 'AzureCosmosDB' allows Azure Cosmos DB service to bypass network restrictions.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        public string NetworkBypassMode { get => this._networkBypassMode; set => this._networkBypassMode = value; }

        /// <summary>Backing field for <see cref="PreviewFeature" /> property.</summary>
        private System.Collections.Generic.List<string> _previewFeature;

        /// <summary>List of private endpoint connections.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> PreviewFeature { get => this._previewFeature; set => this._previewFeature = value; }

        /// <summary>Backing field for <see cref="PublicNetworkAccess" /> property.</summary>
        private string _publicNetworkAccess;

        /// <summary>Whether or not public endpoint access is allowed for this mongo cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        public string PublicNetworkAccess { get => this._publicNetworkAccess; set => this._publicNetworkAccess = value; }

        /// <summary>Backing field for <see cref="ServerVersion" /> property.</summary>
        private string _serverVersion;

        /// <summary>
        /// The Mongo DB server version. Defaults to the latest available version if not specified.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        public string ServerVersion { get => this._serverVersion; set => this._serverVersion = value; }

        /// <summary>Backing field for <see cref="Sharding" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IShardingProperties _sharding;

        /// <summary>The sharding properties of the mongo cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IShardingProperties Sharding { get => (this._sharding = this._sharding ?? new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ShardingProperties()); set => this._sharding = value; }

        /// <summary>Number of shards to provision on the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public int? ShardingShardCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IShardingPropertiesInternal)Sharding).ShardCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IShardingPropertiesInternal)Sharding).ShardCount = value ?? default(int); }

        /// <summary>Backing field for <see cref="Storage" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IStorageProperties _storage;

        /// <summary>The storage properties of the mongo cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IStorageProperties Storage { get => (this._storage = this._storage ?? new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.StorageProperties()); set => this._storage = value; }

        /// <summary>The size of the data disk assigned to each server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public long? StorageSizeGb { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IStoragePropertiesInternal)Storage).SizeGb; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IStoragePropertiesInternal)Storage).SizeGb = value ?? default(long); }

        /// <summary>The type of storage to provision the cluster servers with.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string StorageType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IStoragePropertiesInternal)Storage).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IStoragePropertiesInternal)Storage).Type = value ?? null; }

        /// <summary>Creates an new <see cref="MongoClusterUpdateProperties" /> instance.</summary>
        public MongoClusterUpdateProperties()
        {

        }
    }
    /// The updatable properties of the MongoCluster.
    public partial interface IMongoClusterUpdateProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IJsonSerializable
    {
        /// <summary>The administrator password.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = false,
        Create = true,
        Update = true,
        Description = @"The administrator password.",
        SerializedName = @"password",
        PossibleTypes = new [] { typeof(System.Security.SecureString) })]
        System.Security.SecureString AdministratorPassword { get; set; }
        /// <summary>The administrator user name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The administrator user name.",
        SerializedName = @"userName",
        PossibleTypes = new [] { typeof(string) })]
        string AdministratorUserName { get; set; }
        /// <summary>Allowed authentication modes for data access on the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Allowed authentication modes for data access on the cluster.",
        SerializedName = @"allowedModes",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("NativeAuth", "MicrosoftEntraID")]
        System.Collections.Generic.List<string> AuthConfigAllowedMode { get; set; }
        /// <summary>Earliest restore timestamp in UTC ISO8601 format.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Earliest restore timestamp in UTC ISO8601 format.",
        SerializedName = @"earliestRestoreTime",
        PossibleTypes = new [] { typeof(string) })]
        string BackupEarliestRestoreTime { get;  }
        /// <summary>
        /// The compute tier to assign to the cluster, where each tier maps to a virtual-core and memory size. Example values: 'M30',
        /// 'M40'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The compute tier to assign to the cluster, where each tier maps to a virtual-core and memory size. Example values: 'M30', 'M40'.",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(string) })]
        string ComputeTier { get; set; }
        /// <summary>The URI of the key vault key used for encryption.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The URI of the key vault key used for encryption.",
        SerializedName = @"keyEncryptionKeyUrl",
        PossibleTypes = new [] { typeof(string) })]
        string CustomerManagedKeyEncryptionKeyUrl { get; set; }
        /// <summary>The mode to indicate whether the Mongo Data API is enabled for a cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The mode to indicate whether the Mongo Data API is enabled for a cluster.",
        SerializedName = @"mode",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string DataApiMode { get; set; }
        /// <summary>The target high availability mode requested for the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The target high availability mode requested for the cluster.",
        SerializedName = @"targetMode",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("Disabled", "SameZone", "ZoneRedundantPreferred")]
        string HighAvailabilityTargetMode { get; set; }
        /// <summary>The type of identity. Only 'UserAssignedIdentity' is supported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The type of identity. Only 'UserAssignedIdentity' is supported.",
        SerializedName = @"identityType",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("UserAssignedIdentity")]
        string KeyEncryptionKeyIdentityType { get; set; }
        /// <summary>The user assigned identity resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The user assigned identity resource id.",
        SerializedName = @"userAssignedIdentityResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string KeyEncryptionKeyIdentityUserAssignedIdentityResourceId { get; set; }
        /// <summary>
        /// The network bypass mode for the cluster. Setting to 'AzureCosmosDB' allows Azure Cosmos DB service to bypass network restrictions.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The network bypass mode for the cluster. Setting to 'AzureCosmosDB' allows Azure Cosmos DB service to bypass network restrictions.",
        SerializedName = @"networkBypassMode",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("None", "AzureCosmosDB")]
        string NetworkBypassMode { get; set; }
        /// <summary>List of private endpoint connections.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"List of private endpoint connections.",
        SerializedName = @"previewFeatures",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("GeoReplicas")]
        System.Collections.Generic.List<string> PreviewFeature { get; set; }
        /// <summary>Whether or not public endpoint access is allowed for this mongo cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Whether or not public endpoint access is allowed for this mongo cluster.",
        SerializedName = @"publicNetworkAccess",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string PublicNetworkAccess { get; set; }
        /// <summary>
        /// The Mongo DB server version. Defaults to the latest available version if not specified.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The Mongo DB server version. Defaults to the latest available version if not specified.",
        SerializedName = @"serverVersion",
        PossibleTypes = new [] { typeof(string) })]
        string ServerVersion { get; set; }
        /// <summary>Number of shards to provision on the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Number of shards to provision on the cluster.",
        SerializedName = @"shardCount",
        PossibleTypes = new [] { typeof(int) })]
        int? ShardingShardCount { get; set; }
        /// <summary>The size of the data disk assigned to each server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The size of the data disk assigned to each server.",
        SerializedName = @"sizeGb",
        PossibleTypes = new [] { typeof(long) })]
        long? StorageSizeGb { get; set; }
        /// <summary>The type of storage to provision the cluster servers with.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The type of storage to provision the cluster servers with.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("PremiumSSD", "PremiumSSDv2")]
        string StorageType { get; set; }

    }
    /// The updatable properties of the MongoCluster.
    internal partial interface IMongoClusterUpdatePropertiesInternal

    {
        /// <summary>The local administrator properties for the mongo cluster.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IAdministratorProperties Administrator { get; set; }
        /// <summary>The administrator password.</summary>
        System.Security.SecureString AdministratorPassword { get; set; }
        /// <summary>The administrator user name.</summary>
        string AdministratorUserName { get; set; }
        /// <summary>The authentication configuration for the cluster.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IAuthConfigProperties AuthConfig { get; set; }
        /// <summary>Allowed authentication modes for data access on the cluster.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("NativeAuth", "MicrosoftEntraID")]
        System.Collections.Generic.List<string> AuthConfigAllowedMode { get; set; }
        /// <summary>The backup properties of the mongo cluster.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IBackupProperties Backup { get; set; }
        /// <summary>Earliest restore timestamp in UTC ISO8601 format.</summary>
        string BackupEarliestRestoreTime { get; set; }
        /// <summary>The compute properties of the mongo cluster.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IComputeProperties Compute { get; set; }
        /// <summary>
        /// The compute tier to assign to the cluster, where each tier maps to a virtual-core and memory size. Example values: 'M30',
        /// 'M40'.
        /// </summary>
        string ComputeTier { get; set; }
        /// <summary>The identity used to access the key encryption key.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IKeyEncryptionKeyIdentity CustomerManagedKeyEncryptionKeyIdentity { get; set; }
        /// <summary>The URI of the key vault key used for encryption.</summary>
        string CustomerManagedKeyEncryptionKeyUrl { get; set; }
        /// <summary>The Data API properties of the mongo cluster.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IDataApiProperties DataApi { get; set; }
        /// <summary>The mode to indicate whether the Mongo Data API is enabled for a cluster.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string DataApiMode { get; set; }
        /// <summary>
        /// The encryption configuration for the cluster. Depends on identity being configured.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IEncryptionProperties Encryption { get; set; }
        /// <summary>Customer managed key encryption settings.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ICustomerManagedKeyEncryptionProperties EncryptionCustomerManagedKeyEncryption { get; set; }
        /// <summary>The high availability properties of the mongo cluster.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IHighAvailabilityProperties HighAvailability { get; set; }
        /// <summary>The target high availability mode requested for the cluster.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("Disabled", "SameZone", "ZoneRedundantPreferred")]
        string HighAvailabilityTargetMode { get; set; }
        /// <summary>The type of identity. Only 'UserAssignedIdentity' is supported.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("UserAssignedIdentity")]
        string KeyEncryptionKeyIdentityType { get; set; }
        /// <summary>The user assigned identity resource id.</summary>
        string KeyEncryptionKeyIdentityUserAssignedIdentityResourceId { get; set; }
        /// <summary>
        /// The network bypass mode for the cluster. Setting to 'AzureCosmosDB' allows Azure Cosmos DB service to bypass network restrictions.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("None", "AzureCosmosDB")]
        string NetworkBypassMode { get; set; }
        /// <summary>List of private endpoint connections.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("GeoReplicas")]
        System.Collections.Generic.List<string> PreviewFeature { get; set; }
        /// <summary>Whether or not public endpoint access is allowed for this mongo cluster.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string PublicNetworkAccess { get; set; }
        /// <summary>
        /// The Mongo DB server version. Defaults to the latest available version if not specified.
        /// </summary>
        string ServerVersion { get; set; }
        /// <summary>The sharding properties of the mongo cluster.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IShardingProperties Sharding { get; set; }
        /// <summary>Number of shards to provision on the cluster.</summary>
        int? ShardingShardCount { get; set; }
        /// <summary>The storage properties of the mongo cluster.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IStorageProperties Storage { get; set; }
        /// <summary>The size of the data disk assigned to each server.</summary>
        long? StorageSizeGb { get; set; }
        /// <summary>The type of storage to provision the cluster servers with.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("PremiumSSD", "PremiumSSDv2")]
        string StorageType { get; set; }

    }
}