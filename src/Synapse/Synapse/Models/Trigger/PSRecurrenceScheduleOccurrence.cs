using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
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

        public IDictionary<string, object> AdditionalProperties { get; set; }
    }
}
