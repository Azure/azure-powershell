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
using System.IO;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New,
        "AzureRmP2SVpnServerConfigurationObject",
        SupportsShouldProcess = true,
        DefaultParameterSetName = P2SVpnServerConfigurationParameterSets.Default),
        OutputType(typeof(PSP2SVpnServerConfiguration))]
    public class NewAzureRmP2SVpnServerConfigurationObject : VirtualWanBaseCmdlet
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
        public string[] VpnProtocol { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = P2SVpnServerConfigurationParameterSets.Default,
            HelpMessage = "A list of VpnClientRootCertificates to be added files' paths")]
        public string[] VpnClientRootCertificateFilesList { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = P2SVpnServerConfigurationParameterSets.Default,
            HelpMessage = "A list of VpnClientCertificates to be revoked files' paths")]
        public string[] VpnClientRevokedCertificateFilesList { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
            ParameterSetName = P2SVpnServerConfigurationParameterSets.Default,
             HelpMessage = "A list of IPSec policies for P2SVpnServerConfiguration.")]
        public PSIpsecPolicy[] VpnClientIpsecPolicy { get; set; }

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
        public string[] RadiusServerRootCertificateFilesList { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = P2SVpnServerConfigurationParameterSets.RadiusServerConfiguration,
            HelpMessage = "A list of RadiusClientRootCertificate files' paths")]
        public string[] RadiusClientRootCertificateFilesList { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (this.VpnClientRootCertificateFilesList != null ||
                this.VpnClientRevokedCertificateFilesList != null ||
                this.RadiusServerAddress != null ||
                this.RadiusServerSecret != null ||
                this.RadiusServerRootCertificateFilesList != null ||
                this.RadiusClientRootCertificateFilesList != null ||
                (this.VpnClientIpsecPolicy != null && this.VpnClientIpsecPolicy.Length != 0))
            {
                PSP2SVpnServerConfiguration p2SVpnServerConfiguration = new PSP2SVpnServerConfiguration();
                p2SVpnServerConfiguration.Name = this.Name;

                WriteObject(this.CreateP2sVpnServerConfigurationObject(
                    p2SVpnServerConfiguration,
                    this.VpnProtocol,
                    this.VpnClientRootCertificateFilesList,
                    this.VpnClientRevokedCertificateFilesList,
                    this.VpnClientIpsecPolicy,
                    this.RadiusServerAddress,
                    this.RadiusServerSecret,
                    this.RadiusServerRootCertificateFilesList,
                    this.RadiusClientRootCertificateFilesList));
            }
            else
            {
                throw new ArgumentException("Either VpnClient settings or RadiusClient settings should be specified!");
            }
        }
    }
}