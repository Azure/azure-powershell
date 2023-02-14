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
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// the service specific properties of a provisoning service, including
    /// keys, linked iot hubs, current state, and system generated properties
    /// such as hostname and idScope
    /// </summary>
    public partial class PSIotDpsPropertiesDescription
    {
        /// <summary>
        /// Gets or sets current state of the provisioning service. Possible
        /// values include: 'Activating', 'Active', 'Deleting', 'Deleted',
        /// 'ActivationFailed', 'DeletionFailed', 'Transitioning',
        /// 'Suspending', 'Suspended', 'Resuming', 'FailingOver',
        /// 'FailoverFailed'
        /// </summary>
        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the ARM provisioning state of the provisioning
        /// service.
        /// </summary>
        [JsonProperty(PropertyName = "provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Gets or sets list of IoT hubs assosciated with this provisioning
        /// service.
        /// </summary>
        [JsonProperty(PropertyName = "iotHubs")]
        public IList<PSIotHubDefinitionDescription> IotHubs { get; set; }

        /// <summary>
        /// Gets or sets allocation policy to be used by this provisioning
        /// service. Possible values include: 'Hashed', 'GeoLatency', 'Static'
        /// </summary>
        [JsonProperty(PropertyName = "allocationPolicy")]
        public string AllocationPolicy { get; set; }

        /// <summary>
        /// Gets service endpoint for provisioning service.
        /// </summary>
        [JsonProperty(PropertyName = "serviceOperationsHostName")]
        public string ServiceOperationsHostName { get; private set; }

        /// <summary>
        /// Gets device endpoint for this provisioning service.
        /// </summary>
        [JsonProperty(PropertyName = "deviceProvisioningHostName")]
        public string DeviceProvisioningHostName { get; private set; }

        /// <summary>
        /// Gets unique identifier of this provisioning service.
        /// </summary>
        [JsonProperty(PropertyName = "idScope")]
        public string IdScope { get; private set; }

        /// <summary>
        /// Gets or sets list of authorization keys for a provisioning service.
        /// </summary>
        [JsonProperty(PropertyName = "authorizationPolicies")]
        public IList<PSSharedAccessSignatureAuthorizationRuleAccessRightsDescription> AuthorizationPolicies { get; set; }
    }
}
