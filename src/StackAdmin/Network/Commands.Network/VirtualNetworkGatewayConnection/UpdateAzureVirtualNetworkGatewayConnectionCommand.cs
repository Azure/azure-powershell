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
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Set, "AzureRmVirtualNetworkGatewayConnection", SupportsShouldProcess = true),
        OutputType(typeof(PSVirtualNetworkGatewayConnection))]
    public class SetAzureVirtualNetworkGatewayConnectionCommand : VirtualNetworkGatewayConnectionBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The VirtualNetworkGatewayConnection")]
        public PSVirtualNetworkGatewayConnection VirtualNetworkGatewayConnection { get; set; }
        
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Whether to use a BGP session over a S2S VPN tunnel")]
        public bool? EnableBgp { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Whether to use policy-based traffic selectors for a S2S connection")]
        public bool? UsePolicyBasedTrafficSelectors { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "A list of IPSec policies.")]
        public List<PSIpsecPolicy> IpsecPolicies { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "Do not ask for confirmation if you want to overrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, VirtualNetworkGatewayConnection.Name),
                Properties.Resources.SettingResourceMessage,
                VirtualNetworkGatewayConnection.Name,
                () =>
                {
                    if (!this.IsVirtualNetworkGatewayConnectionPresent(this.VirtualNetworkGatewayConnection.ResourceGroupName, this.VirtualNetworkGatewayConnection.Name))
                    {
                        throw new ArgumentException(Properties.Resources.ResourceNotFound);
                    }

                    if (this.EnableBgp.HasValue)
                    {
                        this.VirtualNetworkGatewayConnection.EnableBgp = this.EnableBgp.Value;
                    }

                    if (this.UsePolicyBasedTrafficSelectors.HasValue)
                    {
                        this.VirtualNetworkGatewayConnection.UsePolicyBasedTrafficSelectors = this.UsePolicyBasedTrafficSelectors.Value;
                    }

                    if (this.IpsecPolicies != null)
                    {
                        this.VirtualNetworkGatewayConnection.IpsecPolicies = this.IpsecPolicies;
                    }

                    var vnetGatewayConnectionModel = NetworkResourceManagerProfile.Mapper.Map<MNM.VirtualNetworkGatewayConnection>(this.VirtualNetworkGatewayConnection);
                    vnetGatewayConnectionModel.Tags = TagsConversionHelper.CreateTagDictionary(this.VirtualNetworkGatewayConnection.Tag, validate: true);
                    this.VirtualNetworkGatewayConnectionClient.CreateOrUpdate(
                        this.VirtualNetworkGatewayConnection.ResourceGroupName,
                        this.VirtualNetworkGatewayConnection.Name, vnetGatewayConnectionModel);
                    var getvnetGatewayConnection = this.GetVirtualNetworkGatewayConnection(this.VirtualNetworkGatewayConnection.ResourceGroupName, this.VirtualNetworkGatewayConnection.Name);
                    WriteObject(getvnetGatewayConnection);
                });

        }
    }
}
