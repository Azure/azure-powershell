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

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.File;
using System;
using System.Collections.Concurrent;
using System.Management.Automation;
using System.Security.Permissions;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.Storage.File.Cmdlet
{
    [Cmdlet(VerbsCommon.Get, Constants.FileCopyCmdletStateName)]
    public class GetAzureStorageFileCopyStateCommand : AzureStorageFileCmdletBase
    {
        [Parameter(
            Position = 0,
            HelpMessage = "Target share name",
            Mandatory = true,
            ParameterSetName = Constants.ShareNameParameterSetName)]
        [ValidateNotNullOrEmpty]
        public string ShareName { get; set; }

        [Parameter(
            Position = 1,
            HelpMessage = "Target file path",
            Mandatory = true,
            ParameterSetName = Constants.ShareNameParameterSetName)]
        [ValidateNotNullOrEmpty]
        public string FilePath { get; set; }

        [Parameter(
            Position = 0,
            HelpMessage = "Target file instance", Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = Constants.FileParameterSetName)]
        [ValidateNotNull]
        public CloudFile File { get; set; }

        [Parameter(HelpMessage = "Indicates whether or not to wait util the copying finished.")]
        public SwitchParameter WaitForComplete { get; set; }

        /// <summary>
        /// CloudFile objects which need to mointor until copy complete
        /// </summary>
        private ConcurrentQueue<Tuple<long, CloudFile>> jobList = new ConcurrentQueue<Tuple<long, CloudFile>>();
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
            CloudFile file = null;

            if (null != this.File)
            {
                file = this.File;
            }
            else
            {
                string[] path = NamingUtil.ValidatePath(this.FilePath, true);
                file = this.BuildFileShareObjectFromName(this.ShareName).GetRootDirectoryReference().GetFileReferenceByPath(path);
            }

            long taskId = InternalTotalTaskCount;
            jobList.Enqueue(new Tuple<long, CloudFile>(taskId, file));
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
        /// <param name="file">CloudFile instance</param>
        /// <param name="progress">Progress record</param>
        internal void WriteCopyProgress(CloudFile file, ProgressRecord progress)
        {
            if (file.CopyState == null) return;
            long bytesCopied = file.CopyState.BytesCopied ?? 0;
            long totalBytes = file.CopyState.TotalBytes ?? 0;
            int percent = 0;

            if (totalBytes != 0)
            {
                percent = (int)(bytesCopied * 100 / totalBytes);
                progress.PercentComplete = percent;
            }

            string activity = String.Format(Resources.CopyFileStatus, file.CopyState.Status.ToString(), file.GetFullPath(), file.Share.Name, file.CopyState.Source.ToString());
            progress.Activity = activity;
            string message = String.Format(Resources.CopyPendingStatus, percent, file.CopyState.BytesCopied, file.CopyState.TotalBytes);
            progress.StatusDescription = message;
            OutputStream.WriteProgress(progress);
        }

        protected override void EndProcessing()
        {
            int currency = GetCmdletConcurrency();

            OutputStream.TaskStatusQueryer = IsTaskCompleted;

            for (int i = 0; i < currency; i++)
            {
                Func<long, Task> taskGenerator = (taskId) => MonitorFileCopyStatusAsync(taskId);
                RunTask(taskGenerator);
            }

            base.EndProcessing();
        }

        /// <summary>
        /// Cmdlet end processing
        /// </summary>
        protected async Task MonitorFileCopyStatusAsync(long taskId)
        {
            ProgressRecord records = new ProgressRecord(OutputStream.GetProgressId(taskId), Resources.CopyFileActivity, Resources.CopyFileActivity);
            Tuple<long, CloudFile> monitorRequest = null;
            FileRequestOptions requestOptions = RequestOptions;
            AccessCondition accessCondition = null;
            OperationContext context = OperationContext;

            while (!jobList.IsEmpty)
            {
                jobList.TryDequeue(out monitorRequest);

                if (monitorRequest != null)
                {
                    long internalTaskId = monitorRequest.Item1;
                    CloudFile file = monitorRequest.Item2;
                    //Just use the last file management channel since the following operation is context insensitive
                    await Channel.FetchFileAttributesAsync(file, accessCondition, requestOptions, context, CmdletCancellationToken);
                    bool taskDone = false;

                    if (file.CopyState == null)
                    {
                        ArgumentException e = new ArgumentException(String.Format(Resources.FileCopyTaskNotFound, file.Uri.ToString()));
                        OutputStream.WriteError(internalTaskId, e);
                        Interlocked.Increment(ref InternalFailedCount);
                        taskDone = true;
                    }
                    else
                    {
                        WriteCopyProgress(file, records);
                        UpdateTaskCount(file.CopyState.Status);

                        if (file.CopyState.Status == CopyStatus.Pending && this.WaitForComplete)
                        {
                            jobList.Enqueue(monitorRequest);
                        }
                        else
                        {
                            OutputStream.WriteObject(internalTaskId, file.CopyState);
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
