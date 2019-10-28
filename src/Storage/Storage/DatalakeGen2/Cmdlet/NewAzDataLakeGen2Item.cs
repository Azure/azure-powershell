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
    using Microsoft.Azure.Storage.DataMovement;
    using System.IO;
    using Microsoft.WindowsAzure.Commands.Common;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;

    /// <summary>
    /// create a new DataLakeGen2 Item
    /// </summary>
    [Cmdlet("New", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "DataLakeGen2Item", SupportsShouldProcess = true, DefaultParameterSetName = FileParameterSet), OutputType(typeof(AzureDataLakeGen2Item))]
    public class NewAzDataLakeGen2ItemCommand : StorageDataMovementCmdletBase
    {
        /// <summary>
        /// Create a Folder parameter
        /// </summary>
        private const string FolderParameterSet = "Folder";

        /// <summary>
        /// Create a file parameter
        /// </summary>
        private const string FileParameterSet = "File";

        [Parameter(ValueFromPipeline = true, Position = 0, Mandatory = true, HelpMessage = "Container name")]
        [ValidateNotNullOrEmpty]
        public string Container { get; set; }

        [Parameter(ValueFromPipeline = true, Position = 1, Mandatory = true, HelpMessage =
                "The path in the specified container that should be create. Can be a file or folder " +
                "In the format 'folder/file.txt' or 'folder1/folder2/'")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Indicates that this new item is a folder and not a file.", ParameterSetName = FolderParameterSet)]
        public SwitchParameter Folder { get; set; }

        [Parameter(ValueFromPipeline = true, Mandatory = true, HelpMessage = "Specify the local source file path which will be upload to a Datalake Gen2 file.", ParameterSetName = FileParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Source
        {
            get { return FileName; }
            set { FileName = value; }
        }

        private string FileName = String.Empty;

        [Parameter(Mandatory = false,
            HelpMessage = "When creating New Item and the parent folder does not have a default ACL, the umask restricts the permissions of the file or directory to be created. The resulting permission is given by p & ^u, where p is the permission and u is the umask. Symbolic (rwxrw-rw-) is supported.")]
        [ValidateNotNullOrEmpty]
        [ValidatePattern("([r-][w-][x-]){3}")]
        public string Umask { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Sets POSIX access permissions for the file owner, the file owning group, and others. Each class may be granted read, write, or execute permission. Symbolic (rwxrw-rw-) is supported. ")]
        [ValidateNotNullOrEmpty]
        [ValidatePattern("([r-][w-][x-]){3}")]
        public string Permission { get; set; }


        [Parameter(HelpMessage = "Specifies properties for the created folder or file. "+
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

        [Parameter(HelpMessage = "Specifies metadata for the created folder or file.", Mandatory = false)]
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

        /// <summary>
        /// Initializes a new instance of the NewAzDataLakeGen2ItemCommand class.
        /// </summary>
        public NewAzDataLakeGen2ItemCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the NewAzDataLakeGen2ItemCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public NewAzDataLakeGen2ItemCommand(IStorageBlobManagement channel)
        {
            Channel = channel;
        }

        protected override void ProcessRecord()
        {
            try
            {
                ResolvedFileName = this.GetUnresolvedProviderPathFromPSPath(string.IsNullOrWhiteSpace(this.FileName) ? "." : this.FileName);
                Validate.ValidateInternetConnection();
                InitChannelCurrentSubscription();
                this.ExecuteSynchronouslyOrAsJob();
            }
            catch (Exception ex) when (!IsTerminatingError(ex))
            {
                WriteExceptionError(ex);
            }
        }

        /// <summary>
        /// execute command
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (AsJob.IsPresent)
            {
                DoBeginProcessing();
            }

            IStorageBlobManagement localChannel = Channel;
            BlobRequestOptions requestOptions = RequestOptions;
            CloudBlobContainer container = GetCloudBlobContainerByName(localChannel, this.Container).ConfigureAwait(false).GetAwaiter().GetResult();

            if (this.Folder.IsPresent)
            {
                CloudBlobDirectory blobDir = container.GetDirectoryReference(this.Path);
                if (ShouldProcess(blobDir.Uri.ToString(), "Create Folder: "))
                {
                    if (blobDir.Exists())
                    {
                        throw new ResourceAlreadyExistException(String.Format("Folder '{0}' already exists.", blobDir.Uri));
                    }

                    if (this.Permission != null)
                    {
                        blobDir.PathProperties.Permissions = PathPermissions.ParseSymbolic(this.Permission);
                    }

                    // Set BlobDir Properties and MetaData
                    SetBlobDirProperties(blobDir, BlobProperties, setToServer: false);
                    SetBlobDirMetadata(blobDir, BlobMetadata, setToServer: false);

                    blobDir.Create(requestOptions,
                            this.Umask != null ? PathPermissions.ParseSymbolic(this.Umask) : null);

                    blobDir.FetchAttributes();
                    WriteDataLakeGen2Item(localChannel, blobDir, null, fetchPermission: true);
                }
            }
            else //create File
            {
                CloudBlockBlob blob = container.GetBlockBlobReference(this.Path);

                if (ShouldProcess(blob.Uri.ToString(), "Create File: "))
                {
                    //SetBlobContent(blob, ResolvedFileName, true);

                    //UploadBlob(taskId, localChannel, blob, filePath);
                    Func<long, Task> taskGenerator = (taskId) => Upload2Blob(taskId, Channel, ResolvedFileName, blob);
                    RunTask(taskGenerator);
                }
            }


            if (AsJob.IsPresent)
            {
                DoEndProcessing();
            }
        }

        /// <summary>
        /// Set blob content
        /// </summary>
        /// <param name="blob">Dest CloudBlob object</param>
        /// <param name="fileName">source local file path</param>
        /// <param name="isValidBlob">whether the source container validated</param>
        /// <returns>the uploaded blob object</returns>
        internal void SetBlobContent(CloudBlockBlob blob, string fileName, bool isValidBlob = false)
        {
            if (!isValidBlob)
            {
                ValidatePipelineCloudBlob(blob);
            }

            //UploadBlob(taskId, localChannel, blob, filePath);
            Func<long, Task> taskGenerator = (taskId) => Upload2Blob(taskId, Channel, fileName, blob);
            RunTask(taskGenerator);
        }

        /// <summary>
        /// upload file to azure blob
        /// </summary>
        /// <param name="taskId">Task id</param>
        /// <param name="filePath">local file path</param>
        /// <param name="blob">destination azure blob object</param>
        internal virtual async Task Upload2Blob(long taskId, IStorageBlobManagement localChannel, string filePath, CloudBlob blob)
        {
            string activity = String.Format(Resources.SendAzureBlobActivity, filePath, blob.Name, blob.Container.Name);
            string status = Resources.PrepareUploadingBlob;
            ProgressRecord pr = new ProgressRecord(OutputStream.GetProgressId(taskId), activity, status);

            FileInfo fileInfo = new FileInfo(filePath);

            DataMovementUserData data = new DataMovementUserData()
            {
                Data = blob,
                TaskId = taskId,
                Channel = localChannel,
                Record = pr,
                TotalSize = fileInfo.Length
            };

            SingleTransferContext transferContext = this.GetTransferContext(data);

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
            transferContext.SetAttributesCallbackAsync = async (destination) =>
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
            {
                CloudBlob destBlob = destination as CloudBlob;
                SetBlobProperties((CloudBlockBlob)destBlob, this.BlobProperties, false);
                SetBlobMetaData((CloudBlockBlob)destBlob, this.BlobMetadata, false);
            };

            await DataMovementTransferHelper.DoTransfer(() =>
            {
                return this.TransferManager.UploadAsync(filePath,
                    blob,
                    null,
                    transferContext,
                    this.CmdletCancellationToken);
            },
                data.Record,
                this.OutputStream).ConfigureAwait(false);

            // Set blob permission with umask, since create Blob API still not support them
            SetBlobPermissionWithUMask((CloudBlockBlob)blob, this.Permission, this.Umask);

            blob.FetchAttributes();
            WriteDataLakeGen2Item(localChannel, (CloudBlockBlob)blob, taskId: data.TaskId);
        }

        /// <summary>
        /// Set block blob permission with Umask after blob is created
        /// Add this since XSCL don't have interface to set permission with umask in create blob
        /// Won't set when both permission and umask are null/empty, and use server default behavior.
        /// </summary>
        /// <param name="blob">the blob object to set permission with umask</param>
        /// <param name="permission">permission string to set, in format "rwxrwxrwx", default value is "rwxrwxrwx"</param>
        /// <param name="umask">umask string to set, in format "rwxrwxrwx", default value is "----w-rwx"</param>
        protected static void SetBlobPermissionWithUMask(CloudBlockBlob blob, string permission, String umask)
        {
            // Don't need set permission when both input permission and umask are null
            if (string.IsNullOrEmpty(permission) && string.IsNullOrEmpty(umask))
            {
                return;
            }

            //Set the default value if one of permission or Umask is null
            // Confirmed with feature team:
            //  Default permission for files is 666 (default permission for directory is 777, this function is for file so use 666)
            //  default umask is 027
            if (string.IsNullOrEmpty(permission))
            {
                permission = "rw-rw-rw-";
            }
            if (string.IsNullOrEmpty(umask))
            {
                umask = "----w-rwx";
            }

            // Get the permission value to set, from input Permission and Umask
            // The permission and umask string format is already checked with parameter ValidatePattern
            string blobPermission = string.Empty;
            for (int i = 0; i < permission.Length; i++)
            {
                if (umask[i] != '-')
                {
                    blobPermission += '-';
                }
                else
                {
                    blobPermission += permission[i];
                }
            }

            //Set permission to blob
            blob.PathProperties.Permissions = PathPermissions.ParseSymbolic(blobPermission);
            blob.SetPermissions();
        }
    }
}
