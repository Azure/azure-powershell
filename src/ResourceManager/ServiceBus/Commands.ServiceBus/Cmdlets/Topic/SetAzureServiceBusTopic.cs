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

namespace Microsoft.Azure.Commands.ServiceBus.Commands.Topic
{
    /// <summary>
    /// 'Set-AzureRmServiceBusTopic' Cmdlet updates the specified ServiceBus Topic
    /// </summary>
    [Cmdlet(VerbsCommon.Set, ServicebusTopicVerb, SupportsShouldProcess = true), OutputType(typeof(TopicAttributes))]
    public class SetAzureRmServiceBusTopic : AzureServiceBusCmdletBase
    {
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The name of the resource group")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroup { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Namespace Name.")]
        [ValidateNotNullOrEmpty]
        public string NamespaceName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Topic Name.")]
        [ValidateNotNullOrEmpty]
        public string TopicName { get; set; }
        
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "ServiceBus Topic definition.")]
        [ValidateNotNullOrEmpty]
        public TopicAttributes TopicObj { get; set; }

        public override void ExecuteCmdlet()
        {
            TopicAttributes topicAttributes = new TopicAttributes();
            if (TopicObj != null)
            {
                topicAttributes = TopicObj;
            }
            else
            {
                //topicAttributes = TopicObj;
            }
            
            if (ShouldProcess(target: TopicName, action: string.Format("Update Topic:{0} of NameSpace:{1}",TopicName,NamespaceName)))
            {
                WriteObject(Client.CreateUpdateTopic(ResourceGroup, NamespaceName, topicAttributes.Name, topicAttributes));
            }
        }
    }
}
