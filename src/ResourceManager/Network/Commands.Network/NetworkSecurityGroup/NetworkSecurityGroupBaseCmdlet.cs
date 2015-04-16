
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

using System.Net;
using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Commands.Resources.Models;
using Hyak.Common;

namespace Microsoft.Azure.Commands.Network
{
    using Microsoft.Azure.Management.Network.Models;

    public abstract class NetworkSecurityGroupBaseCmdlet : NetworkBaseCmdlet
    {
        public INetworkSecurityGroupOperations NetworkSecurityGroupClient
        {
            get
            {
                return NetworkClient.NetworkResourceProviderClient.NetworkSecurityGroups;
            }
        }

        public bool IsNetworkSecurityGroupPresent(string resourceGroupName, string name)
        {
            try
            {
                GetNetworkSecurityGroup(resourceGroupName, name);
            }
            catch (CloudException exception)
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

        public PSNetworkSecurityGroup GetNetworkSecurityGroup(string resourceGroupName, string name)
        {
            var getNetworkSecurityGroupResponse = this.NetworkSecurityGroupClient.Get(resourceGroupName, name);

            var networkSecurityGroup = Mapper.Map<PSNetworkSecurityGroup>(getNetworkSecurityGroupResponse.NetworkSecurityGroup);
            networkSecurityGroup.ResourceGroupName = resourceGroupName;

            networkSecurityGroup.Tag =
                TagsConversionHelper.CreateTagHashtable(getNetworkSecurityGroupResponse.NetworkSecurityGroup.Tags);

            return networkSecurityGroup;
        }

        public PSNetworkSecurityGroup ToPsNetworkSecurityGroup(NetworkSecurityGroup nsg)
        {
            var psNsg = Mapper.Map<PSNetworkSecurityGroup>(nsg);

            psNsg.Tag = TagsConversionHelper.CreateTagHashtable(nsg.Tags);

            return psNsg;
        }
    }
}