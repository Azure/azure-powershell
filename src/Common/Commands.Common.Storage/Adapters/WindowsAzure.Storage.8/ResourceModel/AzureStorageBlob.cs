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
// ---------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel
{
    using Microsoft.WindowsAzure.Storage.Blob;
    using System;

    /// <summary>
    /// Azure storage blob object
    /// </summary>
    public class AzureStorageBlob : AzureStorageBase
    {
        /// <summary>
        /// CloudBlob object
        /// </summary>
        public CloudBlob ICloudBlob { get; private set; }

        /// <summary>
        /// Azure storage blob type
        /// </summary>
        public BlobType BlobType { get; private set; }

        /// <summary>
        /// Blob length
        /// </summary>
        public long Length { get; private set; }

        /// <summary>
        /// Blob content type
        /// </summary>
        public string ContentType { get; private set; }

        /// <summary>
        /// Blob last modified time
        /// </summary>
        public DateTimeOffset? LastModified { get; private set; }

        /// <summary>
        /// Blob snapshot time
        /// </summary>
        public DateTimeOffset? SnapshotTime { get; private set; }

        /// <summary>
        /// Blob continuation token
        /// </summary>
        public BlobContinuationToken ContinuationToken { get; set; }

        /// <summary>
        /// Azure storage blob constructor
        /// </summary>
        /// <param name="blob">ICloud blob object</param>
        public AzureStorageBlob(CloudBlob blob)
        {
            Name = blob.Name;
            ICloudBlob = blob;
            BlobType = blob.BlobType;
            Length = blob.Properties.Length;
            ContentType = blob.Properties.ContentType;
            LastModified = blob.Properties.LastModified;
            SnapshotTime = blob.SnapshotTime;
        }
    }
}
