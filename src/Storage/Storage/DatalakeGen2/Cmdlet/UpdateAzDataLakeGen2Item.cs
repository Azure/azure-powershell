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
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using System.Management.Automation;
    using System.Collections;
    using Microsoft.WindowsAzure.Commands.Storage.Model.ResourceModel;
    using global::Azure.Storage.Files.DataLake;
    using global::Azure.Storage.Files.DataLake.Models;

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

        [Parameter(ValueFromPipeline = true, Mandatory = false, HelpMessage =
                "The path in the specified FileSystem that should be updated. Can be a file or directory " +
                "In the format 'directory/file.txt' or 'directory1/directory2/'. Skip set this parameter to update the root directory of the Filesystem.", ParameterSetName = ManualParameterSet)]
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

        [Parameter(HelpMessage = "Specifies properties for the directory or file. " +
            "The supported properties for file are: CacheControl, ContentDisposition, ContentEncoding, ContentLanguage, ContentMD5, ContentType." +
            "The supported properties for directory are: CacheControl, ContentDisposition, ContentEncoding, ContentLanguage.", 
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

        [Parameter(HelpMessage = "Specifies metadata for the directory or file.", 
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
        public override int? ClientTimeoutPerRequest { get; set; }
        public override int? ServerTimeoutPerRequest { get; set; }
        public override string TagCondition { get; set; }


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

            bool foundAFolder = false;

            DataLakeFileClient fileClient = null;
            DataLakeDirectoryClient dirClient = null;
            if (ParameterSetName == ManualParameterSet)
            {
                DataLakeFileSystemClient fileSystem = GetFileSystemClientByName(localChannel, this.FileSystem);
                foundAFolder = GetExistDataLakeGen2Item(fileSystem, this.Path, out fileClient, out dirClient);
            }
            else //BlobParameterSet
            {
                if (!InputObject.IsDirectory)
                {
                    fileClient = InputObject.File;
                }
                else
                {
                    dirClient = InputObject.Directory;
                    foundAFolder = true;
                }
            }

            if (foundAFolder)
            {
                if (ShouldProcess(GetDataLakeItemUriWithoutSas(dirClient), "Update Directory: "))
                {
                    //Set Permission
                    if (this.Permission != null || this.Owner != null || this.Group != null)
                    {
                        //PathAccessControl originPathAccessControl = dirClient.GetAccessControl().Value;
                        dirClient.SetPermissions(
                            this.Permission != null ? PathPermissions.ParseSymbolicPermissions(this.Permission) : null,
                            this.Owner,
                            this.Group);
                    }

                    //Set ACL            
                    if (this.Acl != null)
                    {
                        dirClient.SetAccessControlList(PSPathAccessControlEntry.ParseAccessControls(this.Acl));
                    }

                    // Set Properties
                    SetDatalakegen2ItemProperties(dirClient, this.BlobProperties, setToServer: true);

                    //Set MetaData
                    SetDatalakegen2ItemMetaData(dirClient, this.BlobMetadata, setToServer: true);

                    WriteDataLakeGen2Item(localChannel, dirClient);
                }
            }
            else
            {
                if (ShouldProcess(GetDataLakeItemUriWithoutSas(fileClient), "Update File: "))
                {
                    //Set Permission
                    if (this.Permission != null || this.Owner != null || this.Group != null)
                    {
                        fileClient.SetPermissions(
                            this.Permission != null ? PathPermissions.ParseSymbolicPermissions(this.Permission) : null,
                            this.Owner,
                            this.Group);
                    }

                    //Set ACL            
                    if (this.Acl != null)
                    {
                        fileClient.SetAccessControlList(PSPathAccessControlEntry.ParseAccessControls(this.Acl));
                    }

                    // Set Properties
                    SetDatalakegen2ItemProperties(fileClient, this.BlobProperties, setToServer: true);

                    //Set MetaData
                    SetDatalakegen2ItemMetaData(fileClient, this.BlobMetadata, setToServer: true);

                    WriteDataLakeGen2Item(localChannel, fileClient);
                }
            }
        }
    }
}
