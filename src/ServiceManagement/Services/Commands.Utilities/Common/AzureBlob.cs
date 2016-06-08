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
using Microsoft.WindowsAzure.Management.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Microsoft.WindowsAzure.Commands.Utilities.Common
{
    public static class AzureBlob
    {
        private static CloudBlobUtility cloudBlobUtility = new CloudBlobUtility();

        public static Uri UploadPackageToBlob(
            StorageManagementClient storageClient,
            string storageName,
            string packagePath,
            BlobRequestOptions blobRequestOptions)
        {
            return cloudBlobUtility.UploadPackageToBlob(
                storageClient,
                storageName,
                packagePath,
                blobRequestOptions);
        }

        public static void DeletePackageFromBlob(
            StorageManagementClient storageClient,
            string storageName,
            Uri packageUri)
        {
            cloudBlobUtility.DeletePackageFromBlob(storageClient, storageName, packageUri);
        }

        public static Uri UploadFile(
            string storageName,
            Uri blobEndpointUri,
            string storageKey,
            string filePath,
            BlobRequestOptions blobRequestOptions)
        {
            return cloudBlobUtility.UploadFile(storageName, blobEndpointUri, storageKey, filePath, blobRequestOptions);
        }
    }
}