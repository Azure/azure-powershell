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
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VpnClientConnectionConfiguration"), OutputType(typeof(PSVpnClientRootCertificate))]
    public class NewAzureVpnClientConnectionConfigurationCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the Virtual Network Gateway Policy Group Member")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Virtual Network Gateway Policy Groups")]
        public PSResourceId[] VirtualNetworkGatewayPolicyGroups { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The Associatted client address pool")]
        public PSAddressSpace VpnClientAddressPool { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            var policyGroup = new PSClientConnectionConfiguration();
            policyGroup.Name = this.Name;
            policyGroup.VirtualNetworkGatewayPolicyGroups = this.VirtualNetworkGatewayPolicyGroups.ToList();
            policyGroup.VpnClientAddressPool = this.VpnClientAddressPool;
            WriteObject(policyGroup);
        }
    }
}
