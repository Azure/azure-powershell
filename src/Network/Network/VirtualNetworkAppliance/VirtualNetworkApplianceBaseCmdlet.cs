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
using Microsoft.Azure.Management.Network.Models;
using System.Net;

namespace Microsoft.Azure.Commands.Network
{
    public abstract class VirtualNetworkApplianceBaseCmdlet : NetworkBaseCmdlet
    {
        public IVirtualNetworkAppliancesOperations VirtualNetworkAppliancesClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.VirtualNetworkAppliances;
            }
        }

        public bool IsVirtualNetworkAppliancePresent(string resourceGroupName, string name)
        {
            try
            {
                GetVirtualNetworkAppliance(resourceGroupName, name);
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

        public PSVirtualNetworkAppliance GetVirtualNetworkAppliance(string resourceGroupName, string name)
        {
            var vna = this.VirtualNetworkAppliancesClient.Get(resourceGroupName, name);
            var psVna = ToPsVirtualNetworkAppliance(vna);
            psVna.ResourceGroupName = resourceGroupName;
            return psVna;
        }

        public PSVirtualNetworkAppliance ToPsVirtualNetworkAppliance(VirtualNetworkAppliance vna)
        {
            var psVna = NetworkResourceManagerProfile.Mapper.Map<PSVirtualNetworkAppliance>(vna);
            psVna.Tag = TagsConversionHelper.CreateTagHashtable(vna.Tags);
            return psVna;
        }
    }
}
