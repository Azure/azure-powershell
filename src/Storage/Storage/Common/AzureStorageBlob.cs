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
    using Microsoft.Azure.Storage.Blob;
    using System;
    using Microsoft.WindowsAzure.Commands.Common.Attributes;

    /// <summary>
    /// Azure storage blob object
    /// </summary>
    public class AzureStorageBlob : AzureStorageBase
    {
        /// <summary>
        /// CloudBlob object
        /// </summary>    
        [Ps1Xml(Label = "Container Uri", Target = ViewControl.Table, GroupByThis = true, ScriptBlock = "$_.ICloudBlob.Container.Uri")]
        [Ps1Xml(Label = "Name", Target = ViewControl.Table, ScriptBlock = "$_.Name", Position = 0, TableColumnWidth = 20)]
        [Ps1Xml(Label = "AccessTier", Target = ViewControl.Table, ScriptBlock = "$_.ICloudBlob.Properties.StandardBlobTier", Position = 5, TableColumnWidth = 10)]
        public CloudBlob ICloudBlob { get; private set; }

        /// <summary>
        /// Azure storage blob type
        /// </summary>
        [Ps1Xml(Label = "BlobType", Target = ViewControl.Table, Position = 1, TableColumnWidth = 9)]
        public BlobType BlobType { get; private set; }

        /// <summary>
        /// Blob length
        /// </summary>
        [Ps1Xml(Label = "Length", Target = ViewControl.Table, Position = 2, TableColumnWidth = 15)]
        public long Length { get; private set; }

        /// <summary>
        /// Blob IsDeleted
        /// </summary>
        [Ps1Xml(Label = "IsDeleted", Target = ViewControl.Table, Position = 7, TableColumnWidth = 10)]
        public bool IsDeleted { get; private set; }

        /// <summary>
        /// Blob IsDeleted
        /// </summary>
        public int? RemainingDaysBeforePermanentDelete { get; private set; }

        /// <summary>
        /// Blob content type
        /// </summary>
        [Ps1Xml(Label = "ContentType", Target = ViewControl.Table, Position = 3, TableColumnWidth = 30)]
        public string ContentType { get; private set; }

        /// <summary>
        /// Blob last modified time
        /// </summary>
        [Ps1Xml(Label = "LastModified", Target = ViewControl.Table, ScriptBlock = "$_.LastModified.UtcDateTime.ToString(\"u\")", Position = 4, TableColumnWidth = 20)]
        public DateTimeOffset? LastModified { get; private set; }

        /// <summary>
        /// Blob snapshot time
        /// </summary>
        [Ps1Xml(Label = "SnapshotTime", Target = ViewControl.Table, ScriptBlock = "$_.SnapshotTime.UtcDateTime.ToString(\"u\")", Position = 6, TableColumnWidth = 20)]
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
            IsDeleted = blob.IsDeleted;
            RemainingDaysBeforePermanentDelete = blob.Properties.RemainingDaysBeforePermanentDelete;
            ContentType = blob.Properties.ContentType;
            LastModified = blob.Properties.LastModified;
            SnapshotTime = blob.SnapshotTime;
        }
    }
}
