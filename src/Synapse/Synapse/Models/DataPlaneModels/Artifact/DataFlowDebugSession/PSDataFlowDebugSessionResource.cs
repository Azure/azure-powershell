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

using Azure.Analytics.Synapse.Artifacts.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSDataFlowDebugSessionResource 
    {
        public PSDataFlowDebugSessionResource(DataFlowDebugSessionInfo dataFlowDebugResource, string workspaceName)
        {
            this.WorkspaceName = workspaceName;
            this.DataFlowName = dataFlowDebugResource?.DataFlowName;
            this.ComputeType = dataFlowDebugResource?.ComputeType;
            this.CoreCount = dataFlowDebugResource?.CoreCount;
            this.NodeCount = dataFlowDebugResource?.NodeCount;
            this.IntegrationRuntimeName = dataFlowDebugResource?.IntegrationRuntimeName;
            this.SessionId = dataFlowDebugResource?.SessionId;
            this.StartTime = dataFlowDebugResource?.StartTime;
            this.TimeToLiveInMinutes = dataFlowDebugResource?.TimeToLiveInMinutes;
            this.LastActivityTime = dataFlowDebugResource?.LastActivityTime;
            this.AdditionalProperties = dataFlowDebugResource?.AdditionalProperties;
        }

        public string WorkspaceName { get; set; }

        public string DataFlowName { get; set; }

        public string ComputeType { get; set; }

        public int? CoreCount { get; set; }

        public int? NodeCount { get; set; }

        public string IntegrationRuntimeName { get; set; }

        public string SessionId { get; set; }

        public string StartTime { get; set; }

        public int? TimeToLiveInMinutes { get; set; }

        public string LastActivityTime { get; set; }

        public IReadOnlyDictionary<string, object> AdditionalProperties { get; }
    }
}
