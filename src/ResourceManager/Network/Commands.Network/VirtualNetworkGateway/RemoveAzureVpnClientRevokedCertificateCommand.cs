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
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Remove, "AzureRmVpnClientRevokedCertificate")]
    public class RemoveAzureVpnClientRevokedCertificateCommand : VirtualNetworkGatewayBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The vpn client revoked certificate name to be Unrevoked.")]
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
            HelpMessage = "The thumbprint of the revoked VpnClient certificate to be Unrevoked.")]
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

            if (vnetGateway.VpnClientConfiguration == null || vnetGateway.VpnClientConfiguration.VpnClientRevokedCertificates == null)
            {
                throw new ArgumentException("There are no any revoked vpn client certificates on Gateway!");
            }

            // Make sure the same client certificate is present in the Revoked certificates list on Gateway before calling to Unrevoke it.
            PSVpnClientRevokedCertificate vpnClientRevokedCertificate = vnetGateway.VpnClientConfiguration.VpnClientRevokedCertificates.Find(cert => cert.Name.Equals(VpnClientRevokedCertificateName)
                   && cert.Thumbprint.Equals(Thumbprint));
            if (vpnClientRevokedCertificate == null)
            {
                throw new ArgumentException("No revoked vpn client certificate:" + VpnClientRevokedCertificateName + " Thumbprint:" + Thumbprint +
                    " found in Revoked certificates list on Gateway! So, can not proceed with unrevoking it!");
            }

            vnetGateway.VpnClientConfiguration.VpnClientRevokedCertificates.Remove(vpnClientRevokedCertificate);

            // Map to the sdk object
            var virtualnetGatewayModel = Mapper.Map<MNM.VirtualNetworkGateway>(vnetGateway);
            virtualnetGatewayModel.Tags = TagsConversionHelper.CreateTagDictionary(vnetGateway.Tag, validate: true);

            this.VirtualNetworkGatewayClient.CreateOrUpdate(ResourceGroupName, VirtualNetworkGatewayName, virtualnetGatewayModel);

            WriteObject(true);
        }
    }
}
