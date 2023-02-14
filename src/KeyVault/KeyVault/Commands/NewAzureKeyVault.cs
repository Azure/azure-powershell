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

using Microsoft.Azure.Commands.KeyVault.Helpers;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.KeyVault.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault
{
    /// <summary>
    /// Create a new key vault.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "KeyVault", SupportsShouldProcess = true)]
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
            HelpMessage = "Specifies the Azure region in which to create the key vault. Use the command Get-AzResourceProvider with the ProviderNamespace parameter to see your choices.")]
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
            HelpMessage = "If specified, protection against immediate deletion is enabled for this vault; requires soft delete to be enabled as well. Enabling 'purge protection' on a key vault is an irreversible action. Once enabled, it cannot be changed or removed.")]
        public SwitchParameter EnablePurgeProtection { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "If specified, enables to authorize data actions by Role Based Access Control (RBAC), and then the access policies specified in vault properties will be ignored. Note that management actions are always authorized with RBAC.")]
        public SwitchParameter EnableRbacAuthorization { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Specifies how long deleted resources are retained, and how long until a vault or an object in the deleted state can be purged. The default is " + Constants.DefaultSoftDeleteRetentionDaysString + " days.")]
        [ValidateRange(Constants.MinSoftDeleteRetentionDays, Constants.MaxSoftDeleteRetentionDays)]
        [ValidateNotNullOrEmpty]
        public int SoftDeleteRetentionInDays { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Specifies whether the vault will accept traffic from public internet. If set to 'disabled' all traffic except private endpoint traffic and that originates from trusted services will be blocked. This will override the set firewall rules, meaning that even if the firewall rules are present we will not honor the rules. By default, we will enable public network access.")]
        [PSArgumentCompleter("Enabled", "Disabled")]
        public string PublicNetworkAccess { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the SKU of the key vault instance. For information about which features are available for each SKU, see the Azure Key Vault Pricing website (http://go.microsoft.com/fwlink/?linkid=512521).")]
        [PSArgumentCompleter("Standard", "Premium")]
        public string Sku { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hash table which represents resource tags.")]
        [Alias(Constants.TagsAlias)]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Specifies the network rule set of the vault. It governs the accessibility of the key vault from specific network locations. Created by `New-AzKeyVaultNetworkRuleSetObject`.")]
        public PSKeyVaultNetworkRuleSet NetworkRuleSet { get; set; }

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

                var newVault = KeyVaultManagementClient.CreateNewVault(new VaultCreationOrUpdateParameters()
                {
                    Name = this.Name,
                    ResourceGroupName = this.ResourceGroupName,
                    Location = this.Location,
                    EnabledForDeployment = this.EnabledForDeployment.IsPresent ? true : null as bool?,
                    EnabledForTemplateDeployment = EnabledForTemplateDeployment.IsPresent ? true : null as bool?,
                    EnabledForDiskEncryption = EnabledForDiskEncryption.IsPresent ? true : null as bool?,
                    EnableSoftDelete = null,
                    EnablePurgeProtection = EnablePurgeProtection.IsPresent ? true : (bool?)null, // false is not accepted
                    EnableRbacAuthorization = EnableRbacAuthorization.IsPresent ? true : null as bool?,
                    /*
                     * If retention days is not specified, use the default value,
                     * else use the vault user provides
                     */
                    SoftDeleteRetentionInDays = this.IsParameterBound(c => c.SoftDeleteRetentionInDays)
                            ? SoftDeleteRetentionInDays
                            : Constants.DefaultSoftDeleteRetentionDays,
                    SkuFamilyName = DefaultSkuFamily,
                    SkuName = this.Sku,
                    TenantId = GetTenantId(),
                    AccessPolicy = accessPolicy,
                    // New key-vault takes in default network rule set
                    NetworkAcls = new NetworkRuleSet(),
                    PublicNetworkAccess = this.PublicNetworkAccess,
                    Tags = this.Tag
                },
                    GraphClient,
                    NetworkRuleSet);

                this.WriteObject(newVault);

                if (accessPolicy == null)
                {
                    WriteWarning(Resources.VaultNoAccessPolicyWarning);
                }
            }
        }
    }
}
