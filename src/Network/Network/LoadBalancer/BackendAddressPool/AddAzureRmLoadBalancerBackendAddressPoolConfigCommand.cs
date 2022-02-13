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
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Add, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "LoadBalancerBackendAddressPoolConfig", SupportsShouldProcess = true), OutputType(typeof(PSLoadBalancer))]
    public partial class AddAzureRmLoadBalancerBackendAddressPoolConfigCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The reference of the load balancer resource.",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public PSLoadBalancer LoadBalancer { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Name of the backend address pool.")]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Gateway Load Balancer provider configurations.")]
        public PSTunnelInterface[] TunnelInterface { get; set; }

        public override void Execute()
        {
            // BackendAddressPools
            if (this.LoadBalancer.BackendAddressPools == null)
            {
                this.LoadBalancer.BackendAddressPools = new List<PSBackendAddressPool>();
            }

            var existingBackendAddressPool = this.LoadBalancer.BackendAddressPools.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));
            if (existingBackendAddressPool != null)
            {
                throw new ArgumentException("BackendAddressPool with the specified name already exists");
            }

            var vBackendAddressPool = new PSBackendAddressPool();

            vBackendAddressPool.Name = this.Name;
            vBackendAddressPool.TunnelInterfaces = this.TunnelInterface?.ToList();

            var generatedId = string.Format(
                "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/loadBalancers/{2}/{3}/{4}",
                this.NetworkClient.NetworkManagementClient.SubscriptionId,
                this.LoadBalancer.ResourceGroupName,
                this.LoadBalancer.Name,
                "BackendAddressPools",
                this.Name);
            vBackendAddressPool.Id = generatedId;

            this.LoadBalancer.BackendAddressPools.Add(vBackendAddressPool);
            WriteObject(this.LoadBalancer, true);
        }
    }
}
