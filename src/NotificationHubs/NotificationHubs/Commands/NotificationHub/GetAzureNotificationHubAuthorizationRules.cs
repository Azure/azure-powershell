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

using Microsoft.Azure.Commands.NotificationHubs.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.NotificationHubs.Commands.NotificationHub
{
    [GenericBreakingChange("Get-AzNotificationHubAuthorizationRules alias will be removed in an upcoming breaking change release", "2.0.0")]
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NotificationHubAuthorizationRule"), OutputType(typeof(SharedAccessAuthorizationRuleAttributes))]
    [Alias("Get-AzNotificationHubAuthorizationRules")]
    public class GetAzureNotificationHubAuthorizationRules : AzureNotificationHubsCmdletBase
    {
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The name of the resource group")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroup { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Namespace Name.")]
        [ValidateNotNullOrEmpty]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "NotificationHub Name.")]
        [ValidateNotNullOrEmpty]
        public string NotificationHub { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "NotificationHub AuthorizationRule Name.")]
        public string AuthorizationRule { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(AuthorizationRule))
            {
                // Get a notificationHub AuthorizationRules
                var authRule = Client.GetNotificationHubAuthorizationRules(ResourceGroup, Namespace, NotificationHub, AuthorizationRule);
                WriteObject(authRule);
            }
            else
            {
                // Get all notificationHub AuthorizationRules
                var authRuleList = Client.ListNotificationHubAuthorizationRules(ResourceGroup, Namespace, NotificationHub);
                WriteObject(authRuleList.ToList(), true);
            }
        }
    }
}
