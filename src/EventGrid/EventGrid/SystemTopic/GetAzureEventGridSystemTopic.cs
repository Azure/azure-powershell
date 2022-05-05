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
    /// 'Get-AzEventGridSystemTopic' Cmdlet gives the details of a / List of EventGrid topic(s)
    /// <para> If Topic name provided, a single Topic details will be returned</para>
    /// <para> If Topic name not provided, list of Topics will be returned</para>
    /// </summary>

    [Cmdlet(
        "Get",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventGridSystemTopic",
        DefaultParameterSetName = ResourceGroupNameParameterSet),
    OutputType(typeof(PSSystemTopic), typeof(PSSytemTopicListInstance))]

    public class GetAzureRmEventGridSystemTopic : AzureEventGridCmdletBase
    {
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = SystemTopicNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Alias(AliasResourceGroup)]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.TopicNameHelp,
            ParameterSetName = SystemTopicNameParameterSet)]
        [ResourceNameCompleter("Microsoft.EventGrid/systemTopics", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        [Alias("SystemTopicName")]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ODataQueryHelp,
            ParameterSetName = SystemTopicNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ODataQueryHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ODataQuery { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.TopHelp,
            ParameterSetName = SystemTopicNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.TopHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [ValidateRange(1, 100)]
        public int? Top { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.TopHelp,
            ParameterSetName = SystemTopicNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.TopHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string NextLink { get; set; }

        public override void ExecuteCmdlet()
        {
            string resourceGroupName = string.Empty;
            string topicName = string.Empty;
            IEnumerable<SystemTopic> topicsList;
            string nextLink = null;
            string newNextLink = null;
            int? providedTop = null;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(this.Top)))
            {
                providedTop = this.Top;
            }

            else if (!string.IsNullOrEmpty(this.Name))
            {
                // If Name is provided, ResourceGroup should be non-empty as well
                resourceGroupName = this.ResourceGroupName;
                topicName = this.Name;
            }
            else if (!string.IsNullOrEmpty(this.ResourceGroupName))
            {
                resourceGroupName = this.ResourceGroupName;
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
                    (topicsList, newNextLink) = this.Client.ListSystemTopicByResourceGroupNext(nextLink);
                }
                else
                {
                    (topicsList, newNextLink) = this.Client.ListSystemTopicBySubscriptionNext(nextLink);
                }

                PSSystemTopicListPagedInstance pSTopicListPagedInstance = new PSSystemTopicListPagedInstance(topicsList, newNextLink);
                this.WriteObject(pSTopicListPagedInstance, true);
            }
            else if (!string.IsNullOrEmpty(resourceGroupName) && !string.IsNullOrEmpty(topicName))
            {
                // Get details of the Event Grid topic
                SystemTopic topic = this.Client.GetSystemTopic(resourceGroupName, topicName);
                PSSystemTopic psTopic = new PSSystemTopic(topic);
                this.WriteObject(psTopic);
            }
            else if (!string.IsNullOrEmpty(resourceGroupName) && string.IsNullOrEmpty(topicName))
            {
                // List all Event Grid topics in the given resource group
                (topicsList, newNextLink) = this.Client.ListSystemTopicByResourceGroup(resourceGroupName, this.ODataQuery, providedTop);
                PSSystemTopicListPagedInstance pSTopicListPagedInstance = new PSSystemTopicListPagedInstance(topicsList, newNextLink);
                this.WriteObject(pSTopicListPagedInstance, true);
            }
            else if (string.IsNullOrEmpty(resourceGroupName) && string.IsNullOrEmpty(topicName))
            {
                // List all Event Grid topics in the given subscription
                (topicsList, newNextLink) = this.Client.ListSystemTopicBySubscription(this.ODataQuery, providedTop);
                PSSystemTopicListPagedInstance pSTopicListPagedInstance = new PSSystemTopicListPagedInstance(topicsList, newNextLink);
                this.WriteObject(pSTopicListPagedInstance, true);
            }
        }
    }
}
