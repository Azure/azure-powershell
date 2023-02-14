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
    /// Add network rule
    /// NOTE: Define VaultName &amp; ResourceGroupName in this class instead of base one because TAB order for input.
    /// </summary>
    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "KeyVaultNetworkRule",SupportsShouldProcess = true,DefaultParameterSetName = ByVaultNameParameterSet)]
    [OutputType(typeof(PSKeyVault))]
    public class AddAzureKeyVaultNetworkRule : KeyVaultNetworkRuleSetBase
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

            if (ShouldProcess(VaultName, Properties.Resources.AddNetworkRule))
            {
                bool isIpAddressRangeSpecified = base.IsIpAddressRangeSpecified;
                bool isVirtualNetResIdSpecified = base.IsVirtualNetworkResourceIdSpecified;
                if (!isIpAddressRangeSpecified && !isVirtualNetResIdSpecified)
                {
                    throw new ArgumentException("At least one of IpAddressRange or VirtualNetworkResourceId must be specified.");
                }

                base.ValidateArrayInputs();

                PSKeyVault existingVault = base.GetCurrentVault(this.VaultName, this.ResourceGroupName);

                IList<string> ipAddressRanges = existingVault.NetworkAcls.IpAddressRanges;
                if (isIpAddressRangeSpecified)
                {
                    ipAddressRanges = MergeInputToSource(base.IpAddressRange, existingVault.NetworkAcls.IpAddressRanges);
                }

                IList<string> virtualNetworkResourceId = existingVault.NetworkAcls.VirtualNetworkResourceIds;
                if (isVirtualNetResIdSpecified)
                {
                    virtualNetworkResourceId =
                        MergeInputToSource(base.VirtualNetworkResourceId, existingVault.NetworkAcls.VirtualNetworkResourceIds);
                }


                PSKeyVaultNetworkRuleSet updatedNetworkAcls = new PSKeyVaultNetworkRuleSet(
                    existingVault.NetworkAcls.DefaultAction, existingVault.NetworkAcls.Bypass, ipAddressRanges, virtualNetworkResourceId);

                // Update the vault
                PSKeyVault updatedVault = UpdateCurrentVault(existingVault, updatedNetworkAcls);

                if (PassThru.IsPresent)
                    WriteObject(updatedVault);
            }
        }

        static private IList<string> MergeInputToSource(string[] addedTargetList, IList<string> sourceList)
        {
            if (addedTargetList == null || addedTargetList.Length == 0)
            {   // No inputs
                return sourceList;
            }

            if (sourceList == null || sourceList.Count == 0)
            {
                return new List<string>(addedTargetList);
            }

            List<string> updatedResults = new List<string>(sourceList);
            foreach (string item in addedTargetList)
            {
                int index = updatedResults.FindIndex(x => string.Equals(x, item, StringComparison.OrdinalIgnoreCase));
                if (index == -1)
                {   // Duplicated items are not added
                    updatedResults.Add(item);
                }
            }

            return updatedResults;
        }
    }
}
