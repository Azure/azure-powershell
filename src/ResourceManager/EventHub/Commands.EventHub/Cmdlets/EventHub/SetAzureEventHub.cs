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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.EventHub.Commands.EventHub
{
    /// <summary>
    /// 'Set-AzureRmEventHub' Cmdlet updates the specified EventHub
    /// </summary>
    [Cmdlet(VerbsCommon.Set, EventHubVerb, SupportsShouldProcess = true), OutputType(typeof(EventHubAttributes))]
    public class SetAzureEventHub : AzureEventHubsCmdletBase
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
            HelpMessage = "Namespace Name.")]
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
        public long? messageRetentionInDays { get; set; }

        [Parameter(Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Eventhub PartitionCount.")]
        [ValidateNotNullOrEmpty]
        public long? partitionCount { get; set; }


        public override void ExecuteCmdlet()
        {
            EventHubAttributes eventHub = null;
            
            if (EventHubObj != null)
            {
                eventHub = EventHubObj;
            }
            else
            {
                if (string.IsNullOrEmpty(EventHubName))
                    eventHub.Name = EventHubName;

                if (messageRetentionInDays.HasValue)
                    eventHub.MessageRetentionInDays = messageRetentionInDays;

                if (partitionCount.HasValue)
                    eventHub.PartitionCount = partitionCount;
            }

            eventHub.Location = Client.GetNamespace(ResourceGroupName, NamespaceName).Location;

            if (ShouldProcess(target:EventHubName, action: string.Format("Updating EventHub:{0} of NameSpace:{1}",EventHubName,NamespaceName)))
            {
                WriteObject(Client.CreateOrUpdateEventHub(ResourceGroupName, NamespaceName, eventHub.Name, eventHub));
            }
        }
    }
}
