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

using Microsoft.Azure.Management.Sql.LegacySdk.Models;
using Microsoft.Azure.Management.Sql.Models;
using System.Collections.Generic;
using System;

namespace Microsoft.Azure.Commands.Sql.FailoverGroup.Model
{
    public class AzureSqlFailoverGroupModel
    {
        /// <summary>
        /// template to generate the Source Database Id
        /// </summary>
        public static string PartnerServerIdTemplate = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Sql/Servers/{2}";

        /// <summary>
        /// Gets or sets the name of the resource group
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the server
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the failover group.
        /// </summary>
        public string FailoverGroupName { get; set; }

        /// <summary>
        /// Gets or sets the read-write endpoint
        /// </summary>
        public ReadWriteEndpoint FailoverGroupReadWriteEndpoint { get; set; }

        /// <summary>
        /// Gets or sets the read-only endpoint (legacy field)
        /// </summary>
        public ReadOnlyEndpoint FailoverGroupReadOnlyEndpoint { get; set; }

        /// <summary>
        /// Gets or sets the read-only endpoint.
        /// This field is used in the newest client and has support for multiple-partner FG's.
        /// </summary>
        public FailoverGroupReadOnlyEndpoint FailoverGroupReadOnlyEndpointV2 { get; set; }

        /// <summary>
        /// Gets or sets the read-write endpoint.
        /// This field is used in the newest client and has support for multiple-partner FG's.
        /// </summary>
        public FailoverGroupReadWriteEndpoint FailoverGroupReadWriteEndpointV2 { get; set; }

        /// <summary>
        /// Gets or sets the partner servers
        /// </summary>
        public IList<FailoverGroupPartnerServer> PartnerServers { get; set; }

        /// <summary>
        /// Gets or sets the Id of partner subscription id
        /// </summary>
        public string PartnerSubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the name of the partner resource group name
        /// </summary>
        public string PartnerResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the partner server name
        /// </summary>
        public string PartnerServerName { get; set; }

        /// <summary>
        /// Gets or sets the partner server's location
        /// </summary>
        public string PartnerLocation { get; set; }

        /// <summary>
        /// Gets or sets the database IDs
        /// </summary>
        public IList<string> Databases { get; internal set; }

        /// <summary>
        /// Gets or sets the list of names of databases in the Failover Group
        /// </summary>
        public IList<string> DatabaseNames { get; internal set; }

        /// <summary>
        /// Gets or sets the read-write endpoint
        /// </summary>
        public string ReplicationRole { get; set; }

        /// <summary>
        /// Gets or sets the read-write endpoint
        /// </summary>
        public string ReplicationState { get; set; }

        /// <summary>
        /// Gets or sets the read-write endpoint failover policy
        /// </summary>
        public string ReadWriteFailoverPolicy { get; set; }

        /// <summary>
        /// Gets or sets the read-write endpoint failover grace period with data loss
        /// </summary>
        public int? FailoverWithDataLossGracePeriodHours { get; set; }

        /// <summary>
        /// Gets or sets the read-only endpoint failover policy
        /// </summary>
        public string ReadOnlyFailoverPolicy { get; set; }

        /// <summary>
        /// Gets or sets the databases secondary type on partner server.
        /// </summary>
        public string SecondaryType { get; set; }

        /// <summary>
        /// Gets or sets the Id of the failover group
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the location of the failover group
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the location of the failover group
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// Gets or sets the tags associated with the Failover Group.
        /// </summary>
        public Dictionary<string, string> Tags { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public AzureSqlFailoverGroupModel()
        {
        }

        /// <summary>
        /// Construct AzureSqlServerfailoverGroupModel from Management.Sql.LegacySdk.Models.FailoverGroup object
        /// </summary>
        /// <param name="resourceGroupName">Resource group</param>
        /// <param name="serverName">Server name</param>
        /// <param name="failoverGroupName">The name of the Azure Sql Database FailoverGroup</param>
        /// <param name="failoverGroup">Recommended Action object</param>
        public AzureSqlFailoverGroupModel(string resourceGroupName, string serverName, string failoverGroupName, Management.Sql.LegacySdk.Models.FailoverGroup failoverGroup)
        {
            ResourceGroupName = resourceGroupName;
            ServerName = serverName;
            FailoverGroupName = failoverGroup.Name;
            Id = failoverGroup.Id;
            Location = failoverGroup.Location;
            ReadWriteFailoverPolicy = failoverGroup.Properties.ReadWriteEndpoint.FailoverPolicy;
            ReadOnlyFailoverPolicy = failoverGroup.Properties.ReadOnlyEndpoint.FailoverPolicy;
            FailoverWithDataLossGracePeriodHours = failoverGroup.Properties.ReadWriteEndpoint.FailoverWithDataLossGracePeriodMinutes / 60;
            PartnerServers = failoverGroup.Properties.PartnerServers;
            Databases = failoverGroup.Properties.Databases;
            ReplicationRole = failoverGroup.Properties.ReplicationRole;
            ReplicationState = failoverGroup.Properties.ReplicationState;
        }
    }
}
