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
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.EventGrid.Models;

namespace Microsoft.Azure.Commands.EventGrid
{
    [Cmdlet(VerbsData.Update, EventGridTopicVerb, SupportsShouldProcess = true, DefaultParameterSetName = TopicNameParameterSet), OutputType(typeof(PSTopic))]
    public class UpdateAzureEventGridTopic : AzureEventGridCmdletBase
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
            HelpMessage = "Hashtable which represents resource Tags.",
            ParameterSetName = TopicNameParameterSet)]
        [Parameter(
            HelpMessage = "Hashtable which represents resource Tags.",
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            HelpMessage = "Hashtable which represents resource Tags.",
            ParameterSetName = TopicInputObjectParameterSet)]
        public Hashtable Tag { get; set; }

        public override void ExecuteCmdlet()
        {
            string resourceGroupName = string.Empty;
            string topicName = string.Empty;

            var newTagDictionary = (this.Tag != null)
                ? TagsConversionHelper.CreateTagDictionary(this.Tag, true)
                : new Dictionary<string, string>();

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

            if (this.ShouldProcess(topicName, $"Update topic {topicName} in Resource Group {resourceGroupName}"))
            {
                Topic existingTopic = this.Client.GetTopic(resourceGroupName, topicName);
                if (existingTopic == null)
                {
                    throw new Exception($"Cannot find an existing topic {topicName} in resource group {resourceGroupName}");
                }

                IDictionary<string, string> existingTagsDictionary = existingTopic.Tags;

                // If there are existing tags, include them along with the provided tags before making the service call
                if (existingTagsDictionary != null)
                {
                    foreach (KeyValuePair<string, string> existingTag in existingTagsDictionary)
                    {
                        if (!newTagDictionary.ContainsKey(existingTag.Key))
                        {
                            newTagDictionary.Add(existingTag.Key, existingTag.Value);
                        }
                    }
                }

                Topic topic = this.Client.UpdateTopic(resourceGroupName, topicName, newTagDictionary);
                PSTopic psTopic = new PSTopic(topic);
                this.WriteObject(psTopic);
            }
        }
    }
}
