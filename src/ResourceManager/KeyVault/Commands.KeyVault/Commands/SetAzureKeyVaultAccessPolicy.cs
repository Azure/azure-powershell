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
using System.Linq;
using System.Management.Automation;
using PSKeyVaultModels = Microsoft.Azure.Commands.KeyVault.Models;
using PSKeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;

namespace Microsoft.Azure.Commands.KeyVault
{
    [Cmdlet(VerbsCommon.Set, "AzureRmKeyVaultAccessPolicy",
        SupportsShouldProcess = true,
        HelpUri = Constants.KeyVaultHelpUri)]
    [OutputType(typeof(PSKeyVaultModels.PSVault))]
    public class SetAzureKeyVaultAccessPolicy : KeyVaultManagementCmdletBase
    {
        #region Parameter Set Names

        private const string ByObjectId = "ByObjectId";
        private const string ByServicePrincipalName = "ByServicePrincipalName";
        private const string ByUserPrincipalName = "ByUserPrincipalName";
        private const string ForVault = "ForVault";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// Vault name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the name of a key vault. This cmdlet modifies the access policy for the key vault that this parameter specifies.")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(Mandatory = false,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the name of the resource group associated with the key vault whose access policy is being modified.")]
        [ValidateNotNullOrEmpty()]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Service principal name
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ByServicePrincipalName,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the service principal name of the application to which to grant permissions. Specify the application ID, also known as client ID, registered for the application in Azure Active Directory. The application with the service principal name that this parameter specifies must be registered in the Azure directory that contains your current subscription.")]
        [ValidateNotNullOrEmpty()]
        [Alias("SPN")]
        public string ServicePrincipalName { get; set; }

        /// <summary>
        /// User principal name
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ByUserPrincipalName,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the user principal name of the user to whom to grant permissions. This user principal name must exist in the directory associated with the current subscription.")]
        [ValidateNotNullOrEmpty()]
        [Alias("UPN")]
        public string UserPrincipalName { get; set; }

        /// <summary>
        /// User principal name
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ByObjectId,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the object ID of the user or service principal in Azure Active Directory for which to grant permissions.")]
        [ValidateNotNullOrEmpty()]
        public Guid ObjectId { get; set; }

        /// <summary>
        /// Id of the application to which a user delegate to
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = ByObjectId,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the ID of application that a user must use to grant permissions.")]
        public Guid? ApplicationId { get; set; }

        /// <summary>
        /// Permissions to Keys
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = ByObjectId,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies key operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ByServicePrincipalName,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies key operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ByUserPrincipalName,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies key operation permissions to grant to a user or service principal.")]
        [ValidateSet("decrypt", "encrypt", "unwrapKey", "wrapKey", "verify", "sign", "get", "list", "update", "create", "import", "delete", "backup", "restore", "all")]
        public string[] PermissionsToKeys { get; set; }

        /// <summary>
        /// Permissions to Secrets
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = ByObjectId,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies secret operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ByServicePrincipalName,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies secret operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ByUserPrincipalName,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies secret operation permissions to grant to a user or service principal.")]
        [ValidateSet("get", "list", "set", "delete", "all")]
        public string[] PermissionsToSecrets { get; set; }

        /// <summary>
        /// Permissions to Certificates
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = ByObjectId,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies certificate operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ByServicePrincipalName,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies certificate operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ByUserPrincipalName,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies certificate operation permissions to grant to a user or service principal.")]
        [ValidateSet("get", "list", "delete", "create", "import", "update", "managecontacts", "getissuers", "listissuers", "setissuers", "deleteissuers", "all")]
        public string[] PermissionsToCertificates { get; set; }

        [Parameter(Mandatory = false,
            ParameterSetName = ForVault,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "If specified, enables secrets to be retrieved from this key vault by the Microsoft.Compute resource provider when referenced in resource creation.")]
        public SwitchParameter EnabledForDeployment { get; set; }

        [Parameter(Mandatory = false,
            ParameterSetName = ForVault,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "If specified, enables secrets to be retrieved from this key vault by Azure Resource Manager when referenced in templates.")]
        public SwitchParameter EnabledForTemplateDeployment { get; set; }

        [Parameter(Mandatory = false,
            ParameterSetName = ForVault,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "If specified, enables secrets to be retrieved from this key vault by Azure Disk Encryption.")]
        public SwitchParameter EnabledForDiskEncryption { get; set; }

        /// <summary>
        /// Flag for bypassing object ID validation or not
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = ByObjectId,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies whether the object ID needs to be validated or not.")]
        public SwitchParameter BypassObjectIdValidation { get; set; }

        [Parameter(Mandatory = false,
           HelpMessage = "This Cmdlet does not return an object by default. If this switch is specified, it returns the updated key vault object.")]
        public SwitchParameter PassThru { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(VaultName, Properties.Resources.SetVaultAccessPolicy))
            {
                if (ParameterSetName == ForVault && !EnabledForDeployment.IsPresent &&
                !EnabledForTemplateDeployment.IsPresent && !EnabledForDiskEncryption.IsPresent)
                {
                    throw new ArgumentException(PSKeyVaultProperties.Resources.VaultPermissionFlagMissing);
                }

                ResourceGroupName = string.IsNullOrWhiteSpace(ResourceGroupName) ? GetResourceGroupName(VaultName) : ResourceGroupName;
                PSKeyVaultModels.PSVault vault = null;

                // Get the vault to be updated
                if (!string.IsNullOrWhiteSpace(ResourceGroupName))
                    vault = KeyVaultManagementClient.GetVault(
                                                       VaultName,
                                                       ResourceGroupName);
                if (vault == null)
                {
                    throw new ArgumentException(string.Format(PSKeyVaultProperties.Resources.VaultNotFound, VaultName, ResourceGroupName));
                }

                // Update vault policies
                PSKeyVaultModels.PSVaultAccessPolicy[] updatedListOfAccessPolicies = vault.AccessPolicies;
                if (!string.IsNullOrEmpty(UserPrincipalName) || !string.IsNullOrEmpty(ServicePrincipalName) || (ObjectId != Guid.Empty))
                {
                    Guid objId = this.ObjectId;
                    if (!this.BypassObjectIdValidation.IsPresent)
                    {
                        objId = GetObjectId(this.ObjectId, this.UserPrincipalName, this.ServicePrincipalName);
                    }

                    if (ApplicationId.HasValue && ApplicationId.Value == Guid.Empty)
                        throw new ArgumentException(PSKeyVaultProperties.Resources.InvalidApplicationId);

                    //All permission arrays cannot be null
                    if (PermissionsToKeys == null && PermissionsToSecrets == null && PermissionsToCertificates == null)
                        throw new ArgumentException(PSKeyVaultProperties.Resources.PermissionsNotSpecified);
                    else
                    {
                        //Validate 
                        if (!IsMeaningfulPermissionSet(PermissionsToKeys))
                            throw new ArgumentException(string.Format(PSKeyVaultProperties.Resources.PermissionSetIncludesAllPlusOthers, "keys"));
                        if (!IsMeaningfulPermissionSet(PermissionsToSecrets))
                            throw new ArgumentException(string.Format(PSKeyVaultProperties.Resources.PermissionSetIncludesAllPlusOthers, "secrets"));
                        if (!IsMeaningfulPermissionSet(PermissionsToCertificates))
                            throw new ArgumentException(string.Format(PSKeyVaultProperties.Resources.PermissionSetIncludesAllPlusOthers, "certificates"));

                        //Is there an existing policy for this policy identity?
                        var existingPolicy = vault.AccessPolicies.FirstOrDefault(ap => MatchVaultAccessPolicyIdentity(ap, objId, ApplicationId));

                        //New policy will have permission arrays that are either from cmdlet input 
                        //or if that's null, then from the old policy for this object ID if one existed
                        var keys = PermissionsToKeys ?? (existingPolicy != null && existingPolicy.PermissionsToKeys != null ?
                            existingPolicy.PermissionsToKeys.ToArray() : null);

                        var secrets = PermissionsToSecrets ?? (existingPolicy != null && existingPolicy.PermissionsToSecrets != null ?
                            existingPolicy.PermissionsToSecrets.ToArray() : null);

                        var certificates = PermissionsToCertificates ?? (existingPolicy != null && existingPolicy.PermissionsToCertificates != null ?
                            existingPolicy.PermissionsToCertificates.ToArray() : null);

                        //Remove old policies for this policy identity and add a new one with the right permissions, iff there were some non-empty permissions
                        updatedListOfAccessPolicies = vault.AccessPolicies.Where(ap => !MatchVaultAccessPolicyIdentity(ap, objId, this.ApplicationId)).ToArray();
                        if ((keys != null && keys.Length > 0) || (secrets != null && secrets.Length > 0) || (certificates != null && certificates.Length > 0))
                        {
                            var policy = new PSKeyVaultModels.PSVaultAccessPolicy(vault.TenantId, objId, this.ApplicationId, keys, secrets, certificates);
                            updatedListOfAccessPolicies = updatedListOfAccessPolicies.Concat(new[] { policy }).ToArray();
                        }

                    }
                }

                // Update the vault
                var updatedVault = KeyVaultManagementClient.UpdateVault(vault, updatedListOfAccessPolicies,
                    EnabledForDeployment.IsPresent ? true : vault.EnabledForDeployment,
                    EnabledForTemplateDeployment.IsPresent ? true : vault.EnabledForTemplateDeployment,
                    EnabledForDiskEncryption.IsPresent ? true : vault.EnabledForDiskEncryption,
                    ActiveDirectoryClient);

                if (PassThru.IsPresent)
                    WriteObject(updatedVault);
            }
        }

        private bool MatchVaultAccessPolicyIdentity(PSKeyVaultModels.PSVaultAccessPolicy ap, Guid objectId, Guid? applicationId)
        {
            return ap.ApplicationId == applicationId && ap.ObjectId == objectId;
        }

        private bool IsMeaningfulPermissionSet(string[] perms)
        {
            if (perms == null || perms.Length == 0)
                return true;

            var nonEmptyPerms = perms.Where(p => !string.IsNullOrWhiteSpace(p));
            if (nonEmptyPerms.Contains("all") && nonEmptyPerms.Count() > 1)
                return false;

            return true;
        }
    }
}
