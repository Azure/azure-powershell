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

    public class PSLinuxSyslogCollectionDataSourceProperties : PSDataSourcePropertiesBase
    {
        [JsonIgnore]
        public override string Kind { get { return PSDataSourceKinds.LinuxSyslogCollection; } }

        /// <summary>
        /// Whether to collect syslog from Linux computers.
        /// </summary>
        [JsonProperty(PropertyName= "state")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CollectionState State { get; set; }
    }

    /// <summary>
    /// The linux syslog collection state.
    /// </summary>
    public enum CollectionState
    {
        /// <summary>
        /// The enabled.
        /// </summary>
        Enabled,

        /// <summary>
        /// The disabled.
        /// </summary>
        Disabled,
    }

}
