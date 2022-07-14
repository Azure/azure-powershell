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
using Microsoft.Azure.Commands.KeyVault.Helpers;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.KeyVault
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "KeyVaultAccessPolicy", SupportsShouldProcess = true, DefaultParameterSetName = ByUserPrincipalName)]
    [OutputType(typeof(PSKeyVault))]
    public class SetAzureKeyVaultAccessPolicy : KeyVaultManagementCmdletBase
    {
        #region Parameter Set Names

        private const string ByObjectId = "ByObjectId";
        private const string ByServicePrincipalName = "ByServicePrincipalName";
        private const string ByUserPrincipalName = "ByUserPrincipalName";
        private const string ByEmailAddress = "ByEmailAddress";
        private const string ForVault = "ForVault";

        private const string InputObjectByObjectId = "InputObjectByObjectId";
        private const string InputObjectByServicePrincipalName = "InputObjectByServicePrincipalName";
        private const string InputObjectByUserPrincipalName = "InputObjectByUserPrincipalName";
        private const string InputObjectByEmailAddress = "InputObjectByEmailAddress";
        private const string InputObjectForVault = "InputObjectForVault";

        private const string ResourceIdByObjectId = "ResourceIdByObjectId";
        private const string ResourceIdByServicePrincipalName = "ResourceIdByServicePrincipalName";
        private const string ResourceIdByUserPrincipalName = "ResourceIdByUserPrincipalName";
        private const string ResourceIdByEmailAddress = "ResourceIdByEmailAddress";
        private const string ResourceIdForVault = "ResourceIdForVault";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// Vault name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ByObjectId,
            HelpMessage = "Specifies the name of a key vault. This cmdlet modifies the access policy for the key vault that this parameter specifies.")]
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ByServicePrincipalName,
            HelpMessage = "Specifies the name of a key vault. This cmdlet modifies the access policy for the key vault that this parameter specifies.")]
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ByUserPrincipalName,
            HelpMessage = "Specifies the name of a key vault. This cmdlet modifies the access policy for the key vault that this parameter specifies.")]
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ByEmailAddress,
            HelpMessage = "Specifies the name of a key vault. This cmdlet modifies the access policy for the key vault that this parameter specifies.")]
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ForVault,
            HelpMessage = "Specifies the name of a key vault. This cmdlet modifies the access policy for the key vault that this parameter specifies.")]
        [ResourceNameCompleter("Microsoft.KeyVault/vaults", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(Mandatory = false,
            Position = 1,
            ParameterSetName = ByObjectId,
            HelpMessage = "Specifies the name of the resource group associated with the key vault whose access policy is being modified.")]
        [Parameter(Mandatory = false,
            Position = 1,
            ParameterSetName = ByServicePrincipalName,
            HelpMessage = "Specifies the name of the resource group associated with the key vault whose access policy is being modified.")]
        [Parameter(Mandatory = false,
            Position = 1,
            ParameterSetName = ByUserPrincipalName,
            HelpMessage = "Specifies the name of the resource group associated with the key vault whose access policy is being modified.")]
        [Parameter(Mandatory = false,
            Position = 1,
            ParameterSetName = ByEmailAddress,
            HelpMessage = "Specifies the name of the resource group associated with the key vault whose access policy is being modified.")]
        [Parameter(Mandatory = false,
            Position = 1,
            ParameterSetName = ForVault,
            HelpMessage = "Specifies the name of the resource group associated with the key vault whose access policy is being modified.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Vault object
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ParameterSetName = InputObjectByObjectId,
            HelpMessage = "Key Vault Object")]
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ParameterSetName = InputObjectByServicePrincipalName,
            HelpMessage = "Key Vault Object")]
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ParameterSetName = InputObjectByUserPrincipalName,
            HelpMessage = "Key Vault Object")]
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ParameterSetName = InputObjectByEmailAddress,
            HelpMessage = "Key Vault Object")]
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ParameterSetName = InputObjectForVault,
            HelpMessage = "Key Vault Object")]
        [ValidateNotNullOrEmpty]
        public PSKeyVaultIdentityItem InputObject { get; set; }

        /// <summary>
        /// Vault ResourceId
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ResourceIdByObjectId,
            HelpMessage = "Key Vault Resource Id")]
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ResourceIdByServicePrincipalName,
            HelpMessage = "Key Vault Resource Id")]
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ResourceIdByUserPrincipalName,
            HelpMessage = "Key Vault Resource Id")]
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ResourceIdByEmailAddress,
            HelpMessage = "Key Vault Resource Id")]
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ResourceIdForVault,
            HelpMessage = "Key Vault Resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Service principal name
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ByServicePrincipalName,
            HelpMessage = "Specifies the service principal name of the application to which to grant permissions. Specify the application ID, also known as client ID, registered for the application in Azure Active Directory. The application with the service principal name that this parameter specifies must be registered in the Azure directory that contains your current subscription.")]
        [Parameter(Mandatory = true,
            ParameterSetName = InputObjectByServicePrincipalName,
            HelpMessage = "Specifies the service principal name of the application to which to grant permissions. Specify the application ID, also known as client ID, registered for the application in Azure Active Directory. The application with the service principal name that this parameter specifies must be registered in the Azure directory that contains your current subscription.")]
        [Parameter(Mandatory = true,
            ParameterSetName = ResourceIdByServicePrincipalName,
            HelpMessage = "Specifies the service principal name of the application to which to grant permissions. Specify the application ID, also known as client ID, registered for the application in Azure Active Directory. The application with the service principal name that this parameter specifies must be registered in the Azure directory that contains your current subscription.")]
        [ValidateNotNullOrEmpty()]
        [Alias("SPN")]
        public string ServicePrincipalName { get; set; }

        /// <summary>
        /// User principal name
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ByUserPrincipalName,
            HelpMessage = "Specifies the user principal name of the user to whom to grant permissions. This user principal name must exist in the directory associated with the current subscription.")]
        [Parameter(Mandatory = true,
            ParameterSetName = InputObjectByUserPrincipalName,
            HelpMessage = "Specifies the user principal name of the user to whom to grant permissions. This user principal name must exist in the directory associated with the current subscription.")]
        [Parameter(Mandatory = true,
            ParameterSetName = ResourceIdByUserPrincipalName,
            HelpMessage = "Specifies the user principal name of the user to whom to grant permissions. This user principal name must exist in the directory associated with the current subscription.")]
        [ValidateNotNullOrEmpty()]
        [Alias("UPN")]
        public string UserPrincipalName { get; set; }

        /// <summary>
        /// User principal name
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ByObjectId,
            HelpMessage = "Specifies the object ID of the user or service principal in Azure Active Directory for which to grant permissions.")]
        [Parameter(Mandatory = true,
            ParameterSetName = InputObjectByObjectId,
            HelpMessage = "Specifies the object ID of the user or service principal in Azure Active Directory for which to grant permissions.")]
        [Parameter(Mandatory = true,
            ParameterSetName = ResourceIdByObjectId,
            HelpMessage = "Specifies the object ID of the user or service principal in Azure Active Directory for which to grant permissions.")]
        [ValidateNotNullOrEmpty()]
        public string ObjectId { get; set; }

        /// <summary>
        /// Email address
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ByEmailAddress,
            HelpMessage = "Specifies the email address of the user in Azure Active Directory for which to grant permissions.")]
        [Parameter(Mandatory = true,
            ParameterSetName = InputObjectByEmailAddress,
            HelpMessage = "Specifies the email address of the user in Azure Active Directory for which to grant permissions.")]
        [Parameter(Mandatory = true,
            ParameterSetName = ResourceIdByEmailAddress,
            HelpMessage = "Specifies the email address of the user in Azure Active Directory for which to grant permissions.")]
        [ValidateNotNullOrEmpty()]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Id of the application to which a user delegate to
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = ByObjectId,
            HelpMessage = "Specifies the ID of application that a user must use to grant permissions.")]
        [Parameter(Mandatory = false,
            ParameterSetName = InputObjectByObjectId,
            HelpMessage = "Specifies the ID of application that a user must use to grant permissions.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdByObjectId,
            HelpMessage = "Specifies the ID of application that a user must use to grant permissions.")]
        public Guid? ApplicationId { get; set; }

        /// <summary>
        /// Permissions to Keys
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = ByObjectId,
            HelpMessage = "Specifies key operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ByServicePrincipalName,
            HelpMessage = "Specifies key operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ByUserPrincipalName,
            HelpMessage = "Specifies key operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ByEmailAddress,
            HelpMessage = "Specifies key operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = InputObjectByObjectId,
            HelpMessage = "Specifies key operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = InputObjectByServicePrincipalName,
            HelpMessage = "Specifies key operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = InputObjectByUserPrincipalName,
            HelpMessage = "Specifies key operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = InputObjectByEmailAddress,
            HelpMessage = "Specifies key operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdByObjectId,
            HelpMessage = "Specifies key operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdByServicePrincipalName,
            HelpMessage = "Specifies key operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdByUserPrincipalName,
            HelpMessage = "Specifies key operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdByEmailAddress,
            HelpMessage = "Specifies key operation permissions to grant to a user or service principal.")]
        [PSArgumentCompleter("all", "decrypt", "encrypt", "unwrapKey", "wrapKey", "verify", "sign", "get", "list", "update", "create", "import", "delete", "backup", "restore", "recover", "purge", "rotate")]
        public string[] PermissionsToKeys { get; set; }

        /// <summary>
        /// Permissions to Secrets
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = ByObjectId,
            HelpMessage = "Specifies secret operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ByServicePrincipalName,
            HelpMessage = "Specifies secret operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ByUserPrincipalName,
            HelpMessage = "Specifies secret operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ByEmailAddress,
            HelpMessage = "Specifies secret operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = InputObjectByObjectId,
            HelpMessage = "Specifies secret operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = InputObjectByServicePrincipalName,
            HelpMessage = "Specifies secret operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = InputObjectByUserPrincipalName,
            HelpMessage = "Specifies secret operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = InputObjectByEmailAddress,
            HelpMessage = "Specifies secret operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdByObjectId,
            HelpMessage = "Specifies secret operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdByServicePrincipalName,
            HelpMessage = "Specifies secret operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdByUserPrincipalName,
            HelpMessage = "Specifies secret operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdByEmailAddress,
            HelpMessage = "Specifies secret operation permissions to grant to a user or service principal.")]
        [PSArgumentCompleter("all", "get", "list", "set", "delete", "backup", "restore", "recover", "purge")]
        public string[] PermissionsToSecrets { get; set; }

        /// <summary>
        /// Permissions to Certificates
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = ByObjectId,
            HelpMessage = "Specifies certificate operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ByServicePrincipalName,
            HelpMessage = "Specifies certificate operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ByUserPrincipalName,
            HelpMessage = "Specifies certificate operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ByEmailAddress,
            HelpMessage = "Specifies certificate operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = InputObjectByObjectId,
            HelpMessage = "Specifies certificate operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = InputObjectByServicePrincipalName,
            HelpMessage = "Specifies certificate operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = InputObjectByUserPrincipalName,
            HelpMessage = "Specifies certificate operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = InputObjectByEmailAddress,
            HelpMessage = "Specifies certificate operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdByObjectId,
            HelpMessage = "Specifies certificate operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdByServicePrincipalName,
            HelpMessage = "Specifies certificate operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdByUserPrincipalName,
            HelpMessage = "Specifies certificate operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdByEmailAddress,
            HelpMessage = "Specifies certificate operation permissions to grant to a user or service principal.")]
        [PSArgumentCompleter("all", "get", "list", "delete", "create", "import", "update", "managecontacts", "getissuers", "listissuers", "setissuers", "deleteissuers", "manageissuers", "recover", "purge", "backup", "restore")]
        public string[] PermissionsToCertificates { get; set; }

        /// <summary>
        /// Permissions to Storage
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = ByObjectId,
            HelpMessage = "Specifies managed storage account and sas definition operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ByServicePrincipalName,
            HelpMessage = "Specifies managed storage account and sas definition operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ByUserPrincipalName,
            HelpMessage = "Specifies managed storage account and sas definition operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ByEmailAddress,
            HelpMessage = "Specifies managed storage account and sas definition  operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = InputObjectByObjectId,
            HelpMessage = "Specifies managed storage account and sas definition operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = InputObjectByServicePrincipalName,
            HelpMessage = "Specifies managed storage account and sas definition operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = InputObjectByUserPrincipalName,
            HelpMessage = "Specifies managed storage account and sas definition operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = InputObjectByEmailAddress,
            HelpMessage = "Specifies managed storage account and sas definition  operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdByObjectId,
            HelpMessage = "Specifies managed storage account and sas definition operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdByServicePrincipalName,
            HelpMessage = "Specifies managed storage account and sas definition operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdByUserPrincipalName,
            HelpMessage = "Specifies managed storage account and sas definition operation permissions to grant to a user or service principal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdByEmailAddress,
            HelpMessage = "Specifies managed storage account and sas definition  operation permissions to grant to a user or service principal.")]
        [PSArgumentCompleter("all", "get", "list", "delete", "set", "update", "regeneratekey", "getsas", "listsas", "deletesas", "setsas", "recover", "backup", "restore", "purge")]
        public string[] PermissionsToStorage { get; set; }

        [Parameter(Mandatory = false,
            ParameterSetName = ForVault,
            HelpMessage = "If specified, enables secrets to be retrieved from this key vault by the Microsoft.Compute resource provider when referenced in resource creation.")]
        [Parameter(Mandatory = false,
            ParameterSetName = InputObjectForVault,
            HelpMessage = "If specified, enables secrets to be retrieved from this key vault by the Microsoft.Compute resource provider when referenced in resource creation.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdForVault,
            HelpMessage = "If specified, enables secrets to be retrieved from this key vault by the Microsoft.Compute resource provider when referenced in resource creation.")]
        public SwitchParameter EnabledForDeployment { get; set; }

        [Parameter(Mandatory = false,
            ParameterSetName = ForVault,
            HelpMessage = "If specified, enables secrets to be retrieved from this key vault by Azure Resource Manager when referenced in templates.")]
        [Parameter(Mandatory = false,
            ParameterSetName = InputObjectForVault,
            HelpMessage = "If specified, enables secrets to be retrieved from this key vault by Azure Resource Manager when referenced in templates.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdForVault,
            HelpMessage = "If specified, enables secrets to be retrieved from this key vault by Azure Resource Manager when referenced in templates.")]
        public SwitchParameter EnabledForTemplateDeployment { get; set; }

        [Parameter(Mandatory = false,
            ParameterSetName = ForVault,
            HelpMessage = "If specified, enables secrets to be retrieved from this key vault by Azure Disk Encryption.")]
        [Parameter(Mandatory = false,
            ParameterSetName = InputObjectForVault,
            HelpMessage = "If specified, enables secrets to be retrieved from this key vault by Azure Disk Encryption.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdForVault,
            HelpMessage = "If specified, enables secrets to be retrieved from this key vault by Azure Disk Encryption.")]
        public SwitchParameter EnabledForDiskEncryption { get; set; }

        /// <summary>
        /// Flag for bypassing object ID validation or not
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = ByObjectId,
            HelpMessage = "Specifies whether the object ID needs to be validated or not.")]
        [Parameter(Mandatory = false,
            ParameterSetName = InputObjectByObjectId,
            HelpMessage = "Specifies whether the object ID needs to be validated or not.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdByObjectId,
            HelpMessage = "Specifies whether the object ID needs to be validated or not.")]
        public SwitchParameter BypassObjectIdValidation { get; set; }

        [Parameter(Mandatory = false,
           HelpMessage = "This Cmdlet does not return an object by default. If this switch is specified, it returns the updated key vault object.")]
        public SwitchParameter PassThru { get; set; }

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

            if (ShouldProcess(VaultName, Properties.Resources.SetVaultAccessPolicy))
            {
                if (ParameterSetName == ForVault && !EnabledForDeployment.IsPresent &&
                !EnabledForTemplateDeployment.IsPresent && !EnabledForDiskEncryption.IsPresent)
                {
                    throw new ArgumentException(Resources.VaultPermissionFlagMissing);
                }

                ResourceGroupName = string.IsNullOrWhiteSpace(ResourceGroupName) ? GetResourceGroupName(VaultName) : ResourceGroupName;
                if (ResourceGroupName == null)
                {
                    throw new ArgumentException(string.Format(Resources.VaultDoesNotExist, VaultName));
                }

                PSKeyVault vault = null;

                // Get the vault to be updated
                if (!string.IsNullOrWhiteSpace(ResourceGroupName))
                    vault = KeyVaultManagementClient.GetVault(
                                                       VaultName,
                                                       ResourceGroupName);
                if (vault == null)
                {
                    throw new ArgumentException(string.Format(Resources.VaultNotFound, VaultName, ResourceGroupName));
                }

                if (!string.IsNullOrWhiteSpace(this.ObjectId) && !this.IsValidObjectIdSyntax(this.ObjectId))
                {
                    throw new ArgumentException(Resources.InvalidObjectIdSyntax);
                }

                // Update vault policies
                PSKeyVaultAccessPolicy[] updatedListOfAccessPolicies = vault.AccessPolicies;
                if (!string.IsNullOrEmpty(UserPrincipalName)
                    || !string.IsNullOrEmpty(ServicePrincipalName)
                    || !string.IsNullOrWhiteSpace(this.ObjectId)
                    || !string.IsNullOrWhiteSpace(this.EmailAddress))
                {
                    var objId = this.ObjectId;
                    if (!this.BypassObjectIdValidation.IsPresent && GraphClient != null)
                    {
                        objId = GetObjectId(this.ObjectId, this.UserPrincipalName, this.EmailAddress, this.ServicePrincipalName);
                    }
                    else if (GraphClient == null && objId == null)
                    {
                        throw new Exception(Resources.ActiveDirectoryClientNull);
                    }

                    if (ApplicationId.HasValue && ApplicationId.Value == Guid.Empty)
                        throw new ArgumentException(Resources.InvalidApplicationId);

                    //All permission arrays cannot be null
                    if (PermissionsToKeys == null && PermissionsToSecrets == null && PermissionsToCertificates == null && PermissionsToStorage == null)
                        throw new ArgumentException(Resources.PermissionsNotSpecified);
                    else
                    {
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

                        var managedStorage = PermissionsToStorage ?? (existingPolicy != null && existingPolicy.PermissionsToStorage != null ?
                            existingPolicy.PermissionsToStorage.ToArray() : null);

                        //Remove old policies for this policy identity and add a new one with the right permissions, iff there were some non-empty permissions
                        updatedListOfAccessPolicies = vault.AccessPolicies.Where(ap => !MatchVaultAccessPolicyIdentity(ap, objId, this.ApplicationId)).ToArray();
                        if ((keys != null && keys.Length > 0) || (secrets != null && secrets.Length > 0) || (certificates != null && certificates.Length > 0) || (managedStorage != null && managedStorage.Length > 0))
                        {
                            var policy = new PSKeyVaultAccessPolicy(vault.TenantId, objId, this.ApplicationId, keys, secrets, certificates, managedStorage);
                            updatedListOfAccessPolicies = updatedListOfAccessPolicies.Concat(new[] { policy }).ToArray();
                        }

                    }
                }

                // Update the vault
                var updatedVault = KeyVaultManagementClient.UpdateVault(
                    vault,
                    updatedListOfAccessPolicies,
                    EnabledForDeployment.IsPresent ? true : vault.EnabledForDeployment,
                    EnabledForTemplateDeployment.IsPresent ? true : vault.EnabledForTemplateDeployment,
                    EnabledForDiskEncryption.IsPresent ? true : vault.EnabledForDiskEncryption,
                    vault.EnableSoftDelete,
                    vault.EnablePurgeProtection,
                    vault.EnableRbacAuthorization,
                    vault.SoftDeleteRetentionInDays,
                    vault.NetworkAcls,
                    GraphClient);

                if (PassThru.IsPresent)
                    WriteObject(updatedVault);
            }
        }

        private bool MatchVaultAccessPolicyIdentity(PSKeyVaultAccessPolicy ap, string objectId, Guid? applicationId)
        {
            return ap.ApplicationId == applicationId && string.Equals(ap.ObjectId, objectId, StringComparison.OrdinalIgnoreCase);
        }
    }
}
