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
    /// 'Set-AzureRmRelayAuthorizationRule' Cmdlet updates the specified AuthorizationRule
    /// </summary>
    [Cmdlet(VerbsCommon.Set, EventHubAuthorizationRuleVerb, DefaultParameterSetName = NamespaceAuthoRuleParameterSet, SupportsShouldProcess = true), OutputType(typeof(SharedAccessAuthorizationRuleAttributes))]
    public class SetAzureEventhubAuthorizationRules : AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1, ParameterSetName = NamespaceAuthoRuleParameterSet,
            HelpMessage = "Namespace Name.")]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = EventhubAuthoRuleParameterSet)]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2, ParameterSetName = EventhubAuthoRuleParameterSet,
            HelpMessage = "EventHub Name.")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasEventHubName)]
        public string EventHub { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "AuthorizationRule Name.")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasAuthorizationRuleName)]
        public string Name { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            Position = 4,
            ParameterSetName = AuthoRuleInputObjectParameterSet,
            HelpMessage = "Relay AuthorizationRule Object.")]
        [Parameter(Mandatory = false,
            ValueFromPipeline = true,
            Position = 4,
            ParameterSetName = NamespaceAuthoRuleParameterSet,
            HelpMessage = "Relay AuthorizationRule Object.")]
        [Parameter(Mandatory = false,
            ValueFromPipeline = true,
            Position = 4,
            ParameterSetName = EventhubAuthoRuleParameterSet,
            HelpMessage = "Relay AuthorizationRule Object.")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasAuthRuleObj)]
        public SharedAccessAuthorizationRuleAttributes InputObject { get; set; }

        [Parameter(Mandatory = true,
            Position = 4,
            ParameterSetName = AuthoRulePropertiesParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Rights, e.g.  @(\"Listen\",\"Send\",\"Manage\")")]
        [Parameter(Mandatory = false,
            Position = 4,
            ParameterSetName = NamespaceAuthoRuleParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Rights, e.g.  @(\"Listen\",\"Send\",\"Manage\")")]
        [Parameter(Mandatory = false,
            Position = 4,
            ParameterSetName = EventhubAuthoRuleParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Rights, e.g.  @(\"Listen\",\"Send\",\"Manage\")")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Listen", "Send", "Manage",
            IgnoreCase = true)]
        public string[] Rights { get; set; }

        public override void ExecuteCmdlet()
        {
            SharedAccessAuthorizationRuleAttributes sasRule = new SharedAccessAuthorizationRuleAttributes();

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

            // update Namespace Authorization Rule
            if (ParameterSetName == NamespaceAuthoRuleParameterSet)
                if (ShouldProcess(target: sasRule.Name, action: string.Format(Resources.UpdateNamespaceAuthorizationrule, Name, Namespace)))
                {
                    WriteObject(Client.CreateOrUpdateNamespaceAuthorizationRules(ResourceGroupName, Namespace, Name, sasRule));
                }


            // Update WcfRelay authorizationRule
            if (ParameterSetName == EventhubAuthoRuleParameterSet)
                if (ShouldProcess(target: sasRule.Name, action: string.Format(Resources.UpdateEventHubAuthorizationrule, Name, EventHub)))
                {
                    WriteObject(Client.CreateOrUpdateEventHubAuthorizationRules(ResourceGroupName, Namespace, EventHub, Name, sasRule));
                }
        }
    }
}
