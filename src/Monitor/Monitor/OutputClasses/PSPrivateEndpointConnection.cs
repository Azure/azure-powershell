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

using Microsoft.Rest;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Initializes a new instance of the PrivateEndpointConnection class.
    /// </summary>
    /// 
    [JsonTransformation]
    public class PSPrivateEndpointConnection
    {
        /// <summary>
        /// Initializes a new instance of the PrivateEndpointConnection class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="privateEndpoint">Private endpoint which the connection
        /// belongs to.</param>
        /// <param name="privateLinkServiceConnectionState">Connection state of
        /// the private endpoint connection.</param>
        /// <param name="provisioningState">State of the private endpoint
        /// connection.</param>
        public PSPrivateEndpointConnection(string id = default(string), string name = default(string), string type = default(string), PSPrivateEndpointProperty privateEndpoint = default(PSPrivateEndpointProperty), PSPrivateLinkServiceConnectionStateProperty privateLinkServiceConnectionState = default(PSPrivateLinkServiceConnectionStateProperty), string provisioningState = default(string))
        {
            Id = id;
            Name = name;
            Type = type;
            PrivateEndpoint = privateEndpoint;
            PrivateLinkServiceConnectionState = privateLinkServiceConnectionState;
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
        /// Gets or sets private endpoint which the connection belongs to.
        /// </summary>
        [JsonProperty(PropertyName = "properties.privateEndpoint")]
        public PSPrivateEndpointProperty PrivateEndpoint { get; set; }

        /// <summary>
        /// Gets or sets connection state of the private endpoint connection.
        /// </summary>
        [JsonProperty(PropertyName = "properties.privateLinkServiceConnectionState")]
        public PSPrivateLinkServiceConnectionStateProperty PrivateLinkServiceConnectionState { get; set; }

        /// <summary>
        /// Gets state of the private endpoint connection.
        /// </summary>
        [JsonProperty(PropertyName = "properties.provisioningState")]
        public string ProvisioningState { get; private set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (PrivateLinkServiceConnectionState != null)
            {
                PrivateLinkServiceConnectionState.Validate();
            }
        }
    }
}
