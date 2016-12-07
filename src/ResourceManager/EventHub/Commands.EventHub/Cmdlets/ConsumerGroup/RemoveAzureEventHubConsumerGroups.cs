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

using System.Management.Automation;
namespace Microsoft.Azure.Commands.EventHub.Commands.ConsumerGroup
{
    /// <summary>
    /// 'Remove-AzureRmEventHubConsumerGroup' deletes the specifed Consumer Group
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, ConsumerGroupVerb, SupportsShouldProcess = true)]
    public class RemoveAzureRmEventHubConsumerGroupp : AzureEventHubsCmdletBase
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

        public override void ExecuteCmdlet()
        {
            // delete a ConsumerGroup 
            if (ShouldProcess(target:ConsumerGroupName, action: string.Format("Deleting ConsumerGrop:{0} from Eventhub:{1}", ConsumerGroupName, EventHubName)))
               {
                Client.DeletConsumerGroup(ResourceGroupName, NamespaceName, EventHubName, ConsumerGroupName);
               }
        }
    }
}
