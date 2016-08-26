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
    [Cmdlet(VerbsCommon.Add, "AzureRmVpnClientRootCertificate"), OutputType(typeof(PSVpnClientRootCertificate))]
    public class AddAzureVpnClientRootCertificateCommand : VirtualNetworkGatewayBaseCmdlet
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

            if (vnetGateway.VpnClientConfiguration == null)
            {
                vnetGateway.VpnClientConfiguration = new PSVpnClientConfiguration();
            }

            if (vnetGateway.VpnClientConfiguration.VpnClientRootCertificates == null)
            {
                vnetGateway.VpnClientConfiguration.VpnClientRootCertificates = new List<PSVpnClientRootCertificate>();
            }
            else
            {
                // Make sure the same client Root certificate is not already added on Gateway
                PSVpnClientRootCertificate vpnClientRootCertificate = vnetGateway.VpnClientConfiguration.VpnClientRootCertificates.Find(cert => cert.Name.Equals(VpnClientRootCertificateName)
                    && cert.PublicCertData.Equals(PublicCertData));
                if (vpnClientRootCertificate != null)
                {
                    throw new ArgumentException("Same vpn client root client certificate:" + VpnClientRootCertificateName + " PublicCertData:" + PublicCertData +
                        " is already added on Gateway! No need to add again!");
                }
            }

            PSVpnClientRootCertificate newVpnClientRootCertToAdd = new PSVpnClientRootCertificate()
            {
                Name = VpnClientRootCertificateName,
                PublicCertData = PublicCertData
            };
            vnetGateway.VpnClientConfiguration.VpnClientRootCertificates.Add(newVpnClientRootCertToAdd);

            // Map to the sdk object
            var virtualnetGatewayModel = Mapper.Map<MNM.VirtualNetworkGateway>(vnetGateway);
            virtualnetGatewayModel.Tags = TagsConversionHelper.CreateTagDictionary(vnetGateway.Tag, validate: true);

            this.VirtualNetworkGatewayClient.CreateOrUpdate(ResourceGroupName, VirtualNetworkGatewayName, virtualnetGatewayModel);

            var getvirtualnetGateway = this.GetVirtualNetworkGateway(ResourceGroupName, VirtualNetworkGatewayName);

            WriteObject(getvirtualnetGateway.VpnClientConfiguration.VpnClientRootCertificates, true);
        }
    }
}
