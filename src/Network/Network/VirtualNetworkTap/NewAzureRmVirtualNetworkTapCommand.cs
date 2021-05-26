// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.

using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using System.Net;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using AutoMapper;
using MNM = Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkTap", DefaultParameterSetName = "SetByResource", SupportsShouldProcess = true), OutputType(typeof(PSVirtualNetworkTap))]
    public partial class NewAzureRmVirtualNetworkTap : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name of the virtual network tap.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the tap.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public int DestinationPort { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The location.",
            ValueFromPipelineByPropertyName = true)]
        [LocationCompleter("Microsoft.Network/virtualNetworkTaps")]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable which represents resource tags.",
            ValueFromPipelineByPropertyName = true)]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = "SetByResourceId",
            HelpMessage = "The reference of the destination network interface IP configuration resource.",
            ValueFromPipelineByPropertyName = true)]
        public string DestinationNetworkInterfaceIPConfigurationId { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = "SetByResource",
            HelpMessage = "The reference of the destination network interface IP configuration resource.",
            ValueFromPipelineByPropertyName = true)]
        public PSNetworkInterfaceIPConfiguration DestinationNetworkInterfaceIPConfiguration { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = "SetByResourceId",
            HelpMessage = "The reference of the destination load balancer front end IP configuration resource.",
            ValueFromPipelineByPropertyName = true)]
        public string DestinationLoadBalancerFrontEndIPConfigurationId { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = "SetByResource",
            HelpMessage = "The reference of the destination load balancer front end IP configuration resource.",
            ValueFromPipelineByPropertyName = true)]
        public PSFrontendIPConfiguration DestinationLoadBalancerFrontEndIPConfiguration { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            // DestinationNetworkInterfaceIPConfiguration
            PSNetworkInterfaceIPConfiguration vDestinationNetworkInterfaceIPConfiguration = null;

            // DestinationLoadBalancerFrontEndIPConfiguration
            PSFrontendIPConfiguration vDestinationLoadBalancerFrontEndIPConfiguration = null;


            if (string.Equals(ParameterSetName, Microsoft.Azure.Commands.Network.Properties.Resources.SetByResource))
            {
                if (this.DestinationNetworkInterfaceIPConfiguration != null)
                {
                    this.DestinationNetworkInterfaceIPConfigurationId = this.DestinationNetworkInterfaceIPConfiguration.Id;
                }
                if (this.DestinationLoadBalancerFrontEndIPConfiguration != null)
                {
                    this.DestinationLoadBalancerFrontEndIPConfigurationId = this.DestinationLoadBalancerFrontEndIPConfiguration.Id;
                }
            }

            if (this.DestinationNetworkInterfaceIPConfigurationId != null)
            {
                if (vDestinationNetworkInterfaceIPConfiguration == null)
                {
                    vDestinationNetworkInterfaceIPConfiguration = new PSNetworkInterfaceIPConfiguration();
                }
                vDestinationNetworkInterfaceIPConfiguration.Id = this.DestinationNetworkInterfaceIPConfigurationId;
            }

            if (this.DestinationLoadBalancerFrontEndIPConfigurationId != null)
            {
                if (vDestinationLoadBalancerFrontEndIPConfiguration == null)
                {
                    vDestinationLoadBalancerFrontEndIPConfiguration = new PSFrontendIPConfiguration();
                }
                vDestinationLoadBalancerFrontEndIPConfiguration.Id = this.DestinationLoadBalancerFrontEndIPConfigurationId;
            }


            var vVirtualNetworkTap = new PSVirtualNetworkTap
            {
                DestinationPort = this.DestinationPort,
                Location = this.Location,
                DestinationNetworkInterfaceIPConfiguration = vDestinationNetworkInterfaceIPConfiguration,
                DestinationLoadBalancerFrontEndIPConfiguration = vDestinationLoadBalancerFrontEndIPConfiguration,
            };

            var vVirtualNetworkTapModel = NetworkResourceManagerProfile.Mapper.Map<MNM.VirtualNetworkTap>(vVirtualNetworkTap);
            vVirtualNetworkTapModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);
            var present = true;
            try
            {
                this.NetworkClient.NetworkManagementClient.VirtualNetworkTaps.Get(this.ResourceGroupName, this.Name);
            }
            catch (Microsoft.Rest.Azure.CloudException exception)
            {
                if (exception.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    // Resource is not present
                    present = false;
                }
                else
                {
                    throw;
                }
            }

            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
            () =>
            {
                this.NetworkClient.NetworkManagementClient.VirtualNetworkTaps.CreateOrUpdate(this.ResourceGroupName, this.Name, vVirtualNetworkTapModel);
                var getVirtualNetworkTap = this.NetworkClient.NetworkManagementClient.VirtualNetworkTaps.Get(this.ResourceGroupName, this.Name);
                var psVirtualNetworkTap = NetworkResourceManagerProfile.Mapper.Map<PSVirtualNetworkTap>(getVirtualNetworkTap);
                psVirtualNetworkTap.ResourceGroupName = this.ResourceGroupName;
                psVirtualNetworkTap.Tag = TagsConversionHelper.CreateTagHashtable(getVirtualNetworkTap.Tags);
                WriteObject(psVirtualNetworkTap, true);
            },
            () => present);

        }
    }
}
