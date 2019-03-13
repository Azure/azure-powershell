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

using Microsoft.Azure.Management.HDInsight.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.HDInsight.Models.Management
{
    public class AzureHDInsightRuntimeScriptActionDetail : AzureHDInsightRuntimeScriptAction
    {
        public AzureHDInsightRuntimeScriptActionDetail(RuntimeScriptActionDetail runtimeScriptActionDetail)
            : base(runtimeScriptActionDetail)
        {
            ScriptExecutionId = runtimeScriptActionDetail.ScriptExecutionId;
            StartTime = runtimeScriptActionDetail.StartTime;
            EndTime = runtimeScriptActionDetail.EndTime;
            Status = runtimeScriptActionDetail.Status;
            Operation = runtimeScriptActionDetail.Operation;

            if (runtimeScriptActionDetail.ExecutionSummary != null)
            {
                ExecutionSummary = runtimeScriptActionDetail.ExecutionSummary
                    .Select(e => string.Format("{{{0}: {1}}}", e.Status, e.InstanceCount))
                    .ToList();
            }
            DebugInformation = runtimeScriptActionDetail.DebugInformation;
        }

        public long ScriptExecutionId { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public string Status { get; set; }

        public string Operation { get; set; }

        public IList<string> ExecutionSummary { get; set; }

        public string DebugInformation { get; set; }
    }
}