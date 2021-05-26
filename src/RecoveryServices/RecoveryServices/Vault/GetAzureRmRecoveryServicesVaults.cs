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
using Microsoft.Azure.Management.RecoveryServices.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Retrieves Azure Recovery Services Vault.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesVault")]
    [OutputType(typeof(ARSVault))]
    public class GetAzureRmRecoveryServicesVaults : RecoveryServicesCmdletBase
    {

        public const string ByTagObjectParameterSet = "ByTagObjectParameterSet";
        public const string ByTagNameValueParameterSet = "ByTagNameValueParameterSet";
        public const string ByNameVaultResourceGroupParameterSet = "ByNameVaultResourceGroupParameterSet";

        #region Parameters
        /// <summary>
        /// Gets or sets Resource Group name.
        /// </summary>
        [Parameter(Position = 1)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets Resource Name.
        /// </summary>
        [Parameter(Position = 2)]
        public string Name { get; set; }

        /// <summary>
        /// TagName Filter for a Recovery Services Vault.
        /// </summary>
        [Parameter(ParameterSetName = ByTagNameValueParameterSet, Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string TagName { get; set; }

        /// <summary>
        /// TagValue Filter for a Recovery Services Vault.
        /// </summary>
        [Parameter(ParameterSetName = ByTagNameValueParameterSet, Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string TagValue { get; set; }

        /// <summary>
        /// TagValue Filter for a Recovery Services Vault.
        /// </summary>
        [Parameter(ParameterSetName = ByTagObjectParameterSet, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public Hashtable Tag { get; set; }

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                if (string.IsNullOrEmpty(this.ResourceGroupName))
                {
                    this.GetVaultsUnderAllResourceGroups();
                }
                else
                {
                    if(string.IsNullOrEmpty(this.Name))
                    {
                        this.GetVaultsUnderResourceGroup(this.ResourceGroupName);
                    }
                    else
                    {
                        // ignore tag filters
                        Vault vault = RecoveryServicesClient.GetVault(this.ResourceGroupName, this.Name);
                        this.WriteObject(new ARSVault(vault));
                    }
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }

        /// <summary>
        /// Get vaults under a resouce group.
        /// </summary>
        private void GetVaultsUnderResourceGroup(string resourceGroupName)
        {
            List<Vault> vaultListResponse =
                RecoveryServicesClient.GetVaultsInResouceGroup(resourceGroupName);

            this.WriteVaults(vaultListResponse);
        }

        /// <summary>
        /// Get vaults under all resouce group.
        /// </summary>
        private void GetVaultsUnderAllResourceGroups()
        {
            
            foreach (var resourceGroup in RecoveryServicesClient.GetResouceGroups())
            {
                try
                {
                    GetVaultsUnderResourceGroup(resourceGroup.Name);
                }
                catch (Exception ex)
                {
                    WriteDebug("GetVaultsUnderResourceGroup failed: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Write Vaults.
        /// </summary>
        /// <param name="vaults">List of Vaults</param>
        private void WriteVaults(IList<Vault> vaults)
        {
            IList<Vault> filteredVaults = new List<Vault>();
            // Do a tag filter here
            for(int i = 0; i < vaults.Count; i++)
            {
                Vault vault = vaults[i];
                if(this.ParameterSetName == ByTagNameValueParameterSet)
                {
                    bool tagNameFilter = TagName == null || vault.Tags.ContainsKey(TagName);
                    bool tagValueFilter = TagValue == null || vault.Tags.Values.Contains(TagValue);

                    if((tagNameFilter && tagValueFilter))
                    {
                        filteredVaults.Add(vault);
                    }
                }
                if(this.ParameterSetName == ByTagObjectParameterSet)
                {
                    if (Tag != null)
                    {
                        foreach (string key in Tag.Keys)
                        {
                            if (vault.Tags.ContainsKey(key) && vault.Tags[key] == (string)Tag[key])
                            {
                                filteredVaults.Add(vault);
                                continue;
                            }
                        }
                    }
                }
            }
            if (string.IsNullOrEmpty(this.Name))
            {
                this.WriteObject(filteredVaults.Select(v => new ARSVault(v)), true);
            }
            else
            {
                foreach (Vault vault in filteredVaults)
                {
                    if (0 == string.Compare(this.Name, vault.Name, true))
                    {
                        this.WriteObject(new ARSVault(vault));
                    }
                }
            }
        }
    }
}
