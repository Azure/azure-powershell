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

using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using CNM = Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Linq;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "LoadBalancerBackendAddressPool", DefaultParameterSetName = "GetByNameParameterSet"), OutputType(typeof(PSBackendAddressPool))]
    public partial class GetAzureLoadBalancerBackendPool : NetworkBaseCmdlet
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
        public string Name {get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = GetByParentObjectParameterSet)]
        [ValidateNotNull]
        public PSLoadBalancer LoadBalancer { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = GetByResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void Execute()
        {
            base.Execute();
            BackendAddressPool loadBalancerBackendAddressPool = null;

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

            // Get single backend pool
            if (ShouldGetByName(this.ResourceGroupName, this.Name))
            {
                loadBalancerBackendAddressPool = this.NetworkClient.NetworkManagementClient.LoadBalancerBackendAddressPools.Get(this.ResourceGroupName, this.LoadBalancerName, this.Name);

                var loadBalancerBackendAddressPoolModel = NetworkResourceManagerProfile.Mapper.Map<PSBackendAddressPool>(loadBalancerBackendAddressPool);
                WriteObject(loadBalancerBackendAddressPoolModel);
            }
            else
            {
                IPage<BackendAddressPool> backendAddressPoolPage = this.NetworkClient.NetworkManagementClient.LoadBalancerBackendAddressPools.List(this.ResourceGroupName, this.LoadBalancerName);

                // compose list of BackendAddressPools
                var backendAddressPoolList = ListNextLink<BackendAddressPool>.GetAllResourcesByPollingNextLink(backendAddressPoolPage,
                            this.NetworkClient.NetworkManagementClient.LoadBalancerBackendAddressPools.ListNext);


                // convert list of BackendAddressPools to a list of Powershell BackendAddressPools
                List<PSBackendAddressPool> psBackendAddressPoolList = new List<PSBackendAddressPool>();
               
                foreach (var backendAddressPool in backendAddressPoolList)
                {
                    var backendAddressPoolModel = NetworkResourceManagerProfile.Mapper.Map<PSBackendAddressPool>(backendAddressPool);
                    psBackendAddressPoolList.Add(backendAddressPoolModel);
                }

                WriteObject(psBackendAddressPoolList, true);
            }
        }
    }
}
