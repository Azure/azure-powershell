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
using Microsoft.Azure.Commands.ServiceBus.Models;
using Microsoft.Azure.Management.ServiceBus.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ServiceBus.Commands.Queue
{
    /// <summary>
    /// 'Set-AzureRmServiceBusQueue' Cmdlet updates the specified Queue
    /// </summary>
    [Cmdlet(VerbsCommon.Set, ServicebusQueueVerb, SupportsShouldProcess = true), OutputType(typeof(QueueAttributes))]
    public class SetAzureRmServiceBusQueue : AzureServiceBusCmdletBase
    {
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The name of the resource group")]
        [ResourceGroupCompleter]
        [Alias("ResourceGroup")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Namespace Name.")]
        [Alias(AliasNamespaceName)]
        [ValidateNotNullOrEmpty]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Queue Name.")]
        [Alias(AliasQueueName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "ServiceBus definition.")]
        [Alias(AliasQueueObj)]
        [ValidateNotNullOrEmpty]
        public QueueAttributes InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            QueueAttributes queueAttributes = new QueueAttributes();

            if (InputObject != null)
               {
                NamespaceAttributes getNamespaceLoc = Client.GetNamespace(ResourceGroupName, Namespace);
                queueAttributes = InputObject;
               }

            if (ShouldProcess(target: Name, action: string.Format(Resources.UpdateQueue, Name, Namespace)))
            {
                WriteObject(Client.CreateUpdateQueue(ResourceGroupName, Namespace, queueAttributes.Name, queueAttributes));
            }
        }
    }
}
