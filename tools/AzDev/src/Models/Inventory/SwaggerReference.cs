namespace AzDev.Models.Inventory
{
    internal class SwaggerReference
    {
        public string Uri { get; }
        public string RawUri { get; }
        public string Commit { get; }

        public SwaggerReference(string uri, string commit)
        {
            RawUri = uri;
            Commit = commit;
            Uri = ParseUri(uri);
        }

        private string ParseUri(string uri)
        {
            return uri.Replace("$(repo)", $"https://github.com/Azure/azure-rest-api-specs/blob/{Commit}");
        }

        public override string ToString()
        {
            return RawUri;
        }
    }
}
