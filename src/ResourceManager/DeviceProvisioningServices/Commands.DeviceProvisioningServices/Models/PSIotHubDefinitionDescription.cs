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

namespace Microsoft.Azure.Commands.Management.DeviceProvisioningServices.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;

    /// <summary>
    /// Description of the IoT hub.
    /// </summary>
    public class PSIotHubDefinitionDescription
    {
        /// <summary>
        /// Gets or sets the property of ResourceGroupName
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the property of Iot Dps Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets flag for applying allocationPolicy or not for a given
        /// iot hub.
        /// </summary>
        [JsonProperty(PropertyName = "applyAllocationPolicy")]
        public bool? ApplyAllocationPolicy { get; set; }

        /// <summary>
        /// Gets or sets weight to apply for a given iot h.
        /// </summary>
        [JsonProperty(PropertyName = "allocationWeight")]
        public int? AllocationWeight { get; set; }

        /// <summary>
        /// Gets host name of the IoT hub.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string LinkedHubName { get; private set; }

        /// <summary>
        /// Gets or sets connection string og the IoT hub.
        /// </summary>
        [JsonProperty(PropertyName = "connectionString")]
        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets ARM region of the IoT hub.
        /// </summary>
        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }
    }
}
