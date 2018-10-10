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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, "AzureRmLoadBalancerInboundNatPoolConfig"), OutputType(typeof(PSInboundNatPool))]
    public class NewAzureLoadBalancerInboundNatPoolConfigCommand : AzureLoadBalancerInboundNatPoolConfigBase
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the Inbound NAT pool")]
        [ValidateNotNullOrEmpty]
        public override string Name { get; set; }

        public override void Execute()
        {

            base.Execute();
            var inboundNatPool = new PSInboundNatPool();
            inboundNatPool.Name = this.Name;
            inboundNatPool.Protocol = this.Protocol;
            inboundNatPool.FrontendPortRangeStart = this.FrontendPortRangeStart;
            inboundNatPool.FrontendPortRangeEnd = this.FrontendPortRangeEnd;
            inboundNatPool.BackendPort = this.BackendPort;

            if (!string.IsNullOrEmpty(this.FrontendIpConfigurationId))
            {
                inboundNatPool.FrontendIPConfiguration = new PSResourceId() { Id = this.FrontendIpConfigurationId };
            }

            inboundNatPool.Id =
                ChildResourceHelper.GetResourceNotSetId(
                    this.NetworkClient.NetworkManagementClient.SubscriptionId,
                    Microsoft.Azure.Commands.Network.Properties.Resources.LoadBalancerInboundNatPoolName,
                    this.Name);

            WriteObject(inboundNatPool);
        }
    }
}
