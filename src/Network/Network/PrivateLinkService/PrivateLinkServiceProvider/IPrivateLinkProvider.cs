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

using Microsoft.Azure.Commands.Network.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network
{
    public interface IPrivateLinkProvider
    {
        #region Interface for general usage
        NetworkBaseCmdlet BaseCmdlet { get; set; }
        #endregion

        #region Interface for Private Endpoint Connection
        PSPrivateEndpointConnection GetPrivateEndpointConnection(string resourceGroupName, string serviceName, string name);
        List<PSPrivateEndpointConnection> ListPrivateEndpointConnections(string resourceGroupName, string serviceName);
        PSPrivateEndpointConnection UpdatePrivateEndpointConnectionStatus(string resourceGroupName, string serviceName, string name, string status, string description = null);
        void DeletePrivateEndpointConnection(string resourceGroupName, string serviceName, string name);
        #endregion

        #region Interface for Private Link Resource
        PSPrivateLinkResource GetPrivateLinkResource(string resourceGroupName, string serviceName, string name);
        List<PSPrivateLinkResource> ListPrivateLinkResource(string resourceGroupName, string serviceName);
        #endregion

    }
}
