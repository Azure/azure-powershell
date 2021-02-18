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
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Security;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Network;
    using Microsoft.WindowsAzure.Commands.Common;
    using MNM = Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using System.Linq;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using System.Security.Cryptography.X509Certificates;
    using System.IO;

    [Cmdlet("Update",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VpnServerConfiguration",
        DefaultParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationName,
        SupportsShouldProcess = true),
        OutputType(typeof(PSVpnServerConfiguration))]
    public class UpdateAzureRmVpnServerConfigurationCommand : VpnServerConfigurationBaseCmdlet
    {
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationName,
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName", "VpnServerConfigurationName")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationName,
            Mandatory = true,
            HelpMessage = "The resource name.")]
        [ResourceNameCompleter("Microsoft.Network/vpnServerConfigurations", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("VpnServerConfiguration")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationObject,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The vpn server configuration object to be modified")]
        [ValidateNotNullOrEmpty]
        public PSVpnServerConfiguration InputObject { get; set; }

        [Alias("VpnServerConfigurationId")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationResourceId,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure resource ID for the vpn server configuration.")]
        [ResourceIdCompleter("Microsoft.Network/vpnServerConfigurations")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The list of P2S VPN client tunneling protocols.")]
        [ValidateSet(
            MNM.VpnGatewayTunnelingProtocol.IkeV2,
            MNM.VpnGatewayTunnelingProtocol.OpenVPN)]
        [ValidateNotNullOrEmpty]
        public string[] VpnProtocol { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The list of P2S VPN client tunneling protocols.")]
        [ValidateSet(
            MNM.VpnAuthenticationType.Certificate,
            MNM.VpnAuthenticationType.Radius,
            MNM.VpnAuthenticationType.AAD)]
        [ValidateNotNullOrEmpty]
        public string[] VpnAuthenticationType { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationName,
            HelpMessage = "A list of VpnClientRootCertificates to be added files' paths")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationObject,
            HelpMessage = "A list of VpnClientRootCertificates to be added files' paths")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationResourceId,
            HelpMessage = "A list of VpnClientRootCertificates to be added files' paths")]
        public string[] VpnClientRootCertificateFilesList { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationName,
            HelpMessage = "A list of VpnClientCertificates to be revoked files' paths")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationObject,
            HelpMessage = "A list of VpnClientCertificates to be revoked files' paths")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationResourceId,
            HelpMessage = "A list of VpnClientCertificates to be revoked files' paths")]
        public string[] VpnClientRevokedCertificateFilesList { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationName,
            HelpMessage = "P2S External Radius server address.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationObject,
            HelpMessage = "P2S External Radius server address.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationResourceId,
            HelpMessage = "P2S External Radius server address.")]
        public string RadiusServerAddress { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationName,
            HelpMessage = "P2S External Radius server secret.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationObject,
            HelpMessage = "P2S External Radius server secret.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationResourceId,
            HelpMessage = "P2S External Radius server secret.")]
        public SecureString RadiusServerSecret { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationName,
            HelpMessage = "P2S External multiple radius servers.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationObject,
            HelpMessage = "P2S External multiple radius servers.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationResourceId,
            HelpMessage = "P2S External multiple radius servers.")]
        public PSRadiusServer[] RadiusServerList { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationName,
            HelpMessage = "A list of RadiusClientRootCertificate files' paths")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationObject,
            HelpMessage = "A list of RadiusClientRootCertificate files' paths")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationResourceId,
            HelpMessage = "A list of RadiusClientRootCertificate files' paths")]
        public string[] RadiusServerRootCertificateFilesList { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationName,
            HelpMessage = "A list of RadiusClientRootCertificate files' paths")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationObject,
            HelpMessage = "A list of RadiusClientRootCertificate files' paths")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationResourceId,
            HelpMessage = "A list of RadiusClientRootCertificate files' paths")]
        public string[] RadiusClientRootCertificateFilesList { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationName,
            HelpMessage = "AAD tenant for P2S AAD authentication.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationObject,
            HelpMessage = "AAD tenant for P2S AAD authentication.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationResourceId,
            HelpMessage = "AAD tenant for P2S AAD authentication.")]
        [ValidateNotNullOrEmpty]
        public string AadTenant { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationName,
            HelpMessage = "AAD audience for P2S AAD authentication.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationObject,
            HelpMessage = "AAD audience for P2S AAD authentication.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationResourceId,
            HelpMessage = "AAD audience for P2S AAD authentication.")]
        [ValidateNotNullOrEmpty]
        public string AadAudience { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationName,
            HelpMessage = "AAD issuer for P2S AAD authentication.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationObject,
            HelpMessage = "AAD issuer for P2S AAD authentication.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = CortexParameterSetNames.ByVpnServerConfigurationResourceId,
            HelpMessage = "AAD issuer for P2S AAD authentication.")]
        [ValidateNotNullOrEmpty]
        public string AadIssuer { get; set; }

        [Parameter(
             Mandatory = false,
            ValueFromPipeline = true,
             HelpMessage = "A list of IPSec policies for VpnServerConfiguration.")]
        public PSIpsecPolicy[] VpnClientIpsecPolicy { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            PSVpnServerConfiguration vpnServerConfigurationToUpdate = null;

            if (ParameterSetName.Contains(CortexParameterSetNames.ByVpnServerConfigurationObject))
            {
                vpnServerConfigurationToUpdate = this.InputObject;
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.Name = this.InputObject.Name;
            }
            else
            {
                if (ParameterSetName.Contains(CortexParameterSetNames.ByVpnServerConfigurationResourceId))
                {
                    var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                    this.Name = parsedResourceId.ResourceName;
                    this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                }

                vpnServerConfigurationToUpdate = this.GetVpnServerConfiguration(this.ResourceGroupName, this.Name);
            }

            if (vpnServerConfigurationToUpdate == null)
            {
                throw new PSArgumentException(Properties.Resources.VpnServerConfigurationNotFound);
            }

            if (this.VpnProtocol != null)
            {
                vpnServerConfigurationToUpdate.VpnProtocols = new List<string>(this.VpnProtocol);
            }

            if (this.VpnAuthenticationType != null)
            {
                vpnServerConfigurationToUpdate.VpnAuthenticationTypes = new List<string>(this.VpnAuthenticationType);
            }

            if (this.VpnClientIpsecPolicy != null && VpnClientIpsecPolicy.Length != 0)
            {
                vpnServerConfigurationToUpdate.VpnClientIpsecPolicies = new List<PSIpsecPolicy>(this.VpnClientIpsecPolicy);
            }

            // VpnAuthenticationType = Certificate related validations.
            if (vpnServerConfigurationToUpdate.VpnAuthenticationTypes == null ||
                (vpnServerConfigurationToUpdate.VpnAuthenticationTypes != null && vpnServerConfigurationToUpdate.VpnAuthenticationTypes.Contains(MNM.VpnAuthenticationType.Certificate)))
            {
                // Read the VpnClientRootCertificates if present
                if (this.VpnClientRootCertificateFilesList != null)
                {
                    vpnServerConfigurationToUpdate.VpnClientRootCertificates = new List<PSClientRootCertificate>();

                    foreach (string vpnClientRootCertPath in this.VpnClientRootCertificateFilesList)
                    {
                        X509Certificate2 VpnClientRootCertificate = new X509Certificate2(vpnClientRootCertPath);

                        PSClientRootCertificate vpnClientRootCert = new PSClientRootCertificate()
                        {
                            Name = Path.GetFileNameWithoutExtension(vpnClientRootCertPath),
                            PublicCertData = Convert.ToBase64String(VpnClientRootCertificate.Export(X509ContentType.Cert))
                        };
                        vpnServerConfigurationToUpdate.VpnClientRootCertificates.Add(vpnClientRootCert);
                    }
                }

                // Read the VpnClientRevokedCertificates if present
                if (this.VpnClientRevokedCertificateFilesList != null)
                {
                    vpnServerConfigurationToUpdate.VpnClientRevokedCertificates = new List<PSClientCertificate>();

                    foreach (string vpnClientRevokedCertPath in this.VpnClientRevokedCertificateFilesList)
                    {
                        X509Certificate2 vpnClientRevokedCertificate = new X509Certificate2(vpnClientRevokedCertPath);

                        PSClientCertificate vpnClientRevokedCert = new PSClientCertificate()
                        {
                            Name = Path.GetFileNameWithoutExtension(vpnClientRevokedCertPath),
                            Thumbprint = vpnClientRevokedCertificate.Thumbprint
                        };

                        vpnServerConfigurationToUpdate.VpnClientRevokedCertificates.Add(vpnClientRevokedCert);
                    }
                }
            }
            else
            {
                vpnServerConfigurationToUpdate.VpnClientRevokedCertificates = null;
                vpnServerConfigurationToUpdate.VpnClientRootCertificates = null;
            }

            // VpnAuthenticationType = Radius related validations.
            if (vpnServerConfigurationToUpdate.VpnAuthenticationTypes.Contains(MNM.VpnAuthenticationType.Radius))
            {
                if ((this.RadiusServerList != null && this.RadiusServerList.Count() > 0) && (this.RadiusServerAddress != null || this.RadiusServerSecret != null))
                {
                    throw new ArgumentException("Cannot configure both singular radius server and multiple radius servers at the same time.");
                }

                if (RadiusServerList != null && this.RadiusServerList.Count() > 0)
                {
                    vpnServerConfigurationToUpdate.RadiusServers = this.RadiusServerList.ToList();
                    vpnServerConfigurationToUpdate.RadiusServerAddress = null;
                    vpnServerConfigurationToUpdate.RadiusServerSecret = null;
                }
                else
                {
                    if (this.RadiusServerAddress != null)
                    {
                        vpnServerConfigurationToUpdate.RadiusServerAddress = this.RadiusServerAddress;
                    }

                    if (this.RadiusServerSecret != null)
                    {
                        vpnServerConfigurationToUpdate.RadiusServerSecret = SecureStringExtensions.ConvertToString(this.RadiusServerSecret);
                    }

                    vpnServerConfigurationToUpdate.RadiusServers = null;
                }

                // Read the RadiusServerRootCertificates if present
                if (this.RadiusServerRootCertificateFilesList != null)
                {
                    vpnServerConfigurationToUpdate.RadiusServerRootCertificates = new List<PSClientRootCertificate>();

                    foreach (string radiusServerRootCertPath in this.RadiusServerRootCertificateFilesList)
                    {
                        X509Certificate2 RadiusServerRootCertificate = new X509Certificate2(radiusServerRootCertPath);

                        PSClientRootCertificate radiusServerRootCert = new PSClientRootCertificate()
                        {
                            Name = Path.GetFileNameWithoutExtension(radiusServerRootCertPath),
                            PublicCertData = Convert.ToBase64String(RadiusServerRootCertificate.Export(X509ContentType.Cert))
                        };

                        vpnServerConfigurationToUpdate.RadiusServerRootCertificates.Add(radiusServerRootCert);
                    }
                }

                // Read the RadiusClientRootCertificates if present
                if (this.RadiusClientRootCertificateFilesList != null)
                {
                    vpnServerConfigurationToUpdate.RadiusClientRootCertificates = new List<PSClientCertificate>();

                    foreach (string radiusClientRootCertPath in this.RadiusClientRootCertificateFilesList)
                    {
                        X509Certificate2 radiusClientRootCertificate = new X509Certificate2(radiusClientRootCertPath);

                        PSClientCertificate radiusClientRootCert = new PSClientCertificate()
                        {
                            Name = Path.GetFileNameWithoutExtension(radiusClientRootCertPath),
                            Thumbprint = radiusClientRootCertificate.Thumbprint
                        };

                        vpnServerConfigurationToUpdate.RadiusClientRootCertificates.Add(radiusClientRootCert);
                    }
                }
            }
            else
            {
                vpnServerConfigurationToUpdate.RadiusServerAddress = null;
                vpnServerConfigurationToUpdate.RadiusServerSecret = null;
                vpnServerConfigurationToUpdate.RadiusClientRootCertificates = null;
                vpnServerConfigurationToUpdate.RadiusServerRootCertificates = null;
                vpnServerConfigurationToUpdate.RadiusServers = null;
            }

            // VpnAuthenticationType = AAD related validations.
            if (vpnServerConfigurationToUpdate.VpnAuthenticationTypes.Contains(MNM.VpnAuthenticationType.AAD))
            {
                if (vpnServerConfigurationToUpdate.AadAuthenticationParameters == null)
                {
                    vpnServerConfigurationToUpdate.AadAuthenticationParameters = new PSAadAuthenticationParameters();
                }

                if ((this.AadTenant == null && vpnServerConfigurationToUpdate.AadAuthenticationParameters.AadTenant == null) ||
                    (this.AadAudience == null && vpnServerConfigurationToUpdate.AadAuthenticationParameters.AadAudience == null) ||
                    (this.AadIssuer == null && vpnServerConfigurationToUpdate.AadAuthenticationParameters.AadIssuer == null))
                {
                    throw new ArgumentException("All Aad tenant, Aad audience and Aad issuer must be specified if VpnAuthenticationType is being configured as AAD.");
                }

                if (this.AadTenant != null)
                {
                    vpnServerConfigurationToUpdate.AadAuthenticationParameters.AadTenant = this.AadTenant;
                }
                if (this.AadAudience != null)
                {
                    vpnServerConfigurationToUpdate.AadAuthenticationParameters.AadAudience = this.AadAudience;
                }
                if (this.AadIssuer != null)
                {
                    vpnServerConfigurationToUpdate.AadAuthenticationParameters.AadIssuer = this.AadIssuer;
                }
            }
            else
            {
                vpnServerConfigurationToUpdate.AadAuthenticationParameters.AadTenant = null;
                vpnServerConfigurationToUpdate.AadAuthenticationParameters.AadIssuer = null;
                vpnServerConfigurationToUpdate.AadAuthenticationParameters.AadAudience = null;
            }

            ConfirmAction(
                    Properties.Resources.SettingResourceMessage,
                    this.Name,
                    () =>
                    {
                        WriteVerbose(String.Format(Properties.Resources.UpdatingLongRunningOperationMessage, this.ResourceGroupName, this.Name));
                        WriteObject(this.CreateOrUpdateVpnServerConfiguration(this.ResourceGroupName, this.Name, vpnServerConfigurationToUpdate, this.Tag));
                    });
        }
    }
}