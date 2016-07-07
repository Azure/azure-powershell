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
    [Cmdlet(VerbsCommon.Remove, "AzureRmKeyVaultAccessPolicy",
        SupportsShouldProcess = true,
        HelpUri = Constants.KeyVaultHelpUri)]
    [OutputType(typeof(PSKeyVaultModels.PSVault))]
    public class RemoveAzureKeyVaultAccessPolicy : KeyVaultManagementCmdletBase
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
            HelpMessage = "Specifies the name of the key vault. This cmdlet removes permissions for the key vault that this parameter specifies.")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(Mandatory = false,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the name of the resource group associated with the key vault whose permissions you want to remove.")]
        [ValidateNotNullOrEmpty()]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Service principal name
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ByServicePrincipalName,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the service principal name of the application whose permissions you want to remove. Specify the application ID, also known as client ID, registered for the application in Azure Active Directory.")]
        [ValidateNotNullOrEmpty()]
        [Alias("SPN")]
        public string ServicePrincipalName { get; set; }

        /// <summary>
        /// User principal name
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ByUserPrincipalName,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the user principal name of the user whose access you want to remove.")]
        [ValidateNotNullOrEmpty()]
        [Alias("UPN")]
        public string UserPrincipalName { get; set; }

        /// <summary>
        /// User principal name
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ByObjectId,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the object ID of the user or service principal in Azure Active Directory for which to remove permissions.")]
        [ValidateNotNullOrEmpty()]
        public Guid ObjectId { get; set; }

        /// <summary>
        /// Id of the application to which a user delegate to
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = ByObjectId,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the ID of application that a user must.")]
        public Guid? ApplicationId { get; set; }

        [Parameter(Mandatory = false,
            ParameterSetName = ForVault,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "If specified, disables the retrieval of secrets from this key vault by the Microsoft.Compute resource provider when referenced in resource creation.")]
        public SwitchParameter EnabledForDeployment { get; set; }

        [Parameter(Mandatory = false,
            ParameterSetName = ForVault,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "If specified, disables the retrieval of secrets from this key vault by Azure Resource Manager when referenced in templates.")]
        public SwitchParameter EnabledForTemplateDeployment { get; set; }

        [Parameter(Mandatory = false,
            ParameterSetName = ForVault,
            ValueFromPipelineByPropertyName = true,
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
                if (ParameterSetName == ForVault && !EnabledForDeployment.IsPresent &&
                !EnabledForTemplateDeployment.IsPresent && !EnabledForDiskEncryption.IsPresent)
                {
                    throw new ArgumentException(PSKeyVaultProperties.Resources.VaultPermissionFlagMissing);
                }

                ResourceGroupName = string.IsNullOrWhiteSpace(ResourceGroupName) ? GetResourceGroupName(VaultName) : ResourceGroupName;

                // Get the vault to be updated
                PSKeyVaultModels.PSVault existingVault = null;

                if (!string.IsNullOrWhiteSpace(ResourceGroupName))
                    existingVault = KeyVaultManagementClient.GetVault(
                                                    VaultName,
                                                    ResourceGroupName);
                if (existingVault == null)
                {
                    throw new ArgumentException(string.Format(PSKeyVaultProperties.Resources.VaultNotFound, VaultName, ResourceGroupName));
                }

                if (ApplicationId.HasValue && ApplicationId.Value == Guid.Empty)
                    throw new ArgumentException(PSKeyVaultProperties.Resources.InvalidApplicationId);

                // Update vault policies
                var updatedPolicies = existingVault.AccessPolicies;
                if (!string.IsNullOrEmpty(UserPrincipalName) || !string.IsNullOrEmpty(ServicePrincipalName) || (ObjectId != Guid.Empty))
                {
                    if (ObjectId == Guid.Empty)
                    {
                        ObjectId = GetObjectId(this.ObjectId, this.UserPrincipalName, this.ServicePrincipalName);
                    }
                    updatedPolicies = existingVault.AccessPolicies.Where(ap => !ShallBeRemoved(ap, ObjectId, this.ApplicationId)).ToArray();
                }

                // Update the vault
                var updatedVault = KeyVaultManagementClient.UpdateVault(existingVault, updatedPolicies,
                    EnabledForDeployment.IsPresent ? false : existingVault.EnabledForDeployment,
                    EnabledForTemplateDeployment.IsPresent ? false : existingVault.EnabledForTemplateDeployment,
                    EnabledForDiskEncryption.IsPresent ? false : existingVault.EnabledForDiskEncryption,
                    ActiveDirectoryClient);

                if (PassThru.IsPresent)
                    WriteObject(updatedVault);
            }
        }
        private bool ShallBeRemoved(PSKeyVaultModels.PSVaultAccessPolicy ap, Guid objectId, Guid? applicationId)
        {
            // If both object id and application id are specified, remove the compound identity policy only.                    
            // If only object id is specified, remove all policies refer to the object id including the compound identity policies.                                
            return applicationId.HasValue ? (ap.ApplicationId == applicationId && ap.ObjectId == objectId) :
                (ap.ObjectId == objectId);
        }
    }
}
