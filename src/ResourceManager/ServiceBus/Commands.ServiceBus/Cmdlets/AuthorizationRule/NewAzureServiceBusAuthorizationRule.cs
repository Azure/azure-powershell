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
using Microsoft.Azure.Commands.ServiceBus.Models;
using System.Collections.Generic;
using Microsoft.Azure.Management.ServiceBus.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.ServiceBus.Commands
{
    /// <summary>
    /// 'New-AzureRmServiceBusAuthorizationRule' Cmdlet creates a new AuthorizationRule
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ServiceBusAuthorizationRule", DefaultParameterSetName = NamespaceAuthoRuleParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSSharedAccessAuthorizationRuleAttributes))]
    public class NewAzureServiceBusAuthorizationRule : AzureServiceBusCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NamespaceAuthoRuleParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [Parameter(Mandatory = true, ParameterSetName = QueueAuthoRuleParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [Parameter(Mandatory = true, ParameterSetName = TopicAuthoRuleParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = QueueAuthoRuleParameterSet, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "Queue Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasQueueName)]
        public string Queue { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = TopicAuthoRuleParameterSet, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "Topic Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasTopicName)]
        public string Topic { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 3, HelpMessage = "AuthorizationRule Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasAuthorizationRuleName)]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Rights, e.g.  \"Listen\",\"Send\",\"Manage\"")]
        [ValidateSet("Listen","Send","Manage", IgnoreCase = true)]
        public string[] Rights { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                PSSharedAccessAuthorizationRuleAttributes sasRule = new PSSharedAccessAuthorizationRuleAttributes();
                sasRule.Rights = new List<AccessRights?>();

                foreach (string test in Rights)
                {
                    sasRule.Rights.Add(ParseAccessRights(test));
                }

                //Create a new Namespace Authorization Rule
                if (ParameterSetName.Equals(NamespaceAuthoRuleParameterSet))
                {
                    if (ShouldProcess(target: sasRule.Name, action: string.Format(Resources.CreateNamespaceAuthorizationrule, Name, Namespace)))
                    {
                        WriteObject(Client.CreateOrUpdateNamespaceAuthorizationRules(ResourceGroupName, Namespace, Name, sasRule));
                    }
                }

                // Create a new Queue authorizationRule
                if (ParameterSetName.Equals(QueueAuthoRuleParameterSet))
                {
                    if (ShouldProcess(target: sasRule.Name, action: string.Format(Resources.CreateQueueAuthorizationrule, Name, Queue)))
                    {
                        WriteObject(Client.CreateOrUpdateServiceBusQueueAuthorizationRules(ResourceGroupName, Namespace, Queue, Name, sasRule));
                    }
                }

                // Create a new Topic authorizationRule
                if (ParameterSetName.Equals(TopicAuthoRuleParameterSet))
                {
                    if (ShouldProcess(target: sasRule.Name, action: string.Format(Resources.CreateTopicAuthorizationrule, Name, Topic)))
                    {
                        WriteObject(Client.CreateOrUpdateServiceBusTopicAuthorizationRules(ResourceGroupName, Namespace, Topic, Name, sasRule));
                    }
                }
            }
            catch (ErrorResponseException ex)
            {
                WriteError(ServiceBusClient.WriteErrorforBadrequest(ex));
            }

        }
    }
}
