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

using Microsoft.Azure.Management.CosmosDB.Models;

namespace Microsoft.Azure.Commands.CosmosDB.Models
{
    public class PSFleetspaceAccountGetResults
    {
        public PSFleetspaceAccountGetResults()
        {
        }

        public PSFleetspaceAccountGetResults(FleetspaceAccountResource fleetspaceAccountResource)
        {
            if (fleetspaceAccountResource == null)
            {
                return;
            }

            Name = fleetspaceAccountResource.Name;
            Id = fleetspaceAccountResource.Id;
            Type = fleetspaceAccountResource.Type;
            ProvisioningState = fleetspaceAccountResource.ProvisioningState;
            GlobalDatabaseAccountProperties = fleetspaceAccountResource.GlobalDatabaseAccountProperties;
        }

        /// <summary>
        /// Gets or sets Name of the Fleetspace Account
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Id of the Fleetspace Account
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets Type of the Fleetspace Account
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets Provisioning State of the Fleetspace Account
        /// </summary>
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Gets or sets Global Database Account Properties
        /// </summary>
        public FleetspaceAccountPropertiesGlobalDatabaseAccountProperties GlobalDatabaseAccountProperties { get; set; }
    }
}
