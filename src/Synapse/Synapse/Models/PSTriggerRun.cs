using Azure.Analytics.Synapse.Artifacts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSTriggerRun
    {
        public PSTriggerRun(TriggerRun triggerRun)
        {
            this.TriggerRunId = triggerRun?.TriggerRunId;
            this.TriggerName = triggerRun?.TriggerName;
            this.TriggerType = triggerRun?.TriggerType;
            this.TriggerRunTimestamp = triggerRun?.TriggerRunTimestamp;
            this.Status = triggerRun?.Status;
            this.Message = triggerRun?.Message;
            this.Properties = triggerRun?.Properties;
            this.TriggeredPipelines = triggerRun?.TriggeredPipelines;
            this.Keys = triggerRun?.Keys;
            this.Values = triggerRun?.Values;
        }

        public string TriggerRunId { get; }

        public string TriggerName { get; }

        public string TriggerType { get; }

        public DateTimeOffset? TriggerRunTimestamp { get; }

        public TriggerRunStatus? Status { get; }

        public string Message { get; }

        public IReadOnlyDictionary<string, string> Properties { get; }

        public IReadOnlyDictionary<string, string> TriggeredPipelines { get; }

        public IEnumerable<string> Keys { get; }

        public IEnumerable<object> Values { get; }
    }
}
