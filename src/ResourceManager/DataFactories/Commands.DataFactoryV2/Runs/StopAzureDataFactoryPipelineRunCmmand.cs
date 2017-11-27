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

using System.Collections.Generic;
using System.Globalization;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.DataFactoryV2.Models;
using Microsoft.Azure.Commands.DataFactoryV2.Properties;
using System;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    [Cmdlet(VerbsLifecycle.Stop, Constants.PipelineRun, DefaultParameterSetName = ParameterSetNames.ByFactoryName, SupportsShouldProcess = true)]
    public class StopAzureDataFactoryPipelineRunCmmand : DataFactoryContextBaseCmdlet
    {

        [Parameter(ParameterSetName = ParameterSetNames.ByInputObject, Position = 0, Mandatory = true, ValueFromPipeline = true,
            HelpMessage = Constants.PipelineRun)]
        [ValidateNotNull]
        public PSDataFactory InputObject { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryName, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpPipelineRunId)]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.PipelineRun)]
        public string PipelineRunId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.HelpDontAskConfirmation)]
        public SwitchParameter Force { get; set; }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ParameterSetNames.ByFactoryObject, StringComparison.OrdinalIgnoreCase))
            {
                DataFactoryName = InputObject.DataFactoryName;
                ResourceGroupName = InputObject.ResourceGroupName;
            }
            ConfirmAction(
                Force.IsPresent,
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.PipelineRunStopConfirmation,
                    PipelineRunId,
                    DataFactoryName),
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.PipelineRunStopping,
                    PipelineRunId,
                    DataFactoryName),
                PipelineRunId,
                () => DataFactoryClient.StopPipelineRun(ResourceGroupName, DataFactoryName, PipelineRunId));

            WriteObject(true);
        }
    }
}
