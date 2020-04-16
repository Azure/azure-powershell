﻿// ----------------------------------------------------------------------------------
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


using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Management.Automation;
using System.Threading.Tasks;
using StorageBlob = Microsoft.Azure.Storage.Blob;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Storage.DataMovement;

namespace Microsoft.WindowsAzure.Commands.Storage.Blob
{

    /// <summary>
    /// download blob from azure
    /// </summary>
    [Cmdlet("Set", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageBlobContent", SupportsShouldProcess = true, DefaultParameterSetName = ManualParameterSet),OutputType(typeof(AzureStorageBlob))]
    public class SetAzureBlobContentCommand : StorageDataMovementCmdletBase
    {
        /// <summary>
        /// default parameter set name
        /// </summary>
        private const string ManualParameterSet = "SendManual";

        /// <summary>
        /// blob pipeline
        /// </summary>
        private const string BlobParameterSet = "BlobPipeline";

        /// <summary>
        /// container pipeline
        /// </summary>
        private const string ContainerParameterSet = "ContainerPipeline";

        /// <summary>
        /// block blob type
        /// </summary>
        private const string BlockBlobType = "Block";

        /// <summary>
        /// page blob type
        /// </summary>
        private const string PageBlobType = "Page";

        /// <summary>
        /// append blob type
        /// </summary>
        private const string AppendBlobType = "Append";

        [Alias("FullName")]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "file Path.",
            ValueFromPipelineByPropertyName = true, ParameterSetName = ManualParameterSet)]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "file Path.",
            ParameterSetName = ContainerParameterSet)]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "file Path.",
            ParameterSetName = BlobParameterSet)]
        public string File
        {
            get { return FileName; }
            set { FileName = value; }
        }

        private string FileName = String.Empty;

        [Parameter(Position = 1, HelpMessage = "Container name", Mandatory = true, ParameterSetName = ManualParameterSet)]
        public string Container
        {
            get { return ContainerName; }
            set { ContainerName = value; }
        }

        private string ContainerName = String.Empty;

        [Parameter(HelpMessage = "Blob name", ParameterSetName = ManualParameterSet)]
        [Parameter(HelpMessage = "Blob name", ParameterSetName = ContainerParameterSet)]
        public string Blob
        {
            get { return BlobName; }
            set { BlobName = value; }
        }

        public string BlobName = String.Empty;

        [Parameter(HelpMessage = "Azure Blob Container Object", Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ContainerParameterSet)]
        public StorageBlob.CloudBlobContainer CloudBlobContainer { get; set; }

        [Alias("ICloudBlob")]
        [Parameter(HelpMessage = "Azure Blob Object", Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = BlobParameterSet)]
        public StorageBlob.CloudBlob CloudBlob { get; set; }

        [Parameter(HelpMessage = "Blob Type('Block', 'Page', 'Append')")]
        [ValidateSet(BlockBlobType, PageBlobType, AppendBlobType, IgnoreCase = true)]
        public string BlobType
        {
            get { return blobType; }
            set { blobType = value; }
        }
        private string blobType = BlockBlobType;

        [Parameter(HelpMessage = "Blob Properties", Mandatory = false)]
        public Hashtable Properties
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

        [Parameter(HelpMessage = "Blob Metadata", Mandatory = false)]
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

        [Parameter(HelpMessage = "Premium Page Blob Tier", Mandatory = false)]
        public PremiumPageBlobTier PremiumPageBlobTier
        {
            get
            {
                return pageBlobTier.Value;
            }

            set
            {
                pageBlobTier = value;
            }
        }

        private PremiumPageBlobTier? pageBlobTier = null;

        [Parameter(HelpMessage = "Block Blob Tier, valid values are Hot/Cool/Archive. See detail in https://docs.microsoft.com/en-us/azure/storage/blobs/storage-blob-storage-tiers", Mandatory = false)]
        [PSArgumentCompleter("Hot", "Cool", "Archive")]
        [ValidateSet("Hot", "Cool", "Archive", IgnoreCase = true)]
        public string StandardBlobTier
        {
            get
            {
                return standardBlobTier is null ? null : standardBlobTier.Value.ToString();
            }

            set
            {
                if (value != null)
                {
                    standardBlobTier = ((StandardBlobTier)Enum.Parse(typeof(StandardBlobTier), value, true));
                }
                else
                {
                    standardBlobTier = null;
                }
            }
        }
        private StandardBlobTier? standardBlobTier = null;

        private BlobUploadRequestQueue UploadRequests = new BlobUploadRequestQueue();
        
        /// <summary>
        /// Initializes a new instance of the SetAzureBlobContentCommand class.
        /// </summary>
        public SetAzureBlobContentCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SetAzureBlobContentCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public SetAzureBlobContentCommand(IStorageBlobManagement channel)
        {
            Channel = channel;
        }

        /// <summary>
        /// upload file to azure blob
        /// </summary>
        /// <param name="taskId">Task id</param>
        /// <param name="filePath">local file path</param>
        /// <param name="blob">destination azure blob object</param>
        internal virtual async Task Upload2Blob(long taskId, IStorageBlobManagement localChannel, string filePath, StorageBlob.CloudBlob blob)
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
                SetBlobProperties(destBlob, this.BlobProperties);
                SetBlobMeta(destBlob, this.BlobMetadata);
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

            if (this.pageBlobTier != null || this.standardBlobTier != null)
            {
                await this.SetBlobTier(localChannel, blob, pageBlobTier, standardBlobTier).ConfigureAwait(false);
            }

            try
            {
                await localChannel.FetchBlobAttributesAsync(
                    blob,
                    AccessCondition.GenerateEmptyCondition(),
                    this.RequestOptions,
                    this.OperationContext,
                    this.CmdletCancellationToken).ConfigureAwait(false);
            }
            catch (StorageException e)
            {
                //Handle the limited read permission, and handle the upload with write only permission
                if (!e.IsNotFoundException() && !e.IsForbiddenException())
                {
                    throw;
                }
            }

            WriteCloudBlobObject(data.TaskId, localChannel, blob);
        }

        /// <summary>
        /// get full file path according to the specified file name
        /// </summary>
        /// <param name="fileName">file name</param>
        /// <returns>full file path if fileName is valid, empty string if file name is directory</returns>
        internal string GetFullSendFilePath(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException(Resources.FileNameCannotEmpty);
            }

            return fileName;
        }

        /// <summary>
        /// set azure blob content
        /// </summary>
        /// <param name="fileName">local file path</param>
        /// <param name="containerName">container name</param>
        /// <param name="blobName">blob name</param>
        /// <returns>null if user cancel the overwrite operation, otherwise return destination blob object</returns>
        internal void SetAzureBlobContent(string fileName, string blobName)
        {
            StorageBlob.BlobType type = StorageBlob.BlobType.BlockBlob;

            if (string.Equals(blobType, BlockBlobType, StringComparison.InvariantCultureIgnoreCase))
            {
                type = StorageBlob.BlobType.BlockBlob;
            }
            else if (string.Equals(blobType, PageBlobType, StringComparison.InvariantCultureIgnoreCase))
            {
                type = StorageBlob.BlobType.PageBlob;
            }
            else if (string.Equals(blobType, AppendBlobType, StringComparison.InvariantCultureIgnoreCase))
            {
                type = StorageBlob.BlobType.AppendBlob;
            }
            else
            {
                throw new InvalidOperationException(string.Format(
                    CultureInfo.CurrentCulture,
                    Resources.InvalidBlobType,
                    blobType,
                    blobName));
            }

            if (!string.IsNullOrEmpty(blobName) && !NameUtil.IsValidBlobName(blobName))
            {
                throw new ArgumentException(String.Format(Resources.InvalidBlobName, blobName));
            }

            string filePath = GetFullSendFilePath(fileName);

            bool isFile = UploadRequests.EnqueueRequest(filePath, type, blobName);

            if (!isFile)
            {
                WriteWarning(String.Format(Resources.CannotSendDirectory, filePath));
            }
        }

        protected override void EndProcessing()
        {
            if (!AsJob.IsPresent)
            {
                DoEndProcessing();
            }
        }

        protected override void DoEndProcessing()
        {
            while (!UploadRequests.IsEmpty())
            {
                Tuple<string, StorageBlob.CloudBlob> uploadRequest = UploadRequests.DequeueRequest();
                IStorageBlobManagement localChannel = Channel;
                Func<long, Task> taskGenerator = (taskId) => Upload2Blob(taskId, localChannel, uploadRequest.Item1, uploadRequest.Item2);
                RunTask(taskGenerator);
            }

            base.DoEndProcessing();
        }        

        /// <summary>
        /// set blob AccessTier
        /// </summary>
        /// <param name="azureBlob">CloudBlob object</param>
        /// <param name="blockBlobTier">Block Blob Tier</param>
        /// <param name="pageBlobTier">Page Blob Tier</param>
        private async Task SetBlobTier(IStorageBlobManagement localChannel, StorageBlob.CloudBlob blob, PremiumPageBlobTier? pageBlobTier = null, StandardBlobTier? standardBlobTier = null)
        {
            if (pageBlobTier == null && standardBlobTier == null)
            {
                return;
            }
            
            StorageBlob.BlobRequestOptions requestOptions = RequestOptions;

            // The Blob Type and Blob Tier must match, since already checked they are match at the begin of ExecuteCmdlet().
            if (pageBlobTier != null)
            {
                await Channel.SetPageBlobTierAsync((CloudPageBlob)blob, pageBlobTier.Value, requestOptions, OperationContext, CmdletCancellationToken).ConfigureAwait(false);
            }
            if (standardBlobTier != null)
            {
                AccessCondition accessCondition = null;
                await Channel.SetStandardBlobTierAsync((CloudBlockBlob)blob, accessCondition, standardBlobTier.Value, null, requestOptions, OperationContext, CmdletCancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// On Task run successfully
        /// </summary>
        /// <param name="data">User data</param>
        protected override void OnTaskSuccessful(DataMovementUserData data)
        {
            StorageBlob.CloudBlob blob = data.Data as StorageBlob.CloudBlob;
            IStorageBlobManagement localChannel = data.Channel;

            if (blob != null)
            {
                AccessCondition accessCondition = null;
                StorageBlob.BlobRequestOptions requestOptions = RequestOptions;

                if (this.pageBlobTier != null || this.standardBlobTier != null)
                {
                    this.SetBlobTier(localChannel, blob, pageBlobTier, standardBlobTier).Wait();
                }

                try
                {
                    localChannel.FetchBlobAttributesAsync(blob, accessCondition, requestOptions, OperationContext, CmdletCancellationToken).Wait();
                }
                catch (AggregateException e)
                {
                    StorageException storageException = e.InnerException as StorageException;
                    //Handle the limited read permission.
                    if (storageException == null || !storageException.IsNotFoundException())
                    {
                        throw e.InnerException;
                    }
                }

                WriteCloudBlobObject(data.TaskId, localChannel, blob);
            }
        }

        protected override void BeginProcessing()
        {
            if (!AsJob.IsPresent)
            {
                DoBeginProcessing();
            }
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

            // Validate the Blob Tier matches with blob Type
            StorageBlob.BlobType type = StorageBlob.BlobType.BlockBlob;
            if (string.Equals(blobType, BlockBlobType, StringComparison.InvariantCultureIgnoreCase))
            {
                type = StorageBlob.BlobType.BlockBlob;
            }
            else if (string.Equals(blobType, PageBlobType, StringComparison.InvariantCultureIgnoreCase))
            {
                type = StorageBlob.BlobType.PageBlob;
            }
            else 
            {
                type = StorageBlob.BlobType.Unspecified;
            }
            ValidateBlobTier(type, pageBlobTier, standardBlobTier);

            if (BlobProperties != null)
            {
                ValidateBlobProperties(BlobProperties);
            }

            // if FIPS policy is enabled, must use native MD5
            if (fipsEnabled)
            {
                CloudStorageAccount.UseV1MD5 = false;
            }

            string containerName = string.Empty;

            switch (ParameterSetName)
            {
                case ContainerParameterSet:
                    if (ShouldProcess(BlobName, VerbsCommon.Set))
                    {
                        SetAzureBlobContent(ResolvedFileName, BlobName);
                        containerName = CloudBlobContainer.Name;
                        UploadRequests.SetDestinationContainer(Channel, containerName);
                    }

                    break;

                case BlobParameterSet:
                    if (ShouldProcess(CloudBlob.Name, VerbsCommon.Set))
                    {
                        SetAzureBlobContent(ResolvedFileName, CloudBlob.Name);
                        containerName = CloudBlob.Container.Name;
                        UploadRequests.SetDestinationContainer(Channel, containerName);
                    }

                    break;

                case ManualParameterSet:
                default:
                    if (ShouldProcess(BlobName, VerbsCommon.Set))
                    {
                        SetAzureBlobContent(ResolvedFileName, BlobName);
                        containerName = ContainerName;
                        UploadRequests.SetDestinationContainer(Channel, containerName);
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
