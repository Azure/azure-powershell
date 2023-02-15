using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models.NetworkManager
{
    public class PSNetworkManagerEffectiveSecurityAdminRuleResult
    {
        public IList<PSNetworkManagerEffectiveBaseSecurityAdminRule> Value { get; set; }

        public string SkipToken { get; set; }

        [JsonIgnore]
        public string ValueText
        {
            get { return JsonConvert.SerializeObject(Value, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
