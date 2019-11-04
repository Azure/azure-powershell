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
    using Microsoft.Azure.Management.CosmosDB.Fluent.Models;

    public class PSDatabaseAccount
    {
        public PSDatabaseAccount()
        {
        }        
        
        public PSDatabaseAccount(DatabaseAccountInner databaseAccountInner)
        {
            Id = databaseAccountInner.Id;
            Name = databaseAccountInner.Name;
            FailoverPolicies = databaseAccountInner.FailoverPolicies;
            ReadLocations = databaseAccountInner.ReadLocations;
            WriteLocations = databaseAccountInner.WriteLocations;
            Capabilities = databaseAccountInner.Capabilities;
            ConsistencyPolicy = databaseAccountInner.ConsistencyPolicy;
            EnableAutomaticFailover = databaseAccountInner.EnableAutomaticFailover;
            IsVirtualNetworkFilterEnabled = databaseAccountInner.IsVirtualNetworkFilterEnabled;
            IpRangeFilter = databaseAccountInner.IpRangeFilter;
            DatabaseAccountOfferType = databaseAccountInner.DatabaseAccountOfferType;
            DocumentEndpoint = databaseAccountInner.DocumentEndpoint;
            ProvisioningState = databaseAccountInner.ProvisioningState;
            Kind = databaseAccountInner.Kind;
            VirtualNetworkRules = databaseAccountInner.VirtualNetworkRules;
            EnableMultipleWriteLocations = databaseAccountInner.EnableMultipleWriteLocations;
        }

        //
        // Summary:
        //     Gets or sets ResourceId
        public string Id { get; set; }
        //
        // Summary:
        //     Gets or sets Resource Name
        public string Name { get; set; }
        //
        // Summary:
        //     Gets or sets an array that contains the regions ordered by their failover priorities.
        public IList<FailoverPolicyInner> FailoverPolicies { get; set; }
        //
        // Summary:
        //     Gets or sets an array that contains of the read locations enabled for the Cosmos DB account.
        public IList<Location> ReadLocations { get; set; }
        //
        // Summary:
        //     Gets or sets an array that contains the write location for the Cosmos DB account.
        public IList<Location> WriteLocations { get; set; }
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
        //     Gets or sets cosmos DB Firewall Support: This value specifies the set of IP addresses
        //     or IP address ranges in CIDR form to be included as the allowed list of client
        //     IPs for a given database account. IP addresses/ranges must be comma separated
        //     and must not contain any spaces.
        public string IpRangeFilter { get; set; }
        //
        // Summary:
        //     Gets or sets the offer type for the Cosmos DB database account. Default value: Standard.
        //     Possible values include: 'Standard'
        public DatabaseAccountOfferType? DatabaseAccountOfferType { get; set; }
        //
        // Summary:
        //     Gets or sets the connection endpoint for the Cosmos DB database account.
        public string DocumentEndpoint { get; set; }
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
        //     Gets or sets list of Virtual Network ACL rules configured for the Cosmos DB account.
        public IList<VirtualNetworkRule> VirtualNetworkRules { get; set; }
        //
        // Summary:
        //     Gets or sets enables the account to write in multiple locations
        public bool? EnableMultipleWriteLocations { get; set; }

    }
}
