// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Extensions;

    /// <summary>Represents a mongo cluster replica.</summary>
    public partial class Replica :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplica,
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal,
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IProxyResource" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IProxyResource __proxyResource = new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ProxyResource();

        /// <summary>The administrator password.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public System.Security.SecureString AdministratorPassword { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).AdministratorPassword; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).AdministratorPassword = value ?? null; }

        /// <summary>The administrator user name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string AdministratorUserName { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).AdministratorUserName; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).AdministratorUserName = value ?? null; }

        /// <summary>Allowed authentication modes for data access on the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<string> AuthConfigAllowedMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).AuthConfigAllowedMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).AuthConfigAllowedMode = value ?? null /* arrayOf */; }

        /// <summary>Earliest restore timestamp in UTC ISO8601 format.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string BackupEarliestRestoreTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).BackupEarliestRestoreTime; }

        /// <summary>The status of the mongo cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string ClusterStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).ClusterStatus; }

        /// <summary>
        /// The compute tier to assign to the cluster, where each tier maps to a virtual-core and memory size. Example values: 'M30',
        /// 'M40'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string ComputeTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).ComputeTier; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).ComputeTier = value ?? null; }

        /// <summary>The default mongo connection string for the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string ConnectionString { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).ConnectionString; }

        /// <summary>The mode to create a mongo cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string CreateMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).CreateMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).CreateMode = value ?? null; }

        /// <summary>The URI of the key vault key used for encryption.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string CustomerManagedKeyEncryptionKeyUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).CustomerManagedKeyEncryptionKeyUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).CustomerManagedKeyEncryptionKeyUrl = value ?? null; }

        /// <summary>The mode to indicate whether the Mongo Data API is enabled for a cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string DataApiMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).DataApiMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).DataApiMode = value ?? null; }

        /// <summary>The target high availability mode requested for the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string HighAvailabilityTargetMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).HighAvailabilityTargetMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).HighAvailabilityTargetMode = value ?? null; }

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)__proxyResource).Id; }

        /// <summary>The infrastructure version the cluster is provisioned on.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string InfrastructureVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).InfrastructureVersion; }

        /// <summary>The type of identity. Only 'UserAssignedIdentity' is supported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string KeyEncryptionKeyIdentityType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).KeyEncryptionKeyIdentityType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).KeyEncryptionKeyIdentityType = value ?? null; }

        /// <summary>The user assigned identity resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string KeyEncryptionKeyIdentityUserAssignedIdentityResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).KeyEncryptionKeyIdentityUserAssignedIdentityResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).KeyEncryptionKeyIdentityUserAssignedIdentityResourceId = value ?? null; }

        /// <summary>Internal Acessors for Administrator</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IAdministratorProperties Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal.Administrator { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).Administrator; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).Administrator = value ?? null /* model class */; }

        /// <summary>Internal Acessors for AuthConfig</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IAuthConfigProperties Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal.AuthConfig { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).AuthConfig; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).AuthConfig = value ?? null /* model class */; }

        /// <summary>Internal Acessors for Backup</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IBackupProperties Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal.Backup { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).Backup; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).Backup = value ?? null /* model class */; }

        /// <summary>Internal Acessors for BackupEarliestRestoreTime</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal.BackupEarliestRestoreTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).BackupEarliestRestoreTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).BackupEarliestRestoreTime = value ?? null; }

        /// <summary>Internal Acessors for ClusterStatus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal.ClusterStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).ClusterStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).ClusterStatus = value ?? null; }

        /// <summary>Internal Acessors for Compute</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IComputeProperties Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal.Compute { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).Compute; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).Compute = value ?? null /* model class */; }

        /// <summary>Internal Acessors for ConnectionString</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal.ConnectionString { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).ConnectionString; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).ConnectionString = value ?? null; }

        /// <summary>Internal Acessors for CustomerManagedKeyEncryptionKeyIdentity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IKeyEncryptionKeyIdentity Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal.CustomerManagedKeyEncryptionKeyIdentity { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).CustomerManagedKeyEncryptionKeyIdentity; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).CustomerManagedKeyEncryptionKeyIdentity = value ?? null /* model class */; }

        /// <summary>Internal Acessors for DataApi</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IDataApiProperties Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal.DataApi { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).DataApi; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).DataApi = value ?? null /* model class */; }

        /// <summary>Internal Acessors for Encryption</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IEncryptionProperties Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal.Encryption { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).Encryption; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).Encryption = value ?? null /* model class */; }

        /// <summary>Internal Acessors for EncryptionCustomerManagedKeyEncryption</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ICustomerManagedKeyEncryptionProperties Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal.EncryptionCustomerManagedKeyEncryption { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).EncryptionCustomerManagedKeyEncryption; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).EncryptionCustomerManagedKeyEncryption = value ?? null /* model class */; }

        /// <summary>Internal Acessors for HighAvailability</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IHighAvailabilityProperties Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal.HighAvailability { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).HighAvailability; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).HighAvailability = value ?? null /* model class */; }

        /// <summary>Internal Acessors for InfrastructureVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal.InfrastructureVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).InfrastructureVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).InfrastructureVersion = value ?? null; }

        /// <summary>Internal Acessors for Parameter</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterReplicaParameters Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal.Parameter { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).ReplicaParameter; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).ReplicaParameter = value ?? null /* model class */; }

        /// <summary>Internal Acessors for PrivateEndpointConnection</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IPrivateEndpointConnection> Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal.PrivateEndpointConnection { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).PrivateEndpointConnection; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).PrivateEndpointConnection = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for PropertiesReplica</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicationProperties Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal.PropertiesReplica { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).Replica; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).Replica = value ?? null /* model class */; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterProperties Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.MongoClusterProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).ProvisioningState = value ?? null; }

        /// <summary>Internal Acessors for ReplicationState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal.ReplicationState { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).ReplicaReplicationState; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).ReplicaReplicationState = value ?? null; }

        /// <summary>Internal Acessors for RestoreParameter</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterRestoreParameters Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal.RestoreParameter { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).RestoreParameter; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).RestoreParameter = value ?? null /* model class */; }

        /// <summary>Internal Acessors for Role</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal.Role { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).ReplicaRole; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).ReplicaRole = value ?? null; }

        /// <summary>Internal Acessors for Sharding</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IShardingProperties Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal.Sharding { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).Sharding; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).Sharding = value ?? null /* model class */; }

        /// <summary>Internal Acessors for SourceResourceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal.SourceResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).ReplicaSourceResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).ReplicaSourceResourceId = value ?? null; }

        /// <summary>Internal Acessors for Storage</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IStorageProperties Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicaInternal.Storage { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).Storage; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).Storage = value ?? null /* model class */; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)__proxyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)__proxyResource).Id = value ?? null; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)__proxyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)__proxyResource).Name = value ?? null; }

        /// <summary>Internal Acessors for SystemData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ISystemData Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal.SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)__proxyResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)__proxyResource).SystemData = value ?? null /* model class */; }

        /// <summary>Internal Acessors for SystemDataCreatedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal.SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)__proxyResource).SystemDataCreatedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)__proxyResource).SystemDataCreatedAt = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for SystemDataCreatedBy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal.SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)__proxyResource).SystemDataCreatedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)__proxyResource).SystemDataCreatedBy = value ?? null; }

        /// <summary>Internal Acessors for SystemDataCreatedByType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal.SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)__proxyResource).SystemDataCreatedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)__proxyResource).SystemDataCreatedByType = value ?? null; }

        /// <summary>Internal Acessors for SystemDataLastModifiedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal.SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedAt = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for SystemDataLastModifiedBy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal.SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedBy = value ?? null; }

        /// <summary>Internal Acessors for SystemDataLastModifiedByType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal.SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedByType = value ?? null; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)__proxyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)__proxyResource).Type = value ?? null; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)__proxyResource).Name; }

        /// <summary>
        /// The network bypass mode for the cluster. Setting to 'AzureCosmosDB' allows Azure Cosmos DB service to bypass network restrictions.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string NetworkBypassMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).NetworkBypassMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).NetworkBypassMode = value ?? null; }

        /// <summary>The location of the source cluster</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string ParameterSourceLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).ReplicaParameterSourceLocation; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).ReplicaParameterSourceLocation = value ?? null; }

        /// <summary>The id of the replication source cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string ParameterSourceResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).ReplicaParameterSourceResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).ReplicaParameterSourceResourceId = value ?? null; }

        /// <summary>List of private endpoint connections.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<string> PreviewFeature { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).PreviewFeature; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).PreviewFeature = value ?? null /* arrayOf */; }

        /// <summary>List of private endpoint connections.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IPrivateEndpointConnection> PrivateEndpointConnection { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).PrivateEndpointConnection; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterProperties _property;

        /// <summary>The resource-specific properties for this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.MongoClusterProperties()); set => this._property = value; }

        /// <summary>The provisioning state of the mongo cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).ProvisioningState; }

        /// <summary>Whether or not public endpoint access is allowed for this mongo cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string PublicNetworkAccess { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).PublicNetworkAccess; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).PublicNetworkAccess = value ?? null; }

        /// <summary>The replication link state of the replica cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string ReplicationState { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).ReplicaReplicationState; }

        /// <summary>UTC point in time to restore a mongo cluster</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public global::System.DateTime? RestoreParameterPointInTimeUtc { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).RestoreParameterPointInTimeUtc; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).RestoreParameterPointInTimeUtc = value ?? default(global::System.DateTime); }

        /// <summary>Resource ID to locate the source cluster to restore</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string RestoreParameterSourceResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).RestoreParameterSourceResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).RestoreParameterSourceResourceId = value ?? null; }

        /// <summary>The replication role of the cluster</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string Role { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).ReplicaRole; }

        /// <summary>
        /// The Mongo DB server version. Defaults to the latest available version if not specified.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string ServerVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).ServerVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).ServerVersion = value ?? null; }

        /// <summary>Number of shards to provision on the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public int? ShardingShardCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).ShardingShardCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).ShardingShardCount = value ?? default(int); }

        /// <summary>The resource id the source cluster for the replica cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string SourceResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).ReplicaSourceResourceId; }

        /// <summary>The size of the data disk assigned to each server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public long? StorageSizeGb { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).StorageSizeGb; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).StorageSizeGb = value ?? default(long); }

        /// <summary>The type of storage to provision the cluster servers with.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inlined)]
        public string StorageType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).StorageType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterPropertiesInternal)Property).StorageType = value ?? null; }

        /// <summary>
        /// Azure Resource Manager metadata containing createdBy and modifiedBy information.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inherited)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ISystemData SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)__proxyResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)__proxyResource).SystemData = value ?? null /* model class */; }

        /// <summary>The timestamp of resource creation (UTC).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inherited)]
        public global::System.DateTime? SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)__proxyResource).SystemDataCreatedAt; }

        /// <summary>The identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inherited)]
        public string SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)__proxyResource).SystemDataCreatedBy; }

        /// <summary>The type of identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inherited)]
        public string SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)__proxyResource).SystemDataCreatedByType; }

        /// <summary>The timestamp of resource last modification (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inherited)]
        public global::System.DateTime? SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedAt; }

        /// <summary>The identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inherited)]
        public string SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedBy; }

        /// <summary>The type of identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inherited)]
        public string SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)__proxyResource).SystemDataLastModifiedByType; }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IResourceInternal)__proxyResource).Type; }

        /// <summary>Creates an new <see cref="Replica" /> instance.</summary>
        public Replica()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__proxyResource), __proxyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyResource), __proxyResource);
        }
    }
    /// Represents a mongo cluster replica.
    public partial interface IReplica :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IProxyResource
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
        /// <summary>The status of the mongo cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The status of the mongo cluster.",
        SerializedName = @"clusterStatus",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("Ready", "Provisioning", "Updating", "Starting", "Stopping", "Stopped", "Dropping")]
        string ClusterStatus { get;  }
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
        /// <summary>The default mongo connection string for the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The default mongo connection string for the cluster.",
        SerializedName = @"connectionString",
        PossibleTypes = new [] { typeof(string) })]
        string ConnectionString { get;  }
        /// <summary>The mode to create a mongo cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"The mode to create a mongo cluster.",
        SerializedName = @"createMode",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("Default", "PointInTimeRestore", "GeoReplica", "Replica")]
        string CreateMode { get; set; }
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
        /// <summary>The infrastructure version the cluster is provisioned on.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The infrastructure version the cluster is provisioned on.",
        SerializedName = @"infrastructureVersion",
        PossibleTypes = new [] { typeof(string) })]
        string InfrastructureVersion { get;  }
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
        /// <summary>The location of the source cluster</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"The location of the source cluster",
        SerializedName = @"sourceLocation",
        PossibleTypes = new [] { typeof(string) })]
        string ParameterSourceLocation { get; set; }
        /// <summary>The id of the replication source cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"The id of the replication source cluster.",
        SerializedName = @"sourceResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string ParameterSourceResourceId { get; set; }
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
        /// <summary>List of private endpoint connections.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"List of private endpoint connections.",
        SerializedName = @"privateEndpointConnections",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IPrivateEndpointConnection) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IPrivateEndpointConnection> PrivateEndpointConnection { get;  }
        /// <summary>The provisioning state of the mongo cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The provisioning state of the mongo cluster.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "InProgress", "Updating", "Dropping")]
        string ProvisioningState { get;  }
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
        /// <summary>The replication link state of the replica cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The replication link state of the replica cluster.",
        SerializedName = @"replicationState",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("Active", "Catchup", "Provisioning", "Updating", "Broken", "Reconfiguring")]
        string ReplicationState { get;  }
        /// <summary>UTC point in time to restore a mongo cluster</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"UTC point in time to restore a mongo cluster",
        SerializedName = @"pointInTimeUTC",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? RestoreParameterPointInTimeUtc { get; set; }
        /// <summary>Resource ID to locate the source cluster to restore</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"Resource ID to locate the source cluster to restore",
        SerializedName = @"sourceResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string RestoreParameterSourceResourceId { get; set; }
        /// <summary>The replication role of the cluster</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The replication role of the cluster",
        SerializedName = @"role",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("Primary", "AsyncReplica", "GeoAsyncReplica")]
        string Role { get;  }
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
        /// <summary>The resource id the source cluster for the replica cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The resource id the source cluster for the replica cluster.",
        SerializedName = @"sourceResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string SourceResourceId { get;  }
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
    /// Represents a mongo cluster replica.
    internal partial interface IReplicaInternal :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IProxyResourceInternal
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
        /// <summary>The status of the mongo cluster.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("Ready", "Provisioning", "Updating", "Starting", "Stopping", "Stopped", "Dropping")]
        string ClusterStatus { get; set; }
        /// <summary>The compute properties of the mongo cluster.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IComputeProperties Compute { get; set; }
        /// <summary>
        /// The compute tier to assign to the cluster, where each tier maps to a virtual-core and memory size. Example values: 'M30',
        /// 'M40'.
        /// </summary>
        string ComputeTier { get; set; }
        /// <summary>The default mongo connection string for the cluster.</summary>
        string ConnectionString { get; set; }
        /// <summary>The mode to create a mongo cluster.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("Default", "PointInTimeRestore", "GeoReplica", "Replica")]
        string CreateMode { get; set; }
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
        /// <summary>The infrastructure version the cluster is provisioned on.</summary>
        string InfrastructureVersion { get; set; }
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
        /// <summary>The parameters to create a replica mongo cluster.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterReplicaParameters Parameter { get; set; }
        /// <summary>The location of the source cluster</summary>
        string ParameterSourceLocation { get; set; }
        /// <summary>The id of the replication source cluster.</summary>
        string ParameterSourceResourceId { get; set; }
        /// <summary>List of private endpoint connections.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("GeoReplicas")]
        System.Collections.Generic.List<string> PreviewFeature { get; set; }
        /// <summary>List of private endpoint connections.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IPrivateEndpointConnection> PrivateEndpointConnection { get; set; }
        /// <summary>The replication properties for the mongo cluster</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IReplicationProperties PropertiesReplica { get; set; }
        /// <summary>The resource-specific properties for this resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterProperties Property { get; set; }
        /// <summary>The provisioning state of the mongo cluster.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "InProgress", "Updating", "Dropping")]
        string ProvisioningState { get; set; }
        /// <summary>Whether or not public endpoint access is allowed for this mongo cluster.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string PublicNetworkAccess { get; set; }
        /// <summary>The replication link state of the replica cluster.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("Active", "Catchup", "Provisioning", "Updating", "Broken", "Reconfiguring")]
        string ReplicationState { get; set; }
        /// <summary>The parameters to create a point-in-time restore mongo cluster.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterRestoreParameters RestoreParameter { get; set; }
        /// <summary>UTC point in time to restore a mongo cluster</summary>
        global::System.DateTime? RestoreParameterPointInTimeUtc { get; set; }
        /// <summary>Resource ID to locate the source cluster to restore</summary>
        string RestoreParameterSourceResourceId { get; set; }
        /// <summary>The replication role of the cluster</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("Primary", "AsyncReplica", "GeoAsyncReplica")]
        string Role { get; set; }
        /// <summary>
        /// The Mongo DB server version. Defaults to the latest available version if not specified.
        /// </summary>
        string ServerVersion { get; set; }
        /// <summary>The sharding properties of the mongo cluster.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IShardingProperties Sharding { get; set; }
        /// <summary>Number of shards to provision on the cluster.</summary>
        int? ShardingShardCount { get; set; }
        /// <summary>The resource id the source cluster for the replica cluster.</summary>
        string SourceResourceId { get; set; }
        /// <summary>The storage properties of the mongo cluster.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IStorageProperties Storage { get; set; }
        /// <summary>The size of the data disk assigned to each server.</summary>
        long? StorageSizeGb { get; set; }
        /// <summary>The type of storage to provision the cluster servers with.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("PremiumSSD", "PremiumSSDv2")]
        string StorageType { get; set; }

    }
}