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
using System.Management.Automation;
using Microsoft.Azure.Commands.DataFactoryV2.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.DataFactory.Models;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    [Cmdlet("Invoke", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataFactoryV2DataFlowDebugSessionCommand", DefaultParameterSetName = ParameterSetNames.ByFactoryName, SupportsShouldProcess = true), OutputType(typeof(PSDataFlowDebugSessionCommandResult))]
    public class InvokeAzureDataFactoryDataFlowDebugSessionOperationCommand : DataFactoryDataFlowDebugSessionBaseCmdlet
    {
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryName, Position = 2, Mandatory = true,
            HelpMessage = Constants.HelpDataFlowDebugSessionId)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryObject, Position = 1, Mandatory = true,
            HelpMessage = Constants.HelpDataFlowDebugSessionId)]
        [Parameter(ParameterSetName = ParameterSetNames.ByResourceId, Position = 1, Mandatory = true,
            HelpMessage = Constants.HelpDataFlowDebugSessionId)]
        [ValidateNotNullOrEmpty]
        public string SessionId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryName, Position = 3, Mandatory = true,
            HelpMessage = Constants.HelpDataFlowDebugCommand)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryObject, Position = 2, Mandatory = true,
            HelpMessage = Constants.HelpDataFlowDebugCommand)]
        [Parameter(ParameterSetName = ParameterSetNames.ByResourceId, Position = 2, Mandatory = true,
            HelpMessage = Constants.HelpDataFlowDebugCommand)]
        [PSArgumentCompleter(DataFlowDebugCommandType.ExecutePreviewQuery, DataFlowDebugCommandType.ExecuteStatisticsQuery, DataFlowDebugCommandType.ExecuteExpressionQuery)]
        [ValidateNotNullOrEmpty]
        public string Command { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryName, Position = 4, Mandatory = true,
            HelpMessage = Constants.HelpDataFlowDebugStreamName)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryObject, Position = 3, Mandatory = true,
            HelpMessage = Constants.HelpDataFlowDebugStreamName)]
        [Parameter(ParameterSetName = ParameterSetNames.ByResourceId, Position = 3, Mandatory = true,
            HelpMessage = Constants.HelpDataFlowDebugStreamName)]
        [ValidateNotNullOrEmpty]
        public string StreamName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryName, Position = 5, Mandatory = false,
            HelpMessage = Constants.HelpDataFlowDebugRowLimits)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryObject, Position = 4, Mandatory = false,
            HelpMessage = Constants.HelpDataFlowDebugRowLimits)]
        [Parameter(ParameterSetName = ParameterSetNames.ByResourceId, Position = 4, Mandatory = false,
            HelpMessage = Constants.HelpDataFlowDebugRowLimits)]
        public int? RowLimit { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryName, Position = 6, Mandatory = false,
            HelpMessage = Constants.HelpDataFlowDebugExpression)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryObject, Position = 5, Mandatory = false,
            HelpMessage = Constants.HelpDataFlowDebugExpression)]
        [Parameter(ParameterSetName = ParameterSetNames.ByResourceId, Position = 5, Mandatory = false,
            HelpMessage = Constants.HelpDataFlowDebugExpression)]
        public string Expression { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryName, Position = 7, Mandatory = false,
            HelpMessage = Constants.HelpDataFlowDebugColumns)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryObject, Position = 6, Mandatory = false,
            HelpMessage = Constants.HelpDataFlowDebugColumns)]
        [Parameter(ParameterSetName = ParameterSetNames.ByResourceId, Position = 6, Mandatory = false,
            HelpMessage = Constants.HelpDataFlowDebugColumns)]
        public List<string> Column { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            ByResourceId();
            ByFactoryObject();

            DataFlowDebugCommandRequest request = new DataFlowDebugCommandRequest
            {
                Command = Command,
                SessionId = SessionId,
                CommandPayload = new DataFlowDebugCommandPayload
                {
                    StreamName = StreamName,
                    RowLimits = RowLimit,
                    Expression = Expression,
                    Columns = Column
                }

            };

            if (ShouldProcess(DataFactoryName, string.Format(Constants.HelpInvokeDebugSessionCommandContext, this.SessionId, this.ResourceGroupName, this.DataFactoryName)))
            {
                WriteObject(DataFactoryClient.InvokeDataFlowDebugSessionCommand(ResourceGroupName, DataFactoryName, request));
            }
        }
    }
}
