using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.KeyVault.Commands.Setting
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultSetting", DefaultParameterSetName = GetSettingViaFlattenParameters)]
    [OutputType(typeof(PSKeyVaultSetting))]
    public class GetAzKeyVaultSetting: KeyVaultCmdletBase
    {
        #region Parameter Set Names
        private const string GetSettingViaFlattenParameters = "GetSettingViaFlattenParameters";
        private const string GetSettingViaHsmObject = "GetSettingViaHsmObject";
        private const string GetSettingViaHsmId = "GetSettingViaHsmId";
        #endregion

        #region Input Parameter Definitions

        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = GetSettingViaFlattenParameters,
            HelpMessage = "Name of the HSM.")]
        [ResourceNameCompleter("Microsoft.KeyVault/managedHSMs", "FakeResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string HsmName;

        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = GetSettingViaHsmObject,
            ValueFromPipeline = true,
            HelpMessage = "Hsm Object.")]
        [ValidateNotNullOrEmpty]
        public PSManagedHsm HsmObject;

        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = GetSettingViaHsmId,
            HelpMessage = "Hsm Resource Id.")]
        [ValidateNotNullOrEmpty]
        public string HsmId;

        [Parameter(Mandatory = false,
            Position = 1,
            HelpMessage = "Name of the setting.")]
        public string Name;

        #endregion

        public override void ExecuteCmdlet()
        {
            NormalizeParameterSets();

            if (string.IsNullOrEmpty(Name))
            {
                WriteObject(this.Track2DataClient.GetManagedHsmSettings(HsmName), true);
            }
            else
            {
                WriteObject(this.Track2DataClient.GetManagedHsmSetting(HsmName, Name));
            }
        }

        private void NormalizeParameterSets()
        {
            switch (ParameterSetName)
            {
                case GetSettingViaHsmId:
                    var parsedResourceId = new ResourceIdentifier(HsmId);
                    HsmName = parsedResourceId.ResourceName;
                    break;
                case GetSettingViaHsmObject:
                    HsmName = HsmObject.VaultName;
                    break;
            }
        }
    }
}
