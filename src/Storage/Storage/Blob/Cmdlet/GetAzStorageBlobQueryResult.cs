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

namespace Microsoft.WindowsAzure.Commands.Storage.Blob
{
    using global::Azure.Storage.Blobs;
    using global::Azure.Storage.Blobs.Specialized;
    using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Management.Automation;
    using System.Security.Permissions;
    using System.Threading.Tasks;
    using Track2Models = global::Azure.Storage.Blobs.Models;

    [Cmdlet("Get", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageBlobQueryResult", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(BlobQueryOutput))]
    public class GetStorageAzureBlobQueryResultCommand : StorageCloudBlobCmdletBase
    {
        /// <summary>
        /// Blob Pipeline parameter set name
        /// </summary>
        private const string BlobPipelineParameterSet = "BlobPipeline";

        /// <summary>
        /// container pipeline paremeter set name
        /// </summary>
        private const string ContainerPipelineParameterSet = "ContainerPipeline";

        /// <summary>
        /// blob name and container name parameter set
        /// </summary>
        private const string NameParameterSet = "NamePipeline";

        private List<PSBlobQueryError> queryErrors = new List<PSBlobQueryError>();
        private long bytesScanned = 0;

        [Parameter(HelpMessage = "BlobBaseClient Object", Mandatory = true,
            ValueFromPipelineByPropertyName = true, ParameterSetName = BlobPipelineParameterSet)]
        [ValidateNotNull]
        public BlobBaseClient BlobBaseClient { get; set; }

        [Parameter(HelpMessage = "BlobContainerClient Object", Mandatory = true,
            ValueFromPipelineByPropertyName = true, ParameterSetName = ContainerPipelineParameterSet)]
        public BlobContainerClient BlobContainerClient { get; set; }

        [Parameter(ParameterSetName = ContainerPipelineParameterSet, Mandatory = true, Position = 0, HelpMessage = "Blob name")]
        [Parameter(ParameterSetName = NameParameterSet, Mandatory = true, Position = 0, HelpMessage = "Blob name")]
        public string Blob
        {
            get { return BlobName; }
            set { BlobName = value; }
        }
        private string BlobName = String.Empty;

        [Parameter(HelpMessage = "Container name", Mandatory = true, Position = 1,
            ParameterSetName = NameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Container
        {
            get { return ContainerName; }
            set { ContainerName = value; }
        }
        private string ContainerName = String.Empty;

        [Parameter(HelpMessage = "Blob SnapshotTime", Mandatory = false, ParameterSetName = ContainerPipelineParameterSet)]
        [Parameter(HelpMessage = "Blob SnapshotTime", Mandatory = false, ParameterSetName = NameParameterSet)]
        [ValidateNotNullOrEmpty]
        public DateTimeOffset? SnapshotTime { get; set; }

        [Parameter(HelpMessage = "Blob VersionId", Mandatory = false, ParameterSetName = ContainerPipelineParameterSet)]
        [Parameter(HelpMessage = "Blob VersionId", Mandatory = false, ParameterSetName = NameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string VersionId { get; set; }

        [Parameter(HelpMessage = "Query string, see more details in: https://learn.microsoft.com/en-us/azure/storage/blobs/query-acceleration-sql-reference", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string QueryString { get; set; }

        [Parameter(HelpMessage = "Local file path to save the query result.", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string ResultFile { get; set; }

        [Parameter(HelpMessage = "The configuration used to handled the query input text.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public PSBlobQueryTextConfiguration InputTextConfiguration { get; set; }

        [Parameter(HelpMessage = "The configuration used to handled the query output text.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public PSBlobQueryTextConfiguration OutputTextConfiguration { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Return whether the specified blob is successfully queried.")]
        public SwitchParameter PassThru { get; set; }

        [Parameter(HelpMessage = "Force to overwrite the existing file.")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Initializes a new instance of the RemoveStorageAzureBlobCommand class.
        /// </summary>
        public GetStorageAzureBlobQueryResultCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the RemoveStorageAzureBlobCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public GetStorageAzureBlobQueryResultCommand(IStorageBlobManagement channel)
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
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            Func<long, Task> taskGenerator = null;
            IStorageBlobManagement localChannel = Channel;

            switch (ParameterSetName)
            {
                case BlobPipelineParameterSet:
                    break;
                case ContainerPipelineParameterSet:
                    this.BlobBaseClient = Util.GetTrack2BlobClient(this.BlobContainerClient,
                        this.Blob, Channel.StorageContext,
                        this.VersionId,
                        null,
                        this.SnapshotTime is null ? null : this.SnapshotTime.Value.ToUniversalTime().ToString("o").Replace("+00:00", "Z"),
                        this.ClientOptions, Track2Models.BlobType.Block);
                    break;
                case NameParameterSet:
                default:
                    BlobContainerClient container = localChannel.GetBlobContainerClient(this.Container, this.ClientOptions);
                    this.BlobBaseClient = Util.GetTrack2BlobClient(
                        container,
                        this.Blob, Channel.StorageContext,
                        this.VersionId,
                        null,
                        this.SnapshotTime is null ? null : this.SnapshotTime.Value.ToUniversalTime().ToString("o").Replace("+00:00", "Z"),
                        this.ClientOptions, Track2Models.BlobType.Block);
                    break;
            }

            taskGenerator = (taskId) => QueryAzureBlob(taskId, localChannel, this.BlobBaseClient, this.QueryString, true);
            RunTask(taskGenerator);
        }

        internal async Task QueryAzureBlob(long taskId, IStorageBlobManagement localChannel, BlobBaseClient blob, string query, bool headers)
        {
            IProgress<long> progressHandler = new Progress<long>((finishedBytes) =>
            {
                bytesScanned = finishedBytes;
            });

            // preapre query Option
            // Not show the Progressbar now, since the ProgressHandler can't represent the read query progress 
            Track2Models.BlobQueryOptions queryOption = new Track2Models.BlobQueryOptions
            {
                InputTextConfiguration = this.InputTextConfiguration is null ? null : this.InputTextConfiguration.ParseBlobQueryTextConfiguration(),
                OutputTextConfiguration = this.OutputTextConfiguration is null ? null : this.OutputTextConfiguration.ParseBlobQueryTextConfiguration(),
                ProgressHandler = progressHandler,
            };

            queryOption.ErrorHandler += (e) =>
            {
                queryErrors.Add(new PSBlobQueryError(e));
            };

            if (this.Force.IsPresent
                || !System.IO.File.Exists(this.ResultFile)
                || ShouldContinue(string.Format(Resources.OverwriteConfirmation, this.ResultFile), null))
            {
                {
                    using (var reader = (await ((BlockBlobClient)blob).QueryAsync(query, queryOption, CmdletCancellationToken)).Value.Content)
                    {
                        FileStream fs = File.Create(this.ResultFile);
                        reader.CopyTo(fs);
                        fs.Close();
                    }
                    OutputStream.WriteObject(taskId, new BlobQueryOutput(bytesScanned, queryErrors));
                }
            }
        }
    }
}
