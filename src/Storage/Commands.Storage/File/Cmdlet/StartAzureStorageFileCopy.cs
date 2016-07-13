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

using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.File;
using System;
using System.Management.Automation;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.Storage.File.Cmdlet
{
    [Cmdlet(VerbsLifecycle.Start, Constants.FileCopyCmdletName, SupportsShouldProcess = true)]
    public class StartAzureStorageFileCopyCommand : StorageFileDataManagementCmdletBase
    {
        private const string ContainerNameParameterSet = "ContainerName";
        private const string ContainerParameterSet = "ContainerInstance";
        private const string BlobFilePathParameterSet = "BlobInstanceFilePath";
        private const string BlobFileParameterSet = "BlobInstanceFileInstance";
        private const string ShareNameParameterSet = "ShareName";
        private const string ShareParameterSet = "ShareInstance";
        private const string FileFilePathParameterSet = "FileInstanceToFilePath";
        private const string FileFileParameterSet = "FileInstanceToFileInstance";
        private const string UriFilePathParameterSet = "UriToFilePath";
        private const string UriFileParameterSet = "UriToFileInstance";

        [Parameter(HelpMessage = "Source blob name", Mandatory = true, ParameterSetName = ContainerNameParameterSet)]
        [Parameter(HelpMessage = "Source blob name", Mandatory = true, ParameterSetName = ContainerParameterSet)]
        [ValidateNotNullOrEmpty]
        public string SrcBlobName { get; set; }

        [Parameter(HelpMessage = "Source container name", Mandatory = true, ParameterSetName = ContainerNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string SrcContainerName { get; set; }

        [Parameter(HelpMessage = "Source container instance", Mandatory = true, ParameterSetName = ContainerParameterSet)]
        [ValidateNotNull]
        public CloudBlobContainer SrcContainer { get; set; }

        [Alias("ICloudBlob")]
        [Parameter(HelpMessage = "Source blob instance", Mandatory = true,
           ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = BlobFilePathParameterSet)]
        [Parameter(HelpMessage = "Source blob instance", Mandatory = true,
           ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = BlobFileParameterSet)]
        [ValidateNotNull]
        public CloudBlob SrcBlob { get; set; }

        [Parameter(HelpMessage = "Source file path", Mandatory = true, ParameterSetName = ShareNameParameterSet)]
        [Parameter(HelpMessage = "Source file path", Mandatory = true, ParameterSetName = ShareParameterSet)]
        [ValidateNotNullOrEmpty]
        public string SrcFilePath { get; set; }

        [Parameter(HelpMessage = "Source share name", Mandatory = true, ParameterSetName = ShareNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string SrcShareName { get; set; }

        [Parameter(HelpMessage = "Source share instance", Mandatory = true, ParameterSetName = ShareParameterSet)]
        [ValidateNotNull]
        public CloudFileShare SrcShare { get; set; }

        [Parameter(HelpMessage = "Source file instance", Mandatory = true,
           ValueFromPipeline = true, ParameterSetName = FileFilePathParameterSet)]
        [Parameter(HelpMessage = "Source file instance", Mandatory = true,
           ValueFromPipeline = true, ParameterSetName = FileFileParameterSet)]
        [ValidateNotNull]
        public CloudFile SrcFile { get; set; }

        [Parameter(HelpMessage = "Source Uri", Mandatory = true, ParameterSetName = UriFilePathParameterSet)]
        [Parameter(HelpMessage = "Source Uri", Mandatory = true, ParameterSetName = UriFileParameterSet)]
        [ValidateNotNullOrEmpty]
        public string AbsoluteUri { get; set; }

        [Parameter(HelpMessage = "Dest share name", Mandatory = true, ParameterSetName = ContainerNameParameterSet)]
        [Parameter(HelpMessage = "Dest share name", Mandatory = true, ParameterSetName = ContainerParameterSet)]
        [Parameter(HelpMessage = "Dest share name", Mandatory = true, ParameterSetName = BlobFilePathParameterSet)]
        [Parameter(HelpMessage = "Dest share name", Mandatory = true, ParameterSetName = ShareNameParameterSet)]
        [Parameter(HelpMessage = "Dest share name", Mandatory = true, ParameterSetName = ShareParameterSet)]
        [Parameter(HelpMessage = "Dest share name", Mandatory = true, ParameterSetName = FileFilePathParameterSet)]
        [Parameter(HelpMessage = "Dest share name", Mandatory = true, ParameterSetName = UriFilePathParameterSet)]
        [ValidateNotNullOrEmpty]
        public string DestShareName { get; set; }

        [Parameter(HelpMessage = "Dest file path", Mandatory = true, ParameterSetName = ContainerNameParameterSet)]
        [Parameter(HelpMessage = "Dest file path", Mandatory = true, ParameterSetName = ContainerParameterSet)]
        [Parameter(HelpMessage = "Dest file path", Mandatory = true, ParameterSetName = BlobFilePathParameterSet)]
        [Parameter(HelpMessage = "Dest file path", Mandatory = true, ParameterSetName = ShareNameParameterSet)]
        [Parameter(HelpMessage = "Dest file path", Mandatory = true, ParameterSetName = ShareParameterSet)]
        [Parameter(HelpMessage = "Dest file path", Mandatory = true, ParameterSetName = FileFilePathParameterSet)]
        [Parameter(HelpMessage = "Dest file path", Mandatory = true, ParameterSetName = UriFilePathParameterSet)]
        [ValidateNotNullOrEmpty]
        public string DestFilePath { get; set; }

        [Parameter(HelpMessage = "Dest file instance", Mandatory = true, ParameterSetName = BlobFileParameterSet)]
        [Parameter(HelpMessage = "Dest file instance", Mandatory = true, ParameterSetName = FileFileParameterSet)]
        [Parameter(HelpMessage = "Dest file instance", Mandatory = true, ParameterSetName = UriFileParameterSet)]
        [ValidateNotNull]
        public CloudFile DestFile { get; set; }

        [Alias("SrcContext")]
        [Parameter(HelpMessage = "Source Azure Storage Context Object",
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ContainerNameParameterSet)]
        [Parameter(HelpMessage = "Source Azure Storage Context Object",
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ShareNameParameterSet)]
        public override AzureStorageContext Context { get; set; }

        [Parameter(HelpMessage = "Destination Storage context object", ParameterSetName = ContainerNameParameterSet)]
        [Parameter(HelpMessage = "Destination Storage context object", ParameterSetName = ContainerParameterSet)]
        [Parameter(HelpMessage = "Destination Storage context object", ParameterSetName = BlobFilePathParameterSet)]
        [Parameter(HelpMessage = "Destination Storage context object", ParameterSetName = ShareNameParameterSet)]
        [Parameter(HelpMessage = "Destination Storage context object", ParameterSetName = ShareParameterSet)]
        [Parameter(HelpMessage = "Destination Storage context object", ParameterSetName = FileFilePathParameterSet)]
        [Parameter(HelpMessage = "Destination Storage context object", ParameterSetName = UriFilePathParameterSet)]
        public AzureStorageContext DestContext { get; set; }

        private IStorageBlobManagement blobChannel = null;

        private BlobToAzureFileNameResolver nameResolver = new BlobToAzureFileNameResolver(() => NameUtil.MaxFileNameLength);

        private IStorageFileManagement destChannel = null;

        public StartAzureStorageFileCopyCommand()
        {
            EnableMultiThread = true;
        }

        /// <summary>
        /// Create file client and storage service management channel if need to.
        /// </summary>
        /// <returns>IStorageFileManagement object</returns>
        protected override IStorageFileManagement CreateChannel()
        {
            if (this.Channel == null || !this.ShareChannel)
            {
                this.Channel = new StorageFileManagement(this.GetSourceContext());
            }

            return this.Channel;
        }

        private IStorageBlobManagement GetBlobChannel()
        {
            return new StorageBlobManagement(this.GetSourceContext());
        }

        private AzureStorageContext GetSourceContext()
        {
            if (this.ParameterSetName == ContainerNameParameterSet ||
                this.ParameterSetName == ShareNameParameterSet)
            {
                return this.GetCmdletStorageContext();
            }
            else
            {
                return AzureStorageContext.EmptyContextInstance;
            }
        }

        /// <summary>
        /// Set up the Channel object for destination share and file
        /// </summary>
        internal IStorageFileManagement GetDestinationChannel()
        {
            //If destChannel exits, reuse it.
            //If desContext exits, use it.
            //If Channl object exists, use it.
            //Otherwise, create a new channel.
            IStorageFileManagement destChannel = default(IStorageFileManagement);

            if (destChannel == null)
            {
                AzureStorageContext context = null;

                if (ContainerNameParameterSet == this.ParameterSetName ||
                    ContainerParameterSet == this.ParameterSetName ||
                    BlobFilePathParameterSet == this.ParameterSetName ||
                    ShareNameParameterSet == this.ParameterSetName ||
                    ShareParameterSet == this.ParameterSetName ||
                    FileFilePathParameterSet == this.ParameterSetName ||
                    UriFilePathParameterSet == this.ParameterSetName)
                {
                    context = this.GetCmdletStorageContext(DestContext);
                }
                else
                {
                    context = AzureStorageContext.EmptyContextInstance;
                }

                destChannel = new StorageFileManagement(context);
            }

            return destChannel;
        }

        /// <summary>
        /// Execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            blobChannel = this.GetBlobChannel();
            destChannel = GetDestinationChannel();
            IStorageFileManagement srcChannel = Channel;
            Action copyAction = null;
            string target = DestFile != null ? DestFile.Name : DestFilePath;
            switch (ParameterSetName)
            {
                case ContainerNameParameterSet:
                case ContainerParameterSet:
                case BlobFilePathParameterSet:
                case BlobFileParameterSet:
                    copyAction = () => this.StartCopyFromBlob();
                    break;
                case ShareNameParameterSet:
                case ShareParameterSet:
                case FileFilePathParameterSet:
                case FileFileParameterSet:
                    copyAction = () => this.StartCopyFromFile();
                    break;
                case UriFilePathParameterSet:
                case UriFileParameterSet:
                    copyAction = () => this.StartCopyFromUri();
                    break;
            }

            if (copyAction != null && ShouldProcess(target, "Start file copy"))
            {
                copyAction();
            }
        }

        private void StartCopyFromBlob()
        {
            CloudBlob blob = null;
            string sourceBlobRelativeName = null;

            if (null != this.SrcBlob)
            {
                blob = this.SrcBlob;
                sourceBlobRelativeName = blob.Name;
            }
            else
            {
                CloudBlobContainer srcContainer = null;

                if (null != this.SrcContainer)
                {
                    srcContainer = this.SrcContainer;
                }
                else
                {
                    NameUtil.ValidateContainerName(this.SrcContainerName);
                    srcContainer = this.blobChannel.GetContainerReference(this.SrcContainerName);
                }
                NameUtil.ValidateBlobName(this.SrcBlobName);
                blob = srcContainer.GetBlobReference(this.SrcBlobName);
                sourceBlobRelativeName = this.SrcBlobName;
            }

            CloudFile destFile = GetDestFile();

            Func<long, Task> taskGenerator = (taskId) => StartAsyncCopy(
                taskId,
                destFile,
                () => this.ConfirmOverwrite(blob.SnapshotQualifiedUri.ToString(), destFile.Uri.ToString()),
                () => destFile.StartCopyAsync(blob.GenerateCopySourceBlob(), null, null, this.RequestOptions, this.OperationContext, CmdletCancellationToken));

            this.RunTask(taskGenerator);
        }

        private void StartCopyFromFile()
        {
            CloudFile sourceFile = null;
            string filePath = null;

            if (null != this.SrcFile)
            {
                sourceFile = this.SrcFile;
                filePath = this.SrcFile.GetFullPath();
            }
            else
            {
                CloudFileDirectory dir = null;

                if (null != this.SrcShare)
                {
                    dir = this.SrcShare.GetRootDirectoryReference();
                }
                else
                {
                    NamingUtil.ValidateShareName(this.SrcShareName, false);
                    dir = this.BuildFileShareObjectFromName(this.SrcShareName).GetRootDirectoryReference();
                }

                string[] path = NamingUtil.ValidatePath(this.SrcFilePath, true);
                sourceFile = dir.GetFileReferenceByPath(path);
                filePath = this.SrcFilePath;
            }

            CloudFile destFile = this.GetDestFile();

            Func<long, Task> taskGenerator = (taskId) => StartAsyncCopy(
                taskId,
                destFile,
                () => this.ConfirmOverwrite(sourceFile.Uri.ToString(), destFile.Uri.ToString()),
                () => destFile.StartCopyAsync(sourceFile.GenerateCopySourceFile(), null, null, this.RequestOptions, this.OperationContext, this.CmdletCancellationToken));

            this.RunTask(taskGenerator);
        }

        private void StartCopyFromUri()
        {
            CloudFile destFile = this.GetDestFile();

            Func<long, Task> taskGenerator = (taskId) => StartAsyncCopy(
                taskId,
                destFile,
                () => this.ConfirmOverwrite(this.AbsoluteUri, destFile.Uri.ToString()),
                () => destFile.StartCopyAsync(new Uri(this.AbsoluteUri), null, null, this.RequestOptions, this.OperationContext));

            this.RunTask(taskGenerator);
        }

        private CloudFile GetDestFile()
        {
            var destChannal = this.GetDestinationChannel();

            if (null != this.DestFile)
            {
                return this.DestFile;
            }
            else
            {
                string destPath = this.DestFilePath;

                NamingUtil.ValidateShareName(this.DestShareName, false);
                CloudFileShare share = destChannal.GetShareReference(this.DestShareName);

                string[] path = NamingUtil.ValidatePath(destPath, true);
                return share.GetRootDirectoryReference().GetFileReferenceByPath(path);
            }
        }

        private async Task StartAsyncCopy(long taskId, CloudFile destFile, Func<bool> checkOverwrite, Func<Task<string>> startCopy)
        {
            bool destExist = true;
            try
            {
                await destFile.FetchAttributesAsync(null, this.RequestOptions, this.OperationContext, this.CmdletCancellationToken);
            }
            catch (StorageException ex)
            {
                if (!ex.IsNotFoundException())
                {
                    throw;
                }

                destExist = false;
            }

            if (!destExist || checkOverwrite())
            {
                string copyId = await startCopy();

                this.OutputStream.WriteVerbose(taskId, String.Format(Resources.CopyDestinationBlobPending, destFile.GetFullPath(), destFile.Share.Name, copyId));
                this.OutputStream.WriteObject(taskId, destFile);
            }
        }
    }
}
