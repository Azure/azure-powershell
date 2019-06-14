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
    /// 'Get-AzureRmEventGridDomainTopic' Cmdlet gives the details of a / List of EventGrid domain topic(s)
    /// <para> If Domain topic name is provided, a single Domain topic details will be returned</para>
    /// <para> If Domain topic name is not provided, list of all Domain topics under a domain will be returned</para>
    /// </summary>
    [Cmdlet(
        VerbsCommon.Get,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventGridDomainTopic",
        DefaultParameterSetName = DomainTopicNameParameterSet),
    OutputType(typeof(PSDomainTopic),
    typeof(PSDomainTopicListInstance))]

    public class GetAzureEventGridDomainTopic : AzureEventGridCmdletBase
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = DomainTopicNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Alias(AliasResourceGroup)]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            HelpMessage = EventGridConstants.DomainNameHelp,
            ParameterSetName = DomainTopicNameParameterSet)]
        [ResourceNameCompleter("Microsoft.EventGrid/domains", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        [Alias(AliasDomain)]
        public string DomainName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.DomainTopicNameHelp,
            ParameterSetName = DomainTopicNameParameterSet)]
        [ResourceNameCompleter("Microsoft.EventGrid/domains/topics", nameof(ResourceGroupName), nameof(DomainName))]
        [ValidateNotNullOrEmpty]
        [Alias(AliasDomainTopicName)]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.DomainOrDomainTopicResourceIdHelp,
            ParameterSetName = ResourceIdDomainTopicParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.ODataQueryHelp,
            ParameterSetName = DomainTopicNameParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.ODataQueryHelp,
            ParameterSetName = ResourceIdDomainTopicParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ODataQuery { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.ODataQueryHelp,
            ParameterSetName = DomainTopicNameParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = EventGridConstants.ODataQueryHelp,
            ParameterSetName = ResourceIdDomainTopicParameterSet)]
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
            string resourceGroupName = string.Empty;
            string domainName = string.Empty;
            string domainTopicName = string.Empty;
            string newNextLink = null;
            IEnumerable<DomainTopic> domainTopicsList;
            List <PSDomainTopicListInstance> psDomainTopicsList = new List<PSDomainTopicListInstance>();
            int? providedTop = null;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(this.Top)))
            {
                providedTop = this.Top;
            }

            if (!string.IsNullOrEmpty(this.ResourceId))
            {
                EventGridUtils.GetResourceGroupNameAndDomainNameAndDomainTopicName(this.ResourceId, out resourceGroupName, out domainName, out domainTopicName);
            }
            else
            {
                resourceGroupName = this.ResourceGroupName;
                domainName = this.DomainName;
                domainTopicName = this.Name;
            }

            // Other parameters should be null or ignored if this.NextLink is specified.
            if (!string.IsNullOrEmpty(this.NextLink))
            {
                // Get Next page of domain topics.
                (domainTopicsList, newNextLink) = this.Client.ListDomainTopicsByDomainNext(this.NextLink);

                PSDomainTopicListPagedInstance pSDomainTopicListPagedInstance = new PSDomainTopicListPagedInstance(domainTopicsList, newNextLink);
                this.WriteObject(pSDomainTopicListPagedInstance, true);
            }
            else if (!string.IsNullOrEmpty(resourceGroupName) && !string.IsNullOrEmpty(domainName))
            {
                if (!string.IsNullOrEmpty(domainTopicName))
                {
                    // Get details of the Event Grid domain topic
                    DomainTopic domainTopic = this.Client.GetDomainTopic(resourceGroupName, domainName, domainTopicName);
                    PSDomainTopic psDomainTopic = new PSDomainTopic(domainTopic);
                    this.WriteObject(psDomainTopic);
                }
                else
                {
                    // List all Event Grid domain topics in the given resource group/domain
                    (domainTopicsList, newNextLink) = this.Client.ListDomainTopicsByDomain(resourceGroupName, domainName, this.ODataQuery, providedTop);
                    PSDomainTopicListPagedInstance pSDomainTopicListPagedInstance = new PSDomainTopicListPagedInstance(domainTopicsList, newNextLink);
                    this.WriteObject(pSDomainTopicListPagedInstance, true);
                }
            }
        }
    }
}
