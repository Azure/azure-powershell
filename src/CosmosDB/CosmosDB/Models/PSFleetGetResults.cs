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
    public class PSFleetGetResults
    {
        public PSFleetGetResults()
        {
        }

        public PSFleetGetResults(FleetResource fleetResource)
        {
            if (fleetResource == null)
            {
                return;
            }

            Name = fleetResource.Name;
            Id = fleetResource.Id;
            Type = fleetResource.Type;
            Tags = fleetResource.Tags;
            Properties = fleetResource.ProvisioningState != null ? new PSFleetProperties(fleetResource.ProvisioningState) : null;
        }

        /// <summary>
        /// Gets or sets Name of the Cosmos DB Fleet
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Id of the Cosmos DB Fleet
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets Type of the Cosmos DB Fleet
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets Tags of the Cosmos DB Fleet
        /// </summary>
        public IDictionary<string, string> Tags { get; set; }

        /// <summary>
        /// Gets or sets Properties of the Cosmos DB Fleet
        /// </summary>
        public PSFleetProperties Properties { get; set; }
    }

    public class PSFleetProperties
    {
        public PSFleetProperties()
        {
        }

        public PSFleetProperties(string provisioningState)
        {
            ProvisioningState = provisioningState;
        }

        /// <summary>
        /// Gets or sets Provisioning State of the Fleet
        /// </summary>
        public string ProvisioningState { get; set; }
    }
}
