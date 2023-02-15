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

    /// <summary>
    /// Azure storage file object
    /// </summary>
    public class AzureStorageFile : AzureStorageBase
    {
        /// <summary>
        /// File object
        /// </summary>    
        [Ps1Xml(Label = "Share Uri", Target = ViewControl.Table, GroupByThis = true, ScriptBlock = "$_.CloudFile.Share.Uri")]
        [Ps1Xml(Label = "Name", Target = ViewControl.Table, ScriptBlock = "$_.Name", Position = 0, TableColumnWidth = 20)]
        public CloudFile CloudFile { get; private set; }

        /// <summary>
        /// File length
        /// </summary>
        [Ps1Xml(Label = "Length", Target = ViewControl.Table, Position = 1, TableColumnWidth = 15)]
        public long Length { get; private set; }
        
        /// <summary>
        /// file last modified time
        /// </summary>
        [Ps1Xml(Label = "LastModified", Target = ViewControl.Table, ScriptBlock = "$_.LastModified.UtcDateTime.ToString(\"u\")", Position = 2, TableColumnWidth = 20)]
        public DateTimeOffset? LastModified { get; private set; }

        /// <summary>
        /// XSCL Track2 File Client, used to run file APIs
        /// </summary>
        public ShareFileClient ShareFileClient
        {
            get
            {
                if (privateFileClient == null)
                {
                    privateFileClient = GetTrack2FileClient(this.CloudFile, this.shareClientOptions);
                }
                return privateFileClient;
            }
        }
        private ShareFileClient privateFileClient = null;

        /// <summary>
        /// XSCL Track2 File properties, will retrieve the properties on server and return to user
        /// </summary>
        public global::Azure.Storage.Files.Shares.Models.ShareFileProperties FileProperties
        {
            get
            {
                if (privateFileProperties == null)
                {
                    privateFileProperties = ShareFileClient.GetProperties().Value;
                }
                return privateFileProperties;
            }
        }
        private global::Azure.Storage.Files.Shares.Models.ShareFileProperties privateFileProperties = null;

        /// <summary>
        /// XSCL Track2 File List properties
        /// </summary>
        public global::Azure.Storage.Files.Shares.Models.ShareFileItem ListFileProperties { get; private set; }


        private ShareClientOptions shareClientOptions { get; set; }

        /// <summary>
        /// Azure storage file constructor from track1 file object
        /// </summary>
        /// <param name="file">Cloud file object</param>
        /// <param name="storageContext"></param>
        /// <param name="clientOptions"></param>
        public AzureStorageFile(CloudFile file, AzureStorageContext storageContext, ShareClientOptions clientOptions = null)
        {
            Name = file.Name;
            CloudFile = file;
            Length = file.Properties.Length;
            LastModified = file.Properties.LastModified;
            Context = storageContext;
            shareClientOptions = clientOptions;
        }

        /// <summary>
        /// Azure storage file constructor from Track2 list file item
        /// </summary>
        /// <param name="shareFileClient"></param>
        /// <param name="storageContext"></param>
        /// <param name="shareFileItem"></param>
        /// <param name="clientOptions"></param>
        public AzureStorageFile(ShareFileClient shareFileClient, AzureStorageContext storageContext, ShareFileItem shareFileItem, ShareClientOptions clientOptions = null)
        {
            Name = shareFileClient.Name;
            this.privateFileClient = shareFileClient;
            CloudFile = GetTrack1FileClient(shareFileClient, storageContext.StorageAccount.Credentials);
            if (shareFileItem != null)
            {
                ListFileProperties = shareFileItem;
                if (shareFileItem.FileSize != null)
                {
                    Length = shareFileItem.FileSize.Value;
                }
                if (shareFileItem.Properties != null)
                {
                    LastModified = shareFileItem.Properties.LastModified;
                }
            }
            Context = storageContext;
            shareClientOptions = clientOptions;
        }

        /// <summary>
        /// Azure storage file constructor from Track2 get file properties output
        /// </summary>
        /// <param name="shareFileClient"></param>
        /// <param name="storageContext"></param>
        /// <param name="shareFileProperties"></param>
        /// <param name="clientOptions"></param>
        public AzureStorageFile(ShareFileClient shareFileClient, AzureStorageContext storageContext, ShareFileProperties shareFileProperties = null, ShareClientOptions clientOptions = null)
        {
            Name = shareFileClient.Name;
            this.privateFileClient = shareFileClient;
            CloudFile = GetTrack1FileClient(shareFileClient, storageContext.StorageAccount.Credentials);
            if (shareFileProperties != null)
            {
                privateFileProperties = shareFileProperties;
                Length = shareFileProperties.ContentLength;
                LastModified = shareFileProperties.LastModified;
            }
            Context = storageContext;
            shareClientOptions = clientOptions;
        }

        // Convert Track2 File object to Track 1 file object
        public static CloudFile GetTrack1FileClient(ShareFileClient shareFileClient, StorageCredentials credentials)
        {
            if (credentials.IsSAS) // the Uri already contains credentail.
            {
                credentials = null;
            }
            CloudFile track1CloudFile;
            track1CloudFile = new CloudFile(shareFileClient.Uri, credentials);
            return track1CloudFile;
        }

        // Convert Track1 File object to Track 2 file Client
        public static ShareFileClient GetTrack2FileClient(CloudFile cloudFile, ShareClientOptions clientOptions = null)
        {
            ShareFileClient fileClient;
            if (cloudFile.ServiceClient.Credentials.IsSAS) //SAS
            {
                string sas = Util.GetSASStringWithoutQuestionMark(cloudFile.ServiceClient.Credentials.SASToken);
                string fullUri = cloudFile.SnapshotQualifiedUri.ToString();
                if (cloudFile.Share.IsSnapshot)
                {
                    // Since snapshot URL already has '?', need remove '?' in the first char of sas
                    fullUri = fullUri + "&" + sas;
                }
                else
                {
                    fullUri = fullUri + "?" + sas;
                }
                fileClient = new ShareFileClient(new Uri(fullUri), clientOptions);
            }
            else if (cloudFile.ServiceClient.Credentials.IsSharedKey) //Shared Key
            {
                fileClient = new ShareFileClient(cloudFile.SnapshotQualifiedUri,
                    new StorageSharedKeyCredential(cloudFile.ServiceClient.Credentials.AccountName, cloudFile.ServiceClient.Credentials.ExportBase64EncodedKey()), clientOptions);
            }
            else //Anonymous
            {
                fileClient = new ShareFileClient(cloudFile.SnapshotQualifiedUri, clientOptions);
            }

            return fileClient;
        }
    }
}
