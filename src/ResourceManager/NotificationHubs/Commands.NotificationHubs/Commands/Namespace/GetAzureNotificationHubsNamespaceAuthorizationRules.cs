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

namespace Microsoft.Azure.Commands.NotificationHubs.Commands.Namespace
{
    using Microsoft.Azure.Commands.NotificationHubs.Models;
    using Microsoft.Azure.Management.NotificationHubs.Models;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Linq;

    [Cmdlet(VerbsCommon.Get, "AzureNotificationHubsNamespaceAuthorizationRules"), OutputType(typeof(List<SharedAccessAuthorizationRuleAttributes>))]
    public class GetAzureNotificationHubsNamespaceAuthorizationRules : AzureNotificationHubsCmdletBase
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
            HelpMessage = "Namespace AuthorizationRule Name.")]
        public string AuthorizationRuleName { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(ResourceGroupName) && !string.IsNullOrEmpty(NamespaceName))
            {
                if (!string.IsNullOrEmpty(AuthorizationRuleName))
                {
                    // Get a namespace AuthorizationRules
                    var authRule = Client.GetNamespaceAuthorizationRules(ResourceGroupName, NamespaceName, AuthorizationRuleName);
                    WriteObject(authRule);
                }
                else
                {
                    // Get all namespace AuthorizationRules
                    var authRuleList = Client.ListNamespaceAuthorizationRules(ResourceGroupName, NamespaceName);
                    WriteObject(authRuleList.ToList(), true);
                }
            }
        }
    }
}
