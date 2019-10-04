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

using Microsoft.Azure.Commands.DataFactoryV2.Properties;
using System.Globalization;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    [Cmdlet("Stop", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataFactoryV2DataFlowDebugSession", DefaultParameterSetName = ParameterSetNames.ByFactoryName, SupportsShouldProcess = true)]
    [OutputType(typeof(void))]
    [OutputType(typeof(bool))]
    public class StopAzureDataFactoryDataFlowDebugSessionCommand : DataFactoryDataFlowDebugSessionBaseCmdlet
    {
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryName, Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpDataFlowDebugSessionId)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryObject, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpDataFlowDebugSessionId)]
        [Parameter(ParameterSetName = ParameterSetNames.ByResourceId, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpDataFlowDebugSessionId)]
        [ValidateNotNullOrEmpty]
        public string SessionId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "If specified will write true in case operation succeeds. This parameter is optional.")]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.HelpDontAskConfirmation)]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            ByResourceId();
            ByFactoryObject();

            ConfirmAction(
                    Force.IsPresent,
                    string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.DataFlowDebugSessionConfirmationMessage,
                        SessionId,
                        DataFactoryName),
                    string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.DataFlowDebugSessionRemoving,
                        SessionId,
                        DataFactoryName),
                    SessionId,
                    ExecuteDelete);
        }

        private void ExecuteDelete()
        {
            DataFactoryClient.DeleteDebugSession(ResourceGroupName, DataFactoryName, SessionId);

            if (this.PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
    }
}
