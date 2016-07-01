using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.DevTestLabs.Models
{
    public class PSWeekDetails
    {
        //
        // Summary:
        //     The time of the day.
        [JsonProperty(PropertyName = "time")]
        public string Time { get; set; }

        //
        // Summary:
        //     The days of the week.
        [JsonProperty(PropertyName = "weekdays")]
        public IList<string> Weekdays { get; set; }

        public override string ToString()
        {
            if (Weekdays == null || Weekdays.Count == 0)
            {
                return String.Format("{{ Time: {0} }}", PSSchedule.ToLocalizedTime(Time));
            }

            return String.Format("{{ Time: {0}, Weekdays: {1} }}", PSSchedule.ToLocalizedTime(Time), string.Join(", ", Weekdays.Select(i => i.ToString())));
        }
    }
}