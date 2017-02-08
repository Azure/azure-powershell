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

using Microsoft.Azure.Commands.EventHub.Models;
using Microsoft.Azure.Management.EventHub.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.EventHub.Commands.EventHub
{
    /// <summary>
    /// 'New-AzureRmEventHub' Cmdlet creates a new EventHub
    /// </summary>
    [Cmdlet(VerbsCommon.New, EventHubVerb, SupportsShouldProcess = true), OutputType(typeof(EventHubAttributes))]
    public class NewAzureRmEventHub : AzureEventHubsCmdletBase
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

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "Namespace Location.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "Eventhub Name.")]
        [ValidateNotNullOrEmpty]
        public string EventHubName { get; set; }

        [Parameter(Mandatory = false,
           ValueFromPipelineByPropertyName = true,           
           HelpMessage = "EventHub object.")]
        [ValidateNotNullOrEmpty]
        public EventHubAttributes EventHubObj { get; set; }

        [Parameter(Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Eventhub Message Retention In Days.")]
        [ValidateNotNullOrEmpty]
        public long? MessageRetentionInDays { get; set; }

        [Parameter(Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Eventhub PartitionCount.")]
        [ValidateNotNullOrEmpty]
        public long? PartitionCount { get; set; }

        public override void ExecuteCmdlet()
        {
            EventHubAttributes eventHub = new EventHubAttributes();

            if (EventHubObj != null)
            {
                eventHub = EventHubObj;
            }
            else
            {
                if (!string.IsNullOrEmpty(EventHubName))
                    eventHub.Name = EventHubName;

                if (MessageRetentionInDays.HasValue)
                    eventHub.MessageRetentionInDays = MessageRetentionInDays;

                if (PartitionCount.HasValue)
                    eventHub.PartitionCount = PartitionCount;

                eventHub.Location = Location;       
            }

            if(ShouldProcess(target:eventHub.Name, action:string.Format("Creating new EventHub:{0} under NameSpace:{1} ",eventHub.Name,NamespaceName)))
            {
                WriteObject(Client.CreateOrUpdateEventHub(ResourceGroupName, NamespaceName, eventHub.Name, eventHub));
            }
                        
        }
    }
}
