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


using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Management.Automation;
using System.Threading.Tasks;
using StorageBlob = Microsoft.WindowsAzure.Storage.Blob;

namespace Microsoft.WindowsAzure.Commands.Storage.Blob
{

    /// <summary>
    /// download blob from azure
    /// </summary>
    [Cmdlet(VerbsCommon.Set, StorageNouns.BlobContent, SupportsShouldProcess = true, DefaultParameterSetName = ManualParameterSet),
        OutputType(typeof(AzureStorageBlob))]
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
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "file Path",
            ValueFromPipelineByPropertyName = true, ParameterSetName = ManualParameterSet)]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "file Path",
            ParameterSetName = ContainerParameterSet)]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "file Path",
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

            await DataMovementTransferHelper.DoTransfer(() =>
                {
                    return this.TransferManager.UploadAsync(filePath,
                        blob,
                        null,
                        this.GetTransferContext(data),
                        this.CmdletCancellationToken);
                },
                data.Record,
                this.OutputStream);

            if (this.BlobProperties != null || this.BlobMetadata != null)
            {
                await TaskEx.WhenAll(
                    this.SetBlobProperties(localChannel, blob, this.BlobProperties),
                    this.SetBlobMeta(localChannel, blob, this.BlobMetadata));
            }

            try
            {
                await localChannel.FetchBlobAttributesAsync(
                    blob,
                    AccessCondition.GenerateEmptyCondition(),
                    this.RequestOptions,
                    this.OperationContext,
                    this.CmdletCancellationToken);
            }
            catch (StorageException e)
            {
                //Handle the limited read permission.
                if (!e.IsNotFoundException())
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

            String filePath = Path.Combine(CurrentPath(), fileName);

            return filePath;
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
            while (!UploadRequests.IsEmpty())
            {
                Tuple<string, StorageBlob.CloudBlob> uploadRequest = UploadRequests.DequeueRequest();
                IStorageBlobManagement localChannel = Channel;
                Func<long, Task> taskGenerator = (taskId) => Upload2Blob(taskId, localChannel, uploadRequest.Item1, uploadRequest.Item2);
                RunTask(taskGenerator);
            }

            base.EndProcessing();
        }

        //only support the common blob properties for block blob and page blob
        //http://msdn.microsoft.com/en-us/library/windowsazure/ee691966.aspx
        private Dictionary<string, Action<StorageBlob.BlobProperties, string>> validCloudBlobProperties =
            new Dictionary<string, Action<StorageBlob.BlobProperties, string>>(StringComparer.OrdinalIgnoreCase)
            {
                {"CacheControl", (p, v) => p.CacheControl = v},
                {"ContentDisposition", (p, v) => p.ContentDisposition = v},
                {"ContentEncoding", (p, v) => p.ContentEncoding = v},
                {"ContentLanguage", (p, v) => p.ContentLanguage = v},
                {"ContentMD5", (p, v) => p.ContentMD5 = v},
                {"ContentType", (p, v) => p.ContentType = v},
            };

        /// <summary>
        /// check whether the blob properties is valid
        /// </summary>
        /// <param name="properties">Blob properties table</param>
        private void ValidateBlobProperties(Hashtable properties)
        {
            if (properties == null)
            {
                return;
            }

            foreach (DictionaryEntry entry in properties)
            {
                if (!validCloudBlobProperties.ContainsKey(entry.Key.ToString()))
                {
                    throw new ArgumentException(String.Format(Resources.InvalidBlobProperties, entry.Key.ToString(), entry.Value.ToString()));
                }
            }
        }

        /// <summary>
        /// set blob properties
        /// </summary>
        /// <param name="azureBlob">CloudBlob object</param>
        /// <param name="meta">blob properties hashtable</param>
        private async Task SetBlobProperties(IStorageBlobManagement localChannel, StorageBlob.CloudBlob blob, Hashtable properties)
        {
            if (properties == null)
            {
                return;
            }

            foreach (DictionaryEntry entry in properties)
            {
                string key = entry.Key.ToString();
                string value = entry.Value.ToString();
                Action<StorageBlob.BlobProperties, string> action = validCloudBlobProperties[key];

                if (action != null)
                {
                    action(blob.Properties, value);
                }
            }

            AccessCondition accessCondition = null;
            StorageBlob.BlobRequestOptions requestOptions = RequestOptions;

            await Channel.SetBlobPropertiesAsync(blob, accessCondition, requestOptions, OperationContext, CmdletCancellationToken);
        }

        /// <summary>
        /// set blob meta
        /// </summary>
        /// <param name="azureBlob">CloudBlob object</param>
        /// <param name="meta">meta data hashtable</param>
        private async Task SetBlobMeta(IStorageBlobManagement localChannel, StorageBlob.CloudBlob blob, Hashtable meta)
        {
            if (meta == null)
            {
                return;
            }

            foreach (DictionaryEntry entry in meta)
            {
                string key = entry.Key.ToString();
                string value = entry.Value.ToString();

                if (blob.Metadata.ContainsKey(key))
                {
                    blob.Metadata[key] = value;
                }
                else
                {
                    blob.Metadata.Add(key, value);
                }
            }

            AccessCondition accessCondition = null;
            StorageBlob.BlobRequestOptions requestOptions = RequestOptions;

            await Channel.SetBlobMetadataAsync(blob, accessCondition, requestOptions, OperationContext, CmdletCancellationToken);
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

                if (BlobProperties != null || BlobMetadata != null)
                {
                    Task[] tasks = new Task[2];
                    tasks[0] = SetBlobProperties(localChannel, blob, BlobProperties);
                    tasks[1] = SetBlobMeta(localChannel, blob, BlobMetadata);
                    Task.WaitAll(tasks);
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

        /// <summary>
        /// execute command
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (BlobProperties != null)
            {
                ValidateBlobProperties(BlobProperties);
            }

            string containerName = string.Empty;

            switch (ParameterSetName)
            {
                case ContainerParameterSet:
                    if (ShouldProcess(BlobName, VerbsCommon.Set))
                    {
                        SetAzureBlobContent(FileName, BlobName);
                        containerName = CloudBlobContainer.Name;
                        UploadRequests.SetDestinationContainer(Channel, containerName);
                    }

                    break;

                case BlobParameterSet:
                    if (ShouldProcess(CloudBlob.Name, VerbsCommon.Set))
                    {
                        SetAzureBlobContent(FileName, CloudBlob.Name);
                        containerName = CloudBlob.Container.Name;
                        UploadRequests.SetDestinationContainer(Channel, containerName);
                    }

                    break;

                case ManualParameterSet:
                default:
                    if (ShouldProcess(BlobName, VerbsCommon.Set))
                    {
                        SetAzureBlobContent(FileName, BlobName);
                        containerName = ContainerName;
                        UploadRequests.SetDestinationContainer(Channel, containerName);
                    }

                    break;
            }

        }
    }
}
