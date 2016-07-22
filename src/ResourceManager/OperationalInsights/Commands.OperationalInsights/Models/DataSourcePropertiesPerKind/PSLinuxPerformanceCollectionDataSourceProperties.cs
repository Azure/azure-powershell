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

    public class PSLinuxPerformanceCollectionDataSourceProperties : PSDataSourcePropertiesBase
    {
        [JsonIgnore]
        public override string Kind { get { return PSDataSourceKinds.LinuxPerformanceCollection; } }

        [JsonProperty(PropertyName = "state")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CollectionState State { get; set; }
    }

}
