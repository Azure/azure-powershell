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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.KeyVault.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault.Commands
{
    [Cmdlet(VerbsData.Update, ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultManagedHsm", DefaultParameterSetName = UpdateByNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSManagedHsm))]
    public class UpdateAzureManagedHsm : KeyVaultManagementCmdletBase
    {
        private const string UpdateByNameParameterSet = "UpdateByNameParameterSet";
        private const string UpdateByInputObjectParameterSet = "UpdateByInputObjectParameterSet";
        private const string UpdateByResourceIdParameterSet = "UpdateByResourceIdParameterSet";

        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameParameterSet, HelpMessage = "Name of the managed HSM.")]
        [ResourceNameCompleter("Microsoft.KeyVault/managedHSMs", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        [Alias("HsmName")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameParameterSet, HelpMessage = "Name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = UpdateByInputObjectParameterSet, HelpMessage = "Managed HSM object.")]
        [ValidateNotNull]
        public PSManagedHsm InputObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = UpdateByResourceIdParameterSet, HelpMessage = "Resource ID of the managed HSM.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "specifying whether protection against purge is enabled for this managed HSM pool. The setting is effective only if soft delete is also enabled. Enabling this functionality is irreversible.")]
        public SwitchParameter EnablePurgeProtection { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Controls permission for data plane traffic coming from public networks while private endpoint is enabled.")]
        [PSArgumentCompleter("Enabled", "Disabled")]
        public string PublicNetworkAccess { get; set; }


        [Parameter(Mandatory = false,
            HelpMessage = "The set of user assigned identities associated with the managed HSM. Its value will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.")]
        [AllowEmptyCollection]
        public string[] UserAssignedIdentity { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hash table which represents resource tags.")]
        [Alias(Constants.TagsAlias)]
        public Hashtable Tag { get; set; }

        public override void ExecuteCmdlet()
        {
            NormalizeParameterSets();

            PSManagedHsm existingResource = null;
            try
            {
                existingResource = KeyVaultManagementClient.GetManagedHsm(this.Name, this.ResourceGroupName);
            }
            catch
            {
                throw new Exception(string.Format(Resources.HsmNotFound, this.Name, this.ResourceGroupName));
            }

            if (this.ShouldProcess(this.Name, string.Format(Resources.UpdateHsmShouldProcessMessage, this.Name, this.ResourceGroupName)))
            {
                var result = KeyVaultManagementClient.UpdateManagedHsm(existingResource, PrepareParameters(existingResource), null);
                WriteObject(result);
            }
        }

        private void NormalizeParameterSets()
        {

            if (this.IsParameterBound(c => c.InputObject))
            {
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.Name = this.InputObject.Name;
            }

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.Name = resourceIdentifier.ResourceName;
            }
        }

        private VaultCreationOrUpdateParameters PrepareParameters(PSManagedHsm hsm)
        {
            ManagedServiceIdentity managedServiceIdentity = null;

            if (this.IsParameterBound(c => c.UserAssignedIdentity))
            {
                if (this.UserAssignedIdentity.Length > 0)
                {
                    managedServiceIdentity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned)
                    {
                        UserAssignedIdentities = new Dictionary<string, UserAssignedIdentity>()
                    };
                    UserAssignedIdentity?.ForEach(id => managedServiceIdentity.UserAssignedIdentities.Add(id, new UserAssignedIdentity()));
                    hsm.OriginalManagedHsm.Identity?.UserAssignedIdentities?.Keys?.ToList()?.ForEach(id => {
                        if (!UserAssignedIdentity.Contains(id))
                        {
                            managedServiceIdentity.UserAssignedIdentities.Add(id, default(UserAssignedIdentity));
                        }
                    });
                }
                else
                {
                    managedServiceIdentity = new ManagedServiceIdentity(ManagedServiceIdentityType.None);
                }
            };

            return new VaultCreationOrUpdateParameters
            {
                // false is not accepted
                EnablePurgeProtection = this.EnablePurgeProtection.IsPresent ? (true as bool?) : null,
                PublicNetworkAccess = this.PublicNetworkAccess,
                ManagedServiceIdentity = managedServiceIdentity,
                Tags = this.Tag
            };
        }
    }
}