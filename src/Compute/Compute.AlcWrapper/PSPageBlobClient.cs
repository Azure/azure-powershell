using System;
using System.Collections.Generic;
using System.Text;
using Azure.Storage.Blobs.Specialized;
using System.IO;

namespace Microsoft.Azure.Commands.Compute
{
    public class PSPageBlobClient
    {
        private PageBlobClient _pageBlobClient;

        internal PSPageBlobClient(PageBlobClient pageblobclient)
        {
            _pageBlobClient = pageblobclient;
        }
        public PSPageBlobClient(Uri blobUri)
        {
            _pageBlobClient = new PageBlobClient(blobUri, null);
        }

        public Uri Uri { get { return _pageBlobClient.Uri; } }

        public void UploadPages(Stream content, long offset)
        {
            _pageBlobClient.UploadPagesAsync(content, offset).ConfigureAwait(false).GetAwaiter().GetResult();
        }
    }
}
