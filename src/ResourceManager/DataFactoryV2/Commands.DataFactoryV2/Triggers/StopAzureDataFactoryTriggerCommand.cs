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

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    [Cmdlet(VerbsLifecycle.Stop, Constants.Trigger, DefaultParameterSetName = ParameterSetNames.ByFactoryName, SupportsShouldProcess = true),
        OutputType(typeof(List<PSTrigger>), typeof(PSTrigger))]
    public class StopAzureDataFactoryTriggerCommand : DataFactoryContextActionBaseCmdlet
    {
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryName, Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpTriggerName)]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.TriggerName)]
        public override string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByInputObject, Position = 0, Mandatory = true, ValueFromPipeline = true,
            HelpMessage = Constants.TriggerName)]
        [ValidateNotNull]
        public PSTrigger InputObject { get; set; }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override void ExecuteCmdlet()
        {
            ByInputObject(InputObject);
            ByResourceId();

            ConfirmAction(
                Force.IsPresent,
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.TriggerStopConfirmation,
                    Name,
                    DataFactoryName),
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.TriggerStopping,
                    Name,
                    DataFactoryName),
                Name,
                () => DataFactoryClient.StopTrigger(ResourceGroupName, DataFactoryName, Name));

            WriteObject(true);
        }
    }
}
