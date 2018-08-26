﻿// ----------------------------------------------------------------------------------
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
        public List<string> AddressPrefix { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The list of Dns Servers")]
        public List<string> DnsServer { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "The list of subnets")]
        public List<PSSubnet> Subnet { get; set; }

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
           HelpMessage = "A switch parameter which represents if Vm protection is enabled or not.")]
        public SwitchParameter EnableVmProtection { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            var present = this.IsVirtualNetworkPresent(this.ResourceGroupName, this.Name);
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
            var vnet = new PSVirtualNetwork();
            vnet.Name = this.Name;
            vnet.ResourceGroupName = this.ResourceGroupName;
            vnet.Location = this.Location;
            vnet.AddressSpace = new PSAddressSpace();
            vnet.AddressSpace.AddressPrefixes = this.AddressPrefix;

            if (this.DnsServer != null)
            {
                vnet.DhcpOptions = new PSDhcpOptions();
                vnet.DhcpOptions.DnsServers = this.DnsServer;
            }

            vnet.Subnets = this.Subnet;
            vnet.EnableDdosProtection = this.EnableDdosProtection;
            vnet.EnableVmProtection = this.EnableVmProtection;

            if (!string.IsNullOrEmpty(this.DdosProtectionPlanId))
            {
                vnet.DdosProtectionPlan = new PSResourceId();
                vnet.DdosProtectionPlan.Id = this.DdosProtectionPlanId;
            }

            // Map to the sdk object
            var vnetModel = NetworkResourceManagerProfile.Mapper.Map<MNM.VirtualNetwork>(vnet);
            vnetModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

            // Execute the Create VirtualNetwork call
            this.VirtualNetworkClient.CreateOrUpdate(this.ResourceGroupName, this.Name, vnetModel);

            var getVirtualNetwork = this.GetVirtualNetwork(this.ResourceGroupName, this.Name);

            return getVirtualNetwork;
        }
    }
}
