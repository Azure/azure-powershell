using Azure.Analytics.Synapse.Artifacts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSScheduleTriggerRecurrence
    {
        public PSScheduleTriggerRecurrence() { }

        public RecurrenceFrequency? Frequency { get; set; }

        public int? Interval { get; set; }

        public DateTimeOffset? StartTime { get; set; }

        public DateTimeOffset? EndTime { get; set; }

        public string TimeZone { get; set; }

        public RecurrenceSchedule Schedule { get; set; }

        public ICollection<string> Keys { get; }

        public ICollection<object> Values { get; }

        public ScheduleTriggerRecurrence ToSdkObject()
        {
            return new ScheduleTriggerRecurrence
            {
                Frequency = this.Frequency,
                Interval = this.Interval,
                StartTime = this.StartTime,
                EndTime = this.EndTime,
                TimeZone = this.TimeZone,
                Schedule = this.Schedule
            };
        }
    }
}
