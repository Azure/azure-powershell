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

namespace Microsoft.Azure.Commands.KeyVault
{
    /// <summary>
    /// Remove network rule set
    /// NOTE: Define VaultName & ResourceGroupName in this class instead of base one because TAB order for input.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmKeyVaultNetworkRuleSet",
        SupportsShouldProcess = true,
        HelpUri = Constants.KeyVaultHelpUri)]
    [OutputType(typeof(PSKeyVault))]
    public class RemoveAzureRmKeyVaultNetworkRuleSet : KeyVaultNetworkRuleSetBase
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
        #endregion

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(VaultName, Properties.Resources.RemoveNetworkRule))
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
                    ipAddressRanges = RemoveInputFromSource(base.IpAddressRange, existingVault.NetworkAcls.IpAddressRanges);
                }

                IList<string> virtualNetworkResourceId = existingVault.NetworkAcls.VirtualNetworkResourceIds;
                if (isVirtualNetResIdSpecified)
                {
                    virtualNetworkResourceId = 
                        RemoveInputFromSource(base.VirtualNetworkResourceId, existingVault.NetworkAcls.VirtualNetworkResourceIds);
                }

                PSKeyVaultNetworkRuleSet updatedNetworkAcls = new PSKeyVaultNetworkRuleSet(
                    existingVault.NetworkAcls.DefaultAction, existingVault.NetworkAcls.Bypass, ipAddressRanges, virtualNetworkResourceId);

                // Update the vault
                PSKeyVault updatedVault = UpdateCurrentVault(existingVault, updatedNetworkAcls);

                if (PassThru.IsPresent)
                    WriteObject(updatedVault);
            }
        }

        static private IList<string> RemoveInputFromSource(string[] removeTargetList, IList<string> sourceList)
        {
            if (removeTargetList == null || removeTargetList.Length == 0)
            {   // No inputs
                return sourceList;
            }

            if (sourceList == null || sourceList.Count == 0)
            {   // Nothing to remove
                return sourceList;
            }

            List<string> updatedResults = new List<string>(sourceList);
            foreach (string item in removeTargetList)
            {
                int index = updatedResults.FindIndex(x => string.Equals(x, item, StringComparison.OrdinalIgnoreCase));
                if (index != -1)
                {   // Remove item that is in source only
                    updatedResults.RemoveAt(index);
                }
            }

            return updatedResults;
        }
    }
}
