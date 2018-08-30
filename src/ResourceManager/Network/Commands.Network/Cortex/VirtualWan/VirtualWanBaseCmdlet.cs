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
        public IVirtualWANsOperations VirtualWanClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.VirtualWANs;
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
            var virtualWans = string.IsNullOrWhiteSpace(resourceGroupName) ?
                this.VirtualWanClient.List() :                                      //// List by sub id
                this.VirtualWanClient.ListByResourceGroup(resourceGroupName);       //// List by RG name

            List<PSVirtualWan> wansToReturn = new List<PSVirtualWan>();
            if (virtualWans != null)
            {
                foreach (MNM.VirtualWAN virtualWan in virtualWans)
                {
                    wansToReturn.Add(ToPsVirtualWan(virtualWan));
                }
            }

            return wansToReturn;
        }
    }
}
