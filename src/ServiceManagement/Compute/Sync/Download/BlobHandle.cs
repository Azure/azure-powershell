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

using Microsoft.WindowsAzure.Commands.Sync.Upload;
using Microsoft.WindowsAzure.Commands.Tools.Vhd.Model;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.RetryPolicies;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Microsoft.WindowsAzure.Commands.Sync.Download
{
    public class BlobHandle
    {
        const int MegaByte = 1024 * 1024;

        private readonly BlobUri blobUri;
        private readonly string storageAccountKey;
        private readonly CloudBlobContainer container;
        private readonly BlobRequestOptions blobRequestOptions;
        private readonly CloudPageBlob pageBlob;

        public BlobHandle(BlobUri blobUri, string storageAccountKey)
        {
            this.blobUri = blobUri;
            this.storageAccountKey = storageAccountKey;
            var blobClient = new CloudBlobClient(new Uri(this.blobUri.BaseUri), new StorageCredentials(this.blobUri.StorageAccountName, this.storageAccountKey));
            this.container = blobClient.GetContainerReference(this.blobUri.BlobContainerName);
            this.container.FetchAttributes();
            this.pageBlob = this.container.GetPageBlobReference(blobUri.BlobName);
            this.blobRequestOptions = new BlobRequestOptions
            {
                ServerTimeout = TimeSpan.FromMinutes(5),
                RetryPolicy = new LinearRetry(TimeSpan.FromMinutes(1), 3)
            };
            this.pageBlob.FetchAttributes(new AccessCondition(), blobRequestOptions);
        }

        public CloudPageBlob Blob { get { return this.pageBlob; } }

        public IEnumerable<IndexRange> GetEmptyRanges()
        {
            var blobRange = new List<IndexRange> { IndexRange.FromLength(0, this.Length) };
            return IndexRange.SubstractRanges(blobRange, GetPageRanges());
        }

        public IEnumerable<IndexRange> GetUploadableRanges()
        {
            IEnumerable<IndexRange> ranges = GetPageRanges();
            ranges = Enumerable.ToList<IndexRange>(IndexRangeHelper.ChunkRangesBySize(ranges, 2 * MegaByte));
            return ranges;
        }

        private IEnumerable<IndexRange> GetPageRanges()
        {
            pageBlob.FetchAttributes(new AccessCondition(), blobRequestOptions);
            IEnumerable<PageRange> pageRanges = pageBlob.GetPageRanges(null, null, new AccessCondition(), blobRequestOptions);
            pageRanges = pageRanges.OrderBy(range => range.StartOffset);
            return pageRanges.Select(pr => new IndexRange(pr.StartOffset, pr.EndOffset));
        }

        public Stream OpenStream()
        {
            return this.container.GetPageBlobReference(blobUri.BlobName).OpenRead(new AccessCondition(), blobRequestOptions);
        }

        public long Length
        {
            get { return pageBlob.Properties.Length; }
        }
    }
}