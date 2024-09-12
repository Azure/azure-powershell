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
using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
using Azure.Storage.Files.Shares;
using Azure;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;

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
        [Alias("BlobContainerClient")]
        public BlobContainerClient SrcContainer { get; set; }

        [Parameter(HelpMessage = "Source blob instance", Mandatory = true,
           ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = BlobFilePathParameterSet)]
        [Parameter(HelpMessage = "Source blob instance", Mandatory = true,
           ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = BlobFileParameterSet)]
        [Alias("BlobBaseClient")]
        public BlobBaseClient SrcBlob { get; set; }

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
        //[Parameter(HelpMessage = "Source Azure Storage Context Object",
            //Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ContainerParameterSet)]
        //[Parameter(HelpMessage = "Source Azure Storage Context Object",
        //    Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = BlobFilePathParameterSet)]
        //[Parameter(HelpMessage = "Source Azure Storage Context Object",
        //    Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = BlobFileParameterSet)]
        //[Parameter(HelpMessage = "Source Azure Storage Context Object",
            //Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ShareParameterSet)]
        //[Parameter(HelpMessage = "Source Azure Storage Context Object",
        //    Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = FileFileParameterSet)]
        //[Parameter(HelpMessage = "Source Azure Storage Context Object",
        //    Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = FileFilePathParameterSet)]
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
                //this.ParameterSetName == ContainerParameterSet || 
                //this.ParameterSetName == BlobFilePathParameterSet ||
                //this.ParameterSetName == BlobFileParameterSet ||
                //this.ParameterSetName == ShareParameterSet
                //this.ParameterSetName == FileFilePathParameterSet || 
                //this.ParameterSetName == FileFileParameterSet
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
            //If Channl object exists, use it.
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
                        destChannel = new StorageFileManagement(this.GetCmdletStorageContext(DestContext));
                    }
                }
                else if (BlobFileParameterSet == this.ParameterSetName ||
                    FileFileParameterSet == this.ParameterSetName ||
                    UriFileParameterSet == this.ParameterSetName)
                {
                    destChannel = new StorageFileManagement(this.GetCmdletStorageContext(DestContext));
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
            BlobBaseClient blob = null;
            string sourceBlobRelativeName = null;

            if (null != this.SrcBlob)
            {
                blob = this.SrcBlob;
                sourceBlobRelativeName = blob.Name;
            }
            else
            {
                BlobContainerClient srcContainer = null;

                if (null != this.SrcContainer)
                {
                    srcContainer = this.SrcContainer;
                }
                else
                {
                    NameUtil.ValidateContainerName(this.SrcContainerName);
                    srcContainer = this.blobChannel.GetBlobContainerClient(this.SrcContainerName);
              
                }
                NameUtil.ValidateBlobName(this.SrcBlobName);
                blob = srcContainer.GetBlobBaseClient(this.SrcBlobName);
                sourceBlobRelativeName = this.SrcBlobName;
            }

            ShareFileClient destFile = GetDestFile();

            Func<long, Task> taskGenerator = (taskId) => StartAsyncCopy(
                taskId,
                destFile,
                () => this.ConfirmOverwrite(Util.GetSnapshotQualifiedUri(blob.Uri), Util.GetSnapshotQualifiedUri(destFile.Uri)),
                () => destFile.StartCopyAsync(blob.GenerateUriWithCredentials((AzureStorageContext)this.Context), cancellationToken: this.CmdletCancellationToken));

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

            //if (((AzureStorageContext)this.Context).Track2OauthToken != null
            //    && string.Compare(sourceFile.Uri.Host, destFile.Uri.Host, ignoreCase: true) != 0)
            //{
            //    WriteWarning("The source File is on Azure AD credential, might cause cross account file copy fail. Please use source File based on SharedKey or SAS creadencial to avoid the failure.");
            //}

            if (!sourceFile.CanGenerateSasUri && string.Compare(sourceFile.Uri.Host, destFile.Uri.Host, ignoreCase: true) != 0)
            {
                WriteWarning("The source File cannot generate SAS Uri and might cause cross account file copy failures. Please use source File based on SharedKey or SAS creadencial to avoid the failure.");
            }

            Func<long, Task> taskGenerator = (taskId) => StartAsyncCopy(
                taskId,
                destFile,
                () => this.ConfirmOverwrite(Util.GetSnapshotQualifiedUri(sourceFile.Uri), Util.GetSnapshotQualifiedUri(destFile.Uri)),
                () => destFile.StartCopyAsync(sourceFile.GenerateUriWithCredentials(), cancellationToken: this.CmdletCancellationToken));

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
