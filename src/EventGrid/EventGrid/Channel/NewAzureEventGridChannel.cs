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
using Microsoft.Azure.Commands.EventGrid.Utilities;
using EventGridModels = Microsoft.Azure.Management.EventGrid.Models;
using System;

namespace Microsoft.Azure.Commands.EventGrid
{
    [Cmdlet(
        VerbsCommon.New,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventGridChannel",
        SupportsShouldProcess = true,
        DefaultParameterSetName = ChannelNameParameterSet),
    OutputType(typeof(PSChannel))]

    public class NewAzureEventGridChannel : AzureEventGridCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = ChannelNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Alias(AliasResourceGroup)]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = EventGridConstants.PartnerNamespaceNameHelp,
            ParameterSetName = ChannelNameParameterSet)]
        [ResourceNameCompleter("Microsoft.EventGrid/partnerNamespaces", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string PartnerNamespaceName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = EventGridConstants.ChannelNameHelp,
            ParameterSetName = ChannelNameParameterSet)]
        [ResourceNameCompleter("Microsoft.EventGrid/channels", nameof(ResourceGroupName), nameof(PartnerNamespaceName))]
        [ValidateNotNullOrEmpty]
        [Alias("ChannelName")]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = EventGridConstants.ChannelTypeHelp,
            ParameterSetName = ChannelNameParameterSet)]
        [ValidateSet("PartnerTopic", IgnoreCase = true)]
        public string ChannelType { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.PartnerTopicSourceHelp,
            ParameterSetName = ChannelNameParameterSet)]
        public string PartnerTopicSource { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.MessageForActivationHelp,
            ParameterSetName = ChannelNameParameterSet)]
        public string MessageForActivation { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.PartnerTopicNameHelp,
            ParameterSetName = ChannelNameParameterSet)]
        public string PartnerTopicName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.EventTypeKindHelp,
            ParameterSetName = ChannelNameParameterSet)]
        public string EventTypeKind { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.InlineEventHelp,
            ParameterSetName = ChannelNameParameterSet)]
        [ValidateSet("Inline", IgnoreCase = true)]
        public Hashtable InlineEvent { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ExpirationTimeIfNotActivatedHelp,
            ParameterSetName = ChannelNameParameterSet)]
        public DateTime? ExpirationTimeIfNotActivatedUtc { get; set; }

        public override void ExecuteCmdlet()
        {
            // Create a new Event Grid Channel
            if (this.ShouldProcess(this.ResourceGroupName, $"Create a new EventGrid partner channel {this.Name} under partner namespace {this.PartnerNamespaceName} in Resource Group {this.ResourceGroupName}"))
            {
                Channel channel = this.Client.CreateChannel(
                    azureSubscriptionId: this.DefaultContext.Subscription.Id,
                    resourceGroupName: this.ResourceGroupName,
                    partnerNamespaceName: this.PartnerNamespaceName,
                    channelName: this.Name,
                    channelType: this.ChannelType,
                    partnerTopicSource: this.PartnerTopicSource,
                    messageForActivation: this.MessageForActivation,
                    partnerTopicName: this.PartnerTopicName,
                    eventTypeKind: this.EventTypeKind,
                    inlineEvents: this.InlineEvent,
                    expirationTimeIfNotActivatedUtc: this.ExpirationTimeIfNotActivatedUtc);

                PSChannel psChannel = new PSChannel(channel);
                this.WriteObject(psChannel);
            }
        }
    }
}
