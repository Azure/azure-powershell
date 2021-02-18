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
    /// Description of the shared access key.
    /// </summary>
    public class PSSymmetricKeyAttestation : PSAttestation
    {
        /// <summary>
        /// Gets the primary key used for attestation.
        /// </summary>
        [JsonProperty(PropertyName = "primaryKey", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string PrimaryKey { get; set; }

        /// <summary>
        /// Gets the secondary key used for attestation.
        /// </summary>
        [JsonProperty(PropertyName = "secondaryKey", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string SecondaryKey { get; set; }
    }
}
