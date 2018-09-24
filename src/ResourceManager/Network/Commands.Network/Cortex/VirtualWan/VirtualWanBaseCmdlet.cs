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
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Security;
    using System.Security.Cryptography.X509Certificates;
    using Management.Network;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Models;
    using Rest.Azure;
    using WindowsAzure.Commands.Common;
    using Management.Network.Models;

    public class VirtualWanBaseCmdlet : NetworkBaseCmdlet
    {

        #region VirtualWan

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
                foreach (VirtualWAN virtualWan in virtualWans)
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

        #endregion

        #region VirtualWan P2SVpnServerConfiguration

        public IP2sVpnServerConfigurationsOperations P2SVpnServerConfigurationClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.P2sVpnServerConfigurations;
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

        public PSP2SVpnServerConfiguration CreateP2sVpnServerConfigurationObject(
            PSP2SVpnServerConfiguration p2SVpnServerConfiguration,
            string[] vpnProtocol,
            string[] vpnClientRootCertificateFilesList,
            string[] vpnClientRevokedCertificateFilesList,
            PSIpsecPolicy[] vpnClientIpsecPolicy,
            string radiusServerAddress,
            SecureString radiusServerSecret,
            string[] radiusServerRootCertificateFilesList,
            string[] radiusClientRootCertificateFilesList)
        {
            if (vpnProtocol != null)
            {
                p2SVpnServerConfiguration.VpnProtocols = new List<string>(vpnProtocol);
            }

            if (vpnClientIpsecPolicy != null && vpnClientIpsecPolicy.Length != 0)
            {
                p2SVpnServerConfiguration.VpnClientIpsecPolicies = new List<PSIpsecPolicy>(vpnClientIpsecPolicy);
            }

            if ((radiusServerAddress != null && radiusServerSecret == null) ||
                (radiusServerAddress == null && radiusServerSecret != null))
            {
                throw new ArgumentException("Both radius server address and secret must be specified if external radius is being configured");
            }

            if (radiusServerAddress != null)
            {
                p2SVpnServerConfiguration.RadiusServerAddress = radiusServerAddress;
                p2SVpnServerConfiguration.RadiusServerSecret = SecureStringExtensions.ConvertToString(radiusServerSecret);
            }

            // Read the VpnClientRootCertificates if present
            if (vpnClientRootCertificateFilesList != null)
            {
                p2SVpnServerConfiguration.P2SVpnServerConfigVpnClientRootCertificates = new List<PSP2SVpnServerConfigVpnClientRootCertificate>();

                foreach (string vpnClientRootCertPath in vpnClientRootCertificateFilesList)
                {
                    X509Certificate2 VpnClientRootCertificate = new X509Certificate2(vpnClientRootCertPath);

                    PSP2SVpnServerConfigVpnClientRootCertificate vpnClientRootCert = new PSP2SVpnServerConfigVpnClientRootCertificate()
                    {
                        Name = Path.GetFileNameWithoutExtension(vpnClientRootCertPath),
                        PublicCertData = Convert.ToBase64String(VpnClientRootCertificate.Export(X509ContentType.Cert)),
                        Id = GetResourceNotSetId(
                            this.NetworkClient.NetworkManagementClient.SubscriptionId,
                            Properties.Resources.P2SVpnServerConfigVpnClientRootCertificateName,
                            p2SVpnServerConfiguration.Name)
                    };

                    p2SVpnServerConfiguration.P2SVpnServerConfigVpnClientRootCertificates.Add(vpnClientRootCert);
                }
            }

            // Read the VpnClientRevokedCertificates if present
            if (vpnClientRevokedCertificateFilesList != null)
            {
                p2SVpnServerConfiguration.P2SVpnServerConfigVpnClientRevokedCertificates = new List<PSP2SVpnServerConfigVpnClientRevokedCertificate>();

                foreach (string vpnClientRevokedCertPath in vpnClientRevokedCertificateFilesList)
                {
                    X509Certificate2 vpnClientRevokedCertificate = new X509Certificate2(vpnClientRevokedCertPath);

                    PSP2SVpnServerConfigVpnClientRevokedCertificate vpnClientRevokedCert = new PSP2SVpnServerConfigVpnClientRevokedCertificate()
                    {
                        Name = Path.GetFileNameWithoutExtension(vpnClientRevokedCertPath),
                        Thumbprint = vpnClientRevokedCertificate.Thumbprint,
                        Id = GetResourceNotSetId(
                            this.NetworkClient.NetworkManagementClient.SubscriptionId,
                            Properties.Resources.P2SVpnServerConfigVpnClientRevokedCertificateName,
                            p2SVpnServerConfiguration.Name)
                    };

                    p2SVpnServerConfiguration.P2SVpnServerConfigVpnClientRevokedCertificates.Add(vpnClientRevokedCert);
                }
            }

            // Read the RadiusServerRootCertificates if present
            if (radiusServerRootCertificateFilesList != null)
            {
                p2SVpnServerConfiguration.P2SVpnServerConfigRadiusServerRootCertificates = new List<PSP2SVpnServerConfigRadiusServerRootCertificate>();

                foreach (string radiusServerRootCertPath in radiusServerRootCertificateFilesList)
                {
                    X509Certificate2 RadiusServerRootCertificate = new X509Certificate2(radiusServerRootCertPath);

                    PSP2SVpnServerConfigRadiusServerRootCertificate radiusServerRootCert = new PSP2SVpnServerConfigRadiusServerRootCertificate()
                    {
                        Name = Path.GetFileNameWithoutExtension(radiusServerRootCertPath),
                        PublicCertData = Convert.ToBase64String(RadiusServerRootCertificate.Export(X509ContentType.Cert)),
                        Id = GetResourceNotSetId(
                            this.NetworkClient.NetworkManagementClient.SubscriptionId,
                            Properties.Resources.P2SVpnServerConfigRadiusServerRootCertificateName,
                            p2SVpnServerConfiguration.Name)
                    };

                    p2SVpnServerConfiguration.P2SVpnServerConfigRadiusServerRootCertificates.Add(radiusServerRootCert);
                }
            }

            // Read the RadiusClientRootCertificates if present
            if (radiusClientRootCertificateFilesList != null)
            {
                p2SVpnServerConfiguration.P2SVpnServerConfigRadiusClientRootCertificates = new List<PSP2SVpnServerConfigRadiusClientRootCertificate>();

                foreach (string radiusClientRootCertPath in radiusClientRootCertificateFilesList)
                {
                    X509Certificate2 radiusClientRootCertificate = new X509Certificate2(radiusClientRootCertPath);

                    PSP2SVpnServerConfigRadiusClientRootCertificate radiusClientRootCert = new PSP2SVpnServerConfigRadiusClientRootCertificate()
                    {
                        Name = Path.GetFileNameWithoutExtension(radiusClientRootCertPath),
                        Thumbprint = radiusClientRootCertificate.Thumbprint,
                        Id = GetResourceNotSetId(
                            this.NetworkClient.NetworkManagementClient.SubscriptionId,
                            Properties.Resources.P2SVpnServerConfigRadiusClientRootCertificateName,
                            p2SVpnServerConfiguration.Name)
                    };

                    p2SVpnServerConfiguration.P2SVpnServerConfigRadiusClientRootCertificates.Add(radiusClientRootCert);
                }
            }

            return p2SVpnServerConfiguration;
        }

        public string GetResourceNotSetId(string subscriptionId, string resource, string resourceName)
        {
            return string.Format(
                Properties.Resources.P2SVpnServerConfigurationResourceId,
                subscriptionId,
                Properties.Resources.ResourceGroupNotSet,
                Properties.Resources.VirtualWanNameNotSet,
                Properties.Resources.P2SVpnServerConfigurationNameNotSet,
                resource,
                resourceName);
        }

        #endregion

    }
}
