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

using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.EventGrid.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.EventGrid.Models;

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
            HelpMessage = "The resource group in which the topic should be created.",
            ParameterSetName = TopicNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Alias(AliasResourceGroup)]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The name of the topic.",
            ParameterSetName = TopicNameParameterSet)]
        [ValidateNotNullOrEmpty]
        [Alias("TopicName")]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The location of the topic",
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
            HelpMessage = "Hashtable which represents resource Tags.",
            ParameterSetName = TopicNameParameterSet)]
        public Hashtable Tag { get; set; }

        public override void ExecuteCmdlet()
        {
            // Create a new Event Grid Topic
            Dictionary<string, string> tagDictionary = TagsConversionHelper.CreateTagDictionary(this.Tag, true);

            if (this.ShouldProcess(this.Name, $"Create a new EventGrid topic {this.Name} in Resource Group {this.ResourceGroupName}"))
            {
                Topic topic = this.Client.CreateTopic(this.ResourceGroupName, this.Name, this.Location, tagDictionary);
                PSTopic psTopic = new PSTopic(topic);
                this.WriteObject(psTopic);
            }
        }
    }
}
