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
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Sql.ManagedInstanceHybridLink.Model
{
    public class AzureSqlManagedInstanceLinkModel
    {
        /// <summary>
        /// Gets or sets resource group name
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets managed instance name
        /// </summary>
        public string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the instance link type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets instance link resource id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets instance link name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets name of the distributed availability group
        /// </summary>
        public string DistributedAvailabilityGroupName { get; set; }

        /// <summary>
        /// Gets ID of the distributed availability group
        /// </summary>
        public Guid? DistributedAvailabilityGroupId { get; set; }

        /// <summary>
        /// Gets or sets databases in the distributed availability group
        /// </summary>
        public IList<DistributedAvailabilityGroupDatabase> Databases { get; set; }

        /// <summary>
        /// Gets or sets managed instance side availability group name
        /// </summary>
        public string InstanceAvailabilityGroupName { get; set; }

        /// <summary>
        /// Gets or sets SQL server side availability group name
        /// </summary>
        public string PartnerAvailabilityGroupName { get; set; }

        /// <summary>
        /// Gets or sets SQL server side endpoint - IP or DNS resolvable name
        /// </summary>
        public string PartnerEndpoint { get; set; }

        /// <summary>
        /// Gets or sets managed instance side link role. Possible values
        /// include: 'Primary', 'Secondary'
        /// </summary>
        public string InstanceLinkRole { get; set; }

        /// <summary>
        /// Gets SQL server side link role. Possible values include: 'Primary',
        /// 'Secondary'
        /// </summary>
        public string PartnerLinkRole { get; set; }

        /// <summary>
        /// Gets or sets replication mode of the link. Possible values include:
        /// 'Async', 'Sync'
        /// </summary>
        public string ReplicationMode { get; set; }

        /// <summary>
        /// Gets or sets the link failover mode - can be Manual if intended to
        /// be used for two-way failover with a supported SQL Server, or None
        /// for one-way failover to Azure. Possible values include: 'None',
        /// 'Manual'
        /// </summary>
        public string FailoverMode { get; set; }

        /// <summary>
        /// Gets or sets database seeding mode – can be Automatic (default), or
        /// Manual for supported scenarios. Possible values include:
        /// 'Automatic', 'Manual'
        /// </summary>
        public string SeedingMode { get; set; }
    }
}
