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

using Microsoft.Azure.Management.EventHub.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.EventHub.Models
{

    public class EventHubDRConfigurationAttributes
    {
        public EventHubDRConfigurationAttributes()
        { }

        public EventHubDRConfigurationAttributes(ArmDisasterRecovery drResource)
        {
            if (drResource != null)
            {
                Name = drResource.Name;
                Id = drResource.Id;
                Type = drResource.Type;
                ProvisioningState = drResource.ProvisioningState;
                PartnerNamespace = drResource.PartnerNamespace;
                Role = drResource.Role;
                ArmDisasterRecoveryType = drResource.ArmDisasterRecoveryType;
                LastSynced = drResource.LastSynced;
            }
        }
        
        public string Name { get; set; }

        public string Id { get; set; }

        public string Type { get; set; }

        /// <summary>
        /// Gets provisioning state of the disaster recovery
        /// </summary>
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates partner namespace
        /// </summary>
        public string PartnerNamespace { get; set; }

        /// <summary>
        /// Gets enumerates the possible values for the encoding format of
        /// capture description. Possible values include: 'Unspecified',
        /// 'Primary', 'PrimaryNotReplicating', 'Secondary'
        /// </summary>
        public RoleDisasterRecovery? Role { get;  set; }

        /// <summary>
        /// Gets enumerates the possible values for the encoding format of
        /// capture description. Possible values include:
        /// 'MetadataReplication', 'DataReplication'
        /// </summary>
        public ReplicationType? ArmDisasterRecoveryType { get;  set; }

        /// <summary>
        /// Gets time of Last Synced
        /// </summary>
        public System.DateTime? LastSynced { get;  set; }
    }
}
