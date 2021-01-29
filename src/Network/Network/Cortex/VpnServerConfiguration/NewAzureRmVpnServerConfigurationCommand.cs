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

    [Cmdlet(VerbsCommon.New,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VpnServerConfiguration",
        SupportsShouldProcess = true),
        OutputType(typeof(PSVpnServerConfiguration))]
    public class NewAzureRmVpnServerConfigurationCommand : VpnServerConfigurationBaseCmdlet
    {
        [Parameter(Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName", "VpnServerConfigurationName")]
        [Parameter(Mandatory = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource location.")]
        [LocationCompleter("Microsoft.Network/vpnServerConfigurations")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

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
            HelpMessage = "A list of VpnClientRootCertificates to be added files' paths")]
        public string[] VpnClientRootCertificateFilesList { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A list of VpnClientCertificates to be revoked files' paths")]
        public string[] VpnClientRevokedCertificateFilesList { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "P2S External Radius server address.")]
        public string RadiusServerAddress { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "P2S External Radius server secret.")]
        public SecureString RadiusServerSecret { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "P2S External multiple radius servers.")]
        public PSRadiusServer[] RadiusServerList { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A list of RadiusClientRootCertificate files' paths")]
        public string[] RadiusServerRootCertificateFilesList { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A list of RadiusClientRootCertificate files' paths")]
        public string[] RadiusClientRootCertificateFilesList { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "AAD tenant for P2S AAD authentication.")]
        [ValidateNotNullOrEmpty]
        public string AadTenant { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "AAD audience for P2S AAD authentication.")]
        [ValidateNotNullOrEmpty]
        public string AadAudience { get; set; }


        [Parameter(
            Mandatory = false,
            HelpMessage = "AAD issuer for P2S AAD authentication.")]
        [ValidateNotNullOrEmpty]
        public string AadIssuer { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
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

            PSVpnServerConfiguration vpnServerConfigurationToCreate = new PSVpnServerConfiguration();
            vpnServerConfigurationToCreate.ResourceGroupName = this.ResourceGroupName;
            vpnServerConfigurationToCreate.Name = this.Name;
            vpnServerConfigurationToCreate.Location = this.Location;

            if (this.IsVpnServerConfigurationPresent(this.ResourceGroupName, this.Name))
            {
                throw new PSArgumentException(string.Format(Properties.Resources.ResourceAlreadyPresentInResourceGroup, this.Name, this.ResourceGroupName));
            }

            vpnServerConfigurationToCreate = this.CreateVpnServerConfigurationObject(
                vpnServerConfigurationToCreate,
                this.VpnProtocol,
                this.VpnAuthenticationType,
                this.VpnClientRootCertificateFilesList,
                this.VpnClientRevokedCertificateFilesList,
                this.RadiusServerAddress,
                this.RadiusServerSecret,
                this.RadiusServerList,
                this.RadiusServerRootCertificateFilesList,
                this.RadiusClientRootCertificateFilesList,
                this.AadTenant,
                this.AadAudience,
                this.AadIssuer,
                this.VpnClientIpsecPolicy);

            ConfirmAction(
                Properties.Resources.CreatingResourceMessage,
                this.Name,
                () =>
                {
                    WriteVerbose(String.Format(Properties.Resources.CreatingLongRunningOperationMessage, this.ResourceGroupName, this.Name));
                    WriteObject(vpnServerConfigurationToCreate);
                    WriteObject(this.CreateOrUpdateVpnServerConfiguration(this.ResourceGroupName, this.Name, vpnServerConfigurationToCreate, this.Tag));
                });
        }
    }
}