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
    using Commands.Common.Storage.ResourceModel;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;
    using System;
    using System.Collections.Concurrent;
    using System.Management.Automation;
    using System.Security.Permissions;
    using System.Threading;
    using System.Threading.Tasks;

    [Cmdlet(VerbsCommon.Get, StorageNouns.CopyBlobStatus, DefaultParameterSetName = NameParameterSet),
       OutputType(typeof(AzureStorageBlob))]
    public class GetAzureStorageBlobCopyState : StorageCloudBlobCmdletBase
    {
        /// <summary>
        /// Blob Pipeline parameter set name
        /// </summary>
        private const string BlobPipelineParameterSet = "BlobPipeline";

        /// <summary>
        /// container pipeline paremeter set name
        /// </summary>
        private const string ContainerPipelineParmeterSet = "ContainerPipeline";

        /// <summary>
        /// blob name and container name parameter set
        /// </summary>
        private const string NameParameterSet = "NamePipeline";

        [Alias("ICloudBlob")]
        [Parameter(HelpMessage = "CloudBlob Object", Mandatory = true,
            ValueFromPipelineByPropertyName = true, ParameterSetName = BlobPipelineParameterSet)]
        public CloudBlob CloudBlob { get; set; }

        [Parameter(HelpMessage = "CloudBlobContainer Object", Mandatory = true,
            ValueFromPipelineByPropertyName = true, ParameterSetName = ContainerPipelineParmeterSet)]
        public CloudBlobContainer CloudBlobContainer { get; set; }

        [Parameter(ParameterSetName = ContainerPipelineParmeterSet, Mandatory = true, Position = 0, HelpMessage = "Blob name")]
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

        [Parameter(HelpMessage = "Wait for copy task complete")]
        public SwitchParameter WaitForComplete
        {
            get { return waitForComplete; }
            set { waitForComplete = value; }
        }
        private bool waitForComplete;

        /// <summary>
        /// CloudBlob objects which need to mointor until copy complete
        /// </summary>
        private ConcurrentQueue<Tuple<long, CloudBlob>> jobList = new ConcurrentQueue<Tuple<long, CloudBlob>>();
        private ConcurrentDictionary<long, bool> TaskStatus = new ConcurrentDictionary<long, bool>();

        /// <summary>
        /// Is the specified task completed
        /// </summary>
        /// <param name="taskId">Task id</param>
        /// <returns>True if the specified task completed, otherwise false</returns>
        protected bool IsTaskCompleted(long taskId)
        {
            bool finished = false;
            bool existed = TaskStatus.TryGetValue(taskId, out finished);
            return existed && finished;
        }

        /// <summary>
        /// Copy task count
        /// </summary>
        private long InternalTotalTaskCount = 0;
        private long InternalFailedCount = 0;
        private long InternalFinishedCount = 0;

        /// <summary>
        /// Execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            CloudBlob blob = null;

            switch (ParameterSetName)
            {
                case NameParameterSet:
                    blob = GetCloudBlobObject(ContainerName, BlobName);
                    break;
                case ContainerPipelineParmeterSet:
                    blob = GetCloudBlobObject(CloudBlobContainer, BlobName);
                    break;
                case BlobPipelineParameterSet:
                    blob = GetCloudBlobObject(CloudBlob);
                    break;
            }

            long taskId = InternalTotalTaskCount;
            jobList.Enqueue(new Tuple<long, CloudBlob>(taskId, blob));
            InternalTotalTaskCount++;
        }

        /// <summary>
        /// Write transmit summary status
        /// </summary>
        protected override void WriteTransmitSummaryStatus()
        {
            long localTotal = Interlocked.Read(ref InternalTotalTaskCount);
            long localFailed = Interlocked.Read(ref InternalFailedCount);
            long localFinished = Interlocked.Read(ref InternalFinishedCount);

            string summary = String.Format(Resources.TransmitActiveSummary, localTotal,
                localFailed, localFinished, (localTotal - localFailed - localFinished));
            summaryRecord.StatusDescription = summary;
            WriteProgress(summaryRecord);
        }

        /// <summary>
        /// Update failed/finished task count
        /// </summary>
        /// <param name="status">Copy status</param>
        private void UpdateTaskCount(CopyStatus status)
        {
            switch (status)
            {
                case CopyStatus.Invalid:
                case CopyStatus.Failed:
                case CopyStatus.Aborted:
                    Interlocked.Increment(ref InternalFailedCount);
                    break;
                case CopyStatus.Pending:
                    break;
                case CopyStatus.Success:
                default:
                    Interlocked.Increment(ref InternalFinishedCount);
                    break;
            }
        }

        /// <summary>
        /// Write copy progress
        /// </summary>
        /// <param name="blob">ICloud blob object</param>
        /// <param name="progress">Progress record</param>
        internal void WriteCopyProgress(CloudBlob blob, ProgressRecord progress)
        {
            if (blob.CopyState == null) return;
            long bytesCopied = blob.CopyState.BytesCopied ?? 0;
            long totalBytes = blob.CopyState.TotalBytes ?? 0;
            int percent = 0;

            if (totalBytes != 0)
            {
                percent = (int)(bytesCopied * 100 / totalBytes);
                progress.PercentComplete = percent;
            }

            string activity = String.Format(Resources.CopyBlobStatus, blob.CopyState.Status.ToString(), blob.Name, blob.Container.Name, blob.CopyState.Source.ToString());
            progress.Activity = activity;
            string message = String.Format(Resources.CopyPendingStatus, percent, blob.CopyState.BytesCopied, blob.CopyState.TotalBytes);
            progress.StatusDescription = message;
            OutputStream.WriteProgress(progress);
        }

        /// <summary>
        /// Get blob with copy status by name
        /// </summary>
        /// <param name="containerName">Container name</param>
        /// <param name="blobName">blob name</param>
        /// <returns>CloudBlob object</returns>
        private CloudBlob GetCloudBlobObject(string containerName, string blobName)
        {
            CloudBlobContainer container = Channel.GetContainerReference(containerName);
            return GetCloudBlobObject(container, blobName);
        }

        /// <summary>
        /// Get blob with copy status by CloudBlobContainer object
        /// </summary>
        /// <param name="container">CloudBlobContainer object</param>
        /// <param name="blobName">Blob name</param>
        /// <returns>CloudBlob object</returns>
        private CloudBlob GetCloudBlobObject(CloudBlobContainer container, string blobName)
        {
            AccessCondition accessCondition = null;
            BlobRequestOptions options = RequestOptions;

            NameUtil.ValidateBlobName(blobName);
            NameUtil.ValidateContainerName(container.Name);

            CloudBlob blob = GetBlobReferenceFromServerWithContainer(Channel, container, blobName, accessCondition, options, OperationContext);

            return GetCloudBlobObject(blob);
        }

        /// <summary>
        /// Get blob with copy status by CloudBlob object
        /// </summary>
        /// <param name="blob">CloudBlob object</param>
        /// <returns>CloudBlob object</returns>
        private CloudBlob GetCloudBlobObject(CloudBlob blob)
        {
            NameUtil.ValidateBlobName(blob.Name);

            ValidateBlobType(blob);

            return blob;
        }

        protected override void EndProcessing()
        {
            int currency = GetCmdletConcurrency();

            OutputStream.TaskStatusQueryer = IsTaskCompleted;

            for (int i = 0; i < currency; i++)
            {
                Func<long, Task> taskGenerator = (taskId) => MonitorBlobCopyStatusAsync(taskId);
                RunTask(taskGenerator);
            }

            base.EndProcessing();
        }

        /// <summary>
        /// Cmdlet end processing
        /// </summary>
        protected async Task MonitorBlobCopyStatusAsync(long taskId)
        {
            ProgressRecord records = new ProgressRecord(OutputStream.GetProgressId(taskId), Resources.CopyBlobActivity, Resources.CopyBlobActivity);
            Tuple<long, CloudBlob> monitorRequest = null;
            BlobRequestOptions requestOptions = RequestOptions;
            AccessCondition accessCondition = null;
            OperationContext context = OperationContext;

            while (!jobList.IsEmpty)
            {
                jobList.TryDequeue(out monitorRequest);

                if (monitorRequest != null)
                {
                    long internalTaskId = monitorRequest.Item1;
                    CloudBlob blob = monitorRequest.Item2;
                    //Just use the last blob management channel since the following operation is context insensitive
                    await Channel.FetchBlobAttributesAsync(blob, accessCondition, requestOptions, context, CmdletCancellationToken);
                    bool taskDone = false;

                    if (blob.CopyState == null)
                    {
                        ArgumentException e = new ArgumentException(String.Format(Resources.CopyTaskNotFound, blob.Name, blob.Container.Name));
                        OutputStream.WriteError(internalTaskId, e);
                        Interlocked.Increment(ref InternalFailedCount);
                        taskDone = true;
                    }
                    else
                    {
                        WriteCopyProgress(blob, records);
                        UpdateTaskCount(blob.CopyState.Status);

                        if (blob.CopyState.Status == CopyStatus.Pending && waitForComplete)
                        {
                            jobList.Enqueue(monitorRequest);
                        }
                        else
                        {
                            OutputStream.WriteObject(internalTaskId, blob.CopyState);
                            taskDone = true;
                        }
                    }

                    if (taskDone)
                    {
                        SetInternalTaskDone(internalTaskId);
                    }
                }

                if (ShouldForceQuit)
                {
                    break;
                }
            }
        }

        private void SetInternalTaskDone(long taskId)
        {
            bool finishedTaskStatus = true;
            TaskStatus.TryAdd(taskId, finishedTaskStatus);
        }
    }
}
