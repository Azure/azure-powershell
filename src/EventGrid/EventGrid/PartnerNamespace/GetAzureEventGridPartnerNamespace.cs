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
using System.Text;
using System.Management.Automation;
using Microsoft.Azure.Commands.EventGrid.Models;
using Microsoft.Azure.Management.EventGrid.Models;
using Microsoft.Azure.Commands.EventGrid.Utilities;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.EventGrid
{
    /// <summary>
    /// 'Get-AzureEventGridPartnerNamespace' Cmdlet gives the details of a / List of EventGrid partner registration(s)
    /// <para> If PartnerNamespace name provided, a single PartnerNamespace details will be returned</para>
    /// <para> If PartnerNamespace name not provided, list of PartnerNamespaces will be returned</para>
    /// </summary>

    [Cmdlet(
        "Get",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventGridPartnerNamespace",
        DefaultParameterSetName = PartnerNamespaceListBySubscriptionParameterSet),
    OutputType(typeof(PSPartnerNamespaceListInstance), typeof(PSPartnerNamespace))]

    public class GetAzureEventGridPartnerNamespace : AzureEventGridCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = PartnerNamespaceNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Alias(AliasResourceGroup)]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.PartnerNamespaceNameHelp,
            ParameterSetName = PartnerNamespaceNameParameterSet)]
        [ResourceNameCompleter("Microsoft.EventGrid/partnerNamespaces", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        [Alias("PartnerNamespaceName")]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ODataQueryHelp,
            ParameterSetName = PartnerNamespaceListBySubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ODataQuery { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.TopHelp,
            ParameterSetName = PartnerNamespaceListBySubscriptionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [ValidateRange(1, 100)]
        public int? Top { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.NextLinkHelp,
            ParameterSetName = NextLinkParameterSet)]
        [ValidateNotNullOrEmpty]
        public string NextLink { get; set; }

        public override void ExecuteCmdlet()
        {
            string resourceGroupName = string.Empty;
            IEnumerable<PartnerNamespace> partnerNamespacesList;
            string newNextLink = null;
            string partnerNamespaceName = null;
            int? providedTop = null;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(this.Top)))
            {
                providedTop = this.Top;
            }

            if (!string.IsNullOrEmpty(this.ResourceGroupName))
            {
                resourceGroupName = this.ResourceGroupName;
            }

            if (!string.IsNullOrEmpty(this.Name))
            {
                partnerNamespaceName = this.Name;
            }

            if (!string.IsNullOrEmpty(this.NextLink))
            {
                // Get next page of partner namespaces
                Uri uri = new Uri(this.NextLink);
                string path = uri.AbsolutePath;

                if (path.IndexOf("/resourceGroups/", StringComparison.OrdinalIgnoreCase) != -1)
                {
                    (partnerNamespacesList, newNextLink) = this.Client.ListPartnerNamespaceByResourceGroupNext(this.NextLink);
                }
                else
                {
                    (partnerNamespacesList, newNextLink) = this.Client.ListPartnerNamespaceBySubscriptionNext(this.NextLink);
                }

                PSPartnerNamespaceListPagedInstance psPartnerNamespaceListPagedInstance = new PSPartnerNamespaceListPagedInstance(partnerNamespacesList, newNextLink);
                this.WriteObject(psPartnerNamespaceListPagedInstance, true);
            }
            else if (!string.IsNullOrEmpty(resourceGroupName) && !string.IsNullOrEmpty(partnerNamespaceName))
            {
                // Get details of a partner namespace
                PartnerNamespace partnerNamespace = this.Client.GetPartnerNamespace(resourceGroupName, partnerNamespaceName);
                PSPartnerNamespace psPartnerConfigutation = new PSPartnerNamespace(partnerNamespace);
                this.WriteObject(psPartnerConfigutation);
            }
            else if (!string.IsNullOrEmpty(resourceGroupName) && string.IsNullOrEmpty(partnerNamespaceName))
            {
                // List partner namespaces at resource group scope
                (partnerNamespacesList, newNextLink) = this.Client.ListPartnerNamespaceByResourceGroup(resourceGroupName, this.ODataQuery, providedTop);
                PSPartnerNamespaceListPagedInstance psPartnerNamespaceListPagedInstance = new PSPartnerNamespaceListPagedInstance(partnerNamespacesList, newNextLink);
                this.WriteObject(psPartnerNamespaceListPagedInstance, true);
            }
            else if (string.IsNullOrEmpty(resourceGroupName))
            {
                // List all partner namespaces in the current subscription
                (partnerNamespacesList, newNextLink) = this.Client.ListPartnerNamespaceBySubscription(this.ODataQuery, providedTop);
                PSPartnerNamespaceListPagedInstance psPartnerNamespaceListPagedInstance = new PSPartnerNamespaceListPagedInstance(partnerNamespacesList, newNextLink);
                this.WriteObject(psPartnerNamespaceListPagedInstance, true);
            }
        }
    }

}