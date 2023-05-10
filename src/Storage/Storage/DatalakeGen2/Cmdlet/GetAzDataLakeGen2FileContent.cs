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
using Azure.Storage.Files.DataLake;

namespace Microsoft.WindowsAzure.Commands.Storage.Blob.Cmdlet
{
    [Cmdlet("Get", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "DataLakeGen2ItemContent", SupportsShouldProcess = true, DefaultParameterSetName = ManualParameterSet),OutputType(typeof(AzureDataLakeGen2Item))]
    public class GetAzDataLakeGen2ItemContentCommand : StorageDataMovementCmdletBase
    {
        /// <summary>
        /// manually set the name parameter
        /// </summary>
        private const string ManualParameterSet = "ReceiveManual";

        /// <summary>
        /// blob pipeline
        /// </summary>
        private const string BlobParameterSet = "ItemPipeline";

        [Parameter(ValueFromPipeline = true, Position = 0, Mandatory = true, HelpMessage = "FileSystem name", ParameterSetName = ManualParameterSet)]
        [ValidateNotNullOrEmpty]
        public string FileSystem { get; set; }

        [Parameter(ValueFromPipeline = true, Position = 1, Mandatory = true, HelpMessage =
                "The path in the specified FileSystem that should be get content from. Must be a file." +
                "In the format 'directory/file.txt'", ParameterSetName = ManualParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Azure Datalake Gen2 Item Object to download.",
            ValueFromPipeline = true, ParameterSetName = BlobParameterSet)]
        [ValidateNotNull]
        public AzureDataLakeGen2Item InputObject { get; set; }

        [Parameter(HelpMessage = "Destination local file path.")]
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

        private DataLakeFileClient fileClient;

        // Overwrite the useless parameter
        public override int? ClientTimeoutPerRequest { get; set; }
        public override int? ServerTimeoutPerRequest { get; set; }
        public override string TagCondition { get; set; }

        /// <summary>
        /// Initializes a new instance of the GetAzDataLakeGen2ItemContentCommand class.
        /// </summary>
        public GetAzDataLakeGen2ItemContentCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the GetAzDataLakeGen2ItemContentCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public GetAzDataLakeGen2ItemContentCommand(IStorageBlobManagement channel)
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

            // If the blob has no length information, need get it
            if(blob.Properties.Length < 0)
            {
                blob.FetchAttributes();
            }

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

            //this.WriteCloudBlobObject(data.TaskId, data.Channel, blob);
            WriteDataLakeGen2Item(localChannel, fileClient, taskId: data.TaskId);
        }

        /// <summary>
        /// get blob content
        /// </summary>
        /// <param name="blob">source CloudBlob object</param>
        /// <param name="fileName">destination file path</param>
        /// <param name="isValidBlob">whether the source FileSystem validated</param>
        /// <returns>the downloaded blob object</returns>
        internal void GetBlobContent(CloudBlob blob, string fileName, bool isValidBlob = false)
        {
            if (null == blob)
            {
                throw new ArgumentNullException(typeof(CloudBlob).Name, String.Format(Resources.ObjectCannotBeNull, typeof(CloudBlob).Name));
            }

            ValidateBlobType(blob);

            string filePath = GetFullReceiveFilePath(fileName, blob.Name);

            if (!isValidBlob)
            {
                ValidatePipelineCloudBlob(blob);
            }

            //create the destination directory if not exists.
            String dirPath = System.IO.Path.GetDirectoryName(filePath);

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
        /// <returns>full file path if file path is valid, otherwise throw an exception</returns>
        internal string GetFullReceiveFilePath(string fileName, string blobName)
        {
            String filePath = fileName;
            fileName = System.IO.Path.GetFileName(filePath);
            String dirPath = System.IO.Path.GetDirectoryName(filePath);

            if (!String.IsNullOrEmpty(dirPath) && !Directory.Exists(dirPath))
            {
                throw new ArgumentException(String.Format(Resources.DirectoryNotExists, dirPath));
            }

            if (string.IsNullOrEmpty(fileName) || Directory.Exists(filePath))
            {
                fileName = fileNameResolver.ResolveFileName(blobName, null);
                filePath = System.IO.Path.Combine(filePath, fileName);
            }

            fileName = System.IO.Path.GetFileName(filePath);

            if (!NameUtil.IsValidFileName(fileName))
            {
                throw new ArgumentException(String.Format(Resources.InvalidFileName, fileName));
            }

            //there is no need to check the read/write permission on the specified file path, the datamovement libraray will do that

            return filePath;
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
            IStorageBlobManagement localChannel = Channel;
            BlobRequestOptions requestOptions = RequestOptions;
            if (AsJob.IsPresent)
            {
                DoBeginProcessing();
            }

            CloudBlockBlob blob = null;
            if (ParameterSetName == ManualParameterSet)
            {
                DataLakeFileSystemClient fileSystem = GetFileSystemClientByName(localChannel, this.FileSystem);
                DataLakeDirectoryClient dirClient;
                if (GetExistDataLakeGen2Item(fileSystem, this.Path, out fileClient, out dirClient))
                {
                    throw new ArgumentException(String.Format("The input FileSystem '{0}', path '{1}' point to a Directory, can't download it.", this.FileSystem, this.Path));
                }

                CloudBlobContainer container = GetCloudBlobContainerByName(Channel, this.FileSystem).ConfigureAwait(false).GetAwaiter().GetResult();
                blob = container.GetBlockBlobReference(this.Path);
            }
            else //BlobParameterSet
            {
                if (!InputObject.IsDirectory)
                {
                    if (Channel.StorageContext.StorageAccount.Credentials.IsSAS)
                    {
                        // For SAS, the Uri already contains the sas token, so can't repeatedly inout the credential
                        blob = new CloudBlockBlob(InputObject.File.Uri);
                    }
                    else
                    {
                        blob = new CloudBlockBlob(InputObject.File.Uri, Channel.StorageContext.StorageAccount.Credentials);
                    }
                    fileClient = InputObject.File;
                }
                else
                {
                    throw new ArgumentException(String.Format("The InputObject is a Directory, which don't have content to get."));
                }
            }

            GetBlobContent(blob, FileName, true);

            if (AsJob.IsPresent)
            {
                DoEndProcessing();
            }
        }
    }
}
