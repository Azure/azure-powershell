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
    using global::Azure.Storage.Blobs;
    using Microsoft.WindowsAzure.Commands.Storage;
    using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using global::Azure.Storage;
    using global::Azure.Storage.Blobs.Models;
    using System.Collections;
    using System.Collections.Generic;
    using global::Azure.Storage.Blobs.Specialized;
    using Microsoft.Azure.Storage.Auth;
    using Microsoft.Azure.Storage;
    using System.Threading.Tasks;

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
        public Microsoft.Azure.Storage.Blob.BlobType BlobType { get; private set; }

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
        /// XSCL Track2 Blob Client, used to run blob APIs, this property should be removed in the future major release, and replace with BlobBaseClient
        /// </summary>
        public BlobClient BlobClient
        {
            get
            {
                if (privateBlobClient == null)
                {
                    if (this.ICloudBlob != null)
                    {
                        privateBlobClient = GetTrack2BlobClient(this.ICloudBlob, (AzureStorageContext)this.Context, this.privateClientOptions);
                    }
                    else if(this.privateBlobBaseClient != null)
                    {
                        privateBlobClient = GetTrack2BlobClient(this.privateBlobBaseClient, (AzureStorageContext)this.Context, this.privateClientOptions);
                    }
                }
                return privateBlobClient;
            }
        }
        private BlobClient privateBlobClient = null;

        /// <summary>
        /// XSCL Track2 Blob Client, used to run blob APIs
        /// </summary>
        public BlobBaseClient BlobBaseClient
        {
            get
            {
                if (privateBlobBaseClient == null)
                {
                    if (this.privateBlobClient == null && this.ICloudBlob != null && !(this.ICloudBlob is InvalidCloudBlob))
                    {
                        privateBlobClient = GetTrack2BlobClient(this.ICloudBlob, (AzureStorageContext)this.Context, this.privateClientOptions);
                    }
                    var Track2BlobType = Util.convertBlobType_Track1ToTrack2(this.BlobType);
                    if (Track2BlobType != null)
                    {
                        privateBlobBaseClient = Util.GetTrack2BlobClientWithType(privateBlobClient, (AzureStorageContext)this.Context, Track2BlobType.Value, this.privateClientOptions);
                    }
                    else
                    {
                        privateBlobBaseClient = (BlobBaseClient)privateBlobClient;
                    }
                    // Don't need add versionID, since with VersionID the object must be get from Track2SDK, and the privateBlobBaseClient should no be null in this case
                }
                return privateBlobBaseClient;
            }
        }
        private BlobBaseClient privateBlobBaseClient = null;

        /// <summary>
        /// XSCL Track2 Blob properties, will retrieve the properties on server and return to user
        /// </summary>
        public global::Azure.Storage.Blobs.Models.BlobProperties BlobProperties
        {
            get
            {
                // For find blob  by Tag, won't auto get blob properties.
                if (getLazyProperties)
                {
                    if (privateBlobProperties == null)
                    {
                        privateBlobProperties = BlobBaseClient.GetProperties().Value;
                    }
                }
                return privateBlobProperties;
            }
        }
        private global::Azure.Storage.Blobs.Models.BlobProperties privateBlobProperties = null;

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
        /// Blob VersionId.
        /// </summary>
        public string VersionId { get; set; }

        /// <summary>
        /// Blob IsCurrentVersion..
        /// </summary>
        public bool? IsLatestVersion { get; set; }

        private BlobClientOptions privateClientOptions = null;

        /// <summary>
        /// Get the lazy properties automaticlly, won't get it when the item is created with Find-AzStorageBlobByTag
        /// </summary>
        private bool getLazyProperties = true;

        /// <summary>
        /// Blob AccessTier..
        /// </summary>
        public string AccessTier { get; set; }

        /// <summary>
        /// Blob TagCount.
        /// </summary>
        public long TagCount
        {
            get
            {
                if (tagcount == -1)
                {
                    tagcount = BlobProperties.TagCount;
                }
                    return tagcount;
            }
            set
            {
                tagcount = value;
            }
        }
        private long tagcount = -1;

        /// <summary>
        /// Blob Tags
        /// </summary>
        public Hashtable Tags { get; set; }

        /// <summary>
        /// Azure storage blob constructor
        /// </summary>
        /// <param name="blob">ICloud blob object</param>
        /// <param name="storageContext">Storage context containing account information used to construct BlobClient.</param>
        /// <param name="options">Blob client options which should contain powershell user agent.</param>
        public AzureStorageBlob(CloudBlob blob, AzureStorageContext storageContext, BlobClientOptions options = null)
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
            this.Context = storageContext;
            this.privateClientOptions = options;
            AccessTier = blob.Properties.StandardBlobTier is null ?
                (blob.Properties.PremiumPageBlobTier is null ? null : blob.Properties.PremiumPageBlobTier.ToString())
                : blob.Properties.StandardBlobTier.ToString();
        }

        /// <summary>
        /// Azure storage blob constructor
        /// </summary>
        /// <param name="track2BlobClient"></param>
        /// <param name="storageContext">Storage context containing account information used to construct BlobClient.</param>
        /// <param name="options">Blob client options which should contain powershell user agent.</param>
        /// <param name="listBlobItem"></param>
        public AzureStorageBlob(BlobBaseClient track2BlobClient, AzureStorageContext storageContext, BlobClientOptions options = null, BlobItem listBlobItem = null)
        {
            if (listBlobItem == null)
            {
                SetProperties(track2BlobClient, storageContext, track2BlobClient.GetProperties().Value, options);
                return;
            }

            this.privateBlobBaseClient = track2BlobClient;
            Name = track2BlobClient.Name;
            this.Context = storageContext;
            privateClientOptions = options;
            ICloudBlob = GetTrack1Blob(track2BlobClient, storageContext.StorageAccount.Credentials, listBlobItem.Properties.BlobType);
            if (!(ICloudBlob is InvalidCloudBlob))
            {
                BlobType = ICloudBlob.BlobType;
                SnapshotTime = ICloudBlob.SnapshotTime;
            }
            else
            {
                BlobType = Util.convertBlobType_Track2ToTrack1(listBlobItem.Properties.BlobType);
                if (listBlobItem.Snapshot != null)
                {
                    SnapshotTime = DateTimeOffset.Parse(listBlobItem.Snapshot);
                }
            }

            // Set the AzureStorageBlob Properties
            Length = listBlobItem.Properties.ContentLength is null ? 0 : listBlobItem.Properties.ContentLength.Value;
            IsDeleted = listBlobItem.Deleted;
            RemainingDaysBeforePermanentDelete = listBlobItem.Properties.RemainingRetentionDays;
            ContentType = listBlobItem.Properties.ContentType;
            LastModified = listBlobItem.Properties.LastModified;
            VersionId = listBlobItem.VersionId;
            IsLatestVersion = listBlobItem.IsLatestVersion;
            AccessTier = listBlobItem.Properties.AccessTier is null? null: listBlobItem.Properties.AccessTier.ToString();
            if (listBlobItem.Tags != null)
            {
                Tags = listBlobItem.Tags.ToHashtable();
                TagCount = listBlobItem.Tags.Count;
            }
        }


        public AzureStorageBlob(BlobBaseClient track2BlobClient, AzureStorageContext storageContext, global::Azure.Storage.Blobs.Models.BlobProperties blobProperties, BlobClientOptions options = null)
        {
            SetProperties(track2BlobClient, storageContext, blobProperties, options);
        }

        /// <summary>
        /// Azure storage blob constructor
        /// </summary>
        /// <param name="blob">ICloud blob object</param>
        /// <param name="storageContext">Storage context containing account information used to construct BlobClient.</param>
        /// <param name="continuationToken">Continuation token.</param>
        /// <param name="options">Blob client options which should contain powershell user agent.</param>
        /// <param name="getProperties"></param>
        public AzureStorageBlob(TaggedBlobItem blob, AzureStorageContext storageContext, string continuationToken = null, BlobClientOptions options = null, bool getProperties = false)
        {
            // Get Track2 blob client
            BlobUriBuilder uriBuilder = new BlobUriBuilder(storageContext.StorageAccount.BlobEndpoint)
            {
                BlobContainerName = blob.BlobContainerName,
                BlobName = blob.BlobName
            };
            Uri blobUri = uriBuilder.ToUri();
            if (storageContext.StorageAccount.Credentials.IsSAS)
            {
                blobUri= new Uri(blobUri.ToString() + storageContext.StorageAccount.Credentials.SASToken);
            }
            this.privateBlobBaseClient = Util.GetTrack2BlobClient(blobUri, storageContext, options);

            // Set continuationToken
            if (continuationToken != null)
            {
                BlobContinuationToken token = new BlobContinuationToken();
                token.NextMarker = continuationToken;
                this.ContinuationToken = token;
                ICloudBlob = storageContext.StorageAccount.CreateCloudBlobClient().GetContainerReference(blob.BlobContainerName).GetBlobReference(blob.BlobName);
            }

            // Set other properties
            if (!getProperties)
            {
                getLazyProperties = false;
                Name = blob.BlobName;
                this.Context = storageContext;
            }
            else
            {
                SetProperties(this.privateBlobBaseClient, storageContext, null, options);
            }
        }

        private void SetProperties(BlobBaseClient track2BlobClient, AzureStorageContext storageContext, global::Azure.Storage.Blobs.Models.BlobProperties blobProperties = null, BlobClientOptions options = null)
        {
            if (blobProperties == null)
            {
                try
                {
                    privateBlobProperties = track2BlobClient.GetProperties().Value;
                }
                catch (global::Azure.RequestFailedException e) when (e.Status == 403 || e.Status == 404)
                {
                    // privateBlobProperties will be null when there are no permission to get blob proeprties, or blob is already deleted.
                }
            }
            else
            {
                privateBlobProperties = blobProperties;
            }

            this.privateBlobBaseClient = track2BlobClient;
            Name = track2BlobClient.Name;
            this.Context = storageContext;
            privateClientOptions = options;
            if (privateBlobProperties is null)
            {
                ICloudBlob = GetTrack1Blob(track2BlobClient, storageContext is null ? null : storageContext.StorageAccount.Credentials, null);
            }
            else
            {
                ICloudBlob = GetTrack1Blob(track2BlobClient, storageContext is null ? null : storageContext.StorageAccount.Credentials, privateBlobProperties.BlobType);
            }
            if (!(ICloudBlob is InvalidCloudBlob))
            {
                BlobType = ICloudBlob.BlobType;
                SnapshotTime = ICloudBlob.SnapshotTime;
            }
            else // This code might should not be necessary, since currently only blob version will has Track1 Blob as null, and blob veresion won't have snapshot time
            {
                SnapshotTime = Util.GetSnapshotTimeFromBlobUri(track2BlobClient.Uri);
            }

            // Set the AzureStorageBlob Properties
            if (privateBlobProperties != null)
            {
                Length = privateBlobProperties.ContentLength;
                ContentType = privateBlobProperties.ContentType;
                LastModified = privateBlobProperties.LastModified;
                VersionId = privateBlobProperties.VersionId;
                IsLatestVersion = privateBlobProperties.IsLatestVersion;
                if (ICloudBlob is InvalidCloudBlob)
                {
                    BlobType = Util.convertBlobType_Track2ToTrack1(privateBlobProperties.BlobType);
                }
                AccessTier = privateBlobProperties.AccessTier is null ? null : privateBlobProperties.AccessTier.ToString();
                TagCount = privateBlobProperties.TagCount;
            }
        }

        /// <summary>
        /// Get Track1 Blob Object
        /// Will return null if it's a Blob version, since Track1 not support blob version
        /// </summary>
        /// <param name="track2BlobClient"></param>
        /// <param name="credentials"></param>
        /// <param name="blobType">Azure storage blob type</param>
        public static CloudBlob GetTrack1Blob(BlobBaseClient track2BlobClient, StorageCredentials credentials, global::Azure.Storage.Blobs.Models.BlobType? blobType = null)
        {
            if ((Util.GetVersionIdFromBlobUri(track2BlobClient.Uri) != null)
                || (track2BlobClient.Uri.Query.Contains("sig=") && (credentials == null || !credentials.IsSAS)))
            {
                // Track1 SDK don't support blob VersionId
                return new InvalidCloudBlob(track2BlobClient.Uri, credentials);
            }

            if (credentials.IsSAS) // the Uri already contains credentail.
            {
                credentials = null;
            }
            CloudBlob track1Blob;
            if (blobType == null)
            {
                track1Blob = new CloudBlob(track2BlobClient.Uri, credentials);
            }
            else
            {
                switch (blobType.Value)
                {
                    case global::Azure.Storage.Blobs.Models.BlobType.Page:
                        track1Blob = new CloudPageBlob(track2BlobClient.Uri, credentials);
                        break;
                    case global::Azure.Storage.Blobs.Models.BlobType.Append:
                        track1Blob = new CloudAppendBlob(track2BlobClient.Uri, credentials);
                        break;
                    default: //Block
                        track1Blob = new CloudBlockBlob(track2BlobClient.Uri, credentials);
                        break;
                }
            }
            return track1Blob;
        }

        //refresh XSCL track2 blob properties object from server
        public void FetchAttributes()
        {
            privateBlobProperties = BlobBaseClient.GetProperties().Value;
        }

        // Convert Track1 Blob object to Track 2 blob Client
        public static BlobClient GetTrack2BlobClient(CloudBlob cloubBlob, AzureStorageContext context, BlobClientOptions options = null)
        {
            BlobClient blobClient;
            if (cloubBlob.ServiceClient.Credentials.IsToken) //Oauth
            {
                if (context == null)
                {
                    //TODO : Get Oauth context from current login user.
                    throw new System.Exception("Need Storage Context to convert Track1 Blob object in token credentail to Track2 Blob object.");
                }
                blobClient = new BlobClient(cloubBlob.SnapshotQualifiedUri, context.Track2OauthToken, options);

            }
            else if (cloubBlob.ServiceClient.Credentials.IsSAS) //SAS
            {
                string sas = Util.GetSASStringWithoutQuestionMark(cloubBlob.ServiceClient.Credentials.SASToken);
                string fullUri = cloubBlob.SnapshotQualifiedUri.ToString();
                if (cloubBlob.IsSnapshot)
                {
                    // Since snapshot URL already has '?', need remove '?' in the first char of sas
                    fullUri = fullUri + "&" + sas;
                }
                else
                {
                    fullUri = fullUri + "?" + sas;
                }
                blobClient = new BlobClient(new Uri(fullUri), options);
            }
            else if (cloubBlob.ServiceClient.Credentials.IsSharedKey) //Shared Key
            {
                blobClient = new BlobClient(cloubBlob.SnapshotQualifiedUri,
                    new StorageSharedKeyCredential(context.StorageAccountName, cloubBlob.ServiceClient.Credentials.ExportBase64EncodedKey()), options);
            }
            else //Anonymous
            {
                blobClient = new BlobClient(cloubBlob.SnapshotQualifiedUri, options);
            }

            return blobClient;
        }

        // Convert Blob object to Track 2 blob Client
        public static BlobClient GetTrack2BlobClient(BlobBaseClient blobBaseClient, AzureStorageContext context, BlobClientOptions options = null)
        {
            if (blobBaseClient is BlobClient)
            {
                return (BlobClient)blobBaseClient;
            }
            BlobClient blobClient;
            if (context.StorageAccount.Credentials.IsToken) //Oauth
            {
                blobClient = new BlobClient(blobBaseClient.Uri, context.Track2OauthToken, options);

            }
            else if (context.StorageAccount.Credentials.IsSharedKey) //Shared Key
            {
                blobClient = new BlobClient(blobBaseClient.Uri,
                    new StorageSharedKeyCredential(context.StorageAccountName, context.StorageAccount.Credentials.ExportBase64EncodedKey()), options);
            }
            else //Anonymous or SAS
            {
                blobClient = new BlobClient(blobBaseClient.Uri, options);
            }

            return blobClient;
        }
    }
}
