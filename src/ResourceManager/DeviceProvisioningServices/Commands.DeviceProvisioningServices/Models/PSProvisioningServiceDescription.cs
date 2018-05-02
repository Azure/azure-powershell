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
    /// The description of the provisioning service.
    /// </summary>
    public class PSProvisioningServiceDescription : PSResource
    {
        /// <summary>
        /// Gets the property of ResourceGroupName
        /// </summary>
        public string ResourceGroupName
        {
            get
            {
                return IotDpsUtils.GetResourceGroupName(Id);
            }
        }

        /// <summary>
        /// Gets the property of Iot Dps Name
        /// </summary>
        public new string Name
        {
            get
            {
                return IotDpsUtils.GetIotDpsName(Id);
            }
        }

        /// <summary>
        /// Gets or sets the Etag field is *not* required. If it is provided in
        /// the response body, it must also be provided as a header per the
        /// normal ETag convention.
        /// </summary>
        [JsonProperty(PropertyName = "etag")]
        public string Etag { get; set; }

        /// <summary>
        /// Gets or sets service specific properties for a provisioning service
        /// </summary>
        [JsonProperty(PropertyName = "properties")]
        public PSIotDpsPropertiesDescription Properties { get; set; }

        /// <summary>
        /// Gets or sets sku info for a provisioning Service.
        /// </summary>
        [JsonProperty(PropertyName = "sku")]
        public PSIotDpsSkuInfo Sku { get; set; }
    }
}
