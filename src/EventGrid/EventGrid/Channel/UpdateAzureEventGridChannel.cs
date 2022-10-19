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
        "Update",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventGridChannel",
        SupportsShouldProcess = true,
        DefaultParameterSetName = ChannelNameParameterSet),
    OutputType(typeof(PSChannel))]

    public class UpdateAzureEventGridChannel : AzureEventGridCmdletBase
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
            Position = 0,
            HelpMessage = EventGridConstants.ChannelInputObjectHelp,
            ParameterSetName = ChannelInputObjectParameterSet)]
        public PSChannel InputObject { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.EventTypeKindHelp,
            ParameterSetName = ChannelNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.EventTypeKindHelp,
            ParameterSetName = ChannelInputObjectParameterSet)]
        public string EventTypeKind { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.InlineEventHelp,
            ParameterSetName = ChannelNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.InlineEventHelp,
            ParameterSetName = ChannelInputObjectParameterSet)]
        [ValidateSet("Inline", IgnoreCase = true)]
        public Hashtable InlineEvent { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ExpirationTimeIfNotActivatedHelp,
            ParameterSetName = ChannelNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ExpirationTimeIfNotActivatedHelp,
            ParameterSetName = ChannelInputObjectParameterSet)]
        public DateTime? ExpirationTimeIfNotActivatedUtc { get; set; }

        public override void ExecuteCmdlet()
        {
            // Update an Event Grid Channel
            string resourceGroupName = string.Empty;
            string partnerNamespaceName = string.Empty;
            string channelName = string.Empty;

            if (this.InputObject != null)
            {
                resourceGroupName = this.InputObject.ResourceGroupName;
                partnerNamespaceName = this.InputObject.PartnerNamespaceName;
                channelName = this.InputObject.Name;
            }
            else
            {
                resourceGroupName = this.ResourceGroupName;
                partnerNamespaceName = this.PartnerNamespaceName;
                channelName = this.Name;
            }

            if (this.ShouldProcess(channelName, $"Update EventGrid channel {channelName} under partner namespace {partnerNamespaceName} in Resource Group {resourceGroupName}"))
            {
                Channel channel = this.Client.UpdateChannel(
                    resourceGroupName,
                    partnerNamespaceName,
                    channelName,
                    this.EventTypeKind,
                    this.InlineEvent,
                    this.ExpirationTimeIfNotActivatedUtc);

                PSChannel psChannel = new PSChannel(channel);
                this.WriteObject(psChannel);
            }
        }
    }
}

