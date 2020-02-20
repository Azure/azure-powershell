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
using Microsoft.WindowsAzure.Commands.Common.Attributes;

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

        [Ps1Xml(Target = ViewControl.Table)]
        public string SessionId
        {
            get
            {
                return this._debugSessionInfo.SessionId;
            }
        }

        [Ps1Xml(Target = ViewControl.Table)]
        public string ComputeType
        {
            get
            {
                return this._debugSessionInfo.ComputeType;
            }
        }

        [Ps1Xml(Target = ViewControl.Table)]
        public int? CoreCount
        {
            get
            {
                return this._debugSessionInfo.CoreCount;
            }
        }

        [Ps1Xml(Target = ViewControl.Table)]
        public string StartTime
        {
            get
            {
                return this._debugSessionInfo.StartTime;
            }
        }

        [Ps1Xml(Target = ViewControl.Table)]
        public string LastActivityTime
        {
            get
            {
                return this._debugSessionInfo.LastActivityTime;
            }
        }

        [Ps1Xml(Target = ViewControl.Table)]
        public int? TimeToLiveInMinutes
        {
            get
            {
                return this._debugSessionInfo.TimeToLiveInMinutes;
            }
        }

        [Ps1Xml(Target = ViewControl.Table)]
        public string IntegrationRuntimeName
        {
            get
            {
                return this._debugSessionInfo.IntegrationRuntimeName;
            }
        }

        [Ps1Xml(Target = ViewControl.Table)]
        public string DataFlowName
        {
            get
            {
                return this._debugSessionInfo.DataFlowName;
            }
        }
    }
}
