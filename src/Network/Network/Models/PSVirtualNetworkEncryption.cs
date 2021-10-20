using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSVirtualNetworkEncryption
    {
        public string Enabled { get; set; }

        public string Enforcement { get; set; }

        [JsonIgnore]
        public string EnabledText
        {
            get { return JsonConvert.SerializeObject(Enabled, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string EnforcementText
        {
            get { return JsonConvert.SerializeObject(Enforcement, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
