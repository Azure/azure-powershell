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

using Microsoft.Azure.Management.Sql.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Sql.InstanceFailoverGroup.Model
{
    public class AzureSqlInstanceFailoverGroupModel
    {
        /// <summary>
        /// template to generate the Primary Managed Instance Id
        /// </summary>
        public const string PrimaryManagedInstanceIdTemplate = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Sql/ManagedInstances/{2}";
        
        /// <summary>
        /// template to generate the Partner Managed Instance Id
        /// </summary>
        public const string PartnerManagedInstanceIdTemplate = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Sql/ManagedInstances/{2}";

        /// <summary>
        /// Gets or sets the name of the resource group
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the primary location
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the name of the Instance Failover Group.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the read-write endpoint
        /// </summary>
        public InstanceFailoverGroupReadWriteEndpoint ReadWriteEndpoint { get; set; }

        /// <summary>
        /// Gets or sets the read-only endpoint
        /// </summary>
        public InstanceFailoverGroupReadOnlyEndpoint ReadOnlyEndpoint { get; set; }

        /// <summary>
        /// Gets or sets the partner servers
        /// </summary>
        public IList<PartnerRegionInfo> PartnerRegions { get; set; }

        /// <summary>
        /// Gets or sets the name of the partner resource group name
        /// </summary>
        public string PartnerResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the partner server name
        /// </summary>
        public PartnerRegionInfo PartnerRegion { get; set; }

        /// <summary>
        /// Gets or sets the managed instance on the primary region
        /// </summary>
        public string PrimaryManagedInstanceName { get; set; }
        
        /// <summary>
        /// Gets or sets the managed instance on the partner region
        /// </summary>
        public string PartnerManagedInstanceName { get; set; }
        
        /// <summary>
        /// Gets or sets the managed instance ids in pairs
        /// </summary>
        public IList<ManagedInstancePairInfo> ManagedInstancePairs { get; internal set; }
        
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
        /// Gets or sets the Id of the Instance Failover Group
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the location of the Instance Failover Group
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public AzureSqlInstanceFailoverGroupModel()
        {
        }

        /// <summary>
        /// Construct AzureSqlServerfailoverGroupModel from Management.Sql.LegacySdk.Models.FailoverGroup object
        /// </summary>
        /// <param name="resourceGroupName">Resource group</param>
        /// <param name="location">Server name</param>
        /// <param name="failoverGroup">Recommended Action object</param>
        public AzureSqlInstanceFailoverGroupModel(string resourceGroupName, string location, string failoverGroupName, Management.Sql.Models.InstanceFailoverGroup failoverGroup)
        {
            ResourceGroupName = resourceGroupName;
            Location = location;
            Name = failoverGroupName;
            Id = failoverGroup.Id;
            ReadWriteFailoverPolicy = failoverGroup.ReadWriteEndpoint.FailoverPolicy;
            ReadOnlyFailoverPolicy = failoverGroup.ReadOnlyEndpoint.FailoverPolicy;
            FailoverWithDataLossGracePeriodHours = failoverGroup.ReadWriteEndpoint.FailoverWithDataLossGracePeriodMinutes / 60;
            PartnerRegions = failoverGroup.PartnerRegions;
            ManagedInstancePairs = failoverGroup.ManagedInstancePairs;
            ReplicationRole = failoverGroup.ReplicationRole;
            ReplicationState = failoverGroup.ReplicationState;
        }
    }
}
