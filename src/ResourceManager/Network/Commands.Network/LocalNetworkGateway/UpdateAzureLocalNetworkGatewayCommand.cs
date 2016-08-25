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
    [Cmdlet(VerbsCommon.Set, "AzureRmLocalNetworkGateway"), OutputType(typeof(PSLocalNetworkGateway))]
    public class SetAzureLocalNetworkGatewayCommand : LocalNetworkGatewayBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The LocalNetworkGateway")]
        public PSLocalNetworkGateway LocalNetworkGateway { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The address prefixes of the local network to be changed.")]
        [ValidateNotNullOrEmpty]
        public List<string> AddressPrefix { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The local network gateway's ASN")]
        public uint Asn { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The IP address of the local network gateway's BGP speaker")]
        public string BgpPeeringAddress { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Weight added to BGP routes learned from this local network gateway")]
        public int PeerWeight { get; set; }

        public override void Execute()
        {

            base.Execute();
            if (!this.IsLocalNetworkGatewayPresent(this.LocalNetworkGateway.ResourceGroupName, this.LocalNetworkGateway.Name))
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
            }

            if (this.AddressPrefix != null && this.AddressPrefix.Count > 0)
            {
                this.LocalNetworkGateway.LocalNetworkAddressSpace.AddressPrefixes = this.AddressPrefix;
            }

            if ((this.Asn > 0 || !string.IsNullOrEmpty(this.BgpPeeringAddress) || this.PeerWeight > 0) && this.LocalNetworkGateway.BgpSettings == null)
            {
                this.LocalNetworkGateway.BgpSettings = new PSBgpSettings();
            }

            if (this.Asn > 0)
            {
                this.LocalNetworkGateway.BgpSettings.Asn = this.Asn;
            }

            if (!string.IsNullOrEmpty(this.BgpPeeringAddress))
            {
                this.LocalNetworkGateway.BgpSettings.BgpPeeringAddress = this.BgpPeeringAddress;
            }

            if (this.PeerWeight > 0)
            {
                this.LocalNetworkGateway.BgpSettings.PeerWeight = this.PeerWeight;
            }
            else if (this.PeerWeight < 0)
            {
                throw new PSArgumentException("PeerWeight cannot be negative");
            }

            // Map to the sdk object
            var localnetGatewayModel = Mapper.Map<MNM.LocalNetworkGateway>(this.LocalNetworkGateway);
            localnetGatewayModel.Tags = TagsConversionHelper.CreateTagDictionary(this.LocalNetworkGateway.Tag, validate: true);

            this.LocalNetworkGatewayClient.CreateOrUpdate(this.LocalNetworkGateway.ResourceGroupName, this.LocalNetworkGateway.Name, localnetGatewayModel);

            var getlocalnetGateway = this.GetLocalNetworkGateway(this.LocalNetworkGateway.ResourceGroupName, this.LocalNetworkGateway.Name);

            WriteObject(getlocalnetGateway);
        }
    }
}
