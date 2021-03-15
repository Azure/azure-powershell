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
        public const string ResourceGroupNameHelpMessage = "Name of resource group.";
        public const string ResourceIdHelpMessage = "ResourceId of the resource.";

        public const string AsJobHelpMessage = "Run cmdlet in the background";
        public const string PassThruHelpMessage = "To be set to true if the user wants to receive an output. The output is true if the operation was successful and an error is thrown if not.";

        public const string AccountNameHelpMessage = "Name of the Cosmos DB database account.";
        public const string AccountKeyKindHelpMessage = "The access key to regenerate. Accepted values: primary, primaryReadonly, secondary, secondaryReadonly ";
        public const string AccountFailoverPolicyHelpMessage = "Array of strings having region names, ordered by failover priority. E.g eastus, westus";
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
        public const string KeyVaultUriHelpMessage = "URI of the KeyVault";
        public const string EnableFreeTierHelpMessage = "Bool to indicate if FreeTier is enabled on the account.";
        public const string EnableAnalyticalStorageHelpMessage = "Bool to indicate if AnalyticalStorage is enabled on the account.";
        public const string ServerVersionHelpMessage = "ServerVersion, valid only in case of MongoDB Accounts.";
        public const string NetworkAclBypassHelpMessage = "Whether or not Network Acl Bypass is enabled for this account for Synapse Link. Possible values include: 'None', 'AzureServices'.";
        public const string NetworkAclBypassResourceIdHelpMessage = "List of Resource Ids to allow Network Acl Bypass for Synapse Link.";

        //Backup specific help messages
        public const string BackupIntervalInMinHelpMessage = "The interval(in minutes) with which backup are taken (only for accounts with periodic mode backups)";
        public const string BackupRetentionInHoursHelpMessage = "The time(in hours) for which each backup is retained (only for accounts with periodic mode backups)";

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

        //Table cmdlets help messages
        public const string TableNameHelpMessage = "Name of the Table.";
        public const string TableThroughputHelpMessage = "The throughput of Table (RU/s). Default value is 400.";
        public const string TableObjectHelpMessage = "Table Object.";

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
        public const string GraphNameHelpMessage = "Gremlin Graph Name.";
        public const string GremlinDatabaseObjectHelpMessage = "Gremlin Database object.";
        public const string GremlinGraphObjectHelpMessage = "Gremlin Graph object.";
        public const string GremlinDatabaseThroughputHelpMessage = "The throughput of Gremlin Database (RU/s). Default value is 400.";
        public const string GremlinGraphThroughputHelpMessage = "The throughput of Gremlin Graph (RU/s). Default value is 400.";
        public const string ConflictResolutionPolicyModeHelpMessage = "Can have the values: LastWriterWins, Custom";
        public const string ConflictResolutionPolicyPathHelpMessage = "To be provided when the type is LastWriterWins.";
        public const string ConflictResolutionPolicyProcedureHelpMessage = "To be provided when the type is custom.";
        public const string UniqueKeysHelpMessage = "Array of objects of type PSUniqueKey.";

        // Throughput cmdlets for all APIs
        public const string ThroughputHelpMessage = "Throughput value in int.";
        public const string AutoscaleMaxThroughputHelpMessage = "Maximum Throughput value if autoscale is enabled.";
        public const string ThroughputTypeHelpMessage = "Throughput type to migrate to. Possible values are: Autoscale, Manual.";
    }
}
