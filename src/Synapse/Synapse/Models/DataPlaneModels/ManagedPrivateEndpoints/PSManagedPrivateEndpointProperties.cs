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

using Azure.Analytics.Synapse.ManagedPrivateEndpoints.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSManagedPrivateEndpointProperties 
    {
        public PSManagedPrivateEndpointProperties(ManagedPrivateEndpointProperties properties)
        {
            this.Name = properties?.Name;
            this.PrivateLinkResourceId = properties?.PrivateLinkResourceId;
            this.GroupId = properties?.GroupId;
            this.ProvisioningState = properties?.ProvisioningState;
            this.IsReserved = properties?.IsReserved;
            this.ConnectionState = properties?.ConnectionState != null? new PSManagedPrivateEndpointConnectionState(properties?.ConnectionState) : null;
            this.Fqdns = properties?.Fqdns;
            this.IsCompliant = properties?.IsCompliant;
        }

        /// <summary>
        /// The name of managed private endpoint.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The ARM resource ID of the resource to which the managed private endpoint is created.
        /// </summary>
        public string PrivateLinkResourceId { get; set; }

        /// <summary>
        /// The groupId to which the managed private endpoint is created.
        /// </summary>
        public string GroupId { get; set; }

        /// <summary>
        /// The managed private endpoint provisioning state.
        /// </summary>
        public string ProvisioningState { get; }

        /// <summary>
        /// The managed private endpoint connection state.
        /// </summary>
        public PSManagedPrivateEndpointConnectionState ConnectionState { get; set; }

        /// <summary>
        /// Denotes whether the managed private endpoint is reserved.
        /// </summary>
        public bool? IsReserved { get; }

        /// <summary>
        /// List of fully qualified domain names.
        /// </summary>
        public IList<string> Fqdns { get; }

        /// <summary>
        /// Denotes whether the managed private endpoint is compliant.
        /// </summary>
        public bool? IsCompliant { get; set; }
    }
}
