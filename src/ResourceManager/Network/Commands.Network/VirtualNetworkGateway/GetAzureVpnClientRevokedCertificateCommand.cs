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

using Microsoft.Azure.Commands.Network.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, "AzureRmVpnClientRevokedCertificate"), OutputType(typeof(PSVpnClientRevokedCertificate))]
    public class GetAzureVpnClientRevokedCertificates : VirtualNetworkGatewayBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The vpnclient revoked certificate name.")]
        [ValidateNotNullOrEmpty]
        public virtual string VpnClientRevokedCertificateName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The virtual network gateway name.")]
        [ValidateNotNullOrEmpty]
        public virtual string VirtualNetworkGatewayName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        public override void Execute()
        {
            base.Execute();
            var vnetGateway = this.GetVirtualNetworkGateway(this.ResourceGroupName, this.VirtualNetworkGatewayName);

            if (!string.IsNullOrEmpty(this.VpnClientRevokedCertificateName))
            {
                PSVpnClientRevokedCertificate clientRevokedCertificate = vnetGateway.VpnClientConfiguration.VpnClientRevokedCertificates.Find(cert => cert.Name.Equals(VpnClientRevokedCertificateName));
                if (clientRevokedCertificate == null)
                {
                    throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
                }
                else
                {
                    WriteObject(clientRevokedCertificate);
                }
            }
            else
            {
                WriteObject(vnetGateway.VpnClientConfiguration.VpnClientRevokedCertificates, true);
            }
        }
    }
}

