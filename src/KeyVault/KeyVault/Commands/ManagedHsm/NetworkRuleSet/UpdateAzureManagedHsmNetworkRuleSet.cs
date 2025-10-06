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
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.KeyVault.Commands.ManagedHsm.NetworkRuleSet
{
    /// <summary>
    /// Authoritatively update a Managed HSM network rule set (default action, bypass, IP ranges, vnet IDs).
    /// Mirrors Update-AzKeyVaultNetworkRuleSet for Managed HSM resources.
    /// </summary>
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "KeyVaultManagedHsmNetworkRuleSet", SupportsShouldProcess = true, DefaultParameterSetName = ByNameParameterSet)]
    [OutputType(typeof(PSManagedHsm))]
    public class UpdateAzureManagedHsmNetworkRuleSet : ManagedHsmNetworkRuleSetBase
    {
        private const string ByNameParameterSet = "ByName";
        private const string ByInputObjectParameterSet = "ByInputObject";
        private const string ByResourceIdParameterSet = "ByResourceId";

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ByNameParameterSet, HelpMessage = "Name of the managed HSM.")]
        [ResourceNameCompleter("Microsoft.KeyVault/managedHSMs", nameof(ResourceGroupName))]
        [Alias("HsmName")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, Position = 1, ParameterSetName = ByNameParameterSet, HelpMessage = "Resource group name.")]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ByInputObjectParameterSet, ValueFromPipeline = true, HelpMessage = "Managed HSM object.")]
        public PSManagedHsm InputObject { get; set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ByResourceIdParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Managed HSM resource Id.")]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Specifies default action of network rule.")]
        public PSManagedHsmNetworkRuleDefaultActionEnum? DefaultAction { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Specifies bypass of network rule.")]
        public PSManagedHsmNetworkRuleBypassEnum? Bypass { get; set; }

        public override void ExecuteCmdlet()
        {
            if (InputObject != null)
            {
                Name = InputObject.Name;
                ResourceGroupName = InputObject.ResourceGroupName;
            }
            else if (ResourceId != null)
            {
                var id = new ResourceIdentifier(ResourceId);
                Name = id.ResourceName;
                ResourceGroupName = id.ResourceGroupName;
            }

            if (ShouldProcess(Name, Properties.Resources.UpdateNetworkRule))
            {
                bool ipSpecified = IsIpAddressRangeSpecified;
                bool vnetSpecified = IsVirtualNetworkResourceIdSpecified;
                if (!DefaultAction.HasValue && !Bypass.HasValue && !ipSpecified && !vnetSpecified)
                {
                    throw new ArgumentException("At least one of DefaultAction, Bypass, IpAddressRange or VirtualNetworkResourceId must be specified.");
                }

                ValidateArrayInputs();
                var existing = GetCurrentManagedHsm(Name, ResourceGroupName);
                var current = existing.OriginalManagedHsm.Properties.NetworkAcls;

                var effectiveDefault = current?.DefaultAction != null && Enum.TryParse(current.DefaultAction, true, out PSManagedHsmNetworkRuleDefaultActionEnum da) ? da : PSManagedHsmNetworkRuleDefaultActionEnum.Allow;
                var effectiveBypass = current?.Bypass != null && Enum.TryParse(current.Bypass, true, out PSManagedHsmNetworkRuleBypassEnum bp) ? bp : PSManagedHsmNetworkRuleBypassEnum.AzureServices;
                var ipRanges = current?.IPRules != null ? new List<string>(current.IPRules.Select(r => r.Value)) : new List<string>();
                var vnetIds = current?.VirtualNetworkRules != null ? new List<string>(current.VirtualNetworkRules.Select(r => r.Id)) : new List<string>();

                if (DefaultAction.HasValue) effectiveDefault = DefaultAction.Value;
                if (Bypass.HasValue) effectiveBypass = Bypass.Value;
                if (ipSpecified) ipRanges = IpAddressRange == null ? null : new List<string>(IpAddressRange);
                if (vnetSpecified) vnetIds = VirtualNetworkResourceId == null ? null : new List<string>(VirtualNetworkResourceId);

                var updated = new PSManagedHsmNetworkRuleSet(effectiveDefault, effectiveBypass, ipRanges, vnetIds);
                if (existing.PublicNetworkAccess != null && existing.PublicNetworkAccess.Equals("Enabled", StringComparison.OrdinalIgnoreCase)
                    && ((ipRanges != null && ipRanges.Count > 0) || (vnetIds != null && vnetIds.Count > 0))
                    && updated.DefaultAction == PSManagedHsmNetworkRuleDefaultActionEnum.Allow)
                {
                    if (DefaultAction.HasValue && DefaultAction.Value == PSManagedHsmNetworkRuleDefaultActionEnum.Allow)
                    {
                        // User explicitly asked for invalid combination – flip and warn.
                        WriteWarning("DefaultAction changed to Deny because PublicNetworkAccess is Enabled and IP or Virtual Network rules are specified.");
                    }
                    updated = new PSManagedHsmNetworkRuleSet(PSManagedHsmNetworkRuleDefaultActionEnum.Deny, updated.Bypass, ipRanges, vnetIds);
                }
                var result = UpdateCurrentManagedHsm(existing, updated);
                if (PassThru.IsPresent)
                {
                    WriteObject(result);
                }
            }
        }
    }
}
