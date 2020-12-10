using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSRecurrenceSchedule
    {
        public PSRecurrenceSchedule() { }

        public IList<int> Minutes { get; }

        public IList<int> Hours { get; }

        public IList<DaysOfWeek> WeekDays { get; }

        public IList<int> MonthDays { get; }

        public IList<PSRecurrenceScheduleOccurrence> MonthlyOccurrences { get; }

        public IDictionary<string, object> AdditionalProperties { get; set; }
    }
}
