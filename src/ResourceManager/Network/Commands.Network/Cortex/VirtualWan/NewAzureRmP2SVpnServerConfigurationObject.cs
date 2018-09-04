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

using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Security;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.WindowsAzure.Commands.Common;
using MNM = Microsoft.Azure.Management.Network.Models;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New,
        "AzureRmP2SVpnServerConfigurationObject",
        SupportsShouldProcess = true,
        DefaultParameterSetName = P2SVpnServerConfigurationParameterSets.Default),
        OutputType(typeof(PSP2SVpnServerConfiguration))]
    public class NewAzureRmP2SVpnServerConfigurationObject : NetworkBaseCmdlet
    {
        [Alias("ResourceName", "P2SVpnServerConfigurationName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = P2SVpnServerConfigurationParameterSets.Default,
            HelpMessage = "The list of P2S VPN client tunneling protocols")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = P2SVpnServerConfigurationParameterSets.RadiusServerConfiguration,
            HelpMessage = "The list of P2S VPN client tunneling protocols")]
        [ValidateSet(
            MNM.VpnGatewayTunnelingProtocol.IkeV2,
            MNM.VpnGatewayTunnelingProtocol.OpenVPN)]
        [ValidateNotNullOrEmpty]
        public List<string> VpnProtocol { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = P2SVpnServerConfigurationParameterSets.Default,
            HelpMessage = "A list of VpnClientRootCertificates to be added files' paths")]
        public List<string> P2SVpnServerConfigVpnClientRootCertificateFilesList { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = P2SVpnServerConfigurationParameterSets.Default,
            HelpMessage = "A list of VpnClientCertificates to be revoked files' paths")]
        public List<string> P2SVpnServerConfigVpnClientRevokedCertificateFilesList { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
            ParameterSetName = P2SVpnServerConfigurationParameterSets.Default,
             HelpMessage = "A list of IPSec policies for P2SVpnServerConfiguration.")]
        public List<PSIpsecPolicy> VpnClientIpsecPolicy { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = P2SVpnServerConfigurationParameterSets.RadiusServerConfiguration,
            HelpMessage = "P2S External Radius server address.")]
        [ValidateNotNullOrEmpty]
        public string RadiusServerAddress { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = P2SVpnServerConfigurationParameterSets.RadiusServerConfiguration,
            HelpMessage = "P2S External Radius server secret.")]
        [ValidateNotNullOrEmpty]
        public SecureString RadiusServerSecret { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = P2SVpnServerConfigurationParameterSets.RadiusServerConfiguration,
            HelpMessage = "A list of RadiusClientRootCertificate files' paths")]
        public List<string> P2SVpnServerConfigRadiusServerRootCertificateFilesList { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = P2SVpnServerConfigurationParameterSets.RadiusServerConfiguration,
            HelpMessage = "A list of RadiusClientRootCertificate files' paths")]
        public List<string> P2SVpnServerConfigRadiusClientRootCertificateFilesList { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (this.P2SVpnServerConfigVpnClientRootCertificateFilesList != null ||
                this.P2SVpnServerConfigVpnClientRevokedCertificateFilesList != null ||
                this.RadiusServerAddress != null ||
                this.RadiusServerSecret != null ||
                this.P2SVpnServerConfigRadiusServerRootCertificateFilesList != null ||
                this.P2SVpnServerConfigRadiusClientRootCertificateFilesList != null ||
                (this.VpnClientIpsecPolicy != null && this.VpnClientIpsecPolicy.Count != 0))
            {
                var p2sVpnServerConfiguration = new PSP2SVpnServerConfiguration();
                p2sVpnServerConfiguration.Name = this.Name;

                if (this.VpnProtocol != null)
                {
                    p2sVpnServerConfiguration.VpnProtocols = this.VpnProtocol;
                }

                if (this.VpnClientIpsecPolicy != null && this.VpnClientIpsecPolicy.Count != 0)
                {
                    p2sVpnServerConfiguration.VpnClientIpsecPolicies = this.VpnClientIpsecPolicy;
                }

                if ((this.RadiusServerAddress != null && this.RadiusServerSecret == null) ||
                    (this.RadiusServerAddress == null && this.RadiusServerSecret != null))
                {
                    throw new ArgumentException("Both radius server address and secret must be specified if external radius is being configured");
                }

                if (this.RadiusServerAddress != null)
                {
                    p2sVpnServerConfiguration.RadiusServerAddress = this.RadiusServerAddress;
                    p2sVpnServerConfiguration.RadiusServerSecret = SecureStringExtensions.ConvertToString(this.RadiusServerSecret);
                }

                // Read the P2SVpnServerConfigVpnClientRootCertificates if present
                if (this.P2SVpnServerConfigVpnClientRootCertificateFilesList != null)
                {
                    p2sVpnServerConfiguration.P2SVpnServerConfigVpnClientRootCertificates = new List<PSP2SVpnServerConfigVpnClientRootCertificate>();

                    foreach (string vpnClientRootCertPath in this.P2SVpnServerConfigVpnClientRootCertificateFilesList)
                    {
                        X509Certificate2 VpnClientRootCertificate = new X509Certificate2(vpnClientRootCertPath);

                        PSP2SVpnServerConfigVpnClientRootCertificate vpnClientRootCert = new PSP2SVpnServerConfigVpnClientRootCertificate()
                        {
                            Name = VpnClientRootCertificate.FriendlyName,
                            PublicCertData = Convert.ToBase64String(VpnClientRootCertificate.Export(X509ContentType.Cert)),
                            Id = GetResourceNotSetId(
                                this.NetworkClient.NetworkManagementClient.SubscriptionId,
                                Properties.Resources.P2SVpnServerConfigVpnClientRootCertificateName,
                                this.Name)
                        };

                        p2sVpnServerConfiguration.P2SVpnServerConfigVpnClientRootCertificates.Add(vpnClientRootCert);
                    }
                }

                // Read the P2SVpnServerConfigVpnClientRevokedCertificates if present
                if (this.P2SVpnServerConfigVpnClientRevokedCertificateFilesList != null)
                {
                    p2sVpnServerConfiguration.P2SVpnServerConfigVpnClientRevokedCertificates = new List<PSP2SVpnServerConfigVpnClientRevokedCertificate>();

                    foreach (string vpnClientRevokedCertPath in this.P2SVpnServerConfigVpnClientRevokedCertificateFilesList)
                    {
                        X509Certificate2 vpnClientRevokedCertificate = new X509Certificate2(vpnClientRevokedCertPath);

                        PSP2SVpnServerConfigVpnClientRevokedCertificate vpnClientRevokedCert = new PSP2SVpnServerConfigVpnClientRevokedCertificate()
                        {
                            Name = vpnClientRevokedCertificate.FriendlyName,
                            Thumbprint = vpnClientRevokedCertificate.Thumbprint,
                            Id = GetResourceNotSetId(
                                this.NetworkClient.NetworkManagementClient.SubscriptionId,
                                Properties.Resources.P2SVpnServerConfigVpnClientRevokedCertificateName,
                                this.Name)
                        };

                        p2sVpnServerConfiguration.P2SVpnServerConfigVpnClientRevokedCertificates.Add(vpnClientRevokedCert);
                    }
                }

                // Read the P2SVpnServerConfigRadiusServerRootCertificates if present
                if (this.P2SVpnServerConfigRadiusServerRootCertificateFilesList != null)
                {
                    p2sVpnServerConfiguration.P2SVpnServerConfigRadiusServerRootCertificates = new List<PSP2SVpnServerConfigRadiusServerRootCertificate>();

                    foreach (string radiusServerRootCertPath in this.P2SVpnServerConfigRadiusServerRootCertificateFilesList)
                    {
                        X509Certificate2 RadiusServerRootCertificate = new X509Certificate2(radiusServerRootCertPath);

                        PSP2SVpnServerConfigRadiusServerRootCertificate radiusServerRootCert = new PSP2SVpnServerConfigRadiusServerRootCertificate()
                        {
                            Name = RadiusServerRootCertificate.FriendlyName,
                            PublicCertData = Convert.ToBase64String(RadiusServerRootCertificate.Export(X509ContentType.Cert)),
                            Id = GetResourceNotSetId(
                                this.NetworkClient.NetworkManagementClient.SubscriptionId,
                                Properties.Resources.P2SVpnServerConfigRadiusServerRootCertificateName,
                                this.Name)
                        };

                        p2sVpnServerConfiguration.P2SVpnServerConfigRadiusServerRootCertificates.Add(radiusServerRootCert);
                    }
                }

                // Read the P2SVpnServerConfigRadiusClientRootCertificates if present
                if (this.P2SVpnServerConfigRadiusClientRootCertificateFilesList != null)
                {
                    p2sVpnServerConfiguration.P2SVpnServerConfigRadiusClientRootCertificates = new List<PSP2SVpnServerConfigRadiusClientRootCertificate>();

                    foreach (string radiusClientRootCertPath in this.P2SVpnServerConfigRadiusClientRootCertificateFilesList)
                    {
                        X509Certificate2 radiusClientRootCertificate = new X509Certificate2(radiusClientRootCertPath);

                        PSP2SVpnServerConfigRadiusClientRootCertificate radiusClientRootCert = new PSP2SVpnServerConfigRadiusClientRootCertificate()
                        {
                            Name = radiusClientRootCertificate.FriendlyName,
                            Thumbprint = radiusClientRootCertificate.Thumbprint,
                            Id = GetResourceNotSetId(
                                this.NetworkClient.NetworkManagementClient.SubscriptionId,
                                Properties.Resources.P2SVpnServerConfigRadiusClientRootCertificateName,
                                this.Name)
                        };

                        p2sVpnServerConfiguration.P2SVpnServerConfigRadiusClientRootCertificates.Add(radiusClientRootCert);
                    }
                }

                WriteObject(p2sVpnServerConfiguration);
            }
            else
            {
                throw new ArgumentException("Either VpnClient settings or RadiusClient settings should be specified!");
            }
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
    }
}