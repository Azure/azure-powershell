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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.KeyVault.Helpers;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.KeyVault
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "KeyVault", DefaultParameterSetName = GetVaultParameterSet)]
    [OutputType(typeof(PSKeyVault), typeof(PSKeyVaultIdentityItem), typeof(PSDeletedKeyVault))]
    public class GetAzureKeyVault : KeyVaultManagementCmdletBase
    {
        #region Parameter Set Names

        private const string GetVaultParameterSet = "GetVaultByName";
        private const string GetDeletedVaultParameterSet = "ByDeletedVault";
        private const string ListDeletedVaultsParameterSet = "ListAllDeletedVaultsInSubscription";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// Vault name
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = GetVaultParameterSet,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [Parameter(Mandatory = true,
            ParameterSetName = GetDeletedVaultParameterSet,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [ResourceNameCompleter("Microsoft.KeyVault/vaults", "ResourceGroupName")]
        [Alias(Constants.Name)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string VaultName { get; set; }

        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(Mandatory = false,
            Position = 1,
            ParameterSetName = GetVaultParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the name of the resource group associated with the key vault being queried.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            Position = 1,
            ParameterSetName = GetDeletedVaultParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The location of the deleted vault.")]
        [LocationCompleter("Microsoft.KeyVault/vaults")]
        [ValidateNotNullOrEmpty()]
        public string Location { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = GetDeletedVaultParameterSet,
            HelpMessage = "Specifies whether to show the previously deleted vaults in the output.")]
        [Parameter(Mandatory = true,
            ParameterSetName = ListDeletedVaultsParameterSet,
            HelpMessage = "Specifies whether to show the previously deleted vaults in the output.")]
        public SwitchParameter InRemovedState { get; set; }

        /// <summary>
        /// Tag value
        /// </summary>
        [Parameter(
            Mandatory = false,
            ParameterSetName = GetVaultParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the key and optional value of the specified tag to filter the list of key vaults by.")]
        public Hashtable Tag { get; set; }

        #endregion
        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case GetVaultParameterSet:
                    List<PSKeyVaultIdentityItem> vaults = null;
                    
                    if (string.IsNullOrWhiteSpace(ResourceGroupName))
                    {
                        vaults = ListVaults(ResourceGroupName, Tag);
                        ResourceGroupName = vaults?.FirstOrDefault(r => r.VaultName.Equals(VaultName, StringComparison.OrdinalIgnoreCase))?.ResourceGroupName;
                    }

                    if (ShouldGetByName(ResourceGroupName, VaultName))
                    {
                        PSKeyVault vault = KeyVaultManagementClient.GetVault(
                                                    VaultName,
                                                    ResourceGroupName,
                                                    GraphClient);
                        WriteObject(FilterByTag(vault, Tag));
                    }
                    else
                    {
                        WriteObject(TopLevelWildcardFilter(ResourceGroupName, VaultName, vaults ?? ListVaults(ResourceGroupName, Tag)), true);
                    }

                    break;

                case GetDeletedVaultParameterSet:
                    WriteObject(KeyVaultManagementClient.GetDeletedVault(VaultName, Location));
                    break;

                case ListDeletedVaultsParameterSet:
                    WriteObject(KeyVaultManagementClient.ListDeletedVaults(), true);
                    break;

                default:
                    throw new ArgumentException(Resources.BadParameterSetName);
            }
        }
    }
}
