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
using Microsoft.Azure.Commands.Security.Models.SecurityContacts;
using Microsoft.Azure.Management.Security.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Security.Cmdlets.SecurityContacts
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SecurityContact", DefaultParameterSetName = ParameterSetNames.SubscriptionLevelResource, SupportsShouldProcess = true), OutputType(typeof(PSSecurityContact))]
    public class SetSecurityContacts : SecurityCenterCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.Email)]
        [ValidateNotNullOrEmpty]
        public string Email { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelResource, Mandatory = false, HelpMessage = ParameterHelpMessages.Phone)]
        public string Phone { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelResource, Mandatory = false, HelpMessage = ParameterHelpMessages.AlertsToAdmins)]
        public SwitchParameter AlertAdmin { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelResource, Mandatory = false, HelpMessage = ParameterHelpMessages.AlertNotifications)]
        public SwitchParameter NotifyOnAlert { get; set; }

        public override void ExecuteCmdlet()
        {
            var alertAdmin = AlertAdmin.IsPresent ? "On" : "Off";
            var alertNotification = NotifyOnAlert.IsPresent ? "On" : "Off";
            var phone = Phone ?? string.Empty;

            if (ShouldProcess(Name, VerbsCommon.Set))
            {
                var contact = new SecurityContact(email: Email, phone: phone, alertNotifications: alertNotification, alertsToAdmins: alertAdmin);
                var sc = SecurityCenterClient.SecurityContacts.CreateWithHttpMessagesAsync(Name, contact).GetAwaiter().GetResult().Body;

                WriteObject(sc.ConvertToPSType(), enumerateCollection: true); 
            }
        }
    }
}
