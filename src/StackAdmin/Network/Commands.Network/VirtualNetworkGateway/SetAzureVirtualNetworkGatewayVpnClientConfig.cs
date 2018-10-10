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
using System.Security;
using Microsoft.Azure.Commands.Network.VirtualNetworkGateway;
using Microsoft.WindowsAzure.Commands.Common;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Set,
         "AzureRmVirtualNetworkGatewayVpnClientConfig",
         DefaultParameterSetName = VirtualNetworkGatewayParameterSets.Default,
         SupportsShouldProcess = true),
     OutputType(typeof(PSVirtualNetworkGateway))]
    public class SetAzureVirtualNetworkGatewayVpnClientConfigCommand : VirtualNetworkGatewayBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = VirtualNetworkGatewayParameterSets.RadiusServerConfiguration,
            HelpMessage = "The VirtualNetworkGateway")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = VirtualNetworkGatewayParameterSets.Default,
            HelpMessage = "The VirtualNetworkGateway")]
        [ValidateNotNull]
        public PSVirtualNetworkGateway VirtualNetworkGateway { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = VirtualNetworkGatewayParameterSets.RadiusServerConfiguration,
            HelpMessage = "P2S VpnClient AddressPool")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = VirtualNetworkGatewayParameterSets.Default,
            HelpMessage = "P2S VpnClient AddressPool")]
        [ValidateNotNullOrEmpty]
        public List<string> VpnClientAddressPool { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = VirtualNetworkGatewayParameterSets.RadiusServerConfiguration,
            HelpMessage = "P2S External Radius server address.")]
        [ValidateNotNullOrEmpty]
        public string RadiusServerAddress { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = VirtualNetworkGatewayParameterSets.RadiusServerConfiguration,
            HelpMessage = "P2S External Radius server secret.")]
        [ValidateNotNullOrEmpty]
        public SecureString RadiusServerSecret { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (!this.IsVirtualNetworkGatewayPresent(this.VirtualNetworkGateway.ResourceGroupName, this.VirtualNetworkGateway.Name))
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
            }

            if (this.VirtualNetworkGateway.VpnClientConfiguration == null)
            {
                this.VirtualNetworkGateway.VpnClientConfiguration = new PSVpnClientConfiguration();
            }
            this.VirtualNetworkGateway.VpnClientConfiguration.VpnClientAddressPool = new PSAddressSpace();
            this.VirtualNetworkGateway.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes = this.VpnClientAddressPool;

            if ((this.RadiusServerAddress != null && this.RadiusServerSecret == null) ||
                (this.RadiusServerAddress == null && this.RadiusServerSecret != null))
            {
                throw new ArgumentException("Both radius server address and secret must be specified if external radius is being configured");
            }

            if (this.RadiusServerAddress != null)
            {
                this.VirtualNetworkGateway.VpnClientConfiguration.RadiusServerAddress = this.RadiusServerAddress;
                this.VirtualNetworkGateway.VpnClientConfiguration.RadiusServerSecret = SecureStringExtensions.ConvertToString(this.RadiusServerSecret);
            }

            // Map to the sdk object
            var virtualnetGatewayModel = NetworkResourceManagerProfile.Mapper.Map<MNM.VirtualNetworkGateway>(this.VirtualNetworkGateway);
            virtualnetGatewayModel.Tags = TagsConversionHelper.CreateTagDictionary(this.VirtualNetworkGateway.Tag, validate: true);

            string shouldProcessMessage = string.Format("Execute AzureRmVirtualNetworkGatewayVpnClientConfig for ResourceGroupName {0} VirtualNetworkGateway {1}", this.VirtualNetworkGateway.ResourceGroupName, this.VirtualNetworkGateway.Name);
            if (ShouldProcess(shouldProcessMessage, VerbsCommon.Set))
            {
                this.VirtualNetworkGatewayClient.CreateOrUpdate(this.VirtualNetworkGateway.ResourceGroupName,
                    this.VirtualNetworkGateway.Name, virtualnetGatewayModel);

                var getvirtualnetGateway = this.GetVirtualNetworkGateway(this.VirtualNetworkGateway.ResourceGroupName,
                    this.VirtualNetworkGateway.Name);

                WriteObject(getvirtualnetGateway);
            }
        }
    }
}