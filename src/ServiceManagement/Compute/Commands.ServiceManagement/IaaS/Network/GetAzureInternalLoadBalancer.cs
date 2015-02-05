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
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Compute.Models;
using Microsoft.WindowsAzure.Management.Compute;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    [Cmdlet(
        VerbsCommon.Get,
        "AzureInternalLoadBalancer"),
    OutputType(
        typeof(InternalLoadBalancerContext))]
    public class GetAzureInternalLoadBalancer : ServiceManagementBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Service Name.")]
        [ValidateNotNullOrEmpty]
        public string ServiceName { get; set; }

        protected override void OnProcessRecord()
        {
            ServiceManagementProfile.Initialize();

            ExecuteClientActionNewSM(
                null,
                CommandRuntime.ToString(),
                () => this.ComputeClient.Deployments.GetBySlot(this.ServiceName, DeploymentSlot.Production),
                (s, d) => d.LoadBalancers == null ? null : d.LoadBalancers.Select(
                    b => new InternalLoadBalancerContext
                    {
                        InternalLoadBalancerName = b.Name,
                        ServiceName = this.ServiceName,
                        DeploymentName = d.Name,
                        IPAddress = b.FrontendIPConfiguration != null && b.FrontendIPConfiguration.StaticVirtualNetworkIPAddress != null ?
                                    b.FrontendIPConfiguration.StaticVirtualNetworkIPAddress : GetInternalLoadBalancerIPAddress(d.VirtualIPAddresses, b.Name),
                        SubnetName = b.FrontendIPConfiguration != null ? b.FrontendIPConfiguration.SubnetName : null,
                        OperationDescription = CommandRuntime.ToString(),
                        OperationId = s.Id,
                        OperationStatus = s.Status.ToString()
                    }));
        }

        private string GetInternalLoadBalancerIPAddress(IList<VirtualIPAddress> virtualIPs, string ilbName)
        {
            var ilbIP = virtualIPs == null || !virtualIPs.Any() ? null
                      : virtualIPs.FirstOrDefault(ip => string.Equals(ip.Name, ilbName, StringComparison.OrdinalIgnoreCase));

            return ilbIP == null ? null : ilbIP.Address;
        }
    }
}
