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

using System.Collections.Generic;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    public class PSMonitorPrivateLinkScopedResource
    {
        public PSMonitorPrivateLinkScopedResource(string id = default(string), string name = default(string), string type = default(string), string linkedResourceId = default(string), string provisioningState = default(string))
        {
            Id = id;
            Name = name;
            Type = type;
            LinkedResourceId = linkedResourceId;
            ProvisioningState = provisioningState;
        }

        /// <summary>
        /// Gets azure resource Id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; private set; }

        /// <summary>
        /// Gets azure resource name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; private set; }

        /// <summary>
        /// Gets azure resource type
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; private set; }

        /// <summary>
        /// Gets or sets the resource id of the scoped Azure monitor resource.
        /// </summary>
        [JsonProperty(PropertyName = "properties.linkedResourceId")]
        public string LinkedResourceId { get; set; }

        /// <summary>
        /// Gets state of the private endpoint connection.
        /// </summary>
        [JsonProperty(PropertyName = "properties.provisioningState")]
        public string ProvisioningState { get; private set; }
    }
}
