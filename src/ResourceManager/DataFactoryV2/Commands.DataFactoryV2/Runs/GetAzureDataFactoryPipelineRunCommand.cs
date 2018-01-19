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
using System.Security.Permissions;
using Microsoft.Azure.Commands.DataFactoryV2.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    [Cmdlet(VerbsCommon.Get, Constants.PipelineRun, DefaultParameterSetName = ParameterSetNames.ByFactoryNameByRunId),
        OutputType(typeof(List<PSPipelineRun>), typeof(PSPipelineRun))]
    public class GetAzureDataFactoryPipelineRunCommand : DataFactoryBaseCmdlet
    {
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryObjectByRunId, Position = 0, Mandatory = true, ValueFromPipeline = true,
            HelpMessage = Constants.HelpFactoryObject)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryObjectByPipeline, Position = 0, Mandatory = true, ValueFromPipeline = true,
            HelpMessage = Constants.HelpFactoryObject)]
        [ValidateNotNullOrEmpty]
        public PSDataFactory DataFactory { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryNameByRunId, Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpResourceGroup)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryNameByPipeline, Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpResourceGroup)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryNameByRunId, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpFactoryName)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryNameByPipeline, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpFactoryName)]
        [ValidateNotNullOrEmpty]
        public string DataFactoryName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryObjectByRunId, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpPipelineRunId)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryNameByRunId, Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpPipelineRunId)]
        [ValidateNotNullOrEmpty]
        public string PipelineRunId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryObjectByPipeline, Position = 1, Mandatory = true,
            HelpMessage = Constants.HelpRunUpdatedAfter)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryNameByPipeline, Position = 2, Mandatory = true,
            HelpMessage = Constants.HelpRunUpdatedAfter)]
        [ValidateNotNullOrEmpty]
        public DateTime LastUpdatedAfter { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryObjectByPipeline, Position = 2, Mandatory = true,
            HelpMessage = Constants.HelpRunUpdatedBefore)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryNameByPipeline, Position = 3, Mandatory = true,
            HelpMessage = Constants.HelpRunUpdatedBefore)]
        [ValidateNotNullOrEmpty]
        public DateTime LastUpdatedBefore { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryObjectByPipeline, Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpPipelineName)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryNameByPipeline, Position = 4, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpPipelineName)]
        [ValidateNotNullOrEmpty]
        public string PipelineName { get; set; }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ParameterSetNames.ByFactoryObjectByRunId, StringComparison.OrdinalIgnoreCase)
                || ParameterSetName.Equals(ParameterSetNames.ByFactoryObjectByPipeline, StringComparison.OrdinalIgnoreCase))
            {
                DataFactoryName = DataFactory.DataFactoryName;
                ResourceGroupName = DataFactory.ResourceGroupName;
            }

            if (ParameterSetName.Equals(ParameterSetNames.ByFactoryObjectByRunId, StringComparison.OrdinalIgnoreCase) ||
                ParameterSetName.Equals(ParameterSetNames.ByFactoryNameByRunId, StringComparison.OrdinalIgnoreCase))
            {
                WriteObject(DataFactoryClient.GetPipelineRun(ResourceGroupName, DataFactoryName, PipelineRunId));
            }
            else
            {
                PipelineRunFilterOptions runFilter = new PipelineRunFilterOptions
                {
                    ResourceGroupName = ResourceGroupName,
                    DataFactoryName = DataFactoryName,
                    PipelineName = PipelineName,
                    LastUpdatedAfter = LastUpdatedAfter,
                    LastUpdatedBefore = LastUpdatedBefore
                };
                WriteObject(DataFactoryClient.ListPipelineRuns(runFilter));
            }
        }
    }
}
