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
    using Rest.Serialization;

    public partial class PSVerificationCodeResponseProperties
    {
        /// <summary>
        /// Gets or sets verification code.
        /// </summary>
        [JsonProperty(PropertyName = "verificationCode")]
        public string VerificationCode { get; set; }

        /// <summary>
        /// Gets the certificate's subject name.
        /// </summary>
        [JsonProperty(PropertyName = "subject")]
        public string Subject { get; set; }

        /// <summary>
        /// Gets the certificate's expiration date and time.
        /// </summary>
        [JsonConverter(typeof(DateTimeRfc1123JsonConverter))]
        [JsonProperty(PropertyName = "expiry")]
        public System.DateTime? Expiry { get; private set; }

        /// <summary>
        /// Gets the certificate's thumbprint.
        /// </summary>
        [JsonProperty(PropertyName = "thumbprint")]
        public string Thumbprint { get; set; }

        /// <summary>
        /// Gets determines whether certificate has been verified.
        /// </summary>
        [JsonProperty(PropertyName = "isVerified")]
        public bool? IsVerified { get; set; }

        /// <summary>
        /// Gets the certificate's creation date and time.
        /// </summary>
        [JsonConverter(typeof(DateTimeRfc1123JsonConverter))]
        [JsonProperty(PropertyName = "created")]
        public System.DateTime? Created { get; private set; }

        /// <summary>
        /// Gets the certificate's last update date and time.
        /// </summary>
        [JsonConverter(typeof(DateTimeRfc1123JsonConverter))]
        [JsonProperty(PropertyName = "updated")]
        public System.DateTime? Updated { get; private set; }
    }
}
