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

namespace Microsoft.Azure.Commands.EventHub.Models
{

    public class PSEventHubPrivateEndpointConnectionAttributes
    {
        public PSEventHubPrivateEndpointConnectionAttributes()
        { }

        public PSEventHubPrivateEndpointConnectionAttributes(Microsoft.Azure.Management.EventHub.Models.PrivateEndpointConnection privateEndpoint)
        {
            if (privateEndpoint != null)
            {
                Name = privateEndpoint?.Name;
                Id = privateEndpoint?.Id;
                Type = privateEndpoint?.Type;
                Location = privateEndpoint?.Location;
                ProvisioningState = privateEndpoint?.ProvisioningState;
                PrivateEndpoint = new PSEventHubPrivateEndpointAttributes(privateEndpoint.PrivateEndpoint);
                ConnectionState = privateEndpoint?.PrivateLinkServiceConnectionState?.Status;
                Description = privateEndpoint?.PrivateLinkServiceConnectionState?.Description;
            }
        }

        public string Name { get; set; }

        public string Id { get; set; }

        public string Type { get; set; }

        public string Location { get; set; }

        public string ProvisioningState { get; set; }

        public PSEventHubPrivateEndpointAttributes PrivateEndpoint { get; set; }

        public string ConnectionState { get; set; }

        public string Description { get; set; }

    }
}
