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

using System.Management.Automation;
using System.Net;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    [Cmdlet(
        VerbsCommon.Set,
        AzureInternalLoadBalancerNoun,
        DefaultParameterSetName = ServiceAndSlotParamSet),
    OutputType(
        typeof(ManagementOperationContext))]
    public class SetAzureInternalLoadBalancer : ServiceManagementBaseCmdlet
    {
        protected const string AzureInternalLoadBalancerNoun = "AzureInternalLoadBalancer";
        protected const string ServiceAndSlotParamSet = "ServiceAndSlot";
        protected const string SubnetNameOnlyParamSet = "SubnetNameOnly";
        protected const string SubnetNameAndIPParamSet = "SubnetNameAndIP";

        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Internal Load Balancer Name.")]
        [ValidateNotNullOrEmpty]
        public string InternalLoadBalancerName { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Service Name.")]
        [ValidateNotNullOrEmpty]
        public string ServiceName { get; set; }

        [Parameter(
            ParameterSetName = SubnetNameOnlyParamSet,
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Subnet Name.")]
        [Parameter(ParameterSetName = SubnetNameAndIPParamSet,
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Subnet Name.")]
        [ValidateNotNullOrEmpty]
        public string SubnetName { get; set; }

        [Parameter(
            ParameterSetName = SubnetNameAndIPParamSet,
            Mandatory = true,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Subnet IP Address.")]
        [ValidateNotNullOrEmpty]
        public IPAddress StaticVNetIPAddress { get; set; }

        protected override void OnProcessRecord()
        {
            ServiceManagementProfile.Initialize();
            
            var parameters = new LoadBalancerUpdateParameters()
            {
                Name = this.InternalLoadBalancerName,
                FrontendIPConfiguration = new FrontendIPConfiguration
                {
                    Type = FrontendIPConfigurationType.Private,
                    SubnetName = this.SubnetName,
                    StaticVirtualNetworkIPAddress = this.StaticVNetIPAddress == null ? null
                                                  : this.StaticVNetIPAddress.ToString()
                }
            };

            ExecuteClientActionNewSM(null,
                CommandRuntime.ToString(),
                () =>
                {
                    var deploymentName = this.ComputeClient.Deployments.GetBySlot(
                        this.ServiceName,
                        DeploymentSlot.Production).Name;

                    return this.ComputeClient.LoadBalancers.Update(
                        this.ServiceName,
                        deploymentName,
                        this.InternalLoadBalancerName,
                        parameters);
                });
        }
    }
}
