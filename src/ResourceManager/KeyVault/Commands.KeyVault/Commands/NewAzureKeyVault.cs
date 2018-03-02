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

using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.KeyVault.Models;
using System;
using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault
{
    /// <summary>
    /// Create a new key vault.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmKeyVault",
        SupportsShouldProcess = true,
        HelpUri = Constants.KeyVaultHelpUri)]
    [OutputType(typeof(PSKeyVault))]
    public class NewAzureKeyVault : KeyVaultManagementCmdletBase
    {
        #region Input Parameter Definitions

        /// <summary>
        /// Vault name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "Specifies a name of the key vault to create. The name can be any combination of letters, digits, or hyphens. The name must start and end with a letter or digit. The name must be universally unique."
            )]
        [ValidateNotNullOrEmpty]
        [Alias("VaultName")]
        public string Name { get; set; }

        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the name of an existing resource group in which to create the key vault.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Location
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the Azure region in which to create the key vault. Use the command Get-AzureRmResourceProvider with the ProviderNamespace parameter to see your choices.")]
        [LocationCompleter("Microsoft.KeyVault/vaults")]
        [ValidateNotNullOrEmpty()]
        public string Location { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "If specified, enables secrets to be retrieved from this key vault by the Microsoft.Compute resource provider when referenced in resource creation.")]
        public SwitchParameter EnabledForDeployment { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "If specified, enables secrets to be retrieved from this key vault by Azure Resource Manager when referenced in templates.")]
        public SwitchParameter EnabledForTemplateDeployment { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "If specified, enables secrets to be retrieved from this key vault by Azure Disk Encryption.")]
        public SwitchParameter EnabledForDiskEncryption { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "If specified, 'soft delete' functionality is enabled for this key vault.")]
        public SwitchParameter EnableSoftDelete { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the SKU of the key vault instance. For information about which features are available for each SKU, see the Azure Key Vault Pricing website (http://go.microsoft.com/fwlink/?linkid=512521).")]
        public SkuName Sku { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hash table which represents resource tags.")]
        [Alias(Constants.TagsAlias)]
        public Hashtable Tag { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, Properties.Resources.CreateKeyVault))
            {
                if (VaultExistsInCurrentSubscription(Name))
                {
                    throw new ArgumentException(Resources.VaultAlreadyExists);
                }

                var userObjectId = string.Empty;
                AccessPolicyEntry accessPolicy = null;

                try
                {
                    userObjectId = GetCurrentUsersObjectId();
                }
                catch (Exception ex)
                {
                    // Show the graph exceptions as a warning, but still proceed to create a vault with no access policy
                    // This is to unblock Key Vault in Fairfax as Graph has issues in this environment.
                    WriteWarning(ex.Message);
                }

                if (!string.IsNullOrWhiteSpace(userObjectId))
                {
                    accessPolicy = new AccessPolicyEntry()
                    {
                        TenantId = GetTenantId(),
                        ObjectId = userObjectId,
                        Permissions = new Permissions
                        {
                            Keys = DefaultPermissionsToKeys,
                            Secrets = DefaultPermissionsToSecrets,
                            Certificates = DefaultPermissionsToCertificates,
                            Storage = DefaultPermissionsToStorage
                        }
                    };
                }

                var newVault = KeyVaultManagementClient.CreateNewVault(new VaultCreationParameters()
                {
                    VaultName = this.Name,
                    ResourceGroupName = this.ResourceGroupName,
                    Location = this.Location,
                    EnabledForDeployment = this.EnabledForDeployment.IsPresent,
                    EnabledForTemplateDeployment = EnabledForTemplateDeployment.IsPresent,
                    EnabledForDiskEncryption = EnabledForDiskEncryption.IsPresent,
                    EnableSoftDelete = EnableSoftDelete.IsPresent,
                    SkuFamilyName = DefaultSkuFamily,
                    SkuName = this.Sku,
                    TenantId = GetTenantId(),
                    AccessPolicy = accessPolicy,
                    Tags = this.Tag
                },
                ActiveDirectoryClient
                );

                this.WriteObject(newVault);

                if (accessPolicy == null)
                {
                    WriteWarning(Resources.VaultNoAccessPolicyWarning);
                }
            }
        }


    }
}
