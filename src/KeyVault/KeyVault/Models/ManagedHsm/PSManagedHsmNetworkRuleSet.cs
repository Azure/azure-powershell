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

using System.Collections.Generic;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    /// <summary>
    /// Default action for a Managed HSM network rule set when no rule matches.
    /// Mirrors <see cref="PSKeyVaultNetworkRuleDefaultActionEnum"/> for Key Vault.
    /// </summary>
    public enum PSManagedHsmNetworkRuleDefaultActionEnum { Allow = 0, Deny }

    /// <summary>
    /// Bypass values for Managed HSM network rule evaluation.
    /// Mirrors <see cref="PSKeyVaultNetworkRuleBypassEnum"/> for Key Vault.
    /// </summary>
    public enum PSManagedHsmNetworkRuleBypassEnum { None = 0, AzureServices }

    /// <summary>
    /// PowerShell wrapper representing a Managed HSM network rule set, analogous to <see cref="PSKeyVaultNetworkRuleSet"/>.
    /// This is used exclusively by Managed HSM network rule cmdlets for constructing or updating the service model
    /// (MhsmNetworkRuleSet: ipRules + virtualNetworkRules, defaultAction, bypass).
    /// </summary>
    public class PSManagedHsmNetworkRuleSet
    {
        public PSManagedHsmNetworkRuleSet()
            : this(PSManagedHsmNetworkRuleDefaultActionEnum.Allow, PSManagedHsmNetworkRuleBypassEnum.AzureServices, null, null)
        {
        }

        public PSManagedHsmNetworkRuleSet(
            PSManagedHsmNetworkRuleDefaultActionEnum defaultAction,
            PSManagedHsmNetworkRuleBypassEnum bypass,
            IList<string> ipAddressRanges,
            IList<string> virtualNetworkResourceIds)
        {
            DefaultAction = defaultAction;
            Bypass = bypass;
            IpAddressRanges = ipAddressRanges;
            VirtualNetworkResourceIds = virtualNetworkResourceIds;
        }

        public PSManagedHsmNetworkRuleDefaultActionEnum DefaultAction { get; private set; }
        public PSManagedHsmNetworkRuleBypassEnum Bypass { get; private set; }
        public IList<string> IpAddressRanges { get; private set; }
        public IList<string> VirtualNetworkResourceIds { get; private set; }
    }
}
