
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Globalization;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ManagedHsm", SupportsShouldProcess = true, DefaultParameterSetName = RemoveManagedHsmByNameParameterSet)]
    [OutputType(typeof(bool))]
    public class RemoveAzureManagedHsm : KeyVaultManagementCmdletBase
    {
        #region Parameter Set Names

        private const string RemoveManagedHsmByNameParameterSet = "RemoveManagedHsmByName";
        private const string RemoveManagedHsmByInputObjectParameterSet = "RemoveManagedHsmByInputObject";
        private const string RemoveManagedHsmByResourceIdParameterSet = "RemoveManagedHsmByResourceId";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// HSM name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = RemoveManagedHsmByNameParameterSet,
            HelpMessage = "Specifies the name of the managed HSM to remove.")]
        [ResourceNameCompleter("Microsoft.KeyVault/managedHSMs", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        [Alias("HsmName")]
        public string Name { get; set; }

        /// <summary>
        /// HSM object
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = RemoveManagedHsmByInputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "Managed HSM object to be deleted.")]
        [ValidateNotNullOrEmpty]
        public PSManagedHsm InputObject { get; set; }

        /// <summary>
        /// HSM Resource Id
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = RemoveManagedHsmByResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Managed HSM Resource Id.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Resource group to which the managed HSM belongs.
        /// </summary>
        [Parameter(Mandatory = false,
            Position = 1,
            ParameterSetName = RemoveManagedHsmByNameParameterSet,
            HelpMessage = "Specifies the name of resource group for Azure managed HSM to remove.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// If present, do not ask for confirmation
        /// </summary>
        [Parameter(Mandatory = false,
           HelpMessage = "Indicates that the cmdlet does not prompt you for confirmation. By default, this cmdlet prompts you to confirm that you want to delete the managed HSM.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(Mandatory = false,
           HelpMessage = "This Cmdlet does not return an object by default. If this switch is specified, it returns true if successful.")]
        public SwitchParameter PassThru { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (InputObject != null)
            {
                Name = InputObject.Name;
                ResourceGroupName = InputObject.ResourceGroupName;
            }
            else if (ResourceId != null)
            {
                var resourceIdentifier = new ResourceIdentifier(ResourceId);
                Name = resourceIdentifier.ResourceName;
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
            }

            // Get resource group name for Managed HSM
            ResourceGroupName = string.IsNullOrWhiteSpace(ResourceGroupName) ? GetResourceGroupName(Name, true) : ResourceGroupName;
            if (string.IsNullOrWhiteSpace(ResourceGroupName))
                throw new ArgumentException(string.Format(Resources.HsmNotFound, Name, ResourceGroupName));

            ConfirmAction(
                Force.IsPresent,
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.RemoveHsmWarning,
                    Name),
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.RemoveHsmWhatIfMessage,
                    Name),
                Name,
                () =>
                {
                    KeyVaultManagementClient.DeleteManagedHsm(
                        managedHsm: Name,
                        resourceGroupName: ResourceGroupName);

                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}