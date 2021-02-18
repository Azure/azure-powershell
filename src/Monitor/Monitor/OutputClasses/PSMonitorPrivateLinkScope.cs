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
    /// <summary>
    /// wrapper class for Microsoft.Azure.Management.Monitor.Models.AzureMonitorPrivateLinkScope
    /// </summary>
    public class PSMonitorPrivateLinkScope
    {
        public PSMonitorPrivateLinkScope() { }

        public PSMonitorPrivateLinkScope(string location, IDictionary<string, string> tags = default(IDictionary<string, string>), string id = default(string), string name = default(string), string type = default(string), string provisioningState = default(string), IList<PSPrivateEndpointConnection> privateEndpointConnections = default(IList<PSPrivateEndpointConnection>))
        {
            this.Id = id;
            this.Name = name;
            this.Type = type;
            this.Location = location;
            this.Tags = tags;
            this.ProvisioningState = provisioningState;
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
        /// Gets or sets resource location
        /// </summary>
        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets resource tags
        /// </summary>
        [JsonProperty(PropertyName = "tags")]
        public IDictionary<string, string> Tags { get; set; }

        /// <summary>
        /// Gets current state of this PrivateLinkScope: whether or not is has
        /// been provisioned within the resource group it is defined. Users
        /// cannot change this value but are able to read from it. Values will
        /// include Provisioning ,Succeeded, Canceled and Failed.
        /// </summary>
        [JsonProperty(PropertyName = "properties.provisioningState")]
        public string ProvisioningState { get; private set; }
    }
}
