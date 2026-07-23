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
using Microsoft.Azure.Commands.KeyVault.Models;

namespace Microsoft.Azure.Commands.KeyVault.Commands.ManagedHsm.NetworkRuleSet
{
    /// <summary>
    /// Creates an in-memory Managed HSM network rule set object (not sent to service).
    /// Mirrors New-AzKeyVaultNetworkRuleSetObject for Managed HSM resources.
    /// </summary>
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "KeyVaultManagedHsmNetworkRuleSetObject")]
    [OutputType(typeof(PSManagedHsmNetworkRuleSet))]
    public class NewAzureManagedHsmNetworkRuleSetObject : KeyVaultManagementCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = "Specifies default action of network rule.")]
        public PSManagedHsmNetworkRuleDefaultActionEnum DefaultAction { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Specifies bypass of network rule.")]
        public PSManagedHsmNetworkRuleBypassEnum Bypass { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Specifies allowed network IP address range of network rule.")]
        public string[] IpAddressRange { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Specifies allowed virtual network resource identifier of network rule.")]
        public string[] VirtualNetworkResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            // Mirror Key Vault style: use MyInvocation.BoundParameters for presence checks (avoid IsParameterBound extension)
            var defaults = new PSManagedHsmNetworkRuleSet();
            var result = new PSManagedHsmNetworkRuleSet(
                MyInvocation.BoundParameters.ContainsKey(nameof(DefaultAction)) ? DefaultAction : defaults.DefaultAction,
                MyInvocation.BoundParameters.ContainsKey(nameof(Bypass)) ? Bypass : defaults.Bypass,
                MyInvocation.BoundParameters.ContainsKey(nameof(IpAddressRange)) ? IpAddressRange : defaults.IpAddressRanges,
                MyInvocation.BoundParameters.ContainsKey(nameof(VirtualNetworkResourceId)) ? VirtualNetworkResourceId : defaults.VirtualNetworkResourceIds);
            WriteObject(result);
        }
    }
}
