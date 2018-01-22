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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.EventGrid.Models;
using Microsoft.Azure.Commands.EventGrid.Utilities;
using Microsoft.Azure.Management.EventGrid.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.EventGrid
{
    [Cmdlet(VerbsCommon.Set, EventGridTopicVerb, SupportsShouldProcess = true, DefaultParameterSetName = TopicNameParameterSet), OutputType(typeof(PSTopic))]
    public class SetAzureEventGridTopic : AzureEventGridCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Resource Group Name.",
            ParameterSetName = TopicNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Alias(AliasResourceGroup)]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "EventGrid Topic Name.",
            ParameterSetName = TopicNameParameterSet)]
        [ValidateNotNullOrEmpty]
        [Alias("TopicName")]
        public string Name { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "EventGrid Topic ResourceID.",
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "EventGrid Topic object.",
            ParameterSetName = TopicInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSTopic InputObject { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Hashtable which represents resource Tags.",
            ParameterSetName = TopicNameParameterSet)]
        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Hashtable which represents resource Tags.",
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = "Hashtable which represents resource Tags.",
            ParameterSetName = TopicInputObjectParameterSet)]
        public Hashtable Tag { get; set; }

        public override void ExecuteCmdlet()
        {
            Dictionary<string, string> tagDictionary = TagsConversionHelper.CreateTagDictionary(this.Tag, true);
            string resourceGroupName = string.Empty;
            string topicName = string.Empty;

            if (!string.IsNullOrEmpty(this.ResourceId))
            {
                EventGridUtils.GetResourceGroupNameAndTopicName(this.ResourceId, out resourceGroupName, out topicName);
            }
            else if (!string.IsNullOrEmpty(this.Name))
            {
                resourceGroupName = this.ResourceGroupName;
                topicName = this.Name;
            }
            else if (this.InputObject != null)
            {
                resourceGroupName = this.InputObject.ResourceGroupName;
                topicName = this.InputObject.TopicName;
            }

            if (this.ShouldProcess(topicName, $"Set topic {topicName} in Resource Group {resourceGroupName}"))
            {
                Topic existingTopic = this.Client.GetTopic(resourceGroupName, topicName);
                if (existingTopic == null)
                {
                    throw new Exception($"Cannot find an existing topic {topicName} in resource group {resourceGroupName}");
                }

                Topic topic = this.Client.ReplaceTopic(resourceGroupName, topicName, existingTopic.Location, tagDictionary);
                PSTopic psTopic = new PSTopic(topic);
                this.WriteObject(psTopic);
            }
        }
    }
}
