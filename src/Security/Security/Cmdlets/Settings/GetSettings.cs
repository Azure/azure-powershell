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

using Commands.Security;
using Microsoft.Azure.Commands.Security.Common;
using Microsoft.Azure.Commands.Security.Models.Settings;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Security.Cmdlets.Settings
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SecuritySetting", DefaultParameterSetName = ParameterSetNames.SubscriptionScope), OutputType(typeof(PSSecuritySetting))]
    public class GetSettings : SecurityCenterCmdletBase
    {
        private const int MaxSettingsToFetch = 1500;

        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.SettingName)]
        [ValidateNotNullOrEmpty]
        public string SettingName { get; set; }

        public override void ExecuteCmdlet()
        {
            int numberOfFetchedSettings = 0;

            switch (ParameterSetName)
            {
                case ParameterSetNames.SubscriptionScope:
                    var settings = SecurityCenterClient.Settings.ListWithHttpMessagesAsync().GetAwaiter().GetResult().Body;
                    var PSTypeSettings = settings.ConvertToPSType();
                    WriteObject(PSTypeSettings, enumerateCollection: true);
                    numberOfFetchedSettings += PSTypeSettings.Count;
                    var nextLink = settings?.NextPageLink;
                    while (!string.IsNullOrWhiteSpace(nextLink) && numberOfFetchedSettings < MaxSettingsToFetch)
                    {
                        settings = SecurityCenterClient.Settings.ListNextWithHttpMessagesAsync(settings.NextPageLink).GetAwaiter().GetResult().Body;
                        PSTypeSettings = settings.ConvertToPSType();
                        WriteObject(PSTypeSettings, enumerateCollection: true);
                        numberOfFetchedSettings += PSTypeSettings.Count;
                        nextLink = settings?.NextPageLink;
                    }
                    break;
                case ParameterSetNames.SubscriptionLevelResource:
                    var setting = SecurityCenterClient.Settings.GetWithHttpMessagesAsync(SettingName).GetAwaiter().GetResult().Body;
                    WriteObject(setting.ConvertToPSType(), enumerateCollection: false);
                    break;
                default:
                    throw new PSInvalidOperationException();
            }
        }
    }
}