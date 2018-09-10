using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSServiceEndpointPolicy : PSTopLevelResource
    {
        [JsonProperty(Order = 1)]
        public List<PSServiceEndpointPolicyDefinition> ServiceEndpointPolicyDefinitions { get; set; }

        [JsonIgnore]
        public string ServiceEndpointPolicyDefinitionsText
        {
            get { return JsonConvert.SerializeObject(ServiceEndpointPolicyDefinitions, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
