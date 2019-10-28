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

    /// <summary>
    /// remove specified azure container
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

        [Parameter(ValueFromPipeline = true, Position = 0, Mandatory = true, HelpMessage = "Container name", ParameterSetName = ManualParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Container { get; set; }

        [Parameter(ValueFromPipeline = true, Position = 1, Mandatory = true, HelpMessage =
                "The path in the specified container that should be removed. Can be a file or folder " +
                "In the format 'folder/file.txt' or 'folder1/folder2/'", ParameterSetName = ManualParameterSet)]
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

        [Parameter(Mandatory = false, HelpMessage = "Return whether the specified container is successfully removed")]
        public SwitchParameter PassThru { get; set; }

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
            CloudBlockBlob blob = null;
            CloudBlobDirectory blobDir = null;
            if (ParameterSetName == ManualParameterSet)
            {
                CloudBlobContainer container = GetCloudBlobContainerByName(localChannel, this.Container).ConfigureAwait(false).GetAwaiter().GetResult();
                foundAFolder = GetExistDataLakeGen2Item(container, this.Path, out blob, out blobDir);
            }
            else //BlobParameterSet
            {
                if (!InputObject.IsDirectory)
                {
                    blob = (CloudBlockBlob)InputObject.ICloudBlob;
                }
                else
                {
                    blobDir = InputObject.CloudBlobDirectory;
                    foundAFolder = true;
                }
            }

            if (foundAFolder)
            {
                if (force || ShouldContinue(string.Format("Remove Folder: {0}", blobDir.Uri.ToString()), ""))
                {
                    string continuationToken = null;
                    do
                    {
                        continuationToken = blobDir.Delete(requestOptions, continuation: continuationToken);
                    }
                    while (!string.IsNullOrEmpty(continuationToken));
                }
            }
            else
            {
                if (force || ShouldContinue(string.Format("Remove File: {0}", blob.Uri.ToString()), ""))
                {
                    blob.Delete(options: requestOptions);
                }
            }

            if (PassThru)
            {
                WriteObject(true);
            }
        }
    }
}
