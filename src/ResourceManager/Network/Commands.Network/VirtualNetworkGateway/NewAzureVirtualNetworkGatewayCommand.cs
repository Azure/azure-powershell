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

using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using AutoMapper;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.Resources.Models;
using MNM = Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Commands.Tags.Model;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, "AzureRMVirtualNetworkGateway"), OutputType(typeof(PSVirtualNetworkGateway))]
    public class NewAzureVirtualNetworkGatewayCommand : VirtualNetworkGatewayBaseCmdlet
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
        public string Location { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The IpConfigurations for Virtual network gateway.")]
        public List<PSVirtualNetworkGatewayIpConfiguration> IpConfigurations { get; set; }

        [Parameter(
       Mandatory = false,
       ValueFromPipelineByPropertyName = true,
       HelpMessage = "The type of this virtual network gateway: Vpn")]
        [ValidateSet(
        MNM.VirtualNetworkGatewayType.Vpn,
        IgnoreCase = true)]
        public string GatewayType { get; set; }

        [Parameter(
       Mandatory = false,
       ValueFromPipelineByPropertyName = true,
       HelpMessage = "The type of the Vpn:PolicyBased/RouteBased")]
        [ValidateSet(
        MNM.VpnType.PolicyBased,
        MNM.VpnType.RouteBased,
        IgnoreCase = true)]
        public string VpnType { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "EnableBgp Flag")]
        public bool EnableBgp { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "An array of hashtables which represents resource tags.")]
        public Hashtable[] Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overrite a resource")]
        public SwitchParameter Force { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            if (this.IsVirtualNetworkGatewayPresent(this.ResourceGroupName, this.Name))
            {
                ConfirmAction(
                    Force.IsPresent,
                    string.Format(Microsoft.Azure.Commands.Network.Properties.Resources.OverwritingResource, Name),
                    Microsoft.Azure.Commands.Network.Properties.Resources.OverwritingResourceMessage,
                    Name,
                    () => CreateVirtualNetworkGateway());

                WriteObject(this.GetVirtualNetworkGateway(this.ResourceGroupName, this.Name));
            }
            else
            {
                var virtualNetworkGateway = CreateVirtualNetworkGateway();

                WriteObject(virtualNetworkGateway);
            }
        }

        private PSVirtualNetworkGateway CreateVirtualNetworkGateway()
        {
            var vnetGateway = new PSVirtualNetworkGateway();
            vnetGateway.Name = this.Name;
            vnetGateway.ResourceGroupName = this.ResourceGroupName;
            vnetGateway.Location = this.Location;

            if (this.IpConfigurations != null)
            {
                vnetGateway.IpConfigurations = new List<PSVirtualNetworkGatewayIpConfiguration>();
                vnetGateway.IpConfigurations = this.IpConfigurations;
            }

            vnetGateway.GatewayType = this.GatewayType;
            vnetGateway.VpnType = this.VpnType;
            vnetGateway.EnableBgp = this.EnableBgp;

            // Map to the sdk object
            var vnetGatewayModel = Mapper.Map<MNM.VirtualNetworkGateway>(vnetGateway);
            vnetGatewayModel.Type = Microsoft.Azure.Commands.Network.Properties.Resources.VirtualNetworkGatewayType;
            vnetGatewayModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

            // Execute the Create VirtualNetwork call
            this.VirtualNetworkGatewayClient.CreateOrUpdate(this.ResourceGroupName, this.Name, vnetGatewayModel);

            var getVirtualNetworkGateway = this.GetVirtualNetworkGateway(this.ResourceGroupName, this.Name);

            return getVirtualNetworkGateway;
        }
    }
}
