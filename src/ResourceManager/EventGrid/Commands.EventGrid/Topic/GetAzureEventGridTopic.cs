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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.EventGrid.Models;
using Microsoft.Azure.Commands.EventGrid.Utilities;
using Microsoft.Azure.Management.EventGrid.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.EventGrid
{
    /// <summary>
    /// 'Get-AzureRmEventGridTopic' Cmdlet gives the details of a / List of EventGrid topic(s)
    /// <para> If Topic name provided, a single Topic details will be returned</para>
    /// <para> If Topic name not provided, list of Topics will be returned</para>
    /// </summary>
    [Cmdlet(
        VerbsCommon.Get,
        EventGridTopicVerb,
        DefaultParameterSetName = ResourceGroupNameParameterSet),
     OutputType(typeof(PSTopic), typeof(List<PSTopicListInstance>))]
    public class GetAzureRmEventGridTopic : AzureEventGridCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Resource Group Name.",
            ParameterSetName = TopicNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Resource Group Name.",
            ParameterSetName = ResourceGroupNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Alias(AliasResourceGroup)]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "EventGrid Topic Name.",
            ParameterSetName = TopicNameParameterSet)]
        [ValidateNotNullOrEmpty]
        [Alias("TopicName")]
        public string Name { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Resource Identifier representing the Event Grid Topic.",
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            string resourceGroupName = string.Empty;
            string topicName = string.Empty;

            if (!string.IsNullOrEmpty(this.ResourceId))
            {
                EventGridUtils.GetResourceGroupNameAndTopicName(this.ResourceId, out resourceGroupName, out topicName);
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
                
            if (!string.IsNullOrEmpty(resourceGroupName) && !string.IsNullOrEmpty(topicName))
            {
                // Get details of the Event Grid topic
                Topic topic = this.Client.GetTopic(resourceGroupName, topicName);
                PSTopic psTopic = new PSTopic(topic);
                this.WriteObject(psTopic);
            }
            else if (!string.IsNullOrEmpty(resourceGroupName) && string.IsNullOrEmpty(topicName))
            {
                // List all Event Grid topics in the given resource group
                IEnumerable<Topic> topicsList = this.Client.ListTopicsByResourceGroup(resourceGroupName);

                List<PSTopicListInstance> psTopicsList = new List<PSTopicListInstance>();
                foreach (Topic topic in topicsList)
                {
                    psTopicsList.Add(new PSTopicListInstance(topic));
                }

                this.WriteObject(psTopicsList, true);
            }
            else
            {
                // List all Event Grid topics in the given subscription
                IEnumerable<Topic> topicsList = this.Client.ListTopicsBySubscription();

                List<PSTopicListInstance> psTopicsList = new List<PSTopicListInstance>();
                foreach (Topic topic in topicsList)
                {
                    psTopicsList.Add(new PSTopicListInstance(topic));
                }

                this.WriteObject(psTopicsList, true);
            }
        }
    }
}