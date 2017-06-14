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

using Microsoft.Azure.Commands.ServiceBus.Models;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ServiceBus.Commands.Topic
{
    /// <summary>
    /// 'Get-AzureRmServiceBusTopic' Cmdlet gives the details of a / List of ServiceBus Topic(s)
    /// <para> If ServiceBus Topic name provided, a single ServiceBus Topic detials will be returned</para>
    /// <para> If ServiceBus Topic name not provided, list of ServiceBus Topic will be returned</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, ServicebusTopicVerb), OutputType(typeof(TopicAttributes))]
    public class GetAzureRmServiceBusTopic : AzureServiceBusCmdletBase
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

        [Parameter(Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           Position = 1,
           HelpMessage = "Topic Name.")]
        [ValidateNotNullOrEmpty]
        public string TopicName { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(TopicName))
            {
                TopicAttributes topicAttributes = Client.GetTopic(ResourceGroup, NamespaceName, TopicName);
                WriteObject(topicAttributes);
            }
            else
            {
               IEnumerable<TopicAttributes> topicAttributes = Client.ListTopics(ResourceGroup, NamespaceName);
               WriteObject(topicAttributes);
            }

            
        }
    }
}
