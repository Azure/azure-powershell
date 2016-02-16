using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Compute
{
    public class ExtensionConfig
    {
        [JsonProperty("cfg")]
        public List<KeyValuePair> Config { get; set; }
    }
}
