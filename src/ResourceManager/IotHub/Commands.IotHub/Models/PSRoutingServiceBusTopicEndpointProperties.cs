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

    /// <summary>
    /// The properties related to service bus topic endpoint types.
    /// </summary>
    public partial class PSRoutingServiceBusTopicEndpointProperties
    {
        /// <summary>
        /// The connection string of the service bus topic endpoint.
        /// </summary>
        [JsonProperty(PropertyName = "connectionString")]
        public string ConnectionString { get; set; }

        /// <summary>
        /// The name of the service bus topic endpoint.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The subscription identifier of the service bus topic endpoint.
        /// </summary>
        [JsonProperty(PropertyName = "subscriptionId")]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// The name of the resource group of the service bus topic endpoint.
        /// </summary>
        [JsonProperty(PropertyName = "resourceGroup")]
        public string ResourceGroup { get; set; }
    }

    /// <summary>
    /// The properties related to service bus topic endpoint type.
    /// </summary>
    public partial class PSRoutingServiceBusTopicEndpoint : PSRoutingServiceBusTopicEndpointProperties
    {
    }
}
