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

using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.Storage.DataMovement;
using System;
using System.IO;
using System.Management.Automation;
using System.Security.Permissions;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Specialized;
using System.Globalization;
using Track2Models = global::Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using Azure.Storage;

namespace Microsoft.WindowsAzure.Commands.Storage.Blob.Cmdlet
{
    [Cmdlet("Get", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageBlobContent", SupportsShouldProcess = true, DefaultParameterSetName = ManualParameterSet),OutputType(typeof(AzureStorageBlob))]
    public class GetAzureStorageBlobContentCommand : StorageDataMovementCmdletBase
    {
        /// <summary>
        /// manually set the name parameter
        /// </summary>
        private const string ManualParameterSet = "ReceiveManual";

        /// <summary>
        /// blob pipeline
        /// </summary>
        private const string BlobParameterSet = "BlobPipeline";

        /// <summary>
        /// container pipeline
        /// </summary>
        private const string ContainerParameterSet = "ContainerPipeline";

        /// <summary>
        /// downlaod from uri parameter set
        /// </summary>
        private const string UriParameterSet = "UriPipeline";

        [Alias("ICloudBlob")]
        [Parameter(HelpMessage = "Azure Blob Object", Mandatory = true,
            ValueFromPipelineByPropertyName = true, ParameterSetName = BlobParameterSet)]
        [ValidateNotNull]
        public CloudBlob CloudBlob { get; set; }

        [Parameter(HelpMessage = "BlobBaseClient Object", Mandatory = false,
            ValueFromPipelineByPropertyName = true, ParameterSetName = BlobParameterSet)]
        [ValidateNotNull]
        public BlobBaseClient BlobBaseClient { get; set; }

        [Parameter(HelpMessage = "Azure Container Object", Mandatory = true,
            ValueFromPipelineByPropertyName = true, ParameterSetName = ContainerParameterSet)]
        [ValidateNotNull]
        public CloudBlobContainer CloudBlobContainer { get; set; }

        [Parameter(Position = 0, HelpMessage = "Blob name",
            Mandatory = true, ParameterSetName = ManualParameterSet)]
        [Parameter(Position = 0, HelpMessage = "Blob name",
            Mandatory = true, ParameterSetName = ContainerParameterSet)]
        public string Blob
        {
            get { return BlobName; }
            set { BlobName = value; }
        }
        private string BlobName = String.Empty;

        [Parameter(Position = 1, HelpMessage = "Container name",
            Mandatory = true, ParameterSetName = ManualParameterSet)]
        public string Container
        {
            get { return ContainerName; }
            set { ContainerName = value; }
        }
        private string ContainerName = String.Empty;

        [Alias("Path")]
        [Parameter(HelpMessage = "File Path.")]
        public string Destination
        {
            get { return FileName; }
            set { FileName = value; }
        }
        public string FileName = String.Empty;

        [Parameter(HelpMessage = "check the md5sum", ParameterSetName = ManualParameterSet)]
        [Parameter(HelpMessage = "check the md5sum", ParameterSetName = BlobParameterSet)]
        [Parameter(HelpMessage = "check the md5sum", ParameterSetName = ContainerParameterSet)]
        public SwitchParameter CheckMd5
        {
            get { return checkMd5; }
            set { checkMd5 = value; }
        }

        private bool checkMd5;

        [Alias("Uri", "BlobUri")]
        [Parameter(HelpMessage = "Blob uri to download from.", Mandatory = true,
            ValueFromPipelineByPropertyName = true, ParameterSetName = UriParameterSet)]
        public string AbsoluteUri { get; set; }

        private BlobToFileSystemNameResolver fileNameResolver;
        private bool skipSourceChannelInit;

        /// <summary>
        /// Initializes a new instance of the GetAzureStorageBlobContentCommand class.
        /// </summary>
        public GetAzureStorageBlobContentCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the GetAzureStorageBlobContentCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public GetAzureStorageBlobContentCommand(IStorageBlobManagement channel)
        {
            Channel = channel;
            fileNameResolver = new BlobToFileSystemNameResolver(() => NameUtil.WindowsMaxFileNameLength);
        }

        /// <summary>
        /// Download blob to local file
        /// </summary>
        /// <param name="taskId">Task id</param>
        /// <param name="localChannel">IStorageBlobManagement channel object</param>
        /// <param name="blob">Source blob object</param>
        /// <param name="filePath">Destination file path</param>
        internal virtual async Task DownloadBlob(long taskId, IStorageBlobManagement localChannel, CloudBlob blob, string filePath)
        {
            string activity = String.Format(Resources.ReceiveAzureBlobActivity, blob.Name, filePath);
            string status = Resources.PrepareDownloadingBlob;
            ProgressRecord pr = new ProgressRecord(OutputStream.GetProgressId(taskId), activity, status);
            DataMovementUserData data = new DataMovementUserData()
            {
                Data = blob,
                TaskId = taskId,
                Channel = localChannel,
                Record = pr,
                TotalSize = blob.Properties.Length
            };

            await DataMovementTransferHelper.DoTransfer(() =>
                {
                    return this.TransferManager.DownloadAsync(blob, filePath,
                        new DownloadOptions()
                        {
                            DisableContentMD5Validation = !this.checkMd5
                        },
                        this.GetTransferContext(data),
                        this.CmdletCancellationToken);
                },
                data.Record,
                this.OutputStream).ConfigureAwait(false);

            this.WriteCloudBlobObject(data.TaskId, data.Channel, blob);
        }



        /// <summary>
        /// Download blob to local file
        /// </summary>
        /// <param name="taskId">Task id</param>
        /// <param name="localChannel">IStorageBlobManagement channel object</param>
        /// <param name="blob">Source blob object</param>
        /// <param name="filePath">Destination file path</param>
        internal virtual async Task DownloadBlob(long taskId, IStorageBlobManagement localChannel, BlobBaseClient blob, string filePath)
        {
            Track2Models.BlobProperties blobProperties = blob.GetProperties(cancellationToken: CmdletCancellationToken);

            if (this.Force.IsPresent
                || !System.IO.File.Exists(filePath)
                || ShouldContinue(string.Format(Resources.OverwriteConfirmation, filePath), null))
            {
                StorageTransferOptions trasnferOption = new StorageTransferOptions()
                {
                    MaximumConcurrency = this.GetCmdletConcurrency(),
                    MaximumTransferSize = size4MB,
                    InitialTransferSize = size4MB
                };
                await blob.DownloadToAsync(filePath, BlobRequestConditions, trasnferOption, CmdletCancellationToken).ConfigureAwait(false);
                OutputStream.WriteObject(taskId, new AzureStorageBlob(blob, localChannel is null? null : localChannel.StorageContext, blobProperties, options: ClientOptions));
            }
        }

        /// <summary>
        /// get blob content
        /// </summary>
        /// <param name="containerName">source container name</param>
        /// <param name="blobName">source blob name</param>
        /// <param name="fileName">file name</param>
        /// <returns>the downloaded AzureStorageBlob object</returns>
        internal void GetBlobContent(string containerName, string blobName, string fileName)
        {
            if (!NameUtil.IsValidContainerName(containerName))
            {
                throw new ArgumentException(String.Format(Resources.InvalidContainerName, containerName));
            }

            CloudBlobContainer container = Channel.GetContainerReference(containerName);
            GetBlobContent(container, blobName, fileName);
        }

        /// <summary>
        /// get blob content
        /// </summary>
        /// <param name="container">source container object</param>
        /// <param name="blobName">source blob name</param>
        /// <param name="fileName">destination file name</param>
        /// <returns>the downloaded AzureStorageBlob object</returns>
        internal void GetBlobContent(CloudBlobContainer container, string blobName, string fileName)
        {
            if (!NameUtil.IsValidBlobName(blobName))
            {
                throw new ArgumentException(String.Format(Resources.InvalidBlobName, blobName));
            }

            // Don't need get File full path here, since will get file full path in GetBlobContent() with blob object.

            ValidatePipelineCloudBlobContainer(container);

            if (UseTrack2Sdk())
            {
                BlobContainerClient track2container = AzureStorageContainer.GetTrack2BlobContainerClient(container, Channel.StorageContext, ClientOptions);
                BlobBaseClient blobClient = track2container.GetBlobBaseClient(blobName);
                GetBlobContent(blobClient, fileName, true);
            }
            else
            {
                AccessCondition accessCondition = null;
                BlobRequestOptions requestOptions = RequestOptions;
                CloudBlob blob = GetBlobReferenceFromServerWithContainer(Channel, container, blobName, accessCondition, requestOptions, OperationContext);

                GetBlobContent(blob, fileName, true);
            }
        }

        /// <summary>
        /// get blob content
        /// </summary>
        /// <param name="blob">source CloudBlob object</param>
        /// <param name="fileName">destination file path</param>
        /// <param name="isValidBlob">whether the source container validated</param>
        /// <returns>the downloaded AzureStorageBlob object</returns>
        internal void GetBlobContent(CloudBlob blob, string fileName, bool isValidBlob = false)
        {
            if (null == blob)
            {
                throw new ArgumentNullException(typeof(CloudBlob).Name, String.Format(Resources.ObjectCannotBeNull, typeof(CloudBlob).Name));
            }

            ValidateBlobType(blob);

            //skip download the snapshot except the CloudBlob pipeline
            if (IsSnapshot(blob) && ParameterSetName != BlobParameterSet)
            {
                WriteWarning(String.Format(Resources.SkipDownloadSnapshot, blob.Name, blob.SnapshotTime));
                return;
            }

            string filePath = GetFullReceiveFilePath(fileName, blob.Name, blob.SnapshotTime);

            if (!isValidBlob)
            {
                ValidatePipelineCloudBlob(blob);
            }

            //create the destination directory if not exists.
            String dirPath = Path.GetDirectoryName(filePath);

            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            IStorageBlobManagement localChannel = Channel;
            Func<long, Task> taskGenerator = (taskId) => DownloadBlob(taskId, localChannel, blob, filePath);
            RunTask(taskGenerator);
        }

        /// <summary>
        /// get blob content
        /// </summary>
        /// <param name="blob">source BlobBaseClient object</param>
        /// <param name="fileName">destination file path</param>
        /// <param name="isValidBlob">whether the source container validated</param>
        /// <returns>the downloaded AzureStorageBlob object</returns>
        internal void GetBlobContent(BlobBaseClient blob, string fileName, bool isValidBlob = false)
        {
            if (null == blob)
            {
                throw new ArgumentNullException(typeof(CloudBlob).Name, String.Format(Resources.ObjectCannotBeNull, typeof(CloudBlob).Name));
            }

            if (!isValidBlob)
            {
                ValidatePipelineCloudBlobTrack2(blob);
            }

            //skip download the snapshot except the CloudBlob pipeline or blob Uri
            DateTimeOffset? snapshotTime = Util.GetSnapshotTimeFromBlobUri(blob.Uri);
            if (snapshotTime != null && ParameterSetName != BlobParameterSet && ParameterSetName != UriParameterSet)
            {
                WriteWarning(String.Format(Resources.SkipDownloadSnapshot, blob.Name, snapshotTime));
                return;
            }

            string filePath = GetFullReceiveFilePath(fileName, blob.Name, snapshotTime);

            if (!isValidBlob)
            {
                ValidatePipelineCloudBlobTrack2(blob);
            }

            //create the destination directory if not exists.
            String dirPath = Path.GetDirectoryName(filePath);

            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            IStorageBlobManagement localChannel = Channel;
            Func<long, Task> taskGenerator = (taskId) => DownloadBlob(taskId, localChannel, blob, filePath);
            RunTask(taskGenerator);
        }

        /// <summary>
        /// Download blob with blob Uri
        /// If blob is on a managed disk account, and server return 401 and requires a bearer token besides Sas Uri to download,
        /// will try to generate a bearer token and download again with both Sas Uri and bearer token.
        /// </summary>
        /// <param name="blobUri"></param>
        /// <param name="fileName"></param>
        internal void GetBlobContent(string blobUri, string fileName)
        {
            BlobClientOptions blobClientOptions = this.ClientOptions;
            BlobBaseClient blobclient = new BlobBaseClient(new Uri(blobUri), blobClientOptions);
            Track2Models.BlobProperties blobproperties;
            if (blobclient.AccountName.ToLower().StartsWith("md-")) // managed disk account, must be page blob
            {
                blobClientOptions.Diagnostics.LoggedHeaderNames.Add("WWW-Authenticate");
                blobclient = new PageBlobClient(new Uri(blobUri), blobClientOptions);

                try
                {
                    blobproperties = blobclient.GetProperties(null, this.CmdletCancellationToken).Value;
                }
                catch (global::Azure.RequestFailedException e) when (e.Status == 401) // need diskRP bearer token
                {
                    string audience = Util.GetAudienceFrom401ExceptionMessage(e.Message);
                    if (audience != null)
                    {
                        WriteDebugLog(string.Format("Need bearer token with audience {0} to access the blob, so will generate bearer token and resend the request.", audience));
                        AzureSessionCredential customerToken = new AzureSessionCredential(DefaultContext, customAudience: audience);
                        blobclient = new PageBlobClient(new Uri(blobUri), customerToken, this.ClientOptions);
                    }
                    else
                    {
                        throw e;
                    }
                }
            }
            else // need check blob type for none md account
            {
                blobproperties = blobclient.GetProperties(null, this.CmdletCancellationToken).Value;

                blobclient = Util.GetTrack2BlobClient(new Uri(blobUri), null, blobClientOptions, blobproperties.BlobType);
            }
            GetBlobContent(blobclient, fileName);
        }

        /// <summary>
        /// get full file path according to the specified file name
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <param name="blobName">Source blob name</param>
        /// <param name="snapshotTime">Source blob snapshot time</param>
        /// <returns>full file path if file path is valid, otherwise throw an exception</returns>
        internal string GetFullReceiveFilePath(string fileName, string blobName, DateTimeOffset? snapshotTime)
        {
            String filePath = fileName;
            fileName = Path.GetFileName(filePath);
            String dirPath = Path.GetDirectoryName(filePath);

            if (!String.IsNullOrEmpty(dirPath) && !Directory.Exists(dirPath))
            {
                throw new ArgumentException(String.Format(Resources.DirectoryNotExists, dirPath));
            }

            if (string.IsNullOrEmpty(fileName) || Directory.Exists(filePath))
            {
                fileName = fileNameResolver.ResolveFileName(blobName, snapshotTime);
                filePath = Path.Combine(filePath, fileName);
            }

            fileName = Path.GetFileName(filePath);

            if (!NameUtil.IsValidFileName(fileName))
            {
                throw new ArgumentException(String.Format(Resources.InvalidFileName, fileName));
            }

            //there is no need to check the read/write permission on the specified file path, the datamovement libraray will do that

            return filePath;
        }

        /// <summary>
        /// Create blob client and storage service management channel if need to.
        /// </summary>
        /// <returns>IStorageManagement object</returns>
        protected override IStorageBlobManagement CreateChannel()
        {
            //Init storage blob management channel
            if (skipSourceChannelInit)
            {
                return null;
            }
            else
            {
                return base.CreateChannel();
            }
        }

        /// <summary>
        /// Begin cmdlet processing
        /// </summary>
        protected override void BeginProcessing()
        {
            if (ParameterSetName == UriParameterSet)
            {
                skipSourceChannelInit = true;
            }
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            try
            {
                FileName = GetUnresolvedProviderPathFromPSPath(FileName);
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
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            if (AsJob.IsPresent)
            {
                DoBeginProcessing();
            }

            switch (ParameterSetName)
            {
                case BlobParameterSet:
                    if (ShouldProcess(CloudBlob.Name, "Download"))
                    {
                        if (!(CloudBlob is InvalidCloudBlob) && !UseTrack2Sdk())
                        {
                            GetBlobContent(CloudBlob, FileName, true);
                        }
                        else
                        {
                            GetBlobContent(this.BlobBaseClient, FileName, true);
                        }
                    }
                    break;

                case ContainerParameterSet:
                    if (ShouldProcess(BlobName, "Download"))
                    {
                        GetBlobContent(CloudBlobContainer, BlobName, FileName);
                    }
                    break;

                case ManualParameterSet:
                    if (ShouldProcess(BlobName, "Download"))
                    {
                        GetBlobContent(ContainerName, BlobName, FileName);
                    }
                    break;
                case UriParameterSet:
                    if (ShouldProcess(BlobName, "Download"))
                    {
                        GetBlobContent(AbsoluteUri, FileName);
                    }
                    break;
            }

            if (AsJob.IsPresent)
            {
                DoEndProcessing();
            }
        }
    }
}
