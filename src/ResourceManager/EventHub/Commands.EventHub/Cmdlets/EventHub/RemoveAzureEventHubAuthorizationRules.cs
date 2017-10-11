﻿// ----------------------------------------------------------------------------------
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

using System.Management.Automation;

namespace Microsoft.Azure.Commands.EventHub.Commands.EventHub
{
    /// <summary>
    /// 'Remove-AzureRmEventHubAuthorizationRule' Cmdlet removes/deletes AuthorizationRule
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, EventHubAuthorizationRuleVerb, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureEventHubAuthorizationRule : AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Resource Group Name.")]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Namespace Name.")]
        [ValidateNotNullOrEmpty]
        public string NamespaceName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "EventHub Name.")]
        [ValidateNotNullOrEmpty]
        public string EventHubName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "EventHub AuthorizationRule Name.")]
        [ValidateNotNullOrEmpty]
        public string AuthorizationRuleName { get; set; }

        public override void ExecuteCmdlet()
        {
            // Delete EventHub authorizationRule
            if (ShouldProcess(target: AuthorizationRuleName, action: string.Format("Deleting AtuhorizationRule:{0} from Eventhub:{1} of Namespace: {2}", AuthorizationRuleName, EventHubName, NamespaceName)))
            {
                WriteObject(Client.DeleteEventHubAuthorizationRules(ResourceGroupName, NamespaceName, EventHubName, AuthorizationRuleName));
            }            
        }
    }
}
