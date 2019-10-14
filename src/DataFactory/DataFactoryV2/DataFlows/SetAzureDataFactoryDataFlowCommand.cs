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
using Microsoft.Azure.Commands.DataFactoryV2.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataFactoryV2DataFlow", DefaultParameterSetName = ParameterSetNames.ByFactoryName, SupportsShouldProcess = true), OutputType(typeof(PSDataFlow))]
    [Alias("New-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataFactoryV2DataFlow")]
    public class SetAzureDataFactoryDataFlowCommand : DataFactoryContextBaseSetCmdlet
    {
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryName, Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpDataFlowName)]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.DataFlowName)]
        public override string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            ByResourceId();

            string rawJsonContent = DataFactoryClient.ReadJsonFileContent(this.TryResolvePath(DefinitionFile));

            CreatePSAdfEntityParameters parameters = new CreatePSAdfEntityParameters
            {
                ResourceGroupName = ResourceGroupName,
                DataFactoryName = DataFactoryName,
                Name = Name,
                RawJsonContent = rawJsonContent,
                Force = Force.IsPresent,
                ConfirmAction = ConfirmAction
            };

            if (ShouldProcess(Name, string.Format(Constants.HelpDataFlowCreationContext, this.Name, this.ResourceGroupName, this.DataFactoryName)))
            {
                WriteObject(DataFactoryClient.CreatePSDataFlow(parameters));
            }
        }
    }
}
