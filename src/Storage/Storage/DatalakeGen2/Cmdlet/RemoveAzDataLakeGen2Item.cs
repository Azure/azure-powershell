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

namespace Microsoft.WindowsAzure.Commands.Storage.Blob.Cmdlet
{
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using Microsoft.Azure.Storage.Blob;
    using System;
    using System.Management.Automation;
    using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
    using global::Azure.Storage.Files.DataLake;

    /// <summary>
    /// remove specified azure FileSystem
    /// </summary>
    [Cmdlet("Remove", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "DataLakeGen2Item", DefaultParameterSetName = ManualParameterSet, SupportsShouldProcess = true),OutputType(typeof(Boolean))]
    public class RemoveAzDataLakeGen2ItemCommand : StorageCloudBlobCmdletBase
    {
        /// <summary>
        /// manually set the name parameter
        /// </summary>
        private const string ManualParameterSet = "ReceiveManual";

        /// <summary>
        /// Blob or BlobDir pipeline
        /// </summary>
        private const string BlobParameterSet = "ItemPipeline";

        [Parameter(ValueFromPipeline = true, Position = 0, Mandatory = true, HelpMessage = "FileSystem name", ParameterSetName = ManualParameterSet)]
        [ValidateNotNullOrEmpty]
        public string FileSystem { get; set; }

        [Parameter(ValueFromPipeline = true, Position = 1, Mandatory = true, HelpMessage =
                "The path in the specified FileSystem that should be removed. Can be a file or directory " +
                "In the format 'directory/file.txt' or 'directory1/directory2/'", ParameterSetName = ManualParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Azure Datalake Gen2 Item Object to remove.",
            ValueFromPipeline = true, ParameterSetName = BlobParameterSet)]
        [ValidateNotNull]
        public AzureDataLakeGen2Item InputObject { get; set; }

        [Parameter(HelpMessage = "Force to remove the Item without any prompt.")]
        public SwitchParameter Force
        {
            get { return force; }
            set { force = value; }
        }
        private bool force;

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Return whether the specified FileSystem is successfully removed")]
        public SwitchParameter PassThru { get; set; }

        // Overwrite the useless parameter
        public override int? ConcurrentTaskCount { get; set; }
        public override int? ClientTimeoutPerRequest { get; set; }
        public override int? ServerTimeoutPerRequest { get; set; }

        /// <summary>
        /// Initializes a new instance of the RemoveAzDataLakeGen2ItemCommand class.
        /// </summary>
        public RemoveAzDataLakeGen2ItemCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the RemoveAzDataLakeGen2ItemCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public RemoveAzDataLakeGen2ItemCommand(IStorageBlobManagement channel)
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

            bool foundAFolder = false;

            DataLakeFileClient fileClient = null;
            DataLakeDirectoryClient dirClient = null;
            if (ParameterSetName == ManualParameterSet)
            {
                DataLakeFileSystemClient fileSystem = GetFileSystemClientByName(localChannel, this.FileSystem);
                foundAFolder = GetExistDataLakeGen2Item(fileSystem, this.Path, out fileClient, out dirClient);
            }
            else //BlobParameterSet
            {
                if (!InputObject.IsDirectory)
                {
                    fileClient = InputObject.File;
                }
                else
                {
                    dirClient = InputObject.Directory;
                    foundAFolder = true;
                }
            }

            if (foundAFolder)
            {
                if (force || ShouldContinue(string.Format("Remove Directory: {0}", GetDataLakeItemUriWithoutSas(dirClient)), ""))
                {
                    dirClient.Delete(true);
                }
            }
            else
            {
                if (force || ShouldContinue(string.Format("Remove File: {0}", GetDataLakeItemUriWithoutSas(fileClient)), ""))
                {
                    fileClient.Delete();
                }
            }

            if (PassThru)
            {
                WriteObject(true);
            }
        }
    }
}
