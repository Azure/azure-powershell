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

using Microsoft.Azure.Commands.Compute.StorageServices;
using System.Collections.Generic;
namespace Microsoft.Azure.Commands.Compute.Extension.AzureDiskEncryption
{
    public class AzureVMBackupBlobSasUris
    {
        public AzureVMBackupBlobSasUris()
        {
            blobSASUri = new List<string>();
            pageBlobUri = new List<string>();
            storageCredentialsFactory = new List<StorageCredentialsFactory>();
        }
        public List<string> blobSASUri { get; set; }
        public List<string> pageBlobUri { get; set; }
        public List<StorageCredentialsFactory> storageCredentialsFactory { get; set; }
    }

    public class AzureVMBackupExtensionProtectedSettings
    {
        public string logsBlobUri { get; set; }
        public string objectStr { get; set; }
    }
}
