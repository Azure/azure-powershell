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
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "LoadBalancerBackendAddressPoolConfig", SupportsShouldProcess = true), OutputType(typeof(PSBackendAddressPool))]
    public partial class NewAzureRmLoadBalancerBackendAddressPoolConfigCommand : NetworkBaseCmdlet
    {
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
            var vBackendAddressPool = new PSBackendAddressPool();

            vBackendAddressPool.Name = this.Name;
            vBackendAddressPool.TunnelInterfaces = this.TunnelInterface?.ToList();

            var generatedId = string.Format(
                "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/loadBalancers/{2}/{3}/{4}",
                this.NetworkClient.NetworkManagementClient.SubscriptionId,
                Microsoft.Azure.Commands.Network.Properties.Resources.ResourceGroupNotSet,
                Microsoft.Azure.Commands.Network.Properties.Resources.LoadBalancerNameNotSet,
                "BackendAddressPools",
                this.Name);
            vBackendAddressPool.Id = generatedId;

            WriteObject(vBackendAddressPool, true);
        }
    }
}