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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "KeyVaultAccessPolicy", SupportsShouldProcess = true, DefaultParameterSetName = ByUserPrincipalName)]
    [OutputType(typeof(PSKeyVault))]
    public class RemoveAzureKeyVaultAccessPolicy : KeyVaultManagementCmdletBase
    {
        #region Parameter Set Names

        private const string ByObjectId = "ByObjectId";
        private const string ByServicePrincipalName = "ByServicePrincipalName";
        private const string ByUserPrincipalName = "ByUserPrincipalName";
        private const string ByEmail = "ByEmail";
        private const string ForVault = "ForVault";

        private const string InputObjectByObjectId = "InputObjectByObjectId";
        private const string InputObjectByServicePrincipalName = "InputObjectByServicePrincipalName";
        private const string InputObjectByUserPrincipalName = "InputObjectByUserPrincipalName";
        private const string InputObjectByEmail = "InputObjectByEmail";
        private const string InputObjectForVault = "InputObjectForVault";

        private const string ResourceIdByObjectId = "ResourceIdByObjectId";
        private const string ResourceIdByServicePrincipalName = "ResourceIdByServicePrincipalName";
        private const string ResourceIdByUserPrincipalName = "ResourceIdByUserPrincipalName";
        private const string ResourceIdByEmail = "ResourceIdByEmail";
        private const string ResourceIdForVault = "ResourceIdForVault";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// Vault name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ByObjectId,
            HelpMessage = "Specifies the name of the key vault. This cmdlet removes permissions for the key vault that this parameter specifies.")]
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ByServicePrincipalName,
            HelpMessage = "Specifies the name of the key vault. This cmdlet removes permissions for the key vault that this parameter specifies.")]
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ByUserPrincipalName,
            HelpMessage = "Specifies the name of the key vault. This cmdlet removes permissions for the key vault that this parameter specifies.")]
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ByEmail,
            HelpMessage = "Specifies the name of the key vault. This cmdlet removes permissions for the key vault that this parameter specifies.")]
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ForVault,
            HelpMessage = "Specifies the name of the key vault. This cmdlet removes permissions for the key vault that this parameter specifies.")]
        [ResourceNameCompleter("Microsoft.KeyVault/vaults", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(Mandatory = false,
            Position = 1,
            ParameterSetName = ByObjectId,
            HelpMessage = "Specifies the name of the resource group associated with the key vault whose permissions you want to remove.")]
        [Parameter(Mandatory = false,
            Position = 1,
            ParameterSetName = ByServicePrincipalName,
            HelpMessage = "Specifies the name of the resource group associated with the key vault whose permissions you want to remove.")]
        [Parameter(Mandatory = false,
            Position = 1,
            ParameterSetName = ByUserPrincipalName,
            HelpMessage = "Specifies the name of the resource group associated with the key vault whose permissions you want to remove.")]
        [Parameter(Mandatory = false,
            Position = 1,
            ParameterSetName = ByEmail,
            HelpMessage = "Specifies the name of the resource group associated with the key vault whose permissions you want to remove.")]
        [Parameter(Mandatory = false,
            Position = 1,
            ParameterSetName = ForVault,
            HelpMessage = "Specifies the name of the resource group associated with the key vault whose permissions you want to remove.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Vault object
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = InputObjectByObjectId,
            ValueFromPipeline = true,
            HelpMessage = "Key Vault object.")]
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = InputObjectByServicePrincipalName,
            ValueFromPipeline = true,
            HelpMessage = "Key Vault object.")]
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = InputObjectByUserPrincipalName,
            ValueFromPipeline = true,
            HelpMessage = "Key Vault object.")]
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = InputObjectByEmail,
            ValueFromPipeline = true,
            HelpMessage = "Key Vault object.")]
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = InputObjectForVault,
            ValueFromPipeline = true,
            HelpMessage = "Key Vault object.")]
        [ValidateNotNullOrEmpty]
        public PSKeyVault InputObject { get; set; }

        /// <summary>
        /// Vault ResourceId
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ResourceIdByObjectId,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "KeyVault Resource Id.")]
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ResourceIdByServicePrincipalName,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "KeyVault Resource Id.")]
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ResourceIdByUserPrincipalName,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "KeyVault Resource Id.")]
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ResourceIdByEmail,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "KeyVault Resource Id.")]
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ResourceIdForVault,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "KeyVault Resource Id.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Service principal name
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ByServicePrincipalName,
            HelpMessage = "Specifies the service principal name of the application whose permissions you want to remove. Specify the application ID, also known as client ID, registered for the application in Azure Active Directory.")]
        [Parameter(Mandatory = true,
            ParameterSetName = InputObjectByServicePrincipalName,
            HelpMessage = "Specifies the service principal name of the application whose permissions you want to remove. Specify the application ID, also known as client ID, registered for the application in Azure Active Directory.")]
        [Parameter(Mandatory = true,
            ParameterSetName = ResourceIdByServicePrincipalName,
            HelpMessage = "Specifies the service principal name of the application whose permissions you want to remove. Specify the application ID, also known as client ID, registered for the application in Azure Active Directory.")]
        [ValidateNotNullOrEmpty()]
        [Alias("SPN")]
        public string ServicePrincipalName { get; set; }

        /// <summary>
        /// User principal name
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ByUserPrincipalName,
            HelpMessage = "Specifies the user principal name of the user whose access you want to remove.")]
        [Parameter(Mandatory = true,
            ParameterSetName = InputObjectByUserPrincipalName,
            HelpMessage = "Specifies the user principal name of the user whose access you want to remove.")]
        [Parameter(Mandatory = true,
            ParameterSetName = ResourceIdByUserPrincipalName,
            HelpMessage = "Specifies the user principal name of the user whose access you want to remove.")]
        [ValidateNotNullOrEmpty()]
        [Alias("UPN")]
        public string UserPrincipalName { get; set; }

        /// <summary>
        /// User principal name
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ByObjectId,
            HelpMessage = "Specifies the object ID of the user or service principal in Azure Active Directory for which to remove permissions.")]
        [Parameter(Mandatory = true,
            ParameterSetName = InputObjectByObjectId,
            HelpMessage = "Specifies the object ID of the user or service principal in Azure Active Directory for which to remove permissions.")]
        [Parameter(Mandatory = true,
            ParameterSetName = ResourceIdByObjectId,
            HelpMessage = "Specifies the object ID of the user or service principal in Azure Active Directory for which to remove permissions.")]
        [ValidateNotNullOrEmpty()]
        public string ObjectId { get; set; }

        /// <summary>
        /// Email address
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ByEmail,
            HelpMessage = "Specifies the email address of the user in Azure Active Directory whose permissions should be deleted.")]
        [Parameter(Mandatory = true,
            ParameterSetName = InputObjectByEmail,
            HelpMessage = "Specifies the email address of the user in Azure Active Directory whose permissions should be deleted.")]
        [Parameter(Mandatory = true,
            ParameterSetName = ResourceIdByEmail,
            HelpMessage = "Specifies the email address of the user in Azure Active Directory whose permissions should be deleted.")]
        [ValidateNotNullOrEmpty()]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Id of the application to which a user delegate to
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = ByObjectId,
            HelpMessage = "Specifies the ID of application whose permissions should be removed.")]
        [Parameter(Mandatory = false,
            ParameterSetName = InputObjectByObjectId,
            HelpMessage = "Specifies the ID of application whose permissions should be removed.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdByObjectId,
            HelpMessage = "Specifies the ID of application whose permissions should be removed.")]
        public Guid? ApplicationId { get; set; }

        [Parameter(Mandatory = false,
            ParameterSetName = ForVault,
            HelpMessage = "If specified, disables the retrieval of secrets from this key vault by the Microsoft.Compute resource provider when referenced in resource creation.")]
        [Parameter(Mandatory = false,
            ParameterSetName = InputObjectForVault,
            HelpMessage = "If specified, disables the retrieval of secrets from this key vault by the Microsoft.Compute resource provider when referenced in resource creation.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdForVault,
            HelpMessage = "If specified, disables the retrieval of secrets from this key vault by the Microsoft.Compute resource provider when referenced in resource creation.")]
        public SwitchParameter EnabledForDeployment { get; set; }

        [Parameter(Mandatory = false,
            ParameterSetName = ForVault,
            HelpMessage = "If specified, disables the retrieval of secrets from this key vault by Azure Resource Manager when referenced in templates.")]
        [Parameter(Mandatory = false,
            ParameterSetName = InputObjectForVault,
            HelpMessage = "If specified, disables the retrieval of secrets from this key vault by Azure Resource Manager when referenced in templates.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdForVault,
            HelpMessage = "If specified, disables the retrieval of secrets from this key vault by Azure Resource Manager when referenced in templates.")]
        public SwitchParameter EnabledForTemplateDeployment { get; set; }

        [Parameter(Mandatory = false,
            ParameterSetName = ForVault,
            HelpMessage = "If specified, disables the retrieval of secrets from this key vault by Azure Disk Encryption.")]
        [Parameter(Mandatory = false,
            ParameterSetName = InputObjectForVault,
            HelpMessage = "If specified, disables the retrieval of secrets from this key vault by Azure Disk Encryption.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdForVault,
            HelpMessage = "If specified, disables the retrieval of secrets from this key vault by Azure Disk Encryption.")]
        public SwitchParameter EnabledForDiskEncryption { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Parameter(Mandatory = false,
           HelpMessage = "This Cmdlet does not return an object by default. If this switch is specified, it returns the updated key vault object.")]
        public SwitchParameter PassThru { get; set; }


        #endregion

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(VaultName, Properties.Resources.RemoveVaultAccessPolicy))
            {
                if (InputObject != null)
                {
                    VaultName = InputObject.VaultName;
                    ResourceGroupName = InputObject.ResourceGroupName;
                }
                else if (!string.IsNullOrEmpty(ResourceId))
                {
                    var parsedResourceId = new ResourceIdentifier(ResourceId);
                    VaultName = parsedResourceId.ResourceName;
                    ResourceGroupName = parsedResourceId.ResourceGroupName;
                }

                ResourceGroupName = string.IsNullOrWhiteSpace(ResourceGroupName) ? GetResourceGroupName(VaultName) : ResourceGroupName;

                // Get the vault to be updated
                PSKeyVault existingVault = null;

                if (!string.IsNullOrWhiteSpace(ResourceGroupName))
                    existingVault = KeyVaultManagementClient.GetVault(
                                                    VaultName,
                                                    ResourceGroupName);
                if (existingVault == null)
                {
                    throw new ArgumentException(string.Format(Resources.VaultNotFound, VaultName, ResourceGroupName));
                }

                if (ApplicationId.HasValue && ApplicationId.Value == Guid.Empty)
                    throw new ArgumentException(Resources.InvalidApplicationId);

                if (!string.IsNullOrWhiteSpace(this.ObjectId) && !this.IsValidObjectIdSyntax(this.ObjectId))
                {
                    throw new ArgumentException(Resources.InvalidObjectIdSyntax);
                }

                // Update vault policies
                var updatedPolicies = existingVault.AccessPolicies;
                if (!string.IsNullOrEmpty(UserPrincipalName)
                    || !string.IsNullOrEmpty(ServicePrincipalName)
                    || !string.IsNullOrWhiteSpace(this.ObjectId)
                    || !string.IsNullOrWhiteSpace(this.EmailAddress))
                {
                    if (string.IsNullOrWhiteSpace(this.ObjectId))
                    {
                        if (GraphClient == null)
                        {
                            throw new Exception(Resources.ActiveDirectoryClientNull);
                        }
                        ObjectId = GetObjectId(this.ObjectId, this.UserPrincipalName, this.EmailAddress, this.ServicePrincipalName);
                    }
                    updatedPolicies = existingVault.AccessPolicies.Where(ap => !ShallBeRemoved(ap, ObjectId, this.ApplicationId)).ToArray();
                }

                // Update the vault
                var updatedVault = KeyVaultManagementClient.UpdateVault(
                    existingVault,
                    updatedPolicies,
                    EnabledForDeployment.IsPresent ? false : existingVault.EnabledForDeployment,
                    EnabledForTemplateDeployment.IsPresent ? false : existingVault.EnabledForTemplateDeployment,
                    EnabledForDiskEncryption.IsPresent ? false : existingVault.EnabledForDiskEncryption,
                    existingVault.EnableSoftDelete,
                    existingVault.EnablePurgeProtection,
                    existingVault.EnableRbacAuthorization,
                    existingVault.SoftDeleteRetentionInDays,
                    existingVault.NetworkAcls,
                    GraphClient);

                if (PassThru.IsPresent)
                    WriteObject(updatedVault);
            }
        }
        private bool ShallBeRemoved(PSKeyVaultAccessPolicy ap, string objectId, Guid? applicationId)
        {
            // If both object id and application id are specified, remove the compound identity policy only.
            // If only object id is specified, remove all policies refer to the object id including the compound identity policies.
            var sameObjectId = string.Equals(ap.ObjectId, objectId, StringComparison.OrdinalIgnoreCase);
            return applicationId.HasValue ? (ap.ApplicationId == applicationId && sameObjectId) : sameObjectId;
        }
    }
}
