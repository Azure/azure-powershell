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
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "LoadBalancerBackendAddressPool"), OutputType(typeof(PSBackendAddressPool))]
    public partial class NewAzureLoadBalancerBackendPool : NetworkBaseCmdlet
    {
        private const string CreateByNameParameterSet = "CreateByNameParameterSet";
        private const string CreateByParentObjectParameterSet = "CreateByParentObjectParameterSet";

        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name of the load balancer.",
            ParameterSetName = CreateByNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the load balancer.",
            ParameterSetName = CreateByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string LoadBalancerName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The load balancer resource.",
            ValueFromPipeline = true,
            ParameterSetName = CreateByParentObjectParameterSet)]
        public PSLoadBalancer LoadBalancer { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the backend pool.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The backend addresses.")]
        [ValidateNotNullOrEmpty]
        public PSLoadBalancerBackendAddress[] LoadBalancerBackendAddress { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        public override void Execute()
        {

            base.Execute();

            if (this.IsParameterBound(c => c.LoadBalancer))
            {
                this.ResourceGroupName = this.LoadBalancer.ResourceGroupName;
                this.LoadBalancerName = this.LoadBalancer.Name;
            }

            BackendAddressPool existingloadBalancerBackendAddressPool = null;

            // Confirm if resource already exists
            try
            {
                existingloadBalancerBackendAddressPool = this.NetworkClient.NetworkManagementClient.LoadBalancerBackendAddressPools.Get(this.ResourceGroupName, this.LoadBalancerName, this.Name);
            }
            catch (Rest.Azure.CloudException exception)
            {
                if (exception.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    existingloadBalancerBackendAddressPool = null;
                }
                else
                {
                    throw;
                }
            }

            // Throw if object already exists
            if (existingloadBalancerBackendAddressPool != null)
            {
                throw new Exception(string.Format("A BackendPool with name '{0}' in resource group '{1}' already exists under LoadBalancer '{2}'. Please use Set-AzLoadBalancerBackendAddressPool to update an existing BackendPool .",
                    this.Name, this.ResourceGroupName, this.LoadBalancerName));
            }

            // Prompt a what if action to user, user can skip with force parameter
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.CreatingResourceMessage, Name),
                Properties.Resources.CreatingResourceMessage,
                this.Name,
                () =>
                {
                    var backendPool = CreatePsBackendPool();
                    WriteObject(backendPool);
                });
        }

        private PSBackendAddressPool CreatePsBackendPool()
        {
            var backendAddressPool = new BackendAddressPool();

            //Include backend address pool IP's if provided by user
            if (this.IsParameterBound(c => c.LoadBalancerBackendAddress))
            {
                backendAddressPool.LoadBalancerBackendAddresses = new List<LoadBalancerBackendAddress>();

                foreach (var psBackendAddress in LoadBalancerBackendAddress)
                {
                    var backendAddress = ToLoadBalancerBackendAddress(psBackendAddress);
                    backendAddressPool.LoadBalancerBackendAddresses.Add(backendAddress);
                }
            }

            var loadBalancerBackendAddressPool = this.NetworkClient.NetworkManagementClient.LoadBalancerBackendAddressPools.CreateOrUpdate(this.ResourceGroupName, this.LoadBalancerName, this.Name, backendAddressPool);
            var loadBalancerBackendAddressPoolModel = NetworkResourceManagerProfile.Mapper.Map<PSBackendAddressPool>(loadBalancerBackendAddressPool);
            loadBalancerBackendAddressPool.LoadBalancerBackendAddresses = loadBalancerBackendAddressPool.LoadBalancerBackendAddresses.ToList();

            return loadBalancerBackendAddressPoolModel;
        }

        // Converts the backend address powershell object to a LoadBalancerBackendAddress
        private LoadBalancerBackendAddress ToLoadBalancerBackendAddress(PSLoadBalancerBackendAddress pSLoadBalancerBackendAddress)
        {
            Microsoft.Azure.Management.Network.Models.VirtualNetwork virtualNetworkConfig = null;

            if (pSLoadBalancerBackendAddress.VirtualNetwork != null)
            {
                virtualNetworkConfig = new Microsoft.Azure.Management.Network.Models.VirtualNetwork(pSLoadBalancerBackendAddress.VirtualNetwork.Id);
            }

            var backendAddress = new LoadBalancerBackendAddress();
            backendAddress.Name = pSLoadBalancerBackendAddress.Name;
            backendAddress.IpAddress = pSLoadBalancerBackendAddress.IpAddress;
            backendAddress.VirtualNetwork = virtualNetworkConfig;

            return backendAddress;
        }
    }
}
