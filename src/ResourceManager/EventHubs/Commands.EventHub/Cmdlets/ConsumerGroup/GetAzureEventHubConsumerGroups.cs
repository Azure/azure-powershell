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

using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.EventHub.Models;

namespace Microsoft.Azure.Commands.EventHub.Cmdlets.ConsumerGroup
{

    [Cmdlet(VerbsCommon.Get, ConsumerGroupVerb), OutputType(typeof(List<ConsumerGroupAttributes>))]
    public class GetAzureRmEventHubConsumerGroup : AzureEventHubsCmdletBase
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
        public string Name { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "EventHub Name.")]
        public string EventHubName { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "ConsumerGroup Name.")]
        public string ConsumerGroupName { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(ConsumerGroupName))
            {
                // Get a ConsumnerGroup
                var consumerGroup = Client.GetConsumerGroup(ResourceGroupName, Name, EventHubName, ConsumerGroupName);
                WriteObject(consumerGroup);
            }
            else
            {
                // Get all ConsumnerGroups
                var consumerGropusList = Client.ListAllConsumerGroup(ResourceGroupName, Name, EventHubName);
                WriteObject(consumerGropusList.ToList(), true);
            }
        }
    }
}
