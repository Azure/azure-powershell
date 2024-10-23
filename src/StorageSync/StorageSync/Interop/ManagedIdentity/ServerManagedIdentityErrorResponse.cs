using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.StorageSync.Interop.ManagedIdentity
{
    /// <summary>
    /// Type representing the error response of the Azure IMDS/HIMDS endpoint for token acquisition requests.
    /// </summary>
    public sealed class ServerManagedIdentityErrorResponse
    {
        [JsonProperty(Required = Required.Always, PropertyName = "error")]
        public string Error { get; set; }

        [JsonProperty(Required = Required.Always, PropertyName = "error_description")]
        public string ErrorDescription { get; set; }
    }
}
