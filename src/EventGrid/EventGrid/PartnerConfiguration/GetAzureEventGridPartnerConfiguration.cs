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
    /// 'Get-AzureEventGridPartnerConfiguration' Cmdlet gives the details of a / List of EventGrid partner configuration(s)
    /// <para> If ResourceGroup name provided, a single PartnerConfiguration details will be returned</para>
    /// <para> If ResourceGroup name not provided, list of PartnerConfiguration will be returned</para>
    /// </summary>

    [Cmdlet(
        "Get",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventGridPartnerConfiguration",
        DefaultParameterSetName = ResourceGroupNameParameterSet),
    OutputType(typeof(PSPartnerConfigurationListInstance), typeof(PSPartnerConfiguration))]

    public class GetAzureEventGridPartnerConfiguration : AzureEventGridCmdletBase
    {
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        public string ResourceGroupName { get; set; }

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
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.NextLinkHelp,
            ParameterSetName = NextLinkParameterSet)]
        [ValidateNotNullOrEmpty]
        public string NextLink { get; set; }

        public override void ExecuteCmdlet()
        {
            string resourceGroupName = string.Empty;
            IEnumerable<PartnerConfiguration> partnerConfigurationsList;
            string newNextLink = null;
            int? providedTop = null;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(this.Top)))
            {
                providedTop = this.Top;
            }

            if (!string.IsNullOrEmpty(this.ResourceGroupName))
            {
                resourceGroupName = this.ResourceGroupName;
            }

            if (!string.IsNullOrEmpty(this.NextLink))
            {
                // Get next page of partner configurations
                Uri uri = new Uri(this.NextLink);
                string path = uri.AbsolutePath;

                (partnerConfigurationsList, newNextLink) = this.Client.ListPartnerConfigurationNext(this.NextLink);
                PSPartnerConfigurationListPagedInstance psPartnerConfigurationListPagedInstance = new PSPartnerConfigurationListPagedInstance(partnerConfigurationsList, newNextLink);
                this.WriteObject(psPartnerConfigurationListPagedInstance, true);
            }
            else if (!string.IsNullOrEmpty(resourceGroupName))
            {
                // Get details of a partner configuration for a resource group
                PartnerConfiguration partnerConfiguration = this.Client.GetPartnerConfiguration(resourceGroupName);
                PSPartnerConfiguration psPartnerConfigutation = new PSPartnerConfiguration(partnerConfiguration);
                this.WriteObject(psPartnerConfigutation);
            }
            else if (string.IsNullOrEmpty(resourceGroupName))
            {
                // List all partner configurations in the current subscription
                (partnerConfigurationsList, newNextLink) = this.Client.ListPartnerConfigurationsBySubscription(this.ODataQuery, providedTop);
                PSPartnerConfigurationListPagedInstance psPartnerConfigurationListPagedInstance = new PSPartnerConfigurationListPagedInstance(partnerConfigurationsList, newNextLink);
                this.WriteObject(psPartnerConfigurationListPagedInstance, true);
            }
        }
    }

}