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

namespace Microsoft.Azure.Commands.EventGrid
{
    [Cmdlet(
        VerbsCommon.Remove,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventGridChannel",
        SupportsShouldProcess = true,
        DefaultParameterSetName = ChannelNameParameterSet),
    OutputType(typeof(bool))]

    public class RemoveAzureEventGridChannel : AzureEventGridCmdletBase
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

        /// <summary>
        /// If present, do not ask for confirmation
        /// </summary>
        [Parameter(Mandatory = false,
           HelpMessage = EventGridConstants.ForceHelp)]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
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

            if (this.ShouldProcess(channelName, $"Remove EventGrid channel {channelName} under partner namespace {partnerNamespaceName} in Resource Group {resourceGroupName}"))
            {
                this.Client.DeleteChannel(resourceGroupName, partnerNamespaceName, channelName);

                if (this.PassThru)
                {
                    this.WriteObject(true);
                }
            }
        }
    }
}
