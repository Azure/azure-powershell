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
using System.Linq;
using System.Net;
using Microsoft.Azure.Commands.DataFactoryV2.Models;
using Microsoft.Azure.Management.DataFactory;
using Microsoft.Azure.Management.DataFactory.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    public partial class DataFactoryClient
    {
        public virtual PSDataFlowDebugSession StartDebugSession(string resourceGroupName, string dataFactoryName, CreateDataFlowDebugSessionRequest request)
        {
            CreateDataFlowDebugSessionResponse response = this.DataFactoryManagementClient.DataFlowDebugSession.Create(resourceGroupName, dataFactoryName, request);
            PSDataFlowDebugSession debugSession = new PSDataFlowDebugSession(response);
            return debugSession;
        }

        public virtual void AddDataFlowToDebugSession(string resourceGroupName, string dataFactoryName, DataFlowDebugPackage package)
        {
            this.DataFactoryManagementClient.DataFlowDebugSession.AddDataFlow(resourceGroupName, dataFactoryName, package);
        }

        public virtual PSDataFlowDebugSessionCommandResult InvokeDataFlowDebugSessionCommand(string resourceGroupName, string dataFactoryName, DataFlowDebugCommandRequest request)
        {
            DataFlowDebugCommandResponse response = this.DataFactoryManagementClient.DataFlowDebugSession.ExecuteCommand(resourceGroupName, dataFactoryName, request);
            PSDataFlowDebugSessionCommandResult result = new PSDataFlowDebugSessionCommandResult(response);
            return result;
        }

        public virtual void DeleteDebugSession(string resourceGroupName, string dataFactoryName, string sessionId)
        {
            this.DataFactoryManagementClient.DataFlowDebugSession.Delete(resourceGroupName, dataFactoryName, new DeleteDataFlowDebugSessionRequest(sessionId));
        }

        public virtual List<PSDataFlowDebugSessionInfo> GetDebugSessions(string resourceGroupName, string dataFactoryName)
        {
            List<PSDataFlowDebugSessionInfo> debugSessions = new List<PSDataFlowDebugSessionInfo>();
            IPage<DataFlowDebugSessionInfo> response;

            do
            {
                response = this.DataFactoryManagementClient.DataFlowDebugSession.QueryByFactory(resourceGroupName, dataFactoryName);

                if (response != null && response.ToList().Count > 0)
                {
                    debugSessions.AddRange(response.ToList().Select(debugSession =>
                        new PSDataFlowDebugSessionInfo(debugSession)));
                }
            }
            while (response.NextPageLink.IsNextPageLink());
            return debugSessions;
        }
    }
}