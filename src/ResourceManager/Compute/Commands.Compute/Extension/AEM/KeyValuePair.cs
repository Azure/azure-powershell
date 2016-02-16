using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Compute
{
    public class KeyValuePair
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        public KeyValuePair() { }

        public KeyValuePair(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
}
