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
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Network;
    using MNM = Microsoft.Azure.Management.Network.Models;
    using System;
    using System.Collections;
    using System.Management.Automation;
    using System.Net;
    using System.Collections.Generic;
    using System.Security;
    using System.Linq;
    using Microsoft.WindowsAzure.Commands.Common;
    using System.Security.Cryptography.X509Certificates;
    using System.IO;

    public class VpnServerConfigurationBaseCmdlet : NetworkBaseCmdlet
    {
        public IVpnServerConfigurationsOperations VpnServerConfigurationClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.VpnServerConfigurations;
            }
        }

        public PSVpnServerConfiguration ToPsVpnServerConfiguration(Management.Network.Models.VpnServerConfiguration vpnServerConfiguration)
        {
            var psVpnServerConfiguration = NetworkResourceManagerProfile.Mapper.Map<PSVpnServerConfiguration>(vpnServerConfiguration);
            psVpnServerConfiguration.Tag = TagsConversionHelper.CreateTagHashtable(vpnServerConfiguration.Tags);

            return psVpnServerConfiguration;
        }

        public PSVpnServerConfiguration GetVpnServerConfiguration(string resourceGroupName, string name)
        {
            var vpnServerConfiguration = this.VpnServerConfigurationClient.Get(resourceGroupName, name);
            var psVpnServerConfiguration = ToPsVpnServerConfiguration(vpnServerConfiguration);
            psVpnServerConfiguration.ResourceGroupName = resourceGroupName;

            return psVpnServerConfiguration;
        }

        public PSVpnServerConfiguration CreateOrUpdateVpnServerConfiguration(string resourceGroupName, string vpnServerConfigurationName, PSVpnServerConfiguration vpnServerConfiguration, Hashtable tags)
        {
            var vpnServerConfigurationModel = NetworkResourceManagerProfile.Mapper.Map<MNM.VpnServerConfiguration>(vpnServerConfiguration);
            vpnServerConfigurationModel.Location = vpnServerConfiguration.Location;
            vpnServerConfigurationModel.Tags = TagsConversionHelper.CreateTagDictionary(tags, validate: true);

            var vpnSiteCreatedOrUpdated = this.VpnServerConfigurationClient.CreateOrUpdate(resourceGroupName, vpnServerConfigurationName, vpnServerConfigurationModel);
            PSVpnServerConfiguration vpnServerConfigToReturn = ToPsVpnServerConfiguration(vpnSiteCreatedOrUpdated);
            vpnServerConfigToReturn.ResourceGroupName = resourceGroupName;

            return vpnServerConfigToReturn;
        }

        public List<PSVpnServerConfiguration> ListVpnServerConfigurations(string resourceGroupName)
        {
            var vpnServerConfigurations = ShouldListBySubscription(resourceGroupName, null) ?
                this.VpnServerConfigurationClient.List() :                                       //// List by SubId
                this.VpnServerConfigurationClient.ListByResourceGroup(resourceGroupName);        //// List by RG Name

            List<PSVpnServerConfiguration> vpnServerConfigsToReturn = new List<PSVpnServerConfiguration>();
            if (vpnServerConfigurations != null)
            {
                foreach (MNM.VpnServerConfiguration vpnServerConfiguration in vpnServerConfigurations)
                {
                    PSVpnServerConfiguration vpnServerConfigToReturn = ToPsVpnServerConfiguration(vpnServerConfiguration);
                    vpnServerConfigToReturn.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(vpnServerConfiguration.Id);
                    vpnServerConfigsToReturn.Add(vpnServerConfigToReturn);
                }
            }

            return vpnServerConfigsToReturn;
        }

        public bool IsVpnServerConfigurationPresent(string resourceGroupName, string name)
        {
            try
            {
                GetVpnServerConfiguration(resourceGroupName, name);
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

        public PSVpnServerConfiguration CreateVpnServerConfigurationObject(
            PSVpnServerConfiguration vpnServerConfiguration,
            string[] vpnProtocol,
            string[] vpnAuthenticationType,
            string[] vpnClientRootCertificateFilesList,
            string[] vpnClientRevokedCertificateFilesList,
            string radiusServerAddress,
            SecureString radiusServerSecret,
            string[] radiusServerRootCertificateFilesList,
            string[] radiusClientRootCertificateFilesList,
            string aadTenant,
            string aadAudience,
            string aadIssuer,
            PSIpsecPolicy[] vpnClientIpsecPolicy)
        {
            if (vpnProtocol != null)
            {
                vpnServerConfiguration.VpnProtocols = new List<string>(vpnProtocol);
            }

            if (vpnAuthenticationType != null)
            {
                vpnServerConfiguration.VpnAuthenticationTypes = new List<string>(vpnAuthenticationType);
            }

            if (vpnClientIpsecPolicy != null && vpnClientIpsecPolicy.Length != 0)
            {
                vpnServerConfiguration.VpnClientIpsecPolicies = new List<PSIpsecPolicy>(vpnClientIpsecPolicy);
            }

            // VpnAuthenticationType = Certificate related validations.
            if (vpnAuthenticationType == null || vpnAuthenticationType.Contains(MNM.VpnAuthenticationType.Certificate))
            {
                // Read the VpnClientRootCertificates if present
                if (vpnClientRootCertificateFilesList != null)
                {
                    vpnServerConfiguration.VpnServerConfigVpnClientRootCertificates = new List<PSVpnServerConfigVpnClientRootCertificate>();

                    foreach (string vpnClientRootCertPath in vpnClientRootCertificateFilesList)
                    {
                        X509Certificate2 VpnClientRootCertificate = new X509Certificate2(vpnClientRootCertPath);

                        PSVpnServerConfigVpnClientRootCertificate vpnClientRootCert = new PSVpnServerConfigVpnClientRootCertificate()
                        {
                            Name = Path.GetFileNameWithoutExtension(vpnClientRootCertPath),
                            PublicCertData = Convert.ToBase64String(VpnClientRootCertificate.Export(X509ContentType.Cert))
                        };

                        vpnServerConfiguration.VpnServerConfigVpnClientRootCertificates.Add(vpnClientRootCert);
                    }
                }

                // Read the VpnClientRevokedCertificates if present
                if (vpnClientRevokedCertificateFilesList != null)
                {
                    vpnServerConfiguration.VpnServerConfigVpnClientRevokedCertificates = new List<PSVpnServerConfigVpnClientRevokedCertificate>();

                    foreach (string vpnClientRevokedCertPath in vpnClientRevokedCertificateFilesList)
                    {
                        X509Certificate2 vpnClientRevokedCertificate = new X509Certificate2(vpnClientRevokedCertPath);

                        PSVpnServerConfigVpnClientRevokedCertificate vpnClientRevokedCert = new PSVpnServerConfigVpnClientRevokedCertificate()
                        {
                            Name = Path.GetFileNameWithoutExtension(vpnClientRevokedCertPath),
                            Thumbprint = vpnClientRevokedCertificate.Thumbprint
                        };

                        vpnServerConfiguration.VpnServerConfigVpnClientRevokedCertificates.Add(vpnClientRevokedCert);
                    }
                }
            }

            // VpnAuthenticationType = Radius related validations.
            if (vpnAuthenticationType != null && vpnAuthenticationType.Equals(MNM.VpnAuthenticationType.Radius))
            {
                if (radiusServerAddress == null || radiusServerSecret == null)
                {
                    throw new ArgumentException("Both radius server address and secret must be specified if VpnAuthenticationType is being configured as Radius.");
                }

                vpnServerConfiguration.RadiusServerAddress = radiusServerAddress;
                vpnServerConfiguration.RadiusServerSecret = SecureStringExtensions.ConvertToString(radiusServerSecret);

                // Read the RadiusServerRootCertificates if present
                if (radiusServerRootCertificateFilesList != null)
                {
                    vpnServerConfiguration.VpnServerConfigRadiusServerRootCertificates = new List<PSVpnServerConfigRadiusServerRootCertificate>();

                    foreach (string radiusServerRootCertPath in radiusServerRootCertificateFilesList)
                    {
                        X509Certificate2 RadiusServerRootCertificate = new X509Certificate2(radiusServerRootCertPath);

                        PSVpnServerConfigRadiusServerRootCertificate radiusServerRootCert = new PSVpnServerConfigRadiusServerRootCertificate()
                        {
                            Name = Path.GetFileNameWithoutExtension(radiusServerRootCertPath),
                            PublicCertData = Convert.ToBase64String(RadiusServerRootCertificate.Export(X509ContentType.Cert))
                        };

                        vpnServerConfiguration.VpnServerConfigRadiusServerRootCertificates.Add(radiusServerRootCert);
                    }
                }

                // Read the RadiusClientRootCertificates if present
                if (radiusClientRootCertificateFilesList != null)
                {
                    vpnServerConfiguration.VpnServerConfigRadiusClientRootCertificates = new List<PSVpnServerConfigRadiusClientRootCertificate>();

                    foreach (string radiusClientRootCertPath in radiusClientRootCertificateFilesList)
                    {
                        X509Certificate2 radiusClientRootCertificate = new X509Certificate2(radiusClientRootCertPath);

                        PSVpnServerConfigRadiusClientRootCertificate radiusClientRootCert = new PSVpnServerConfigRadiusClientRootCertificate()
                        {
                            Name = Path.GetFileNameWithoutExtension(radiusClientRootCertPath),
                            Thumbprint = radiusClientRootCertificate.Thumbprint
                        };

                        vpnServerConfiguration.VpnServerConfigRadiusClientRootCertificates.Add(radiusClientRootCert);
                    }
                }
            }

            // VpnAuthenticationType = AAD related validations.
            if (vpnAuthenticationType != null && vpnAuthenticationType.Equals(MNM.VpnAuthenticationType.AAD))
            {
                if (aadTenant == null || aadAudience == null || aadIssuer == null)
                {
                    throw new ArgumentException("All Aad tenant, Aad audience and Aad issuer must be specified if VpnAuthenticationType is being configured as AAD.");
                }

                vpnServerConfiguration.AadAuthenticationParameters = new PSAadAuthenticationParameters()
                {
                    AadTenant = aadTenant,
                    AadAudience = aadAudience,
                    AadIssuer = aadIssuer
                };
            }

            return vpnServerConfiguration;
        }
    }
}
