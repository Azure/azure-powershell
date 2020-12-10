using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSScheduleTriggerRecurrence
    {
        public PSScheduleTriggerRecurrence() { }

        [JsonProperty(PropertyName = "frequency")]
        public RecurrenceFrequency? Frequency { get; set; }

        [JsonProperty(PropertyName = "interval")]
        public int? Interval { get; set; }

        [JsonProperty(PropertyName = "startTime")]
        public DateTimeOffset? StartTime { get; set; }

        [JsonProperty(PropertyName = "endTime")]
        public DateTimeOffset? EndTime { get; set; }

        [JsonProperty(PropertyName = "timeZone")]
        public string TimeZone { get; set; }

        [JsonProperty(PropertyName = "schedule")]
        public PSRecurrenceSchedule Schedule { get; set; }

        public IDictionary<string, object> AdditionalProperties { get; set; }
    }
}
