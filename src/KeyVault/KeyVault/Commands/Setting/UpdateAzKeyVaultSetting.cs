using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.KeyVault.Commands.Setting
{
    [Cmdlet(VerbsData.Update, ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultSetting", DefaultParameterSetName = UpdateSettingViaFlattenValuesParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSKeyVaultSetting))]
    public class UpdateAzKeyVaultSetting : KeyVaultCmdletBase
    {
        #region Parameter Set Names

        private const string UpdateSettingViaFlattenValuesParameterSet = "UpdateSettingViaFlattenValues";
        private const string UpdateSettingViaHsmObjectParameterSet = "UpdateSettingViaHsmObject";
        private const string UpdateSettingViaHsmIdParameterSet = "UpdateSettingViaHsmId";
        private const string UpdateSettingViaInputObjectParameterSet = "UpdateSettingViaInputObject";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// Hsm name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = UpdateSettingViaFlattenValuesParameterSet,
            HelpMessage = "Name of the HSM.")]
        [Parameter(Mandatory = false, Position = 0, ParameterSetName = UpdateSettingViaInputObjectParameterSet)]
        [ResourceNameCompleter("Microsoft.KeyVault/managedHSMs", "FakeResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string HsmName { get; set; }

        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = UpdateSettingViaHsmObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "Hsm Object.")]
        [ValidateNotNullOrEmpty]
        public PSManagedHsm HsmObject;

        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = UpdateSettingViaHsmIdParameterSet,
            HelpMessage = "Hsm Resource Id.")]
        [ValidateNotNullOrEmpty]
        public string HsmId;

        /// <summary>
        /// Name of the setting
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 1,
            ParameterSetName = UpdateSettingViaFlattenValuesParameterSet,
            HelpMessage = "Name of the setting.")]
        [Parameter(Mandatory = true,
            Position = 1,
            ParameterSetName = UpdateSettingViaHsmObjectParameterSet)]
        [Parameter(Mandatory = true,
            Position = 1,
            ParameterSetName = UpdateSettingViaHsmIdParameterSet)]
        public string Name { get; set; }

        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = UpdateSettingViaFlattenValuesParameterSet,
            HelpMessage = "Value of the setting.")]
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = UpdateSettingViaHsmObjectParameterSet)]
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = UpdateSettingViaHsmIdParameterSet)]
        [Parameter(Mandatory = false, Position = 2, ParameterSetName = UpdateSettingViaInputObjectParameterSet)]
        public string Value { get; set; }

        [Parameter(Mandatory = true,
            Position = 1,
            ParameterSetName = UpdateSettingViaInputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "The location of the deleted vault.")]
        [ValidateNotNullOrEmpty()]
        public PSKeyVaultSetting InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Cmdlet does not return object by default. If this switch is specified, return Secret object.")]
        public SwitchParameter PassThru { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            NormalizeParameterSets();
            if (ShouldProcess(InputObject.Name, Properties.Resources.UpdateKeyVaultSetting))            {
                var setting = Track2DataClient.UpdateManagedHsmSetting(InputObject);
                if(PassThru.IsPresent) WriteObject(setting);
            }
        }

        private void NormalizeParameterSets()
        {
            switch (ParameterSetName)
            {
                case UpdateSettingViaHsmIdParameterSet:
                    var parsedResourceId = new ResourceIdentifier(HsmId);
                    HsmName = parsedResourceId.ResourceName;
                    break;
                case UpdateSettingViaHsmObjectParameterSet:
                    HsmName = HsmObject.VaultName; 
                    break;
                case UpdateSettingViaInputObjectParameterSet:
                    if (this.IsParameterBound(c => c.HsmName))
                    {
                        InputObject.HsmName = HsmName;
                    }
                    break;
            }
            if (!ParameterSetName.Equals(UpdateSettingViaInputObjectParameterSet))
            {
                InputObject = Track2DataClient.GetManagedHsmSetting(HsmName, Name);
            }
            if (this.IsParameterBound(c => c.Value))
            {
                InputObject.Value = this.Value;
            }
        }
    }
}
