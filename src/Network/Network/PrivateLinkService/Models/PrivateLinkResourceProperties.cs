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

using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network.PrivateLinkService.Models
{
    /// <summary>
    /// Properties of a private link resource.
    /// </summary>
    public partial class PrivateLinkResourceProperties
    {
        /// <summary>
        /// Initializes a new instance of the PrivateLinkResourceProperties
        /// class.
        /// </summary>
        public PrivateLinkResourceProperties()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the PrivateLinkResourceProperties
        /// class.
        /// </summary>
        /// <param name="groupId">The private link resource group id.</param>
        /// <param name="requiredMembers">The private link resource required
        /// member names.</param>
        /// <param name="requiredZoneNames">The private link resource required zone names.</param>
        public PrivateLinkResourceProperties(string groupId = default(string), IList<string> requiredMembers = default(IList<string>), IList<string> requiredZoneNames = default(IList<string>))
        {
            GroupId = groupId;
            RequiredMembers = requiredMembers;
            RequiredZoneNames = requiredZoneNames;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets the private link resource group id.
        /// </summary>
        [JsonProperty(PropertyName = "groupId")]
        public string GroupId { get; private set; }

        /// <summary>
        /// Gets the private link resource required member names.
        /// </summary>
        [JsonProperty(PropertyName = "requiredMembers")]
        public IList<string> RequiredMembers { get; private set; }

        /// <summary>
        /// Gets the private link resource required zone names.
        /// </summary>
        [JsonProperty(PropertyName = "requiredZoneNames")]
        public IList<string> RequiredZoneNames { get; private set; }
    }
}
