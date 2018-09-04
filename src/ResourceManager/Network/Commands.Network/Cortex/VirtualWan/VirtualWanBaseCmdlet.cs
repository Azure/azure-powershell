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
    using System.Collections;
    using System.Collections.Generic;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Network;
    using Microsoft.Azure.Management.Network.Models;
    using Rest.Azure;
    using MNM = Microsoft.Azure.Management.Network.Models;

    public class VirtualWanBaseCmdlet : NetworkBaseCmdlet
    {

        #region VirtualWan

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
        /// Converts to PS Virtual wan object
        /// </summary>
        /// <param name="virtualWan">Virtual wan object</param>
        /// <returns>PS Virtual wan object</returns>
        public PSVirtualWan ToPsVirtualWan(Management.Network.Models.VirtualWAN virtualWan)
        {
            var psVirtualWan = NetworkResourceManagerProfile.Mapper.Map<PSVirtualWan>(virtualWan);

            psVirtualWan.Tag = TagsConversionHelper.CreateTagHashtable(virtualWan.Tags);

            return psVirtualWan;
        }

        /// <summary>
        /// Gets Virtual Wan
        /// </summary>
        /// <param name="resourceGroupName">Resource group name</param>
        /// <param name="name">Virtual wan name</param>
        /// <returns>Created or updated Virtual wan object</returns>
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

            foreach (string vpnSiteId in vpnSiteIds)
            {
                request.VpnSites.Add(vpnSiteId);
            }

            this.VpnSitesConfigurationClient.Download(virtualWan.ResourceGroupName, virtualWan.Name, request);

            return new PSVirtualWanVpnSitesConfiguration() { SasUrl = outputBlobSasUrl };
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

        /// <summary>
        /// Create or update Virtual wan
        /// </summary>
        /// <param name="resourceGroupName">Resource group name</param>
        /// <param name="virtualWanName">Virtual wan name</param>
        /// <param name="virtualWan">Virtual wan PS object</param>
        /// <param name="tags">Tag</param>
        /// <returns>Virtual wan object</returns>
        public PSVirtualWan CreateOrUpdateVirtualWan(string resourceGroupName, string virtualWanName, PSVirtualWan virtualWan, Hashtable tags)
        {
            var virtualWanModel = NetworkResourceManagerProfile.Mapper.Map<VirtualWAN>(virtualWan);
            virtualWanModel.Tags = TagsConversionHelper.CreateTagDictionary(tags, validate: true);

            var virtualWanCreatedOrUpdated = this.VirtualWanClient.CreateOrUpdate(resourceGroupName, virtualWanName, virtualWanModel);
            return this.ToPsVirtualWan(virtualWanCreatedOrUpdated);
        }

        #endregion

        #region VirtualWan P2SVpnServerConfiguration

        public IP2SVpnServerConfigurationsOperations P2SVpnServerConfigurationClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.P2SVpnServerConfigurations;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="virtualWanP2SVpnServerConfiguration"></param>
        /// <returns></returns>
        public PSP2SVpnServerConfiguration ToPsVirtualWanP2SVpnServerConfiguration(Management.Network.Models.P2SVpnServerConfiguration virtualWanP2SVpnServerConfiguration)
        {
            var psVirtualWanP2SVpnServerConfiguration = NetworkResourceManagerProfile.Mapper.Map<PSP2SVpnServerConfiguration>(virtualWanP2SVpnServerConfiguration);
            psVirtualWanP2SVpnServerConfiguration.Etag = virtualWanP2SVpnServerConfiguration.Etag;
            return psVirtualWanP2SVpnServerConfiguration;
        }

        /// <summary>
        /// Gets VirtualWan P2SVpnServerConfiguration
        /// </summary>
        /// <param name="resourceGroupName">Resource group name</param>
        /// <param name="virtualWanName">Parent Virtual wan name</param>
        /// <param name="p2sVpnServerConfigurationName">P2SVpnServerConfiguration name</param>
        /// <returns>Virtual Wan P2SVpnServerConfiguration object</returns>
        public PSP2SVpnServerConfiguration GetVirtualWanP2SVpnServerConfiguration(string resourceGroupName, string virtualWanName, string p2sVpnServerConfigurationName)
        {
            var virtualWanP2SVpnServerConfiguration = this.P2SVpnServerConfigurationClient.Get(resourceGroupName, virtualWanName, p2sVpnServerConfigurationName);

            var psvirtualWanP2SVpnServerConfiguration = ToPsVirtualWanP2SVpnServerConfiguration(virtualWanP2SVpnServerConfiguration);

            return psvirtualWanP2SVpnServerConfiguration;
        }

        /// <summary>
        /// Get list of VirtualWan P2SVpnServerConfigurations
        /// </summary>
        /// <param name="resourceGroupName">Resource group name</param>
        /// <param name="virtualWanName">Parent Virtual wan name</param>
        /// <returns>Virtual Wan P2SVpnServerConfigurations list</returns>
        public List<PSP2SVpnServerConfiguration> ListVirtualWanP2SVpnServerConfigurations(string resourceGroupName, string virtualWanName)
        {
            IPage<P2SVpnServerConfiguration> p2sVpnServerConfigurationList = this.P2SVpnServerConfigurationClient.ListByVirtualWan(resourceGroupName, virtualWanName);

            var p2sVpnServerConfigurations = new List<PSP2SVpnServerConfiguration>();
            foreach (var p2sVpnServerConfiguration in p2sVpnServerConfigurationList)
            {
                var psP2SVpnServerConfiguration = this.ToPsVirtualWanP2SVpnServerConfiguration(p2sVpnServerConfiguration);
                p2sVpnServerConfigurations.Add(psP2SVpnServerConfiguration);
            }

            return p2sVpnServerConfigurations;
        }

        /// <summary>
        /// Create or update Virtual Wan P2SVpnServerConfiguration
        /// </summary>
        /// <param name="resourceGroupName">>Resource group name</param>
        /// <param name="virtualWanName">>Parent Virtual wan name</param>
        /// <param name="p2sVpnServerConfigurationName">P2SVpnServerConfiguration name</param>
        /// <param name="p2sVpnServerConfiguration">P2SVpnServerConfiguration object</param>
        /// <param name="tags">Tag</param>
        /// <returns>Created or updated Virtual Wan P2SVpnServerConfiguration object</returns>
        public PSP2SVpnServerConfiguration CreateOrUpdateVirtualWanP2SVpnServerConfiguration(string resourceGroupName, string virtualWanName, string p2sVpnServerConfigurationName, PSP2SVpnServerConfiguration p2sVpnServerConfiguration)
        {
            var virtualWanP2SVpnServerConfigurationModel = NetworkResourceManagerProfile.Mapper.Map<P2SVpnServerConfiguration>(p2sVpnServerConfiguration);

            var virtualWanP2SVpnServerConfigurationCreatedOrUpdated = this.P2SVpnServerConfigurationClient.CreateOrUpdate(resourceGroupName, virtualWanName, p2sVpnServerConfigurationName, virtualWanP2SVpnServerConfigurationModel);
            return this.ToPsVirtualWanP2SVpnServerConfiguration(virtualWanP2SVpnServerConfigurationCreatedOrUpdated);
        }

        /// <summary>
        /// Delete Virtual Wan P2SVpnServerConfiguration
        /// </summary>
        /// <param name="resourceGroupName">>Resource group name</param>
        /// <param name="virtualWanName">>Parent Virtual wan name</param>
        /// <param name="p2sVpnServerConfigurationName">P2SVpnServerConfiguration name</param>
        /// <returns>Deletes Virtual Wan P2SVpnServerConfiguration object</returns>
        public void DeleteVirtualWanP2SVpnServerConfiguration(string resourceGroupName, string virtualWanName, string p2sVpnServerConfigurationName)
        {
            this.P2SVpnServerConfigurationClient.Delete(resourceGroupName, virtualWanName, p2sVpnServerConfigurationName);
        }

        #endregion

    }
}
