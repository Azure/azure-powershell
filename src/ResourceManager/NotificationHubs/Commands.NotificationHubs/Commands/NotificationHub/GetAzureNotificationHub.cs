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

namespace Microsoft.Azure.Commands.NotificationHubs.Commands.NotificationHub
{
    using Microsoft.Azure.Commands.NotificationHubs.Models;
    using Microsoft.Azure.Management.NotificationHubs.Models;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Linq;

    [Cmdlet(VerbsCommon.Get, "AzureNotificationHub"), OutputType(typeof(List<NotificationHubAttributes>))]
    public class GetAzureNotificationHub: AzureNotificationHubsCmdletBase
    {
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The name of the resource group")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Namespace Name.")]
        [ValidateNotNullOrEmpty]
        public string NamespaceName { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "NotificationHub Name.")]
        public string NotificationHubName { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(ResourceGroupName) && !string.IsNullOrEmpty(NamespaceName))
            {
                if (!string.IsNullOrEmpty(NotificationHubName))
                {
                    // Get a NotificationHub
                    var notificationHub = Client.GetNotificationHub(ResourceGroupName, NamespaceName, NotificationHubName);
                    WriteObject(notificationHub);
                }
                else
                {
                    // Get all NotificationHub
                    var notificationHubsList = Client.ListNotificationHubs(ResourceGroupName, NamespaceName);
                    WriteObject(notificationHubsList.ToList(), true);
                }
            }
        }
    }
}
