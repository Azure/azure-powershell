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
    /// Update (replace) the network rule set for a Managed HSM. Virtual network rules are not supported.
    /// If IP rules are specified (or retained) DefaultAction must be Deny; the cmdlet will throw otherwise.
    /// Mirrors Key Vault pattern except for the stricter MHSM rule (no VNet rules, no Allow+IPs) and does not silently mutate DefaultAction.
    /// </summary>
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "KeyVaultManagedHsmNetworkRuleSet", SupportsShouldProcess = true, DefaultParameterSetName = ByNameParameterSet)]
    [OutputType(typeof(PSManagedHsm))]
    public class UpdateAzureManagedHsmNetworkRuleSet : ManagedHsmNetworkRuleSetBase
    {
        private const string ByNameParameterSet = "ByName";
        private const string ByInputObjectParameterSet = "ByInputObject";
        private const string ByResourceIdParameterSet = "ByResourceId";

        #region Parameters
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ByNameParameterSet,
            HelpMessage = "Specifies the name of a Managed HSM whose network rule set is being modified.")]
        [ResourceNameCompleter("Microsoft.KeyVault/managedHSMs", nameof(ResourceGroupName))]
        [Alias("HsmName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false,
            Position = 1,
            ParameterSetName = ByNameParameterSet,
            HelpMessage = "Specifies the resource group name of the Managed HSM whose network rule set is being modified.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ByInputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "Managed HSM object.")]
        [ValidateNotNullOrEmpty]
        public PSManagedHsm InputObject { get; set; }

        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ByResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Managed HSM resource Id.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies default action of network rule.")]
        public PSManagedHsmNetworkRuleDefaultActionEnum? DefaultAction { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies bypass of network rule.")]
        public PSManagedHsmNetworkRuleBypassEnum? Bypass { get; set; }
        #endregion

        public override void ExecuteCmdlet()
        {
            if (InputObject != null)
            {
                Name = InputObject.Name;
                ResourceGroupName = InputObject.ResourceGroupName;
            }
            else if (ResourceId != null)
            {
                var resourceIdentifier = new ResourceIdentifier(ResourceId);
                Name = resourceIdentifier.ResourceName;
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
            }

            if (ShouldProcess(Name, Properties.Resources.UpdateNetworkRule))
            {
                bool isIpAddressRangeSpecified = IsIpAddressRangeSpecified;
                bool isVirtualNetResIdSpecified = IsVirtualNetworkResourceIdSpecified;
                if (isVirtualNetResIdSpecified)
                {
                    throw new NotSupportedException("Virtual network rules are not supported for Managed HSM.");
                }
                if (!DefaultAction.HasValue && !Bypass.HasValue && !isIpAddressRangeSpecified)
                {
                    throw new ArgumentException("At least one of DefaultAction, Bypass, or IpAddressRange must be specified.");
                }

                ValidateArrayInputs(); // will also guard against unsupported arrays

                var existingHsm = GetCurrentManagedHsm(Name, ResourceGroupName);
                var updatedRuleSet = ConvertInputToRuleSet(existingHsm, isIpAddressRangeSpecified, isVirtualNetResIdSpecified);

                var updatedHsm = UpdateCurrentManagedHsm(existingHsm, updatedRuleSet);
                if (PassThru.IsPresent)
                {
                    WriteObject(updatedHsm);
                }

                WriteDisabledWarning(existingHsm?.OriginalManagedHsm?.Properties?.NetworkAcls, updatedHsm?.OriginalManagedHsm?.Properties?.NetworkAcls);
            }
        }

        private PSManagedHsmNetworkRuleSet ConvertInputToRuleSet(
            PSManagedHsm existingHsm,
            bool isIpAddressRangeSpecified,
            bool isVirtualNetworkResourceIdSpecified)
        {
            var existingService = existingHsm?.OriginalManagedHsm?.Properties?.NetworkAcls;

            // DefaultAction
            PSManagedHsmNetworkRuleDefaultActionEnum defaultAct = PSManagedHsmNetworkRuleDefaultActionEnum.Allow;
            if (existingService?.DefaultAction != null && Enum.TryParse(existingService.DefaultAction, true, out PSManagedHsmNetworkRuleDefaultActionEnum parsedDefault))
            {
                defaultAct = parsedDefault;
            }

            // Override if parameter specified
            if (DefaultAction.HasValue)
            {
                defaultAct = DefaultAction.Value;
            }

            // Bypass
            PSManagedHsmNetworkRuleBypassEnum bypass = PSManagedHsmNetworkRuleBypassEnum.AzureServices;
            if (existingService?.Bypass != null && Enum.TryParse(existingService.Bypass, true, out PSManagedHsmNetworkRuleBypassEnum parsedBypass))
            {
                bypass = parsedBypass;
            }
            if (Bypass.HasValue)
            {
                bypass = Bypass.Value;
            }

            // IP Ranges
            IList<string> ipAddressRanges = existingService?.IPRules != null
                ? new List<string>(existingService.IPRules.Select(r => r.Value))
                : new List<string>();
            if (isIpAddressRangeSpecified)
            {
                ipAddressRanges = IpAddressRange == null ? null : new List<string>(IpAddressRange);
            }

            if (isVirtualNetworkResourceIdSpecified)
            {
                throw new NotSupportedException("Virtual network rules are not supported for Managed HSM.");
            }

            // Enforcement: cannot have IP rules with DefaultAction Allow
            if (ipAddressRanges != null && ipAddressRanges.Count > 0 && defaultAct == PSManagedHsmNetworkRuleDefaultActionEnum.Allow)
            {
                throw new InvalidOperationException("Cannot specify both IP network rules & DefaultAction Allow together. Please specify -DefaultAction Deny or remove IPRules.");
            }

            return new PSManagedHsmNetworkRuleSet(defaultAct, bypass, ipAddressRanges, null);
        }

        private void WriteDisabledWarning(Microsoft.Azure.Management.KeyVault.Models.MhsmNetworkRuleSet existingRuleSet,
            Microsoft.Azure.Management.KeyVault.Models.MhsmNetworkRuleSet updatedRuleSet)
        {
            // Mirror Key Vault pattern: warn when transitioning from Deny -> Allow (i.e. firewall effectively disabled).
            if (existingRuleSet == null || !string.Equals(existingRuleSet.DefaultAction, "Deny", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            var updatedDefault = updatedRuleSet?.DefaultAction ?? "Allow"; // if null, treat as Allow as service would.
            if (string.Equals(updatedDefault, "Allow", StringComparison.OrdinalIgnoreCase))
            {
                WriteWarning("Changing DefaultAction to Allow may open public access to the Managed HSM unless restricted by other settings.");
            }
        }
    }
}
