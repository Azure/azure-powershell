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
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Network;
    using Microsoft.Azure.Management.Network.Models;
    using System.Collections.Generic;
    using System.Net;
    using MNM = Microsoft.Azure.Management.Network.Models;

    public class VirtualWanBaseCmdlet : NetworkBaseCmdlet
    {
        public IVirtualWansOperations VirtualWanClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.VirtualWans;
            }
        }

        public IVpnSitesConfigurationOperations VpnSitesConfigurationClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.VpnSitesConfiguration;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="virtualWan"></param>
        /// <returns></returns>
        public PSVirtualWan ToPsVirtualWan(Management.Network.Models.VirtualWAN virtualWan)
        {
            var psVirtualWan = NetworkResourceManagerProfile.Mapper.Map<PSVirtualWan>(virtualWan);

            psVirtualWan.Tag = TagsConversionHelper.CreateTagHashtable(virtualWan.Tags);

            return psVirtualWan;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public PSVirtualWan GetVirtualWan(string resourceGroupName, string name)
        {
            var virtualWan = this.VirtualWanClient.Get(resourceGroupName, name);
            var psVirtualWan = ToPsVirtualWan(virtualWan);
            psVirtualWan.ResourceGroupName = resourceGroupName;

            return psVirtualWan;
        }

        public PSVirtualWanVpnSitesConfiguration GetVirtualWanVpnSitesConfiguration(PSVirtualWan virtualWan, List<string> vpnSiteIds, string outputBlobSasUrl)
        {
            GetVpnSitesConfigurationRequest request = new GetVpnSitesConfigurationRequest();
            request.OutputBlobSasUrl = outputBlobSasUrl;
            request.VpnSites = new List<string>();

            foreach(string vpnSiteId in vpnSiteIds)
            {
                request.VpnSites.Add(vpnSiteId);
            }

            this.VpnSitesConfigurationClient.Download(virtualWan.ResourceGroupName, virtualWan.Name, request);

            return new PSVirtualWanVpnSitesConfiguration() { SasUrl = outputBlobSasUrl};
        }

        public List<PSVirtualWan> ListVirtualWans(string resourceGroupName)
        {
            var virtualWans = ShouldListBySubscription(resourceGroupName, null) ?
                this.VirtualWanClient.List() :                                      //// List by sub id
                this.VirtualWanClient.ListByResourceGroup(resourceGroupName);       //// List by RG name

            List<PSVirtualWan> wansToReturn = new List<PSVirtualWan>();
            if (virtualWans != null)
            {
                foreach (MNM.VirtualWAN virtualWan in virtualWans)
                {
                    PSVirtualWan wanToReturn = ToPsVirtualWan(virtualWan);
                    wanToReturn.ResourceGroupName = resourceGroupName;
                    wansToReturn.Add(wanToReturn);
                }
            }

            return wansToReturn;
        }

        public bool IsVirtualWanPresent(string resourceGroupName, string name)
        {
            try
            {
                GetVirtualWan(resourceGroupName, name);
            }
            catch (Microsoft.Azure.Management.Network.Models.ErrorException exception)
            {
                if (exception.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    // Resource is not present
                    return false;
                }
            }

            return true;
        }
    }
}
