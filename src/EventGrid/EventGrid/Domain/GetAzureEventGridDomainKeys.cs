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

namespace Microsoft.Azure.Commands.EventGrid
{
    [Cmdlet(
        VerbsCommon.Get,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventGridDomainKey",
        DefaultParameterSetName = DomainNameParameterSet),
    OutputType(typeof(PsDomainSharedAccessKeys))]

    public class GetAzureEventGridDomainKeys : AzureEventGridCmdletBase
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
        [Alias("DomainName")]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = EventGridConstants.DomainInputObjectHelp,
            ParameterSetName = DomainInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSDomain DomainObject { get; set; }

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
            string resourceGroupName;
            string domainName;

            if (!string.IsNullOrEmpty(this.DomainResourceId))
            {
                EventGridUtils.GetResourceGroupNameAndDomainName(this.DomainResourceId, out resourceGroupName, out domainName);
            }
            else if (this.DomainObject != null)
            {
                resourceGroupName = this.DomainObject.ResourceGroupName;
                domainName = this.DomainObject.DomainName;
            }
            else
            {
                resourceGroupName = this.ResourceGroupName;
                domainName = this.Name;
            }

            DomainSharedAccessKeys domainSharedAccessKeys = this.Client.GetDomainSharedAccessKeys(resourceGroupName, domainName);
            PsDomainSharedAccessKeys psDomainSharedAccessKeys = new PsDomainSharedAccessKeys(domainSharedAccessKeys);
            this.WriteObject(psDomainSharedAccessKeys);
        }
    }
}
