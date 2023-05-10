using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models.NetworkManager
{
    public class PSNetworkManagerActiveSecurityAdminRuleResult
    {
        public IList<PSNetworkManagerActiveBaseSecurityAdminRule> Value { get; set; }

        public string SkipToken { get; set; }

        [JsonIgnore]
        public string ValueText
        {
            get { return JsonConvert.SerializeObject(Value, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
