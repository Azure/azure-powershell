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
    using Microsoft.Rest.Azure;
    using Newtonsoft.Json;

    /// <summary>
    /// Description of the response of the verification code.
    /// </summary>
    public partial class PSVerificationCodeResponse : IResource
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
        public string Name
        {
            get
            {
                return IotDpsUtils.GetIotDpsName(Id);
            }
        }

        /// <summary>
        /// Gets name of certificate.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string CertificateName { get; private set; }

        /// <summary>
        /// Gets request etag.
        /// </summary>
        [JsonProperty(PropertyName = "etag")]
        public string Etag { get; private set; }

        /// <summary>
        /// Gets the resource identifier.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; private set; }

        /// <summary>
        /// Gets the resource type.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "properties")]
        public PSVerificationCodeResponseProperties Properties { get; set; }
    }
}
