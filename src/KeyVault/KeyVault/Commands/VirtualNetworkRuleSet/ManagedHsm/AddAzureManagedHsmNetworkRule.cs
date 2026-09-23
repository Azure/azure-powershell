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
    /// Add network IP rules to a Managed HSM.
    /// VNet rules are not supported. If DefaultAction is Allow this operation will fail (user must set Deny first via Update cmdlet).
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
                if (vnetSpecified)
                {
                    throw new NotSupportedException("Virtual network rules are not supported for Managed HSM.");
                }
                if (!ipSpecified)
                {
                    throw new ArgumentException("IpAddressRange must be specified.");
                }

                ValidateArrayInputs(); // will also block VNet param usage
                var existing = GetCurrentManagedHsm(Name, ResourceGroupName);
                var current = existing.OriginalManagedHsm.Properties.NetworkAcls;

                var currentIp = current?.IPRules != null ? new List<string>(current.IPRules.Select(r => r.Value)) : new List<string>();
                var currentVnet = new List<string>(); // Unsupported

                // Merge new entries, avoiding duplicates (case-insensitive) – mirrors Key Vault merge helper semantics
                if (ipSpecified)
                {
                    currentIp = MergeInputToSource(IpAddressRange, currentIp).ToList();
                }
                // vnetSpecified already blocked

                // Derive effective DefaultAction and Bypass from CURRENT state only (no implicit fallback to Allow that could block unnecessarily).
                // If we cannot determine the current DefaultAction we require the user to set it explicitly first.
                if (current == null)
                {
                    throw new InvalidOperationException("Current network ACLs not initialized. Set the DefaultAction (e.g. Deny) using Update-AzKeyVaultManagedHsmNetworkRuleSet before adding IP rules.");
                }

                if (!Enum.TryParse(current.DefaultAction, true, out PSManagedHsmNetworkRuleDefaultActionEnum effectiveDefault))
                {
                    throw new InvalidOperationException("Unable to determine existing DefaultAction. Set it explicitly with Update-AzKeyVaultManagedHsmNetworkRuleSet before adding IP rules.");
                }

                if (!Enum.TryParse(current.Bypass, true, out PSManagedHsmNetworkRuleBypassEnum effectiveBypass))
                {
                    throw new InvalidOperationException("Unable to determine existing Bypass. Set it explicitly with Update-AzKeyVaultManagedHsmNetworkRuleSet before adding IP rules.");
                }

                // Enforcement: cannot add IP rules while DefaultAction is Allow. (We do not change it here.)
                if (effectiveDefault == PSManagedHsmNetworkRuleDefaultActionEnum.Allow)
                {
                    throw new InvalidOperationException("Cannot add IP network rules while DefaultAction is Allow. Run Update-AzKeyVaultManagedHsmNetworkRuleSet -Name <name> -DefaultAction Deny first, then add IP rules.");
                }

                var updated = new PSManagedHsmNetworkRuleSet(effectiveDefault, effectiveBypass, currentIp, null);
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
