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

namespace Microsoft.Azure.Commands.CosmosDB.Models
{
    using System.Collections.Generic;
    using Microsoft.Azure.Management.CosmosDB.Models;

    public class PSDatabaseAccountGetResults
    {
        public PSDatabaseAccountGetResults()
        {
        }

        public PSDatabaseAccountGetResults(DatabaseAccountGetResults databaseAccountGetResults)
        {
            if (databaseAccountGetResults == null)
            {
                return;
            }

            Id = databaseAccountGetResults.Id;
            Name = databaseAccountGetResults.Name;
            Tags = databaseAccountGetResults.Tags;
            Location = databaseAccountGetResults.Location;
            EnableCassandraConnector = databaseAccountGetResults.EnableCassandraConnector;
            FailoverPolicies = databaseAccountGetResults.FailoverPolicies;
            Locations = databaseAccountGetResults.Locations;
            ReadLocations = databaseAccountGetResults.ReadLocations;
            WriteLocations = databaseAccountGetResults.WriteLocations;
            Capabilities = databaseAccountGetResults.Capabilities;
            ConsistencyPolicy = databaseAccountGetResults.ConsistencyPolicy;
            EnableAutomaticFailover = databaseAccountGetResults.EnableAutomaticFailover;
            IsVirtualNetworkFilterEnabled = databaseAccountGetResults.IsVirtualNetworkFilterEnabled;
            IpRules = databaseAccountGetResults.IpRules;
            DatabaseAccountOfferType = databaseAccountGetResults.DatabaseAccountOfferType;
            DocumentEndpoint = databaseAccountGetResults.DocumentEndpoint;
            ProvisioningState = databaseAccountGetResults.ProvisioningState;
            Kind = databaseAccountGetResults.Kind;
            VirtualNetworkRules = databaseAccountGetResults.VirtualNetworkRules;
            EnableMultipleWriteLocations = databaseAccountGetResults.EnableMultipleWriteLocations;
            ConnectorOffer = databaseAccountGetResults.ConnectorOffer;
            DisableKeyBasedMetadataWriteAccess = databaseAccountGetResults.DisableKeyBasedMetadataWriteAccess;
            PublicNetworkAccess = databaseAccountGetResults.PublicNetworkAccess;
            KeyVaultKeyUri = databaseAccountGetResults.KeyVaultKeyUri;
            PrivateEndpointConnections = databaseAccountGetResults.PrivateEndpointConnections;
            EnableFreeTier = databaseAccountGetResults.EnableFreeTier;
            ApiProperties = new PSApiProperties(databaseAccountGetResults.ApiProperties);
            EnableAnalyticalStorage = databaseAccountGetResults.EnableAnalyticalStorage;
            NetworkAclBypass = databaseAccountGetResults.NetworkAclBypass;
            NetworkAclBypassResourceIds = databaseAccountGetResults.NetworkAclBypassResourceIds;
            BackupPolicy = new PSBackupPolicy(databaseAccountGetResults.BackupPolicy);
        }

        //
        //
        // Summary:
        //     Gets or sets the Id of the CosmosDB Account
        public string Id { get; set; }
        //
        //
        // Summary:
        //     Gets or sets the Name of the CosmosDB Account
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets Location of the Cosmos DB CosmosDB Account
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// Gets or sets Tags of the Cosmos DB CosmosDB Account
        /// </summary>
        public IDictionary<string, string> Tags { get; set; }
        //
        //
        // Summary:
        //     Gets or sets enables the cassandra connector on the Cosmos DB C* account
        public bool? EnableCassandraConnector { get; set; }
        //
        // Summary:
        //     Gets or sets enables the account to write in multiple locations
        public bool? EnableMultipleWriteLocations { get; set; }
        //
        // Summary:
        //     Gets or sets list of Virtual Network ACL rules configured for the Cosmos DB account.
        public IList<VirtualNetworkRule> VirtualNetworkRules { get; set; }
        //
        // Summary:
        //     Gets an array that contains the regions ordered by their failover priorities.
        public IList<FailoverPolicy> FailoverPolicies { get; }
        //
        // Summary:
        //     Gets an array that contains all of the locations enabled for the Cosmos DB account.
        public IList<Location> Locations { get; }
        //
        // Summary:
        //     Gets an array that contains of the read locations enabled for the Cosmos DB account.
        public IList<Location> ReadLocations { get; }
        //
        // Summary:
        //     Gets an array that contains the write location for the Cosmos DB account.
        public IList<Location> WriteLocations { get; }
        //
        // Summary:
        //     Gets or sets list of Cosmos DB capabilities for the account
        public IList<Capability> Capabilities { get; set; }
        //
        // Summary:
        //     Gets or sets the consistency policy for the Cosmos DB database account.
        public ConsistencyPolicy ConsistencyPolicy { get; set; }
        //
        // Summary:
        //     Gets or sets enables automatic failover of the write region in the rare event
        //     that the region is unavailable due to an outage. Automatic failover will result
        //     in a new write region for the account and is chosen based on the failover priorities
        //     configured for the account.
        public bool? EnableAutomaticFailover { get; set; }
        //
        // Summary:
        //     Gets or sets flag to indicate whether to enable/disable Virtual Network ACL rules.
        public bool? IsVirtualNetworkFilterEnabled { get; set; }
        //
        // Summary:
        //     Gets or sets list of IpRules.
        public IList<IpAddressOrRange> IpRules { get; set; }
        //
        // Summary:
        //     Gets the offer type for the Cosmos DB database account. Default value: Standard.
        //     Possible values include: 'Standard'
        public DatabaseAccountOfferType? DatabaseAccountOfferType { get; }
        //
        // Summary:
        //     Gets the connection endpoint for the Cosmos DB database account.
        public string DocumentEndpoint { get; }
        //
        public string ProvisioningState { get; set; }
        //
        // Summary:
        //     Gets or sets indicates the type of database account. This can only be set at
        //     database account creation. Possible values include: 'GlobalDocumentDB', 'MongoDB',
        //     'Parse'
        public string Kind { get; set; }
        //
        // Summary:
        //     Gets or sets the cassandra connector offer type for the Cosmos DB database C*
        //     account. Possible values include: 'Small'
        public string ConnectorOffer { get; set; }
        //
        // Summary:
        //     Gets or sets disable write operations on metadata resources (databases, containers,
        //     throughput) via account keys
        public bool? DisableKeyBasedMetadataWriteAccess { get; set; }
        //
        // Summary:
        //     Gets or sets Whether or not public endpoint access is allowed for this server.
        //     Possible values include: 'Enabled', 'Disabled'
        public string PublicNetworkAccess { get; set; }
        //
        // Summary:
        //     Gets or sets the URI of the key vault
        public string KeyVaultKeyUri { get; set; }
        //     Gets or sets list of Private Endpoint Connections configured for the Cosmos DB account.
        public IList<PrivateEndpointConnection> PrivateEndpointConnections { get; set; }
        //
        // Summary:
        //     Gets or sets flag to indicate whether Free Tier is enabled.
        public bool? EnableFreeTier { get; }
        //
        // Summary:
        //     Gets or sets API specific properties.
        public PSApiProperties ApiProperties { get; set; }
        //
        // Summary:
        //     Gets or sets flag to indicate whether to enable storage analytics.
        public bool? EnableAnalyticalStorage { get; set; }
        //
        // Summary:
        //     Gets or sets flag to indicate to allow Network Acl Bypass.
        public NetworkAclBypass? NetworkAclBypass { get; set; }
        //
        // Summary:
        //     Gets or sets list of Network Acl Bypass Resource Ids.
        public IList<string> NetworkAclBypassResourceIds { get; set; }
        //
        // Summary:
        //     Gets or sets the backup policy of the database account.
        public PSBackupPolicy BackupPolicy { get; set; }
    }
}
