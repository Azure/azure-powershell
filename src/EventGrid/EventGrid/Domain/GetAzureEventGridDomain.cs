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
            Position = 0,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = DomainNameParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Alias(AliasResourceGroup)]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
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
            Position = 0,
            HelpMessage = EventGridConstants.DomainResourceIdHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.ODataQueryHelp,
            ParameterSetName = DomainNameParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.ODataQueryHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.ODataQueryHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ODataQuery { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.TopHelp,
            ParameterSetName = DomainNameParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.TopHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.TopHelp,
            ParameterSetName = ResourceIdEventSubscriptionParameterSet)]
        [ValidateRange(1, 100)]
        public int Top { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.NextLinkHelp,
            ParameterSetName = NextLinkParameterSet)]
        [ValidateNotNullOrEmpty]
        public string NextLink { get; set; }

        public override void ExecuteCmdlet()
        {
            IEnumerable<Domain> domainsList;
            string newNextLink = null;
            int? providedTop = null;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(this.Top)))
            {
                providedTop = this.Top;
            }

            if (!string.IsNullOrEmpty(this.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.Name = resourceIdentifier.ResourceName;
            }

            // Other parameters should be null or ignored if this.NextLink is specified.
            if (!string.IsNullOrEmpty(this.NextLink))
            {
                // Get Next page of domains. Get the proper next API to be called based on the nextLink.
                Uri uri = new Uri(this.NextLink);
                string path = uri.AbsolutePath;

                if (path.IndexOf("/resourceGroups/", StringComparison.OrdinalIgnoreCase) != -1)
                {
                    (domainsList, newNextLink) = this.Client.ListDomainsByResourceGroupNext(this.NextLink);
                }
                else
                {
                    (domainsList, newNextLink) = this.Client.ListDomainBySubscriptionNext(this.NextLink);
                }

                PSDomainListPagedInstance pSDomainListPagedInstance = new PSDomainListPagedInstance(domainsList, newNextLink);
                this.WriteObject(pSDomainListPagedInstance, true);
            }
            else if (!string.IsNullOrEmpty(this.ResourceGroupName) && !string.IsNullOrEmpty(this.Name))
            {
                // Get details of the Event Grid domain
                Domain domain = this.Client.GetDomain(this.ResourceGroupName, this.Name);
                PSDomain psDomain = new PSDomain(domain);
                this.WriteObject(psDomain);
            }
            else if (!string.IsNullOrEmpty(this.ResourceGroupName) && string.IsNullOrEmpty(this.Name))
            {
                // List all Event Grid domains in the given resource group
                (domainsList, newNextLink) = this.Client.ListDomainsByResourceGroup(this.ResourceGroupName, this.ODataQuery, providedTop);
                PSDomainListPagedInstance pSDomainListPagedInstance = new PSDomainListPagedInstance(domainsList, newNextLink);
                this.WriteObject(pSDomainListPagedInstance, true);
            }
            else if (string.IsNullOrEmpty(this.ResourceGroupName) && string.IsNullOrEmpty(this.Name))
            {
                // List all Event Grid domains in the given subscription
                (domainsList, newNextLink) = this.Client.ListDomainsBySubscription(this.ODataQuery, providedTop);
                PSDomainListPagedInstance pSDomainListPagedInstance = new PSDomainListPagedInstance(domainsList, newNextLink);
                this.WriteObject(pSDomainListPagedInstance, true);
            }
        }
    }
}
