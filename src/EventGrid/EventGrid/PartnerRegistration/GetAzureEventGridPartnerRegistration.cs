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
    /// 'Get-AzureEventGridPartnerRegistration' Cmdlet gives the details of a / List of EventGrid partner registration(s)
    /// <para> If PartnerRegistration name provided, a single PartnerRegistration details will be returned</para>
    /// <para> If PartnerRegistration name not provided, list of PartnerRegistrations will be returned</para>
    /// </summary>

    [Cmdlet(
        "Get",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventGridPartnerRegistration",
        DefaultParameterSetName = ResourceGroupNameParameterSet),
    OutputType(typeof(PSPartnerRegistrationListInstance), typeof(PSPartnerRegistration))]

    public class GetAzureEventGridPartnerRegistration : AzureEventGridCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = PartnerRegistrationNameParameterSet)]
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
            HelpMessage = EventGridConstants.PartnerRegistrationNameHelp,
            ParameterSetName = PartnerRegistrationNameParameterSet)]
        [ResourceNameCompleter("Microsoft.EventGrid/partnerRegistrations", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        [Alias("PartnerRegistrationName")]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ODataQueryHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ODataQuery { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.TopHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
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
            IEnumerable<PartnerRegistration> partnerRegistrationsList;
            string newNextLink = null;
            string partnerRegistrationName = null;
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
                partnerRegistrationName = this.Name;
            }

            if (!string.IsNullOrEmpty(this.NextLink))
            {
                // Get next page of partner registrations
                Uri uri = new Uri(this.NextLink);
                string path = uri.AbsolutePath;

                if (path.IndexOf("/resourceGroups/", StringComparison.OrdinalIgnoreCase) != -1)
                {
                    (partnerRegistrationsList, newNextLink) = this.Client.ListPartnerRegistrationsByResourceGroupNext(this.NextLink);
                }
                else
                {
                    (partnerRegistrationsList, newNextLink) = this.Client.ListPartnerRegistrationsBySubscriptionNext(this.NextLink);
                }

                PSPartnerRegistrationListPagedInstance psPartnerRegistrationListPagedInstance = new PSPartnerRegistrationListPagedInstance(partnerRegistrationsList, newNextLink);
                this.WriteObject(psPartnerRegistrationListPagedInstance, true);
            }
            else if (!string.IsNullOrEmpty(resourceGroupName) && !string.IsNullOrEmpty(partnerRegistrationName))
            {
                // Get details of a partner registration
                PartnerRegistration partnerRegistration = this.Client.GetPartnerRegistration(resourceGroupName, partnerRegistrationName);
                PSPartnerRegistration psPartnerConfigutation = new PSPartnerRegistration(partnerRegistration);
                this.WriteObject(psPartnerConfigutation);
            }
            else if (!string.IsNullOrEmpty(resourceGroupName) && string.IsNullOrEmpty(partnerRegistrationName))
            {
                // List partner registers at resource group scope
                (partnerRegistrationsList, newNextLink) = this.Client.ListPartnerRegistrationsByResourceGroup(resourceGroupName, this.ODataQuery, providedTop);
                PSPartnerRegistrationListPagedInstance psPartnerRegistrationListPagedInstance = new PSPartnerRegistrationListPagedInstance(partnerRegistrationsList, newNextLink);
                this.WriteObject(psPartnerRegistrationListPagedInstance, true);
            }
            else if (string.IsNullOrEmpty(resourceGroupName))
            {
                // List all partner registrations in the current subscription
                (partnerRegistrationsList, newNextLink) = this.Client.ListPartnerRegistrationsBySubscription(this.ODataQuery, providedTop);
                PSPartnerRegistrationListPagedInstance psPartnerRegistrationListPagedInstance = new PSPartnerRegistrationListPagedInstance(partnerRegistrationsList, newNextLink);
                this.WriteObject(psPartnerRegistrationListPagedInstance, true);
            }
        }
    }

}