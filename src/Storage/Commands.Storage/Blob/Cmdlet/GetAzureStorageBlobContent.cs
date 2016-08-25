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
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.DataMovement;
using System;
using System.IO;
using System.Management.Automation;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.Storage.Blob.Cmdlet
{
    [Cmdlet(VerbsCommon.Get, StorageNouns.BlobContent, SupportsShouldProcess = true, DefaultParameterSetName = ManualParameterSet),
        OutputType(typeof(AzureStorageBlob))]
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

        [Alias("ICloudBlob")]
        [Parameter(HelpMessage = "Azure Blob Object", Mandatory = true,
            ValueFromPipelineByPropertyName = true, ParameterSetName = BlobParameterSet)]
        [ValidateNotNull]
        public CloudBlob CloudBlob { get; set; }

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
        [Parameter(HelpMessage = "File Path")]
        public string Destination
        {
            get { return FileName; }
            set { FileName = value; }
        }
        public string FileName = String.Empty;

        [Parameter(HelpMessage = "check the md5sum")]
        public SwitchParameter CheckMd5
        {
            get { return checkMd5; }
            set { checkMd5 = value; }
        }

        private bool checkMd5;

        private BlobToFileSystemNameResolver fileNameResolver;

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
                this.OutputStream);

            this.WriteCloudBlobObject(data.TaskId, data.Channel, blob);
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
            if (!NameUtil.IsValidBlobName(blobName))
            {
                throw new ArgumentException(String.Format(Resources.InvalidBlobName, blobName));
            }

            if (!NameUtil.IsValidContainerName(containerName))
            {
                throw new ArgumentException(String.Format(Resources.InvalidContainerName, containerName));
            }

            CloudBlobContainer container = Channel.GetContainerReference(containerName);
            BlobRequestOptions requestOptions = RequestOptions;
            AccessCondition accessCondition = null;

            CloudBlob blob = GetBlobReferenceFromServerWithContainer(Channel, container, blobName, accessCondition, requestOptions, OperationContext);

            GetBlobContent(blob, fileName, true);
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

            string filePath = GetFullReceiveFilePath(fileName, blobName, null);

            ValidatePipelineCloudBlobContainer(container);
            AccessCondition accessCondition = null;
            BlobRequestOptions requestOptions = RequestOptions;

            CloudBlob blob = GetBlobReferenceFromServerWithContainer(Channel, container, blobName, accessCondition, requestOptions, OperationContext);

            GetBlobContent(blob, filePath, true);
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
        /// get full file path according to the specified file name
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <param name="blobName">Source blob name</param>
        /// <param name="snapshotTime">Source blob snapshot time</param>
        /// <returns>full file path if file path is valid, otherwise throw an exception</returns>
        internal string GetFullReceiveFilePath(string fileName, string blobName, DateTimeOffset? snapshotTime)
        {
            String filePath = Path.Combine(CurrentPath(), fileName);
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
        /// execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case BlobParameterSet:
                    if (ShouldProcess(CloudBlob.Name, "Download"))
                    {
                        GetBlobContent(CloudBlob, FileName, true);
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
            }
        }
    }
}
