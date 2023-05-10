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
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkGatewayPolicyGroupMember"), OutputType(typeof(PSVirtualNetworkGatewayPolicyGroupMember))]
    public class NewAzureVirtualNetworkGatewayPolicyGroupMemberCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the Virtual Network Gateway Policy Group Member")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The Attribute Type of the policy group member.",
            ValueFromPipelineByPropertyName = true)]
        public string AttributeType { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The Attribute Value")]
        public string AttributeValue { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            var policyGroup = new PSVirtualNetworkGatewayPolicyGroupMember();
            policyGroup.Name = this.Name;
            policyGroup.AttributeType = this.AttributeType;
            policyGroup.AttributeValue = this.AttributeValue;
            WriteObject(policyGroup);
        }
    }
}
