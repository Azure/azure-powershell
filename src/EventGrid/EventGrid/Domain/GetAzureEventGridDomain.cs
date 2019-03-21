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

namespace Microsoft.Azure.Commands.EventGrid
{
    /// <summary>
    /// 'Get-AzureRmEventGridDomain' Cmdlet gives the details of a / List of EventGrid domain(s)
    /// <para> If Domain name provided, a single Domain details will be returned</para>
    /// <para> If Domain name not provided, list of Domains will be returned</para>
    /// </summary>

    [Cmdlet(
        VerbsCommon.Get,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventGridDomain",
        DefaultParameterSetName = ResourceGroupNameParameterSet),
    OutputType(typeof(PSDomain),
    typeof(PSDomainListInstance))]

    public class GetAzureEventGridDomain : AzureEventGridCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = DomainNameParameterSet)]
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
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = EventGridConstants.DomainNameHelp,
            ParameterSetName = DomainNameParameterSet)]
        [ValidateNotNullOrEmpty]
        [Alias("DomainName")]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.DomainResourceIdHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ODataQueryHelp,
            ParameterSetName = DomainNameParameterSet)]
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
            ParameterSetName = DomainNameParameterSet)]
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
            string resourceGroupName = string.Empty;
            string domainName = string.Empty;
            IEnumerable<Domain> domainsList;
            string nextLink = null;
            string newNextLink = null;

            if (!string.IsNullOrEmpty(this.ResourceId))
            {
                EventGridUtils.GetResourceGroupNameAndDomainName(this.ResourceId, out resourceGroupName, out domainName);
            }
            else if (!string.IsNullOrEmpty(this.Name))
            {
                // If Name is provided, ResourceGroup should be non-empty as well
                resourceGroupName = this.ResourceGroupName;
                domainName = this.Name;
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
                // Get Next page of domains. Get the proper next API to be called based on the nextLink.
                Uri uri = new Uri(nextLink);
                string path = uri.AbsolutePath;

                if (path.IndexOf("/resourceGroups/", StringComparison.OrdinalIgnoreCase) != -1)
                {
                    (domainsList, newNextLink) = this.Client.ListDomainsByResourceGroupNext(nextLink);
                }
                else
                {
                    (domainsList, newNextLink) = this.Client.ListDomainBySubscriptionNext(nextLink);
                }

                PSDomainListPagedInstance pSDomainListPagedInstance = new PSDomainListPagedInstance(domainsList, newNextLink);
                this.WriteObject(pSDomainListPagedInstance, true);
            }
            else if (!string.IsNullOrEmpty(resourceGroupName) && !string.IsNullOrEmpty(domainName))
            {
                // Get details of the Event Grid domain
                Domain domain = this.Client.GetDomain(resourceGroupName, domainName);
                PSDomain psDomain = new PSDomain(domain);
                this.WriteObject(psDomain);
            }
            else if (!string.IsNullOrEmpty(resourceGroupName) && string.IsNullOrEmpty(domainName))
            {
                // List all Event Grid domains in the given resource group
                (domainsList, newNextLink) = this.Client.ListDomainsByResourceGroup(resourceGroupName, this.ODataQuery, this.Top);
                PSDomainListPagedInstance pSDomainListPagedInstance = new PSDomainListPagedInstance(domainsList, newNextLink);
                this.WriteObject(pSDomainListPagedInstance, true);
            }
            else if (string.IsNullOrEmpty(resourceGroupName) && string.IsNullOrEmpty(domainName))
            {
                // List all Event Grid domains in the given subscription
                (domainsList, newNextLink) = this.Client.ListDomainsBySubscription(this.ODataQuery, this.Top);
                PSDomainListPagedInstance pSDomainListPagedInstance = new PSDomainListPagedInstance(domainsList, newNextLink);
                this.WriteObject(pSDomainListPagedInstance, true);
            }
        }
    }
}
