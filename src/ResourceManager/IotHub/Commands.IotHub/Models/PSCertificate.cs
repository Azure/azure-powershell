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

namespace Microsoft.Azure.Commands.Management.IotHub.Models
{
    using Common;
    using Newtonsoft.Json;

    public class PSCertificate
    {
        /// <summary>
        /// Gets the property of ResourceGroupName
        /// </summary>
        public string ResourceGroupName
        {
            get
            {
                return IotHubUtils.GetResourceGroupName(Id);
            }
        }

        /// <summary>
        /// Gets the property of Iot Hub Name
        /// </summary>
        public string Name
        {
            get
            {
                return IotHubUtils.GetIotHubName(Id);
            }
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "properties")]
        public PSCertificateProperties Properties { get; set; }

        /// <summary>
        /// Gets the resource identifier.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; private set; }

        /// <summary>
        /// Gets the name of the certificate.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string CertificateName { get; private set; }

        /// <summary>
        /// Gets the entity tag.
        /// </summary>
        [JsonProperty(PropertyName = "etag")]
        public string Etag { get; private set; }

        /// <summary>
        /// Gets the resource type.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; private set; }
    }
}
