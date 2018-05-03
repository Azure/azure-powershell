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
using Microsoft.Azure.Commands.EventGrid.Models;
using Microsoft.Azure.Commands.EventGrid.Utilities;
using Microsoft.Azure.Management.EventGrid.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.EventGrid
{
    [Cmdlet(VerbsCommon.New, EventGridTopicKeyVerb, DefaultParameterSetName = TopicNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(TopicSharedAccessKeys))]
    public class NewAzureEventGridTopicKey : AzureEventGridCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            ParameterSetName = TopicNameParameterSet,
            HelpMessage = "Resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Alias(AliasResourceGroup)]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            ParameterSetName = TopicNameParameterSet,
            HelpMessage = "The name of the topic.")]
        [ValidateNotNullOrEmpty]
        public string TopicName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            ParameterSetName = TopicNameParameterSet,
            HelpMessage = "The name of the key that needs to be regenerated")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = false,
            Position = 1,
            HelpMessage = "The name of the key that needs to be regenerated",
            ParameterSetName = TopicInputObjectParameterSet)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The name of the key that needs to be regenerated",
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string KeyName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "EventGrid Topic object.",
            ParameterSetName = TopicInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSTopic InputObject { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Resource Identifier representing the Event Grid Topic.",
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ShouldProcess(this.TopicName, $"Regenerate key {this.KeyName} for topic {this.TopicName} in Resource Group {this.ResourceGroupName}"))
            {
                string resourceGroupName;
                string topicName;

                if (!string.IsNullOrEmpty(this.ResourceId))
                {
                    EventGridUtils.GetResourceGroupNameAndTopicName(this.ResourceId, out resourceGroupName, out topicName);
                }
                else if (this.InputObject != null)
                {
                    resourceGroupName = this.InputObject.ResourceGroupName;
                    topicName = this.InputObject.TopicName;
                }
                else
                {
                    resourceGroupName = this.ResourceGroupName;
                    topicName = this.TopicName;
                }

                this.WriteObject(this.Client.RegenerateTopicKey(resourceGroupName, topicName, this.KeyName));
            }
        }
    }
}
