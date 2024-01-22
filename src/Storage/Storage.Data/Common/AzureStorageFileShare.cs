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
    using Microsoft.Azure.Storage.File;
    using Microsoft.WindowsAzure.Commands.Storage;
    using global::Azure.Storage.Files.Shares;
    using global::Azure.Storage;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using global::Azure.Storage.Files.Shares.Models;
    using Microsoft.Azure.Storage.Auth;
    using System.Management.Automation;

    /// <summary>
    /// Azure storage file object
    /// </summary>
    public class AzureStorageFileShare : AzureStorageBase
    {
        /// <summary>
        /// CloudBlob object
        /// </summary>    
        [Ps1Xml(Label = "Share Uri", Target = ViewControl.Table, GroupByThis = true, ScriptBlock = "$_.CloudFile.Share.Uri")]
        [Ps1Xml(Label = "Name", Target = ViewControl.Table, ScriptBlock = "$_.Name", Position = 0, TableColumnWidth = 20)]
        public CloudFileShare CloudFileShare { get; private set; }

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

        /// <summary>
        /// XSCL Track2 File Share Client, used to run file APIs
        /// </summary>
        public ShareClient ShareClient
        {
            get
            {
                if (privateShareClient == null)
                {
                    if (this.IsDeleted == null || !this.IsDeleted.Value)
                    {
                        privateShareClient = GetTrack2FileShareClient(this.CloudFileShare, (AzureStorageContext)this.Context);
                    }
                    else
                    {
                        throw new InvalidJobStateException("This share is already deleted. Can't create ShareClient for it.");
                    }
                }
                return privateShareClient;
            }
        }
        private ShareClient privateShareClient = null;

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
        /// Azure storage file constructor
        /// </summary>
        /// <param name="share">Cloud file share object</param>
        /// <param name="storageContext">Storage context containing account information used to construct ShareClient.</param>
        public AzureStorageFileShare(CloudFileShare share, AzureStorageContext storageContext)
        {
            Name = share.Name;
            CloudFileShare = share;
            LastModified = share.Properties.LastModified;
            IsSnapshot = share.IsSnapshot;
            SnapshotTime = share.SnapshotTime;
            Quota = share.Properties.Quota;
            Context = storageContext;
        }

        /// <summary>
        /// Azure storage file share constructor from Track2 get file properties output
        /// </summary>
        public AzureStorageFileShare(ShareClient shareClient, AzureStorageContext storageContext, ShareProperties shareProperties = null, ShareClientOptions clientOptions = null)
        {
            Name = shareClient.Name;
            this.privateShareClient = shareClient;
            CloudFileShare = GetTrack1FileShareClient(shareClient, storageContext.StorageAccount.Credentials);
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
            //this.privateShareClient = shareClient;
            CloudFileShare = GetTrack1FileShareClient(shareClient, storageContext.StorageAccount.Credentials);
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
                    this.privateShareClient = GetTrack2FileShareClient(CloudFileShare, storageContext, clientOptions);
                    this.privateShareClient = this.privateShareClient.WithSnapshot(shareItem.Snapshot);
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

        // Convert Track2 File share object to Track 1 file share object
        public static CloudFileShare GetTrack1FileShareClient(ShareClient shareClient, StorageCredentials credentials)
        {
            if (credentials.IsToken)
            {
                return new InvalidCloudFileShare(shareClient.Uri, credentials);
            }
            if (credentials.IsSAS) // the Uri already contains credentail.
            {
                credentials = null;
            }
            CloudFileShare track1CloudFileShare = new CloudFileShare(shareClient.Uri, credentials);
            return track1CloudFileShare;
        }

        // Convert Track1 File share object to Track 2 file share Client
        public static ShareClient GetTrack2FileShareClient(CloudFileShare cloudFileShare, AzureStorageContext context, ShareClientOptions clientOptions = null)
        {
            ShareClient fileShareClient;
            if (cloudFileShare.ServiceClient.Credentials.IsSAS) //SAS
            {
                string sas = Util.GetSASStringWithoutQuestionMark(cloudFileShare.ServiceClient.Credentials.SASToken);
                string fullUri = cloudFileShare.SnapshotQualifiedUri.ToString();
                if (cloudFileShare.IsSnapshot)
                {
                    // Since snapshot URL already has '?', need remove '?' in the first char of sas
                    fullUri = fullUri + "&" + sas;
                }
                else
                {
                    fullUri = fullUri + "?" + sas;
                }
                fileShareClient = new ShareClient(new Uri(fullUri), clientOptions);
            }
            else if (cloudFileShare.ServiceClient.Credentials.IsSharedKey) //Shared Key
            {
                fileShareClient = new ShareClient(cloudFileShare.SnapshotQualifiedUri,
                    new StorageSharedKeyCredential(cloudFileShare.ServiceClient.Credentials.AccountName, cloudFileShare.ServiceClient.Credentials.ExportBase64EncodedKey()), clientOptions);
            }
            else //Anonymous
            {
                fileShareClient = new ShareClient(cloudFileShare.SnapshotQualifiedUri, clientOptions);
            }

            return fileShareClient;
        }
    }
}
