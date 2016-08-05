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
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, "AzureRmLocalNetworkGateway", SupportsShouldProcess = true),
        OutputType(typeof(PSLocalNetworkGateway))]
    public class NewAzureLocalNetworkGatewayCommand : LocalNetworkGatewayBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
         Mandatory = true,
         ValueFromPipelineByPropertyName = true,
         HelpMessage = "location.")]
        [ValidateNotNullOrEmpty]
        public virtual string Location { get; set; }

        [Parameter(
       Mandatory = false,
       ValueFromPipelineByPropertyName = true,
       HelpMessage = "IP address of local network gateway.")]
        public string GatewayIpAddress { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The address prefixes of the virtual network")]
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

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overrite a resource")]
        public SwitchParameter Force { get; set; }

        public override void Execute()
        {
            base.Execute();
            WriteWarning("The output object type of this cmdlet will be modified in a future release.");
            var present = this.IsLocalNetworkGatewayPresent(this.ResourceGroupName, this.Name);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
                () =>
                {
                    var localNetworkGateway = CreateLocalNetworkGateway();
                    WriteObject(localNetworkGateway);
                },
                () => present);
        }

        private PSLocalNetworkGateway CreateLocalNetworkGateway()
        {
            var localnetGateway = new PSLocalNetworkGateway();
            localnetGateway.Name = this.Name;
            localnetGateway.ResourceGroupName = this.ResourceGroupName;
            localnetGateway.Location = this.Location;
            localnetGateway.LocalNetworkAddressSpace = new PSAddressSpace();
            localnetGateway.LocalNetworkAddressSpace.AddressPrefixes = this.AddressPrefix;
            localnetGateway.GatewayIpAddress = this.GatewayIpAddress;

            if (this.PeerWeight < 0)
            {
                throw new PSArgumentException("PeerWeight cannot be negative");
            }

            if (this.Asn > 0 && !string.IsNullOrEmpty(this.BgpPeeringAddress))
            {
                localnetGateway.BgpSettings = new PSBgpSettings()
                {
                    Asn = this.Asn,
                    BgpPeeringAddress = this.BgpPeeringAddress,
                    PeerWeight = this.PeerWeight
                };
            }
            else if ((!string.IsNullOrEmpty(this.BgpPeeringAddress) && this.Asn == 0) ||
               (string.IsNullOrEmpty(this.BgpPeeringAddress) && this.Asn > 0))
            {
                throw new PSArgumentException("For a BGP session to be established over IPsec, the local network gateway's ASN and BgpPeeringAddress must both be specified.");
            }

            // Map to the sdk object
            var localnetGatewayModel = Mapper.Map<MNM.LocalNetworkGateway>(localnetGateway);
            localnetGatewayModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

            // Execute the Create Local Network Gateway call
            this.LocalNetworkGatewayClient.CreateOrUpdate(this.ResourceGroupName, this.Name, localnetGatewayModel);

            var getLocalNetworkGateway = this.GetLocalNetworkGateway(this.ResourceGroupName, this.Name);

            return getLocalNetworkGateway;
        }
    }
}
