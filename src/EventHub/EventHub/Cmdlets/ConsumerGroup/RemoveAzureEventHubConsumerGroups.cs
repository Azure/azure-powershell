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
using System.Management.Automation;
using Microsoft.Azure.Commands.EventHub.Models;

namespace Microsoft.Azure.Commands.EventHub.Commands.ConsumerGroup
{
    /// <summary>
    /// 'Remove-AzEventHubConsumerGroup' deletes the specified Consumer Group
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventHubConsumerGroup", DefaultParameterSetName = ConsumergroupPropertiesParameterSet, SupportsShouldProcess = true), OutputType(typeof(void))]
    public class RemoveAzureRmEventHubConsumerGroupp : AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = ConsumergroupPropertiesParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ConsumergroupPropertiesParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ConsumergroupPropertiesParameterSet, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "EventHub Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasEventHubName)]
        public string EventHub { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ConsumergroupPropertiesParameterSet, ValueFromPipelineByPropertyName = true, Position = 3, HelpMessage = "ConsumerGroup Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasConsumerGroupName)]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ConsumergroupInputObjectParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "ConsumerGroup Object")]
        [ValidateNotNullOrEmpty]
        public PSConsumerGroupAttributes InputObject { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ConsumergroupResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "ConsumerGroup Resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {

            if (ParameterSetName.Equals(ConsumergroupInputObjectParameterSet))
            {
                LocalResourceIdentifier identifier = new LocalResourceIdentifier(InputObject.Id);

                ResourceGroupName = identifier.ResourceGroupName;
                Namespace = identifier.ParentResource;
                EventHub = identifier.ParentResource1;
                Name = identifier.ResourceName;
            }
            else if (ParameterSetName.Equals(ConsumergroupResourceIdParameterSet))
            {
                LocalResourceIdentifier identifier = new LocalResourceIdentifier(ResourceId);

                ResourceGroupName = identifier.ResourceGroupName;
                Namespace = identifier.ParentResource;
                EventHub = identifier.ParentResource1;
                Name = identifier.ResourceName;
            }

            // delete a ConsumerGroup 
            if (ShouldProcess(target: Name, action: string.Format(Resources.RemoveConsumerGroup, Name, EventHub)))
            {
                try
                {
                    Client.DeletConsumerGroup(ResourceGroupName, Namespace, EventHub, Name);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                }
                catch (Management.EventHub.Models.ErrorResponseException ex)
                {
                    WriteError(Eventhub.EventHubsClient.WriteErrorforBadrequest(ex));
                }
            }
        }
    }
}
