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
                    privateShareClient = GetTrack2FileShareClient(this.CloudFileShare, (AzureStorageContext)this.Context);
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

        // Convert Track1 File share object to Track 2 file share Client
        protected static ShareClient GetTrack2FileShareClient(CloudFileShare cloudFileShare, AzureStorageContext context)
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
                fileShareClient = new ShareClient(new Uri(fullUri));
            }
            else if (cloudFileShare.ServiceClient.Credentials.IsSharedKey) //Shared Key
            {
                fileShareClient = new ShareClient(cloudFileShare.SnapshotQualifiedUri,
                    new StorageSharedKeyCredential(context.StorageAccountName, cloudFileShare.ServiceClient.Credentials.ExportBase64EncodedKey()));
            }
            else //Anonymous
            {
                fileShareClient = new ShareClient(cloudFileShare.SnapshotQualifiedUri);
            }

            return fileShareClient;
        }
    }
}
