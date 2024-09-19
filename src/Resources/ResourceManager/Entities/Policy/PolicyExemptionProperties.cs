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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Policy
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;

    /// <summary>
    /// The policy exemption properties.
    /// </summary>
    public class PolicyExemptionProperties
    {
        /// <summary>
        /// Gets or sets the policy assignment Id associated with the policy exemption.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string PolicyAssignmentId { get; set; }

        /// <summary>
        /// Gets or sets the policy definition reference Ids when the associated policy assignment is for a policy set (initiative).
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string[] PolicyDefinitionReferenceIds { get; set; }

        /// <summary>
        /// Gets or sets the policy exemption category.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string ExemptionCategory { get; set; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the policy exemption expiration.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public DateTime? ExpiresOn { get; set; }

        /// <summary>
        /// Gets or sets the metadata.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public JObject Metadata { get; set; }
    }
}