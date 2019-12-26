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
        public const string AccountUpdateLocationHelpMessage = "Name of the location to be added.";
        public const string DefaultConsistencyLevelHelpMessage = "Default consistency level of the Cosmos DB database account. Accepted values: BoundedStaleness, ConsistentPrefix, Eventual, Session, Strong";
        public const string EnableAutomaticFailoverHelpMessage = "Enables automatic failover of the write region in the rare event that the region is unavailable due to an outage. Automatic failover will result" +
               " in a new write region for the account and is chosen based on the failover priorities configured for the account. Accepted values: false, true ";
        public const string EnableMultipleWriteLocationsHelpMessage = "Enable Multiple Write Locations. Accepted values: false, true ";
        public const string EnableVirtualNetworkHelpMessage = "Enables virtual network on the Cosmos DB database account. Accepted values: false, true ";
        public const string IpRangeFilterHelpMessage = "Firewall support. Specifies the set of IP addresses or IP address ranges in CIDR form to be included as the allowed list of client IPs for a given database account";
        public const string MaxStalenessIntervalInSecondsHelpMessage = "When used with Bounded Staleness consistency, this value represents the time amount of staleness (in timespan) tolerated. Accepted range for this value is 5-86400.";
        public const string MaxStalenessPrefixHelpMessage = "When used with Bounded Staleness consistency, this value represents the number of stale requests tolerated. Accepted range for this value is 1 - 2,147,483,647. ";
        public const string TagHelpMessage = "Hashtable of tags as key-value pairs. Use empty string to clear existing tag.";
        public const string LocationHelpMessage = "Add a location to the Cosmos DB database account. Array of strings, ordered by failover priority.";
        public const string VirtualNetworkRuleHelpMessage = "Array of string values of ACL's for virtual network.";
        public const string ApiKindHelpMessage = "The type of Cosmos DB database account to create. Accepted values: GlobalDocumentDB, Sql, MongoDB, Gremlin, Table, Cassandra. Default value: GlobalDocumentDB ";
        public const string AccountKeyTypeHelpMessage = "Value from: {ConnectionStrings, Keys, ReadOnlyKeys}. Default is Keys.";
        
        //Sql cmdlets help messages
        public const string DatabaseNameHelpMessage = "Database name.";
        public const string ContainerNameHelpMessage = "Container name.";
        public const string StoredProcedureNameHelpMessage = "Stored Prcodecure Name.";
        public const string UserDefinedFunctionNameHelpMessage = "User Defined Function Name.";
        public const string TriggerNameHelpMessage = "Trigger name.";
        public const string IndexingPolicyHelpMessage = "Indexing Policy Object of type Microsoft.Azure.Commands.CosmosDB.PSSqlIndexingPolicy.";
        public const string UniqueKeyPolciyHelpMessage = "UniqueKeyPolicy Object of type Microsoft.Azure.Commands.CosmosDB.PSSqlUniqueKeyPolicy. ";
        public const string ConflictResolutionPolicyHelpMessage = "ConflictResolutionPolicy Object of type PSSqlConflictResolutionPolicy. ";
        public const string PartitionKeyPathHelpMessage = "Partition Key Path, e.g., '/address/zipcode'.";
        public const string SqlContainerThroughputHelpMessage = "The throughput of SQL container (RU/s). Default value is 400.";
        public const string TtlInSecondsHelpMessage = "Default Ttl in seconds. If the value is missing or set to  - 1, items don’t expire. If the value is set to n, items will expire n seconds after last modified time. ";
        public const string SqlDatabaseObjectHelpMessage = "Sql Database object.";
        public const string SqlContainerDetailedParamHelpMessage = "If provided then, the cmdlet returns the container with the throughput value. ";
        public const string SqlContainerObjectHelpMessage = "Sql Container object.";
        public const string SqlDatabaseThroughputHelpMessage = "The throughput of SQL database (RU/s). Default value is 400.";
        public const string SqlDatabaseDetailedParamHelpMessage = "If provided then, the cmdlet returns the container with the throughput value. ";
        public const string ConflictResolutionPolicyTypeHelpMessage = "Can have the values: LastWriterWins, Custom, Manual.";
        public const string ConflictResolutionPolicyPathHelpMessage = "To be provided when the type is LastWriterWins.";
        public const string ConflictResolutionPolicyStoredProcedureNameHelpMessage = "To be provided when the type is custom.";
        public const string UniqueKeyPathHelpMessage = "Array of string of path values";
        public const string IndexingPolicyIncludedPathHelpMessage = "Array of strings containing includedPath (Specifies a path within a JSON document to be included in the Azure Cosmos DB service.) elements. ";
        public const string IndexingPolicyExcludedPathHelpMessage = "Array of strings containing excludedPath(Specifies a path within a JSON document to be excluded in the Azure Cosmos DB service.)  elements. ";
        public const string IndexingPolicyAutomaticHelpMessage = "Bool to indicate if the indexing policy is automatic";
        public const string IndexingPolicyIndexingModeIndexHelpMessage = " indicates the indexing mode. Possible values include: 'Consistent', 'Lazy', 'None'";
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
    }
}
