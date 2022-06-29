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

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "LoadBalancerBackendAddressInboundNatRulePortMapping", DefaultParameterSetName = "GetByNameParameterSet"), OutputType(typeof(PSInboundNatRulePortMapping))]
    public partial class GetAzureLoadBalancerBackendAddressInboundNatRulePortMapping : NetworkBaseCmdlet
    {
        private const string GetByNameParameterSet = "GetByNameParameterSet";
        private const string GetByParentObjectParameterSet = "GetByParentObjectParameterSet";
        private const string GetByResourceIdParameterSet = "GetByResourceIdParameterSet";

        [Parameter(
        Mandatory = true,
        HelpMessage = "The resource group name of the load balancer.",
        ParameterSetName = GetByNameParameterSet)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
        HelpMessage = "The name of the load balancer.",
        ParameterSetName = GetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string LoadBalancerName { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "The name of the backend address pool.",
            ParameterSetName = GetByNameParameterSet)]
        [Parameter(Mandatory = false,
            HelpMessage = "The name of the backend address pool.",
            ParameterSetName = GetByParentObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = GetByParentObjectParameterSet)]
        [ValidateNotNull]
        public PSLoadBalancer LoadBalancer { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "ResourceId of load balancer backend address pool.",
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = GetByResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
              Mandatory = false,
              HelpMessage = "IP address in the load balancer backend pool.")]
        public string IpAddress { get; set; }

        [Parameter(
              Mandatory = false,
              HelpMessage = "ResourceID of network interface IP configuration in the load balancer backend pool.")]
        public string NetworkInterfaceIpConfigurationId { get; set; }


        public override void Execute()
        {
            base.Execute();

            if (this.IsParameterBound(c => c.LoadBalancer))
            {
                this.ResourceGroupName = this.LoadBalancer.ResourceGroupName;
                this.LoadBalancerName = this.LoadBalancer.Name;
            }

            if (this.IsParameterBound(p => p.ResourceId))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.LoadBalancerName = resourceIdentifier.ParentResource.Split('/')[1];
                this.Name = resourceIdentifier.ResourceName;
            }

            // Request
            MNM.QueryInboundNatRulePortMappingRequest parameters = new MNM.QueryInboundNatRulePortMappingRequest();
            if (!string.IsNullOrEmpty(this.IpAddress))
            {
                parameters.IpAddress = this.IpAddress;
            }

            if (!string.IsNullOrEmpty(this.NetworkInterfaceIpConfigurationId))
            {
                SubResource nic = new SubResource(this.NetworkInterfaceIpConfigurationId);
                parameters.IpConfiguration = nic;
            }

            // Response
            var response = this.NetworkClient.NetworkManagementClient.LoadBalancers.ListInboundNatRulePortMappings(this.ResourceGroupName, this.LoadBalancerName, this.Name, parameters);
            var portMappingList = response.InboundNatRulePortMappings;

            // Convert list of portMappings to a list of Powershell portMappings
            List<PSInboundNatRulePortMapping> psPortMappingList = new List<PSInboundNatRulePortMapping>();
            foreach (var portMapping in portMappingList)
            {
                var portMappingModel = NetworkResourceManagerProfile.Mapper.Map<PSInboundNatRulePortMapping>(portMapping);
                psPortMappingList.Add(portMappingModel);
            }

            WriteObject(psPortMappingList, true);
        }
    }
}
