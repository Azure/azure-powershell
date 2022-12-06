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
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkGatewayPolicyGroup"), OutputType(typeof(PSVirtualNetworkGatewayPolicyGroup))]
    public class NewAzureVirtualNetworkGatewayPolicyGroupCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the Virtual Network Gateway Policy Group")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
                   Mandatory = true,
                   HelpMessage = "The Priority of the policy group.",
                   ValueFromPipelineByPropertyName = true)]
        public int Priority { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Flag to set this as Default Policy Group on this VpnServerConfiguration.")]
        public SwitchParameter DefaultPolicyGroup { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The list of Policy members.")]
        public PSVirtualNetworkGatewayPolicyGroupMember[] PolicyMember { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            var policyGroup = new PSVirtualNetworkGatewayPolicyGroup();
            policyGroup.Name = this.Name;
            policyGroup.Priority = this.Priority;
            policyGroup.IsDefault = this.DefaultPolicyGroup.IsPresent;
            policyGroup.PolicyMembers = (this.PolicyMember.ToList());
            WriteObject(policyGroup);
        }
    }
}
