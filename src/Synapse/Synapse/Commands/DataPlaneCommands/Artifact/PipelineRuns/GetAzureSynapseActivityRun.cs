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

using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.ActivityRun,
        DefaultParameterSetName = GetByName)]
    [OutputType(typeof(PSActivityRunsQueryResponse))]
    public class GetAzureSynapseActivityRun : SynapseArtifactsCmdletBase
    {
        private const string GetByName = "GetByName";
        private const string GetByObject = "GetByObject";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = GetByObject,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true, HelpMessage = HelpMessages.PipelineName)]
        [ValidateNotNullOrEmpty]
        public string PipelineName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true, HelpMessage = HelpMessages.RunId)]
        [ValidateNotNullOrEmpty]
        public string PipelineRunId { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true, HelpMessage = HelpMessages.LastUpdatedAfter)]
        [ValidateNotNullOrEmpty]
        public DateTimeOffset RunStartedAfter { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true, HelpMessage = HelpMessages.LastUpdatedBefore)]
        [ValidateNotNullOrEmpty]
        public DateTimeOffset RunStartedBefore { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.ActivityName)]
        [ValidateNotNullOrEmpty]
        public string ActivityName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.RunStatus)]
        [ValidateNotNullOrEmpty]
        public string Status { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            RunFilterParameters filter = new RunFilterParameters(this.RunStartedAfter, this.RunStartedBefore);

            if (this.IsParameterBound(c => c.ActivityName))
            {
                filter.Filters.Add(new RunQueryFilter(RunQueryFilterOperand.ActivityName, RunQueryFilterOperator.EqualsValue, new List<string>() { this.ActivityName }));
            }

            if (this.IsParameterBound(c => c.Status))
            {
                filter.Filters.Add(new RunQueryFilter(RunQueryFilterOperand.Status, RunQueryFilterOperator.EqualsValue, new List<string>() { this.Status }));
            }

            WriteObject(SynapseAnalyticsClient.GetActivityRuns(this.PipelineName, this.PipelineRunId, filter)
                .Select(element => new PSActivityRunsQueryResponse(element)));
        }
    }
}
