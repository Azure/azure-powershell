
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

namespace Microsoft.Azure.Commands.Network
{
    using Microsoft.Azure.Commands.Network.Models;
    using System.Net;
    using Microsoft.Azure.Management.Network;
    using Microsoft.Azure.Management.Network.Models;
    using System.Collections.Generic;
    using Microsoft.Rest.Azure;

    public abstract class AzureInterfaceEndpointBaseCmdlet : NetworkBaseCmdlet
    {
        public IInterfaceEndpointsOperations InterfaceEndpointClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.InterfaceEndpoints;
            }
        }

        public bool IsServiceEndpointPolicyPresent(string resourceGroupName, string name)
        {
            try
            {
                GetInterfaceEndpoint(resourceGroupName, name);
            }
            catch (Microsoft.Rest.Azure.CloudException exception)
            {
                if (exception.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    // Resource is not present
                    return false;
                }

                throw;
            }

            return true;
        }

        public PSInterfaceEndpoint GetInterfaceEndpoint(string resourceGroupName, string name, string expandResource = null)
        {
            var interfaceEndpoint = this.InterfaceEndpointClient.Get(resourceGroupName, name, expandResource);

            var pSInterfaceEndpoint = ToInterfaceEndpoint(interfaceEndpoint);
            pSInterfaceEndpoint.ResourceGroupName = resourceGroupName;

            return pSInterfaceEndpoint;
        }

        public IEnumerable<PSInterfaceEndpoint> ListInterfaceEndpoints(string resourceGroupName)
        {
            var interfaceEndpoints = this.InterfaceEndpointClient.List(resourceGroupName);

            List<PSInterfaceEndpoint> pSInterfaceEndpoints = new List<PSInterfaceEndpoint>();
            foreach (var interfaceEndpoint in interfaceEndpoints)
            {
                var pSInterfaceEndpoint = ToInterfaceEndpoint(interfaceEndpoint);
                pSInterfaceEndpoint.ResourceGroupName = resourceGroupName;
                pSInterfaceEndpoints.Add(pSInterfaceEndpoint);
            }

            return pSInterfaceEndpoints;
        }

        public PSInterfaceEndpoint ToInterfaceEndpoint(InterfaceEndpoint interfaceEndpoint)
        {
            var pSInterfaceEndpoint = NetworkResourceManagerProfile.Mapper.Map<PSInterfaceEndpoint>(interfaceEndpoint);
            return pSInterfaceEndpoint;
        }
    }
}