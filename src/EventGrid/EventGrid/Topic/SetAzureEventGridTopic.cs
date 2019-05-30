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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.EventGrid
{
    [Cmdlet(
        "Set",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventGridTopic",
        SupportsShouldProcess = true,
        DefaultParameterSetName = TopicNameParameterSet),
    OutputType(typeof(PSTopic))]

    public class SetAzureEventGridTopic : AzureEventGridCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = TopicNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Alias(AliasResourceGroup)]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = EventGridConstants.TopicNameHelp,
            ParameterSetName = TopicNameParameterSet)]
        [ResourceNameCompleter("Microsoft.EventGrid/topics", nameof(ResourceGroupName))]
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
            HelpMessage = EventGridConstants.TopicInputObjectHelp,
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
            Mandatory = false,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Hashtable which represents resource Tags.",
            ParameterSetName = TopicInputObjectParameterSet)]
        public Hashtable Tag { get; set; }

        public override void ExecuteCmdlet()
        {
            Dictionary<string, string> tagDictionary = TagsConversionHelper.CreateTagDictionary(this.Tag, true);

            if (!string.IsNullOrEmpty(this.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.Name = resourceIdentifier.ResourceName;
            }
            else if (this.InputObject != null)
            {
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.Name = this.InputObject.TopicName;
            }

            if (this.ShouldProcess(this.Name, $"Set topic {this.Name} in Resource Group {this.ResourceGroupName}"))
            {
                Topic existingTopic = this.Client.GetTopic(this.ResourceGroupName, this.Name);
                if (existingTopic == null)
                {
                    throw new Exception($"Cannot find an existing topic {this.Name} in resource group {this.ResourceGroupName}");
                }

                Topic topic = this.Client.ReplaceTopic(this.ResourceGroupName, this.Name, existingTopic.Location, tagDictionary);
                PSTopic psTopic = new PSTopic(topic);
                this.WriteObject(psTopic);
            }
        }
    }
}
