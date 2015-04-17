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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Set, "AzureLoadBalancerBackendAddressPoolConfig"), OutputType(typeof(PSLoadBalancer))]
    public class SetAzureLoadBalancerBackendAddressPoolConfigCommand : AzureLoadBalancerBackendAddressPoolConfigBase
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the BackendAddressPool")]
        [ValidateNotNullOrEmpty]
        public override string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The load balancer")]
        public PSLoadBalancer LoadBalancer { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var backendAddressPool = this.LoadBalancer.BackendAddressPools.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (backendAddressPool == null)
            {
                throw new ArgumentException("BackendAddressPool with the specified name does not exist");
            }

            backendAddressPool.Name = this.Name;
            

            if (this.BackendIpConfigurationId != null)
            {
                backendAddressPool.BackendIpConfigurations = new List<PSResourceId>();
                foreach (var backendIpConfigurationId in this.BackendIpConfigurationId)
                {
                    var resourceId = new PSResourceId();
                    resourceId.Id = backendIpConfigurationId;
                    backendAddressPool.BackendIpConfigurations.Add(resourceId);
                }
            }
            else
            {
                backendAddressPool.BackendIpConfigurations = null;
            }

            WriteObject(this.LoadBalancer);
        }
    }
}
