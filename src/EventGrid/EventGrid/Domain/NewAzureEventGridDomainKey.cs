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
using Microsoft.Azure.Management.EventGrid.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.EventGrid
{
    [Cmdlet(
        VerbsCommon.New,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventGridDomainKey",
        DefaultParameterSetName = DomainNameParameterSet,
        SupportsShouldProcess = true), 
    OutputType(typeof(PsDomainSharedAccessKeys))]

    public class NewAzureEventGridDomainKey : AzureEventGridCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            ParameterSetName = DomainNameParameterSet,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Alias(AliasResourceGroup)]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            ParameterSetName = DomainNameParameterSet,
            HelpMessage = EventGridConstants.DomainNameHelp)]
        [ResourceNameCompleter("Microsoft.EventGrid/domains", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string DomainName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            ParameterSetName = DomainNameParameterSet,
            HelpMessage = EventGridConstants.KeyNameHelp)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = EventGridConstants.KeyNameHelp,
            ParameterSetName = DomainInputObjectParameterSet)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = EventGridConstants.KeyNameHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        [Alias(AliasKey)]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = EventGridConstants.DomainInputObjectHelp,
            ParameterSetName = DomainInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSDomain DomainInputObject { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.DomainResourceIdHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string DomainResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(this.DomainResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.DomainResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.DomainName = resourceIdentifier.ResourceName;
            }
            else if (this.DomainInputObject != null)
            {
                this.ResourceGroupName = this.DomainInputObject.ResourceGroupName;
                this.DomainName = this.DomainInputObject.DomainName;
            }

            if (this.ShouldProcess(this.DomainName, $"Regenerate key {this.Name} for domain {this.DomainName} in Resource Group {this.ResourceGroupName}"))
            {
                DomainSharedAccessKeys domainSharedAccessKeys = this.Client.RegenerateDomainKey(this.ResourceGroupName, this.DomainName, this.Name);
                PsDomainSharedAccessKeys psDomainSharedAccessKeys = new PsDomainSharedAccessKeys(domainSharedAccessKeys);
                this.WriteObject(psDomainSharedAccessKeys);
            }
        }
    }
}
