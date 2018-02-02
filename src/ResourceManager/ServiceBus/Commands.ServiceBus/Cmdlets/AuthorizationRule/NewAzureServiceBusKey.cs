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

using Microsoft.Azure.Management.ServiceBus.Models;
using Microsoft.Azure.Commands.ServiceBus.Models;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.ServiceBus.Commands
{
    /// <summary>
    /// 'New-AzureRmServiceBusKey' Cmdlet creates a new specified (PrimaryKey / SecondaryKey) key for the given WcfRelay Authorization Rule
    /// </summary>
    [Cmdlet(VerbsCommon.New, ServiceBusKeyVerb, DefaultParameterSetName = NamespaceAuthoRuleParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSListKeysAttributes))]
    public class NewAzureServiceBusKey : AzureServiceBusCmdletBase
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

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 3, HelpMessage = "AuthorizationRule Name.")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasAuthorizationRuleName)]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Regenerate Keys - 'PrimaryKey'/'SecondaryKey'.")]
        [ValidateSet(RegeneKeys.PrimaryKey, RegeneKeys.SecondaryKey, IgnoreCase = true)]      
        public string RegenerateKey { get; set; }

        public override void ExecuteCmdlet()
        {            
            // Generate new Namespace List Keys for the specified AuthorizationRule
            if (ParameterSetName.Equals(NamespaceAuthoRuleParameterSet))
            {
                if (ShouldProcess(target: RegenerateKey, action: string.Format(Resources.RegenerateKeyNamesapce, Name, Namespace)))
                {
                    WriteObject(Client.SetRegenerateKeys(ResourceGroupName, Namespace, Name, RegenerateKey));
                }
            }

            // Generate new Queue List Keys for the specified AuthorizationRule
            if (ParameterSetName.Equals(QueueAuthoRuleParameterSet))
            {
                if (ShouldProcess(target: RegenerateKey, action: string.Format(Resources.RegenerateKeyQueue, Name, Queue)))
                {
                    WriteObject(Client.NewQueueKey(ResourceGroupName, Namespace, Queue, Name, RegenerateKey));
                }
            }

            // Generate new Topic List Keys for the specified AuthorizationRule
            if (ParameterSetName.Equals(TopicAuthoRuleParameterSet))
            {
                if (ShouldProcess(target: RegenerateKey, action: string.Format(Resources.RegenerateKeyTopic, Name, Topic)))
                {
                    WriteObject(Client.NewTopicKey(ResourceGroupName, Namespace, Topic, Name, RegenerateKey));
                }
            }
        }
    }
}
