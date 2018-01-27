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

using Microsoft.Azure.Commands.ServiceBus.Models;
using Microsoft.Azure.Management.ServiceBus.Models;
using System.Management.Automation;
using System.Collections.Generic;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.ServiceBus.Commands
{
    /// <summary>
    /// 'Set-AzureRmServiceBusAuthorizationRule' Cmdlet updates the specified AuthorizationRule
    /// </summary>
    [Cmdlet(VerbsCommon.Set, ServiceBusAuthorizationRuleVerb, DefaultParameterSetName = NamespaceAuthoRuleParameterSet, SupportsShouldProcess = true), OutputType(typeof(SharedAccessAuthorizationRuleAttributes))]
    public class SetAzureServiceBusAuthorizationRule : AzureServiceBusCmdletBase
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
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 1, ParameterSetName = QueueAuthoRuleParameterSet)]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 1, ParameterSetName = TopicAuthoRuleParameterSet)]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2, ParameterSetName = QueueAuthoRuleParameterSet,
            HelpMessage = "Queue Name.")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasQueueName)]
        public string Queue { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2, ParameterSetName = TopicAuthoRuleParameterSet,
            HelpMessage = "Topic Name.")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasTopicName)]
        public string Topic { get; set; }

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
            HelpMessage = "ServiceBus AuthorizationRule Object.")]
        [Parameter(Mandatory = false,
            ValueFromPipeline = true,
            Position = 4,
            ParameterSetName = NamespaceAuthoRuleParameterSet,
            HelpMessage = "ServiceBus AuthorizationRule Object.")]
        [Parameter(Mandatory = false,
            ValueFromPipeline = true,
            Position = 4,
            ParameterSetName = QueueAuthoRuleParameterSet,
            HelpMessage = "ServiceBus AuthorizationRule Object.")]
        [Parameter(Mandatory = false,
            ValueFromPipeline = true,
            Position = 4,
            ParameterSetName = TopicAuthoRuleParameterSet,
            HelpMessage = "ServiceBus AuthorizationRule Object.")]
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
            ParameterSetName = QueueAuthoRuleParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Rights, e.g.  @(\"Listen\",\"Send\",\"Manage\")")]
        [Parameter(Mandatory = false,
            Position = 4,
            ParameterSetName = TopicAuthoRuleParameterSet,
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
                sasRule.Rights = new List<AccessRights?>();
                if (Rights != null && Rights.Length > 0)
                    foreach (string test in Rights)
                    {
                        sasRule.Rights.Add(ParseAccessRights(test));
                    }
            }

            // update Namespace Authorization Rule
            if (ParameterSetName == NamespaceAuthoRuleParameterSet)
            {
                if (ShouldProcess(target: sasRule.Name, action: string.Format(Resources.UpdateNamespaceAuthorizationrule, Name, Namespace)))
                {
                    WriteObject(Client.CreateOrUpdateNamespaceAuthorizationRules(ResourceGroupName, Namespace, Name, sasRule));
                }
            }


            // Update Topic authorizationRule
            if (ParameterSetName == QueueAuthoRuleParameterSet)
            {
                if (ShouldProcess(target: sasRule.Name, action: string.Format(Resources.UpdateQueueAuthorizationrule, Name, Queue)))
                {
                    WriteObject(Client.CreateOrUpdateServiceBusQueueAuthorizationRules(ResourceGroupName, Namespace, Queue, Name, sasRule));
                }
            }

            // Update Topic authorizationRule
            if (ParameterSetName == TopicAuthoRuleParameterSet)
            {
                if (ShouldProcess(target: sasRule.Name, action: string.Format(Resources.UpdateTopicAuthorizationrule, Name, Topic)))
                {
                    WriteObject(Client.CreateOrUpdateServiceBusTopicAuthorizationRules(ResourceGroupName, Namespace, Topic, Name, sasRule));
                }
            }

        }
    }
}
