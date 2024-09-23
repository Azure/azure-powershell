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

namespace Microsoft.Azure.Commands.CosmosDB.Helpers
{
    internal static class Constants
    {

        public const string DeprecateByAzVersion12 = "12.0.0";
        public const string DeprecateByVersion2 = "2.0.0";

        public const string ResourceGroupNameHelpMessage = "Name of resource group.";
        public const string ResourceIdHelpMessage = "ResourceId of the resource.";

        public const string AsJobHelpMessage = "Run cmdlet in the background";
        public const string PassThruHelpMessage = "To be set to true if the user wants to receive an output. The output is true if the operation was successful and an error is thrown if not.";

        public const string AccountNameHelpMessage = "Name of the Cosmos DB database account.";
        public const string AccountKeyKindHelpMessage = "The access key to regenerate. Accepted values: primary, primaryReadonly, secondary, secondaryReadonly ";
        public const string AccountFailoverPolicyHelpMessage = "Array of strings having region names, ordered by failover priority. E.g eastus, westus";
        public const string AccountInstanceIdHelpMessage = "The instance Id of the CosmosDB database account. (This is returned as a part of database account properties).";
        public const string AccountObjectHelpMessage = "CosmosDB Account object";
        public const string AccountUpdateLocationHelpMessage = "The georeplication location to be enabled for the Cosmos DB account, can be a single string or an array of strings.";
        public const string DefaultConsistencyLevelHelpMessage = "Default consistency level of the Cosmos DB database account. Accepted values: BoundedStaleness, ConsistentPrefix, Eventual, Session, Strong. Default is Session.";
        public const string EnableAutomaticFailoverHelpMessage = "Enables automatic failover of the write region in the rare event that the region is unavailable due to an outage. Automatic failover will result" +
               " in a new write region for the account and is chosen based on the failover priorities configured for the account. Accepted values: false, true ";
        public const string EnableMultipleWriteLocationsHelpMessage = "Enable Multiple Write Locations. Accepted values: false, true ";
        public const string EnableVirtualNetworkHelpMessage = "Enables virtual network on the Cosmos DB database account. Accepted values: false, true ";
        public const string IpRulesHelpMessage = "Firewall support. Specifies the set of IP addresses or IP address ranges in CIDR form to be included as the allowed list of client IPs for a given database account.";
        public const string MaxStalenessIntervalInSecondsHelpMessage = "When used with Bounded Staleness consistency, this value represents the time amount of staleness (in timespan) tolerated. Accepted range for this value is 5-86400.";
        public const string MaxStalenessPrefixHelpMessage = "When used with Bounded Staleness consistency, this value represents the number of stale requests tolerated. Accepted range for this value is 1 - 2,147,483,647. ";
        public const string TagHelpMessage = "Hashtable of tags as key-value pairs. Use empty string to clear existing tag.";
        public const string LocationHelpMessage = "Add a location to the Cosmos DB database account. Array of strings, ordered by failover priority.";
        public const string LocationObjectHelpMessage = "Add a location to the Cosmos DB database account. Array of PSLocation objects.";
        public const string LocationNameHelpMessage = "Name of the Location in string.";
        public const string FailoverPriorityHelpMessage = "Failover priority of the location.";
        public const string IsZoneRedundantHelpMessage = "Boolean to indicate whether or not this region is an AvailabilityZone.";
        public const string VirtualNetworkRuleHelpMessage = "Array of string values of ACL's for virtual network.";
        public const string VirtualNetworkRuleObjectHelpMessage = "Array of PSVirtualNetworkRuleObjects for virtual network.";
        public const string VirtualNetworkRuleIdHelpMessage = "Resource ID of a subnet, for example: /subscriptions/{subscriptionId}/resourceGroups/{groupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/subnets/{subnetName}";
        public const string IgnoreMissingVNetServiceEndpointHelpMessage = "Boolean to indicate if to create firewall rule before the virtual network has vnet service endpoint enabled.";
        public const string ApiKindHelpMessage = "The type of Cosmos DB database account to create. Accepted values: Sql, MongoDB, Gremlin, Table, Cassandra. Default value: Sql ";
        public const string AccountKeyTypeHelpMessage = "Value from: {ConnectionStrings, Keys, ReadOnlyKeys}. Default is Keys.";
        public const string DisableKeyBasedMetadataWriteAccessHelpMessage = "Disable write operations on metadata resources (databases, containers, throughput) via account keys";
        public const string PublicNetworkAccessHelpMessage = "Whether or not public endpoint access is allowed for this server. Possible values include: 'Enabled', 'Disabled'";
        public const string DisableTtlHelpMessage = "Bool to indicate if restored account is going to have Time-To-Live disabled.";
        public const string KeyVaultUriHelpMessage = "URI of the KeyVault";
        public const string EnableFreeTierHelpMessage = "Bool to indicate if FreeTier is enabled on the account.";
        public const string EnableAnalyticalStorageHelpMessage = "Bool to indicate if AnalyticalStorage is enabled on the account.";
        public const string EnableBurstCapacityHelpMessage = "Bool to indicate if Burst Capacity is enabled on the account.";
        public const string ServerVersionHelpMessage = "ServerVersion, valid only in case of MongoDB Accounts.";
        public const string NetworkAclBypassHelpMessage = "Whether or not Network Acl Bypass is enabled for this account for Synapse Link. Possible values include: 'None', 'AzureServices'.";
        public const string NetworkAclBypassResourceIdHelpMessage = "List of Resource Ids to allow Network Acl Bypass for Synapse Link.";
        public const string DatabaseResourceIdHelpMessage = "ResourceId of the database.";
        public const string AnalyticalStorageSchemaTypeHelpMessage = "The schema type for analytical storage. Valid values include: 'WellDefined' and 'FullFidelity'.";
        public const string EnablePartitionMergeHelpMessage = "Enables partition merge feature on the Cosmos DB database account. Accepted values: false, true";
        public const string MinimalTlsVersionHelpMessage = "Indicates the minimum allowed Tls version. The default value is Tls 1.2. Cassandra and Mongo APIs only work with Tls 1.2. Possible values include: 'Tls', 'Tls11', 'Tls12'.";

        //Restore specific help messages
        public const string IsRestoreRequestHelpMessage = "Indicates that the new Cosmos DB account request is a restore request.";
        public const string RestoreSourceIdHelpMessage = "The restorable database account Id of the source account of the restore. Example: /subscriptions/{subscriptionId}/providers/Microsoft.DocumentDB/locations/{location}/restorabledatabaseaccounts/{instanceId}";
        public const string RestoreTimestampHelpMessage = "The timestamp to which the source account has to be restored to.";
        public const string ResourceRestoreTimestampHelpMessage = "The timestamp to which the resource has to be restored to.";
        public const string DatabasesToRestoreHelpMessage = "The list of PSDatabaseToRestore objects which specify the subset of databases and collections to restore from the source account. (If not provided, all the databases will be restored)";
        public const string GremlinDatabasesToRestoreHelpMessage = "The list of PSGremlinDatabaseToRestore objects which specify the subset of databases and graphs to restore from the source account. (If not provided, all the databases will be restored)";
        public const string TablesToRestoreHelpMessage = "The list of PSTableToRestore objects which specify the subset of tables to restore from the source account. (If not provided, all the tables will be restored)";
        public const string RestoreDatabaseNameHelpMessage = "The name of the database to restore";
        public const string RestoreCollectionNamesHelpMessage = "The names of the collections to be restored. (If not provided, all the collections will be restored)";
        public const string RestoreSourceDatabaseAccountNameHelpMessage = "The name of the source database account of the restore.";
        public const string RestoreLocationNameHelpMessage = "The location of the source account from which restore is triggered. This will also be the write region of the restored account";
        public const string RestorableDatabaseAccountObjectHelpMessage = "CosmosDB Restorable Database Account object";
        public const string RestorableSqlDatabaseObjectHelpMessage = "CosmosDB Restorable Sql Database object";
        public const string RestorableMongoDBDatabaseObjectHelpMessage = "CosmosDB Restorable MongoDB Database object";

        //Backup specific help messages
        public const string BackupPolicyHelpMessage = "The backup policy to indicate how the backups of the account should be taken";
        public const string BackupIntervalInMinHelpMessage = "The interval(in minutes) with which backup are taken (only for accounts with periodic mode backups)";
        public const string BackupRetentionInHoursHelpMessage = "The time(in hours) for which each backup is retained (only for accounts with periodic mode backups)";
        public const string BackupTypeHelpMessage = "The type of backups on the Cosmos DB account. Accepted values: Periodic, Continuous";
        public const string BackupStorageRedundancyHelpMessage = "The redundancy type of the backup Storage account";
        public const string ContinuousTierHelpMessage = "The continuous backup tier of the account";

        //Sql cmdlets help messages
        public const string DatabaseNameHelpMessage = "Database name.";
        public const string ContainerNameHelpMessage = "Container name.";
        public const string StoredProcedureNameHelpMessage = "Stored Prcodecure Name.";
        public const string UserDefinedFunctionNameHelpMessage = "User Defined Function Name.";
        public const string TriggerNameHelpMessage = "Trigger name.";
        public const string SqlIndexingPolicyHelpMessage = "Indexing Policy Object of type Microsoft.Azure.Commands.CosmosDB.PSSqlIndexingPolicy.";
        public const string IndexingPolicyHelpMessage = "Indexing Policy Object of type Microsoft.Azure.Commands.CosmosDB.PSIndexingPolicy.";
        public const string SqlUniqueKeyPolciyHelpMessage = "UniqueKeyPolicy Object of type Microsoft.Azure.Commands.CosmosDB.PSSqlUniqueKeyPolicy. ";
        public const string UniqueKeyPolciyHelpMessage = "UniqueKeyPolicy Object of type Microsoft.Azure.Commands.CosmosDB.PSUniqueKeyPolicy. ";
        public const string SqlConflictResolutionPolicyHelpMessage = "ConflictResolutionPolicy Object of type PSSqlConflictResolutionPolicy, when provided this is set as the ConflictResolutionPolicy of the container.";
        public const string SqlClientEncryptionPolicyHelpMessage = "ClientEncryptionPolicy Object of type PSSqlClientEncryptionPolicy, when provided this is set as the ClientEncryptionPolicy of the container.";
        public const string ConflictResolutionPolicyHelpMessage = "ConflictResolutionPolicy Object of type PSConflictResolutionPolicy, when provided this is set as the ConflictResolutionPolicy of the container.";
        public const string PartitionKeyPathHelpMessage = "Partition Key Path, e.g., '/address/zipcode'.";
        public const string SqlContainerThroughputHelpMessage = "The throughput of SQL container (RU/s). Default value is 400.";
        public const string TtlInSecondsHelpMessage = "Default Ttl in seconds. If the value is missing or set to  - 1, items don’t expire. If the value is set to n, items will expire n seconds after last modified time. ";
        public const string SqlDatabaseObjectHelpMessage = "Sql Database object.";
        public const string SqlContainerObjectHelpMessage = "Sql Container object.";
        public const string SqlDatabaseThroughputHelpMessage = "The throughput of SQL database (RU/s). Default value is 400.";
        public const string SqlConflictResolutionPolicyModeHelpMessage = "Can have the values: LastWriterWins, Custom, Manual. If provided along with ConflictResolutionPolicy parameter, it is ignored.";
        public const string SqlConflictResolutionPolicyPathHelpMessage = "To be provided when the type is LastWriterWins. If provided along with ConflictResolutionPolicy parameter, it is ignored.";
        public const string SqlConflictResolutionPolicyProcedureHelpMessage = "To be provided when the type is custom. If provided along with ConflictResolutionPolicy parameter, it is ignored.";
        public const string UniqueKeyPathHelpMessage = "Array of string of path values";
        public const string SqlUniqueKeysHelpMessage = "Array of objects of type PSSqlUniqueKey.";
        public const string IndexingPolicyIncludedPathHelpMessage = "Array of strings containing includedPath (Specifies a path within a JSON document to be included in the Azure Cosmos DB service.) elements. ";
        public const string IndexingPolicyExcludedPathHelpMessage = "Array of strings containing excludedPath(Specifies a path within a JSON document to be excluded in the Azure Cosmos DB service.)  elements. ";
        public const string IndexingPolicyAutomaticHelpMessage = "Bool to indicate if the indexing policy is automatic";
        public const string IndexingPolicyIndexingModeIndexHelpMessage = "Indicates the indexing mode. Possible values include: 'Consistent', 'Lazy', 'None'";
        public const string IndexingPolicySpatialIndexHelpMessage = "Array of objects of type Microsoft.Azure.Commands.CosmosDB.PSSpatialSpec";
        public const string IndexingPolicyCompositePathHelpMessage = "Array of array of objects of type Microsoft.Azure.Commands.CosmosDB.PSCompositePath";
        public const string SpatialTypeHelpMessage = "Array of strings with acceptable values: Point, LineString, Polygon, MultiPolygon. Represent’s paths spatial type.";
        public const string SpatialPathHelpMessage = "Path in JSON document to index.";
        public const string SortOrderHelpMessage = "The sort order of the CompositeIndex";
        public const string PathHelpMessage = "String value of the path";
        public const string PartitionKeyVersionHelpMessage = "The version of the partition key definition";
        public const string PartitionKeyKindHelpMessage = "The kind of algorithm used for partitioning. Possible values include: 'Hash', 'Range'";
        public const string StoredProcedureBodyHelpMessage = "The body of the Stored Procedure.";
        public const string UserDefinedFunctionBodyHelpMessage = "The body of the User Defined Function.";
        public const string TriggerBodyHelpMessage = "The body of the Trigger.";
        public const string TriggerOperationHelpMessage = "The operation the trigger is associated with. Possible values include: 'All', 'Create', 'Update', 'Delete', 'Replace' ";
        public const string TriggerTypeHelpMessage = "Type of the Trigger. Possible values include: 'Pre', 'Post'";
        public const string SqlUserDefinedFunctionObjectHelpMessage = "Sql User Defined Function Object";
        public const string SqlTriggerObjectHelpMessage = "Sql trigger Object";
        public const string SqlStoredProcedureObjectHelpMessage = "Sql Stored Procedure Object";
        public const string IncludedPathIndexesDataTypeHelpMessage = "Datatype for which the indexing behavior is applied to. Possible values include: 'String', 'Number', 'Point', 'Polygon', 'LineString', 'MultiPolygon'";
        public const string IncludedPathIndexesPrecisionHelpMessage = "The precision of the index. -1 is maximum precision.";
        public const string IncludedPathIndexesKindHelpMessage = "Indicates the type of index. Possible values include: 'Hash', 'Range', 'Spatial'";
        public const string IncludedPathHelpMessage = "The path for which the indexing behavior applies to. Index paths typically start with root and end with wildcard (/path/*)";
        public const string IncludedPathIndexesHelpMessage = "List of indexes for this path";
        public const string CompositePathHelpMessage = "The path for which the indexing behavior applies to. Index paths typically start with root and end with wildcard (/path/*)";
        public const string CompositePathOrderTypeHelpMessage = " Gets or sets sort order for composite paths. Possible values include: 'Ascending', 'Descending'";
        public const string SqlContainerAnalyticalStorageTtlHelpMessage = "TTL for Analytical Storage (in Seconds).";
        public const string ClientEncryptionKeyObjectHelpMessage = "Client Encryption Key object.";
        public const string RestorableSqlContainersFeedStartTimeHelpMessage = "Restorable Sql containers event feed start time.";
        public const string RestorableSqlContainersFeedEndTimeHelpMessage = "Restorable Sql containers event feed end time.";

        //SQL Client Side Encryption
        public const string ClientEncryptionKeyName = "Client Encryption Key name.";
        public const string ClientEncryptionKeyNameAlias = "ClientEncryptionKeyName";
        public const string EncryptionAlgorithmName = "Client Encryption Algorithm name.";
        public const string KeyWrapMetaData = "KeyWrapMetaData Object of type Microsoft.Azure.Commands.CosmosDB.PSSqlKeyWrapMetadata.";
        public const string KeyEncryptionKeyResolver = "KeyEncryptionKeyResolver interface of type Azure.Core.Cryptography.IKeyEncryptionKeyResolver. If KeyEncryptionKeyResolver is not passed Azure Key Vault KeyResolver is used.";

        //MongoDB cmdlets help messages
        public const string CollectionNameHelpMessage = "Collection name.";
        public const string MongoDatabaseObjectHelpMessage = "Mongo Database object.";
        public const string MongoCollectionObjectHelpMessage = "Mongo Collection object.";
        public const string MongoShardKeyHelpMessage = "Sharding key path.";
        public const string MongoCollectionAnalyticalStorageTtlHelpMessage = "TTL for Analytical Storage (in Seconds).";
        public const string MongoIndexTtlInSeconds = "Number of seconds after which the index expires.";
        public const string MongoIndexUnique = "Bool to indicate if the index is unique or not.";
        public const string MongoIndexKey = "Array of key values as strings.";
        public const string MongoIndexHelpMessage = "Array of PSMongoIndex objects.";
        public const string MongoCollectionThroughputHelpMessage = "The throughput of Mongo collection (RU/s). Default value is 400.";
        public const string MongoDatabaseThroughputHelpMessage = "The throughput of Mongo database (RU/s). Default value is 400.";
        public const string RestorableMongoDBCollectionsFeedStartTimeHelpMessage = "Restorable MongoDB collections event feed start time.";
        public const string RestorableMongoDBCollectionsFeedEndTimeHelpMessage = "Restorable MongoDB collections event feed end time.";

        //Table cmdlets help messages
        public const string TableNameHelpMessage = "Name of the Table.";
        public const string TableThroughputHelpMessage = "The throughput of Table (RU/s). Default value is 400.";
        public const string TableObjectHelpMessage = "Table Object.";
        public const string RestorableTableObjectHelpMessage = "CosmosDB Restorable Table object.";
        public const string RestorableTablesFeedStartTimeHelpMessage = "Restorable Tables event feed start time.";
        public const string RestorableTablesFeedEndTimeHelpMessage = "Restorable Tables event feed end time.";
        public const string RestoreTableNamesHelpMessage = "The names of the tables to be restored. (If not provided, all the tables will be restored)";

        //Cassandra cmdlets help messages
        public const string KeyspaceNameHelpMessage = "Cassandra Keyspace Name.";
        public const string CassandraTableNameHelpMessage = "Cassandra Table Name.";
        public const string CassandraKeyspaceObjectHelpMessage = "Cassandra Keyspace object.";
        public const string CassandraTableObjectHelpMessage = "Cassandra Table object.";
        public const string CassandraKeyspaceThroughputHelpMessage = "The throughput of Cassandra Keyspace (RU/s). Default value is 400.";
        public const string CassandraTableThroughputHelpMessage = "The throughput of Cassandra Keyspace (RU/s). Default value is 400.";
        public const string CassandraSchemaHelpMessage = "PSCassandraSchema object. Use New-AzCosmosDBCassandraSchema to create this object.";
        public const string CassandraClusterKeyNameHelpMessage = "Name of Cassandra Cluster Key.";
        public const string CassandraClusterKeyOrderByHelpMessage = "Ordering of Cassandra Cluster key. Possible values include: 'Asc', 'Desc'";
        public const string CassandraColumnNameHelpMessage = "Name of Cassandra Column.";
        public const string CassandraColumnTypeHelpMessage = "Type of Cassandra Column.";
        public const string CassandraSchemaColumnHelpMessage = "PSColumn object.";
        public const string CassandraSchemaPartitionKeyHelpMessage = "Array of strings containing Partition Keys.";
        public const string CassandraSchemaClusterKeyHelpMessage = "Array of PSClusterKey objects.";
        public const string AnalyticalStorageTtlHelpMessage = "Analytical Storage TTL.";

        //Gremlin cmdlets help messages
        public const string GremlinDatabaseNameHelpMessage = "Gremlin Database name.";
        public const string GraphNameHelpMessage = "Gremlin Graph Name.";
        public const string GremlinDatabaseObjectHelpMessage = "Gremlin Database object.";
        public const string GremlinGraphObjectHelpMessage = "Gremlin Graph object.";
        public const string GremlinDatabaseThroughputHelpMessage = "The throughput of Gremlin Database (RU/s). Default value is 400.";
        public const string GremlinGraphThroughputHelpMessage = "The throughput of Gremlin Graph (RU/s). Default value is 400.";
        public const string ConflictResolutionPolicyModeHelpMessage = "Can have the values: LastWriterWins, Custom";
        public const string ConflictResolutionPolicyPathHelpMessage = "To be provided when the type is LastWriterWins.";
        public const string ConflictResolutionPolicyProcedureHelpMessage = "To be provided when the type is custom.";
        public const string UniqueKeysHelpMessage = "Array of objects of type PSUniqueKey.";
        public const string RestorableGremlinDatabaseObjectHelpMessage = "CosmosDB Restorable Gremlin Database object.";
        public const string RestorableGremlinGraphObjectHelpMessage = "CosmosDB Restorable Gremlin Graph object.";
        public const string RestorableGremlinGraphsFeedStartTimeHelpMessage = "Restorable Gremlin graphs event feed start time.";
        public const string RestorableGremlinGraphsFeedEndTimeHelpMessage = "Restorable Gremlin graphs event feed end time.";
        public const string RestoreGremlinDatabaseNameHelpMessage = "The name of the gremlin database to restore";
        public const string RestoreGraphNamesHelpMessage = "The names of the graphs to be restored. (If not provided, all the graphs will be restored)";

        // Throughput cmdlets for all APIs
        public const string ThroughputHelpMessage = "Throughput value in int.";
        public const string AutoscaleMaxThroughputHelpMessage = "Maximum Throughput value if autoscale is enabled.";
        public const string ThroughputTypeHelpMessage = "Throughput type to migrate to. Possible values are: Autoscale, Manual.";

        // Role cmdlets help messages
        public const string PrincipalIdHelpMessage = "Object ID (Guid) of the AAD principal to which the Role Assignment is being granted. This could be user, group, service principal, or managed identity.";
        public const string ScopeHelpMessage = "Resource path below which the Role Assignment shall grant access. Eg. '/', '/dbs/dbname','/dbs/dbname/colls/collname'.";
        public const string RoleAssignmentHelpMessage = "A Role Assignment attaches a Role Definition to an AAD principal at a specified resource scope for granting access.";
        public const string RoleAssignmentIdHelpMessage = "Unique ID (Guid) for the Role Assignment.";
        public const string RoleDefinitionHelpMessage = "A Role Definition is a collection of permissions.";
        public const string RoleDefinitionIdHelpMessage = "Unique ID (Guid) for the Role Definition.";
        public const string TypeHelpMessage = "Type of the Role Definition, either CustomRole or BuiltInRole.";
        public const string RoleNameHelpMessage = "Unique display name for the Role Definition.";
        public const string DataActionsHelpMessage = "Set of data actions granted through the Role Definition. List of allowed actions can be found at: https://aka.ms/cosmos-native-rbac";
        public const string PermissionsHelpMessage = "Permission is a collection of data actions.";
        public const string AssignableScopesHelpMessage = "Set of resource paths below which a Role Assignment can be attached to the Role Definition. Eg. '/', '/dbs/dbname','/dbs/dbname/colls/collname'.";
        public const string RoleDefinitionNameHelpMessage = "Unique display name for the Role Definition.";

        //Cassandra cmdlets help messages        
        public const string ManagedCassandraTagsHelpMessage = "Managed Cassandra Tags.";
        public const string ManagedCassandraIdentityHelpMessage = "Identity used to authenticate.";
        public const string ManagedCassandraRepairEnabledHelpMessage = "Enables automatic repair.";
        public const string ManagedCassandraLocationHelpMessage = "Azure Location of the Cluster.";
        public const string ManagedCassandraClusterNameHelpMessage = "Managed Cassandra Cluster Name.";
        public const string ManagedCassandraClusterObjectHelpMessage = "Managed Cassandra Cluster object";
        public const string ManagedCassandraDatacenterNameHelpMessage = "Managed Cassandra Datacenter Name.";
        public const string ManagedCassandraCassandraVersionHelpMessage = "The version of Cassandra chosen.";
        public const string ManagedCassandraDatacenterObjectHelpMessage = "Managed Cassandra Datacenter object";
        public const string ManagedCassandraDatacenterLocationHelpMessage = "Azure Location of the DataCenter.";
        public const string ManagedCassandraHoursBetweenBackupsHelpMessage = "The number of hours between backup attempts.";
        public const string ManagedCassandraExternalSeedNodesHelpMessage = "A list of ip addresses of the seed nodes of on-premise data centers.";
        public const string ManagedCassandraClientCertificatesHelpMessage = "If specified, enables client certificate authentication to the Cassandra API.";
        public const string ManagedCassandraNodeCountHelpMessage = "The number of Cassandra virtual machines in this data center. The minimum value is 3.";
        public const string ManagedCassandraExternalGossipCertificatesHelpMessage = "A list of certificates that the managed cassandra data center's should accept.";
        public const string ManagedCassandraInitialCassandraAdminPasswordHelpMessage = "The intial password to be configured when a cluster is created for AuthenticationMethod Cassandra.";
        public const string ManagedCassandraBase64EncodedCassandraYamlFragment = "This is a Base64 encoded yaml file that is a subset of cassandra.yaml. Supported fields will be honored and others will be ignored.";
        public const string ManagedCassandraDataCenterDelegatedSubnetIdHelpMessage = "The resource id of a subnet where ip addresses of the Cassandra virtual machines will be allocated. This must be in the same region as datacenter location.";
        public const string ManagedCassandraAuthenticationMethodHelpMessage = "Authentication mode can be None or Cassandra. If None, no authentication will be required to connect to the Cassandra API. If Cassandra, then passwords will be used.";
        public const string ManagedCassandraRestoreFromBackupIdHelpMessage = "The resource id of a backup. If provided on create, the backup will be used to prepopulate the cluster.";
        public const string ManagedCassandraDelegatedSubnetIdHelpMessage = "The resource id of a subnet where the ip address of the cassandra management server will be allocated. This subnet must have connectivity to the DelegatedSubnetId subnet of each data center.";
        public const string ManagedCassandraClusterNameOverrideHelpMessage = "By default, the Azure resource name is used to populate the clusterName field in cassandra.yaml. If this field is set, its value is used instead of the Azure resource name, for example, if you need a clusterName that is not a valid Azure resource name, or you need multiple clusters with the same clusterName.";
        public const string ManagedCassandraManagedDiskCustomerKeyUri = "URI to KeyVault key used to encrypt the Cassandra data disks. If not set, will use Azure's own keys. Ensure the system assigned identity of the cluster has been assigned appropriate permissions (key get/wrap/unwrap permissions) on the key.";
        public const string ManagedCassandraBackupStorageCustomerKeyUri = "URI to KeyVault key that is used to encrypt Cassandra backups. If not set, will use Azure's own keys. Ensure the system assigned identity of the cluster has been assigned appropriate permissions (key get/wrap/unwrap permissions) on the key.";
        public const string ManagedCassandraSku = "Virtual Machine SKU used for data centers. Default value is Standard_DS14_v2";
        public const string ManagedCassandraDiskSku = "Disk SKU used for data centers. Default value is P30.";
        public const string ManagedCassandraDiskCapacity = "Number of disk used for data centers. Default value is 4.";
        public const string ManagedCassandraUseAvailabilityZone = "Deploy nodes across availability zones if they are available in this location.";

        // MongoDB Role cmdlets help messages
        public const string MongoDBRoleDefinitionHelpMessage = "A MongoDB Role Definition For Mongo DB.";
        public const string MongoDBRoleDefinitionDatabaseName = "Database Name for the MongoDB Role Definition.";
        public const string MongoRoleDefinitionPrivilegesHelpMessage = "MongoDB Role Definition Privileges define allowed actions for corresponding resources.";
        public const string MongoDBRoleDefinitionIdHelpMessage = "Unique ID (<Databasename>.<RoleName>) for the MongoDB Role Definition.";
        public const string MongoDBTypeHelpMessage = "Type of the MongoDB Role Definition, either CustomRole or BuiltInRole.";
        public const string MongoDBRoleDefinitionNameHelpMessage = "Unique display name(per database) for the MongoDB Role Definition.";
        public const string MongoDBRoleNameHelpMessage = "Unique display name(per database) for the Role Definition.";
        public const string MongoDBInheritedRolesHelpMessage = "List of Inherited roles for MongoDB Role Definition.";
        public const string MongoDBRoleDefinitionRoleDatabaseName = "Database Name for the MongoDB Role Definition Inherited Role.";
        public const string MongoDBInheritedRoleNameHelpMessage = "Role Name for the MongoDB Role Definition Inherited Role.";
        public const string MongoRoleDefinitionPrivilegeResourcHelpMessage = "MongoDB Role Definition Resource(Database and Collection name) for the Privilege.";
        public const string MongoRoleDefinitionPrivilegeActionsHelpMessage = "MongoDB Role Definition list of actions(insert/update/delete) for the Privilege.";

        // MongoDB User Definition cmdlets help messages
        public const string MongoDBUserDefinitionHelpMessage = "A MongoDB User Definition for MongoDB.";
        public const string MongoDBUserDefinitionIdHelpMessage = "Unique ID (<Databasename>.<UserName>) for the MongoDB User Definition.";
        public const string MongoDBUserDefinitionUserNameHelpMessage = "Unique username(per database) for the user Definition.";
        public const string MongoDBUserDefinitionPasswordHelpMessage = "Password for the user Definition.";
        public const string MongoDBUserDefinitionMechanismsHelpMessage = "Mechanisms(e.g. SCRAM-SHA-256) for the user Definition.";
        public const string MongoDBUserDefinitionCustomDataHelpMessage = "Additional information about the user Definition.";

        // Service constants
        public const string ServiceName = "Name of the service";
        public const string ServiceInstanceSize = "Instance count of the service";
        public const string ServiceInstanceCount = "Instance size of the service";
    }
}
