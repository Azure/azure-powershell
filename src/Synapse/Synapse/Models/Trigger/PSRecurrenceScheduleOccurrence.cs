using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSRecurrenceScheduleOccurrence
    {
        public PSRecurrenceScheduleOccurrence() { }

        [JsonProperty(PropertyName = "day")]
        public DayOfWeek? Day { get; set; }

        [JsonProperty(PropertyName = "occurrence")]
        public int? Occurrence { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties { get; set; }

        public RecurrenceScheduleOccurrence ToSdkObject()
        {
            var recurrenceScheduleOccurrence = new RecurrenceScheduleOccurrence()
            {
                Day = this.Day,
                Occurrence = this.Occurrence
            };
            this.AdditionalProperties?.ForEach(item => recurrenceScheduleOccurrence.Add(item.Key, item.Value));
            return recurrenceScheduleOccurrence;
        }
    }
}
