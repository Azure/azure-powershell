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
using Microsoft.Azure.Management.EventHub.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.EventHub.Commands.ConsumerGroup
{
    /// <summary>
    /// 'Set-AzureRmEventHubConsumerGroup' Cmdlet updates the specified of Consumer Group
    /// </summary>
    [Cmdlet(VerbsCommon.Set, ConsumerGroupVerb, SupportsShouldProcess = true), OutputType(typeof(ConsumerGroupAttributes))]
    public class SetAzureEventHubConsumerGroup : AzureEventHubsCmdletBase
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
             Position = 2,
             HelpMessage = "EventHub Name.")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasEventHubName)]
        public string EventHub { get; set; }

        [Parameter(Mandatory = true,
             ValueFromPipelineByPropertyName = true,
             Position = 3,
             HelpMessage = "ConsumerGroup Name.")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasConsumerGroupName)]
        public string Name { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 4,
            HelpMessage = " User Metadata for ConsumerGroup")]
        [ValidateNotNullOrEmpty]
        public string UserMetadata { get; set; }

        public override void ExecuteCmdlet()
        {
            ConsumerGroupAttributes consumerGroup = new ConsumerGroupAttributes();
            consumerGroup.Name = Name;

            if (!string.IsNullOrEmpty(UserMetadata))
                consumerGroup.UserMetadata = UserMetadata;

            if(ShouldProcess(target: consumerGroup.Name, action: string.Format(Resources.UpdateConsumerGroup,consumerGroup.Name,EventHub)))
            {
                WriteObject(Client.CreateOrUpdateConsumerGroup(ResourceGroupName, Namespace, EventHub, consumerGroup.Name, consumerGroup));
            }
            
        }
    }
}
