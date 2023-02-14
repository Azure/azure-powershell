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


using Microsoft.Azure.Management.Batch.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public class PSPrivateEndpointConnection
    {
        public string Id { get; }

        public string Name { get; }

        public PrivateEndpointConnectionProvisioningState ProvisioningState { get; }

        public PSPrivateEndpoint PrivateEndpoint { get; }

        public PSPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get; }

        public PSPrivateEndpointConnection(
            string id,
            string name,
            PrivateEndpointConnectionProvisioningState provisioningState,
            PSPrivateEndpoint privateEndpoint,
            PSPrivateLinkServiceConnectionState privateLinkServiceConnectionState)
        {
            Id = id;
            Name = name;
            ProvisioningState = provisioningState;
            PrivateEndpoint = privateEndpoint;
            PrivateLinkServiceConnectionState = privateLinkServiceConnectionState;
        }

        internal static PSPrivateEndpointConnection CreateFromPrivateEndpointConnection(PrivateEndpointConnection privateEndpointConnection)
        {
            if(privateEndpointConnection == null)
            {
                return null;
            }

            return new PSPrivateEndpointConnection(
                privateEndpointConnection.Id,
                privateEndpointConnection.Name,
                privateEndpointConnection.ProvisioningState,
                PSPrivateEndpoint.CreateFromPrivateEndpoint(privateEndpointConnection.PrivateEndpoint),
                PSPrivateLinkServiceConnectionState.CreateFromPrivateLinkServiceConnectionState(privateEndpointConnection.PrivateLinkServiceConnectionState));
        }
    }
}
