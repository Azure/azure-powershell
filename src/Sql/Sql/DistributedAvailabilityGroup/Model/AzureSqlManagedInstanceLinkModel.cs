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

using System;

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
        /// Gets or sets target database
        /// </summary>
        public string TargetDatabase { get; set; }

        /// <summary>
        /// Gets or sets source endpoint
        /// </summary>
        public string SourceEndpoint { get; set; }

        /// <summary>
        /// Gets or sets primary availability group name
        /// </summary>
        public string PrimaryAvailabilityGroupName { get; set; }

        /// <summary>
        /// Gets or sets secondary availability group name
        /// </summary>
        public string SecondaryAvailabilityGroupName { get; set; }

        /// <summary>
        /// Gets or sets replication mode
        /// </summary>
        public string ReplicationMode { get; set; }

        /// <summary>
        /// Gets or sets distributed availability group id
        /// </summary>
        public Guid? DistributedAvailabilityGroupId { get; set; }

        /// <summary>
        /// Gets or sets source replica id
        /// </summary>
        public Guid? SourceReplicaId { get; set; }

        /// <summary>
        /// Gets or sets target replica id
        /// </summary>
        public Guid? TargetReplicaId { get; set; }

        /// <summary>
        /// Gets or sets link state
        /// </summary>
        public string LinkState { get; set; }

        /// <summary>
        /// Gets or sets last hardened numbers
        /// </summary>
        public string LastHardenedLsn { get; set; }
    }
}
