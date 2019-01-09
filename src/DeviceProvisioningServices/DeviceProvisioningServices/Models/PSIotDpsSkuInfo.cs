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
    using Newtonsoft.Json;

    /// <summary>
    /// List of possible provisoning service SKUs.
    /// </summary>
    public partial class PSIotDpsSkuInfo
    {
        /// <summary>
        /// Gets or sets sku name. Possible values include: 'S1'
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets pricing tier name of the provisioning service.
        /// </summary>
        [JsonProperty(PropertyName = "tier")]
        public string Tier { get; private set; }

        /// <summary>
        /// Gets or sets the number of units to provision
        /// </summary>
        [JsonProperty(PropertyName = "capacity")]
        public long? Capacity { get; set; }
    }
}
