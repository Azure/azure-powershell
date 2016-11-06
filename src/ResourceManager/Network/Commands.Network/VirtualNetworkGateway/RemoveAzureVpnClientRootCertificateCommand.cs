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
    [Cmdlet(VerbsCommon.Remove, "AzureRmVpnClientRootCertificate")]
    public class RemoveAzureVpnClientRootCertificateCommand : VirtualNetworkGatewayBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The vpn client root certificate name.")]
        [ValidateNotNullOrEmpty]
        public virtual string VpnClientRootCertificateName { get; set; }

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
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Client Root Public certificate data")]
        [ValidateNotNullOrEmpty]
        public string PublicCertData { get; set; }

        public override void Execute()
        {

            base.Execute();
            if (!this.IsVirtualNetworkGatewayPresent(ResourceGroupName, VirtualNetworkGatewayName))
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
            }

            var vnetGateway = this.GetVirtualNetworkGateway(this.ResourceGroupName, this.VirtualNetworkGatewayName);

            if (vnetGateway.VpnClientConfiguration == null || vnetGateway.VpnClientConfiguration.VpnClientRootCertificates == null)
            {
                throw new ArgumentException("There are no any vpn client root certificates on Gateway!");
            }

            // Make sure the vpn client root certificate is present on Gateway before calling to Remove it.
            PSVpnClientRootCertificate vpnClientRootCertificate = vnetGateway.VpnClientConfiguration.VpnClientRootCertificates.Find(cert => cert.Name.Equals(VpnClientRootCertificateName)
                   && cert.PublicCertData.Equals(PublicCertData));
            if (vpnClientRootCertificate == null)
            {
                throw new ArgumentException("No Vpn client root certificate:" + VpnClientRootCertificateName + " PublicCertData:" + PublicCertData +
                    " found on Gateway! So, can not proceed with removing it!");
            }

            vnetGateway.VpnClientConfiguration.VpnClientRootCertificates.Remove(vpnClientRootCertificate);

            // Map to the sdk object
            var virtualnetGatewayModel = Mapper.Map<MNM.VirtualNetworkGateway>(vnetGateway);
            virtualnetGatewayModel.Tags = TagsConversionHelper.CreateTagDictionary(vnetGateway.Tag, validate: true);

            this.VirtualNetworkGatewayClient.CreateOrUpdate(ResourceGroupName, VirtualNetworkGatewayName, virtualnetGatewayModel);

            WriteObject(true);
        }
    }
}
