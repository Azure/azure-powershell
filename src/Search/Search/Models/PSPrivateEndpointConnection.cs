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

using Microsoft.Azure.Management.Search.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;

namespace Microsoft.Azure.Commands.Management.Search.Models
{
    public class PSPrivateEndpointConnection
    {
        [Ps1Xml(Label = "Private Endpoint Connection Name", Target = ViewControl.List, Position = 0)]
        public string Name { get; private set; }

        [Ps1Xml(Label = "Private Endpoint Connection Id", Target = ViewControl.List, Position = 1)]
        public string Id { get; private set; }

        [Ps1Xml(Label = "Private Endpoint", Target = ViewControl.List, Position = 2)]
        public PSPrivateEndpoint PrivateEndpoint { get; private set; }

        [Ps1Xml(Label = "Private Link Service Connection State", Target = ViewControl.List, Position = 3)]
        public PSPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get; private set; }

        public static explicit operator PrivateEndpointConnection(PSPrivateEndpointConnection v)
        {
            return new PrivateEndpointConnection(id: v.Id, name: v.Name)
            {
                Properties = new PrivateEndpointConnectionProperties()
                {
                    PrivateEndpoint = v.PrivateEndpoint,
                    PrivateLinkServiceConnectionState = (PrivateEndpointConnectionPropertiesPrivateLinkServiceConnectionState)v.PrivateLinkServiceConnectionState
                }
            };
        }

        public static explicit operator PSPrivateEndpointConnection(PrivateEndpointConnection v)
        {
            return new PSPrivateEndpointConnection()
            {
                Id = v.Id,
                Name = v.Name,
                PrivateEndpoint = v.Properties?.PrivateEndpoint,
                PrivateLinkServiceConnectionState = (PSPrivateLinkServiceConnectionState)v.Properties?.PrivateLinkServiceConnectionState
            };
        }
    }
}