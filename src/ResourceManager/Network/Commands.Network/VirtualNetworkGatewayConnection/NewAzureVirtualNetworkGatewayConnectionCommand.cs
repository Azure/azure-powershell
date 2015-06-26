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
    [Cmdlet(VerbsCommon.New, "AzureVirtualNetworkGatewayConnection"), OutputType(typeof(PSVirtualNetworkGatewayConnection))]
    public class NewAzureVirtualNetworkGatewayConnectionCommand : VirtualNetworkGatewayConnectionBaseCmdlet
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
             Mandatory = true,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "First virtual network gateway.")]
        public PSVirtualNetworkGateway VirtualNetworkGateway1 { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "Second virtual network gateway.")]
        public PSVirtualNetworkGateway VirtualNetworkGateway2 { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "local network gateway.")]
        public PSLocalNetworkGateway LocalNetworkGateway2 { get; set; }

        [Parameter(
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gateway connection type:IPsec/Vnet2Vnet/ExpressRoute/VPNClient")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            MNM.VirtualNetworkGatewayConnectionType.IPsec,
            MNM.VirtualNetworkGatewayConnectionType.Vnet2Vnet,
            MNM.VirtualNetworkGatewayConnectionType.ExpressRoute,
            MNM.VirtualNetworkGatewayConnectionType.VPNClient,
            IgnoreCase = true)]
        public string ConnectionType { get; set; }

        [Parameter(
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "RoutingWeight.")]
        public int RoutingWeight { get; set; }

        [Parameter(
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The Ipsec share key.")]
        public string SharedKey { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "An array of hashtables which represents resource tags.")]
        public Hashtable[] Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overrite a resource")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (this.IsVirtualNetworkGatewayConnectionPresent(this.ResourceGroupName, this.Name))
            {
                ConfirmAction(
                    Force.IsPresent,
                    string.Format(Microsoft.Azure.Commands.Network.Properties.Resources.OverwritingResource, Name),
                    Microsoft.Azure.Commands.Network.Properties.Resources.OverwritingResourceMessage,
                    Name,
                    () => CreateVirtualNetworkGatewayConnection());

                WriteObject(this.GetVirtualNetworkGatewayConnection(this.ResourceGroupName, this.Name));
            }
            else
            {
                var virtualNetworkGatewayConnection = CreateVirtualNetworkGatewayConnection();

                WriteObject(virtualNetworkGatewayConnection);
            }
        }

        private PSVirtualNetworkGatewayConnection CreateVirtualNetworkGatewayConnection()
        {
            var vnetGatewayConnection = new PSVirtualNetworkGatewayConnection();
            vnetGatewayConnection.Name = this.Name;
            vnetGatewayConnection.ResourceGroupName = this.ResourceGroupName;
            vnetGatewayConnection.Location = this.Location;
            vnetGatewayConnection.VirtualNetworkGateway1 = this.VirtualNetworkGateway1;
            vnetGatewayConnection.VirtualNetworkGateway2 = this.VirtualNetworkGateway2;
            vnetGatewayConnection.LocalNetworkGateway2 = this.LocalNetworkGateway2;
            vnetGatewayConnection.ConnectionType = this.ConnectionType;
            vnetGatewayConnection.RoutingWeight = this.RoutingWeight;
            vnetGatewayConnection.SharedKey = this.SharedKey;

            // Map to the sdk object
            var vnetGatewayConnectionModel = Mapper.Map<MNM.VirtualNetworkGatewayConnection>(vnetGatewayConnection);
            vnetGatewayConnectionModel.Type = Microsoft.Azure.Commands.Network.Properties.Resources.VirtualNetworkGatewayConnectionType;
            vnetGatewayConnectionModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

            // Execute the Create VirtualNetworkConnection call
            this.VirtualNetworkGatewayConnectionClient.CreateOrUpdate(this.ResourceGroupName, this.Name, vnetGatewayConnectionModel);

            var getVirtualNetworkGatewayConnection = this.GetVirtualNetworkGatewayConnection(this.ResourceGroupName, this.Name);

            return getVirtualNetworkGatewayConnection;
        }
    }
}
