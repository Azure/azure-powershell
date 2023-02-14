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
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Used to specify the authentication mechanism used by a device.
    /// </summary>
    public class PSAuthenticationMechanism
    {
        /// <summary>
        /// Gets or sets the <see cref="SymmetricKey"/> used for Authentication
        /// </summary>
        [JsonProperty(PropertyName = "symmetricKey")]
        public PSSymmetricKey SymmetricKey { get; set; }

        /// <summary>
        /// Gets or sets the X509 client certificate thumbprint.
        /// </summary>
        [JsonProperty(PropertyName = "x509Thumbprint")]
        public PSX509Thumbprint X509Thumbprint { get; set; }

        /// <summary>
        /// Gets or sets the authentication type.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public PSAuthenticationType Type { get; set; }
    }
}
