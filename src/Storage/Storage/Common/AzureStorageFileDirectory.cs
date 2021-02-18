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

    /// <summary>
    /// Azure storage file object
    /// </summary>
    public class AzureStorageFileDirectory : AzureStorageBase
    {
        /// <summary>
        /// CloudBlob object
        /// </summary>    
        [Ps1Xml(Label = "Share Uri", Target = ViewControl.Table, GroupByThis = true, ScriptBlock = "if (IsDirectory) {$_.CloudFileDirectory.Share.Uri} else {$_.CloudFile.Share.Uri}")]
        [Ps1Xml(Label = "Name", Target = ViewControl.Table, ScriptBlock = "$_.Name", Position = 0, TableColumnWidth = 20)]  
        public CloudFileDirectory CloudFileDirectory { get; private set; }
        
        /// <summary>
        /// file last modified time
        /// </summary>
        [Ps1Xml(Label = "LastModified", Target = ViewControl.Table, ScriptBlock = "$_.LastModified.UtcDateTime.ToString(\"u\")", Position = 2, TableColumnWidth = 20)]
        public DateTimeOffset? LastModified { get; private set; }

        /// <summary>
        /// XSCL Track2 File Client, used to run file APIs
        /// </summary>
        public ShareDirectoryClient ShareDirectoryClient
        {
            get
            {
                if (privateFileDirClient == null)
                {
                    privateFileDirClient = GetTrack2FileDirClient(this.CloudFileDirectory, (AzureStorageContext)this.Context);
                }
                return privateFileDirClient;
            }
        }
        private ShareDirectoryClient privateFileDirClient = null;

        /// <summary>
        /// XSCL Track2 File properties, will retrieve the properties on server and return to user
        /// </summary>
        public global::Azure.Storage.Files.Shares.Models.ShareDirectoryProperties ShareDirectoryProperties
        {
            get
            {
                if (privateFileDirProperties == null)
                {
                    privateFileDirProperties = ShareDirectoryClient.GetProperties().Value;
                }
                return privateFileDirProperties;
            }
        }
        private global::Azure.Storage.Files.Shares.Models.ShareDirectoryProperties privateFileDirProperties = null;


        /// <summary>
        /// Azure storage file constructor
        /// </summary>
        /// <param name="file">Cloud file Directory object</param>
        public AzureStorageFileDirectory(CloudFileDirectory dir, AzureStorageContext storageContext)
        {
            Name = dir.Name;
            CloudFileDirectory = dir;
            LastModified = dir.Properties.LastModified;
            Context = storageContext;
        }

        // Convert Track1 File Dir object to Track 2 file Dir Client
        protected static ShareDirectoryClient GetTrack2FileDirClient(CloudFileDirectory cloudFileDir, AzureStorageContext context)
        {
            ShareDirectoryClient fileDirClient;
            if (cloudFileDir.ServiceClient.Credentials.IsSAS) //SAS
            {
                string fullUri = cloudFileDir.SnapshotQualifiedUri.ToString();
                if (cloudFileDir.Share.IsSnapshot)
                {
                    // Since snapshot URL already has '?', need remove '?' in the first char of sas
                    fullUri = fullUri + "&" + cloudFileDir.ServiceClient.Credentials.SASToken.Substring(1);
                }
                else
                {
                    fullUri = fullUri + cloudFileDir.ServiceClient.Credentials.SASToken;
                }
                fileDirClient = new ShareDirectoryClient(new Uri(fullUri));
            }
            else if (cloudFileDir.ServiceClient.Credentials.IsSharedKey) //Shared Key
            {
                fileDirClient = new ShareDirectoryClient(cloudFileDir.SnapshotQualifiedUri,
                    new StorageSharedKeyCredential(context.StorageAccountName, cloudFileDir.ServiceClient.Credentials.ExportBase64EncodedKey()));
            }
            else //Anonymous
            {
                fileDirClient = new ShareDirectoryClient(cloudFileDir.SnapshotQualifiedUri);
            }

            return fileDirClient;
        }
    }
}
