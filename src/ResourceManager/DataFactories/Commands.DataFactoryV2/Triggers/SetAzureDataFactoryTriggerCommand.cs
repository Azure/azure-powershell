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

using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.DataFactoryV2.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    [Cmdlet(VerbsCommon.Set, Constants.Trigger, DefaultParameterSetName = ParameterSetNames.ByFactoryName, 
        SupportsShouldProcess = true), OutputType(typeof(PSTrigger))]
    [Alias(VerbsCommon.New + "-" + Constants.Trigger)]
    public class SetAzureDataFactoryTriggerCommand : DataFactoryContextBaseSetCmdlet
    {
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryName, Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpTriggerName)]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.TriggerName)]
        public override string Name { get; set; }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override void ExecuteCmdlet()
        {
            ByResourceId();

            string rawJsonContent = DataFactoryClient.ReadJsonFileContent(this.TryResolvePath(DefinitionFile));

            CreatePSAdfEntityParameters parameters = new CreatePSAdfEntityParameters()
            {
                ResourceGroupName = ResourceGroupName,
                DataFactoryName = DataFactoryName,
                Name = Name,
                RawJsonContent = rawJsonContent,
                Force = Force.IsPresent,
                ConfirmAction = ConfirmAction
            };

            WriteObject(DataFactoryClient.CreatePSTrigger(parameters));
        }
    }
}