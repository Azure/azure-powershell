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
            this.Keys = activityRun?.Keys;
            this.Error = activityRun?.Error;
            this.Output = activityRun?.Output;
            this.Input = activityRun?.Input;
            this.DurationInMs = activityRun?.DurationInMs;
            this.ActivityRunEnd = activityRun?.ActivityRunEnd;
            this.ActivityRunStart = activityRun?.ActivityRunStart;
            this.Values = activityRun?.Values;
            this.Status = activityRun?.Status;
            this.ActivityRunId = activityRun?.ActivityRunId;
            this.ActivityType = activityRun?.ActivityType;
            this.ActivityName = activityRun?.ActivityName;
            this.PipelineRunId = activityRun?.PipelineRunId;
            this.PipelineName = activityRun?.PipelineName;
            this.LinkedServiceName = activityRun?.LinkedServiceName;
        }

        public IEnumerable<string> Keys { get; }
        
        public object Error { get; }
        
        public object Output { get; }
        
        public object Input { get; }
        
        public int? DurationInMs { get; }
        
        public DateTimeOffset? ActivityRunEnd { get; }
        
        public DateTimeOffset? ActivityRunStart { get; }

        public IEnumerable<object> Values { get; }
        
        public string Status { get; }
        
        public string ActivityRunId { get; }
        
        public string ActivityType { get; }
       
        public string ActivityName { get; }
        
        public string PipelineRunId { get; }
        
        public string PipelineName { get; }
        
        public string LinkedServiceName { get; }
    }
}
