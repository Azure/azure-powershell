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
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.EventGrid
{
    [Cmdlet(
        "New",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventGridPartnerTopic",
        SupportsShouldProcess = true,
        DefaultParameterSetName = TopicNameParameterSet),
    OutputType(typeof(PSPartnerTopic))]

    public class NewAzureEventGridPartnerTopic : AzureEventGridCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = PartnerTopicNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Alias(AliasResourceGroup)]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.TopicNameHelp,
            ParameterSetName = PartnerTopicNameParameterSet)]
        [ResourceNameCompleter("Microsoft.EventGrid/partnerTopics", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        [Alias("PartnerTopicName")]
        public string Name { get; set; }

        /// <summary>
        /// string which represents the source.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.SourceHelp,
            ParameterSetName = PartnerTopicNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Source { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.TopicLocationHelp,
            ParameterSetName = PartnerTopicNameParameterSet)]
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
            ParameterSetName = PartnerTopicNameParameterSet)]
        [ValidateSet("SystemAssigned", "UserAssigned", "SystemAssigned, UserAssigned", "None", IgnoreCase = true)]
        public string IdentityType { get; set; }

        /// <summary>
        /// string array of identity ids for user assigned identities
        /// </summary>
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.IdentityIdsHelp,
            ParameterSetName = PartnerTopicNameParameterSet)]
        public string[] IdentityId { get; set; }

        /// <summary>
        /// Hashtable which represents resource Tags.
        /// </summary>
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.TagsHelp,
            ParameterSetName = PartnerTopicNameParameterSet)]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.TagsHelp,
            ParameterSetName = PartnerTopicNameParameterSet)]
        public string PartnerTopicFriendlyDescription { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.MessageForActivationHelp,
            ParameterSetName = PartnerTopicNameParameterSet)]
        public string MessageForActivation { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ExpirationTimeIfNotActivatedHelp,
            ParameterSetName = PartnerTopicNameParameterSet)]
        public DateTime? ExpirationTimeIfNotActivatedUtc { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.PartnerRegistrationImmutableIdHelp,
            ParameterSetName = PartnerTopicNameParameterSet)]
        public Guid? PartnerRegistrationImmutableId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.EventTypeKindHelp,
            ParameterSetName = PartnerTopicNameParameterSet)]
        [ValidateSet("Inline", IgnoreCase = true)]
        public string EventTypeKind { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.InlineEventHelp,
            ParameterSetName = PartnerTopicNameParameterSet)]
        [ValidateSet("Inline", IgnoreCase = true)]
        public Hashtable InlineEvent { get; set; }

        public override void ExecuteCmdlet()
        {
            // Create a new Event Grid Partner Topic
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

            if (this.ShouldProcess(this.Name, $"Create a new EventGrid partner topic {this.Name} in Resource Group {this.ResourceGroupName}"))
            {
                PartnerTopic topic = this.Client.CreatePartnerTopic(
                    this.ResourceGroupName,
                    this.Name,
                    this.Location,
                    this.Source,
                    this.IdentityType,
                    userAssignedIdentities,
                    tagDictionary,
                    this.PartnerRegistrationImmutableId,
                    this.ExpirationTimeIfNotActivatedUtc,
                    this.PartnerTopicFriendlyDescription,
                    this.MessageForActivation,
                    this.EventTypeKind,
                    this.InlineEvent);

                PSPartnerTopic psTopic = new PSPartnerTopic(topic);
                this.WriteObject(psTopic);
            }
        }
    }
}
