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

using System.Management.Automation;
using Microsoft.Azure.Commands.EventGrid.Models;
using Microsoft.Azure.Commands.EventGrid.Utilities;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.EventGrid
{
    [Cmdlet(
        VerbsCommon.Remove,
        EventGridEventSubscriptionVerb,
        DefaultParameterSetName = ResourceGroupNameParameterSet,
        SupportsShouldProcess = true),
     OutputType(typeof(bool))]
    public class RemoveAzureRmEventGridSubscription : AzureEventGridCmdletBase
    {
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Identifier of the resource whose event subscription needs to be removed.",
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = EventGridConstants.TopicInputObject,
            ParameterSetName = EventSubscriptionInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSTopic InputObject { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.EventSubscriptionName,
            ParameterSetName = TopicNameParameterSet)]
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.EventSubscriptionName,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = EventGridConstants.EventSubscriptionName,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = false,
            Position = 1,
            HelpMessage = EventGridConstants.EventSubscriptionName,
            ParameterSetName = EventSubscriptionInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string EventSubscriptionName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = EventGridConstants.ResourceGroupName,
            ParameterSetName = TopicNameParameterSet)]
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = EventGridConstants.ResourceGroupName,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Alias(AliasResourceGroup)]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = EventGridConstants.TopicName,
            ParameterSetName = TopicNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string TopicName { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ShouldProcess(this.EventSubscriptionName, $"Remove event subscription {this.EventSubscriptionName}"))
            {
                string scope;

                if (!string.IsNullOrEmpty(this.ResourceId))
                {
                    scope = this.ResourceId;
                }
                else if (this.InputObject != null)
                {
                    scope = this.InputObject.Id;
                }
                else
                {
                    // ResourceID not specified, build the scope for the event subscription for either the 
                    // subscription, or resource group, or custom topic depending on which of the parameters are provided.
                    scope = EventGridUtils.GetScope(this.DefaultContext.Subscription.Id, this.ResourceGroupName, this.TopicName);
                }

                this.Client.DeleteEventSubscription(scope, this.EventSubscriptionName);
                if (this.PassThru)
                {
                    this.WriteObject(true);
                }
            }
        }
    }
}
