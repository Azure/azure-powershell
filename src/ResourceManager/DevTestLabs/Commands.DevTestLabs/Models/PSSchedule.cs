using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.DevTestLabs.Models
{
    public class PSSchedule
    {
        internal static string ToLocalizedTime(string militaryTime)
        {
            if (militaryTime == null || militaryTime.Length != 4)
            {
                return militaryTime;
            }

            ushort hours;

            if (!ushort.TryParse(militaryTime.Substring(0, 2), out hours))
            {
                return militaryTime;
            }

            ushort minutes;

            if (!ushort.TryParse(militaryTime.Substring(2), out minutes))
            {
                return militaryTime;
            }

            if (hours > 23 || minutes > 59)
            {
                return militaryTime;
            }

            return new DateTime(2000, 1, 1, hours, minutes, 0, 0).ToShortTimeString();
        }

        //
        // Summary:
        //     The daily recurrence of the schedule.
        [JsonProperty(PropertyName = "properties.dailyRecurrence")]
        public PSDayDetails DailyRecurrence { get; set; }

        //
        // Summary:
        //     The hourly recurrence of the schedule.
        [JsonProperty(PropertyName = "properties.hourlyRecurrence")]
        public PSHourDetails HourlyRecurrence { get; set; }

        //
        // Summary:
        //     The identifier of the resource.
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        //
        // Summary:
        //     The location of the resource.
        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }

        //
        // Summary:
        //     The name of the resource.
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        //
        // Summary:
        //     The provisioning status of the resource.
        [JsonProperty(PropertyName = "properties.provisioningState")]
        public string ProvisioningState { get; set; }

        //
        // Summary:
        //     The status of the schedule. Possible values include: 'Enabled', 'Disabled'
        [JsonProperty(PropertyName = "properties.status")]
        public string Status { get; set; }

        //
        // Summary:
        //     The tags of the resource.
        [JsonProperty(PropertyName = "tags")]
        public IDictionary<string, string> Tags { get; set; }

        //
        // Summary:
        //     The task type of the schedule. Possible values include: 'LabVmsShutdownTask',
        //     'LabVmsStartupTask', 'LabBillingTask'
        [JsonProperty(PropertyName = "properties.taskType")]
        public string TaskType { get; set; }

        //
        // Summary:
        //     The time zone id.
        [JsonProperty(PropertyName = "properties.timeZoneId")]
        public string TimeZoneId { get; set; }

        //
        // Summary:
        //     The type of the resource.
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        //
        // Summary:
        //     The weekly recurrence of the schedule.
        [JsonProperty(PropertyName = "properties.weeklyRecurrence")]
        public PSWeekDetails WeeklyRecurrence { get; set; }
    }
}
