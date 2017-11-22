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
    [Cmdlet(VerbsCommon.Get, ServiceBusAuthorizationRuleVerb, DefaultParameterSetName = NamespaceAuthoRuleParameterSet), OutputType(typeof(List<SharedAccessAuthorizationRuleAttributes>))]
    public class GetAzureServiceBusAuthorizationRule : AzureServiceBusCmdletBase
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

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "AuthorizationRule Name.")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasAuthorizationRuleName)]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {

            //Get Namespace Authorization Rule
            if (ParameterSetName == NamespaceAuthoRuleParameterSet)
                if (!string.IsNullOrEmpty(Name))
                {
                    // Get a Namespace AuthorizationRule
                    SharedAccessAuthorizationRuleAttributes authRule = Client.GetNamespaceAuthorizationRules(ResourceGroupName, Namespace, Name);
                    WriteObject(authRule);
                }
                else
                {
                    // Get all Namespace AuthorizationRules
                    IEnumerable<SharedAccessAuthorizationRuleAttributes> authRuleList = Client.ListNamespaceAuthorizationRules(ResourceGroupName, Namespace);
                    WriteObject(authRuleList, true);
                }


            // Get Queue authorizationRule
            if (ParameterSetName == QueueAuthoRuleParameterSet)
                    if (!string.IsNullOrEmpty(Name))
                    {
                    // Get a Queue AuthorizationRule
                    SharedAccessAuthorizationRuleAttributes authRule = Client.GetServiceBusQueueAuthorizationRules(ResourceGroupName, Namespace, Queue, Name);
                        WriteObject(authRule);
                    }
                    else
                    {
                    // Get all Queue AuthorizationRules
                    IEnumerable<SharedAccessAuthorizationRuleAttributes> authRuleList = Client.ListServiceBusQueueAuthorizationRules(ResourceGroupName, Namespace, Queue);
                        WriteObject(authRuleList, true);
                    }

            // Get Topic authorizationRule
            if (ParameterSetName == TopicAuthoRuleParameterSet)
                if (!string.IsNullOrEmpty(Name))
                {
                    // Get a Topic AuthorizationRule
                    SharedAccessAuthorizationRuleAttributes authRule = Client.GetServiceBusTopicAuthorizationRules(ResourceGroupName, Namespace, Topic, Name);
                    WriteObject(authRule);
                }
                else
                {
                    // Get all Topic AuthorizationRules
                    IEnumerable<SharedAccessAuthorizationRuleAttributes> authRuleList = Client.ListServiceBusTopicAuthorizationRules(ResourceGroupName, Namespace, Topic);
                    WriteObject(authRuleList, true);
                }
            
        }
    }
}
