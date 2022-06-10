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
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Network.PrivateLinkService.Models
{
    /// <summary>
    /// A private endpoint connection
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class PrivateEndpointConnection : ProxyResource
    {
        /// <summary>
        /// Initializes a new instance of the PrivateEndpointConnection class.
        /// </summary>
        public PrivateEndpointConnection()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the PrivateEndpointConnection class.
        /// </summary>
        /// <param name="id">Resource ID.</param>
        /// <param name="name">Resource name.</param>
        /// <param name="type">Resource type.</param>
        /// <param name="privateEndpoint">Private endpoint which the connection
        /// belongs to.</param>
        /// <param name="privateLinkServiceConnectionState">Connection state of
        /// the private endpoint connection.</param>
        /// <param name="provisioningState">State of the private endpoint
        /// connection.</param>
        /// <param name="groupId">Group ID of the private endpoint.</param>
        public PrivateEndpointConnection(string id = default(string), string name = default(string), string type = default(string), PrivateEndpointProperty privateEndpoint = default(PrivateEndpointProperty), PrivateLinkServiceConnectionStateProperty privateLinkServiceConnectionState = default(PrivateLinkServiceConnectionStateProperty), string provisioningState = default(string), string groupId = default(string))
            : base(id, name, type)
        {
            PrivateEndpoint = privateEndpoint;
            PrivateLinkServiceConnectionState = privateLinkServiceConnectionState;
            ProvisioningState = provisioningState;
            GroupId = groupId;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets private endpoint which the connection belongs to.
        /// </summary>
        [JsonProperty(PropertyName = "properties.privateEndpoint")]
        public PrivateEndpointProperty PrivateEndpoint { get; set; }

        /// <summary>
        /// Gets or sets connection state of the private endpoint connection.
        /// </summary>
        [JsonProperty(PropertyName = "properties.privateLinkServiceConnectionState")]
        public PrivateLinkServiceConnectionStateProperty PrivateLinkServiceConnectionState { get; set; }

        /// <summary>
        /// Gets state of the private endpoint connection.
        /// </summary>
        [JsonProperty(PropertyName = "properties.provisioningState")]
        public string ProvisioningState { get; private set; }

        /// <summary>
        /// Gets group id of the private endpoint.
        /// </summary>
        [JsonProperty(PropertyName = "properties.groupId")]
        public string GroupId { get; private set; }

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
