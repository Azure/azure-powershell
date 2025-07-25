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

using Microsoft.Azure.Commands.OperationalInsights.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.OperationalInsights
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "OperationalInsightsWorkspace", DefaultParameterSetName = ByName), OutputType(typeof(PSWorkspace))]
    public class SetAzureOperationalInsightsWorkspaceCommand : OperationalInsightsBaseCmdlet
    {
        [Parameter(Position = 0, ParameterSetName = ByObject, Mandatory = true, ValueFromPipeline = true,
            HelpMessage = "The workspace.")]
        [ValidateNotNull]
        public PSWorkspace Workspace { get; set; }

        [Parameter(Position = 1, ParameterSetName = ByName, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 2, ParameterSetName = ByName, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The workspace name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The service tier of the workspace.")]
        [ValidateSet("free", "standard", "premium", "pernode", "standalone", "pergb2018", "capacityreservation", "lacluster", IgnoreCase = true)]
        public string Sku { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Sku Capacity, value need to be multiple of 100 and above 0.")]
        [ValidateNotNullOrEmpty]
        public int? SkuCapacity { get; set; }

        [Parameter(Position = 4, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource tags for the workspace.")]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The workspace data retention in days. 730 days is the maximum allowed for all other Skus.")]
        [ValidateNotNullOrEmpty]
        public int? RetentionInDays { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "The network access type for accessing workspace ingestion. Value should be 'Enabled' or 'Disabled'")]
        public string PublicNetworkAccessForIngestion;

        [Parameter(Mandatory = false,
            HelpMessage = "The network access type for accessing workspace query. Value should be 'Enabled' or 'Disabled'")]
        public string PublicNetworkAccessForQuery;

        [Parameter(Mandatory = false, HelpMessage = "The daily volume cap for ingestion - number")]
        public int? DailyQuotaGb;

        [Parameter(Position = 9, Mandatory = false,
            HelpMessage = "Gets or sets indicates whether customer managed storage is mandatory for query management")]
        public bool? ForceCmkForQuery;

        [Parameter(Position = 10, Mandatory = false,
            HelpMessage = "Allow to opt-out of local authentication and ensure customers can use only MSI and AAD for exclusive authentication")]
        public bool? DisableLocalAuth;

        [Parameter(Mandatory = false, HelpMessage = "The resource ID of the default Data Collection Rule to use for this workspace. Expected format is - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Insights/dataCollectionRules/{dcrName}.")]
        public string DefaultDataCollectionRuleResourceId;

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ByObject)
            {
                ResourceGroupName = Workspace.ResourceGroupName;
                Name = Workspace.Name;
            }

            UpdatePSWorkspaceParameters parameters = new UpdatePSWorkspaceParameters
            {
                ResourceGroupName = ResourceGroupName,
                WorkspaceName = Name,
                Sku = string.IsNullOrEmpty(Sku) ? null : new PSWorkspaceSku(Sku, SkuCapacity),
                Tags = Tag,
                PublicNetworkAccessForIngestion = this.PublicNetworkAccessForIngestion,
                PublicNetworkAccessForQuery = this.PublicNetworkAccessForQuery,
                RetentionInDays = RetentionInDays,
                DailyQuotaGb = DailyQuotaGb,
                ForceCmkForQuery = ForceCmkForQuery,
                WsFeatures = new PSWorkspaceFeatures(DisableLocalAuth),
                DefaultDataCollectionRuleResourceId = DefaultDataCollectionRuleResourceId
            };

            WriteObject(OperationalInsightsClient.UpdatePSWorkspace(parameters));
        }
    }
}
