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
using System.Management.Automation;
using Microsoft.Azure.Commands.EventGrid.Models;
using Microsoft.Azure.Commands.EventGrid.Utilities;
using Microsoft.Azure.Management.EventGrid.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.EventGrid
{
    /// <summary>
    /// 'Get-AzEventGridTopic' Cmdlet gives the details of a / List of EventGrid topic(s)
    /// <para> If Topic name provided, a single Topic details will be returned</para>
    /// <para> If Topic name not provided, list of Topics will be returned</para>
    /// </summary>

    [Cmdlet(
        "Get",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventGridTopic",
        DefaultParameterSetName = ResourceGroupNameParameterSet),
    OutputType(typeof(PSTopic), typeof(PSTopicListInstance))]

    public class GetAzureRmEventGridTopic : AzureEventGridCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = TopicNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
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
            Position = 0,
            HelpMessage = EventGridConstants.TopicResourceIdHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ODataQueryHelp,
            ParameterSetName = TopicNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ODataQueryHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ODataQueryHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ODataQuery { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.TopHelp,
            ParameterSetName = TopicNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.TopHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.TopHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [ValidateRange(1, 100)]
        public int? Top { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.NextLinkHelp,
            ParameterSetName = NextLinkParameterSet)]
        [ValidateNotNullOrEmpty]
        public string NextLink { get; set; }

        public override void ExecuteCmdlet()
        {
            IEnumerable<Topic> topicsList;
            string nextLink = null;
            string newNextLink = null;
            int? providedTop = null;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(this.Top)))
            {
                providedTop = this.Top;
            }

            if (!string.IsNullOrEmpty(this.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.Name = resourceIdentifier.ResourceName;
            }
            else if (!string.IsNullOrEmpty(this.NextLink))
            {
                // Other parameters should be null or ignored if nextLink is specified.
                nextLink = this.NextLink;
            }

            if (!string.IsNullOrEmpty(nextLink))
            {
                // Get Next page of topics. Get the proper next API to be called based on the nextLink.
                Uri uri = new Uri(nextLink);
                string path = uri.AbsolutePath;

                if (path.IndexOf("/resourceGroups/", StringComparison.OrdinalIgnoreCase) != -1)
                {
                    (topicsList, newNextLink) = this.Client.ListTopicsByResourceGroupNext(nextLink);
                }
                else
                {
                    (topicsList, newNextLink) = this.Client.ListTopicBySubscriptionNext(nextLink);
                }

                PSTopicListPagedInstance pSTopicListPagedInstance = new PSTopicListPagedInstance(topicsList, newNextLink);
                this.WriteObject(pSTopicListPagedInstance, true);
            }
            else if (!string.IsNullOrEmpty(this.ResourceGroupName) && !string.IsNullOrEmpty(this.Name))
            {
                // Get details of the Event Grid topic
                Topic topic = this.Client.GetTopic(this.ResourceGroupName, this.Name);
                PSTopic psTopic = new PSTopic(topic);
                this.WriteObject(psTopic);
            }
            else if (!string.IsNullOrEmpty(this.ResourceGroupName) && string.IsNullOrEmpty(this.Name))
            {
                // List all Event Grid topics in the given resource group
                (topicsList, newNextLink) = this.Client.ListTopicsByResourceGroup(this.ResourceGroupName, this.ODataQuery, providedTop);
                PSTopicListPagedInstance pSTopicListPagedInstance = new PSTopicListPagedInstance(topicsList, newNextLink);
                this.WriteObject(pSTopicListPagedInstance, true);
            }
            else if (string.IsNullOrEmpty(this.ResourceGroupName) && string.IsNullOrEmpty(this.Name))
            {
                // List all Event Grid topics in the given subscription
                (topicsList, newNextLink) = this.Client.ListTopicsBySubscription(this.ODataQuery, providedTop);
                PSTopicListPagedInstance pSTopicListPagedInstance = new PSTopicListPagedInstance(topicsList, newNextLink);
                this.WriteObject(pSTopicListPagedInstance, true);
            }
        }
    }
}
