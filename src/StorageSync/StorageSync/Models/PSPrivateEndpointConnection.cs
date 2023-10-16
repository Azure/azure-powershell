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

namespace Microsoft.Azure.Commands.StorageSync.Models
{
    /// <summary>
    /// Class PSPrivateEndpointConnection.
    /// </summary>
    public class PSPrivateEndpointConnection
    {
        /// <summary>
        /// Gets the resource identifier.
        /// </summary>
        /// <value>The resource identifier.</value>
        public string ResourceId { get; internal set; }

        /// <summary>
        /// Gets the private endpoint connection name.
        /// </summary>
        /// <value></value>
        public string PrivateEndpointConnectionName { get; internal set; }
        
        /// <summary>
        /// Gets the private endpoint.
        /// </summary>
        /// <value></value>
        public PSPrivateEndpoint PrivateEndpoint { get; internal set; }

        /// <summary>
        /// Gets the private linke service connection state.
        /// </summary>
        /// <value></value>
        public PSPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get; internal set; }

        /// <summary>
        /// Gets the provisioning state.
        /// </summary>
        /// <value></value>
        public string ProvisioningState { get; internal set; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value></value>
        public string Type { get; internal set; }

        /// <summary>
        /// Gets or sets the SystemData.
        /// </summary>
        /// <value>The SystemData.</value>
        public PSSystemData SystemData { get; set; }

        /// <summary>
        /// Group Identifier list
        /// </summary>
        public IList<string> GroupIds { get; set; }
    }
}