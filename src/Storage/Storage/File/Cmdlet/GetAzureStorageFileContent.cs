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

using Microsoft.Azure.Storage.File;
using System.Globalization;
using System.IO;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.Storage.File.Cmdlet
{
    using global::Azure;
    using global::Azure.Storage.Files.Shares;
    using global::Azure.Storage.Files.Shares.Models;
    using Microsoft.Azure.Documents.Partitioning;
    using Microsoft.Azure.Storage.DataMovement;
    using Microsoft.WindowsAzure.Commands.Common;
    using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using System;
    using System.Runtime.InteropServices;
    using LocalConstants = Microsoft.WindowsAzure.Commands.Storage.File.Constants;
    using LocalDirectory = System.IO.Directory;
    using LocalPath = System.IO.Path;

    [Cmdlet("Get", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageFileContent", SupportsShouldProcess = true, DefaultParameterSetName = LocalConstants.ShareNameParameterSetName)]
    [OutputType(typeof(AzureStorageFile))]
    public class GetAzureStorageFileContent : StorageFileDataManagementCmdletBase, IDynamicParameters
    {
        [Parameter(
           Position = 0,
           Mandatory = true,
           ParameterSetName = LocalConstants.ShareNameParameterSetName,
           HelpMessage = "Name of the file share where the file would be downloaded.")]
        [ValidateNotNullOrEmpty]
        public string ShareName { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = LocalConstants.ShareParameterSetName,
            HelpMessage = "CloudFileShare object indicated the share where the file would be downloaded.")]
        [ValidateNotNull]
        [Alias("CloudFileShare")]
        public CloudFileShare Share { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = LocalConstants.DirectoryParameterSetName,
            HelpMessage = "CloudFileDirectory object indicated the cloud directory where the file would be downloaded.")]
        [ValidateNotNull]
        [Alias("CloudFileDirectory")]
        public CloudFileDirectory Directory { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = LocalConstants.FileParameterSetName,
            HelpMessage = "CloudFile object indicated the cloud file to be downloaded.")]
        [ValidateNotNull]
        [Alias("CloudFile")]
        public CloudFile File { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = LocalConstants.ShareNameParameterSetName,
            HelpMessage = "Path to the cloud file to be downloaded.")]
        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = LocalConstants.ShareParameterSetName,
            HelpMessage = "Path to the cloud file to be downloaded.")]
        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = LocalConstants.DirectoryParameterSetName,
            HelpMessage = "Path to the cloud file to be downloaded.")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(
            Position = 2,
            ParameterSetName = LocalConstants.ShareNameParameterSetName,
            HelpMessage = "Path to the local file or directory when the downloaded file would be put.")]
        [Parameter(
            Position = 2,
            ParameterSetName = LocalConstants.ShareParameterSetName,
            HelpMessage = "Path to the local file or directory when the downloaded file would be put.")]
        [Parameter(
            Position = 2,
            ParameterSetName = LocalConstants.DirectoryParameterSetName,
            HelpMessage = "Path to the local file or directory when the downloaded file would be put.")]
        [Parameter(
            Position = 1,
            ParameterSetName = LocalConstants.FileParameterSetName,
            HelpMessage = "Path to the local file or directory when the downloaded file would be put.")]
        [ValidateNotNullOrEmpty]
        public string Destination { get; set; }

        [Parameter(HelpMessage = "check the md5sum")]
        public SwitchParameter CheckMd5
        {
            get;
            set;
        }

        [Parameter(HelpMessage = "Returns an object representing the downloaded cloud file. By default, this cmdlet does not generate any output.")]
        public SwitchParameter PassThru { get; set; }

        protected override void ProcessRecord()
        {
            try
            {
                Destination = this.GetUnresolvedProviderPathFromPSPath(
                    string.IsNullOrWhiteSpace(Destination) ? "." : Destination);
                Validate.ValidateInternetConnection();
                InitChannelCurrentSubscription();
                this.ExecuteSynchronouslyOrAsJob();
            }
            catch (Exception ex) when (!IsTerminatingError(ex))
            {
                WriteExceptionError(ex);
            }
        }

        public override void ExecuteCmdlet()
        {
            if (AsJob.IsPresent)
            {
                DoBeginProcessing();
            }

            CloudFile fileToBeDownloaded;
            string[] path = NamingUtil.ValidatePath(this.Path, true);
            switch (this.ParameterSetName)
            {
                case LocalConstants.FileParameterSetName:
                    fileToBeDownloaded = this.File;
                    break;

                case LocalConstants.ShareNameParameterSetName:
                    var share = this.BuildFileShareObjectFromName(this.ShareName);
                    fileToBeDownloaded = share.GetRootDirectoryReference().GetFileReferenceByPath(path);
                    break;

                case LocalConstants.ShareParameterSetName:
                    fileToBeDownloaded = this.Share.GetRootDirectoryReference().GetFileReferenceByPath(path);
                    break;

                case LocalConstants.DirectoryParameterSetName:
                    fileToBeDownloaded = this.Directory.GetFileReferenceByPath(path);
                    break;

                default:
                    throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid parameter set name: {0}", this.ParameterSetName));
            }

            string resolvedDestination = this.Destination;
            FileMode mode = this.Force ? FileMode.Create : FileMode.CreateNew;
            string targetFile;
            if (LocalDirectory.Exists(resolvedDestination))
            {
                // If the destination pointed to an existing directory, we
                // would download the file into the folder with the same name
                // on cloud.
                targetFile = LocalPath.Combine(resolvedDestination, fileToBeDownloaded.GetBaseName());
            }
            else
            {
                // Otherwise we treat the destination as a file no matter if
                // there's one existing or not. The overwrite behavior is configured
                // by FileMode.
                targetFile = resolvedDestination;
            }

            if (ShouldProcess(targetFile, "Download"))
            {
                this.RunTask(async taskId =>
                {
                    await
                        fileToBeDownloaded.FetchAttributesAsync(null, this.RequestOptions, OperationContext,
                            CmdletCancellationToken).ConfigureAwait(false);

                    var progressRecord = new ProgressRecord(
                        this.OutputStream.GetProgressId(taskId),
                        string.Format(CultureInfo.CurrentCulture, Resources.ReceiveAzureFileActivity,
                            fileToBeDownloaded.GetFullPath(), targetFile),
                        Resources.PrepareDownloadingFile);

                    // If not Oauth, use DMlib
                    if (!(this.Channel != null && this.Channel.StorageContext != null && this.Channel.StorageContext.StorageAccount != null && this.Channel.StorageContext.StorageAccount.Credentials.IsToken))
                    {
                        await DataMovementTransferHelper.DoTransfer(() =>
                        {
                            return this.TransferManager.DownloadAsync(
                                fileToBeDownloaded,
                                targetFile,
                                new DownloadOptions
                                {
                                    DisableContentMD5Validation = !this.CheckMd5,
                                    PreserveSMBAttributes = context is null ? false : context.PreserveSMBAttribute.IsPresent
                                },
                                this.GetTransferContext(progressRecord, fileToBeDownloaded.Properties.Length),
                                CmdletCancellationToken);
                        },
                            progressRecord,
                            this.OutputStream).ConfigureAwait(false);
                    }
                    else // Track2 SDK 
                    {
                        ShareFileClient fileClientToDownload = AzureStorageFile.GetTrack2FileClient(fileToBeDownloaded, this.ClientOptions);
                        if (!System.IO.File.Exists(targetFile) || ConfirmOverwrite(fileClientToDownload, targetFile))
                        {
                            //Prepare progress Handler
                            IProgress<long> progressHandler = new Progress<long>((finishedBytes) =>
                            {
                                if (progressRecord != null)
                                {
                                    // Size of the source file might be 0, when it is, directly treat the progress as 100 percent.
                                    progressRecord.PercentComplete = (fileToBeDownloaded.Properties.Length == 0) ? 100 : (int)(finishedBytes * 100 / fileToBeDownloaded.Properties.Length);
                                    progressRecord.StatusDescription = string.Format(CultureInfo.CurrentCulture, Resources.FileTransmitStatus, progressRecord.PercentComplete);
                                    this.OutputStream.WriteProgress(progressRecord);
                                }
                            });

                            using (FileStream stream = System.IO.File.OpenWrite(targetFile))
                            {
                                stream.SetLength(0);
                                long contentLenLeft = fileToBeDownloaded.Properties.Length;
                                long downloadOffset = 0;
                                ShareFileDownloadOptions downloadOptions = new ShareFileDownloadOptions();
                                while (contentLenLeft > 0)
                                {
                                    long contentSize = contentLenLeft < size4MB ? contentLenLeft : size4MB;
                                    downloadOptions.Range = new HttpRange(downloadOffset, contentSize);
                                    ShareFileDownloadInfo download = fileClientToDownload.Download(downloadOptions, cancellationToken: this.CmdletCancellationToken);
                                    download.Content.CopyTo(stream);
                                    downloadOffset += contentSize;
                                    contentLenLeft -= contentSize;
                                    progressHandler.Report(downloadOffset);
                                }
                            }
                        }
                    }

                    if (this.PassThru)
                    {
                        WriteCloudFileObject(taskId, this.Channel, fileToBeDownloaded);
                    }
                });
            }

            if (AsJob.IsPresent)
            {
                DoEndProcessing();
            }
        }
        public object GetDynamicParameters()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                context = new WindowsOnlyParameters();
                return context;
            }
            else return null;
        }
        private WindowsOnlyParameters context;
    }
}
