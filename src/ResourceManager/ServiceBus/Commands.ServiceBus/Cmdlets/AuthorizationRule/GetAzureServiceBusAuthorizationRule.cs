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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ServiceBus.Models;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ServiceBus.Commands
{
    /// <summary>
    /// 'Get-AzureRmServiceBusAuthorizationRule' Cmdlet gives the details of a / List of AuthorizationRule(s)
    /// <para> If AuthorizationRule name provided, a single AuthorizationRule detials will be returned</para>
    /// <para> If AuthorizationRule name not provided, list of AuthorizationRules will be returned</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, ServiceBusAuthorizationRuleVerb, DefaultParameterSetName = NamespaceAuthoRuleParameterSet), OutputType(typeof(List<PSSharedAccessAuthorizationRuleAttributes>))]
    public class GetAzureServiceBusAuthorizationRule : AzureServiceBusCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]        
         public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
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

        [Parameter(Mandatory = true, ParameterSetName = AliasAuthoRuleParameterSet, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = " GeoDR Configuration Name")]
        [ValidateNotNullOrEmpty]
        public string AliasName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, Position = 3, HelpMessage = "AuthorizationRule Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasAuthorizationRuleName)]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {

            //Get Namespace Authorization Rule
            if (ParameterSetName.Equals(NamespaceAuthoRuleParameterSet))
                if (!string.IsNullOrEmpty(Name))
                {
                    // Get a Namespace AuthorizationRule
                    PSSharedAccessAuthorizationRuleAttributes authRule = Client.GetNamespaceAuthorizationRules(ResourceGroupName, Namespace, Name);
                    WriteObject(authRule);
                }
                else
                {
                    // Get all Namespace AuthorizationRules
                    IEnumerable<PSSharedAccessAuthorizationRuleAttributes> authRuleList = Client.ListNamespaceAuthorizationRules(ResourceGroupName, Namespace);
                    WriteObject(authRuleList, true);
                }


            // Get Queue authorizationRule
            if (ParameterSetName.Equals(QueueAuthoRuleParameterSet))
                    if (!string.IsNullOrEmpty(Name))
                    {
                    // Get a Queue AuthorizationRule
                    PSSharedAccessAuthorizationRuleAttributes authRule = Client.GetServiceBusQueueAuthorizationRules(ResourceGroupName, Namespace, Queue, Name);
                        WriteObject(authRule);
                    }
                    else
                    {
                    // Get all Queue AuthorizationRules
                    IEnumerable<PSSharedAccessAuthorizationRuleAttributes> authRuleList = Client.ListServiceBusQueueAuthorizationRules(ResourceGroupName, Namespace, Queue);
                        WriteObject(authRuleList, true);
                    }

            // Get Topic authorizationRule
            if (ParameterSetName.Equals(TopicAuthoRuleParameterSet))
                if (!string.IsNullOrEmpty(Name))
                {
                    // Get a Topic AuthorizationRule
                    PSSharedAccessAuthorizationRuleAttributes authRule = Client.GetServiceBusTopicAuthorizationRules(ResourceGroupName, Namespace, Topic, Name);
                    WriteObject(authRule);
                }
                else
                {
                    // Get all Topic AuthorizationRules
                    IEnumerable<PSSharedAccessAuthorizationRuleAttributes> authRuleList = Client.ListServiceBusTopicAuthorizationRules(ResourceGroupName, Namespace, Topic);
                    WriteObject(authRuleList, true);
                }

            // Get Alias authorizationRule
            if (ParameterSetName.Equals(AliasAuthoRuleParameterSet))
                if (!string.IsNullOrEmpty(Name))
                {
                    // Get a Topic AuthorizationRule
                    PSSharedAccessAuthorizationRuleAttributes authRule = Client.GetAliasAuthorizationRules(ResourceGroupName, Namespace, AliasName, Name);
                    WriteObject(authRule);
                }
                else
                {
                    // Get all Topic AuthorizationRules
                    IEnumerable<PSSharedAccessAuthorizationRuleAttributes> authRuleList = Client.ListAliasAuthorizationRules(ResourceGroupName, Namespace, AliasName);
                    WriteObject(authRuleList, true);
                }

        }
    }
}
