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

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSManagedPrivateEndpointProperties 
    {
        public PSManagedPrivateEndpointProperties(ManagedPrivateEndpointProperties properties)
        {
            this.PrivateLinkResourceId = properties?.PrivateLinkResourceId;
            this.GroupId = properties?.GroupId;
            this.ProvisioningState = properties?.ProvisioningState;
            this.IsReserved = properties?.IsReserved;
            this.ConnectionState = properties?.ConnectionState != null? new PSManagedPrivateEndpointConnectionState(properties?.ConnectionState) : null;
        }      

        public string PrivateLinkResourceId { get; set; }

        public string GroupId { get; set; }

        public string ProvisioningState { get; }

        public PSManagedPrivateEndpointConnectionState ConnectionState { get; set; }

        public bool? IsReserved { get; }
    }
}
