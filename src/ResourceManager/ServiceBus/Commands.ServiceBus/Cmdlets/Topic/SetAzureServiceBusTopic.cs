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
using Microsoft.Azure.Management.ServiceBus.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ServiceBus.Commands.Topic
{
    /// <summary>
    /// 'Set-AzureRmServiceBusTopic' Cmdlet updates the specified ServiceBus Topic
    /// </summary>
    [Cmdlet(VerbsCommon.Set, ServicebusTopicVerb, SupportsShouldProcess = true), OutputType(typeof(PSTopicAttributes))]
    public class SetAzureRmServiceBusTopic : AzureServiceBusCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "The name of the resource group")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Alias(AliasResourceGroup)]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "Topic Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasTopicName)]
        public string Name { get; set; }
        
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 3, HelpMessage = "ServiceBus Topic definition")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasTopicObj)]
        public PSTopicAttributes InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            PSTopicAttributes topicAttributes = new PSTopicAttributes();
            if (InputObject != null)
            {
                topicAttributes = InputObject;
            }            
            
            if (ShouldProcess(target: Name, action: string.Format(Resources.UpdateTopic, Name, Namespace)))
            {
                WriteObject(Client.CreateUpdateTopic(ResourceGroupName, Namespace, topicAttributes.Name, topicAttributes));
            }
        }
    }
}
