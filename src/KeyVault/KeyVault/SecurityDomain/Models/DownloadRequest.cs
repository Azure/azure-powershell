using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.KeyVault.SecurityDomain.Models
{
    class DownloadRequest
    {
        public DownloadRequest()
        {
            Certificates = new List<JWK>();
        }

        [JsonProperty("required")]
        public int Required;

        [JsonProperty("certificates")]
        public IList<JWK> Certificates { get; set; }
    }
}
