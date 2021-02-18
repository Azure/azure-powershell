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
    public class AzureStorageFile : AzureStorageBase
    {
        /// <summary>
        /// CloudBlob object
        /// </summary>    
        [Ps1Xml(Label = "Share Uri", Target = ViewControl.Table, GroupByThis = true, ScriptBlock = "$_.CloudFile.Share.Uri")]
        [Ps1Xml(Label = "Name", Target = ViewControl.Table, ScriptBlock = "$_.Name", Position = 0, TableColumnWidth = 20)]
        public CloudFile CloudFile { get; private set; }

        /// <summary>
        /// Blob length
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
                    privateFileClient = GetTrack2FileClient(this.CloudFile, (AzureStorageContext)this.Context);
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
        /// Azure storage file constructor
        /// </summary>
        /// <param name="file">Cloud file object</param>
        public AzureStorageFile(CloudFile file, AzureStorageContext storageContext)
        {
            Name = file.Name;
            CloudFile = file;
            Length = file.Properties.Length;
            LastModified = file.Properties.LastModified;
            Context = storageContext;
        }

        // Convert Track1 File object to Track 2 file Client
        public static ShareFileClient GetTrack2FileClient(CloudFile cloudFile, AzureStorageContext context)
        {
            ShareFileClient fileClient;
            if (cloudFile.ServiceClient.Credentials.IsSAS) //SAS
            {
                string fullUri = cloudFile.SnapshotQualifiedUri.ToString();
                if (cloudFile.Share.IsSnapshot)
                {
                    // Since snapshot URL already has '?', need remove '?' in the first char of sas
                    fullUri = fullUri + "&" + cloudFile.ServiceClient.Credentials.SASToken.Substring(1);
                }
                else
                {
                    fullUri = fullUri + cloudFile.ServiceClient.Credentials.SASToken;
                }
                fileClient = new ShareFileClient(new Uri(fullUri));
            }
            else if (cloudFile.ServiceClient.Credentials.IsSharedKey) //Shared Key
            {
                fileClient = new ShareFileClient(cloudFile.SnapshotQualifiedUri,
                    new StorageSharedKeyCredential(context.StorageAccountName, cloudFile.ServiceClient.Credentials.ExportBase64EncodedKey()));
            }
            else //Anonymous
            {
                fileClient = new ShareFileClient(cloudFile.SnapshotQualifiedUri);
            }

            return fileClient;
        }
    }
}
