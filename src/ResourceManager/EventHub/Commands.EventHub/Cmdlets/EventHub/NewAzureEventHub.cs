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
using System;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

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
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Namespace Name.")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Namespace { get; set; }        

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "Eventhub Name.")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasEventHubName)]
        public string Name { get; set; }

        [Parameter(Mandatory = false,
           ParameterSetName = EventhubInputObjectParameterSet,
           ValueFromPipelineByPropertyName = true,           
           HelpMessage = "EventHub Input object.")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasEventHubObj)]
        public EventHubAttributes InputObject { get; set; }

        [Parameter(Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           ParameterSetName = EventhubPropertiesParameterSet,
           HelpMessage = "Eventhub Message Retention In Days.")]
        [ValidateNotNullOrEmpty]
        public long? MessageRetentionInDays { get; set; }

        [Parameter(Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           ParameterSetName = EventhubPropertiesParameterSet,
           HelpMessage = "Eventhub PartitionCount.")]
        [ValidateNotNullOrEmpty]
        public long? PartitionCount { get; set; }       


        public override void ExecuteCmdlet()
        {
            EventHubAttributes eventHub = new EventHubAttributes();

            if (InputObject != null)
            {
                eventHub = InputObject;
            }
            else
            {
                if (!string.IsNullOrEmpty(Name))
                    eventHub.Name = Name;

                if (MessageRetentionInDays.HasValue)
                    eventHub.MessageRetentionInDays = MessageRetentionInDays;

                if (PartitionCount.HasValue)
                    eventHub.PartitionCount = PartitionCount;     
            }

            if(ShouldProcess(target:eventHub.Name, action:string.Format(Resources.CreateEventHub,eventHub.Name,Namespace)))
            {
                WriteObject(Client.CreateOrUpdateEventHub(ResourceGroupName, Namespace, eventHub.Name, eventHub));
            }
                        
        }
    }
}
