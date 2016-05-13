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

namespace Microsoft.WindowsAzure.Commands.Common.Storage
{
    using Microsoft.WindowsAzure.Storage.Blob;

    public class BlobUploadParameters
    {
        public string StorageName { get; set; }
        public string FileLocalPath { get; set; }
        public string FileRemoteName { get; set; }
        public string ContainerName { get; set; }
        public bool ContainerPublic { get; set; }
        public bool OverrideIfExists { get; set; }
        public int SasTokenDurationInHours { get; set; }
        public BlobRequestOptions BlobRequestOptions { get; set; }

        public BlobUploadParameters()
        {
            ContainerPublic = false;
            ContainerName = "mydeployments";
            SasTokenDurationInHours = 24;
            OverrideIfExists = false;
        }
    }
}
