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
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class PSSharedAccessAuthorizationRule
    {
        /// <summary>
        /// The key name.
        /// </summary>
        [JsonProperty(PropertyName = "KeyName")]
        public string KeyName { get; set; }

        /// <summary>
        /// The primary key.
        /// </summary>
        [JsonProperty(PropertyName = "PrimaryKey")]
        public string PrimaryKey { get; set; }

        /// <summary>
        /// The issuer name.
        /// </summary>
        [JsonProperty(PropertyName = "IssuerName")]
        public string IssuerName { get; set; }

        /// <summary>
        /// The secondary key.
        /// </summary>
        [JsonProperty(PropertyName = "SecondaryKey")]
        public string SecondaryKey { get; set; }

        /// <summary>
        /// The claim type.
        /// </summary>
        [JsonProperty(PropertyName = "ClaimType")]
        public string ClaimType { get; set; }

        /// <summary>
        /// The claim value.
        /// </summary>
        [JsonProperty(PropertyName = "ClaimValue")]
        public string ClaimValue { get; set; }

        /// <summary>
        /// The rights.
        /// </summary>
        [JsonProperty(PropertyName = "Rights")]
        public IList<PSSBAccessRights?> Rights { get; set; }

        /// <summary>
        /// The created time.
        /// </summary>
        [JsonProperty(PropertyName = "CreatedTime")]
        public DateTime? CreatedTime { get; set; }

        /// <summary>
        /// The modified time.
        /// </summary>
        [JsonProperty(PropertyName = "ModifiedTime")]
        public DateTime? ModifiedTime { get; set; }

        /// <summary>
        /// The revision.
        /// </summary>
        [JsonProperty(PropertyName = "Revision")]
        public long? Revision { get; set; }
    }
}
