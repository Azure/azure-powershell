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

using Microsoft.Azure.Storage;
using XFile = Microsoft.Azure.Storage.File;
using Microsoft.Azure.Storage.File;
using System;
using System.Collections.Concurrent;
using System.Management.Automation;
using System.Security.Permissions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Azure.Storage.Files.Shares;
using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using Azure.Storage.Files.Shares.Models;

namespace Microsoft.WindowsAzure.Commands.Storage.File.Cmdlet
{
    [Cmdlet("Get", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageFileCopyState")]
    [OutputType(typeof(PSCopyState))]
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

        [CmdletParameterBreakingChangeWithVersion("File", "13.0.0", "8.0.0", ChangeDescription = "The parameter File (alias CloudFile) will be deprecated, and ShareFileClient will be mandatory.")]
        [Parameter(
            Position = 0,
            HelpMessage = "Target file instance", Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.FileParameterSetName)]
        [ValidateNotNull]
        [Alias("CloudFile")]
        public CloudFile File { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.FileParameterSetName,
            HelpMessage = "ShareFileClient object indicated the file to get copy status.")]
        [ValidateNotNull]
        public ShareFileClient ShareFileClient { get; set; }

        [Parameter(HelpMessage = "Indicates whether or not to wait util the copying finished.")]
        public SwitchParameter WaitForComplete { get; set; }

        /// <summary>
        /// CloudFile objects which need to mointor until copy complete
        /// </summary>
        private ConcurrentQueue<Tuple<long, ShareFileClient>> jobList = new ConcurrentQueue<Tuple<long, ShareFileClient>>();
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

            ShareFileClient file = null;

            if (this.ShareFileClient != null)
            {
                file = this.ShareFileClient;
            }
            else if (null != this.File)
            {
                file = AzureStorageFile.GetTrack2FileClient(this.File);
            }
            else
            {
                file = Util.GetTrack2ShareReference(this.ShareName,
                    (AzureStorageContext)this.Context,
                    snapshotTime: null,
                    ClientOptions).GetRootDirectoryClient().GetFileClient(this.FilePath);
            }

            long taskId = InternalTotalTaskCount;
            jobList.Enqueue(new Tuple<long, ShareFileClient>(taskId, file));
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
        private void UpdateTaskCount(global::Azure.Storage.Files.Shares.Models.CopyStatus status)
        {
            switch (status)
            {
                case global::Azure.Storage.Files.Shares.Models.CopyStatus.Failed:
                case global::Azure.Storage.Files.Shares.Models.CopyStatus.Aborted:
                    Interlocked.Increment(ref InternalFailedCount);
                    break;
                case global::Azure.Storage.Files.Shares.Models.CopyStatus.Pending:
                    break;
                case global::Azure.Storage.Files.Shares.Models.CopyStatus.Success:
                default:
                    Interlocked.Increment(ref InternalFinishedCount);
                    break;
            }
        }

        /// <summary>
        /// Write copy progress
        /// </summary>
        /// <param name="file">file client object </param>
        /// <param name="fileProperties">File Properties</param>
        /// <param name="progress">Progress record</param>
        internal void WriteCopyProgress(ShareFileClient file, ShareFileProperties fileProperties, ProgressRecord progress)
        {
            if (fileProperties.CopyId == null) return;
            long bytesCopied = string.IsNullOrEmpty(fileProperties.CopyProgress) ? 0 : Convert.ToInt64(fileProperties.CopyProgress.Split(new char[] { '/' })[0]);
            long totalBytes = string.IsNullOrEmpty(fileProperties.CopyProgress) ? 0 : Convert.ToInt64(fileProperties.CopyProgress.Split(new char[] { '/' })[1]);
            int percent = 0;

            if (totalBytes != 0)
            {
                percent = (int)(bytesCopied * 100 / totalBytes);
                progress.PercentComplete = percent;
            }

            string activity = String.Format(Resources.CopyFileStatus, fileProperties.CopyStatus, file.Path, file.ShareName, fileProperties.CopySource);
            progress.Activity = activity;
            string message = String.Format(Resources.CopyPendingStatus, percent, bytesCopied, totalBytes);
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
            Tuple<long, ShareFileClient> monitorRequest = null;

            while (!jobList.IsEmpty)
            {
                jobList.TryDequeue(out monitorRequest);

                if (monitorRequest != null)
                {
                    long internalTaskId = monitorRequest.Item1;
                    ShareFileClient file = monitorRequest.Item2;
                    //Just use the last file management channel since the following operation is context insensitive
                    ShareFileProperties fileProperties = (await file.GetPropertiesAsync(this.CmdletCancellationToken).ConfigureAwait(false)).Value;
                    bool taskDone = false;

                    if (fileProperties.CopyId == null)
                    {
                        ArgumentException e = new ArgumentException(String.Format(Resources.FileCopyTaskNotFound, file.Uri.ToString().Replace(file.Uri.Query, "")));
                        OutputStream.WriteError(internalTaskId, e);
                        Interlocked.Increment(ref InternalFailedCount);
                        taskDone = true;
                    }
                    else
                    {
                        WriteCopyProgress(file, fileProperties, records);
                        UpdateTaskCount(fileProperties.CopyStatus);

                        if (fileProperties.CopyStatus == global::Azure.Storage.Files.Shares.Models.CopyStatus.Pending && this.WaitForComplete)
                        {
                            jobList.Enqueue(monitorRequest);
                        }
                        else
                        {
                            OutputStream.WriteObject(internalTaskId, new PSCopyState(fileProperties));
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
