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
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using System.Management.Automation;
    using Microsoft.WindowsAzure.Commands.Storage.Model.ResourceModel;
    using global::Azure.Storage.Files.DataLake;
    using global::Azure.Storage.Files.DataLake.Models;
    using System;
    using System.Collections.Generic;
    using global::Azure;
    using System.Threading.Tasks;

    public abstract class DataLakeGen2ACLRecursiveBaseCmdlet : StorageCloudBlobCmdletBase
    {
        protected List<AccessControlChangeFailure> FailedEntries = new List<AccessControlChangeFailure>();
        protected long totalDirectoriesSuccessfulCount = 0;
        protected long totalFilesSuccessfulCount = 0;
        protected long totalFailureCount = 0;
        protected string continuationToken = null;
        protected string summaryString;
        protected string Operator = "Change";

        [Parameter(ValueFromPipeline = true, Position = 0, Mandatory = true, HelpMessage = "FileSystem name")]
        [ValidateNotNullOrEmpty]
        public string FileSystem { get; set; }

        [Parameter(ValueFromPipeline = true, Position = 1, Mandatory = false, HelpMessage =
                "The path in the specified FileSystem that to change Acl recursively. Can be a file or directory. " +
                "In the format 'directory/file.txt' or 'directory1/directory2/'. Skip set this parameter to change Acl recursively from root directory of the Filesystem.")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Continuation Token.")]
        public string ContinuationToken { get; set; }

        [Parameter(HelpMessage = "The POSIX access control list to set recursively for the file or directory.", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public PSPathAccessControlEntry[] Acl { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Set this parameter to ignore failures and continue proceeing with the operation on other sub-entities of the directory. Default the operation will terminate quickly on encountering failures.")]
        public SwitchParameter ContinueOnFailure { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "If data set size exceeds batch size then operation will be split into multiple requests so that progress can be tracked. Batch size should be between 1 and 2000. Default is 2000.")]
        public int BatchSize
        {
            get
            {
                return batchSize is null ? 0 : batchSize.Value;
            }
            set
            {
                batchSize = value;
            }
        }
        protected int? batchSize = null;

        [Parameter(Mandatory = false,
            HelpMessage = "Maximum number of batches that single change Access Control operation can execute. If data set size exceeds MaxBatchCount multiply BatchSize, continuation token will be return.")]
        public int MaxBatchCount
        {
            get
            {
                return maxBatchCount is null ? 0 : maxBatchCount.Value;
            }
            set
            {
                maxBatchCount = value;
            }
        }
        protected int? maxBatchCount = null;

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public virtual SwitchParameter AsJob { get; set; }

        // Overwrite the useless parameter
        public override int? ConcurrentTaskCount { get; set; }
        public override int? ClientTimeoutPerRequest { get; set; }
        public override int? ServerTimeoutPerRequest { get; set; }
        public override string TagCondition { get; set; }

        protected AccessControlChangeOptions GetAccessControlChangeOptions(long taskId)
        {
            return new AccessControlChangeOptions()
            {
                BatchSize = this.batchSize,
                ContinueOnFailure = this.ContinueOnFailure.IsPresent,
                MaxBatches = this.maxBatchCount,
                ProgressHandler = GetProgressHandler(taskId)
            };
        }

        protected IProgress<Response<AccessControlChanges>> GetProgressHandler(long taskId)
        {
            if (this.progressRecord == null)
            {
                progressRecord = GetProgressRecord("Change", taskId);
            }
            this.OutputStream.WriteProgress(progressRecord);

            return new ChangeAccessControlPartialResultProgress((setProgress) =>
            {
                if (this.progressRecord != null)
                {
                    totalDirectoriesSuccessfulCount += setProgress.Value.BatchCounters.ChangedDirectoriesCount;
                    totalFilesSuccessfulCount += setProgress.Value.BatchCounters.ChangedFilesCount;
                    totalFailureCount += setProgress.Value.BatchCounters.FailedChangesCount;
                    this.FailedEntries.AddRange(setProgress.Value.BatchFailures);

                    if (setProgress.Value.ContinuationToken == continuationToken  && (setProgress.Value.BatchCounters.FailedChangesCount == 0 ||this.ContinueOnFailure.IsPresent))
                    {
                        // When SDK return continuationToken same as the chunk before last, it means this is the last chunk of this run, and the token is for the chunk before last
                        // this continuationToken should only output when last chunk has failure and ContinueOnFailure disable, else return null
                        continuationToken = null;
                    }
                    else if (setProgress.Value.ContinuationToken == null && setProgress.Value.BatchCounters.FailedChangesCount != 0 && !this.ContinueOnFailure.IsPresent)
                    {
                        // when SDK return continuationToken as null, it means this is the last chunk of this run
                        // should output the continue token of the chunk before last , when last chunk has failure and ContinueOnFailure disable
                        // So don't need to update continue token
                    }
                    else
                    {
                        continuationToken = setProgress.Value.ContinuationToken;
                    }

                    long total = totalDirectoriesSuccessfulCount + totalFilesSuccessfulCount + totalFailureCount;
                    summaryString = $"Total Finished: {total}, Directories Success: {totalDirectoriesSuccessfulCount},  File Success: {totalFilesSuccessfulCount}, Failed: {totalFailureCount}";
                    progressRecord.StatusDescription = summaryString;
                    progressRecord.PercentComplete = (progressRecord.PercentComplete + 10) % 110;
                    this.OutputStream.WriteProgress(progressRecord);
                }
            });
        }

        /// <summary>
        /// Since it's difficult to know if the progress is finished or not in the progress, so need set progressbar to complete after cmdlet finish set acl recursive
        /// </summary>
        protected void SetProgressComplete()
        {
            // Update progress bar to 100%
            progressRecord.PercentComplete = 100;
            this.OutputStream.WriteProgress(progressRecord);
        }


        protected ProgressRecord progressRecord;
        protected ProgressRecord GetProgressRecord(string aclOperator, long taskId)
        {
            summaryString = $"Total Finished: 0, Directories Success: 0,  File Success: 0, Failed: 0";
            totalDirectoriesSuccessfulCount = 0;
            totalFilesSuccessfulCount = 0;
            totalFailureCount = 0;

            return new ProgressRecord(activityId: OutputStream.GetProgressId(taskId),
            activity: string.Format($"{aclOperator} ACL Recursive"),
            statusDescription: summaryString)
            {
                PercentComplete = 0
            };
        }

        protected void WriteResult(long taskId)
        {
            PSACLRecursiveChangeResult result = new PSACLRecursiveChangeResult(this.totalDirectoriesSuccessfulCount,
                this.totalFilesSuccessfulCount,
                this.totalFailureCount,
                this.continuationToken,
                this.FailedEntries);
            OutputStream.WriteObject(taskId, result);
        }

        /// <summary>
        /// Set/Update/Remove ACL recusive async function
        /// </summary>
        protected abstract Task OperationAclResusive(long taskId);

        /// <summary>
        /// execute command
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Func<long, Task> taskGenerator = (taskId) => OperationAclResusive(taskId);
            RunTask(taskGenerator);
        }
    }

    public class ChangeAccessControlPartialResultProgress : IProgress<Response<AccessControlChanges>>
    {
        private Action<Response<AccessControlChanges>> progressHandler;

        public ChangeAccessControlPartialResultProgress(Action<Response<AccessControlChanges>> progressHandler)
        {
            this.progressHandler = progressHandler;
        }

        public void Report(Response<AccessControlChanges> value)
        {
            this.progressHandler(value);            
        }
    }
}
