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
    /// Update network rule set for a Managed HSM.
    /// Structured intentionally to mirror Update-AzKeyVaultNetworkRuleSet for consistency.
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
                if (!DefaultAction.HasValue && !Bypass.HasValue && !isIpAddressRangeSpecified && !isVirtualNetResIdSpecified)
                {
                    throw new ArgumentException("At least one of DefaultAction, Bypass, IpAddressRange or VirtualNetworkResourceId must be specified.");
                }

                ValidateArrayInputs();

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

            // VNet IDs
            IList<string> vnetIds = existingService?.VirtualNetworkRules != null
                ? new List<string>(existingService.VirtualNetworkRules.Select(r => r.Id))
                : new List<string>();
            if (isVirtualNetworkResourceIdSpecified)
            {
                vnetIds = VirtualNetworkResourceId == null ? null : new List<string>(VirtualNetworkResourceId);
            }

            return new PSManagedHsmNetworkRuleSet(defaultAct, bypass, ipAddressRanges, vnetIds);
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
