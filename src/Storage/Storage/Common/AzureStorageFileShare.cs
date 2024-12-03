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
    using System;
    using Microsoft.WindowsAzure.Commands.Common.Attributes;
    using global::Azure.Storage.Files.Shares;
    using global::Azure.Storage;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using global::Azure.Storage.Files.Shares.Models;
    using System.Management.Automation;

    /// <summary>
    /// Azure storage file object
    /// </summary>
    public class AzureStorageFileShare : AzureStorageBase
    {
        /// <summary>
        /// The Snapshot time of the share
        /// </summary>
        public DateTimeOffset? SnapshotTime { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this share is a snapshot.
        /// </summary>
        public bool IsSnapshot { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this share is deleted.
        /// </summary>
        public bool? IsDeleted { get; private set; }

        /// <summary>
        /// file share last modified time
        /// </summary>
        [Ps1Xml(Label = "LastModified", Target = ViewControl.Table, ScriptBlock = "$_.LastModified.UtcDateTime.ToString(\"u\")", Position = 2, TableColumnWidth = 20)]
        public DateTimeOffset? LastModified { get; private set; }

        /// <summary>
        /// File share Quota
        /// </summary>
        public int? Quota { get; private set; }

        public ShareClient ShareClient { get; private set; }

        /// <summary>
        /// XSCL Track2 File Share properties, will retrieve the properties on server and return to user
        /// </summary>
        public global::Azure.Storage.Files.Shares.Models.ShareProperties ShareProperties
        {
            get
            {
                if (privateShareProperties == null)
                {
                    privateShareProperties = ShareClient.GetProperties().Value;
                }
                return privateShareProperties;
            }
        }
        private global::Azure.Storage.Files.Shares.Models.ShareProperties privateShareProperties = null;

        /// <summary>
        /// XSCL Track2 File share List properties
        /// </summary>
        public global::Azure.Storage.Files.Shares.Models.ShareItem ListShareProperties { get; private set; }

        /// <summary>
        /// Delete Share version ID
        /// </summary>
        public string VersionId { get; }

        private ShareClientOptions shareClientOptions { get; set; }
        private ShareServiceClient shareService { get; set; }

        /// <summary>
        /// Azure storage file share constructor from Track2 get file properties output
        /// </summary>
        public AzureStorageFileShare(ShareClient shareClient, AzureStorageContext storageContext, ShareProperties shareProperties = null, ShareClientOptions clientOptions = null)
        {
            Name = shareClient.Name;
            this.ShareClient = shareClient;
            if (shareProperties != null)
            {
                privateShareProperties = shareProperties;
                LastModified = shareProperties.LastModified;
                SnapshotTime = Util.GetSnapshotTimeFromUri(ShareClient.Uri);
                if (SnapshotTime != null)
                {
                    IsSnapshot = true;
                }
                Quota = shareProperties.QuotaInGB;
            }
            Context = storageContext;
            shareClientOptions = clientOptions;
        }

        /// <summary>
        /// Azure storage file share constructor from Track2 list share output
        /// </summary>
        public AzureStorageFileShare(ShareClient shareClient, AzureStorageContext storageContext, ShareItem shareItem, ShareClientOptions clientOptions = null)
        {
            Name = shareClient.Name;
            this.ShareClient = shareClient;
            if (shareItem != null)
            {
                this.ListShareProperties = shareItem;
                this.IsDeleted = shareItem.IsDeleted;
                this.VersionId = shareItem.VersionId;
                if (shareItem.Properties != null)
                {
                    privateShareProperties = shareItem.Properties;
                    LastModified = shareItem.Properties.LastModified;
                    Quota = shareItem.Properties.QuotaInGB;
                }
                if (!string.IsNullOrEmpty(shareItem.Snapshot))
                {
                    SnapshotTime = DateTimeOffset.Parse(shareItem.Snapshot).ToUniversalTime();
                    IsSnapshot = true;
                    this.ShareClient = this.ShareClient.WithSnapshot(shareItem.Snapshot);
                }
            }
            Context = storageContext;
            shareClientOptions = clientOptions;
        }

        /// <summary>
        /// Azure storage file share constructor from Track2 list share output, with deleted share
        /// </summary>
        public AzureStorageFileShare(ShareServiceClient shareService, string shareName, AzureStorageContext storageContext, ShareItem shareItem, ShareClientOptions clientOptions = null)
        {
            this.shareService = shareService;
            this.Name = shareName;
            if (shareItem != null)
            {
                this.ListShareProperties = shareItem;
                this.IsDeleted = shareItem.IsDeleted;
                this.VersionId = shareItem.VersionId;
                if (shareItem.Properties != null)
                {
                    privateShareProperties = shareItem.Properties;
                    LastModified = shareItem.Properties.LastModified;
                    Quota = shareItem.Properties.QuotaInGB;
                }
                if (!string.IsNullOrEmpty(shareItem.Snapshot))
                {
                    SnapshotTime = DateTimeOffset.Parse(shareItem.Snapshot).ToUniversalTime();
                    IsSnapshot = true;
                }
            }
            Context = storageContext;
            shareClientOptions = clientOptions;
        }

        // undelete a soft deleted share
        public void UndeleteShare()
        {
            if (this.IsDeleted != null && this.IsDeleted.Value)
            {
                this.shareService.UndeleteShare(this.Name, this.VersionId);
            }
            else
            {
                throw new InvalidJobStateException("This share is not soft deleted, so can't undelete it.");
            }
        }
    }
}
