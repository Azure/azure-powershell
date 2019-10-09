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
using Microsoft.Rest.Serialization;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Management.DataFactory.Models;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataFactoryV2DataFlowDebugSessionPackage", DefaultParameterSetName = ParameterSetNames.ByFactoryName, SupportsShouldProcess = true)]
    [OutputType(typeof(void))]
    [OutputType(typeof(bool))]
    public class AddAzureDataFactoryDataFlowDebugSessionDataFlowPackageCommand : DataFactoryDataFlowDebugSessionBaseCmdlet
    {
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryName, Position = 2, Mandatory = true,
            HelpMessage = Constants.HelpJsonFilePath)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryObject, Position = 1, Mandatory = true,
            HelpMessage = Constants.HelpJsonFilePath)]
        [Parameter(ParameterSetName = ParameterSetNames.ByResourceId, Position = 1, Mandatory = true,
            HelpMessage = Constants.HelpJsonFilePath)]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.File)]
        public string PackageFile { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryName, Position = 3, Mandatory = false,
            HelpMessage = Constants.HelpDataFlowDebugSessionId)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryObject, Position = 2, Mandatory = false,
            HelpMessage = Constants.HelpDataFlowDebugSessionId)]
        [Parameter(ParameterSetName = ParameterSetNames.ByResourceId, Position = 2, Mandatory = false,
            HelpMessage = Constants.HelpDataFlowDebugSessionId)]
        public string SessionId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "If specified will write true in case operation succeeds. This parameter is optional.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            ByResourceId();
            ByFactoryObject();

            DataFlowDebugPackage package = ConvertRequestFromJson(PackageFile);
            if (!string.IsNullOrWhiteSpace(SessionId))
            {
                package.SessionId = SessionId;
            }

            if (ShouldProcess(DataFactoryName, string.Format(Constants.HelpAddDataFlowPackageContext, this.SessionId, this.ResourceGroupName, this.DataFactoryName)))
            {
                DataFactoryClient.AddDataFlowToDebugSession(ResourceGroupName, DataFactoryName, package);
            }

            if (this.PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }

        private DataFlowDebugPackage ConvertRequestFromJson(string requestFile)
        {
            var parameters = new DataFlowDebugPackage();
            string rawJsonContent = DataFactoryClient.ReadJsonFileContent(this.TryResolvePath(requestFile));
            if (!string.IsNullOrWhiteSpace(rawJsonContent))
            {
                parameters = SafeJsonConvert.DeserializeObject<DataFlowDebugPackage>(rawJsonContent, DataFactoryClient.DataFactoryManagementClient.DeserializationSettings);
            }
            return parameters;
        }
    }
}
