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
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSTriggerRun
    {
        public PSTriggerRun(TriggerRun triggerRun, string workspaceName)
        {
            this.TriggerRunId = triggerRun?.TriggerRunId;
            this.TriggerName = triggerRun?.TriggerName;
            this.TriggerType = triggerRun?.TriggerType;
            this.TriggerRunTimestamp = triggerRun?.TriggerRunTimestamp;
            this.Status = PSTriggerRunStatus.Parse(triggerRun?.Status);
            this.Message = triggerRun?.Message;
            this.Properties = triggerRun?.Properties;
            this.TriggeredPipelines = triggerRun?.TriggeredPipelines;
            this.WorkspaceName = workspaceName;
            this.AdditionalProperties = triggerRun?.AdditionalProperties;
        }

        public string TriggerRunId { get; }

        public string TriggerName { get; }

        public string TriggerType { get; }

        public DateTimeOffset? TriggerRunTimestamp { get; }

        public PSTriggerRunStatus? Status { get; }

        public string Message { get; }

        public IReadOnlyDictionary<string, string> Properties { get; }

        public IReadOnlyDictionary<string, string> TriggeredPipelines { get; }

        public string WorkspaceName { get; set; }

        public IReadOnlyDictionary<string, object> AdditionalProperties { get; }
    }
}
