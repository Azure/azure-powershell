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
    public partial class PSSharedAccessSignatureAuthorizationRuleAccessRightsDescription
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
        /// Gets or sets name of the key.
        /// </summary>
        [JsonProperty(PropertyName = "keyName")]
        public string KeyName { get; set; }

        /// <summary>
        /// Gets or sets primary SAS key value.
        /// </summary>
        [JsonProperty(PropertyName = "primaryKey")]
        public string PrimaryKey { get; set; }

        /// <summary>
        /// Gets or sets secondary SAS key value.
        /// </summary>
        [JsonProperty(PropertyName = "secondaryKey")]
        public string SecondaryKey { get; set; }

        /// <summary>
        /// Gets or sets rights that this key has. Possible values include:
        /// 'ServiceConfig', 'EnrollmentRead', 'EnrollmentWrite',
        /// 'DeviceConnect', 'RegistrationStatusRead',
        /// 'RegistrationStatusWrite'
        /// </summary>
        [JsonProperty(PropertyName = "rights")]
        public string Rights { get; set; }
    }
}
