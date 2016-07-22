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

    public class PSIISLogDataSourceProperties: PSDataSourcePropertiesBase
    {
        [JsonIgnore]
        public override string Kind { get { return PSDataSourceKinds.IISLog; } }

        /// <summary>
        /// Whether to enable IISLog collection on Windows computers.
        /// </summary>
        [JsonProperty(PropertyName="state")]
        [JsonConverter(typeof(StringEnumConverter))]
        public IISLogState State { get; set; }
    }

    public enum IISLogState {
        OnPremiseEnabled,
        OnPremiseDisabled
    }
}
