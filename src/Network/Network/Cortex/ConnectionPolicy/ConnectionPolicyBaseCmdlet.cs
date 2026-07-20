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
    using AutoMapper;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Management.Network;
    using System.Collections.Generic;
    using System.Management.Automation;
    using MNM = Microsoft.Azure.Management.Network.Models;

    public class ConnectionPolicyBaseCmdlet : NetworkBaseCmdlet
    {
        public IConnectionPolicyOperations ConnectionPolicyClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.ConnectionPolicy;
            }
        }

        public PSConnectionPolicy ToPsConnectionPolicy(MNM.ConnectionPolicy connectionPolicy)
        {
            var psConnectionPolicy = NetworkResourceManagerProfile.Mapper.Map<PSConnectionPolicy>(connectionPolicy);
            return psConnectionPolicy;
        }

        public PSConnectionPolicy GetConnectionPolicy(string resourceGroupName, string virtualHubName, string name)
        {
            var connectionPolicy = ConnectionPolicyClient.Get(resourceGroupName, virtualHubName, name);
            var psConnectionPolicy = ToPsConnectionPolicy(connectionPolicy);
            return psConnectionPolicy;
        }

        public List<PSConnectionPolicy> ListConnectionPolicies(string resourceGroupName, string virtualHubName)
        {
            var connectionPolicies = ConnectionPolicyClient.List(resourceGroupName, virtualHubName);

            List<PSConnectionPolicy> connectionPoliciesToReturn = new List<PSConnectionPolicy>();
            if (connectionPolicies != null)
            {
                foreach (MNM.ConnectionPolicy connectionPolicy in connectionPolicies)
                {
                    connectionPoliciesToReturn.Add(ToPsConnectionPolicy(connectionPolicy));
                }
            }

            return connectionPoliciesToReturn;
        }

        public PSConnectionPolicy CreateOrUpdateConnectionPolicy(string resourceGroupName, string virtualHubName, string connectionPolicyName, PSConnectionPolicy connectionPolicy)
        {
            var connectionPolicyModel = new MNM.ConnectionPolicy
            {
                Properties = new MNM.ConnectionPolicyProperties
                {
                    EnableInternetSecurity = connectionPolicy.EnableInternetSecurity,
                    RoutingConfiguration = connectionPolicy.RoutingConfiguration != null
                        ? NetworkResourceManagerProfile.Mapper.Map<MNM.RoutingConfiguration>(connectionPolicy.RoutingConfiguration)
                        : null
                }
            };
            var connectionPolicyCreated = ConnectionPolicyClient.CreateOrUpdate(resourceGroupName, virtualHubName, connectionPolicyName, connectionPolicyModel);
            return ToPsConnectionPolicy(connectionPolicyCreated);
        }

        public void IsParentVirtualHubPresent(string resourceGroupName, string parentHubName)
        {
            try
            {
                NetworkClient.NetworkManagementClient.VirtualHubs.Get(resourceGroupName, parentHubName);
            }
            catch
            {
                throw new PSArgumentException(Properties.Resources.ParentVirtualHubNotFound);
            }
        }
    }
}
