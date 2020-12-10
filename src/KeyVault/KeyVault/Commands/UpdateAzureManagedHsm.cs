using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault.Commands
{
    [Cmdlet(VerbsData.Update, ResourceManager.Common.AzureRMConstants.AzurePrefix + "ManagedHsm", DefaultParameterSetName = UpdateByNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSManagedHsm))]
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
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hash table which represents resource tags.")]
        [Alias(Constants.TagsAlias)]
        public Hashtable Tag { get; set; }

        public override void ExecuteCmdlet()
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

            PSManagedHsm existingResource = null;
            try
            {
                existingResource = KeyVaultManagementClient.GetManagedHsm(this.Name, this.ResourceGroupName);
            }
            catch
            {
                existingResource = null;
            }

            if (existingResource == null)
            {
                throw new Exception(string.Format("A managed HSM with name '{0}' in resource group '{1}' does not exist. Please use New-AzManagedHsm to create a managed HSM with these properties.", this.Name, this.ResourceGroupName));
            }

            if (this.ShouldProcess(this.Name, string.Format("Updating managed HSM '{0}' in resource group '{1}'.", this.Name, this.ResourceGroupName)))
            {
                var result = KeyVaultManagementClient.UpdateManagedHsm(existingResource, 
                    new VaultCreationOrUpdateParameters 
                    { 
                        Tags = Tag
                    }, null);
                WriteObject(result);
            }
        }
    }
}