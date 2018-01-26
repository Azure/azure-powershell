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
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.DataFactoryV2.Models;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    [Cmdlet(VerbsLifecycle.Stop, Constants.PipelineRun, DefaultParameterSetName = ParameterSetNames.ByFactoryName, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class StopAzureDataFactoryPipelineRunCommand : DataFactoryContextBaseCmdlet
    {
        [Parameter(ParameterSetName = ParameterSetNames.ByInputObject, Position = 0, Mandatory = true, ValueFromPipeline = true,
            HelpMessage = Constants.HelpPipelineRun)]
        [ValidateNotNullOrEmpty]
        public PSPipelineRun InputObject { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryName, Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpPipelineRunId)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryObject, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpPipelineRunId)]
        [ValidateNotNullOrEmpty]
        public string PipelineRunId { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override void ExecuteCmdlet()
        {
            ByFactoryObject();
            if (ParameterSetName.Equals(ParameterSetNames.ByInputObject, StringComparison.OrdinalIgnoreCase))
            {
                DataFactoryName = InputObject.DataFactoryName;
                ResourceGroupName = InputObject.ResourceGroupName;
                PipelineRunId = InputObject.RunId;
            }

            if (ShouldProcess(PipelineRunId))
            {
                DataFactoryClient.StopPipelineRun(ResourceGroupName, DataFactoryName, PipelineRunId);
            }

            if (PassThru)
            {
                WriteObject(true);
            }
        }
    }
}
