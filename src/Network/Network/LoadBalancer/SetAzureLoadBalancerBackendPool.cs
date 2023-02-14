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
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "LoadBalancerBackendAddressPool", SupportsShouldProcess = true, DefaultParameterSetName = "SetByNameParameterSet"), OutputType(typeof(PSBackendAddressPool))]
    public partial class SetAzureLoadBalancerBackendPool : NetworkBaseCmdlet
    {
        private const string SetByNameParameterSet = "SetByNameParameterSet";
        private const string SetByParentObjectParameterSet = "SetByParentObjectParameterSet";
        private const string SetByInputObjectParameterSet = "SetByInputObjectParameterSet";
        private const string SetByResourceIdParameterSet = "SetByResourceIdParameterSet";

        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name of the load balancer.",
            ParameterSetName = SetByNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }


        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the load balancer.",
            ParameterSetName = SetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string LoadBalancerName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the backend pool.",
            ParameterSetName = SetByNameParameterSet)]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the backend pool.",
            ParameterSetName = SetByParentObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The load balancer resource.",
            ValueFromPipeline = true,
            ParameterSetName = SetByParentObjectParameterSet)]
        public PSLoadBalancer LoadBalancer { get; set; }


        [Parameter(
            Mandatory = true,
            HelpMessage = "The backend address pool to set",
            ValueFromPipeline = true,
            ParameterSetName = SetByInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSBackendAddressPool InputObject { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The backend addresses.",
            ParameterSetName = SetByNameParameterSet)]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The backend addresses.",
            ParameterSetName = SetByParentObjectParameterSet)]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The backend addresses.",
            ParameterSetName = SetByResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSLoadBalancerBackendAddress[] LoadBalancerBackendAddress { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = SetByResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Gateway Load Balancer provider configurations.")]
        public PSTunnelInterface[] TunnelInterface { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void Execute()
        {
            base.Execute();

            BackendAddressPool backendAddressPool = null;

            if (this.IsParameterBound(c => c.LoadBalancer))
            {
                this.ResourceGroupName = this.LoadBalancer.ResourceGroupName;
                this.LoadBalancerName = this.LoadBalancer.Name;
            }

            if (this.IsParameterBound(c => c.ResourceId))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.LoadBalancerName = resourceIdentifier.ParentResource.Split('/')[1];
                this.Name = resourceIdentifier.ResourceName;
            }

            if (this.IsParameterBound(c => c.InputObject))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(this.InputObject.Id);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.LoadBalancerName = resourceIdentifier.ParentResource.Split('/')[1];
                this.Name = resourceIdentifier.ResourceName;
                backendAddressPool = NetworkResourceManagerProfile.Mapper.Map<BackendAddressPool>(this.InputObject);
            }

            // Confirm if resource already exists
            try
            {
                this.NetworkClient.NetworkManagementClient.LoadBalancerBackendAddressPools.Get(this.ResourceGroupName, this.LoadBalancerName, this.Name);
            }
            catch (Rest.Azure.CloudException exception)
            {
                if (exception.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new ArgumentException(string.Format(Properties.Resources.ResourceNotFound,Name));
                }
                else
                {
                    throw exception;
                }
            }

            // add loadbalancer address to the request available. 
            if (this.IsParameterBound(c => c.LoadBalancerBackendAddress))
            {
                backendAddressPool = SetupBackendPoolWithLoadBalancerAddresses();
            }

            AddTunnelInterfacesToPool(backendAddressPool);

            if (ShouldProcess(Name, Microsoft.Azure.Commands.Network.Properties.Resources.OverwritingResourceMessage))
            {
                var loadBalancerBackendAddressPool = this.NetworkClient.NetworkManagementClient.LoadBalancerBackendAddressPools.CreateOrUpdate(
                        this.ResourceGroupName, this.LoadBalancerName, this.Name, backendAddressPool);

                var loadBalancerBackendAddressPoolModel = NetworkResourceManagerProfile.Mapper.Map<PSBackendAddressPool>(loadBalancerBackendAddressPool);

                WriteObject(loadBalancerBackendAddressPoolModel);
            }
        }

        private void AddTunnelInterfacesToPool(BackendAddressPool backendAddressPool)
        {
            if (this.TunnelInterface != null)
            {
                backendAddressPool.TunnelInterfaces = new List<GatewayLoadBalancerTunnelInterface>();
                foreach (var tun in this.TunnelInterface)
                {
                    var tunnelinterface = NetworkResourceManagerProfile.Mapper.Map<GatewayLoadBalancerTunnelInterface>(tun);
                    backendAddressPool.TunnelInterfaces.Add(tunnelinterface);
                }
            }
        }

        private BackendAddressPool SetupBackendPoolWithLoadBalancerAddresses()
        {
            var backendAddressPool = new BackendAddressPool();

            backendAddressPool.LoadBalancerBackendAddresses = new List<LoadBalancerBackendAddress>();

            foreach (var psBackendAddress in this.LoadBalancerBackendAddress)
            {
                var backendAddress = NetworkResourceManagerProfile.Mapper.Map<LoadBalancerBackendAddress>(psBackendAddress);
                backendAddressPool.LoadBalancerBackendAddresses.Add(backendAddress);
            }

            return backendAddressPool;
        }
    }
}
