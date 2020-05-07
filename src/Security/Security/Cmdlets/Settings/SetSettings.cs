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
using Microsoft.Azure.Commands.Security.Models.Settings;
using Microsoft.Azure.Commands.SecurityCenter.Common;
using Microsoft.Azure.Management.Security.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Security.Cmdlets.Settings
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SecuritySetting", DefaultParameterSetName = ParameterSetNames.SubscriptionLevelResource, SupportsShouldProcess = true), OutputType(typeof(PSSecuritySetting))]
    public class SetSettings : SecurityCenterCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.SettingName)]
        [ValidateNotNullOrEmpty]
        public string SettingName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.Setting)]
        [ValidateNotNullOrEmpty]
        public PSSecuritySetting SettingInput { get; set; }

        public override void ExecuteCmdlet()
        {
            var settingName = SettingName;
            SettingInput.Name = SettingName;
            var setting = SettingInput.ConvertToCSType();
      
            if (ShouldProcess(settingName, VerbsCommon.Set))
            {
                var setting2 = SecurityCenterClient.Settings.UpdateWithHttpMessagesAsync(settingName, setting).GetAwaiter().GetResult().Body;

                WriteObject(setting2.ConvertToPSType(), enumerateCollection: false);
            }
        }
    }
}