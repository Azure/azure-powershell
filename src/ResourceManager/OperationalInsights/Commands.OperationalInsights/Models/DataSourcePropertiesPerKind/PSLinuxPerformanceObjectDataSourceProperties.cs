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

    public class PSLinuxPerformanceObjectDataSourceProperties : PSDataSourcePropertiesBase
    {
        [JsonIgnore]
        public override string Kind { get { return PSDataSourceKinds.LinuxPerformanceObject; } }

        [JsonProperty(PropertyName= "objectName")]
        public string ObjectName { get; set; }

        [JsonProperty(PropertyName = "instanceName")]
        public string InstanceName { get; set; }

        [JsonProperty(PropertyName = "intervalSeconds")]
        public int IntervalSeconds { get; set; }

        [JsonProperty(PropertyName = "performanceCounters")]
        public List<PerformanceCounterSubscription>PerformanceCounters { get; set; }
    }

    /// <summary>
    /// Subscribe to a Syslog Severity
    /// </summary>
    public class PerformanceCounterSubscription
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Severity type.
        /// </summary>
        [JsonProperty(PropertyName = "counterName")]
        public string CounterName { get; set; }

        #endregion
    }

}
