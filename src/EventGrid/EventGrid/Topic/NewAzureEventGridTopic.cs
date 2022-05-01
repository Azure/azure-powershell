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
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventGridTopic",
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
        [ResourceNameCompleter("Microsoft.EventGrid/topics", nameof(ResourceGroupName))]
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
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.TagsHelp,
            ParameterSetName = TopicNameParameterSet)]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.InputSchemaHelp,
            ParameterSetName = TopicNameParameterSet)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(EventGridModels.InputSchema.EventGridSchema, EventGridModels.InputSchema.CustomEventSchema, EventGridModels.InputSchema.CloudEventSchemaV10, IgnoreCase = true)]
        public string InputSchema { get; set; } = EventGridModels.InputSchema.EventGridSchema;

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.InputMappingFieldHelp,
            ParameterSetName = TopicNameParameterSet)]
        public Hashtable InputMappingField { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.InputMappingDefaultValueHelp,
            ParameterSetName = TopicNameParameterSet)]
        public Hashtable InputMappingDefaultValue { get; set; }

        /// <summary>
        /// Hashtable which represents the Inbound IP Rules.
        /// </summary>
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.InboundIpRuleHelp,
            ParameterSetName = TopicNameParameterSet)]
        public Hashtable InboundIpRule { get; set; }

        /// <summary>
        /// string which represents the IdentityType.
        /// </summary>
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.IdentityTypeHelp,
            ParameterSetName = TopicNameParameterSet)]
        [ValidateSet("SystemAssigned", "UserAssigned", "SystemAssigned, UserAssigned", "None", IgnoreCase = true)]
        public string IdentityType { get; set; }

        /// <summary>
        /// string array of identity ids for user assigned identities
        /// </summary>
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.IdentityIdsHelp,
            ParameterSetName = TopicNameParameterSet)]
        public string[] IdentityId { get; set; }

        /// <summary>
        /// Public network access.
        /// </summary>
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.PublicNetworkAccessHelp,
            ParameterSetName = TopicNameParameterSet)]
        [ValidateSet(EventGridConstants.Enabled, EventGridConstants.Disabled, IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string PublicNetworkAccess { get; set; } = EventGridConstants.Enabled;

        public override void ExecuteCmdlet()
        {
            // Create a new Event Grid Topic
            Dictionary<string, string> tagDictionary = TagsConversionHelper.CreateTagDictionary(this.Tag, true);
            Dictionary<string, string> inputMappingFieldsDictionary = TagsConversionHelper.CreateTagDictionary(this.InputMappingField, true);
            Dictionary<string, string> inputMappingDefaultValuesDictionary = TagsConversionHelper.CreateTagDictionary(this.InputMappingDefaultValue, true);
            Dictionary<string, string> inboundIpRuleDictionary = TagsConversionHelper.CreateTagDictionary(this.InboundIpRule, true);
            Dictionary<string, UserIdentityProperties> userAssignedIdentities = null;
            if(IdentityId != null && IdentityId.Length > 0)
            {
                userAssignedIdentities = new Dictionary<string, UserIdentityProperties>();
                foreach (string identityId in IdentityId)
                {
                    userAssignedIdentities.Add(identityId, new UserIdentityProperties());
                }
            }
            

            EventGridUtils.ValidateInputMappingInfo(this.InputSchema, inputMappingFieldsDictionary, inputMappingDefaultValuesDictionary);

            if (this.ShouldProcess(this.Name, $"Create a new EventGrid topic {this.Name} in Resource Group {this.ResourceGroupName}"))
            {
                Topic topic = this.Client.CreateTopic(
                    this.ResourceGroupName,
                    this.Name,
                    this.Location,
                    tagDictionary,
                    InputSchema,
                    inputMappingFieldsDictionary,
                    inputMappingDefaultValuesDictionary,
                    inboundIpRuleDictionary,
                    this.PublicNetworkAccess,
                    this.IdentityType,
                    userAssignedIdentities);

                PSTopic psTopic = new PSTopic(topic);
                this.WriteObject(psTopic);
            }
        }
    }
}
