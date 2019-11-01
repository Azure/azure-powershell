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
    using Microsoft.WindowsAzure.Commands.Storage.Model.ResourceModel;

    /// <summary>
    /// Azure storage blob object
    /// </summary>
    public class AzureDataLakeGen2Item : AzureStorageBase
    {
        public CloudBlockBlob File { get; set; }

        /// <summary>
        /// CloudBlobDirectory object
        /// </summary>
        public CloudBlobDirectory Directory { get; private set; }


        /// <summary>
        /// The Path of the item
        /// </summary>
        [Ps1Xml(Label = "Path", Target = ViewControl.Table, Position = 0, TableColumnWidth = 20)]
        public string Path { get; set; }

        /// <summary>
        /// CloudBlobDirectory object
        /// </summary>
        [Ps1Xml(Label = "IsDirectory", Target = ViewControl.Table, Position = 1, TableColumnWidth = 12)]
        public bool IsDirectory { get; private set; }

        /// <summary>
        /// Datalake Gen2 Item path Permissions
        /// </summary>
        [Ps1Xml(Label = "Permissions", Target = ViewControl.Table, ScriptBlock = "$_.Permissions.ToSymbolicString()", Position = 5, TableColumnWidth = 12)]
        public PathPermissions Permissions { get; set; }

        /// <summary>
        /// Datalake Gen2 Item ACL
        /// </summary>
        public PSPathAccessControlEntry[] ACL { get; set; }

        /// <summary>
        /// Azure storage blob type
        /// </summary>
        public BlobType BlobType { get; private set; }

        /// <summary>
        /// Blob length
        /// </summary>
        [Ps1Xml(Label = "Length", Target = ViewControl.Table, ScriptBlock = "if ($_.IsDirectory -eq $false) {$_.Length}", Position = 2, TableColumnWidth = 15)]
        public long Length { get; private set; }

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
        /// The owner of the item
        /// </summary>
        [Ps1Xml(Label = "Owner", Target = ViewControl.Table, Position = 6, TableColumnWidth = 10)]
        public string Owner { get; set; }

        /// <summary>
        /// The Group of the item
        /// </summary>
        [Ps1Xml(Label = "Group", Target = ViewControl.Table, Position = 7, TableColumnWidth = 10)]
        public string Group { get; set; }

        /// <summary>
        /// Blob continuation token
        /// </summary>
        public BlobContinuationToken ContinuationToken { get; set; }

        /// <summary>
        /// Azure DataLakeGen2 Item constructor
        /// </summary>
        /// <param name="blob">CloudBlockBlob blob object</param>
        public AzureDataLakeGen2Item(CloudBlockBlob blob)
        {
            Name = blob.Name;
            Path = blob.Name;
            File = blob;
            BlobType = blob.BlobType;
            Length = blob.Properties.Length;
            ContentType = blob.Properties.ContentType;
            LastModified = blob.Properties.LastModified;
            IsDirectory = false;
            if (blob.PathProperties != null)
            {
                Permissions = ((CloudBlockBlob)blob).PathProperties.Permissions;
                ACL = PSPathAccessControlEntry.ParsePSPathAccessControlEntrys(blob.PathProperties.ACL);
                Owner = blob.PathProperties.Owner;
                Group = blob.PathProperties.Group;
            }
        }

        /// <summary>
        /// Azure DataLakeGen2 Item constructor
        /// </summary>
        /// <param name="blobDir">Cloud blob Directory object</param>
        public AzureDataLakeGen2Item(CloudBlobDirectory blobDir)
        {
            Name = blobDir.Prefix;
            Path = blobDir.Prefix;
            Directory = blobDir;
            BlobType = BlobType.Unspecified;
            Length = 0;
            ContentType = blobDir.Properties.ContentType;
            LastModified = blobDir.Properties.LastModified;
            IsDirectory = true;
            if (blobDir.PathProperties != null)
            {
                Permissions = blobDir.PathProperties.Permissions;
                ACL = PSPathAccessControlEntry.ParsePSPathAccessControlEntrys(blobDir.PathProperties.ACL);
                Owner = blobDir.PathProperties.Owner;
                Group = blobDir.PathProperties.Group;
            }
        }
    }
}
