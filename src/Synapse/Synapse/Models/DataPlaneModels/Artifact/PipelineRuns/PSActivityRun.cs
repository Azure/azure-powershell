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
    public class PSActivityRun
    {
        public PSActivityRun(ActivityRun activityRun)
        {
            this.Error = activityRun?.Error;
            this.Output = activityRun?.Output;
            this.Input = activityRun?.Input;
            this.DurationInMs = activityRun?.DurationInMs;
            this.ActivityRunEnd = activityRun?.ActivityRunEnd;
            this.ActivityRunStart = activityRun?.ActivityRunStart;
            this.Status = activityRun?.Status;
            this.ActivityRunId = activityRun?.ActivityRunId;
            this.ActivityType = activityRun?.ActivityType;
            this.ActivityName = activityRun?.ActivityName;
            this.PipelineRunId = activityRun?.PipelineRunId;
            this.PipelineName = activityRun?.PipelineName;
            this.LinkedServiceName = activityRun?.LinkedServiceName;
            this.AdditionalProperties = activityRun?.AdditionalProperties;
        }
        
        public object Error { get; }
        
        public object Output { get; }
        
        public object Input { get; }
        
        public int? DurationInMs { get; }
        
        public DateTimeOffset? ActivityRunEnd { get; }
        
        public DateTimeOffset? ActivityRunStart { get; }
        
        public string Status { get; }
        
        public string ActivityRunId { get; }
        
        public string ActivityType { get; }
       
        public string ActivityName { get; }
        
        public string PipelineRunId { get; }
        
        public string PipelineName { get; }
        
        public string LinkedServiceName { get; }

        public IReadOnlyDictionary<string, object> AdditionalProperties { get; set; }
    }
}
