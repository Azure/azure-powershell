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
        [ValidateNotNullOrEmpty]
        public string ResourceGroup { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Namespace Name.")]
        [ValidateNotNullOrEmpty]
        public string NamespaceName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Queue Name.")]
        [ValidateNotNullOrEmpty]
        public string QueueName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "ServiceBus definition.")]
        [ValidateNotNullOrEmpty]
        public QueueAttributes QueueObj { get; set; }

        public override void ExecuteCmdlet()
        {
            QueueAttributes queueAttributes = new QueueAttributes();

            NamespaceAttributes getNamespaceLoc = Client.GetNamespace(ResourceGroup, NamespaceName);
            QueueObj.Location = getNamespaceLoc.Location;
            queueAttributes = QueueObj;
            
            if (ShouldProcess(target: QueueName, action: string.Format("Updating Queue:{0} of the NameSpace:{1}", QueueName, NamespaceName)))
            {
                WriteObject(Client.CreateUpdateQueue(ResourceGroup, NamespaceName, queueAttributes.Name, queueAttributes));
            }
        }
    }
}
