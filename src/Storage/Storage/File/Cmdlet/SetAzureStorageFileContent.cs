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

namespace Microsoft.WindowsAzure.Commands.Storage.File.Cmdlet
{
    using global::Azure;
    using global::Azure.Storage.Files.Shares;
    using global::Azure.Storage.Files.Shares.Models;
    using Microsoft.Azure.Storage;
    using Microsoft.Azure.Storage.DataMovement;
    using Microsoft.Azure.Storage.File;
    using Microsoft.WindowsAzure.Commands.Common;
    using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Management.Automation;
    using System.Net;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;
    using System.Threading.Tasks;
    using LocalConstants = Microsoft.WindowsAzure.Commands.Storage.File.Constants;

    [Cmdlet("Set", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageFileContent", SupportsShouldProcess = true, DefaultParameterSetName = LocalConstants.ShareNameParameterSetName), OutputType(typeof(AzureStorageFile))]
    public class SetAzureStorageFileContent : StorageFileDataManagementCmdletBase, IDynamicParameters
    {
        [Parameter(
           Position = 0,
           Mandatory = true,
           ParameterSetName = LocalConstants.ShareNameParameterSetName,
           HelpMessage = "Name of the file share where the file would be uploaded to.")]
        [ValidateNotNullOrEmpty]
        public string ShareName { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = LocalConstants.ShareParameterSetName,
            HelpMessage = "ShareClient object indicated the share where the file would be uploaded to.")]
        [ValidateNotNull]
        public ShareClient ShareClient { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = LocalConstants.DirectoryParameterSetName,
            HelpMessage = "ShareDirectoryClient object indicated the directory where the file would be uploaded.")]
        [ValidateNotNull]
        public ShareDirectoryClient ShareDirectoryClient { get; set; }

        [Alias("FullName")]
        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Path to the local file to be uploaded.")]
        [ValidateNotNullOrEmpty]
        public string Source { get; set; }

        [Parameter(
            Position = 2,
            HelpMessage = "Path to the cloud file which would be uploaded to.")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(HelpMessage = "Returns an object representing the downloaded cloud file. By default, this cmdlet does not generate any output.")]
        public SwitchParameter PassThru { get; set; }

        protected override void ProcessRecord()
        {
            try
            {
                Source = this.GetUnresolvedProviderPathFromPSPath(Source);
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

            string filePath = this.Source;
            FileInfo localFile = new FileInfo(filePath);
            if (!localFile.Exists)
            {
                throw new FileNotFoundException(string.Format(CultureInfo.CurrentCulture, Resources.SourceFileNotFound, this.Source));
            }
            long fileSize = localFile.Length;

            // if FIPS policy is enabled, must use native MD5 for DMlib. 
            if (fipsEnabled)
            {
                if (fileSize < sizeTB)
                {
                    CloudStorageAccount.UseV1MD5 = false;
                }
                else // use Track2 SDK
                {
                    WriteWarning("The uploaded file won't have Content MD5 hash, since caculate MD5 hash fail, most possiblly caused by FIPS is enabled on this machine.");
                }
            }

            bool isDirectory;
            string[] path = NamingUtil.ValidatePath(this.Path, out isDirectory);

            var cloudFileToBeUploaded =
                        BuildCloudFileInstanceFromPathAsync(localFile.Name, path, isDirectory).ConfigureAwait(false).GetAwaiter().GetResult();
            var fileClientToBeUploaded = BuildShareFileClientInstanceFromPathAsync(localFile.Name, path, isDirectory).ConfigureAwait(false).GetAwaiter().GetResult();


            this.RunTask(async taskId =>
            {
                if (fileSize <= sizeTB && !WithOauthCredential() && (this.DisAllowTrailingDot.IsPresent || !Util.PathContainsTrailingDot(fileClientToBeUploaded.Path)))
                {                    
                    if (ShouldProcess(cloudFileToBeUploaded.Name, "Set file content"))
                    {
                        var progressRecord = new ProgressRecord(
                        this.OutputStream.GetProgressId(taskId),
                        string.Format(CultureInfo.CurrentCulture, Resources.SendAzureFileActivity, localFile.Name,
                            cloudFileToBeUploaded.GetFullPath(), cloudFileToBeUploaded.Share.Name),
                        Resources.PrepareUploadingFile);

                        await DataMovementTransferHelper.DoTransfer(() =>
                            this.TransferManager.UploadAsync(
                                    localFile.FullName,
                                    cloudFileToBeUploaded,
                                    new UploadOptions
                                    {
                                        PreserveSMBAttributes = context is null ? false : context.PreserveSMBAttribute.IsPresent
                                    },
                                    this.GetTransferContext(progressRecord, localFile.Length),
                                    this.CmdletCancellationToken),
                                progressRecord,
                                this.OutputStream).ConfigureAwait(false);

                        if (this.PassThru)
                        {
                            // TODO: is get attributes necessary?
                            ShareFileProperties fileProperties = fileClientToBeUploaded.GetProperties(this.CmdletCancellationToken).Value;
                            OutputStream.WriteObject(taskId, new AzureStorageFile(fileClientToBeUploaded, (AzureStorageContext)this.Context, fileProperties, ClientOptions));
                        }
                    }
                }
                else // use Track2 SDK
                {
                   
                    if (ShouldProcess(fileClientToBeUploaded.Path, "Set file content"))
                    {
                        var progressRecord = new ProgressRecord(
                        this.OutputStream.GetProgressId(taskId),
                        string.Format(CultureInfo.CurrentCulture, Resources.SendAzureFileActivity, localFile.Name,
                            fileClientToBeUploaded.Path, fileClientToBeUploaded.ShareName),
                        Resources.PrepareUploadingFile);

                        //Create File
                        ShareFileClient fileClient = fileClientToBeUploaded;

                        // confirm overwrite if file exist
                        if (!this.Force.IsPresent &&
                            fileClient.Exists(this.CmdletCancellationToken) &&
                            !await this.OutputStream.ConfirmAsync(string.Format(CultureInfo.CurrentCulture, Resources.OverwriteConfirmation, Util.GetSnapshotQualifiedUri(fileClient.Uri))))
                        {
                            return;
                        }

                        await fileClient.CreateAsync(fileSize, cancellationToken: this.CmdletCancellationToken).ConfigureAwait(false);

                        //Prepare progress Handler
                        IProgress<long> progressHandler = new Progress<long>((finishedBytes) =>
                        {
                            if (progressRecord != null)
                            {
                                // Size of the source file might be 0, when it is, directly treat the progress as 100 percent.
                                progressRecord.PercentComplete = 0 == fileSize ? 100 : (int)(finishedBytes * 100 / fileSize);
                                progressRecord.StatusDescription = string.Format(CultureInfo.CurrentCulture, Resources.FileTransmitStatus, progressRecord.PercentComplete);
                                this.OutputStream.WriteProgress(progressRecord);
                            }
                        });

                        long blockSize = 4 * 1024 * 1024;
                        int maxWorkers = 4;

                        List<Task> runningTasks = new List<Task>();

                        IncrementalHash hash = null;
                        if (!fipsEnabled)
                        {
                            hash = IncrementalHash.CreateHash(HashAlgorithmName.MD5);
                        }

                        using (FileStream stream = File.OpenRead(localFile.FullName))
                        {
                            byte[] buffer = null;
                            for (long offset = 0; offset < fileSize;)
                            {
                                long targetBlockSize = offset + blockSize < fileSize ? blockSize : fileSize - offset;

                                // create new buffer, the old buffer will be GC
                                buffer = new byte[targetBlockSize];

                                int actualBlockSize = await stream.ReadAsync(buffer: buffer, offset: 0, count: (int)targetBlockSize);
                                if (!fipsEnabled && hash != null)
                                {
                                    hash.AppendData(buffer, 0, actualBlockSize);
                                }

                                Task task = UploadFileRangAsync(fileClient,
                                    new HttpRange(offset, actualBlockSize),
                                    new MemoryStream(buffer, 0, actualBlockSize),
                                    progressHandler);
                                runningTasks.Add(task);

                                offset += actualBlockSize;

                                // Check if any of upload range tasks are still busy
                                if (runningTasks.Count >= maxWorkers)
                                {
                                    await Task.WhenAny(runningTasks).ConfigureAwait(false);

                                    // Clear any completed blocks from the task list
                                    for (int i = 0; i < runningTasks.Count; i++)
                                    {
                                        Task runningTask = runningTasks[i];
                                        if (!runningTask.IsCompleted)
                                        {
                                            continue;
                                        }

                                        await runningTask.ConfigureAwait(false);
                                        runningTasks.RemoveAt(i);
                                        i--;
                                    }
                                }
                            }
                            // Wait for all upload range tasks finished
                            await Task.WhenAll(runningTasks).ConfigureAwait(false);
                        }

                        // Need set file properties
                        if ((!fipsEnabled && hash != null) || (context != null && context.PreserveSMBAttribute.IsPresent))
                        {
                            ShareFileHttpHeaders header = null;
                            if (!fipsEnabled && hash != null)
                            {
                                header = new ShareFileHttpHeaders();
                                header.ContentHash = hash.GetHashAndReset();
                            }

                            FileSmbProperties smbProperties = null;
                            if (context != null && context.PreserveSMBAttribute.IsPresent)
                            {
                                FileInfo sourceFileInfo = new FileInfo(localFile.FullName);
                                smbProperties = new FileSmbProperties();
                                smbProperties.FileCreatedOn = sourceFileInfo.CreationTimeUtc;
                                smbProperties.FileLastWrittenOn = sourceFileInfo.LastWriteTimeUtc;
                                smbProperties.FileAttributes = Util.LocalAttributesToAzureFileNtfsAttributes(File.GetAttributes(localFile.FullName));
                            }

                            // set file header and attributes to the file
                            ShareFileSetHttpHeadersOptions httpHeadersOptions = new ShareFileSetHttpHeadersOptions
                            {
                                HttpHeaders = header,
                                SmbProperties = smbProperties
                            };
                            fileClient.SetHttpHeaders(httpHeadersOptions);
                        }

                        if (this.PassThru)
                        {
                            // TODO: should make sure track1 file object attributes get?
                            ShareFileProperties fileProperties = fileClient.GetProperties(this.CmdletCancellationToken).Value;
                            OutputStream.WriteObject(taskId, new AzureStorageFile(fileClient, (AzureStorageContext)this.Context, fileProperties, ClientOptions));
                        }
                    }
                }
            });

            if (AsJob.IsPresent)
            {
                DoEndProcessing();
            }
        }

        private long Finishedbytes = 0;
        private async Task UploadFileRangAsync(ShareFileClient file, HttpRange range, Stream content, IProgress<long> progressHandler = null)
        {
            await file.UploadRangeAsync(
                range,
                content,
                cancellationToken: this.CmdletCancellationToken).ConfigureAwait(false);
            Finishedbytes += range.Length is null? 0 : range.Length.Value;
            progressHandler.Report(Finishedbytes);
        }

        private async Task<CloudFile> BuildCloudFileInstanceFromPathAsync(string defaultFileName, string[] path, bool pathIsDirectory)
        {
            CloudFileDirectory baseDirectory = null;
            bool isPathEmpty = path.Length == 0;
            switch (this.ParameterSetName)
            {
                case LocalConstants.DirectoryParameterSetName:
                    CheckContextForObjectInput((AzureStorageContext)this.Context);
                    baseDirectory = AzureStorageFileDirectory.GetTrack1FileDirClient(this.ShareDirectoryClient, ((AzureStorageContext)this.Context).StorageAccount.Credentials, ClientOptions);
                    break;

                case LocalConstants.ShareNameParameterSetName:
                    NamingUtil.ValidateShareName(this.ShareName, false);
                    baseDirectory = this.BuildFileShareObjectFromName(this.ShareName).GetRootDirectoryReference();
                    break;

                case LocalConstants.ShareParameterSetName:
                    CheckContextForObjectInput((AzureStorageContext)this.Context);
                    baseDirectory = AzureStorageFileDirectory.GetTrack1FileDirClient(this.ShareClient.GetRootDirectoryClient(), ((AzureStorageContext)this.Context).StorageAccount.Credentials, ClientOptions);
                    break;

                default:
                    throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid parameter set name: {0}", this.ParameterSetName));
            }

            if (isPathEmpty)
            {
                return baseDirectory.GetFileReference(defaultFileName);
            }

            var directory = baseDirectory.GetDirectoryReferenceByPath(path);
            if (pathIsDirectory)
            {
                return directory.GetFileReference(defaultFileName);
            }

            bool directoryExists;

            try
            {
                directoryExists = await this.Channel.DirectoryExistsAsync(directory, this.RequestOptions, this.OperationContext, this.CmdletCancellationToken).ConfigureAwait(false);
            }
            catch (StorageException e)
            {
                if (e.RequestInformation != null &&
                    e.RequestInformation.HttpStatusCode == (int)HttpStatusCode.Forbidden)
                {
                    //Forbidden to check directory existence, might caused by a write only SAS
                    //Don't report error here since should not block upload with write only SAS,
                    //Will take as directory not exist here, and take the path as file path (instead of parent dir path), to allow upload file with specific file name and write only sas
                    //If the dir already exist, will get error later, and customer can set the path to file path to unblock it.
                    directoryExists = false;
                }
                else
                {
                    if (e.RequestInformation != null &&
                        e.RequestInformation.HttpStatusCode == (int)HttpStatusCode.BadRequest &&
                        e.RequestInformation.ExtendedErrorInformation == null)
                    {
                        throw new AzureStorageFileException(ErrorCategory.InvalidArgument, ErrorIdConstants.InvalidResource, Resources.InvalidResource, this);
                    }

                    throw;
                }
            }

            if (directoryExists)
            {
                // If the directory exist on the cloud, we treat the path as
                // to a directory. So we append the default file name after
                // it and build an instance of CloudFile class.
                return directory.GetFileReference(defaultFileName);
            }
            else
            {
                // If the directory does not exist, we treat the path as to a
                // file. So we use the path of the directory to build out a
                // new instance of CloudFile class.
                return baseDirectory.GetFileReferenceByPath(path);
            }
        }
        private async Task<ShareFileClient> BuildShareFileClientInstanceFromPathAsync(string defaultFileName, string[] path, bool pathIsDirectory)
        {
            ShareDirectoryClient baseDirectory = null;
            bool isPathEmpty = path.Length == 0;
            switch (this.ParameterSetName)
            {
                case LocalConstants.DirectoryParameterSetName:
                    baseDirectory = this.ShareDirectoryClient;
                    break;

                case LocalConstants.ShareNameParameterSetName:
                    NamingUtil.ValidateShareName(this.ShareName, false);
                    ShareClient share = Util.GetTrack2ShareReference(this.ShareName,
                                             (AzureStorageContext)this.Context, 
                                             null,
                                             ClientOptions);
                    baseDirectory = share.GetRootDirectoryClient();
                    break;

                case LocalConstants.ShareParameterSetName:
                    baseDirectory = this.ShareClient.GetRootDirectoryClient();
                    break;

                default:
                    throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid parameter set name: {0}", this.ParameterSetName));
            }

            if (isPathEmpty)
            {
                return baseDirectory.GetFileClient(defaultFileName);
            }

            var directory = baseDirectory.GetSubdirectoryClient(this.Path);
            if (pathIsDirectory)
            {
                return directory.GetFileClient(defaultFileName);
            }

            bool directoryExists;

            try
            {
                directoryExists = await directory.ExistsAsync(this.CmdletCancellationToken).ConfigureAwait(false);
            }
            catch (global::Azure.RequestFailedException e) 
            {
                if (e.Status == 403)
                {
                    //Forbidden to check directory existence, might caused by a write only SAS
                    //Don't report error here since should not block upload with write only SAS,
                    //Will take as directory not exist here, and take the path as file path (instead of parent dir path), to allow upload file with specific file name and write only sas
                    //If the dir already exist, will get error later, and customer can set the path to file path to unblock it.
                    directoryExists = false;
                }
                else
                {
                    throw;
                }
            }

            if (directoryExists)
            {
                // If the directory exist on the cloud, we treat the path as
                // to a directory. So we append the default file name after
                // it and build an instance of CloudFile class.
                return directory.GetFileClient(defaultFileName);
            }
            else
            {
                // If the directory does not exist, we treat the path as to a
                // file. So we use the path of the directory to build out a
                // new instance of FileClient class.
                return baseDirectory.GetFileClient(this.Path);
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
