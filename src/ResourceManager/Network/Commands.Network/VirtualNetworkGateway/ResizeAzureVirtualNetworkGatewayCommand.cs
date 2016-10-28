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
    [Cmdlet(VerbsCommon.Resize, "AzureRmVirtualNetworkGateway"), OutputType(typeof(PSVirtualNetworkGateway))]
    public class ResizeAzureVirtualNetworkGatewayCommand : VirtualNetworkGatewayBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The VirtualNetworkGateway")]
        [ValidateNotNull]
        public PSVirtualNetworkGateway VirtualNetworkGateway { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The gatway Sku:- Basic/Standard/HighPerformance")]
        [ValidateSet(
        MNM.VirtualNetworkGatewaySkuTier.Basic,
        MNM.VirtualNetworkGatewaySkuTier.Standard,
        MNM.VirtualNetworkGatewaySkuTier.HighPerformance,
        MNM.VirtualNetworkGatewaySkuTier.UltraPerformance,
        IgnoreCase = true)]
        public string GatewaySku { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (!this.IsVirtualNetworkGatewayPresent(this.VirtualNetworkGateway.ResourceGroupName, this.VirtualNetworkGateway.Name))
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
            }

            var getvirtualnetGateway = this.GetVirtualNetworkGateway(this.VirtualNetworkGateway.ResourceGroupName, this.VirtualNetworkGateway.Name);
            if (getvirtualnetGateway.Sku.Tier.Equals(this.GatewaySku))
            {
                throw new ArgumentException("Current Gateway SKU is same as Resize SKU size:"+ this.GatewaySku + " requested. No need to resize!");
            }

            if (this.VirtualNetworkGateway.ActiveActive && !GatewaySku.Equals(MNM.VirtualNetworkGatewaySkuTier.HighPerformance))
            {
                throw new ArgumentException("Virtual Network Gateway Sku should be " + MNM.VirtualNetworkGatewaySkuTier.HighPerformance + " when Active-Active feature is already enabled on gateway.");
            }

            this.VirtualNetworkGateway.Sku = new PSVirtualNetworkGatewaySku();
            this.VirtualNetworkGateway.Sku.Tier = this.GatewaySku;
            this.VirtualNetworkGateway.Sku.Name = this.GatewaySku;

            // Map to the sdk object
            var virtualnetGatewayModel = Mapper.Map<MNM.VirtualNetworkGateway>(this.VirtualNetworkGateway);
            virtualnetGatewayModel.Tags = TagsConversionHelper.CreateTagDictionary(this.VirtualNetworkGateway.Tag, validate: true);

            this.VirtualNetworkGatewayClient.CreateOrUpdate(this.VirtualNetworkGateway.ResourceGroupName, this.VirtualNetworkGateway.Name, virtualnetGatewayModel);

            getvirtualnetGateway = this.GetVirtualNetworkGateway(this.VirtualNetworkGateway.ResourceGroupName, this.VirtualNetworkGateway.Name);

            WriteObject(getvirtualnetGateway);
        }
    }
}
