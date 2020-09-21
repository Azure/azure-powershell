using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.KeyVault.SecurityDomain.Models
{
    class DownloadRequest
    {
        public DownloadRequest()
        {
            certificates = new List<JWK>();
        }

        public int required; // todo: rename to Required
        public IList<JWK> certificates { get; set; }
    }
}
