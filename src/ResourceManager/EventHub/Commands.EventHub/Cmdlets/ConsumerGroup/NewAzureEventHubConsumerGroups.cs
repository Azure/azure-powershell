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
using Microsoft.Azure.Commands.EventHub.Models;

namespace Microsoft.Azure.Commands.EventHub.Commands.ConsumerGroup
{
    /// <summary>
    /// 'New-AzureRmEventHubConsumerGroup' Cmdlet creates a new Cosumer Group for Specified Eventhub
    /// </summary>
    [Cmdlet(VerbsCommon.New, ConsumerGroupVerb, SupportsShouldProcess = true), OutputType(typeof(ConsumerGroupAttributes))]
    public class NewEventHubConsumerGroup : AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Resource Group Name.")]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Namespace Name.")]
        [ValidateNotNullOrEmpty]
        public string NamespaceName { get; set; }

        [Parameter(Mandatory = true,
             ValueFromPipelineByPropertyName = true,
             Position = 2,
             HelpMessage = "EventHub Name.")]
        [ValidateNotNullOrEmpty]
        public string EventHubName { get; set; }

        [Parameter(Mandatory = true,
             ValueFromPipelineByPropertyName = true,
             Position = 3,
             HelpMessage = "ConsumerGroup Name.")]
        [ValidateNotNullOrEmpty]
        public string ConsumerGroupName { get; set; }

        [Parameter(Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             Position = 4,
             HelpMessage = " User Metadata for ConsumerGroup")]
        [ValidateNotNullOrEmpty]
        public string UserMetadata { get; set; }
        
        public override void ExecuteCmdlet()
        {
            ConsumerGroupAttributes consumerGroup = new ConsumerGroupAttributes();

            consumerGroup.Name = ConsumerGroupName;
            var getnamespace = Client.GetNamespace(ResourceGroupName, NamespaceName);
            consumerGroup.Location = getnamespace.Location;

            if (!string.IsNullOrEmpty(UserMetadata))
                consumerGroup.UserMetadata = UserMetadata;

            if (ShouldProcess(target: consumerGroup.Name, action: string.Format("Adding a new Consumer Group {0} under Eventhub {1}", consumerGroup.Name, EventHubName)))
            {
                WriteObject(Client.CreateOrUpdateConsumerGroup(ResourceGroupName, NamespaceName, EventHubName, consumerGroup.Name, consumerGroup));
            }
            
        }
    }
}
