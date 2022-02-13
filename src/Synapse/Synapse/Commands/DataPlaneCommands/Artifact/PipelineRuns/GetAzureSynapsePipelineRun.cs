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
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.PipelineRun,
        DefaultParameterSetName = GetByNameAndId)]
    [OutputType(typeof(PSPipelineRun))]
    public class GetAzureSynapsePipelineRun : SynapseArtifactsCmdletBase
    {
        private const string GetByNameAndId = "GetByNameAndId";
        private const string GetByObjectAndId = "GetByObjectAndId";
        private const string GetByNameAndTime = "GetByNameAndTime";
        private const string GetByObjectAndTime = "GetByObjectAndTime";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByNameAndId,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByNameAndTime,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = GetByObjectAndId,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [Parameter(ValueFromPipeline = true, ParameterSetName = GetByObjectAndTime,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true, ParameterSetName = GetByNameAndId,
            HelpMessage = HelpMessages.RunId)]
        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true, ParameterSetName = GetByObjectAndId,
            HelpMessage = HelpMessages.RunId)]
        [ValidateNotNullOrEmpty]
        public string PipelineRunId { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true, ParameterSetName = GetByNameAndTime,
            HelpMessage = HelpMessages.LastUpdatedAfter)]
        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true, ParameterSetName = GetByObjectAndTime,
            HelpMessage = HelpMessages.LastUpdatedAfter)]
        [ValidateNotNullOrEmpty]
        public DateTimeOffset RunStartedAfter { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true, ParameterSetName = GetByNameAndTime,
            HelpMessage = HelpMessages.LastUpdatedBefore)]
        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true, ParameterSetName = GetByObjectAndTime,
            HelpMessage = HelpMessages.LastUpdatedBefore)]
        [ValidateNotNullOrEmpty]
        public DateTimeOffset RunStartedBefore { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, ParameterSetName = GetByNameAndTime,
            HelpMessage = HelpMessages.PipelineName)]
        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, ParameterSetName = GetByObjectAndTime,
            HelpMessage = HelpMessages.PipelineName)]
        [ValidateNotNullOrEmpty]
        public string PipelineName { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            if (this.IsParameterBound(c => c.PipelineRunId))
            {
                WriteObject(new PSPipelineRun(SynapseAnalyticsClient.GetPipelineRun(this.PipelineRunId), this.WorkspaceName));
            }
            else
            {
                RunFilterParameters filter = new RunFilterParameters(this.RunStartedAfter, this.RunStartedBefore);
                if (this.IsParameterBound(c => c.PipelineName))
                {
                    filter.Filters.Add(new RunQueryFilter(RunQueryFilterOperand.PipelineName, RunQueryFilterOperator.EqualsValue, new List<string>() { this.PipelineName }));
                }
                WriteObject(SynapseAnalyticsClient.QueryPipelineRunsByWorkspace(filter)
                    .Select(element => new PSPipelineRun(element, this.WorkspaceName)),true);
            }
        }
    }
}
