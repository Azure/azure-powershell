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

using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Properties;
using System;
using System.Globalization;
using System.IO;
using System.Management.Automation;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Synapse.Commands
{
    public class SynapseDataMovementCmdletBase : SynapseArtifactsCmdletBase
    {
        /// <summary>
        /// Bytes of 4 MB
        /// </summary>
        protected const int size4MB = 4 * 1024 * 1024;

        /// <summary>
        /// Amount of concurrent async tasks to run per available core.
        /// </summary>
        private int _concurrentTaskCount = 10;

        /// <summary>
        /// Amount of concurrent async tasks to run per available core.
        /// </summary>
        [Parameter(HelpMessage = "The total amount of concurrent async tasks. The default value is 10.")]
        [ValidateNotNull]
        [ValidateRange(1, 1000)]
        public virtual int? ConcurrentTaskCount
        {
            get { return _concurrentTaskCount; }
            set
            {
                var count = value.Value;

                if (count > 0)
                {
                    _concurrentTaskCount = count;
                }
            }
        }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public virtual SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Enable or disable multithread
        ///     If the package cmdlet want to disable the multithread feature,
        ///     it can disable when construct and beginProcessing
        /// </summary>
        protected bool EnableMultiThread
        {
            get { return _enableMultiThread; }
            set { _enableMultiThread = value; }
        }
        protected bool _enableMultiThread = true;

        internal TaskOutputStream OutputStream;

        /// <summary>
        /// Cancellation Token Source
        /// </summary>
        protected readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        protected CancellationToken CmdletCancellationToken;

        /// <summary>
        /// Summary progress record on multithread task
        /// </summary>
        protected ProgressRecord summaryRecord;

        private LimitedConcurrencyTaskScheduler _taskScheduler;

        /// <summary>
        /// CountDownEvent wait time out and output time interval.
        /// </summary>
        protected const int CountDownWaitTimeout = 1000;//ms

        protected override void BeginProcessing()
        {
            if (!AsJob.IsPresent)
            {
                DoBeginProcessing();
            }
        }

        public override void ExecuteCmdlet()
        {
            if (AsJob.IsPresent)
            {
                DoBeginProcessing();
            }

            DoExecuteCmdlet();

            if (AsJob.IsPresent)
            {
                DoEndProcessing();
            }
        }

        protected override void EndProcessing()
        {
            if (!AsJob.IsPresent)
            {
                DoEndProcessing();
            }
        }

        protected virtual void DoBeginProcessing()
        {
            CmdletCancellationToken = _cancellationTokenSource.Token;
            if (_enableMultiThread)
            {
                SetUpMultiThreadEnvironment();
            }

            OutputStream.ConfirmWriter = (s1, s2, s3) => ShouldContinue(s2, s3);
        }

        protected virtual void DoExecuteCmdlet()
        {
        }

        protected virtual void DoEndProcessing()
        {
            if (_enableMultiThread)
            {
                MultiThreadEndProcessing();
            }

            base.EndProcessing();
        }

        /// <summary>
        /// Close the summary progress bar, otherwise it'll cause a very bad performance on output.
        /// </summary>
        private void CloseSummaryProgressBar()
        {
            OutputStream.DisableProgressBar = true;
            summaryRecord.RecordType = ProgressRecordType.Completed;
            WriteProgress(summaryRecord);
        }

        /// <summary>
        /// Get the concurrency value
        /// </summary>
        /// <returns>The max number of concurrent task/rest call</returns>
        protected int GetCmdletConcurrency()
        {
            return _concurrentTaskCount;
        }

        /// <summary>
        /// Configure Service Point
        /// </summary>
        private void ConfigureServicePointManager()
        {
            var maxConcurrency = 1000;
            var cmdletConcurrency = GetCmdletConcurrency();
            maxConcurrency = Math.Max(maxConcurrency, cmdletConcurrency);
            // Set the default connection limit to a very high value and control the concurrency with LimitedConcurrencyTaskScheduler.
            // If so, there is no need to set the ConnectionLimit for each ServicePoint.
            ServicePointManager.DefaultConnectionLimit = maxConcurrency;
            ServicePointManager.Expect100Continue = false;
            ServicePointManager.UseNagleAlgorithm = true;
        }

        private void TaskErrorHandler(object sender, TaskExceptionEventArgs args)
        {
            OutputStream?.WriteError(args.TaskId, args.Exception);
        }

        /// <summary>
        /// Init the multithread run time resource
        /// </summary>
        internal void InitMutltiThreadResources()
        {
            _taskScheduler = new LimitedConcurrencyTaskScheduler(GetCmdletConcurrency(), CmdletCancellationToken);
            OutputStream = new TaskOutputStream(CmdletCancellationToken)
            {
                OutputWriter = WriteObject,
                ErrorWriter = WriteExceptionError,
                ProgressWriter = WriteProgress,
                VerboseWriter = WriteVerbose,
                DebugWriter = WriteDebugWithTimestamp,
                ConfirmWriter = ShouldProcess,
                TaskStatusQueryer = _taskScheduler.IsTaskCompleted
            };
            _taskScheduler.OnError += TaskErrorHandler;

            const int summaryRecordId = 0;
            var summary = String.Format(Resources.TransmitActiveSummary, _taskScheduler.TotalTaskCount,
                _taskScheduler.FinishedTaskCount, _taskScheduler.FailedTaskCount, _taskScheduler.ActiveTaskCount);
            var activity = string.Format(Resources.TransmitActivity, MyInvocation.MyCommand);
            summaryRecord = new ProgressRecord(summaryRecordId, activity, summary);
            CmdletCancellationToken.Register(() => OutputStream.CancelConfirmRequest());
        }

        /// <summary>
        /// Set up MultiThread environment
        /// </summary>
        internal void SetUpMultiThreadEnvironment()
        {
            ConfigureServicePointManager();
            InitMutltiThreadResources();
        }

        /// <summary>
        /// End processing in multi thread environment
        /// </summary>
        internal void MultiThreadEndProcessing()
        {
            do
            {
                WriteTransmitSummaryStatus();
                OutputStream.Output();
            }
            while (!_taskScheduler.WaitForComplete(CountDownWaitTimeout, CmdletCancellationToken));

            CloseSummaryProgressBar();
            OutputStream.Output();
        }

        /// <summary>
        /// Write transmit summary status
        /// </summary>
        protected virtual void WriteTransmitSummaryStatus()
        {
            var summary = String.Format(Resources.TransmitActiveSummary, _taskScheduler.TotalTaskCount,
                _taskScheduler.FinishedTaskCount, _taskScheduler.FailedTaskCount, _taskScheduler.ActiveTaskCount);
            summaryRecord.StatusDescription = summary;
            WriteProgress(summaryRecord);
        }

        internal void RunTask(Func<long, Task> taskGenerator)
        {
            _taskScheduler.RunTask(taskGenerator);
        }

        /// <summary>
        /// Upload workspace package
        /// </summary>
        internal virtual async Task UploadWorkspacePackage(long taskId, string filePath, string packageName)
        {
            // Check if the package already exists
            bool exists = await this.SynapseAnalyticsClient.TestPackageAsync(packageName);
            if (exists)
            {
                throw new AzPSInvalidOperationException(string.Format(Resources.WorkspacePackageExists, packageName, this.WorkspaceName));
            }

            // Prepare progress handler
            long fileSize = new FileInfo(filePath).Length;
            string activity = String.Format(Resources.UploadWorkspacePackageActivity, filePath);
            string status = Resources.PrepareUploadingPackage;
            ProgressRecord pr = new ProgressRecord(OutputStream.GetProgressId(taskId), activity, status);
            IProgress<long> progressHandler = new Progress<long>((finishedBytes) =>
            {
                if (pr != null)
                {
                    // Size of the source file might be 0, when it is, directly treat the progress as 100 percent.
                    pr.PercentComplete = 0 == fileSize ? 100 : (int)(finishedBytes * 100 / fileSize);
                    pr.StatusDescription = string.Format(CultureInfo.CurrentCulture, Resources.FileTransmitStatus, pr.PercentComplete);
                    this.OutputStream.WriteProgress(pr);
                }
            });

            using (FileStream stream = System.IO.File.OpenRead(filePath))
            {
                // Create Package
                await this.SynapseAnalyticsClient.CreatePackageAsync(packageName);

                // Upload package content
                byte[] uploadcache4MB = null;
                byte[] uploadcache = null;
                progressHandler.Report(0);
                long offset = 0;
                while (offset < fileSize)
                {
                    // Get chunk size and prepare cache
                    int chunksize = size4MB;
                    if (chunksize <= (fileSize - offset)) // Chunk size will be 4MB
                    {
                        if (uploadcache4MB == null)
                        {
                            uploadcache4MB = new byte[size4MB];
                        }
                        uploadcache = uploadcache4MB;
                    }
                    else // last chunk can < 4MB
                    {
                        chunksize = (int)(fileSize - offset);
                        if (uploadcache4MB == null)
                        {
                            uploadcache = new byte[chunksize];
                        }
                        else
                        {
                            uploadcache = uploadcache4MB;
                        }
                    }

                    // Get content to upload for the chunk
                    int readoutcount = await stream.ReadAsync(uploadcache, 0, (int)chunksize).ConfigureAwait(false);
                    MemoryStream chunkContent = new MemoryStream(uploadcache, 0, readoutcount);

                    // Upload content
                    await this.SynapseAnalyticsClient.AppendPackageAsync(packageName, chunkContent);

                    // Update progress
                    offset += readoutcount;
                    progressHandler.Report(offset);
                }
            }

            // Call Flush API as a completion signal
            await this.SynapseAnalyticsClient.FlushPackageAsync(packageName);
        }
    }
}
