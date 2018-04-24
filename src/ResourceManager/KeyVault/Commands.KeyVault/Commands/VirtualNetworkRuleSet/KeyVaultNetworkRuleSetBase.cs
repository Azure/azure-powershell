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
using PSKeyVaultModels = Microsoft.Azure.Commands.KeyVault.Models;
using PSKeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.KeyVault.Models;


namespace Microsoft.Azure.Commands.KeyVault
{
    public class KeyVaultNetworkRuleSetBase : KeyVaultManagementCmdletBase
    {
        #region Input Parameter Definitions
        /// <summary>
        /// IP address range for network rule set
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Specifies allowed network IP address range of network rule.")]
        [ValidateCount(0, 127)]
        public string[] IpAddressRange { get; set; }

        /// <summary>
        /// Virtual network resource IDs for network rule set
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Specifies allowed virtual network resource identifier of network rule.")]
        [ValidateCount(0, 127)]
        public string[] VirtualNetworkResourceId { get; set; }

        /// <summary>
        /// Flag for pass-through output object
        /// </summary>
        [Parameter(Mandatory = false,
           HelpMessage = "This Cmdlet does not return an object by default. If this switch is specified, it returns the updated key vault object.")]
        public SwitchParameter PassThru { get; set; }
        #endregion


        protected bool IsIpAddressRangeSpecified
        {
            get { return MyInvocation.BoundParameters.ContainsKey("IpAddressRange"); }
            // The MyInvocation.BoundParameters.ContainsKey() DOES NOT WORK WITH POSITIONED PARAMETER!!!
        }

        protected bool IsVirtualNetworkResourceIdSpecified
        {
            get { return MyInvocation.BoundParameters.ContainsKey("VirtualNetworkResourceId"); }
            // The MyInvocation.BoundParameters.ContainsKey() DOES NOT WORK WITH POSITIONED PARAMETER!!!
        }

        protected void ValidateArrayInputs()
        {
            if (IpAddressRange != null &&
                IpAddressRange.Length > 0 &&
                IpAddressRange.Where(item => { return string.IsNullOrWhiteSpace(item); }).Any())
            {
                throw new ArgumentException("The array of IpAddressRange input cannot contain null or empty strings");
            }

            if (VirtualNetworkResourceId != null &&
                VirtualNetworkResourceId.Length > 0 &&
                VirtualNetworkResourceId.Where(item => { return string.IsNullOrWhiteSpace(item); }).Any())
            {
                throw new ArgumentException("The array of VirtualNetworkResourceId input cannot contain null or empty strings");
            }
        }

        protected PSKeyVault GetCurrentVault(string vaultName, string resourceGroupName)
        {
            string resGroupName = resourceGroupName;
            if (string.IsNullOrWhiteSpace(resGroupName))
            {
                resGroupName = GetResourceGroupName(vaultName);
            }

            // Get the existing vault
            PSKeyVault vault = null;
            if (!string.IsNullOrWhiteSpace(resGroupName))
            {
                vault = KeyVaultManagementClient.GetVault(vaultName, resGroupName);
            }

            if (vault == null)
            {
                throw new ArgumentException(string.Format(PSKeyVaultProperties.Resources.VaultNotFound, vaultName, resGroupName));
            }

            return vault;
        }

        protected PSKeyVault UpdateCurrentVault(PSKeyVault existingVault, PSKeyVaultNetworkRuleSet updatedNetworkAcls)
        {
            return KeyVaultManagementClient.UpdateVault(
                existingVault,
                existingVault.AccessPolicies,
                existingVault.EnabledForDeployment,
                existingVault.EnabledForTemplateDeployment,
                existingVault.EnabledForDiskEncryption,
                existingVault.EnableSoftDelete,
                existingVault.EnablePurgeProtection,
                updatedNetworkAcls,
                ActiveDirectoryClient);
        }
    }
}
