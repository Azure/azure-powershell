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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.KeyVault
{
    [Cmdlet(VerbsData.Update, ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVault", DefaultParameterSetName = UpdateKeyVault + ByNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSKeyVault))]
    public class UpdateTopLevelResourceCommand : KeyVaultManagementCmdletBase
    {
        private const string UpdateKeyVault = "UpdateKeyVault";
        private const string UpdateManagedHsm = "UpdateManagedHsm";
        private const string ByNameParameterSet = "ByNameParameterSet";
        private const string ByInputObjectParameterSet = "ByInputObjectParameterSet";
        private const string ByResourceIdParameterSet = "UByResourceIdParameterSet";

        [Parameter(Mandatory = true, ParameterSetName = UpdateKeyVault + ByNameParameterSet, HelpMessage = "Name of the resource group.")]
        [Parameter(Mandatory = true, ParameterSetName = UpdateManagedHsm + ByNameParameterSet, HelpMessage = "Name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = UpdateKeyVault + ByNameParameterSet, HelpMessage = "Name of the key vault.")]
        [Parameter(Mandatory = true, ParameterSetName = UpdateManagedHsm + ByNameParameterSet, HelpMessage = "Name of the key vault.")]
        [ResourceNameCompleter("Microsoft.KeyVault/vaults", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        [Alias("Name")]
        public string VaultName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = UpdateKeyVault + ByInputObjectParameterSet, HelpMessage = "Key vault object.")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = UpdateManagedHsm + ByInputObjectParameterSet, HelpMessage = "Key vault object.")]
        [ValidateNotNull]
        public PSKeyVaultIdentityItem InputObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = UpdateKeyVault + ByResourceIdParameterSet, HelpMessage = "Resource ID of the key vault.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = UpdateManagedHsm + ByResourceIdParameterSet, HelpMessage = "Resource ID of the key vault.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Enable the soft-delete functionality for this key vault. Once enabled it cannot be disabled.")]
        public SwitchParameter EnableSoftDelete { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Enable the purge protection functionality for this key vault. Once enabled it cannot be disabled. It requires soft-delete to be turned on.")]
        public SwitchParameter EnablePurgeProtection { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Specifies how long deleted resources are retained, and how long until a vault or an object in the deleted state can be purged. The default is " + Constants.DefaultSoftDeleteRetentionDaysString + " days.")]
        [ValidateRange(Constants.MinSoftDeleteRetentionDays, Constants.MaxSoftDeleteRetentionDays)]
        [ValidateNotNullOrEmpty]
        public int SoftDeleteRetentionInDays { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = UpdateManagedHsm + ByNameParameterSet, HelpMessage = "Specifies the type of this vault as MHSM.")]
        [Parameter(Mandatory = true, ParameterSetName = UpdateManagedHsm + ByInputObjectParameterSet, HelpMessage = "Specifies the type of this vault as MHSM.")]
        [Parameter(Mandatory = true, ParameterSetName = UpdateManagedHsm + ByResourceIdParameterSet, HelpMessage = "Specifies the type of this vault as MHSM.")]
        public SwitchParameter Hsm { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.InputObject))
            {
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.VaultName = this.InputObject.VaultName;
            }

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.VaultName = resourceIdentifier.ResourceName;
            }

            PSKeyVaultIdentityItem existingResource = null;
            try
            {
                if (Hsm.IsPresent) existingResource = KeyVaultManagementClient.GetManagedHsm(VaultName, ResourceGroupName);
                else existingResource = KeyVaultManagementClient.GetVault(this.VaultName, this.ResourceGroupName);
            }
            catch
            {
                existingResource = null;
            }

            if (existingResource == null)
            {
                if(Hsm.IsPresent)
                    throw new Exception(string.Format("A managed hsm with name '{0}' in resource group '{1}' does not exist. Please use New-AzKeyVault to create a managed hsm with these properties.", this.VaultName, this.ResourceGroupName));
                else 
                    throw new Exception(string.Format("A key vault with name '{0}' in resource group '{1}' does not exist. Please use New-AzKeyVault to create a key vault with these properties.", this.VaultName, this.ResourceGroupName));

            }

            if (this.ShouldProcess(this.VaultName, string.Format("Updating key vault '{0}' in resource group '{1}'.", this.VaultName, this.ResourceGroupName)))
            {
                if (Hsm.IsPresent)
                {
                    var existingManagedHsmResource = (PSManagedHsm)existingResource;
                    var result = KeyVaultManagementClient.UpdateManagedHsm(existingManagedHsmResource,
                        existingManagedHsmResource.EnableSoftDelete,
                        EnablePurgeProtection.IsPresent ? (true as bool?) : null,
                        this.IsParameterBound(c => c.SoftDeleteRetentionInDays)
                            ? (SoftDeleteRetentionInDays as int?)
                            : (existingManagedHsmResource.SoftDeleteRetentionInDays ?? Constants.DefaultSoftDeleteRetentionDays)
                        );
                    WriteObject(result);
                }
                else
                {
                    var existingKeyVaultResource = (PSKeyVault)existingResource;
                    var result = KeyVaultManagementClient.UpdateVault(existingKeyVaultResource,
                        existingKeyVaultResource.AccessPolicies,
                        existingKeyVaultResource.EnabledForDeployment,
                        existingKeyVaultResource.EnabledForTemplateDeployment,
                        existingKeyVaultResource.EnabledForDiskEncryption,
                        EnableSoftDelete.IsPresent ? (true as bool?) : null,
                        EnablePurgeProtection.IsPresent ? (true as bool?) : null,
                        this.IsParameterBound(c => c.SoftDeleteRetentionInDays)
                            ? (SoftDeleteRetentionInDays as int?)
                            : (existingKeyVaultResource.SoftDeleteRetentionInDays ?? Constants.DefaultSoftDeleteRetentionDays),
                        existingKeyVaultResource.NetworkAcls
                    );
                    WriteObject(result);
                }

                
            }
        }
    }
}
