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

using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

using System.IO;

namespace Microsoft.Azure.Commands.Compute
{
    //As Compute module must not reference to storage SDK, the types of parameters and return values of
    //public APIs within this project should not expose any types defined in storage SDK.

    public class AzureStorageService
    {
        public AzureStorageService()
        {
        }

        public void UseBlobClientOptions()
        {
            var options = new BlobClientOptions();
        }

        public PSBlobDownloadInfo DownloadBlob()
        {
            //TODO: Please repalce with your real account
            BlobClient client = new BlobClient("", "", "");
            BlobDownloadInfo info = client.Download().Value;
            return new PSBlobDownloadInfo(info);
        }
    }

    public class PSBlobDownloadInfo
    {
        private BlobDownloadInfo _blobDownloadInfo;

        internal PSBlobDownloadInfo(BlobDownloadInfo info)
        {
            _blobDownloadInfo = info;
        }

        public long ContentLength { get { return _blobDownloadInfo.ContentLength; } }

        public Stream Content { get { return _blobDownloadInfo.Content; } }

        public string ContentType { get { return _blobDownloadInfo.ContentType; } }
    }
}
