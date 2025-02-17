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
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The address prefixes of the virtual network")]
        public string[] AddressPrefix { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "IpamPool to auto allocate from for virtual network address prefixes.")]
        [ValidateNotNullOrEmpty]
        public PSIpamPoolPrefixAllocation[] IpamPoolPrefixAllocation { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The list of Dns Servers")]
        public string[] DnsServer { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "FlowTimeout enables connection tracking for intra-VM flows. The value should be between 4 and 30 minutes (inclusive) to enable tracking, or null to disable tracking.")]
        public int? FlowTimeout { get; set; }

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
            HelpMessage = "Indicates if encryption is enabled on the virtual network. The value should be true to enable encryption on the virtual network, false to disable encryption.")]
        public string EnableEncryption { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "Set the Encryption EnforcementPolicy. The value should be allowUnencrypted to allow VMs without encryption capability inside an encrypted virtual network, or dropUnencrypted to disable any VM without encryption capability from being added into an encrypted virtual network.")]
        public string EncryptionEnforcementPolicy { get; set; }

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
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "IpAllocation")]
        public PSIpAllocation[] IpAllocation { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The edge zone of the virtual network.")]
        public string EdgeZone { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The PrivateEndpointVNetPolicies of the virtual network")]
        public string PrivateEndpointVNetPoliciesValue { get; set; }

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

            if (IpamPoolPrefixAllocation?.Length > 0)
            {
                vnet.AddressSpace.IpamPoolPrefixAllocations = IpamPoolPrefixAllocation.ToList();
            }

            if (DnsServer != null)
            {
                vnet.DhcpOptions = new PSDhcpOptions {DnsServers = DnsServer?.ToList()};
            }
            
            if (this.FlowTimeout > 0)
            {
                vnet.FlowTimeoutInMinutes = this.FlowTimeout;
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

            if (!string.IsNullOrWhiteSpace(EnableEncryption))
            {
                vnet.Encryption = new PSVirtualNetworkEncryption { Enabled = this.EnableEncryption, Enforcement = this.EncryptionEnforcementPolicy };
            }
           
            if (!string.IsNullOrEmpty(this.EdgeZone))
            {
                vnet.ExtendedLocation = new PSExtendedLocation(this.EdgeZone);
            }

            if(!string.IsNullOrEmpty(this.PrivateEndpointVNetPoliciesValue))
            {
                vnet.PrivateEndpointVNetPolicies = this.PrivateEndpointVNetPoliciesValue;
            }

            // Map to the sdk object
            var vnetModel = NetworkResourceManagerProfile.Mapper.Map<MNM.VirtualNetwork>(vnet);
            vnetModel.Tags = TagsConversionHelper.CreateTagDictionary(Tag, validate: true);

            if (this.IpAllocation != null)
            {
                foreach (var ipAllocation in this.IpAllocation)
                {
                    var ipAllocationReference = new MNM.SubResource(ipAllocation.Id);
                    vnetModel.IPAllocations.Add(ipAllocationReference);
                }
            }

            // Execute the Create VirtualNetwork call
            VirtualNetworkClient.CreateOrUpdate(ResourceGroupName, Name, vnetModel);

            var getVirtualNetwork = GetVirtualNetwork(ResourceGroupName, Name);

            return getVirtualNetwork;
        }
    }
}
