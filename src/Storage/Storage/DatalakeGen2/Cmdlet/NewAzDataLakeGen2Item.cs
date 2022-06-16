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
    using global::Azure.Storage.Files.DataLake;
    using global::Azure.Storage.Files.DataLake.Models;
    using DataLakeModels = global::Azure.Storage.Files.DataLake.Models;
    using System.Globalization;

    /// <summary>
    /// create a new DataLakeGen2 Item
    /// </summary>
    [Cmdlet("New", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "DataLakeGen2Item", SupportsShouldProcess = true, DefaultParameterSetName = FileParameterSet), OutputType(typeof(AzureDataLakeGen2Item))]
    public class NewAzDataLakeGen2ItemCommand : StorageDataMovementCmdletBase
    {
        /// <summary>
        /// Create a Directory parameter
        /// </summary>
        private const string DirectoryParameterSet = "Directory";

        /// <summary>
        /// Create a file parameter
        /// </summary>
        private const string FileParameterSet = "File";

        private const string defaultFilePermission = "rw-rw-rw-";
        private const string defaultUmask = "----w-rwx";

        private DataLakeFileSystemClient fileSystem;

        [Parameter(ValueFromPipeline = true, Position = 0, Mandatory = true, HelpMessage = "FileSystem name")]
        [ValidateNotNullOrEmpty]
        public string FileSystem { get; set; }

        [Parameter(ValueFromPipeline = true, Position = 1, Mandatory = true, HelpMessage =
                "The path in the specified FileSystem that should be create. Can be a file or directory " +
                "In the format 'directory/file.txt' or 'directory1/directory2/'")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Indicates that this new item is a directory and not a file.", ParameterSetName = DirectoryParameterSet)]
        public SwitchParameter Directory { get; set; }

        [Parameter(ValueFromPipeline = true, Mandatory = true, HelpMessage = "Specify the local source file path which will be upload to a Datalake Gen2 file.", ParameterSetName = FileParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Source
        {
            get { return FileName; }
            set { FileName = value; }
        }

        private string FileName = String.Empty;

        [Parameter(Mandatory = false,
            HelpMessage = "When creating New Item and the parent directory does not have a default ACL, the umask restricts the permissions of the file or directory to be created. The resulting permission is given by p & ^u, where p is the permission and u is the umask. Symbolic (rwxrw-rw-) is supported.")]
        [ValidateNotNullOrEmpty]
        [ValidatePattern("([r-][w-][x-]){3}")]
        public string Umask { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Sets POSIX access permissions for the file owner, the file owning group, and others. Each class may be granted read, write, or execute permission. Symbolic (rwxrw-rw-) is supported. ")]
        [ValidateNotNullOrEmpty]
        [ValidatePattern("([r-][w-][x-]){3}")]
        public string Permission { get; set; }


        [Parameter(HelpMessage = "Specifies properties for the created directory or file. "+
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

        [Parameter(HelpMessage = "Specifies metadata for the created directory or file.", Mandatory = false)]
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

        // Overwrite the useless parameter
        public override int? ClientTimeoutPerRequest { get; set; }
        public override int? ServerTimeoutPerRequest { get; set; }
        public override string TagCondition { get; set; }

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
            fileSystem = GetFileSystemClientByName(localChannel, this.FileSystem);

            if (this.Directory.IsPresent)
            {
                DataLakeDirectoryClient dirClient = fileSystem.GetDirectoryClient(this.Path);
                if (ShouldProcess(GetDataLakeItemUriWithoutSas(dirClient), "Create Directory: "))
                {
                    if (dirClient.Exists())
                    {
                        throw new ResourceAlreadyExistException(String.Format("Folder '{0}' already exists.", GetDataLakeItemUriWithoutSas(dirClient)));
                    }
                    DataLakeModels.PathPermissions pathPermissions = null;
                    if (this.Permission != null)
                    {
                        pathPermissions = DataLakeModels.PathPermissions.ParseSymbolicPermissions(this.Permission);
                    }

                    // Set BlobDir Properties and MetaData
                    PathHttpHeaders pathHttpHeaders = SetDatalakegen2ItemProperties(dirClient, BlobProperties, setToServer: false);
                    IDictionary<string, string> metadata = SetDatalakegen2ItemMetaData(dirClient, BlobMetadata, setToServer: false);

                    dirClient.Create(pathHttpHeaders, 
                        metadata, 
                        this.Permission, 
                        this.Umask != null ? DataLakeModels.PathPermissions.ParseSymbolicPermissions(this.Umask).ToOctalPermissions() : null);

                    WriteDataLakeGen2Item(localChannel, dirClient);
                }
            }
            else //create File
            {
                DataLakeFileClient fileClient = fileSystem.GetFileClient(this.Path);
                if (ShouldProcess(GetDataLakeItemUriWithoutSas(fileClient), "Create File: "))
                {
                    // Use SDK to upload directly when use SAS credential, and need set permission, since set permission after upload will fail with SAS
                    if (Channel.StorageContext.StorageAccount.Credentials.IsSAS
                        && (!string.IsNullOrEmpty(this.Permission) || !string.IsNullOrEmpty(this.Umask)))
                    {
                        Func<long, Task> taskGenerator = (taskId) => UploadDataLakeFile(taskId, fileClient, ResolvedFileName);
                        RunTask(taskGenerator);
                    }
                    else
                    {
                        CloudBlobContainer container = Channel.GetContainerReference(this.FileSystem);
                        CloudBlockBlob blob = container.GetBlockBlobReference(this.Path);

                        Func<long, Task> taskGenerator = (taskId) => Upload2Blob(taskId, Channel, ResolvedFileName, blob);
                        RunTask(taskGenerator);
                    }
                }
            }


            if (AsJob.IsPresent)
            {
                DoEndProcessing();
            }
        }

        /// <summary>
        /// Upload File with Datalake API
        /// </summary>
        internal virtual async Task UploadDataLakeFile(long taskId, DataLakeFileClient fileClient, string filePath)
        {
            if (this.Force.IsPresent || !fileClient.Exists() || ShouldContinue(string.Format(Resources.OverwriteConfirmation, GetDataLakeItemUriWithoutSas(fileClient)), null))
            {

                // Set Item Properties and MetaData
                PathHttpHeaders pathHttpHeaders = SetDatalakegen2ItemProperties(fileClient, BlobProperties, setToServer: false);
                IDictionary<string, string> metadata = SetDatalakegen2ItemMetaData(fileClient, BlobMetadata, setToServer: false);

                fileClient.Create(pathHttpHeaders,
                    metadata,
                    this.Permission,
                    this.Umask != null ? DataLakeModels.PathPermissions.ParseSymbolicPermissions(this.Umask).ToOctalPermissions() : null);

                long fileSize = new FileInfo(ResolvedFileName).Length;
                string activity = String.Format(Resources.SendAzureBlobActivity, this.Source, this.Path, this.FileSystem);
                string status = Resources.PrepareUploadingBlob;
                ProgressRecord pr = new ProgressRecord(OutputStream.GetProgressId(taskId), activity, status);
                IProgress<long> progressHandler = new Progress<long>((finishedBytes) =>
                {
                    if (pr != null)
                    {
                        // Size of the source file might be 0, when it is, directly treat the progress as 100 percent.
                        pr.PercentComplete = 0 == fileSize ? 100 : (int)(finishedBytes * 100 / fileSize);
                        pr.StatusDescription = string.Format(CultureInfo.CurrentCulture, Resources.FileTransmitStatus, pr.PercentComplete);
                        this.OutputStream.WriteProgress(pr);
                    }
                });

                using (FileStream stream = File.OpenRead(ResolvedFileName))
                {
                    await fileClient.AppendAsync(stream, 0, progressHandler: progressHandler, cancellationToken: CmdletCancellationToken).ConfigureAwait(false);
                }
                WriteDataLakeGen2Item(Channel, fileClient, taskId: taskId);
            }

        }

        /// <summary>
        /// Set blob content
        /// </summary>
        /// <param name="blob">Dest CloudBlob object</param>
        /// <param name="fileName">source local file path</param>
        /// <param name="isValidBlob">whether the source FileSystem validated</param>
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
        /// <param name="localChannel">IStorageBlobManagement channel object</param>
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
            transferContext.SetAttributesCallbackAsync = async (source, destination) =>
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
            {
                CloudBlob destBlob = destination as CloudBlob;
                SetAzureBlobContentCommand.SetBlobProperties(destBlob, this.BlobProperties);
                SetAzureBlobContentCommand.SetBlobMeta(destBlob, this.BlobMetadata);
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

            WriteDataLakeGen2Item(localChannel, fileSystem.GetFileClient(blob.Name), taskId: data.TaskId);
        }

        /// <summary>
        /// Set block blob permission with Umask after blob is created
        /// Add this since XSCL don't have interface to set permission with umask in create blob
        /// Won't set when both permission and umask are null/empty, and use server default behavior.
        /// </summary>
        /// <param name="blob">the blob object to set permission with umask</param>
        /// <param name="permission">permission string to set, in format "rwxrwxrwx", default value is "rwxrwxrwx"</param>
        /// <param name="umask">umask string to set, in format "rwxrwxrwx", default value is "----w-rwx"</param>
        protected void SetBlobPermissionWithUMask(CloudBlockBlob blob, string permission, String umask)
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
                permission = defaultFilePermission;
            }
            if (string.IsNullOrEmpty(umask))
            {
                umask = defaultUmask;
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
            fileSystem.GetFileClient(blob.Name).SetPermissions(DataLakeModels.PathPermissions.ParseSymbolicPermissions(blobPermission));
        }
    }
}
