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

namespace Microsoft.WindowsAzure.Commands.Storage.Blob.Cmdlet
{
    using Commands.Common.Storage.ResourceModel;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using Microsoft.Azure.Storage.Blob;
    using System;
    using System.Management.Automation;
    using System.Security.Permissions;
    using System.Threading.Tasks;
    using System.Collections;
    using System.Collections.Generic;
    using Microsoft.WindowsAzure.Commands.Storage.Model.ResourceModel;

    /// <summary>
    /// create a new azure FileSystem
    /// </summary>
    [Cmdlet("Update", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "DataLakeGen2Item", DefaultParameterSetName = ManualParameterSet, SupportsShouldProcess = true),OutputType(typeof(AzureDataLakeGen2Item))]
    public class SetAzDataLakeGen2ItemCommand : StorageCloudBlobCmdletBase
    {
        /// <summary>
        /// manually set the name parameter
        /// </summary>
        private const string ManualParameterSet = "ReceiveManual";

        /// <summary>
        /// Blob or BlobDir pipeline
        /// </summary>
        private const string BlobParameterSet = "ItemPipeline";

        [Parameter(ValueFromPipeline = true, Position = 0, Mandatory = true, HelpMessage = "FileSystem name", ParameterSetName = ManualParameterSet)]
        [ValidateNotNullOrEmpty]
        public string FileSystem { get; set; }

        [Parameter(ValueFromPipeline = true, Position = 1, Mandatory = true, HelpMessage =
                "The path in the specified FileSystem that should be updated. Can be a file or folder " +
                "In the format 'folder/file.txt' or 'folder1/folder2/'", ParameterSetName = ManualParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Azure Datalake Gen2 Item Object to update",
            ValueFromPipeline = true, ParameterSetName = BlobParameterSet)]
        [ValidateNotNull]
        public AzureDataLakeGen2Item InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Sets POSIX access permissions for the file owner, the file owning group, and others. Each class may be granted read, write, or execute permission. Symbolic (rwxrw-rw-) is supported. Invalid in conjunction with ACL.")]
        [ValidateNotNullOrEmpty]
        [ValidatePattern("([r-][w-][x-]){3}")]
        public string Permission { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Sets the owner of the item.")]
        [ValidateNotNullOrEmpty]
        public string Owner { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Sets the owning group of the item.")]
        [ValidateNotNullOrEmpty]
        public string Group { get; set; }

        [Parameter(HelpMessage = "Specifies properties for the folder or file. " +
            "The supported properties for file are: CacheControl, ContentDisposition, ContentEncoding, ContentLanguage, ContentMD5, ContentType." +
            "The supported properties for folder are: CacheControl, ContentDisposition, ContentEncoding, ContentLanguage.", 
            Mandatory = false)]
        public Hashtable Property
        {
            get
            {
                return BlobProperties;
            }

            set
            {
                BlobProperties = value;
            }
        }
        private Hashtable BlobProperties = null;

        [Parameter(HelpMessage = "Specifies metadata for the folder or file.", 
            Mandatory = false)]
        public Hashtable Metadata
        {
            get
            {
                return BlobMetadata;
            }

            set
            {
                BlobMetadata = value;
            }
        }
        private Hashtable BlobMetadata = null;

        [Parameter(HelpMessage = "Sets POSIX access control rights on files and directories. Create this object with New-AzDataLakeGen2ItemAclObject.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public PSPathAccessControlEntry[] Acl { get; set; }

        // Overwrite the useless parameter
        public override int? ConcurrentTaskCount { get; set; }


        /// <summary>
        /// Initializes a new instance of the SetAzDataLakeGen2ItemCommand class.
        /// </summary>
        public SetAzDataLakeGen2ItemCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SetAzDataLakeGen2ItemCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public SetAzDataLakeGen2ItemCommand(IStorageBlobManagement channel)
        {
            Channel = channel;
        }
        
        /// <summary>
        /// execute command
        /// </summary>
        public override void ExecuteCmdlet()
        {
            IStorageBlobManagement localChannel = Channel;
            BlobRequestOptions requestOptions = RequestOptions;

            bool foundAFolder = false;
            CloudBlockBlob blob = null;
            CloudBlobDirectory blobDir = null;
            if (ParameterSetName == ManualParameterSet)
            {
                CloudBlobContainer container = GetCloudBlobContainerByName(localChannel, this.FileSystem).ConfigureAwait(false).GetAwaiter().GetResult();
                foundAFolder = GetExistDataLakeGen2Item(container, this.Path, out blob, out blobDir);
            }
            else //BlobParameterSet
            {
                if (!InputObject.IsDirectory)
                {
                    blob = (CloudBlockBlob)InputObject.ICloudBlob;
                }
                else
                {
                    blobDir = InputObject.CloudBlobDirectory;
                    foundAFolder = true;
                }
            }

            if (foundAFolder)
            {
                if (ShouldProcess(blobDir.Uri.ToString(), "Update Folder: "))
                {
                    //Set Permission
                    if (this.Permission != null || this.Owner != null || this.Group != null)
                    {
                        blobDir.FetchAccessControls();
                        if (this.Permission != null)
                        {
                            blobDir.PathProperties.Permissions = PathPermissions.ParseSymbolic(this.Permission);
                        }
                        if (this.Owner != null)
                        {
                            blobDir.PathProperties.Owner = this.Owner;
                        }
                        if (this.Group != null)
                        {
                            blobDir.PathProperties.Group = this.Group;
                        }
                        blobDir.SetPermissions();
                    }

                    //Set ACL            
                    if (this.Acl != null)
                    {
                        blobDir.PathProperties.ACL = PSPathAccessControlEntry.ParseAccessControls(this.Acl);
                        blobDir.SetAcl();
                    }

                    // Set Properties
                    SetBlobDirProperties(blobDir, this.BlobProperties);

                    //Set MetaData
                    SetBlobDirMetadata(blobDir, this.BlobMetadata);

                    blobDir.FetchAttributes();
                    WriteDataLakeGen2Item(localChannel, blobDir, null, fetchPermission: true);
                }
            }
            else
            {
                if (ShouldProcess(blob.Uri.ToString(), "Update File: "))
                {
                    //Set permission
                    if (this.Permission != null || this.Owner != null || this.Group != null)
                    {
                        blob.FetchAccessControls();
                        if (this.Permission != null)
                        {
                            blob.PathProperties.Permissions = PathPermissions.ParseSymbolic(this.Permission);
                        }
                        if (this.Owner != null)
                        {
                            blob.PathProperties.Owner = this.Owner;
                        }
                        if (this.Group != null)
                        {
                            blob.PathProperties.Group = this.Group;
                        }
                        blob.SetPermissions();
                    }

                    //Set ACL               
                    if (this.Acl != null)
                    {
                        blob.PathProperties.ACL = PSPathAccessControlEntry.ParseAccessControls(this.Acl);
                        blob.SetAcl();
                    }

                    // Set Blob Properties
                    SetBlobProperties(blob, this.BlobProperties);

                    //Set Blob MetaData
                    SetBlobMetaData(blob, this.BlobMetadata);
                }

                blob.FetchAttributes();
                WriteDataLakeGen2Item(Channel, blob, null, fetchPermission: true);
            }
        }
    }
}
