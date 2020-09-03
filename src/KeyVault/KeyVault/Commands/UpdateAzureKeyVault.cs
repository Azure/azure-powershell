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
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.KeyVault
{
    [Cmdlet(VerbsData.Update, ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVault", DefaultParameterSetName = UpdateByNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSKeyVault))]
    public class UpdateTopLevelResourceCommand : KeyVaultManagementCmdletBase
    {
        private const string UpdateByNameParameterSet = "UpdateByNameParameterSet";
        private const string UpdateByInputObjectParameterSet = "UpdateByInputObjectParameterSet";
        private const string UpdateByResourceIdParameterSet = "UpdateByResourceIdParameterSet";

        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameParameterSet, HelpMessage = "Name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameParameterSet, HelpMessage = "Name of the key vault.")]
        [ResourceNameCompleter("Microsoft.KeyVault/vaults", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        [Alias("Name")]
        public string VaultName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = UpdateByInputObjectParameterSet, HelpMessage = "Key vault object.")]
        [ValidateNotNull]
        public PSKeyVault InputObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = UpdateByResourceIdParameterSet, HelpMessage = "Resource ID of the key vault.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }
        
        public const String EnableSoftDeleteChangeDesc = "EnableSoftDelete will be deprecated without being replaced.";

        [CmdletParameterBreakingChange("EnableSoftDelete", "3.0.0", ChangeDescription = EnableSoftDeleteChangeDesc)]
        [Parameter(Mandatory = false, HelpMessage = "Enable the soft-delete functionality for this key vault. Once enabled it cannot be disabled.")]
        public SwitchParameter EnableSoftDelete { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Enable the purge protection functionality for this key vault. Once enabled it cannot be disabled. It requires soft-delete to be turned on.")]
        public SwitchParameter EnablePurgeProtection { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Specifies how long deleted resources are retained, and how long until a vault or an object in the deleted state can be purged. The default is " + Constants.DefaultSoftDeleteRetentionDaysString + " days.")]
        [ValidateRange(Constants.MinSoftDeleteRetentionDays, Constants.MaxSoftDeleteRetentionDays)]
        [ValidateNotNullOrEmpty]
        public int SoftDeleteRetentionInDays { get; set; }

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

            PSKeyVault existingResource = null;
            try
            {
                existingResource = KeyVaultManagementClient.GetVault(this.VaultName, this.ResourceGroupName);
            }
            catch
            {
                existingResource = null;
            }

            if (existingResource == null)
            {
                throw new Exception(string.Format("A key vault with name '{0}' in resource group '{1}' does not exist. Please use New-AzKeyVault to create a key vault with these properties.", this.VaultName, this.ResourceGroupName));
            }

            if (this.ShouldProcess(this.VaultName, string.Format("Updating key vault '{0}' in resource group '{1}'.", this.VaultName, this.ResourceGroupName)))
            {
                var result = KeyVaultManagementClient.UpdateVault(existingResource,
                    existingResource.AccessPolicies,
                    existingResource.EnabledForDeployment,
                    existingResource.EnabledForTemplateDeployment,
                    existingResource.EnabledForDiskEncryption,
                    EnableSoftDelete.IsPresent ? (true as bool?) : null,
                    EnablePurgeProtection.IsPresent ? (true as bool?) : null,
                    this.IsParameterBound(c => c.SoftDeleteRetentionInDays)
                        ? (SoftDeleteRetentionInDays as int?)
                        : (existingResource.SoftDeleteRetentionInDays ?? Constants.DefaultSoftDeleteRetentionDays),
                    existingResource.NetworkAcls
                );
                WriteObject(result);
            }
        }
    }
}
