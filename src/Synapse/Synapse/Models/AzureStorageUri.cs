using System;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public abstract class AzureStorageUri
    {
        private readonly Uri rawUri;

        public string Schema { get; protected set; }

        public string RelativePath { get; protected set; }

        public string StorageEndpointSuffix { get; protected set; }

        protected AzureStorageUri(Uri rawUri)
        {
            this.rawUri = rawUri;
        }

        public Uri GetRawUri()
        {
            return rawUri;
        }

        public abstract Uri GetUri();
    }
}
