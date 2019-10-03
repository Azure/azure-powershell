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
using Microsoft.Rest.Serialization;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Management.DataFactory.Models;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    [Cmdlet("Start", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataFactoryV2DataFlowDebugSession", DefaultParameterSetName = ParameterSetNames.ByFactoryName, SupportsShouldProcess = true), OutputType(typeof(PSDataFlowDebugSession))]
    public class StartAzureDataFactoryDataFlowDebugSessionCommand : DataFactoryDataFlowDebugSessionBaseCmdlet
    {
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryName, Position = 2, Mandatory = false,
            HelpMessage = Constants.HelpJsonFilePath)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryObject, Position = 1, Mandatory = false,
            HelpMessage = Constants.HelpJsonFilePath)]
        [Parameter(ParameterSetName = ParameterSetNames.ByResourceId, Position = 1, Mandatory = false,
            HelpMessage = Constants.HelpJsonFilePath)]
        [Alias(Constants.File)]
        public string IntegrationRuntimeFile { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            ByResourceId();
            ByFactoryObject();

            CreateDataFlowDebugSessionRequest request = new CreateDataFlowDebugSessionRequest
            {
                TimeToLive = 60
            };

            if (!string.IsNullOrWhiteSpace(IntegrationRuntimeFile))
            {
                IntegrationRuntimeDebugResource integrationRuntimeResource = this.ConvertRequestFromJson(IntegrationRuntimeFile);
                request.IntegrationRuntime = integrationRuntimeResource;
            }

            if (ShouldProcess(DataFactoryName, string.Format(Constants.HelpStartDataFlowDebugSessionContext, this.ResourceGroupName, this.DataFactoryName)))
            {
                WriteObject(DataFactoryClient.StartDebugSession(ResourceGroupName, DataFactoryName, request));
            }            
        }

        private IntegrationRuntimeDebugResource ConvertRequestFromJson(string requestFile)
        {
            var parameters = new IntegrationRuntimeDebugResource();
            string rawJsonContent = DataFactoryClient.ReadJsonFileContent(this.TryResolvePath(requestFile));
            if (!string.IsNullOrWhiteSpace(rawJsonContent))
            {
                parameters = SafeJsonConvert.DeserializeObject<IntegrationRuntimeDebugResource>(rawJsonContent, DataFactoryClient.DataFactoryManagementClient.DeserializationSettings);
            }
            return parameters;
        }
    }
}
