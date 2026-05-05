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
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.CosmosDB.Models
{
    public class PSFleetspaceGetResults
    {
        public PSFleetspaceGetResults()
        {
        }

        public PSFleetspaceGetResults(FleetspaceResource fleetspaceResource)
        {
            if (fleetspaceResource == null)
            {
                return;
            }

            Name = fleetspaceResource.Name;
            Id = fleetspaceResource.Id;
            Type = fleetspaceResource.Type;
            ProvisioningState = fleetspaceResource.ProvisioningState;
            FleetspaceApiKind = fleetspaceResource.FleetspaceApiKind;
            ServiceTier = fleetspaceResource.ServiceTier;
            DataRegions = fleetspaceResource.DataRegions;
            ThroughputPoolConfiguration = fleetspaceResource.ThroughputPoolConfiguration;
        }

        /// <summary>
        /// Gets or sets Name of the Fleetspace
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Id of the Fleetspace
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets Type of the Fleetspace
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets Provisioning State of the Fleetspace
        /// </summary>
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Gets or sets API Kind of the Fleetspace
        /// </summary>
        public string FleetspaceApiKind { get; set; }

        /// <summary>
        /// Gets or sets Service Tier of the Fleetspace
        /// </summary>
        public string ServiceTier { get; set; }

        /// <summary>
        /// Gets or sets Data Regions of the Fleetspace
        /// </summary>
        public IList<string> DataRegions { get; set; }

        /// <summary>
        /// Gets or sets Throughput Pool Configuration of the Fleetspace
        /// </summary>
        public FleetspacePropertiesThroughputPoolConfiguration ThroughputPoolConfiguration { get; set; }
    }
}
