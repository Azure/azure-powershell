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
    using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
    using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using System;
    using System.Runtime.InteropServices;
    using LocalConstants = Microsoft.WindowsAzure.Commands.Storage.File.Constants;
    using LocalDirectory = System.IO.Directory;
    using LocalPath = System.IO.Path;

    [CmdletOutputBreakingChangeWithVersion(typeof(AzureStorageFile), "13.0.0", "8.0.0", ChangeDescription = "The child property CloudFile from deprecated v11 SDK will be removed when -PassThru is specified. Use child property ShareFileClient instead.")]
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

        [CmdletParameterBreakingChangeWithVersion("Share", "13.0.0", "8.0.0", ChangeDescription = "The parameter Share (alias CloudFileShare) will be deprecated, and ShareClient will be mandatory.")]
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
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = LocalConstants.ShareParameterSetName,
            HelpMessage = "CloudFileShare object indicated the share where the file would be downloaded.")]
        [ValidateNotNull]
        public ShareClient ShareClient { get; set; }

        [CmdletParameterBreakingChangeWithVersion("Directory", "13.0.0", "8.0.0", ChangeDescription = "The parameter Directory (alias CloudFileDirectory) will be deprecated, and ShareDirectoryClient will be mandatory.")]
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
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = LocalConstants.DirectoryParameterSetName,
            HelpMessage = "ShareDirectoryClient object indicated the cloud directory where the file would be downloaded.")]
        [ValidateNotNull]
        public ShareDirectoryClient ShareDirectoryClient { get; set; }

        [CmdletParameterBreakingChangeWithVersion("File", "13.0.0", "8.0.0", ChangeDescription = "The parameter File (alias CloudFile) will be deprecated, and ShareFileClient will be mandatory.")]
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
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = LocalConstants.FileParameterSetName,
            HelpMessage = "ShareFileClient object indicated the cloud file to be downloaded.")]
        [ValidateNotNull]
        public ShareFileClient ShareFileClient { get; set; }

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
            ShareFileClient fileClientToBeDownloaded = null;
            string[] path = NamingUtil.ValidatePath(this.Path, true);
            switch (this.ParameterSetName)
            {
                case LocalConstants.FileParameterSetName:
                    fileToBeDownloaded = this.File;

                    if (this.ShareFileClient != null)
                    {
                        fileClientToBeDownloaded = this.ShareFileClient;
                    }
                    // Build and set storage context for the output object when
                    // 1. input track1 object and storage context is missing 2. the current context doesn't match the context of the input object 
                    if (ShouldSetContext(this.Context, this.File.ServiceClient))
                    {
                        this.Context = GetStorageContextFromTrack1FileServiceClient(this.File.ServiceClient, DefaultContext);
                    }
                    break;

                case LocalConstants.ShareNameParameterSetName:
                    var share = this.BuildFileShareObjectFromName(this.ShareName);
                    fileToBeDownloaded = share.GetRootDirectoryReference().GetFileReferenceByPath(path); 
                    
                    ShareServiceClient fileserviceClient = Util.GetTrack2FileServiceClient((AzureStorageContext)this.Context, ClientOptions);
                    fileClientToBeDownloaded = fileserviceClient.GetShareClient(this.ShareName).GetRootDirectoryClient().GetFileClient(this.Path);
                    break;

                case LocalConstants.ShareParameterSetName:
                    fileToBeDownloaded = this.Share.GetRootDirectoryReference().GetFileReferenceByPath(path);

                    // Build and set storage context for the output object when
                    // 1. input track1 object and storage context is missing 2. the current context doesn't match the context of the input object 
                    if (ShouldSetContext(this.Context, this.Share.ServiceClient))
                    {
                        this.Context = GetStorageContextFromTrack1FileServiceClient(this.Share.ServiceClient, DefaultContext);
                    }

                    if (this.ShareClient != null)
                    {
                        fileClientToBeDownloaded = this.ShareClient.GetRootDirectoryClient().GetFileClient(this.Path);
                    }
                    else
                    {
                        fileClientToBeDownloaded = AzureStorageFile.GetTrack2FileClient(fileToBeDownloaded, ClientOptions);
                    }
                    break;

                case LocalConstants.DirectoryParameterSetName:
                    fileToBeDownloaded = this.Directory.GetFileReferenceByPath(path);

                    // Build and set storage context for the output object when
                    // 1. input track1 object and storage context is missing 2. the current context doesn't match the context of the input object 
                    if (ShouldSetContext(this.Context, this.Directory.ServiceClient))
                    {
                        this.Context = GetStorageContextFromTrack1FileServiceClient(this.Directory.ServiceClient, DefaultContext);
                    }

                    if (this.ShareDirectoryClient != null)
                    {
                        fileClientToBeDownloaded = this.ShareDirectoryClient.GetFileClient(this.Path);
                    }
                    else
                    {
                        fileClientToBeDownloaded = AzureStorageFile.GetTrack2FileClient(fileToBeDownloaded, ClientOptions);
                    }
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

                    // If not Oauth, and not AllowTrailingDot , use DMlib
                    if ((!WithOauthCredential() && (this.DisAllowTrailingDot.IsPresent || !Util.PathContainsTrailingDot(fileToBeDownloaded.GetFullPath()))) || fileClientToBeDownloaded == null)
                    {
                        await
                            fileToBeDownloaded.FetchAttributesAsync(null, this.RequestOptions, OperationContext,
                                CmdletCancellationToken).ConfigureAwait(false);

                        var progressRecord = new ProgressRecord(
                            this.OutputStream.GetProgressId(taskId),
                            string.Format(CultureInfo.CurrentCulture, Resources.ReceiveAzureFileActivity,
                                fileToBeDownloaded.GetFullPath(), targetFile),
                            Resources.PrepareDownloadingFile);

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

                        if (this.PassThru)
                        {
                            WriteCloudFileObject(taskId, (AzureStorageContext)this.Context, fileToBeDownloaded);
                        }
                    }
                    else // Track2 SDK 
                    {
                        ShareFileProperties fileProperties =  await fileClientToBeDownloaded.GetPropertiesAsync( cancellationToken: this.CmdletCancellationToken).ConfigureAwait(false);

                        var progressRecord = new ProgressRecord(
                            this.OutputStream.GetProgressId(taskId),
                            string.Format(CultureInfo.CurrentCulture, Resources.ReceiveAzureFileActivity,
                                fileClientToBeDownloaded.Path, targetFile),
                            Resources.PrepareDownloadingFile);

                        if (!System.IO.File.Exists(targetFile) || ConfirmOverwrite(fileClientToBeDownloaded, targetFile))
                        {
                            //Prepare progress Handler
                            IProgress<long> progressHandler = new Progress<long>((finishedBytes) =>
                            {
                                if (progressRecord != null)
                                {
                                    // Size of the source file might be 0, when it is, directly treat the progress as 100 percent.
                                    progressRecord.PercentComplete = (fileProperties.ContentLength == 0) ? 100 : (int)(finishedBytes * 100 / fileProperties.ContentLength);
                                    progressRecord.StatusDescription = string.Format(CultureInfo.CurrentCulture, Resources.FileTransmitStatus, progressRecord.PercentComplete);
                                    this.OutputStream.WriteProgress(progressRecord);
                                }
                            });

                            using (FileStream stream = System.IO.File.OpenWrite(targetFile))
                            {
                                stream.SetLength(0);
                                long contentLenLeft = fileProperties.ContentLength;
                                long downloadOffset = 0;
                                ShareFileDownloadOptions downloadOptions = new ShareFileDownloadOptions();
                                while (contentLenLeft > 0)
                                {
                                    long contentSize = contentLenLeft < size4MB ? contentLenLeft : size4MB;
                                    downloadOptions.Range = new HttpRange(downloadOffset, contentSize);
                                    ShareFileDownloadInfo download = fileClientToBeDownloaded.Download(downloadOptions, cancellationToken: this.CmdletCancellationToken);
                                    download.Content.CopyTo(stream);
                                    downloadOffset += download.ContentLength;
                                    contentLenLeft -= download.ContentLength;
                                    progressHandler.Report(downloadOffset);
                                }
                            }
                        }

                        if (this.PassThru)
                        {
                            // TODO: should make sure track1 file object attributes get?
                            OutputStream.WriteObject(taskId, new AzureStorageFile(fileClientToBeDownloaded, (AzureStorageContext)this.Context, fileProperties, ClientOptions));
                        }
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
