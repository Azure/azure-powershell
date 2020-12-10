using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;

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

        public PSRecurrenceSchedule Schedule { get; set; }

        public IDictionary<string, object> AdditionalProperties { get; set; }
    }
}
