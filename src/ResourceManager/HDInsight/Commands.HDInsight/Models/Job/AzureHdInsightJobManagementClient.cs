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
using System.IO;
using System.Linq;
using Hyak.Common;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Management.HDInsight.Job;
using Microsoft.Azure.Management.HDInsight.Job.Models;

namespace Microsoft.Azure.Commands.HDInsight.Models
{
    public class AzureHdInsightJobManagementClient
    {
        public AzureHdInsightJobManagementClient(string clusterName, BasicAuthenticationCloudCredentials credential)
        {
            HdInsightJobManagementClient = AzureSession.ClientFactory.CreateCustomClient<HDInsightJobManagementClient>(clusterName, credential, HDInsightJobManagementClient.HDInsightRetryPolicy);
        }

        /// <summary>
        /// Parameterless constructor for mocking
        /// </summary>
        public AzureHdInsightJobManagementClient() { }

        private IHDInsightJobManagementClient HdInsightJobManagementClient { get; set; }

        public string ClusterName { get { return HdInsightJobManagementClient.ClusterDnsName; } }

        public virtual JobSubmissionResponse SubmitHiveJob(AzureHDInsightHiveJobDefinition hiveJobDef)
        {
            var hiveJobParams = new HiveJobSubmissionParameters
            {
                Arguments = hiveJobDef.Arguments,
                Defines = hiveJobDef.Defines,
                File = hiveJobDef.File,
                Files = hiveJobDef.Files,
                Query = hiveJobDef.Query,
                StatusDir = hiveJobDef.StatusFolder
            };
            return HdInsightJobManagementClient.JobManagement.SubmitHiveJob(hiveJobParams);
        }

        public virtual JobSubmissionResponse SubmitMRJob(AzureHDInsightMapReduceJobDefinition mapredJobDef)
        {
            var mapredJobParams = new MapReduceJobSubmissionParameters
            {
                Arguments = mapredJobDef.Arguments,
                Defines = mapredJobDef.Defines,
                Files = mapredJobDef.Files,
                JarClass = mapredJobDef.ClassName,
                LibJars = mapredJobDef.LibJars,
                JarFile = mapredJobDef.JarFile,
                StatusDir = mapredJobDef.StatusFolder
            };

            return HdInsightJobManagementClient.JobManagement.SubmitMapReduceJob(mapredJobParams);
        }

        public virtual JobSubmissionResponse SubmitPigJob(AzureHDInsightPigJobDefinition pigJobDef)
        {
            var pigJobParams = new PigJobSubmissionParameters
            {
                Arguments = pigJobDef.Arguments,
                Files = pigJobDef.Files,
                StatusDir = pigJobDef.StatusFolder,
                File = pigJobDef.File,
                Query = pigJobDef.Query
            };

            return HdInsightJobManagementClient.JobManagement.SubmitPigJob(pigJobParams);
        }

        public virtual JobSubmissionResponse SubmitStreamingJob(
            AzureHDInsightStreamingMapReduceJobDefinition streamingJobDef)
        {
            var streamingJobParams = new MapReduceStreamingJobSubmissionParameters
            {
                Input = streamingJobDef.Input,
                Output = streamingJobDef.Output,
                Mapper = streamingJobDef.Mapper,
                Reducer = streamingJobDef.Reducer,
                File = streamingJobDef.File,
                Files = streamingJobDef.Files,
                Defines = streamingJobDef.Defines,
                CmdEnv = streamingJobDef.CommandEnvironment,
                Arguments = streamingJobDef.Arguments,
                StatusDir = streamingJobDef.StatusFolder
            };

            return HdInsightJobManagementClient.JobManagement.SubmitMapReduceStreamingJob(streamingJobParams);
        }

        public virtual JobSubmissionResponse SubmitSqoopJob(AzureHDInsightSqoopJobDefinition sqoopJobDef)
        {
            var sqoopJobParams = new SqoopJobSubmissionParameters
            {
                Command = sqoopJobDef.Command,
                File = sqoopJobDef.File,
                Files = sqoopJobDef.Files,
                LibDir = sqoopJobDef.LibDir,
                StatusDir = sqoopJobDef.StatusFolder
            };
            return HdInsightJobManagementClient.JobManagement.SubmitSqoopJob(sqoopJobParams);
        }

        public virtual JobGetResponse GetJob(string jobId)
        {
            return HdInsightJobManagementClient.JobManagement.GetJob(jobId);
        }

        public virtual JobGetResponse WaitForJobCompletion(string jobId, TimeSpan? duration = null, TimeSpan? waitInterval = null)
        {
            return HdInsightJobManagementClient.JobManagement.WaitForJobCompletion(jobId, duration, waitInterval);
        }

        public virtual JobListResponse ListJobs()
        {
            return HdInsightJobManagementClient.JobManagement.ListJobs();
        }

        public virtual JobListResponse ListJobsAfterJobId(string jobId, int numberOfJobs)
        {
            return HdInsightJobManagementClient.JobManagement.ListJobsAfterJobId(jobId, numberOfJobs);
        }

        public void StopJob(string jobId)
        {
            HdInsightJobManagementClient.JobManagement.KillJob(jobId);
        }

        public Stream GetJobOutput(string jobid, IStorageAccess storageAccess)
        {
            var joboutput = HdInsightJobManagementClient.JobManagement.GetJobOutput(jobid, storageAccess);
            return joboutput;
        }

        public Stream GetJobError(string jobid, IStorageAccess storageAccess)
        {
            var joboutput = HdInsightJobManagementClient.JobManagement.GetJobErrorLogs(jobid, storageAccess);
            return joboutput;
        }
    }
}
