using Newtonsoft.Json;
using System;
using System.Linq;

namespace Microsoft.Azure.Commands.DevTestLabs.Models
{
    public class PSHourDetails
    {
        //
        // Summary:
        //     Minutes of the hour the schedule will run.
        [JsonProperty(PropertyName = "minute")]
        public int? Minute { get; set; }

        public override string ToString()
        {
            return String.Format("{{ Minute: {0} }}", Minute);
        }
    }
}
