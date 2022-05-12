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
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.EventGrid
{
    [Cmdlet(
        "Remove",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventGridSystemTopicEventSubscription",
        SupportsShouldProcess = true,
        DefaultParameterSetName = TopicNameParameterSet),
    OutputType(typeof(bool))]

    public class RemoveAzureEventGridSystemTopicEventSubscription : AzureEventGridCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.EventSubscriptionNameHelp,
            ParameterSetName = SystemTopicEventSuscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string EventSubscriptionName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = SystemTopicEventSuscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.TopicNameHelp,
            ParameterSetName = SystemTopicEventSuscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string SystemTopicName { get; set; }

        /// <summary>
        /// If present, do not ask for confirmation
        /// </summary>
        [Parameter(Mandatory = false,
           HelpMessage = EventGridConstants.ForceHelp)]
        public SwitchParameter Force { get; set; }

        [Parameter(
            Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(Force.IsPresent,
                $"Remove event subscription {this.EventSubscriptionName}",
                $"Removing event subscription {this.EventSubscriptionName}",
                this.EventSubscriptionName,
                () =>
                {
                    this.Client.DeleteSystemTopicEventSubscriptiion(this.ResourceGroupName, this.SystemTopicName, this.EventSubscriptionName);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}
