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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.KeyVault
{
    /// <summary>
    /// Update network rule set
    /// NOTE: Define VaultName &amp; ResourceGroupName in this class instead of base one because TAB order for input.
    /// </summary>
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "KeyVaultNetworkRuleSet",DefaultParameterSetName = ByVaultNameParameterSet,SupportsShouldProcess = true)]
    [OutputType(typeof(PSKeyVault))]
    public class UpdateAzureKeyVaultNetworkRuleSet : KeyVaultNetworkRuleSetBase
    {
        private const string ByVaultNameParameterSet = "ByVaultName";
        private const string ByInputObjectParameterSet = "ByInputObject";
        private const string ByResourceIdParameterSet = "ByResourceId";

        #region Input Parameter Definitions
        /// <summary>
        /// Vault name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ByVaultNameParameterSet,
            HelpMessage = "Specifies the name of a key vault whose network rule is being modified.")]
        [ResourceNameCompleter("Microsoft.KeyVault/vaults", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        /// <summary>
        /// KeyVault object
        /// </summary>
        [Parameter(Mandatory = true,
                   Position = 0,
                   ParameterSetName = ByInputObjectParameterSet,
                   ValueFromPipeline = true,
                   HelpMessage = "KeyVault object")]
        [ValidateNotNullOrEmpty]
        public PSKeyVault InputObject { get; set; }

        /// <summary>
        /// KeyVault ResourceId
        /// </summary>
        [Parameter(Mandatory = true,
                   Position = 0,
                   ParameterSetName = ByResourceIdParameterSet,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "KeyVault Resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(Mandatory = false,
            Position = 1,
            ParameterSetName = ByVaultNameParameterSet,
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
        public PSKeyVaultNetworkRuleDefaultActionEnum? DefaultAction { get; set; }

        /// <summary>
        /// Bypass for network rule set
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies bypass of network rule.")]
        public PSKeyVaultNetworkRuleBypassEnum? Bypass { get; set; }
        #endregion


        public override void ExecuteCmdlet()
        {
            if (InputObject != null)
            {
                VaultName = InputObject.VaultName;
                ResourceGroupName = InputObject.ResourceGroupName;
            }
            else if (ResourceId != null)
            {
                var resourceIdentifier = new ResourceIdentifier(ResourceId);
                VaultName = resourceIdentifier.ResourceName;
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
            }

            if (ShouldProcess(VaultName, Properties.Resources.UpdateNetworkRule))
            {
                bool isIpAddressRangeSpecified = base.IsIpAddressRangeSpecified;
                bool isVirtualNetResIdSpecified = base.IsVirtualNetworkResourceIdSpecified;
                if (!DefaultAction.HasValue && !Bypass.HasValue && !isIpAddressRangeSpecified && !isVirtualNetResIdSpecified)
                {
                    throw new ArgumentException("At least one of DefaultAction, Bypass, IpAddressRange or VirtualNetworkResourceId must be specified.");
                }

                base.ValidateArrayInputs();

                PSKeyVault existingVault = base.GetCurrentVault(this.VaultName, this.ResourceGroupName);

                PSKeyVaultNetworkRuleSet updatedNetworkAcls = ConvertInputToRuleSet(
                    existingVault.NetworkAcls, isIpAddressRangeSpecified, isVirtualNetResIdSpecified);

                // Update the vault
                PSKeyVault updatedVault = UpdateCurrentVault(existingVault, updatedNetworkAcls);

                if (PassThru.IsPresent)
                    WriteObject(updatedVault);

                WriteDisabledWarning(existingVault.NetworkAcls, updatedVault.NetworkAcls);
            }
        }

        private PSKeyVaultNetworkRuleSet ConvertInputToRuleSet(
            PSKeyVaultNetworkRuleSet existingNetworkRuleSet, bool isIpAddressRangeSpecified, bool isVirtualNetworkResourceIdSpecified)
        {
            PSKeyVaultNetworkRuleDefaultActionEnum defaultAct = existingNetworkRuleSet.DefaultAction;
            if (this.DefaultAction.HasValue)
            {
                defaultAct = this.DefaultAction.Value;
            }

            PSKeyVaultNetworkRuleBypassEnum bypass = existingNetworkRuleSet.Bypass;
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

            return new PSKeyVaultNetworkRuleSet(defaultAct, bypass, ipAddressRanges, virtualNetworkResourceId);
        }

        private void WriteDisabledWarning(PSKeyVaultNetworkRuleSet existingRuleSet, PSKeyVaultNetworkRuleSet updatedRuleSet)
        {
            if (existingRuleSet.DefaultAction != PSKeyVaultNetworkRuleDefaultActionEnum.Deny)
                return;

            PSKeyVaultNetworkRuleDefaultActionEnum updatedDefaultAction = 
                updatedRuleSet == null ? PSKeyVaultNetworkRuleDefaultActionEnum.Allow : updatedRuleSet.DefaultAction;

            if (updatedDefaultAction == PSKeyVaultNetworkRuleDefaultActionEnum.Allow)
            {
                WriteWarning(Properties.Resources.UpdateNetworkRuleWarning);
            }
        }
    }
}
