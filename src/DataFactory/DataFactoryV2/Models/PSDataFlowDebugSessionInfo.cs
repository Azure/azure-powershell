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
using Microsoft.Azure.Management.DataFactory.Models;

namespace Microsoft.Azure.Commands.DataFactoryV2.Models
{
    public class PSDataFlowDebugSessionInfo
    {
        private DataFlowDebugSessionInfo _debugSessionInfo;

        public PSDataFlowDebugSessionInfo()
        {
            this._debugSessionInfo = new DataFlowDebugSessionInfo();
        }

        public PSDataFlowDebugSessionInfo(DataFlowDebugSessionInfo debugSession)
        {
            this._debugSessionInfo = debugSession ?? throw new ArgumentNullException("debugSession");
        }

        public string DataFlowName
        {
            get
            {
                return this._debugSessionInfo.DataFlowName;
            }
        }

        public string SessionId
        {
            get
            {
                return this._debugSessionInfo.SessionId;
            }
        }

        public string ComputeType
        {
            get
            {
                return this._debugSessionInfo.ComputeType;
            }
        }

        public string IntegrationRuntimeName
        {
            get
            {
                return this._debugSessionInfo.IntegrationRuntimeName;
            }
        }

        public string StartTime
        {
            get
            {
                return this._debugSessionInfo.StartTime;
            }
        }

        public string LastActivityTime
        {
            get
            {
                return this._debugSessionInfo.LastActivityTime;
            }
        }

        public int? CoreCount
        {
            get
            {
                return this._debugSessionInfo.CoreCount;
            }
        }

        public int? TimeToLiveInMinutes
        {
            get
            {
                return this._debugSessionInfo.TimeToLiveInMinutes;
            }
        }
    }
}
