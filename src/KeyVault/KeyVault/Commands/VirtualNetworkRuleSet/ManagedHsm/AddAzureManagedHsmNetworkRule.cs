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
    /// Add network rules (IP ranges and/or virtual network resource IDs) to a Managed HSM.
    /// Mirrors Add-AzKeyVaultNetworkRule for Managed HSM resources.
    /// </summary>
    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "KeyVaultManagedHsmNetworkRule", SupportsShouldProcess = true, DefaultParameterSetName = ByNameParameterSet)]
    [OutputType(typeof(PSManagedHsm))]
    public class AddAzureManagedHsmNetworkRule : ManagedHsmNetworkRuleSetBase
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

            if (ShouldProcess(Name, Properties.Resources.AddNetworkRule))
            {
                bool ipSpecified = IsIpAddressRangeSpecified;
                bool vnetSpecified = IsVirtualNetworkResourceIdSpecified;
                if (!ipSpecified && !vnetSpecified)
                {
                    throw new ArgumentException("At least one of IpAddressRange or VirtualNetworkResourceId must be specified.");
                }

                ValidateArrayInputs();
                var existing = GetCurrentManagedHsm(Name, ResourceGroupName);
                var current = existing.OriginalManagedHsm.Properties.NetworkAcls;

                var currentIp = current?.IPRules != null ? new List<string>(current.IPRules.Select(r => r.Value)) : new List<string>();
                var currentVnet = current?.VirtualNetworkRules != null ? new List<string>(current.VirtualNetworkRules.Select(r => r.Id)) : new List<string>();

                // Merge new entries, avoiding duplicates (case-insensitive) – mirrors Key Vault merge helper semantics
                if (ipSpecified)
                {
                    currentIp = MergeInputToSource(IpAddressRange, currentIp).ToList();
                }
                if (vnetSpecified)
                {
                    currentVnet = MergeInputToSource(VirtualNetworkResourceId, currentVnet).ToList();
                }

                // Derive effective DefaultAction and Bypass in a readable step-wise fashion.
                // Start with current values (if any), else fall back to documented defaults (Allow / AzureServices).
                PSManagedHsmNetworkRuleDefaultActionEnum effectiveDefault = PSManagedHsmNetworkRuleDefaultActionEnum.Allow;
                if (current?.DefaultAction != null && Enum.TryParse(current.DefaultAction, true, out PSManagedHsmNetworkRuleDefaultActionEnum parsedDefault))
                {
                    effectiveDefault = parsedDefault;
                }

                PSManagedHsmNetworkRuleBypassEnum effectiveBypass = PSManagedHsmNetworkRuleBypassEnum.AzureServices;
                if (current?.Bypass != null && Enum.TryParse(current.Bypass, true, out PSManagedHsmNetworkRuleBypassEnum parsedBypass))
                {
                    effectiveBypass = parsedBypass;
                }

                // Service rule: if PublicNetworkAccess is Enabled AND any IP/VNet rules exist, DefaultAction must be Deny.
                bool publicEnabled = existing.PublicNetworkAccess != null && existing.PublicNetworkAccess.Equals("Enabled", StringComparison.OrdinalIgnoreCase);
                bool anyRules = (currentIp.Count > 0) || (currentVnet.Count > 0);

                if (publicEnabled && anyRules && effectiveDefault == PSManagedHsmNetworkRuleDefaultActionEnum.Allow)
                {
                    effectiveDefault = PSManagedHsmNetworkRuleDefaultActionEnum.Deny;
                    WriteWarning("DefaultAction automatically set to Deny because PublicNetworkAccess is Enabled and IP or Virtual Network rules are specified.");
                }

                var updated = new PSManagedHsmNetworkRuleSet(effectiveDefault, effectiveBypass, currentIp, currentVnet);
                var result = UpdateCurrentManagedHsm(existing, updated);
                
                if (PassThru.IsPresent)
                {
                    WriteObject(result);
                }
            }
        }

        private static IList<string> MergeInputToSource(string[] additions, IList<string> existing)
        {
            if (additions == null || additions.Length == 0)
            {
                return existing ?? new List<string>();
            }
            if (existing == null || existing.Count == 0)
            {
                return new List<string>(additions);
            }
            var updated = new List<string>(existing);
            foreach (var candidate in additions)
            {
                if (candidate == null) continue;
                if (updated.FindIndex(x => string.Equals(x, candidate, StringComparison.OrdinalIgnoreCase)) == -1)
                {
                    updated.Add(candidate);
                }
            }
            return updated;
        }
    }
}
