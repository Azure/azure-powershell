// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Extensions;

    /// <summary>The type used for update operations of the MongoCluster.</summary>
    public partial class MongoClusterUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdate,
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdateInternal
    {

        /// <summary>The administrator password.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public System.Security.SecureString AdministratorPassword { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).AdministratorPassword; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).AdministratorPassword = value ?? null; }

        /// <summary>The administrator user name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string AdministratorUserName { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).AdministratorUserName; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).AdministratorUserName = value ?? null; }

        /// <summary>Allowed authentication modes for data access on the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<string> AuthConfigAllowedMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).AuthConfigAllowedMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).AuthConfigAllowedMode = value ?? null /* arrayOf */; }

        /// <summary>Earliest restore timestamp in UTC ISO8601 format.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string BackupEarliestRestoreTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).BackupEarliestRestoreTime; }

        /// <summary>
        /// The compute tier to assign to the cluster, where each tier maps to a virtual-core and memory size. Example values: 'M30',
        /// 'M40'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string ComputeTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).ComputeTier; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).ComputeTier = value ?? null; }

        /// <summary>The URI of the key vault key used for encryption.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string CustomerManagedKeyEncryptionKeyUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).CustomerManagedKeyEncryptionKeyUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).CustomerManagedKeyEncryptionKeyUrl = value ?? null; }

        /// <summary>The mode to indicate whether the Mongo Data API is enabled for a cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string DataApiMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).DataApiMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).DataApiMode = value ?? null; }

        /// <summary>The target high availability mode requested for the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string HighAvailabilityTargetMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).HighAvailabilityTargetMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).HighAvailabilityTargetMode = value ?? null; }

        /// <summary>Backing field for <see cref="Identity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IManagedServiceIdentity _identity;

        /// <summary>The managed service identities assigned to this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IManagedServiceIdentity Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ManagedServiceIdentity()); set => this._identity = value; }

        /// <summary>
        /// The service principal ID of the system assigned identity. This property will only be provided for a system assigned identity.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IManagedServiceIdentityInternal)Identity).PrincipalId; }

        /// <summary>
        /// The tenant ID of the system assigned identity. This property will only be provided for a system assigned identity.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IManagedServiceIdentityInternal)Identity).TenantId; }

        /// <summary>The type of managed identity assigned to this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string IdentityType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IManagedServiceIdentityInternal)Identity).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IManagedServiceIdentityInternal)Identity).Type = value ?? null; }

        /// <summary>The identities assigned to this resource by the user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IManagedServiceIdentityUserAssignedIdentities IdentityUserAssignedIdentity { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IManagedServiceIdentityInternal)Identity).UserAssignedIdentity; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IManagedServiceIdentityInternal)Identity).UserAssignedIdentity = value ?? null /* model class */; }

        /// <summary>The type of identity. Only 'UserAssignedIdentity' is supported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string KeyEncryptionKeyIdentityType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).KeyEncryptionKeyIdentityType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).KeyEncryptionKeyIdentityType = value ?? null; }

        /// <summary>The user assigned identity resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string KeyEncryptionKeyIdentityUserAssignedIdentityResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).KeyEncryptionKeyIdentityUserAssignedIdentityResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).KeyEncryptionKeyIdentityUserAssignedIdentityResourceId = value ?? null; }

        /// <summary>Internal Acessors for Administrator</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IAdministratorProperties Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdateInternal.Administrator { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).Administrator; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).Administrator = value ?? null /* model class */; }

        /// <summary>Internal Acessors for AuthConfig</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IAuthConfigProperties Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdateInternal.AuthConfig { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).AuthConfig; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).AuthConfig = value ?? null /* model class */; }

        /// <summary>Internal Acessors for Backup</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IBackupProperties Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdateInternal.Backup { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).Backup; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).Backup = value ?? null /* model class */; }

        /// <summary>Internal Acessors for BackupEarliestRestoreTime</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdateInternal.BackupEarliestRestoreTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).BackupEarliestRestoreTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).BackupEarliestRestoreTime = value ?? null; }

        /// <summary>Internal Acessors for Compute</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IComputeProperties Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdateInternal.Compute { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).Compute; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).Compute = value ?? null /* model class */; }

        /// <summary>Internal Acessors for CustomerManagedKeyEncryptionKeyIdentity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IKeyEncryptionKeyIdentity Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdateInternal.CustomerManagedKeyEncryptionKeyIdentity { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).CustomerManagedKeyEncryptionKeyIdentity; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).CustomerManagedKeyEncryptionKeyIdentity = value ?? null /* model class */; }

        /// <summary>Internal Acessors for DataApi</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IDataApiProperties Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdateInternal.DataApi { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).DataApi; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).DataApi = value ?? null /* model class */; }

        /// <summary>Internal Acessors for Encryption</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IEncryptionProperties Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdateInternal.Encryption { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).Encryption; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).Encryption = value ?? null /* model class */; }

        /// <summary>Internal Acessors for EncryptionCustomerManagedKeyEncryption</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ICustomerManagedKeyEncryptionProperties Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdateInternal.EncryptionCustomerManagedKeyEncryption { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).EncryptionCustomerManagedKeyEncryption; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).EncryptionCustomerManagedKeyEncryption = value ?? null /* model class */; }

        /// <summary>Internal Acessors for HighAvailability</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IHighAvailabilityProperties Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdateInternal.HighAvailability { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).HighAvailability; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).HighAvailability = value ?? null /* model class */; }

        /// <summary>Internal Acessors for Identity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IManagedServiceIdentity Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdateInternal.Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ManagedServiceIdentity()); set { {_identity = value;} } }

        /// <summary>Internal Acessors for IdentityPrincipalId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdateInternal.IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IManagedServiceIdentityInternal)Identity).PrincipalId; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IManagedServiceIdentityInternal)Identity).PrincipalId = value ?? null; }

        /// <summary>Internal Acessors for IdentityTenantId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdateInternal.IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IManagedServiceIdentityInternal)Identity).TenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IManagedServiceIdentityInternal)Identity).TenantId = value ?? null; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdateProperties Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdateInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.MongoClusterUpdateProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Sharding</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IShardingProperties Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdateInternal.Sharding { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).Sharding; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).Sharding = value ?? null /* model class */; }

        /// <summary>Internal Acessors for Storage</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IStorageProperties Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdateInternal.Storage { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).Storage; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).Storage = value ?? null /* model class */; }

        /// <summary>
        /// The network bypass mode for the cluster. Setting to 'AzureCosmosDB' allows Azure Cosmos DB service to bypass network restrictions.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string NetworkBypassMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).NetworkBypassMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).NetworkBypassMode = value ?? null; }

        /// <summary>List of private endpoint connections.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<string> PreviewFeature { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).PreviewFeature; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).PreviewFeature = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdateProperties _property;

        /// <summary>The resource-specific properties for this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdateProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.MongoClusterUpdateProperties()); set => this._property = value; }

        /// <summary>Whether or not public endpoint access is allowed for this mongo cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string PublicNetworkAccess { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).PublicNetworkAccess; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).PublicNetworkAccess = value ?? null; }

        /// <summary>
        /// The Mongo DB server version. Defaults to the latest available version if not specified.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string ServerVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).ServerVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).ServerVersion = value ?? null; }

        /// <summary>Number of shards to provision on the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public int? ShardingShardCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).ShardingShardCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).ShardingShardCount = value ?? default(int); }

        /// <summary>The size of the data disk assigned to each server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public long? StorageSizeGb { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).StorageSizeGb; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).StorageSizeGb = value ?? default(long); }

        /// <summary>The type of storage to provision the cluster servers with.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string StorageType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).StorageType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdatePropertiesInternal)Property).StorageType = value ?? null; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdateTags _tag;

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdateTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.MongoClusterUpdateTags()); set => this._tag = value; }

        /// <summary>Creates an new <see cref="MongoClusterUpdate" /> instance.</summary>
        public MongoClusterUpdate()
        {

        }
    }
    /// The type used for update operations of the MongoCluster.
    public partial interface IMongoClusterUpdate :
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
        /// <summary>
        /// The service principal ID of the system assigned identity. This property will only be provided for a system assigned identity.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The service principal ID of the system assigned identity. This property will only be provided for a system assigned identity.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityPrincipalId { get;  }
        /// <summary>
        /// The tenant ID of the system assigned identity. This property will only be provided for a system assigned identity.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The tenant ID of the system assigned identity. This property will only be provided for a system assigned identity.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityTenantId { get;  }
        /// <summary>The type of managed identity assigned to this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The type of managed identity assigned to this resource.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("None", "SystemAssigned", "UserAssigned", "SystemAssigned,UserAssigned")]
        string IdentityType { get; set; }
        /// <summary>The identities assigned to this resource by the user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The identities assigned to this resource by the user.",
        SerializedName = @"userAssignedIdentities",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IManagedServiceIdentityUserAssignedIdentities) })]
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IManagedServiceIdentityUserAssignedIdentities IdentityUserAssignedIdentity { get; set; }
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
        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Resource tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdateTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdateTags Tag { get; set; }

    }
    /// The type used for update operations of the MongoCluster.
    internal partial interface IMongoClusterUpdateInternal

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
        /// <summary>The managed service identities assigned to this resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IManagedServiceIdentity Identity { get; set; }
        /// <summary>
        /// The service principal ID of the system assigned identity. This property will only be provided for a system assigned identity.
        /// </summary>
        string IdentityPrincipalId { get; set; }
        /// <summary>
        /// The tenant ID of the system assigned identity. This property will only be provided for a system assigned identity.
        /// </summary>
        string IdentityTenantId { get; set; }
        /// <summary>The type of managed identity assigned to this resource.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("None", "SystemAssigned", "UserAssigned", "SystemAssigned,UserAssigned")]
        string IdentityType { get; set; }
        /// <summary>The identities assigned to this resource by the user.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IManagedServiceIdentityUserAssignedIdentities IdentityUserAssignedIdentity { get; set; }
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
        /// <summary>The resource-specific properties for this resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdateProperties Property { get; set; }
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
        /// <summary>Resource tags.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdateTags Tag { get; set; }

    }
}