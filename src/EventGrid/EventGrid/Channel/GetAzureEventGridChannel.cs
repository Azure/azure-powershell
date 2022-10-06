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
using System.Collections.Generic;
using System.Text;
using System.Management.Automation;
using Microsoft.Azure.Commands.EventGrid.Models;
using Microsoft.Azure.Management.EventGrid.Models;
using Microsoft.Azure.Commands.EventGrid.Utilities;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.EventGrid
{
    /// <summary>
    /// 'Get-AzureEventGridChannel' Cmdlet gives the details of a / List of EventGrid channel(s)
    /// <para> If Channel name provided, a single Channel details will be returned</para>
    /// <para> If Channel name not provided, list of Channels will be returned</para>
    /// </summary>

    [Cmdlet(
        "Get",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventGridChannel",
        DefaultParameterSetName = ChannelListByPartnerNamespaceParameterSet),
    OutputType(typeof(PSChannelListInstance), typeof(PSChannel))]

    public class GetAzureEventGridChannel : AzureEventGridCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = ChannelListByPartnerNamespaceParameterSet)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = ChannelNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Alias(AliasResourceGroup)]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.PartnerNamespaceNameHelp,
            ParameterSetName = ChannelListByPartnerNamespaceParameterSet)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.PartnerNamespaceNameHelp,
            ParameterSetName = ChannelNameParameterSet)]
        [ResourceNameCompleter("Microsoft.EventGrid/partnerNamespaces", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string PartnerNamespaceName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ChannelNameHelp,
            ParameterSetName = ChannelNameParameterSet)]
        [ResourceNameCompleter("Microsoft.EventGrid/channels", nameof(ResourceGroupName), nameof(PartnerNamespaceName))]
        [ValidateNotNullOrEmpty]
        [Alias("ChannelName")]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ODataQueryHelp,
            ParameterSetName = ChannelListByPartnerNamespaceParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ODataQuery { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.TopHelp,
            ParameterSetName = ChannelListByPartnerNamespaceParameterSet)]
        [ValidateRange(1, 100)]
        public int? Top { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.NextLinkHelp,
            ParameterSetName = NextLinkParameterSet)]
        [ValidateNotNullOrEmpty]
        public string NextLink { get; set; }

        public override void ExecuteCmdlet()
        {
            string resourceGroupName = string.Empty;
            IEnumerable<Channel> partnerNamespacesList;
            string newNextLink = null;
            string partnerNamespaceName = null;
            string channelName = null;
            int? providedTop = null;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(this.Top)))
            {
                providedTop = this.Top;
            }

            if (!string.IsNullOrEmpty(this.ResourceGroupName))
            {
                resourceGroupName = this.ResourceGroupName;
            }

            if (!string.IsNullOrEmpty(this.PartnerNamespaceName))
            {
                partnerNamespaceName = this.PartnerNamespaceName;
            }

            if (!string.IsNullOrEmpty(this.Name))
            {
                channelName = this.Name;
            }

            if (!string.IsNullOrEmpty(this.NextLink))
            {
                // Get next page of channels
                Uri uri = new Uri(this.NextLink);
                string path = uri.AbsolutePath;

                (partnerNamespacesList, newNextLink) = this.Client.ListChannelByPartnerNamespaceNext(this.NextLink);

                PSChannelListPagedInstance psChannelListPagedInstance = new PSChannelListPagedInstance(partnerNamespacesList, newNextLink);
                this.WriteObject(psChannelListPagedInstance, true);
            }
            else if (!string.IsNullOrEmpty(channelName))
            {
                // Get details of a channel
                Channel partnerNamespace = this.Client.GetChannel(resourceGroupName, partnerNamespaceName, channelName);
                PSChannel psPartnerConfigutation = new PSChannel(partnerNamespace);
                this.WriteObject(psPartnerConfigutation);
            }
            else if (string.IsNullOrEmpty(channelName))
            {
                // List channels at partner namespace scope
                (partnerNamespacesList, newNextLink) = this.Client.ListChannelByPartnerNamespace(resourceGroupName, partnerNamespaceName, this.ODataQuery, providedTop);
                PSChannelListPagedInstance psChannelListPagedInstance = new PSChannelListPagedInstance(partnerNamespacesList, newNextLink);
                this.WriteObject(psChannelListPagedInstance, true);
            }
        }
    }

}