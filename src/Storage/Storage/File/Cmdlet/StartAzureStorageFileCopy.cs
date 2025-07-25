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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
using System;
using System.Management.Automation;
using System.Security.Permissions;
using System.Threading.Tasks;
using Microsoft.Azure.Storage.Blob;
using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
using Azure.Storage.Files.Shares;
using Azure;
using Azure.Storage.Files.Shares.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Globalization;

namespace Microsoft.WindowsAzure.Commands.Storage.File.Cmdlet
{
    [Cmdlet("Start", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageFileCopy", SupportsShouldProcess = true), OutputType(typeof(AzureStorageFile))]
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
        [Alias("ShareClient")]
        public ShareClient SrcShare { get; set; }

        [Parameter(HelpMessage = "Source file instance",
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = FileFilePathParameterSet)]
        [Parameter(HelpMessage = "Source file instance",
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = FileFileParameterSet)]
        [ValidateNotNull]
        [Alias("ShareFileClient")]
        public ShareFileClient SrcFile { get; set; }

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

        [Parameter(Mandatory = false, ParameterSetName = BlobFileParameterSet, HelpMessage = "ShareFileClient object indicated the Dest file.")]
        [Parameter(Mandatory = false, ParameterSetName = FileFileParameterSet, HelpMessage = "ShareFileClient object indicated the Dest file.")]
        [Parameter(Mandatory = false, ParameterSetName = UriFileParameterSet, HelpMessage = "ShareFileClient object indicated the Dest file.")]
        [ValidateNotNull]
        [Alias("DestFile")]
        public ShareFileClient DestShareFileClient { get; set; }

        [Alias("SrcContext")]
        [Parameter(HelpMessage = "Source Azure Storage Context Object",
            Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ContainerNameParameterSet)]
        [Parameter(HelpMessage = "Source Azure Storage Context Object",
            Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ShareNameParameterSet)]
        public override IStorageContext Context { get; set; }

        [Parameter(HelpMessage = "Destination Storage context object", ParameterSetName = ContainerNameParameterSet)]
        [Parameter(HelpMessage = "Destination Storage context object", ParameterSetName = ContainerParameterSet)]
        [Parameter(HelpMessage = "Destination Storage context object", ParameterSetName = BlobFilePathParameterSet)]
        [Parameter(HelpMessage = "Destination Storage context object", ParameterSetName = ShareNameParameterSet)]
        [Parameter(HelpMessage = "Destination Storage context object", ParameterSetName = ShareParameterSet)]
        [Parameter(HelpMessage = "Destination Storage context object", ParameterSetName = FileFilePathParameterSet)]
        [Parameter(HelpMessage = "Destination Storage context object", ParameterSetName = UriFilePathParameterSet)]
        [Parameter(HelpMessage = "Destination Storage context object", ParameterSetName = BlobFileParameterSet)]
        [Parameter(HelpMessage = "Destination Storage context object", ParameterSetName = FileFileParameterSet)]
        [Parameter(HelpMessage = "Destination Storage context object", ParameterSetName = UriFileParameterSet)]
        public IStorageContext DestContext { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Disallow trailing dot (.) to suffix source directory and source file names.", ParameterSetName = ShareNameParameterSet)]
        public virtual SwitchParameter DisAllowSourceTrailingDot { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Disallow trailing dot (.) to suffix destination directory and destination file names.", ParameterSetName = ContainerNameParameterSet)]
        [Parameter(Mandatory = false, HelpMessage = "Disallow trailing dot (.) to suffix destination directory and destination file names.", ParameterSetName = ShareNameParameterSet)]
        public virtual SwitchParameter DisAllowDestTrailingDot { get; set; }

        private const string fileModeParameterDescription = "The mode permissions to be set on the destination file. Only applicable to NFS Files. Only work together with parameter `-FileModeCopyMode Override`. Symbolic (rwxrw-rw-) is supported.";
        [Parameter(Mandatory = false, ParameterSetName = ShareNameParameterSet, HelpMessage = fileModeParameterDescription)]
        [Parameter(Mandatory = false, ParameterSetName = ShareParameterSet, HelpMessage = fileModeParameterDescription)]
        [Parameter(Mandatory = false, ParameterSetName = FileFilePathParameterSet, HelpMessage = fileModeParameterDescription)]
        [Parameter(Mandatory = false, ParameterSetName = FileFileParameterSet, HelpMessage = fileModeParameterDescription)]
        [ValidateNotNullOrEmpty]
        [ValidatePattern("([r-][w-][xsS-]){2}([r-][w-][xtT-])")]
        public string FileMode { get; set; }

        private const string ownerParameterDescription = "The owner user identifier (UID) to be set on the destination file. Only applicable to NFS Files. Need specify together with parameter `-OwnerCopyMode Override`.";
        [Parameter(Mandatory = false, ParameterSetName = ShareNameParameterSet, HelpMessage = ownerParameterDescription)]
        [Parameter(Mandatory = false, ParameterSetName = ShareParameterSet, HelpMessage = ownerParameterDescription)]
        [Parameter(Mandatory = false, ParameterSetName = FileFilePathParameterSet, HelpMessage = ownerParameterDescription)]
        [Parameter(Mandatory = false, ParameterSetName = FileFileParameterSet, HelpMessage = ownerParameterDescription)]
        [ValidateNotNullOrEmpty]
        public string Owner { get; set; }

        private const string groupParameterDescription = "The owner group identifier (GID) to be set on the destination file. Only applicable to NFS Files. Need specify together with parameter `-OwnerCopyMode Override`.";
        [Parameter(Mandatory = false, ParameterSetName = ShareNameParameterSet, HelpMessage = groupParameterDescription)]
        [Parameter(Mandatory = false, ParameterSetName = ShareParameterSet, HelpMessage = groupParameterDescription)]
        [Parameter(Mandatory = false, ParameterSetName = FileFilePathParameterSet, HelpMessage = groupParameterDescription)]
        [Parameter(Mandatory = false, ParameterSetName = FileFileParameterSet, HelpMessage = groupParameterDescription)]
        [ValidateNotNullOrEmpty]
        public string Group { get; set; }

        private const string ownerCopyModeParameterDescription = "Only applicable to NFS Files. The value \"Override\" need to be specified together with parameter `-Owner` and `-Group`. If not specified, the destination file will have the default Owner and Group.";
        [Parameter(Mandatory = false, ParameterSetName = ShareNameParameterSet, HelpMessage = ownerCopyModeParameterDescription)]
        [Parameter(Mandatory = false, ParameterSetName = ShareParameterSet, HelpMessage = ownerCopyModeParameterDescription)]
        [Parameter(Mandatory = false, ParameterSetName = FileFilePathParameterSet, HelpMessage = ownerCopyModeParameterDescription)]
        [Parameter(Mandatory = false, ParameterSetName = FileFileParameterSet, HelpMessage = ownerCopyModeParameterDescription)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Source", "Override")]
        public string OwnerCopyMode { get; set; }

        private const string fileModeCopyModeParameterDescription = "Only applicable to NFS Files. The value \"Override\" need to be specified together with parameter `-FileMode`. If not specified, the destination file will have the default File Mode.";
        [Parameter(Mandatory = false, ParameterSetName = ShareNameParameterSet, HelpMessage = fileModeCopyModeParameterDescription)]
        [Parameter(Mandatory = false, ParameterSetName = ShareParameterSet, HelpMessage = fileModeCopyModeParameterDescription)]
        [Parameter(Mandatory = false, ParameterSetName = FileFilePathParameterSet, HelpMessage = fileModeCopyModeParameterDescription)]
        [Parameter(Mandatory = false, ParameterSetName = FileFileParameterSet, HelpMessage = fileModeCopyModeParameterDescription)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Source", "Override")]
        public string FileModeCopyMode { get; set; }

        // Overwrite the useless parameter
        public override SwitchParameter AsJob { get; set; }
        public override SwitchParameter DisAllowTrailingDot { get; set; }

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
                this.ParameterSetName == ShareNameParameterSet 
                )
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
            //If Channel object exists, use it.
            //Otherwise, create a new channel.
            IStorageFileManagement destChannel = default(IStorageFileManagement);

            if (destChannel == null)
            {
                if (ContainerNameParameterSet == this.ParameterSetName ||
                    ContainerParameterSet == this.ParameterSetName ||
                    BlobFilePathParameterSet == this.ParameterSetName ||
                    ShareNameParameterSet == this.ParameterSetName ||
                    ShareParameterSet == this.ParameterSetName ||
                    FileFilePathParameterSet == this.ParameterSetName ||
                    UriFilePathParameterSet == this.ParameterSetName)
                {
                    if (DestContext == null)
                    {
                        if (Channel != null)
                        {
                            destChannel = Channel;
                        }
                        else
                        {
                            destChannel = base.CreateChannel();
                        }
                    }
                    else
                    {
                        destChannel = new StorageFileManagement(this.GetCmdletStorageContext(DestContext, isDestContext:true));
                    }
                }
                else if (BlobFileParameterSet == this.ParameterSetName ||
                    FileFileParameterSet == this.ParameterSetName ||
                    UriFileParameterSet == this.ParameterSetName)
                {
                    destChannel = new StorageFileManagement(this.GetCmdletStorageContext(DestContext, isDestContext:true));
                }
                else
                {
                    destChannel = base.CreateChannel();
                }
            }

            return destChannel;
        }

        /// <summary>
        /// Execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            if (this.DisAllowSourceTrailingDot)
            {
                this.ClientOptions.AllowSourceTrailingDot = false;
            }
            if (this.DisAllowDestTrailingDot)
            {
                this.ClientOptions.AllowTrailingDot = false;
            }

            blobChannel = this.GetBlobChannel();
            destChannel = GetDestinationChannel();
            IStorageFileManagement srcChannel = Channel;
            Action copyAction = null;
            string target = this.DestShareFileClient != null ? this.DestShareFileClient.Name : DestFilePath;
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

            ShareFileClient destFile = GetDestFile();

            Func<long, Task> taskGenerator = (taskId) => StartAsyncCopy(
                taskId,
                destFile,
                () => this.ConfirmOverwrite(blob.SnapshotQualifiedUri.ToString(), Util.GetSnapshotQualifiedUri(destFile.Uri)),
                () => destFile.StartCopyAsync(blob.GenerateUriWithCredentials(), cancellationToken: this.CmdletCancellationToken));

            this.RunTask(taskGenerator);
        }

        private void StartCopyFromFile()
        {
            ShareFileClient sourceFile = null;

            if (null != this.SrcFile)
            {
                sourceFile = this.SrcFile;
            }
            else
            {
                ShareDirectoryClient dir = null;

                if (null != this.SrcShare)
                {
                    dir = this.SrcShare.GetRootDirectoryClient();
                }
                else
                {
                    NamingUtil.ValidateShareName(this.SrcShareName, false);

                    ShareClientOptions srcClientOptions = new ShareClientOptions();
                    if (this.DisAllowSourceTrailingDot)
                    {
                        srcClientOptions.AllowTrailingDot = false;
                    }
                    dir = Util.GetTrack2FileServiceClient((AzureStorageContext)this.Context, srcClientOptions).GetShareClient(this.SrcShareName).GetRootDirectoryClient();
                }

                // Remove trailing dots manually if DisAllowSourceTrailing dot is specified 
                string filepath = this.SrcFilePath;
                if (this.DisAllowSourceTrailingDot)
                {
                    filepath = Util.RemoveFilePathTrailingDot(filepath);
                }
                sourceFile = dir.GetFileClient(filepath);
            }

            ShareFileClient destFile = this.GetDestFile();

            if (!sourceFile.CanGenerateSasUri && (sourceFile.Uri.Query != null && !sourceFile.Uri.Query.Contains("sig=")) && string.Compare(sourceFile.Uri.Host, destFile.Uri.Host, ignoreCase: true) != 0)
            {
                WriteWarning("The source File cannot generate SAS Uri and might cause cross account file copy failures. Please use source File based on SharedKey or SAS credential to avoid the failure.");
            }

            ShareFileCopyOptions copyOptions = new ShareFileCopyOptions();
            if (this.FileMode != null || this.Owner != null || this.Group != null)
            {
                copyOptions.PosixProperties = new FilePosixProperties()
                {
                    FileMode = this.FileMode is null ? null : NfsFileMode.ParseSymbolicFileMode(this.FileMode),
                    Group = this.Group,
                    Owner = this.Owner
                };
            }
            if (this.FileModeCopyMode != null)
            {
                // Parse FileModeCopyMode
                if (Enum.TryParse<ModeCopyMode>(this.FileModeCopyMode, out var modeCopyMode))
                {
                    copyOptions.ModeCopyMode = modeCopyMode;
                }
                else 
                {
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Can't parse FileModeCopyMode \"{0}\", only \"Source\" and \"Override\" are supported.", this.FileModeCopyMode));
                }
            }
            if (this.OwnerCopyMode != null)
            {
                // Parse OwnerCopyMode
                if (Enum.TryParse<OwnerCopyMode>(this.OwnerCopyMode, out var ownerCopyMode))
                {
                    copyOptions.OwnerCopyMode = ownerCopyMode;
                }
                else
                {
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Can't parse OwnerCopyMode \"{0}\", only \"Source\" and \"Override\" are supported.", this.OwnerCopyMode));
                }
            }

            Func<long, Task> taskGenerator = (taskId) => StartAsyncCopy(
                taskId,
                destFile,
                () => this.ConfirmOverwrite(Util.GetSnapshotQualifiedUri(sourceFile.Uri), Util.GetSnapshotQualifiedUri(destFile.Uri)),
                () => destFile.StartCopyAsync(sourceFile.GenerateUriWithCredentials(), copyOptions, cancellationToken: this.CmdletCancellationToken));

            this.RunTask(taskGenerator);
        }

        private void StartCopyFromUri()
        {
            ShareFileClient destFile = this.GetDestFile();

            Func<long, Task> taskGenerator = (taskId) => StartAsyncCopy(
                taskId,
                destFile,
                () => this.ConfirmOverwrite(this.AbsoluteUri, Util.GetSnapshotQualifiedUri(destFile.Uri)),
                () => destFile.StartCopyAsync(new Uri(this.AbsoluteUri), cancellationToken: this.CmdletCancellationToken));

            this.RunTask(taskGenerator);
        }

        private ShareFileClient GetDestFile()
        {
            destChannel = this.GetDestinationChannel();

            if(this.DestShareFileClient != null)
            {
                return this.DestShareFileClient;
            }
            else
            {
                NamingUtil.ValidateShareName(this.DestShareName, false);
                ShareServiceClient fileserviceClient = Util.GetTrack2FileServiceClient(destChannel.StorageContext, ClientOptions);
                return fileserviceClient.GetShareClient(this.DestShareName).GetRootDirectoryClient().GetFileClient(this.DestFilePath);
            }
        }

        private async Task StartAsyncCopy(long taskId, ShareFileClient destFile, Func<bool> checkOverwrite, Func<Task<Response<ShareFileCopyInfo>>> startCopy)
        {
            bool destExist = true;
            try
            {
                await destFile.GetPropertiesAsync(cancellationToken: this.CmdletCancellationToken).ConfigureAwait(false);
            }
            catch (global::Azure.RequestFailedException ex) when (ex.Status == 404)
            {
                destExist = false;
            }

            if (!destExist || checkOverwrite())
            {
                ShareFileCopyInfo copyInfo = (await startCopy().ConfigureAwait(false)).Value;

                this.OutputStream.WriteVerbose(taskId, String.Format(Resources.CopyDestinationBlobPending, destFile.Path, destFile.ShareName, copyInfo.CopyId));
                this.OutputStream.WriteObject(taskId, new AzureStorageFile(destFile, destChannel.StorageContext, clientOptions: ClientOptions));
            }
        }
    }
}
