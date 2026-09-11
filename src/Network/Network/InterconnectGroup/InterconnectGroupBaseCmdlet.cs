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
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using Microsoft.Rest.Azure;
using System.Net;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    public class InterconnectGroupBaseCmdlet : NetworkBaseCmdlet
    {
        public IInterconnectGroupsOperations InterconnectGroupClient
        {
            get { return NetworkClient.NetworkManagementClient.InterconnectGroups; }
        }

        public ISubgroupsOperations SubgroupClient
        {
            get { return NetworkClient.NetworkManagementClient.Subgroups; }
        }

        public bool IsInterconnectGroupPresent(string resourceGroupName, string name)
        {
            try
            {
                this.InterconnectGroupClient.Get(resourceGroupName, name);
            }
            catch (CloudException exception) when (exception.Response.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }

            return true;
        }

        public PSInterconnectGroup GetInterconnectGroup(string resourceGroupName, string name)
        {
            var interconnectGroup = this.InterconnectGroupClient.Get(resourceGroupName, name);
            return ToPsInterconnectGroup(interconnectGroup, resourceGroupName);
        }

        public PSInterconnectGroup ToPsInterconnectGroup(MNM.InterconnectGroup interconnectGroup, string resourceGroupName = null)
        {
            var psInterconnectGroup = NetworkResourceManagerProfile.Mapper.Map<PSInterconnectGroup>(interconnectGroup);
            psInterconnectGroup.ResourceGroupName = resourceGroupName ?? GetResourceGroup(interconnectGroup.Id);
            psInterconnectGroup.Tag = TagsConversionHelper.CreateTagHashtable(interconnectGroup.Tags);
            return psInterconnectGroup;
        }
    }
}
