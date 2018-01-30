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

using Microsoft.Azure.Commands.EventHub.Models;
using Microsoft.Azure.Management.EventHub.Models;
using System.Management.Automation;
using System.Collections.Generic;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.EventHub.Commands
{
    /// <summary>
    /// 'Set-AzureRmEventHubAuthorizationRule' Cmdlet updates the specified AuthorizationRule
    /// </summary>
    [Cmdlet(VerbsCommon.Set, EventHubAuthorizationRuleVerb, DefaultParameterSetName = NamespaceAuthoRuleParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSSharedAccessAuthorizationRuleAttributes))]
    public class SetAzureEventhubAuthorizationRules : AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
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

        [Parameter(Mandatory = true, ParameterSetName = AuthoRuleInputObjectParameterSet, ValueFromPipeline = true, Position = 4, HelpMessage = "AuthorizationRule Object")]
        [Parameter(Mandatory = false, ParameterSetName = NamespaceAuthoRuleParameterSet, ValueFromPipeline = true, Position = 4, HelpMessage = "AuthorizationRule Object")]
        [Parameter(Mandatory = false, ParameterSetName = EventhubAuthoRuleParameterSet, ValueFromPipeline = true, Position = 4, HelpMessage = "AuthorizationRule Object")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasAuthRuleObj)]
        public PSSharedAccessAuthorizationRuleAttributes InputObject { get; set; }
        
        [Parameter(Mandatory = false, ParameterSetName = NamespaceAuthoRuleParameterSet, ValueFromPipelineByPropertyName = true, Position = 4, HelpMessage = "Rights, e.g.  @(\"Listen\",\"Send\",\"Manage\")")]
        [Parameter(Mandatory = false, ParameterSetName = EventhubAuthoRuleParameterSet, ValueFromPipelineByPropertyName = true, Position = 4, HelpMessage = "Rights, e.g.  @(\"Listen\",\"Send\",\"Manage\")")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Listen", "Send", "Manage", IgnoreCase = true)]
        public string[] Rights { get; set; }

        public override void ExecuteCmdlet()
        {
            PSSharedAccessAuthorizationRuleAttributes sasRule = new PSSharedAccessAuthorizationRuleAttributes();

            if (InputObject != null)
            {
                sasRule = InputObject;
            }
            else
            {
                sasRule.Rights = new List<string>();
                if (Rights != null && Rights.Length > 0)
                    foreach (string test in Rights)
                    {
                        sasRule.Rights.Add(test);
                    }
            }

            // InputObject Authorization Rule
            if (ParameterSetName.Equals(AuthoRuleInputObjectParameterSet))
                if (EventHub != null)
                {
                    if (ShouldProcess(target: sasRule.Name, action: string.Format(Resources.UpdateEventHubAuthorizationrule, Name, EventHub)))
                    {
                        WriteObject(Client.CreateOrUpdateEventHubAuthorizationRules(ResourceGroupName, Namespace, EventHub, Name, sasRule));
                    }
                }
                else
                {
                    if (ShouldProcess(target: sasRule.Name, action: string.Format(Resources.UpdateNamespaceAuthorizationrule, Name, Namespace)))
                    {
                        sasRule = InputObject;
                        WriteObject(Client.CreateOrUpdateNamespaceAuthorizationRules(ResourceGroupName, Namespace, Name, sasRule));
                    }
                }

            // update Namespace Authorization Rule
            if (ParameterSetName.Equals(NamespaceAuthoRuleParameterSet))
                if (ShouldProcess(target: sasRule.Name, action: string.Format(Resources.UpdateNamespaceAuthorizationrule, Name, Namespace)))
                {
                    WriteObject(Client.CreateOrUpdateNamespaceAuthorizationRules(ResourceGroupName, Namespace, Name, sasRule));
                }


            // Update EventHub authorizationRule
            if (ParameterSetName.Equals(EventhubAuthoRuleParameterSet))
                if (ShouldProcess(target: sasRule.Name, action: string.Format(Resources.UpdateEventHubAuthorizationrule, Name, EventHub)))
                {
                    WriteObject(Client.CreateOrUpdateEventHubAuthorizationRules(ResourceGroupName, Namespace, EventHub, Name, sasRule));
                }
        }
    }
}
