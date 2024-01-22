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

namespace Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel
{
    using Microsoft.Azure.Storage.Blob;
    using System;
    using Microsoft.WindowsAzure.Commands.Common.Attributes;
    using global::Azure.Storage.Blobs;
    using Microsoft.WindowsAzure.Commands.Storage;
    using global::Azure.Storage;
    using global::Azure.Storage.Blobs.Models;
    using BlobContainerProperties = global::Azure.Storage.Blobs.Models.BlobContainerProperties;
    using Microsoft.Azure.Storage.Auth;
    using Microsoft.Azure.Storage;
    using Microsoft.WindowsAzure.Commands.Storage.Common;

    /// <summary>
    /// azure storage container
    /// </summary>
    public class AzureStorageContainer : AzureStorageBase
    {
        /// <summary>
        /// CloudBlobContainer object
        /// </summary>
        [Ps1Xml(Label = "Blob End Point", Target = ViewControl.Table, GroupByThis = true, ScriptBlock = "$_.CloudBlobContainer.ServiceClient.BaseUri")]
        [Ps1Xml(Label = "Name", Target = ViewControl.Table, ScriptBlock = "$_.Name", Position = 0, TableColumnWidth = 20)]
        public CloudBlobContainer CloudBlobContainer {
            get
            {
                // cloudBlobContainer is not null, but not fetach attribute yet.
                if (cloudBlobContainer!=null 
                    && cloudBlobContainer.Properties != null 
                    && cloudBlobContainer.Properties.LeaseStatus == Azure.Storage.Blob.LeaseStatus.Unspecified 
                    && cloudBlobContainer.Properties.ETag == null)
                {
                    cloudBlobContainer.FetchAttributes();
                }
                return cloudBlobContainer;
            }
            private set
            {
                cloudBlobContainer = value;
            }
        }
        private CloudBlobContainer cloudBlobContainer;

        /// <summary>
        /// the permission of CloudBlobContainer
        /// </summary>
        public BlobContainerPermissions Permission {
            get
            {
                if(privatePermission == null)
                {
                    try
                    {
                        privatePermission = cloudBlobContainer.GetPermissions();
                    }
                    catch (StorageException e) when (e.RequestInformation.HttpStatusCode == 403 || e.RequestInformation.HttpStatusCode == 404)
                    {                
                        // 404 Not found, or 403 Forbidden means we don't have permission to query the Permission of the specified container.
                        // Just skip return container permission in this case.
                    }
                }
                return privatePermission;
            }
            private set
            {
                privatePermission = value;
            }
        }
        private BlobContainerPermissions privatePermission;

        /// <summary>
        /// the AccessPolicy of BlobContainer
        /// </summary>
        public BlobContainerAccessPolicy AccessPolicy { get; private set; }

        /// <summary>
        /// the public access level of CloudBlobContainer
        /// </summary>
        [Ps1Xml(Label = "PublicAccess", Target = ViewControl.Table, Position = 1, TableColumnWidth = 20)]
        public BlobContainerPublicAccessType? PublicAccess { get; private set; }

        /// <summary>
        /// last modified of CloudBlobContainer
        /// </summary>
        [Ps1Xml(Label = "LastModified", Target = ViewControl.Table, Position = 2)]
        public DateTimeOffset? LastModified { get; private set; }

        /// <summary>
        /// Container continuation token
        /// </summary>
        public BlobContinuationToken ContinuationToken { get; set; }

        /// <summary>
        /// Set to true if the container is deleted
        /// </summary>
        public bool? IsDeleted { get; set; }

        /// <summary>
        /// deleted container version
        /// </summary>
        public string VersionId { get; set; }

        /// <summary>
        /// XSCL Track2 container Client, used to run blob APIs
        /// </summary>
        public BlobContainerClient BlobContainerClient
        {
            get
            {
                if (privateBlobContainerClient == null)
                {
                    privateBlobContainerClient = GetTrack2BlobContainerClient(this.cloudBlobContainer, (AzureStorageContext)this.Context);
                }
                return privateBlobContainerClient;
            }
        }
        private BlobContainerClient privateBlobContainerClient = null;

        /// <summary>
        /// XSCL Track2 Blob properties, will retrieve the properties on server and return to user
        /// </summary>
        public global::Azure.Storage.Blobs.Models.BlobContainerProperties BlobContainerProperties
        {
            get
            {
                if (privateBlobContainerProperties == null)
                {
                    privateBlobContainerProperties = BlobContainerClient.GetProperties().Value;
                }
                return privateBlobContainerProperties;
            }
        }
        private global::Azure.Storage.Blobs.Models.BlobContainerProperties privateBlobContainerProperties = null;

        /// <summary>
        /// init azure storage container using CloudBlobContainer and BlobContainerPermissions
        /// </summary>
        /// <param name="container">CloudBlobContainer object</param>
        /// <param name="permissions">permissions of container</param>
        public AzureStorageContainer(CloudBlobContainer container, BlobContainerPermissions permissions)
        {
            cloudBlobContainer = container;
            Permission = permissions;
            Name = container.Name;

            if (permissions == null)
            {
                PublicAccess = null;
            }
            else
            {
                PublicAccess = permissions.PublicAccess;
            }

            LastModified = container.Properties.LastModified;
        }

        public AzureStorageContainer(BlobContainerClient container, AzureStorageContext storageContext, BlobContainerProperties properties = null)
        {
            Name = container.Name;
            privateBlobContainerClient = container;
            cloudBlobContainer = GetTrack1BlobContainer(privateBlobContainerClient, storageContext.StorageAccount.Credentials);
            privateBlobContainerProperties = properties;

            if (privateBlobContainerProperties == null)
            {
                LastModified = null;
            }
            else
            {
                LastModified = privateBlobContainerProperties.LastModified;
            }
            this.Context = storageContext;
        }

        public AzureStorageContainer(BlobContainerItem containerItem, AzureStorageContext storageContext, BlobServiceClient serviceClient)
        {
            Name = containerItem.Name;
            privateBlobContainerClient = serviceClient.GetBlobContainerClient(containerItem.Name);
            cloudBlobContainer = GetTrack1BlobContainer(privateBlobContainerClient, storageContext.StorageAccount.Credentials);
            privateBlobContainerProperties = containerItem.Properties;

            IsDeleted = containerItem.IsDeleted;
            VersionId = containerItem.VersionId;
            LastModified = privateBlobContainerProperties.LastModified;
            this.Context = storageContext;
        }

        public void SetTrack2Permission(BlobContainerAccessPolicy accesspolicy = null)
        {
            // Try to get container permission if not input it, and container not deleted
            if (accesspolicy == null && (this.IsDeleted == null || !this.IsDeleted.Value))
            {
                try
                {
                    accesspolicy = privateBlobContainerClient.GetAccessPolicy().Value;
                }
                catch (global::Azure.RequestFailedException e) when (e.Status == 403 || e.Status == 404)
                {
                    // 404 Not found, or 403 Forbidden means we don't have permission to query the Permission of the specified container.
                    // Just skip return container permission in this case.
                }
            }

            if (accesspolicy != null)
            {
                AccessPolicy = accesspolicy;

                switch (accesspolicy.BlobPublicAccess)
                {
                    case PublicAccessType.Blob:
                        PublicAccess = BlobContainerPublicAccessType.Blob;
                        break;
                    case PublicAccessType.BlobContainer:
                        PublicAccess = BlobContainerPublicAccessType.Container;
                        break;
                    case PublicAccessType.None:
                    default:
                        PublicAccess = BlobContainerPublicAccessType.Off;
                        break;
                }
            }
        }

        //refresh XSCL track2 container properties object from server
        public void FetchAttributes()
        {
            privateBlobContainerProperties = BlobContainerClient.GetProperties().Value;
        }

        // Convert Track1 Container object to Track 2 Container Client
        public static BlobContainerClient GetTrack2BlobContainerClient(CloudBlobContainer cloubContainer, AzureStorageContext context, BlobClientOptions options = null)
        {
            BlobContainerClient blobContainerClient;
            if (cloubContainer.ServiceClient.Credentials.IsToken) //Oauth
            {
                if (context == null)
                {
                    //TODO : Get Oauth context from current login user.
                    throw new System.Exception("Need Storage Context to convert Track1 object in token credentail to Track2 object.");
                }
                blobContainerClient = new BlobContainerClient(cloubContainer.Uri, context.Track2OauthToken, options);

            }
            else if (cloubContainer.ServiceClient.Credentials.IsSAS) //SAS
            {
                string fullUri = cloubContainer.Uri.ToString();
                string sas = Util.GetSASStringWithoutQuestionMark(cloubContainer.ServiceClient.Credentials.SASToken);
                fullUri = fullUri + "?" + sas;
                blobContainerClient = new BlobContainerClient(new Uri(fullUri), options);
            }
            else if (cloubContainer.ServiceClient.Credentials.IsSharedKey) //Shared Key
            {
                blobContainerClient = new BlobContainerClient(cloubContainer.Uri,
                    new StorageSharedKeyCredential(context.StorageAccountName, cloubContainer.ServiceClient.Credentials.ExportBase64EncodedKey()), options);
            }
            else //Anonymous
            {
                blobContainerClient = new BlobContainerClient(cloubContainer.Uri, options);
            }

            return blobContainerClient;
        }

        /// <summary>
        /// Get Track1 Blob Container Object
        /// </summary>
        /// <param name="track2BlobContainerClient"></param>
        /// <param name="credentials"></param>
        public static CloudBlobContainer GetTrack1BlobContainer(BlobContainerClient track2BlobContainerClient, StorageCredentials credentials)
        {
            if (credentials.IsSAS) // the Uri already contains credentail.
            {
                credentials = null;
            }
            CloudBlobContainer track1Container;
            track1Container = new CloudBlobContainer(track2BlobContainerClient.Uri, credentials);
            return track1Container;
        }
    }
}
