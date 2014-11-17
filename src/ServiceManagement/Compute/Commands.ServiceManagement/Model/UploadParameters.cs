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


using System.IO;
using Microsoft.WindowsAzure.Commands.ServiceManagement.StorageServices;
using Microsoft.WindowsAzure.Commands.Sync.Download;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Model
{
    public class UploadParameters
    {
        public UploadParameters(BlobUri destinationUri, BlobUri baseImageUri, FileInfo localFilePath, bool overWrite, int numberOfUploaderThreads)
        {
            DestinationUri = destinationUri;
            BaseImageUri = baseImageUri;
            LocalFilePath = localFilePath;
            OverWrite = overWrite;
            NumberOfUploaderThreads = numberOfUploaderThreads;
        }

        public BlobUri DestinationUri { get; private set; }

        public BlobUri BaseImageUri { get; private set; }

        public FileInfo LocalFilePath { get; private set; }

        public bool OverWrite { get; private set; }

        public int NumberOfUploaderThreads { get; private set; }

        public AddAzureVhdCommand Cmdlet { get; set; }

        public CloudPageBlobObjectFactory BlobObjectFactory { get; set; }
    }
}