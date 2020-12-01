using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
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

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties { get; set; }

        public ScheduleTriggerRecurrence ToSdkObject()
        {
            var scheduleTriggerRecurrence = new ScheduleTriggerRecurrence
            {
                Frequency = this.Frequency,
                Interval = this.Interval,
                StartTime = this.StartTime,
                EndTime = this.EndTime,
                TimeZone = this.TimeZone,
                Schedule = this.Schedule.ToSdkObject()
            };
            this.AdditionalProperties?.ForEach(item => scheduleTriggerRecurrence.Add(item.Key, item.Value));
            return scheduleTriggerRecurrence;
        }
    }
}
