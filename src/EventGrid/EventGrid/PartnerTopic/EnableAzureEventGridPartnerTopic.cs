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
        "Enable",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventGridPartnerTopic",
        SupportsShouldProcess = true,
        DefaultParameterSetName = PartnerTopicNameParameterSet),
    OutputType(typeof(PSPartnerTopic))]

    public class EnableAzureEventGridPartnerTopic : AzureEventGridCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = PartnerTopicNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Alias(AliasResourceGroup)]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = EventGridConstants.PartnerTopicNameHelp,
            ParameterSetName = PartnerTopicNameParameterSet)]
        [ResourceNameCompleter("Microsoft.EventGrid/partnerTopics", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        [Alias("PartnerTopicName")]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.PartnerTopicInputObjectHelp,
            ParameterSetName = PartnerTopicInputObjectParameterSet)]
        public PSPartnerTopic InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            string resourceGroupName = string.Empty;
            string partnerTopicName = string.Empty;

            if (this.InputObject != null)
            {
                resourceGroupName = this.InputObject.ResourceGroupName;
                partnerTopicName = this.InputObject.Name;
            }
            else
            {
                resourceGroupName = this.ResourceGroupName;
                partnerTopicName = this.Name;
            }

            if (this.ShouldProcess(this.ResourceGroupName, $"Enable EventGrid partner topic {partnerTopicName} in Resource Group {resourceGroupName}"))
            {
                PartnerTopic partnerTopic = this.Client.ActivatePartnerTopic(resourceGroupName, partnerTopicName);
                PSPartnerTopic psPartnerTopic = new PSPartnerTopic(partnerTopic);
                this.WriteObject(psPartnerTopic);
            }
        }
    }
}
