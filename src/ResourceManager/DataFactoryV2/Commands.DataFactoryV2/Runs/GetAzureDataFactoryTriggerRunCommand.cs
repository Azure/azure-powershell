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
    [Cmdlet(VerbsCommon.Get, Constants.TriggerRun, DefaultParameterSetName = ParameterSetNames.ByFactoryName),
        OutputType(typeof(List<PSTriggerRun>), typeof(PSTriggerRun))]
    public class GetAzureDataFactoryTriggerRunCommand : DataFactoryContextBaseCmdlet
    {
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryObject, Position = 2, Mandatory = true,
            HelpMessage = Constants.HelpTriggerName)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryName, Position = 3, Mandatory = true,
            HelpMessage = Constants.HelpTriggerName)]
        [Alias(Constants.TriggerName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryObject, Position = 3, Mandatory = true,
            HelpMessage = Constants.HelpTriggerRunStartedAfter)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryName, Position = 4, Mandatory = true,
            HelpMessage = Constants.HelpTriggerRunStartedAfter)]
        [ValidateNotNullOrEmpty]
        public DateTime TriggerRunStartedAfter { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryObject, Position = 4, Mandatory = true,
            HelpMessage = Constants.HelpTriggerRunStartedBefore)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryName, Position = 5, Mandatory = true,
            HelpMessage = Constants.HelpTriggerRunStartedBefore)]
        [ValidateNotNullOrEmpty]
        public DateTime TriggerRunStartedBefore { get; set; }
        
        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override void ExecuteCmdlet()
        {
            ByFactoryObject();

            TriggerRunFilterOptions triggerRunFilter = new TriggerRunFilterOptions
            {
                ResourceGroupName = ResourceGroupName,
                DataFactoryName = DataFactoryName,
                TriggerName = Name,
                TriggerRunStartedAfter = TriggerRunStartedAfter,
                TriggerRunStartedBefore = TriggerRunStartedBefore
            };
            WriteObject(DataFactoryClient.ListTriggerRuns(triggerRunFilter));
        }
    }
}
