using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSRecurrenceScheduleOccurrence
    {
        public PSRecurrenceScheduleOccurrence() { }

        public DayOfWeek? Day { get; set; }

        public int? Occurrence { get; set; }

        public IDictionary<string, object> AdditionalProperties { get; set; }
    }
}
