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
            WriteObject(vpnServerConfigurationModel);

            var vpnServerConfigCreatedOrUpdated = this.VpnServerConfigurationClient.CreateOrUpdate(resourceGroupName, vpnServerConfigurationName, vpnServerConfigurationModel);
            PSVpnServerConfiguration vpnServerConfigToReturn = ToPsVpnServerConfiguration(vpnServerConfigCreatedOrUpdated);
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
            return NetworkBaseCmdlet.IsResourcePresent(() => { GetVpnServerConfiguration(resourceGroupName, name); });
        }

        public PSVpnServerConfiguration CreateVpnServerConfigurationObject(
            PSVpnServerConfiguration vpnServerConfiguration,
            string[] vpnProtocol,
            string[] vpnAuthenticationType,
            string[] vpnClientRootCertificateFilesList,
            string[] vpnClientRevokedCertificateFilesList,
            string radiusServerAddress,
            SecureString radiusServerSecret,
            PSRadiusServer[] radiusServers,
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
            if (vpnAuthenticationType == null ||
                (vpnAuthenticationType != null && vpnAuthenticationType.Contains(MNM.VpnAuthenticationType.Certificate)))

            {
                // Read the VpnClientRootCertificates if present
                if (vpnClientRootCertificateFilesList != null)
                {
                    vpnServerConfiguration.VpnClientRootCertificates = new List<PSClientRootCertificate>();

                    foreach (string vpnClientRootCertPath in vpnClientRootCertificateFilesList)
                    {
                        X509Certificate2 VpnClientRootCertificate = new X509Certificate2(vpnClientRootCertPath);

                        PSClientRootCertificate vpnClientRootCert = new PSClientRootCertificate()
                        {
                            Name = Path.GetFileNameWithoutExtension(vpnClientRootCertPath),
                            PublicCertData = Convert.ToBase64String(VpnClientRootCertificate.Export(X509ContentType.Cert))
                        };

                        vpnServerConfiguration.VpnClientRootCertificates.Add(vpnClientRootCert);
                    }
                }

                // Read the VpnClientRevokedCertificates if present
                if (vpnClientRevokedCertificateFilesList != null)
                {
                    vpnServerConfiguration.VpnClientRevokedCertificates = new List<PSClientCertificate>();

                    foreach (string vpnClientRevokedCertPath in vpnClientRevokedCertificateFilesList)
                    {
                        X509Certificate2 vpnClientRevokedCertificate = new X509Certificate2(vpnClientRevokedCertPath);

                        PSClientCertificate vpnClientRevokedCert = new PSClientCertificate()
                        {
                            Name = Path.GetFileNameWithoutExtension(vpnClientRevokedCertPath),
                            Thumbprint = vpnClientRevokedCertificate.Thumbprint
                        };

                        vpnServerConfiguration.VpnClientRevokedCertificates.Add(vpnClientRevokedCert);
                    }
                }
            }
            // VpnAuthenticationType = Radius related validations.
            if (vpnAuthenticationType.Contains(MNM.VpnAuthenticationType.Radius))
            {
                if (radiusServerAddress != null)
                {
                    vpnServerConfiguration.RadiusServerAddress = radiusServerAddress;
                }

                if (radiusServerSecret != null)
                {
                    vpnServerConfiguration.RadiusServerSecret = SecureStringExtensions.ConvertToString(radiusServerSecret);
                }

                vpnServerConfiguration.RadiusServers = radiusServers?.ToList();

                // Read the RadiusServerRootCertificates if present
                if (radiusServerRootCertificateFilesList != null)
                {
                    vpnServerConfiguration.RadiusServerRootCertificates = new List<PSClientRootCertificate>();

                    foreach (string radiusServerRootCertPath in radiusServerRootCertificateFilesList)
                    {
                        X509Certificate2 RadiusServerRootCertificate = new X509Certificate2(radiusServerRootCertPath);

                        PSClientRootCertificate radiusServerRootCert = new PSClientRootCertificate()
                        {
                            Name = Path.GetFileNameWithoutExtension(radiusServerRootCertPath),
                            PublicCertData = Convert.ToBase64String(RadiusServerRootCertificate.Export(X509ContentType.Cert))
                        };

                        vpnServerConfiguration.RadiusServerRootCertificates.Add(radiusServerRootCert);
                    }
                }

                // Read the RadiusClientRootCertificates if present
                if (radiusClientRootCertificateFilesList != null)
                {
                    vpnServerConfiguration.RadiusClientRootCertificates = new List<PSClientCertificate>();

                    foreach (string radiusClientRootCertPath in radiusClientRootCertificateFilesList)
                    {
                        X509Certificate2 radiusClientRootCertificate = new X509Certificate2(radiusClientRootCertPath);

                        PSClientCertificate radiusClientRootCert = new PSClientCertificate()
                        {
                            Name = Path.GetFileNameWithoutExtension(radiusClientRootCertPath),
                            Thumbprint = radiusClientRootCertificate.Thumbprint
                        };

                        vpnServerConfiguration.RadiusClientRootCertificates.Add(radiusClientRootCert);
                    }
                }
            }
            // VpnAuthenticationType = AAD related validations.
            if (vpnAuthenticationType.Contains(MNM.VpnAuthenticationType.AAD))
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