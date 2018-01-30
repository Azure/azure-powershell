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

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    [Cmdlet(VerbsCommon.Get, Constants.ActivityRun, DefaultParameterSetName = ParameterSetNames.ByFactoryName),
        OutputType(typeof(List<PSActivityRun>), typeof(PSActivityRun))]
    public class GetAzureDataFactoryActivityRunCommand : DataFactoryContextBaseCmdlet
    {
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryObject, Position = 1, Mandatory = true,
            HelpMessage = Constants.HelpPipelineRunId)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryName, Position = 2, Mandatory = true,
            HelpMessage = Constants.HelpPipelineRunId)]
        [ValidateNotNullOrEmpty]
        public string PipelineRunId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryObject, Position = 2, Mandatory = true,
            HelpMessage = Constants.HelpRunStartedAfter)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryName, Position = 3, Mandatory = true,
            HelpMessage = Constants.HelpRunStartedAfter)]
        [ValidateNotNullOrEmpty]
        public DateTime RunStartedAfter { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryObject, Position = 3, Mandatory = true,
            HelpMessage = Constants.HelpRunStartedBefore)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryName, Position = 4, Mandatory = true,
            HelpMessage = Constants.HelpRunStartedBefore)]
        [ValidateNotNullOrEmpty]
        public DateTime RunStartedBefore { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryObject, Position = 4, Mandatory = false,
            HelpMessage = Constants.HelpActivityName)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryName, Position = 5, Mandatory = false,
            HelpMessage = Constants.HelpActivityName)]
        [ValidateNotNullOrEmpty]
        public string ActivityName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryObject, Position = 5, Mandatory = false,
            HelpMessage = Constants.HelpRunStatus)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryName, Position = 6, Mandatory = false,
            HelpMessage = Constants.HelpRunStatus)]
        [ValidateNotNullOrEmpty]
        public string Status { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryObject, Position = 6, Mandatory = false,
            HelpMessage = Constants.HelpLinkedServiceName)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryName, Position = 7, Mandatory = false,
            HelpMessage = Constants.HelpLinkedServiceName)]
        [ValidateNotNullOrEmpty]
        public string LinkedServiceName { get; set; }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override void ExecuteCmdlet()
        {
            ByFactoryObject();

            ActivityRunFilterOptions activityRunFilter = new ActivityRunFilterOptions
            {
                ResourceGroupName = ResourceGroupName,
                DataFactoryName = DataFactoryName,
                PipelineRunId = PipelineRunId,
                RunStartedAfter = RunStartedAfter,
                RunStartedBefore = RunStartedBefore,
                ActivityName = ActivityName,
                LinkedServiceName = LinkedServiceName,
                Status = Status
            };
            WriteObject(DataFactoryClient.ListActivityRuns(activityRunFilter));
        }
    }
}
