using Microsoft.Azure.Commands.OperationalInsights.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{

    public class PSWindowsPerformanceCounterDataSourceProperties : PSDataSourcePropertiesBase
    {
        [JsonIgnore]
        public override string Kind { get { return PSDataSourceKinds.WindowsPerformanceCounter; } }

        [JsonProperty(PropertyName= "objectName")]
        public string ObjectName { get; set; }

        [JsonProperty(PropertyName = "instanceName")]
        public string InstanceName { get; set; }

        [JsonProperty(PropertyName = "intervalSeconds")]
        public int IntervalSeconds { get; set; }

        [JsonProperty(PropertyName = "counterName")]
        public string CounterName { get; set; }
    }

}
