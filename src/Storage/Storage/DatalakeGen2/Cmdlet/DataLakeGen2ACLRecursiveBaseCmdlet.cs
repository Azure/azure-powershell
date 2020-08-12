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

        //[Parameter(Mandatory = false,
        //    HelpMessage = "Set this parameter to ignore failures and continue proceeing with the operation on other sub-entities of the directory. Default the operation will terminate quickly on encountering failures.")]
        //public SwitchParameter ContinueOnFailure { get; set; }

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

        protected AccessControlChangeOptions accessControlChangeOptions
        {
            get
            {
                return new AccessControlChangeOptions()
                {
                    BatchSize = this.batchSize,
                    //ContinueOnFailure = this.ContinueOnFailure.IsPresent,
                    MaxBatches = this.maxBatchCount
                };
            }
        }        

        protected IProgress<Response<AccessControlChanges>> GetProgressHandler()
        {
            if (this.progressRecord == null)
            {
                progressRecord = GetProgressRecord("Change");
            }
            this.WriteProgress(progressRecord);

            //return new ChangeChangeAccessControlPartialResultProgress(this.FailedEntries, (setProgress) =>
            return new ChangeChangeAccessControlPartialResultProgress((setProgress) =>
            {
                if (this.progressRecord != null)
                {
                    // Size of the source file might be 0, when it is, directly treat the progress as 100 percent.
                    //progressRecord.PercentComplete = (totalTransferLength == 0) ? 100 : (int)(transferProgress.BytesTransferred * 100 / totalTransferLength);
                    totalDirectoriesSuccessfulCount += setProgress.Value.BatchCounters.ChangedDirectoriesCount;
                    totalFilesSuccessfulCount += setProgress.Value.BatchCounters.ChangedFilesCount;
                    totalFailureCount += setProgress.Value.BatchCounters.FailedChangesCount;
                    this.FailedEntries.AddRange(setProgress.Value.BatchFailures);
                    //if (setProgress.Value.BatchCounters.FailedEntries == null || new List<AccessControlChanges>(setProgress.Value.FailedEntries).Count == 0)

                    // TODO: Write like this, since the last request without ContinuationToken, XSCL will still set the ContinuationToken of the request before last. 
                    // After this is fixed, should update this block to "if(setProgress.Value.BatchCounters.FailedChangesCount == 0) {continuationToken = setProgress.Value.ContinuationToken;}" 
                    //if ((continuationToken == setProgress.Value.ContinuationToken) && (setProgress.Value.BatchCounters.FailedChangesCount == 0 || this.ContinueOnFailure.IsPresent))
                    if ((continuationToken == setProgress.Value.ContinuationToken) && (setProgress.Value.BatchCounters.FailedChangesCount == 0))
                    {
                        continuationToken = null;
                    }
                    else
                    {
                        continuationToken = setProgress.Value.ContinuationToken;
                    }

                    long total = totalDirectoriesSuccessfulCount + totalFilesSuccessfulCount + totalFailureCount;
                    summaryString = $"Total Finished: {total}, Directories Success: {totalDirectoriesSuccessfulCount},  File Success: {totalFilesSuccessfulCount}, Failed: {totalFailureCount}";
                    progressRecord.StatusDescription = summaryString;
                    progressRecord.PercentComplete = (progressRecord.PercentComplete + 10) % 110;
                    this.WriteProgress(progressRecord);
                }
            });
        }


        protected ProgressRecord progressRecord;
        protected ProgressRecord GetProgressRecord(string aclOperator)
        {
            summaryString = $"Total Finished: 0, Directories Success: 0,  File Success: 0, Failed: 0";
            return new ProgressRecord(new Random(DateTime.Now.Millisecond).Next(0, 10000000),
            string.Format($"{aclOperator} ACL Recursive"),
            summaryString)
            {
                PercentComplete = 0
            };
        }

        protected void WriteResult()
        {
            PSACLRecursiveChangeResult result = new PSACLRecursiveChangeResult(this.totalDirectoriesSuccessfulCount,
                this.totalFilesSuccessfulCount,
                this.totalFailureCount,
                this.continuationToken,
                this.FailedEntries);
            WriteObject(result, true);
        }       
    }

    public class ChangeChangeAccessControlPartialResultProgress : IProgress<Response<AccessControlChanges>>
    {
        private Action<Response<AccessControlChanges>> progressHandler;
        //private List<AccessControlChanges> FailedEntries = null;

        //public ChangeChangeAccessControlPartialResultProgress(List<AccessControlChanges> failedEntries, Action<Response<AccessControlChanges>> progressHandler)
        public ChangeChangeAccessControlPartialResultProgress(Action<Response<AccessControlChanges>> progressHandler)
        {
            //this.FailedEntries = failedEntries;
            this.progressHandler = progressHandler;
        }

        public void Report(Response<AccessControlChanges> value)
        {
            // Console.WriteLine(String.Format("success dir: {0}, success file: {1}, failed items: {2}", value.DirectoriesSuccessfulCount, value.FilesSuccessfulCount, value.FailureCount));
            //this.FailedEntries.AddRange(value.Value.FailedEntries);
            this.progressHandler(value);
            
        }
    }
}
