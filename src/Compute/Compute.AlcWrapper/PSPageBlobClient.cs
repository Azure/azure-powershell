// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Storage.Blobs.Specialized;
using System.IO;
using Azure.Core;

namespace Microsoft.Azure.Commands.Compute
{
    public class PSPageBlobClient
    {
        private PageBlobClient _pageBlobClient;

        internal PSPageBlobClient(PageBlobClient pageblobclient)
        {
            _pageBlobClient = pageblobclient;
        }
        public PSPageBlobClient(Uri blobUri, TokenCredential tokenCredential = null )
        {
            _pageBlobClient = tokenCredential == null ? new PageBlobClient(blobUri, null) : new PageBlobClient(blobUri, tokenCredential);
        }

        public Uri Uri { get { return _pageBlobClient.Uri; } }

        public void UploadPages(Stream content, long offset)
        {
            _pageBlobClient.UploadPagesAsync(content, offset).ConfigureAwait(false).GetAwaiter().GetResult();
        }
    }
}
