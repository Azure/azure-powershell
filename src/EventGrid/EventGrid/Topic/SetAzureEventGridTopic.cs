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
            HelpMessage = EventGridConstants.TagsHelp,
            ParameterSetName = TopicNameParameterSet)]
        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.TagsHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.TagsHelp,
            ParameterSetName = TopicInputObjectParameterSet)]
        public Hashtable Tag { get; set; }

        /// <summary>
        /// Hashtable which represents the Inbound IP Rules.
        /// </summary>
        [Parameter(
            Mandatory = true,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.InboundIpRuleHelp,
            ParameterSetName = TopicNameParameterSet)]
        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.InboundIpRuleHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.InboundIpRuleHelp,
            ParameterSetName = TopicInputObjectParameterSet)]
        public Hashtable InboundIpRule { get; set; }

        /// <summary>
        /// string which represents the IdentityType.
        /// </summary>
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.IdentityTypeHelp,
            ParameterSetName = TopicNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.IdentityTypeHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.IdentityTypeHelp,
            ParameterSetName = TopicInputObjectParameterSet)]
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
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.IdentityIdsHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.IdentityIdsHelp,
            ParameterSetName = TopicInputObjectParameterSet)]
        public string[] IdentityId { get; set; }

        /// <summary>
        /// Public network access.
        /// </summary>
        [Parameter(
            Mandatory = true,
            Position = 4,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.PublicNetworkAccessHelp,
            ParameterSetName = TopicNameParameterSet)]
        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.PublicNetworkAccessHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.PublicNetworkAccessHelp,
            ParameterSetName = TopicInputObjectParameterSet)]
        [ValidateSet(EventGridConstants.Enabled, EventGridConstants.Disabled, IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string PublicNetworkAccess { get; set; } = EventGridConstants.Enabled;

        public override void ExecuteCmdlet()
        {
            Dictionary<string, string> tagDictionary = TagsConversionHelper.CreateTagDictionary(this.Tag, true);
            Dictionary<string, string> inboundIpRuleDictionary = TagsConversionHelper.CreateTagDictionary(this.InboundIpRule, true);
            string resourceGroupName = string.Empty;
            string topicName = string.Empty;

            Dictionary<string, UserIdentityProperties> userAssignedIdentities = null;
            if (IdentityId != null && IdentityId.Length > 0)
            {
                userAssignedIdentities = new Dictionary<string, UserIdentityProperties>();
                foreach (string identityId in IdentityId)
                {
                    userAssignedIdentities.Add(identityId, new UserIdentityProperties());
                }
            }

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

                Topic topic = this.Client.ReplaceTopic(
                    resourceGroupName,
                    topicName,
                    existingTopic.Location,
                    tagDictionary,
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
