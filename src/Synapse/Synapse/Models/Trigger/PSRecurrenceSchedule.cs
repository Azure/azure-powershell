using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSRecurrenceSchedule
    {
        public PSRecurrenceSchedule() { }

        [JsonProperty(PropertyName = "minutes")]
        public IList<int> Minutes { get; }

        [JsonProperty(PropertyName = "hours")]
        public IList<int> Hours { get; }

        [JsonProperty(PropertyName = "weekDays")]
        public IList<DaysOfWeek> WeekDays { get; }

        [JsonProperty(PropertyName = "monthDays")]
        public IList<int> MonthDays { get; }

        [JsonProperty(PropertyName = "monthlyOccurrences")]
        public IList<PSRecurrenceScheduleOccurrence> MonthlyOccurrences { get; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties { get; set; }

        public RecurrenceSchedule ToSdkObject()
        {
            var recurrenceSchedule = new RecurrenceSchedule();
            this.AdditionalProperties?.ForEach(item => recurrenceSchedule.Add(item.Key, item.Value));
            return recurrenceSchedule;
        }
    }
}
