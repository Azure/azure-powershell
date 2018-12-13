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
using Microsoft.Azure.Commands.ServiceBus.Models;
namespace Microsoft.Azure.Commands.ServiceBus.Commands.Queue
{
    /// <summary>
    /// 'Remove-AzServiceBusQueue' Cmdlet removes the specified Queue
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ServiceBusQueue", DefaultParameterSetName = QueuePropertiesParameterSet, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureRmServiceBusQueue : AzureServiceBusCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = QueuePropertiesParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "The name of the resource group")]
        [ResourceGroupCompleter]
        [Alias("ResourceGroup")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = QueuePropertiesParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [Alias(AliasNamespaceName)]
        [ValidateNotNullOrEmpty]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = QueuePropertiesParameterSet, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "Queue Name")]
        [Alias(AliasQueueName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = QueueInputObjectParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "Service Bus Queue Object")]
        [ValidateNotNullOrEmpty]
        public PSQueueAttributes InputObject { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = QueueResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Service Bus Queue Resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }
        
        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(QueueInputObjectParameterSet))
            {
                LocalResourceIdentifier identifier = new LocalResourceIdentifier(InputObject.Id);
                ResourceGroupName = identifier.ResourceGroupName;
                Namespace = identifier.ParentResource;
                Name = identifier.ResourceName;
            }
            else if (ParameterSetName.Equals(QueueResourceIdParameterSet))
            {
                LocalResourceIdentifier identifier = new LocalResourceIdentifier(ResourceId);
                ResourceGroupName = identifier.ResourceGroupName;
                Namespace = identifier.ParentResource;
                Name = identifier.ResourceName;
            }

            // delete a Queue 
            if (ShouldProcess(target: Name, action: string.Format(Resources.RemoveQueue, Name, Namespace)))
            {
                try
                {
                    var result = Client.DeleteQueue(ResourceGroupName, Namespace, Name);
                    if (PassThru.IsPresent)
                    {
                        WriteObject(result);
                    }
                }
                catch (Management.ServiceBus.Models.ErrorResponseException ex)
                {
                    WriteError(ServiceBusClient.WriteErrorforBadrequest(ex));
                }
            }
        }
    }
}
