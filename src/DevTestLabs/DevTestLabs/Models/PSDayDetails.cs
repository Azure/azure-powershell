using Newtonsoft.Json;
using System;
using System.Linq;

namespace Microsoft.Azure.Commands.DevTestLabs.Models
{
    public class PSDayDetails
    {
        [JsonProperty(PropertyName = "time")]
        public string Time { get; set; }

        public override string ToString()
        {
            return String.Format("{{ Time: {0} }}", PSSchedule.ToLocalizedTime(Time));
        }
    }
}
