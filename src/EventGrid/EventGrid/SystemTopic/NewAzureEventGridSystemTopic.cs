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
        "New",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventGridSystemTopic",
        SupportsShouldProcess = true,
        DefaultParameterSetName = TopicNameParameterSet),
    OutputType(typeof(PSSystemTopic))]

    public class NewAzureEventGridSystemTopic : AzureEventGridCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = SystemTopicNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Alias(AliasResourceGroup)]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.TopicNameHelp,
            ParameterSetName = SystemTopicNameParameterSet)]
        [ResourceNameCompleter("Microsoft.EventGrid/systemTopics", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// string which represents the source.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.SourceHelp,
            ParameterSetName = SystemTopicNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Source { get; set; }

        /// <summary>
        /// string which represents the topic type.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.TopicTypeNameHelp,
            ParameterSetName = SystemTopicNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string TopicType { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.TopicLocationHelp,
            ParameterSetName = SystemTopicNameParameterSet)]
        [LocationCompleter("Microsoft.EventGrid/systemTopics")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }


        /// <summary>
        /// string which represents the IdentityType.
        /// </summary>
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.IdentityTypeHelp,
            ParameterSetName = SystemTopicNameParameterSet)]
        [ValidateSet("SystemAssigned", "UserAssigned", "SystemAssigned, UserAssigned", "None", IgnoreCase = true)]
        public string IdentityType { get; set; }

        /// <summary>
        /// string array of identity ids for user assigned identities
        /// </summary>
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.IdentityIdsHelp,
            ParameterSetName = SystemTopicNameParameterSet)]
        public string[] IdentityId { get; set; }

        /// <summary>
        /// Hashtable which represents resource Tags.
        /// </summary>
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.TagsHelp,
            ParameterSetName = SystemTopicNameParameterSet)]
        public Hashtable Tag { get; set; }

        

        public override void ExecuteCmdlet()
        {
            // Create a new Event Grid Topic
            Dictionary<string, string> tagDictionary = TagsConversionHelper.CreateTagDictionary(this.Tag, true);
            Dictionary<string, UserIdentityProperties> userAssignedIdentities = null;
            if (IdentityId != null && IdentityId.Length > 0)
            {
                userAssignedIdentities = new Dictionary<string, UserIdentityProperties>();
                foreach (string identityId in IdentityId)
                {
                    userAssignedIdentities.Add(identityId, new UserIdentityProperties());
                }
            }

            if (this.ShouldProcess(this.Name, $"Create a new EventGrid topic {this.Name} in Resource Group {this.ResourceGroupName}"))
            {
                SystemTopic topic = this.Client.CreateSystemTopic(
                    this.ResourceGroupName,
                    this.Name,
                    this.Location,
                    this.Source,
                    this.TopicType,
                    this.IdentityType,
                    userAssignedIdentities,
                    tagDictionary);

                PSSystemTopic psTopic = new PSSystemTopic(topic);
                this.WriteObject(psTopic);
            }
        }
    }
}
