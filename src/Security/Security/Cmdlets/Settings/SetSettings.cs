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
// ------------------------------------

using System.Management.Automation;
using Commands.Security;
using Microsoft.Azure.Commands.Security.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Security.Models.Settings;


namespace Microsoft.Azure.Commands.Security.Cmdlets.Settings
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SecuritySetting", SupportsShouldProcess = true, DefaultParameterSetName = ParameterSetNames.GeneralScope), OutputType(typeof(PSSecuritySetting))]
    public class SetSettings : SecurityCenterCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.DataExportSettingsScope, Mandatory = true, HelpMessage = ParameterHelpMessages.SettingName)]
        [ValidateNotNullOrEmpty]
        public string SettingName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.DataExportSettingsScope, Mandatory = true, HelpMessage = ParameterHelpMessages.SettingKind)]
        [ValidateNotNullOrEmpty]
        public string SettingKind { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.InputObject, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.InputObject)]
        [ValidateNotNullOrEmpty]
        public PSSecuritySetting InputObject { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.DataExportSettingsScope, Mandatory = true, HelpMessage = ParameterHelpMessages.Enabled)]
        [Parameter(ParameterSetName = ParameterSetNames.InputObject, Mandatory = false, ValueFromPipeline = false, HelpMessage = ParameterHelpMessages.Enabled)]
        [ValidateNotNullOrEmpty]
        public bool Enabled { get; set; }

        public override void ExecuteCmdlet()
        {
            PSSecuritySetting setting;

            switch (ParameterSetName)
            {
                case ParameterSetNames.DataExportSettingsScope:
                    break;
                case ParameterSetNames.InputObject:
                    if (InputObject.GetType().Name == nameof(PSSecurityDataExportSetting))
                    {
                        SettingKind = "DataExportSettings";
                        Enabled = !this.IsParameterBound(c => c.Enabled) ? ((PSSecurityDataExportSetting)InputObject).Enabled : Enabled;
                    }
                    SettingName = InputObject.Name;
                    break;
                default:
                    throw new PSInvalidOperationException();
            }

            if (SettingKind == "DataExportSettings")
            {
                setting = new PSSecurityDataExportSetting()
                {
                    Enabled = Enabled,
                    Name = SettingName
                };
            }
            else
            {
                throw new PSInvalidOperationException("Invalid setting kind");
            }


            if (ShouldProcess(SettingName, VerbsCommon.Set))
            {
                var updatedSetting = SecurityCenterClient.Settings.UpdateWithHttpMessagesAsync(SettingName, setting.ConvertToCSType()).GetAwaiter().GetResult().Body;

                WriteObject(updatedSetting.ConvertToPSType(), enumerateCollection: false);
            }
        }
    }
}