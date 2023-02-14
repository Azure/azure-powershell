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
    using System;
    using System.Collections.Generic;
    using Microsoft.Azure.Devices.Provisioning.Service;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Representation of a single Device Provisioning Service enrollment.
    /// </summary>
    public class PSEnrollmentGroup
    {
        /// <summary>
        /// Enrollment Group ID.
        /// </summary>
        [JsonProperty(PropertyName = "enrollmentGroupId")]
        public string EnrollmentGroupId { get; set; }

        /// <summary>
        /// Current registration state.
        /// </summary>
        [JsonProperty(PropertyName = "registrationState", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public PSDeviceRegistrationState RegistrationState { get; private set; }

        /// <summary>
        /// Attestation
        /// </summary>
        [JsonIgnore]
        public PSAttestation Attestation { get; set; }

        /// <summary>
        /// Desired IotHub to assign the device to
        /// </summary>
        [JsonProperty(PropertyName = "iotHubHostName", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string IotHubHostName { get; set; }

        /// <summary>
        /// Initial twin state.
        /// </summary>
        [JsonProperty(PropertyName = "initialTwin", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public TwinState InitialTwinState { get; set; }

        /// <summary>
        /// The provisioning status.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "provisioningStatus", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public PSProvisioningStatus ProvisioningStatus { get; set; }

        /// <summary>
        /// The DateTime this resource was created.
        /// </summary>
        [JsonProperty(PropertyName = "createdDateTimeUtc", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime CreatedDateTimeUtc { get; private set; }

        /// <summary>
        /// The DateTime this resource was last updated.
        /// </summary>
        [JsonProperty(PropertyName = "lastUpdatedDateTimeUtc", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime LastUpdatedDateTimeUtc { get; private set; }

        /// <summary>
        /// Enrollment's ETag
        /// </summary>
        [JsonProperty(PropertyName = "etag", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ETag { get; set; }

        /// <summary>
        /// Capabilities of the device
        /// </summary>
        [JsonProperty(PropertyName = "capabilities", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public PSDeviceCapabilities Capabilities { get; set; }

        /// <summary> 
        /// The behavior when a device is re-provisioned to an IoT hub.
        /// </summary>
        [JsonProperty(PropertyName = "reprovisionPolicy", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public PSReprovisionPolicy ReprovisionPolicy { get; set; }

        /// <summary> 
        /// Custom allocation definition.  
        /// </summary>  
        [JsonProperty(PropertyName = "customAllocationDefinition", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public PSCustomAllocationDefinition CustomAllocationDefinition { get; set; }

        /// <summary> 
        /// The allocation policy of this resource. Overrides the tenant level allocation policy.
        /// </summary>
        [JsonProperty(PropertyName = "allocationPolicy", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public PSAllocationPolicy AllocationPolicy { get; set; }

        /// <summary> 
        /// The list of names of IoT hubs the device in this resource can be allocated to. Must be a subset of tenant level list of IoT hubs
        /// </summary>
        [JsonProperty(PropertyName = "iotHubs", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IList<string> IotHubs { get; set; }
    }

    public class PSEnrollmentGroups : PSEnrollmentGroup
    { }
}
