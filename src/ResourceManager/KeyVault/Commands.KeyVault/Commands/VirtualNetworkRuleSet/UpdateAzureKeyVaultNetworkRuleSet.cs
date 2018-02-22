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
using System.Management.Automation;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.KeyVault
{
    /// <summary>
    /// Update network rule set
    /// NOTE: Define VaultName & ResourceGroupName in this class instead of base one because TAB order for input.
    /// </summary>
    [Cmdlet(VerbsData.Update, "AzureRmKeyVaultNetworkRuleSet",
        SupportsShouldProcess = true,
        HelpUri = Constants.KeyVaultHelpUri)]
    [OutputType(typeof(PSVault))]
    public class UpdateAzureKeyVaultNetworkRuleSet : KeyVaultNetworkRuleSetBase
    {
        #region Input Parameter Definitions
        /// <summary>
        /// Vault name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the name of a key vault whose network rule is being modified.")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(Mandatory = false,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the name of the resource group associated with the key vault whose network rule is being modified.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Default action for network rule set
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies default action of network rule.")]
        public PSNetWorkRuleDefaultActionEnum? DefaultAction { get; set; }

        /// <summary>
        /// Bypass for network rule set
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies bypass of network rule.")]
        public PSNetWorkRuleBypassEnum? Bypass { get; set; }
        #endregion


        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(VaultName, Properties.Resources.UpdateNetworkRule))
            {
                bool isIpAddressRangeSpecified = base.IsIpAddressRangeSpecified;
                bool isVirtualNetResIdSpecified = base.IsVirtualNetworkResourceIdSpecified;
                if (!DefaultAction.HasValue && !Bypass.HasValue && !isIpAddressRangeSpecified && !isVirtualNetResIdSpecified)
                {
                    throw new ArgumentException("At least one of DefaultAction, Bypass, IpAddressRange or VirtualNetworkResourceId must be specified.");
                }

                base.ValidateArrayInputs();

                PSVault existingVault = base.GetCurrentVault(this.VaultName, this.ResourceGroupName);

                PSVaultNetworkRuleSet updatedNetworkAcls = ConvertInputToRuleSet(
                    existingVault.NetworkAcls, isIpAddressRangeSpecified, isVirtualNetResIdSpecified);

                // Update the vault
                PSVault updatedVault = UpdateCurrentVault(existingVault, updatedNetworkAcls);

                if (PassThru.IsPresent)
                    WriteObject(updatedVault);

                WriteDisabledWarning(existingVault.NetworkAcls, updatedVault.NetworkAcls);
            }
        }

        private PSVaultNetworkRuleSet ConvertInputToRuleSet(
            PSVaultNetworkRuleSet existingNetworkRuleSet, bool isIpAddressRangeSpecified, bool isVirtualNetworkResourceIdSpecified)
        {
            PSNetWorkRuleDefaultActionEnum defaultAct = existingNetworkRuleSet.DefaultAction;
            if (this.DefaultAction.HasValue)
            {
                defaultAct = this.DefaultAction.Value;
            }

            PSNetWorkRuleBypassEnum bypass = existingNetworkRuleSet.Bypass;
            if (this.Bypass.HasValue)
            {
                bypass = this.Bypass.Value;
            }

            IList<string> ipAddressRanges = existingNetworkRuleSet.IpAddressRanges;
            if (isIpAddressRangeSpecified)
            {
                ipAddressRanges = this.IpAddressRange == null ? null : new List<string>(this.IpAddressRange);
            }

            IList<string> virtualNetworkResourceId = existingNetworkRuleSet.VirtualNetworkResourceIds;
            if (isVirtualNetworkResourceIdSpecified)
            {
                virtualNetworkResourceId = this.VirtualNetworkResourceId == null ? null : new List<string>(this.VirtualNetworkResourceId);
            }

            return new PSVaultNetworkRuleSet(defaultAct, bypass, ipAddressRanges, virtualNetworkResourceId);
        }

        private void WriteDisabledWarning(PSVaultNetworkRuleSet existingRuleSet, PSVaultNetworkRuleSet updatedRuleSet)
        {
            if (existingRuleSet.DefaultAction != PSNetWorkRuleDefaultActionEnum.Deny)
                return;

            PSNetWorkRuleDefaultActionEnum updatedDefaultAction = 
                updatedRuleSet == null ? PSNetWorkRuleDefaultActionEnum.Allow : updatedRuleSet.DefaultAction;

            if (updatedDefaultAction == PSNetWorkRuleDefaultActionEnum.Allow)
            {
                WriteWarning(Properties.Resources.UpdateNetworkRuleWarning);
            }
        }
    }
}
