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
using Microsoft.Azure.Commands.ServiceBus.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.ServiceBus.Commands
{
    /// <summary>
    /// 'Remove-AzureRmServiceBusAuthorizationRule' Cmdlet removes/deletes AuthorizationRule
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, ServiceBusAuthorizationRuleVerb, DefaultParameterSetName = NamespaceAuthoRuleParameterSet, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureServiceBusAuthorizationRule : AzureServiceBusCmdletBase
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

        [Parameter(Mandatory = false,
            ValueFromPipeline = true,
            Position = 4,
            HelpMessage = "ServiceBus AuthorizationRule Object.")]        
        [ValidateNotNullOrEmpty]
        [Alias(AliasAuthRuleObj)]
        public SharedAccessAuthorizationRuleAttributes InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            // Delete Namespace authorizationRule
            if (ParameterSetName == NamespaceAuthoRuleParameterSet)
                ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.RemovingNamespaceAuthorizationRule, Name, Namespace),
                string.Format(Resources.RemoveNamespaceAuthorizationRule, Name, Namespace),
                Name,
                () =>
                {                                        
                    Client.DeleteNamespaceAuthorizationRules(ResourceGroupName, Namespace, Name);

                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });

            // Delete Queue authorizationRule
            if (ParameterSetName == QueueAuthoRuleParameterSet)
                ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.RemovingQueueAuthorizationRule, Namespace, Queue, Name),
                string.Format(Resources.RemoveQueueAuthorizationRule, Namespace, Queue, Name),
                Name,
                () =>
                {
                    Client.DeleteServiceBusQueueAuthorizationRules(ResourceGroupName, Namespace, Queue, Name);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });

            // Delete Topic authorizationRule
            if (ParameterSetName == TopicAuthoRuleParameterSet)
                ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.RemovingTopicAuthorizationRule, Namespace, Topic, Name),
                string.Format(Resources.RemoveTopicAuthorizationRule, Namespace, Topic, Name),
                Name,
                () =>
                {
                    Client.DeleteServiceBusTopicAuthorizationRule(ResourceGroupName, Namespace, Topic, Name);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}
