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

using System.Management.Automation;
using System.Collections.Generic;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.EventHub.Models;
using System;

namespace Microsoft.Azure.Commands.EventHub.Commands
{
    /// <summary>
    /// 'New-AzRelayAuthorizationRule' Cmdlet creates a new AuthorizationRule
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventHubAuthorizationRule", DefaultParameterSetName = NamespaceAuthoRuleParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSSharedAccessAuthorizationRuleAttributes))]
    public class NewAzureEventhubAuthorizationRules : AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NamespaceAuthoRuleParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [Parameter(Mandatory = true, ParameterSetName = EventhubAuthoRuleParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = EventhubAuthoRuleParameterSet, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "EventHub Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasEventHubName)]
        public string EventHub { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 3, HelpMessage = "AuthorizationRule Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasAuthorizationRuleName)]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Rights, e.g.  \"" + Manage + "\",\"" + Send + "\",\"" + Listen + "\"")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Listen", "Send", "Manage", IgnoreCase = true)]
        public string[] Rights { get; set; }

        public override void ExecuteCmdlet()
        {
            PSSharedAccessAuthorizationRuleAttributes sasRule = new PSSharedAccessAuthorizationRuleAttributes();
            sasRule.Rights = new List<string>();

            if (Array.Exists(Rights, element => element.Equals(Manage) && (!Array.Exists(Rights, element1 => element1.Equals(Listen)) || !Array.Exists(Rights, element1 => element1.Equals(Send)))))
            {
                Exception exManage = new Exception("Assigning '" + Manage + "' to rights requires '" + Listen + "' and '" + Send + "' to be included with. e.g. @(\"" + Manage + "\",\"" + Listen + "\",\"" + Send + "\")");
                throw exManage;
            }

            foreach (string right in Rights)
            {
                sasRule.Rights.Add(right);
            }

            try
            {
                //Create a new Namespace Authorization Rule
                if (ParameterSetName.Equals(NamespaceAuthoRuleParameterSet))
                    if (ShouldProcess(target: sasRule.Name, action: string.Format(Resources.CreateNamespaceAuthorizationrule, Name, Namespace)))
                    {
                        WriteObject(Client.CreateOrUpdateNamespaceAuthorizationRules(ResourceGroupName, Namespace, Name, sasRule));
                    }

                // Create a new EventHub authorizationRule
                if (ParameterSetName.Equals(EventhubAuthoRuleParameterSet))
                    if (ShouldProcess(target: sasRule.Name, action: string.Format(Resources.CreateEventHubAuthorizationrule, Name, EventHub)))
                    {
                        WriteObject(Client.CreateOrUpdateEventHubAuthorizationRules(ResourceGroupName, Namespace, EventHub, Name, sasRule));
                    }
                
            }
            catch (Management.EventHub.Models.ErrorResponseException ex)
            {
                WriteError(Eventhub.EventHubsClient.WriteErrorforBadrequest(ex));
            }
            catch (Exception ex)
            {
                WriteError(new ErrorRecord(ex, ex.Message, ErrorCategory.OpenError, ex));
            }
        }
    }
}
