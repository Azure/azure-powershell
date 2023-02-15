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
using System;
using System.Globalization;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "KeyVaultManagedHsm", SupportsShouldProcess = true, DefaultParameterSetName = RemoveManagedHsmByNameParameterSet)]
    [OutputType(typeof(bool))]
    public class RemoveAzureManagedHsm : KeyVaultManagementCmdletBase
    {
        #region Parameter Set Names

        private const string RemoveManagedHsmByNameParameterSet = "RemoveManagedHsmByName";
        private const string RemoveManagedHsmByInputObjectParameterSet = "RemoveManagedHsmByInputObject";
        private const string RemoveManagedHsmByResourceIdParameterSet = "RemoveManagedHsmByResourceId";

        private const string RemoveDeletedManagedHsmByNameParameterSet = "RemoveDeletedManagedHsmByName";
        private const string RemoveDeletedManagedHsmByInputObjectParameterSet = "RemoveDeletedManagedHsmByInputObject";
        private const string RemoveDeletedManagedHsmByResourceIdParameterSet = "RemoveDeletedManagedHsmByResourceId";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// HSM name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = RemoveManagedHsmByNameParameterSet,
            HelpMessage = "Specifies the name of the managed HSM to remove.")]
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = RemoveDeletedManagedHsmByNameParameterSet)]
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
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = RemoveDeletedManagedHsmByInputObjectParameterSet,
            ValueFromPipeline = true)]
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
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = RemoveDeletedManagedHsmByResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true)]
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

        [Parameter(Mandatory = true,
            Position = 1,
            ParameterSetName = RemoveDeletedManagedHsmByNameParameterSet,
            HelpMessage = "The location of the deleted managed HSM pool.")]
        [Parameter(Mandatory = true,
            Position = 1,
            ParameterSetName = RemoveDeletedManagedHsmByResourceIdParameterSet)]
        [LocationCompleter("Microsoft.KeyVault/managedHSMs")]
        [ValidateNotNullOrEmpty()]
        public string Location { get; set; }

        /// <summary>
        /// If present, operate on the deleted vault entity.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = RemoveDeletedManagedHsmByNameParameterSet,
            HelpMessage = "Remove the previously deleted managed HSM pool permanently.")]
        [Parameter(Mandatory = true,
            ParameterSetName = RemoveDeletedManagedHsmByInputObjectParameterSet,
            HelpMessage = "Remove the previously deleted managed HSM pool permanently.")]
        [Parameter(Mandatory = true,
            ParameterSetName = RemoveDeletedManagedHsmByResourceIdParameterSet,
            HelpMessage = "Remove the previously deleted managed HSM pool permanently.")]
        public SwitchParameter InRemovedState { get; set; }

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
                Location = InputObject.Location;
            }
            else if (ResourceId != null)
            {
                var resourceIdentifier = new ResourceIdentifier(ResourceId);
                Name = resourceIdentifier.ResourceName;
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
            }

            if (InRemovedState.IsPresent && InRemovedState.ToBool())
            {
                ConfirmAction(
                   Force.IsPresent,
                   string.Format(
                       CultureInfo.InvariantCulture,
                       Resources.PurgeManagedHsmWarning,
                       Name),
                   string.Format(
                       CultureInfo.InvariantCulture,
                       Resources.PurgeManagedHsmWarningWhatIf,
                       Name),
                   Name,
                   () =>
                   {
                       KeyVaultManagementClient.PurgeManagedHsm(
                           managedHsmName: Name,
                           location: Location);

                       if (PassThru)
                       {
                           WriteObject(true);
                       }
                   });
            }
            else
            {
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
}