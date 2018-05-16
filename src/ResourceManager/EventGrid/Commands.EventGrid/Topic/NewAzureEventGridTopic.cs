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
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.EventGrid.Models;
using Microsoft.Azure.Commands.EventGrid.Utilities;
using EventGridModels = Microsoft.Azure.Management.EventGrid.Models;

namespace Microsoft.Azure.Commands.EventGrid
{
    [Cmdlet(
        VerbsCommon.New,
        EventGridTopicVerb,
        SupportsShouldProcess = true,
        DefaultParameterSetName = TopicNameParameterSet),
     OutputType(typeof(PSTopic))]
    public class NewAzureEventGridTopic : AzureEventGridCmdletBase
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
        [ValidateNotNullOrEmpty]
        [Alias("TopicName")]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = EventGridConstants.TopicLocationHelp,
            ParameterSetName = TopicNameParameterSet)]
        [LocationCompleter("Microsoft.EventGrid/topics")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// Hashtable which represents resource Tags.
        /// </summary>
        [Parameter(
            Mandatory = false,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.TagsHelp,
            ParameterSetName = TopicNameParameterSet)]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 4,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.InputSchemaHelp,
            ParameterSetName = TopicNameParameterSet)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(EventGridModels.InputSchema.EventGridSchema, EventGridModels.InputSchema.CustomEventSchema, EventGridModels.InputSchema.CloudEventV01Schema, IgnoreCase = true)]
        public string InputSchema { get; set; } = EventGridModels.InputSchema.EventGridSchema;

        [Parameter(
            Mandatory = false,
            Position = 5,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.InputMappingFieldsHelp,
            ParameterSetName = TopicNameParameterSet)]
        public Hashtable InputMappingFields { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 6,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.InputMappingDefaultValuesHelp,
            ParameterSetName = TopicNameParameterSet)]
        public Hashtable InputMappingDefaultValues { get; set; }

        public override void ExecuteCmdlet()
        {
            // Create a new Event Grid Topic
            Dictionary<string, string> tagDictionary = TagsConversionHelper.CreateTagDictionary(this.Tag, true);
            Dictionary<string, string> inputMappingFieldsDictionary = TagsConversionHelper.CreateTagDictionary(this.InputMappingFields, true);
            Dictionary<string, string> inputMappingDefaultValuesDictionary = TagsConversionHelper.CreateTagDictionary(this.InputMappingDefaultValues, true);

            this.ValidateInputMappingInfo(inputMappingFieldsDictionary, inputMappingDefaultValuesDictionary);

            if (this.ShouldProcess(this.Name, $"Create a new EventGrid topic {this.Name} in Resource Group {this.ResourceGroupName}"))
            {
                Topic topic = this.Client.CreateTopic(this.ResourceGroupName, this.Name, this.Location, tagDictionary, InputSchema, inputMappingFieldsDictionary, inputMappingDefaultValuesDictionary);
                PSTopic psTopic = new PSTopic(topic);
                this.WriteObject(psTopic);
            }
        }

        void ValidateInputMappingInfo(Dictionary<string, string> inputMappingFieldsDictionary, Dictionary<string, string> inputMappingDefaultValuesDictionary)
        {
            if (string.Equals(this.InputSchema, EventGridModels.InputSchema.CustomEventSchema, StringComparison.OrdinalIgnoreCase))
            {
                if (inputMappingFieldsDictionary == null && inputMappingDefaultValuesDictionary == null)
                {
                    throw new Exception($"Either input mapping fields or input mapping default values should be specified if the input mapping schema is customeventschema.");
                }
            }
            else
            {
                if (inputMappingFieldsDictionary != null || inputMappingDefaultValuesDictionary != null)
                {
                    throw new Exception($"Input mapping fields and input mapping default values cannot be specified if the input mapping schema is not customeventschema.");
                }
            }

            if (inputMappingFieldsDictionary != null)
            {
                foreach (var entry in inputMappingFieldsDictionary)
                {
                    if (!string.Equals(entry.Key, EventGridConstants.InputMappingId, StringComparison.OrdinalIgnoreCase) &&
                        !string.Equals(entry.Key, EventGridConstants.InputMappingTopic, StringComparison.OrdinalIgnoreCase) &&
                        !string.Equals(entry.Key, EventGridConstants.InputMappingEventTime, StringComparison.OrdinalIgnoreCase) &&
                        !string.Equals(entry.Key, EventGridConstants.InputMappingSubject, StringComparison.OrdinalIgnoreCase) &&
                        !string.Equals(entry.Key, EventGridConstants.InputMappingEventType, StringComparison.OrdinalIgnoreCase) &&
                        !string.Equals(entry.Key, EventGridConstants.InputMappingDataVersion, StringComparison.OrdinalIgnoreCase))
                    {
                        throw new InvalidOperationException($"{entry.Key} is an invalid key value for InputMappingFields");
                    }
                }
            }

            if (inputMappingDefaultValuesDictionary != null)
            {
                foreach (var entry in inputMappingDefaultValuesDictionary)
                {
                    if (!string.Equals(entry.Key, EventGridConstants.InputMappingSubject, StringComparison.OrdinalIgnoreCase) &&
                        !string.Equals(entry.Key, EventGridConstants.InputMappingEventType, StringComparison.OrdinalIgnoreCase) &&
                        !string.Equals(entry.Key, EventGridConstants.InputMappingDataVersion, StringComparison.OrdinalIgnoreCase))
                    {
                        throw new InvalidOperationException($"{entry.Key} is an invalid key value for InputMappingDefaultValues");
                    }
                }
            }
        }
    }
}
