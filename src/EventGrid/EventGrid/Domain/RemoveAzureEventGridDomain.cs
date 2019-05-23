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
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventGridDomain",
        DefaultParameterSetName = DomainNameParameterSet,
        SupportsShouldProcess = true),
    OutputType(typeof(bool))]

    public class RemoveAzureEventGridDomain : AzureEventGridCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = DomainNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Alias(AliasResourceGroup)]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = EventGridConstants.DomainNameHelp,
            ParameterSetName = DomainNameParameterSet)]
        [ResourceNameCompleter("Microsoft.EventGrid/domains", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        [Alias("DomainName")]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = EventGridConstants.DomainResourceIdHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = EventGridConstants.DomainInputObjectHelp,
            ParameterSetName = DomainInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSDomain InputObject { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ShouldProcess(this.Name, $"Remove domain {this.Name} in resource group {this.ResourceGroupName}"))
            {
                string resourceGroupName = string.Empty;
                string domainName = string.Empty;

                if (!string.IsNullOrEmpty(this.Name))
                {
                    resourceGroupName = this.ResourceGroupName;
                    domainName = this.Name;
                }
                else if (!string.IsNullOrEmpty(this.ResourceId))
                {
                    EventGridUtils.GetResourceGroupNameAndDomainName(this.ResourceId, out resourceGroupName, out domainName);
                }
                else if (this.InputObject != null)
                {
                    resourceGroupName = this.InputObject.ResourceGroupName;
                    domainName = this.InputObject.DomainName;
                }

                this.Client.DeleteDomain(resourceGroupName, domainName);
                if (this.PassThru)
                {
                    this.WriteObject(true);
                }
            }
        }
    }
}
