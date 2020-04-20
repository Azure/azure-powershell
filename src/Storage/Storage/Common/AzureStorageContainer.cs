﻿// ----------------------------------------------------------------------------------
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
        public CloudBlobContainer CloudBlobContainer { get; private set; }

        /// <summary>
        /// the permission of CloudBlobContainer
        /// </summary>
        public BlobContainerPermissions Permission { get; private set; }

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
        /// XSCL Track2 container Client, used to run blob APIs
        /// </summary>
        public BlobContainerClient BlobContainerClient
        {
            get
            {
                if (privateBlobContainerClient == null)
                {
                    privateBlobContainerClient = GetTrack2BlobContainerClient(this.CloudBlobContainer, (AzureStorageContext)this.Context);
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
            CloudBlobContainer = container;
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

        //refresh XSCL track2 container properties object from server
        public void FetchAttributes()
        {
            privateBlobContainerProperties = BlobContainerClient.GetProperties().Value;
        }

        // Convert Track1 Container object to Track 2 Container Client
        protected static BlobContainerClient GetTrack2BlobContainerClient(CloudBlobContainer cloubContainer, AzureStorageContext context)
        {
            BlobContainerClient blobContainerClient;
            if (cloubContainer.ServiceClient.Credentials.IsToken) //Oauth
            {
                if (context == null)
                {
                    //TODO : Get Oauth context from current login user.
                    throw new System.Exception("Need Storage Context to convert Track1 object in token credentail to Track2 object.");
                }
                blobContainerClient = new BlobContainerClient(cloubContainer.Uri, context.Track2OauthToken);

            }
            else if (cloubContainer.ServiceClient.Credentials.IsSAS) //SAS
            {
                string fullUri = cloubContainer.Uri.ToString();
                fullUri = fullUri + cloubContainer.ServiceClient.Credentials.SASToken;
                blobContainerClient = new BlobContainerClient(new Uri(fullUri));
            }
            else if (cloubContainer.ServiceClient.Credentials.IsSharedKey) //Shared Key
            {
                blobContainerClient = new BlobContainerClient(cloubContainer.Uri,
                    new StorageSharedKeyCredential(context.StorageAccountName, cloubContainer.ServiceClient.Credentials.ExportBase64EncodedKey()));
            }
            else //Anonymous
            {
                blobContainerClient = new BlobContainerClient(cloubContainer.Uri);
            }

            return blobContainerClient;
        }
    }
}
