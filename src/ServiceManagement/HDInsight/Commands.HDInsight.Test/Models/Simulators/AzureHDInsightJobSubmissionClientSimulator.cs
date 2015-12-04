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


using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Hadoop.Client;
using Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.Utilities;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions;
using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest;
using Microsoft.WindowsAzure.Management.HDInsight.Logging;

namespace Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.Simulators
{
    internal class AzureHDInsightJobSubmissionClientSimulator : ClientBase, IJobSubmissionClient
    {
        internal const string JobFailed = "jobDetails failed";
        internal const string JobSuccesful = "jobDetails succeeded";
        private readonly AzureHDInsightClusterManagementClientSimulator.SimulatorClusterContainer cluster;
        private readonly IDictionary<string, string> jobError = new Dictionary<string, string>();
        private readonly IDictionary<string, string> jobOutput = new Dictionary<string, string>();
        private readonly ILogger logger;
        private readonly IDictionary<string, IEnumerable<string>> taskLogAttempts = new Dictionary<string, IEnumerable<string>>();
        private readonly IDictionary<string, string> taskLogs = new Dictionary<string, string>();
        private CancellationTokenSource cancellationTokenSource;

        private IJobSubmissionClientCredential credentials;

        public AzureHDInsightJobSubmissionClientSimulator(
            IJobSubmissionClientCredential credential, AzureHDInsightClusterManagementClientSimulator.SimulatorClusterContainer cluster)
        {
            this.credentials = credential;
            this.cluster = cluster;
            this.logger = new Logger();
            this.InitializeSimulator();
        }

        public new void Dispose()
        {
        }

        public event EventHandler<WaitJobStatusEventArgs> JobStatusEvent;

        public string GetCustomUserAgent()
        {
            throw new NotImplementedException();
        }

        public new void AddLogWriter(ILogWriter logWriter)
        {
            this.logger.AddWriter(logWriter);
        }

        public new void RemoveLogWriter(ILogWriter logWriter)
        {
            this.logger.RemoveWriter(logWriter);
        }

        public new void Cancel()
        {
        }

        public JobCreationResults CreateHiveJob(HiveJobCreateParameters hiveJobCreateParameters)
        {
            this.PrepareQueryJob(hiveJobCreateParameters);
            return this.CreateHiveJobAsync(hiveJobCreateParameters).WaitForResult();
        }

        public Task<JobCreationResults> CreateHiveJobAsync(HiveJobCreateParameters hiveJobCreateParameters)
        {
            if (hiveJobCreateParameters.Query.IsNullOrEmpty())
            {
                hiveJobCreateParameters.File.ArgumentNotNullOrEmpty("File");
                if (hiveJobCreateParameters.File.Contains("://") &&
                    !hiveJobCreateParameters.File.StartsWith("wasb", StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException("Invalid file protocol : " + hiveJobCreateParameters.File);
                }
            }
            else
            {
                this.PrepareQueryJob(hiveJobCreateParameters);
            }

            JobCreationResults retval =
                this.CreateJobSuccessResult(
                    new JobDetails
                    {
                        Name = hiveJobCreateParameters.JobName,
                        Query = hiveJobCreateParameters.Query,
                        StatusDirectory = hiveJobCreateParameters.StatusFolder
                    },
                    hiveJobCreateParameters.JobName);
            return TaskEx2.FromResult(retval);
        }

        public JobCreationResults CreateMapReduceJob(MapReduceJobCreateParameters mapReduceJobCreateParameters)
        {
            return this.CreateMapReduceJobAsync(mapReduceJobCreateParameters).WaitForResult();
        }

        public Task<JobCreationResults> CreateMapReduceJobAsync(MapReduceJobCreateParameters mapReduceJobCreateParameters)
        {
            if (mapReduceJobCreateParameters.JobName == "1456577")
            {
                throw new HttpLayerException(HttpStatusCode.BadRequest, "{ \"error\": \"File /example/files/WordCount.jar does not exist.\"}");
            }

            mapReduceJobCreateParameters.JarFile.ArgumentNotNullOrEmpty("JarFile");
            mapReduceJobCreateParameters.ClassName.ArgumentNotNullOrEmpty("ClassName");
            return TaskEx2.FromResult(this.CreateJobSuccessResult(mapReduceJobCreateParameters, mapReduceJobCreateParameters.JobName));
        }

        public JobCreationResults CreatePigJob(PigJobCreateParameters pigJobCreateParameters)
        {
            this.PrepareQueryJob(pigJobCreateParameters);
            return this.CreatePigJobAsync(pigJobCreateParameters).WaitForResult();
        }

        public Task<JobCreationResults> CreatePigJobAsync(PigJobCreateParameters pigJobCreateParameters)
        {
            if (pigJobCreateParameters == null)
            {
                throw new ArgumentNullException("pigJobCreateParameters");
            }

            this.PrepareQueryJob(pigJobCreateParameters);
            JobCreationResults retval =
                this.CreateJobSuccessResult(
                    new JobDetails { Query = pigJobCreateParameters.Query, StatusDirectory = pigJobCreateParameters.StatusFolder }, string.Empty);
            return TaskEx2.FromResult(retval);
        }

        public JobCreationResults CreateSqoopJob(SqoopJobCreateParameters sqoopJobCreateParameters)
        {
            this.PrepareQueryJob(sqoopJobCreateParameters);
            return this.CreateSqoopJobAsync(sqoopJobCreateParameters).WaitForResult();
        }

        public Task<JobCreationResults> CreateSqoopJobAsync(SqoopJobCreateParameters sqoopJobCreateParameters)
        {
            if (sqoopJobCreateParameters == null)
            {
                throw new ArgumentNullException("sqoopJobCreateParameters");
            }

            this.PrepareQueryJob(sqoopJobCreateParameters);
            JobCreationResults retval =
                this.CreateJobSuccessResult(
                    new JobDetails { Query = sqoopJobCreateParameters.Command, StatusDirectory = sqoopJobCreateParameters.StatusFolder }, string.Empty);
            return TaskEx2.FromResult(retval);
        }

        public JobCreationResults CreateStreamingJob(StreamingMapReduceJobCreateParameters streamingMapReduceJobCreateParameters)
        {
            return this.CreateStreamingJobAsync(streamingMapReduceJobCreateParameters).WaitForResult();
        }

        public Task<JobCreationResults> CreateStreamingJobAsync(StreamingMapReduceJobCreateParameters streamingMapReduceJobCreateParameters)
        {
            if (streamingMapReduceJobCreateParameters == null)
            {
                throw new ArgumentNullException("streamingMapReduceJobCreateParameters");
            }

            return
                TaskEx2.FromResult(this.CreateJobSuccessResult(streamingMapReduceJobCreateParameters, streamingMapReduceJobCreateParameters.JobName));
        }

        public void DownloadJobTaskLogs(string jobId, string targetDirectory)
        {
            this.DownloadJobTaskLogsAsync(jobId, targetDirectory).WaitForResult();
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Needed to implement interface")]
        public Task DownloadJobTaskLogsAsync(string jobId, string targetDirectory)
        {
            if (this.taskLogAttempts.ContainsKey(jobId))
            {
                if (!Directory.Exists(targetDirectory))
                {
                    Directory.CreateDirectory(targetDirectory);
                }
                foreach (string file in this.taskLogAttempts[jobId])
                {
                    File.Create(Path.Combine(targetDirectory, file));
                }
            }
            else
            {
                throw new InvalidOperationException("Job with id " + jobId + " does not exist.");
            }

            return TaskEx2.FromResult("");
        }

        public JobDetails GetJob(string jobId)
        {
            return this.GetJobAsync(jobId).WaitForResult();
        }

        public Task<JobDetails> GetJobAsync(string jobId)
        {
            this.LogMessage("Getting jobDetails '{0}'.", jobId);
            lock (this.cluster.JobQueue)
            {
                if (this.cluster.JobQueue.ContainsKey(jobId))
                {
                    JobList jobHistory = this.ListJobs();
                    JobDetails jobHistoryItem = jobHistory.Jobs.FirstOrDefault(job => job.JobId == jobId);
                    if (jobHistoryItem != null)
                    {
                        if (jobHistoryItem.Name.IsNotNull() && jobHistoryItem.Name.IndexOf("timeout", StringComparison.OrdinalIgnoreCase) > -1)
                        {
                            Thread.Sleep(50);
                        }
                        return TaskEx2.FromResult(jobHistoryItem);
                    }
                }
            }

            return TaskEx2.FromResult<JobDetails>(null);
        }

        public Stream GetJobErrorLogs(string jobId)
        {
            return this.GetJobErrorLogsAsync(jobId).WaitForResult();
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Needed to implement interface")]
        public Task<Stream> GetJobErrorLogsAsync(string jobId)
        {
            Stream resultStream = new MemoryStream();
            if (this.jobError.ContainsKey(jobId))
            {
                resultStream = GetStream(this.jobError[jobId]);
            }

            return TaskEx2.FromResult(resultStream);
        }

        public Stream GetJobOutput(string jobId)
        {
            return this.GetJobOutputAsync(jobId).WaitForResult();
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Needed to implement interface")]
        public Task<Stream> GetJobOutputAsync(string jobId)
        {
            Stream resultStream = new MemoryStream();
            if (this.jobOutput.ContainsKey(jobId))
            {
                resultStream = GetStream(this.jobOutput[jobId]);
            }

            return TaskEx2.FromResult(resultStream);
        }

        public Stream GetJobTaskLogSummary(string jobId)
        {
            return this.GetJobTaskLogSummaryAsync(jobId).WaitForResult();
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Needed to implement interface")]
        public Task<Stream> GetJobTaskLogSummaryAsync(string jobId)
        {
            Stream resultStream = new MemoryStream();
            if (this.taskLogs.ContainsKey(jobId))
            {
                resultStream = GetStream(this.taskLogs[jobId]);
            }

            return TaskEx2.FromResult(resultStream);
        }

        public void HandleClusterWaitNotifyEvent(JobDetails jobDetails)
        {
            EventHandler<WaitJobStatusEventArgs> handler = this.JobStatusEvent;
            if (handler.IsNotNull())
            {
                handler(this, new WaitJobStatusEventArgs(jobDetails));
            }
        }

        public JobList ListJobs()
        {
            return this.ListJobsAsync().WaitForResult();
        }

        public Task<JobList> ListJobsAsync()
        {
            this.LogMessage("Listing jobs");
            var jobDetailList = new JobList();
            var changedJobs = new List<JobDetails>();
            lock (this.cluster.JobQueue)
            {
                foreach (JobDetails jobHistoryItem in this.cluster.JobQueue.Values)
                {
                    JobDetails changedJob = this.ChangeJobState(jobHistoryItem);
                    jobDetailList.Jobs.Add(changedJob);
                    changedJobs.Add(changedJob);
                }

                foreach (JobDetails changedJob in changedJobs)
                {
                    this.cluster.JobQueue[changedJob.JobId] = changedJob;
                }
            }

            return TaskEx2.FromResult(jobDetailList);
        }

        public new void SetCancellationSource(CancellationTokenSource tokenSource)
        {
            this.cancellationTokenSource = tokenSource;
        }

        public new bool IgnoreSslErrors { get; set; }

        public JobDetails StopJob(string jobId)
        {
            return this.StopJobAsync(jobId).WaitForResult();
        }

        public Task<JobDetails> StopJobAsync(string jobId)
        {
            JobDetails jobToStop = this.GetJob(jobId);
            lock (this.cluster.JobDeletionQueue)
            {
                this.cluster.JobDeletionQueue.Add(jobId, DateTime.Now.AddSeconds(0.5));
            }

            return TaskEx2.FromResult(jobToStop);
        }

        private static Stream GetStream(string contents)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(contents);
            return new MemoryStream(bytes);
        }

        private JobDetails ChangeJobState(JobDetails jobDetailsHistoryItem)
        {
            if (jobDetailsHistoryItem.StatusCode == JobStatusCode.Unknown)
            {
                jobDetailsHistoryItem.StatusCode = JobStatusCode.Initializing;
            }
            else
            {
                switch (jobDetailsHistoryItem.StatusCode)
                {
                    case JobStatusCode.Initializing:
                        jobDetailsHistoryItem.StatusCode = JobStatusCode.Running;
                        jobDetailsHistoryItem.PercentComplete = "map 5% reduce 0%";
                        break;
                    case JobStatusCode.Running:
                        jobDetailsHistoryItem.StatusCode = JobStatusCode.Completed;
                        jobDetailsHistoryItem.PercentComplete = "map 100% reduce 100%";
                        jobDetailsHistoryItem.ExitCode = 0;
                        if ((jobDetailsHistoryItem.Name.IsNotNullOrEmpty() &&
                             string.Equals(jobDetailsHistoryItem.Name, "show tables", StringComparison.OrdinalIgnoreCase)) ||
                            string.Equals(jobDetailsHistoryItem.Query, "show tables", StringComparison.OrdinalIgnoreCase))
                        {
                            this.WriteJobOutput(jobDetailsHistoryItem.JobId, jobDetailsHistoryItem.StatusDirectory, "hivesampletable");
                            this.WriteJobError(jobDetailsHistoryItem.JobId, jobDetailsHistoryItem.StatusDirectory, JobSuccesful);
                        }
                        else if (jobDetailsHistoryItem.Name.IsNotNullOrEmpty() &&
                                 string.Equals(jobDetailsHistoryItem.Name, "pi estimation job", StringComparison.OrdinalIgnoreCase))
                        {
                            this.WriteJobOutput(jobDetailsHistoryItem.JobId, jobDetailsHistoryItem.StatusDirectory, "3.142");
                            this.WriteJobError(jobDetailsHistoryItem.JobId, jobDetailsHistoryItem.StatusDirectory, JobSuccesful);
                        }
                        else
                        {
                            this.WriteJobOutput(jobDetailsHistoryItem.JobId, jobDetailsHistoryItem.StatusDirectory, JobSuccesful);
                            this.WriteJobError(jobDetailsHistoryItem.JobId, jobDetailsHistoryItem.StatusDirectory, JobSuccesful);
                        }

                        this.WriteJobLogSummary(jobDetailsHistoryItem.StatusDirectory, jobDetailsHistoryItem.JobId);
                        break;
                }
            }

            KeyValuePair<string, DateTime> jobDeletionTime =
                this.cluster.JobDeletionQueue.FirstOrDefault(deletedJob => deletedJob.Key == jobDetailsHistoryItem.JobId);
            if (jobDeletionTime.Value != DateTime.MinValue && jobDeletionTime.Value != DateTime.MaxValue && jobDeletionTime.Value <= DateTime.Now)
            {
                jobDetailsHistoryItem.StatusCode = JobStatusCode.Canceled;
            }
            else
            {
                if (this.ShouldFail(jobDetailsHistoryItem))
                {
                    if (jobDetailsHistoryItem.StatusCode == JobStatusCode.Running)
                    {
                        jobDetailsHistoryItem.StatusCode = JobStatusCode.Failed;
                        jobDetailsHistoryItem.ExitCode = 4000;
                        this.WriteJobOutput(jobDetailsHistoryItem.JobId, jobDetailsHistoryItem.StatusDirectory, JobFailed);
                        this.WriteJobError(jobDetailsHistoryItem.JobId, jobDetailsHistoryItem.StatusDirectory, JobFailed);
                    }
                }
                else if (jobDetailsHistoryItem.Name.IsNotNullOrEmpty() && jobDetailsHistoryItem.Name.Contains("Unknown"))
                {
                    if (jobDetailsHistoryItem.StatusCode == JobStatusCode.Running)
                    {
                        jobDetailsHistoryItem.StatusCode = JobStatusCode.Unknown;
                    }
                }
            }

            return jobDetailsHistoryItem;
        }

        private JobCreationResults CreateJobSuccessResult(JobCreateParameters details, string jobName)
        {
            return this.CreateJobSuccessResult(new JobDetails { StatusDirectory = details.StatusFolder }, jobName);
        }

        private JobCreationResults CreateJobSuccessResult(JobDetails jobDetailsHistoryEntry, string jobName)
        {
            if (this.cluster.IsNull())
            {
                throw new InvalidOperationException("The cluster could not be found.");
            }

            //if (this.credentials.UserName != this.cluster.Cluster.HttpUserName && this.credentials.Password != this.cluster.Cluster.HttpPassword)
            //{
            //    throw new UnauthorizedAccessException("The supplied credential do not have access to the server.");
            //}
            lock (this.cluster.JobQueue)
            {
                this.LogMessage("Starting jobDetails '{0}'.", jobName);
                var jobCreationResults = new JobCreationResults { JobId = "job_" + Guid.NewGuid().ToString(), HttpStatusCode = HttpStatusCode.OK };

                jobDetailsHistoryEntry.Name = jobName;
                jobDetailsHistoryEntry.JobId = jobCreationResults.JobId;
                jobDetailsHistoryEntry.PercentComplete = "map 0% reduce 0%";
                this.cluster.JobQueue.Add(jobDetailsHistoryEntry.JobId, jobDetailsHistoryEntry);

                return jobCreationResults;
            }
        }

        private void InitializeSimulator()
        {
            if (this.cluster.IsNull())
            {
                throw new InvalidOperationException("Cluster is not set to a valid instance.");
            }

            JobCreationResults piJob =
                this.CreateMapReduceJob(
                    new MapReduceJobCreateParameters
                    {
                        ClassName = "pi",
                        JarFile = "wasb://containerName@hostname/jarfileName",
                        JobName = "pi estimation jobDetails",
                        StatusFolder = "/pioutput"
                    });

            JobCreationResults hiveJob =
                this.CreateHiveJob(
                    new HiveJobCreateParameters { JobName = "show tables jobDetails", Query = "show tables", StatusFolder = "/hiveoutput" });

            JobCreationResults pigJob = this.CreatePigJob(new PigJobCreateParameters { Query = "show tables", StatusFolder = "/pigoutput" });

            this.WriteJobOutput(piJob.JobId, "/pioutput", JobSuccesful);
            this.WriteJobOutput(hiveJob.JobId, "/hiveoutput", "hivesampletable");
            this.WriteJobOutput(pigJob.JobId, "/pigoutput", JobSuccesful);

            this.WriteJobError(piJob.JobId, "/pioutput", JobSuccesful);
            this.WriteJobError(hiveJob.JobId, "/hiveoutput", JobSuccesful);
            this.WriteJobError(pigJob.JobId, "/pigoutput", JobSuccesful);

            this.WriteJobLogSummary("/pioutput", piJob.JobId);
            this.WriteJobLogSummary("/hiveoutput", hiveJob.JobId);
            this.WriteJobLogSummary("/pigoutput", pigJob.JobId);
        }

        private void LogMessage(string content, params string[] args)
        {
            string message = content;
            if (args.Any())
            {
                message = string.Format(CultureInfo.InvariantCulture, content, args);
            }

            this.logger.LogMessage(message, Severity.Informational, Verbosity.Diagnostic);
        }

        private bool ShouldFail(JobDetails jobDetailsHistoryItem)
        {
            if (jobDetailsHistoryItem.Name.IsNotNullOrEmpty() && jobDetailsHistoryItem.Name.Contains("Fail"))
            {
                return true;
            }

            return jobDetailsHistoryItem.Query.IsNotNullOrEmpty() && jobDetailsHistoryItem.Query.Contains("Fail");
        }

        private void WriteJobError(string jobId, string statusDirectory, string stdErrContent)
        {
            this.jobError[jobId] = stdErrContent;
        }

        private void WriteJobLogSummary(string statusDirectory, string jobId)
        {
            this.taskLogs[jobId] = jobId + " ran on this server.";
            var taskLogAttemptFiles = new List<string>();
            taskLogAttemptFiles.Add("attempt_" + jobId + "_0");
            taskLogAttemptFiles.Add("attempt_" + jobId + "_1");
            taskLogAttemptFiles.Add("attempt_" + jobId + "_2");
            this.taskLogAttempts[jobId] = taskLogAttemptFiles;
        }

        private void WriteJobOutput(string jobId, string statusDirectory, string stdoutContent)
        {
            this.jobOutput[jobId] = stdoutContent;
        }

        public new ILogger Logger { get; private set; }
    }
}
