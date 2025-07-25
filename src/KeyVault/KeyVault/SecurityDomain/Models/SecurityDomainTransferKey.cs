using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.KeyVault.SecurityDomain.Models
{
    public class SecurityDomainTransferKey
    {
        [JsonProperty("transfer_key")]
        public string TransferKey { get; set; }

        [JsonProperty("key_format")]
        public string KeyFormat { get; set; }
    }
}
