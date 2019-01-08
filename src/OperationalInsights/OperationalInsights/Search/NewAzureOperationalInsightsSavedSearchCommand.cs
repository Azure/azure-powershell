﻿// ----------------------------------------------------------------------------------
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
using System.Management.Automation;
using Microsoft.Azure.Management.OperationalInsights.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Net;

namespace Microsoft.Azure.Commands.OperationalInsights
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "OperationalInsightsSavedSearch", SupportsShouldProcess = true), OutputType(typeof(HttpStatusCode))]
    public class NewAzureOperationalInsightsSavedSearchCommand : OperationalInsightsBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("Name")]
        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The workspace name.")]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The saved search id.")]
        [ValidateNotNullOrEmpty]
        public string SavedSearchId { get; set; }

        [Parameter(Position = 3, Mandatory = true, ValueFromPipelineByPropertyName = true,
        HelpMessage = "The saved search display name.")]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter(Position = 4, Mandatory = true, ValueFromPipelineByPropertyName = true,
        HelpMessage = "The saved search category.")]
        [ValidateNotNullOrEmpty]
        public string Category { get; set; }

        [Parameter(Position = 5, Mandatory = true, ValueFromPipelineByPropertyName = true,
        HelpMessage = "The saved search query.")]
        [ValidateNotNullOrEmpty]
        public string Query { get; set; }

        [Parameter(Position = 6, Mandatory = false, ValueFromPipelineByPropertyName = true,
        HelpMessage = "The saved search tags.")]
        [ValidateNotNullOrEmpty]
        public Hashtable Tag { get; set; }

        [Parameter(Position = 7, Mandatory = false, ValueFromPipelineByPropertyName = true,
        HelpMessage = "The saved search version.")]
        [ValidateNotNullOrEmpty]
        public long Version { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Don't ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        protected override void ProcessRecord()
        {
            SavedSearch properties = new SavedSearch()
            {
                Category = this.Category,
                DisplayName = this.DisplayName,
                Query = this.Query,
                Version = this.Version
            };

            properties.Tags = SearchCommandHelper.PopulateAndValidateTagsForProperties(this.Tag, properties.Query);
            WriteObject(OperationalInsightsClient.CreateOrUpdateSavedSearch(ResourceGroupName, WorkspaceName, SavedSearchId, properties, Force, ConfirmAction), true);
        }

    }
}
