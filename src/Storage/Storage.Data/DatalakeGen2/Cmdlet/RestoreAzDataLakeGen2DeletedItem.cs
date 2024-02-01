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

namespace Microsoft.WindowsAzure.Commands.Storage.Blob.Cmdlet
{
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using Microsoft.Azure.Storage.Blob;
    using System;
    using System.Management.Automation;
    using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
    using global::Azure.Storage.Files.DataLake;
    using global::Azure.Storage.Files.DataLake.Models;

    /// <summary>
    /// remove specified azure FileSystem
    /// </summary>
    [Cmdlet("Restore", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "DataLakeGen2DeletedItem", DefaultParameterSetName = ManualParameterSet, SupportsShouldProcess = true),OutputType(typeof(AzureDataLakeGen2Item))]
    public class RestoreAzDataLakeGen2DeletedItemCommand : StorageCloudBlobCmdletBase
    {
        /// <summary>
        /// manually set the name parameter
        /// </summary>
        private const string ManualParameterSet = "ReceiveManual";

        /// <summary>
        /// Deleted Item pipeline
        /// </summary>
        private const string ItemParameterSet = "ItemPipeline";

        [Parameter(ValueFromPipeline = true, Position = 0, Mandatory = true, HelpMessage = "FileSystem name", ParameterSetName = ManualParameterSet)]
        [ValidateNotNullOrEmpty]
        public string FileSystem { get; set; }

        [Parameter(ValueFromPipeline = true, Position = 1, Mandatory = true, HelpMessage =
                "The deleted item path in the specified FileSystem that should be restore. " +
                "In the format 'directory/file.txt' or 'directory1/directory2/'", ParameterSetName = ManualParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(ValueFromPipeline = true, Position = 2, Mandatory = true, HelpMessage =
                "The deletion ID associated with the soft deleted path. You can get soft deleted paths and their assocaited deletion IDs with cmdlet 'Get-AzDataLakeGen2DeletedItem'.", ParameterSetName = ManualParameterSet)]
        [ValidateNotNullOrEmpty]
        public string DeletionId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Azure Datalake Gen2 Deleted Item Object to restore.",
            ValueFromPipeline = true, ParameterSetName = ItemParameterSet)]
        [ValidateNotNull]
        public AzureDataLakeGen2DeletedItem InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        // Overwrite the useless parameter
        public override int? ConcurrentTaskCount { get; set; }
        public override int? ClientTimeoutPerRequest { get; set; }
        public override int? ServerTimeoutPerRequest { get; set; }
        public override string TagCondition { get; set; }

        /// <summary>
        /// Initializes a new instance of the RestoreAzDataLakeGen2DeletedItemCommand class.
        /// </summary>
        public RestoreAzDataLakeGen2DeletedItemCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the RestoreAzDataLakeGen2DeletedItemCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public RestoreAzDataLakeGen2DeletedItemCommand(IStorageBlobManagement channel)
        {
            Channel = channel;
        }     

        /// <summary>
        /// Cmdlet begin processing
        /// </summary>
        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            OutputStream.ConfirmWriter = (s1, s2, s3) => ShouldContinue(s2, s3);            
        }

        /// <summary>
        /// execute command
        /// </summary>
        public override void ExecuteCmdlet()
        {
            IStorageBlobManagement localChannel = Channel;
            BlobRequestOptions requestOptions = RequestOptions;


            DataLakeFileSystemClient fileSystem = null;
            DataLakePathClient restoredClient = null;
            if (ParameterSetName == ManualParameterSet)
            {
                fileSystem = GetFileSystemClientByName(localChannel, this.FileSystem);
            }
            else 
            {
                fileSystem = GetFileSystemClientByName(localChannel, InputObject.FileSystemName);
                this.Path = InputObject.Path;
                this.DeletionId = InputObject.DeletionId;
            }

            if (ShouldProcess(this.Path, "Restore Item: "))
            {
                restoredClient = fileSystem.UndeletePath(this.Path, this.DeletionId, this.CmdletCancellationToken).Value;

                WriteDataLakeGen2Item(Channel, restoredClient, fileSystem);
            }
        }
    }
}
