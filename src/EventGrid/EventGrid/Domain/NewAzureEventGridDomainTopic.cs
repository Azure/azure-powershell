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
        VerbsCommon.New,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventGridDomainTopic",
        SupportsShouldProcess = true,
        DefaultParameterSetName = DomainTopicNameParameterSet),
    OutputType(typeof(PSDomainTopic))]

    public class NewAzureEventGridDomainTopic : AzureEventGridCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = DomainTopicNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Alias(AliasResourceGroup)]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = EventGridConstants.DomainNameHelp,
            ParameterSetName = DomainTopicNameParameterSet)]
        [ResourceNameCompleter("Microsoft.EventGrid/domains", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        [Alias("Domain")]
        public string DomainName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = EventGridConstants.DomainTopicNameHelp,
            ParameterSetName = DomainTopicNameParameterSet)]
        [ResourceNameCompleter("Microsoft.EventGrid/domains/topics", nameof(ResourceGroupName), nameof(DomainName))]
        [ValidateNotNullOrEmpty]
        [Alias("DomainTopicName")]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            // Create a new Event Grid Domain Topic
            if (this.ShouldProcess(this.Name, $"Create a new EventGrid domain topic under domain {this.DomainName} in Resource Group {this.ResourceGroupName}"))
            {
                DomainTopic domainTopic = this.Client.CreateDomainTopic(this.ResourceGroupName, this.DomainName, this.Name);
                PSDomainTopic psDomainTopic = new PSDomainTopic(domainTopic);
                this.WriteObject(psDomainTopic);
            }
        }
    }
}