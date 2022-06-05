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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.EventHub.Commands.EventHub
{
    /// <summary>
    /// 'Set-AzEventHub' Cmdlet updates the specified EventHub
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventHub", SupportsShouldProcess = true), OutputType(typeof(PSEventHubAttributes))]
    public class SetAzureEventHub : AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "EventHub Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasEventHubName)]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = EventhubInputObjectParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "EventHub object")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasEventHubObj)]
        public PSEventHubAttributes InputObject { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = EventhubPropertiesParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Eventhub Message Retention In Days")]
        [ValidateNotNullOrEmpty]
        public long? messageRetentionInDays { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = EventhubPropertiesParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Eventhub PartitionCount")]
        [ValidateNotNullOrEmpty]
        public long? partitionCount { get; set; }
        
        public override void ExecuteCmdlet()
        {
            PSEventHubAttributes eventHub = new PSEventHubAttributes();
            
            if (InputObject != null)
            {
                eventHub = InputObject;
            }
            else
            {
                if (string.IsNullOrEmpty(Name))
                    eventHub.Name = Name;

                if (messageRetentionInDays.HasValue)
                    eventHub.MessageRetentionInDays = messageRetentionInDays;

                if (partitionCount.HasValue)
                    eventHub.PartitionCount = partitionCount;                
            }
          

            if (ShouldProcess(target:Name, action: string.Format(Resources.UpdateEventHub,Name,Namespace)))
            {
                try
                {
                    WriteObject(Client.CreateOrUpdateEventHub(ResourceGroupName, Namespace, Name, eventHub));
                }
                catch (Management.EventHub.Models.ErrorResponseException ex)
                {
                    WriteError(Eventhub.EventHubsClient.WriteErrorforBadrequest(ex));
                }
            }
        }
    }
}
