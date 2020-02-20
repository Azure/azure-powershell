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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Linq;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetwork", SupportsShouldProcess = true),OutputType(typeof(PSVirtualNetwork))]
    public class NewAzureVirtualNetworkCommand : VirtualNetworkBaseCmdlet
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
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
         Mandatory = true,
         ValueFromPipelineByPropertyName = true,
         HelpMessage = "location.")]
        [LocationCompleter("Microsoft.Network/virtualNetworks")]
        [ValidateNotNullOrEmpty]
        public virtual string Location { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The address prefixes of the virtual network")]
        [ValidateNotNullOrEmpty]
        public string[] AddressPrefix { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The list of Dns Servers")]
        public string[] DnsServer { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "The list of subnets")]
        public PSSubnet[] Subnet { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "The BGP Community advertised over ExpressRoute.")]
        public string BgpCommunity { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A switch parameter which represents whether DDoS protection is enabled or not. It can only be turned on if a DDoS Protection Plan is associated with the virtual network.")]
        public SwitchParameter EnableDdosProtection { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Reference to the DDoS protection plan resource associated with the virtual network.")]
        public string DdosProtectionPlanId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to override a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            var present = IsVirtualNetworkPresent(ResourceGroupName, Name);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
                () =>
                {
                    var virtualNetwork = CreateVirtualNetwork();
                    WriteObject(virtualNetwork);
                },
                () => present);
        }

        private PSVirtualNetwork CreateVirtualNetwork()
        {
            var vnet = new PSVirtualNetwork
            {
                Name = Name,
                ResourceGroupName = ResourceGroupName,
                Location = Location,
                AddressSpace = new PSAddressSpace {AddressPrefixes = AddressPrefix?.ToList()}
            };

            if (DnsServer != null)
            {
                vnet.DhcpOptions = new PSDhcpOptions {DnsServers = DnsServer?.ToList()};
            }

            vnet.Subnets = this.Subnet?.ToList();
            vnet.EnableDdosProtection = EnableDdosProtection;
            
            if (!string.IsNullOrEmpty(DdosProtectionPlanId))
            {
                vnet.DdosProtectionPlan = new PSResourceId {Id = DdosProtectionPlanId};
            }

            if (!string.IsNullOrWhiteSpace(BgpCommunity))
            {
                vnet.BgpCommunities = new PSVirtualNetworkBgpCommunities {VirtualNetworkCommunity = this.BgpCommunity};
            }

            // Map to the sdk object
                var vnetModel = NetworkResourceManagerProfile.Mapper.Map<MNM.VirtualNetwork>(vnet);
            vnetModel.Tags = TagsConversionHelper.CreateTagDictionary(Tag, validate: true);

            // Execute the Create VirtualNetwork call
            VirtualNetworkClient.CreateOrUpdate(ResourceGroupName, Name, vnetModel);

            var getVirtualNetwork = GetVirtualNetwork(ResourceGroupName, Name);

            return getVirtualNetwork;
        }
    }
}
