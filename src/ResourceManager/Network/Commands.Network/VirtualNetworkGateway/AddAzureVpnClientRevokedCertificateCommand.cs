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

using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Add, "AzureRmVpnClientRevokedCertificate"), OutputType(typeof(PSVpnClientRevokedCertificate))]
    public class AddAzureVpnClientRevokedCertificateCommand : VirtualNetworkGatewayBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The vpn client revoked certificate name.")]
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

        [Parameter(
            Mandatory = true,
            HelpMessage = "The thumbprint of the VpnClient certificate to be revoked.")]
        [ValidateNotNullOrEmpty]
        public string Thumbprint { get; set; }


        public override void Execute()
        {

            base.Execute();
            if (!this.IsVirtualNetworkGatewayPresent(ResourceGroupName, VirtualNetworkGatewayName))
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
            }

            var vnetGateway = this.GetVirtualNetworkGateway(this.ResourceGroupName, this.VirtualNetworkGatewayName);

            if (vnetGateway.VpnClientConfiguration == null)
            {
                vnetGateway.VpnClientConfiguration = new PSVpnClientConfiguration();
            }

            if (vnetGateway.VpnClientConfiguration.VpnClientRevokedCertificates == null)
            {
                vnetGateway.VpnClientConfiguration.VpnClientRevokedCertificates = new List<PSVpnClientRevokedCertificate>();
            }
            else
            {
                // Make sure the same vpn client certificate is not already in the Revoked certificates list on Gateway
                PSVpnClientRevokedCertificate vpnClientRevokedCertificate = vnetGateway.VpnClientConfiguration.VpnClientRevokedCertificates.Find(cert => cert.Name.Equals(VpnClientRevokedCertificateName)
                    && cert.Thumbprint.Equals(Thumbprint));
                if (vpnClientRevokedCertificate != null)
                {
                    throw new ArgumentException("Same vpn client certificate:" + VpnClientRevokedCertificateName + " Thumbprint:" + Thumbprint +
                        " is already in Revoked certificates list on Gateway! No need to revoke again!");
                }
            }

            PSVpnClientRevokedCertificate newVpnClientCertToRevoke = new PSVpnClientRevokedCertificate()
            {
                Name = VpnClientRevokedCertificateName,
                Thumbprint = Thumbprint
            };

            vnetGateway.VpnClientConfiguration.VpnClientRevokedCertificates.Add(newVpnClientCertToRevoke);

            // Map to the sdk object
            var virtualnetGatewayModel = Mapper.Map<MNM.VirtualNetworkGateway>(vnetGateway);
            virtualnetGatewayModel.Tags = TagsConversionHelper.CreateTagDictionary(vnetGateway.Tag, validate: true);

            this.VirtualNetworkGatewayClient.CreateOrUpdate(ResourceGroupName, VirtualNetworkGatewayName, virtualnetGatewayModel);

            var getvirtualnetGateway = this.GetVirtualNetworkGateway(ResourceGroupName, VirtualNetworkGatewayName);

            WriteObject(getvirtualnetGateway.VpnClientConfiguration.VpnClientRevokedCertificates, true);
        }
    }
}
