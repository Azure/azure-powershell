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

    public class PSLinuxSyslogDataSourceProperties : PSDataSourcePropertiesBase
    {
        [JsonIgnore]
        public override string Kind { get { return PSDataSourceKinds.LinuxSyslog; } }

        [JsonProperty(PropertyName= "syslogName")]
        public string SyslogName { get; set; }

        [JsonProperty(PropertyName = "syslogSeverities")]
        public List<SyslogSeverityIdentifier> SyslogSeverities { get; set; }
    }

    /// <summary>
    /// Subscribe to a Syslog Severity
    /// </summary>
    public class SyslogSeverityIdentifier
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Severity type.
        /// </summary>
        [JsonProperty(PropertyName = "severity")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SyslogSeverities Severity { get; set; }

        #endregion
    }

    /// <summary>
    /// The linux syslog Severities.
    /// </summary>
    public enum SyslogSeverities
    {
        emerg,
        alert,
        crit,
        err,
        warning,
        notice,
        info,
        debug
    }

}
