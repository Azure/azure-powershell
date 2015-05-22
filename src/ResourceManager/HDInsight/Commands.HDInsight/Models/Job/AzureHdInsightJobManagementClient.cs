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
using System.Threading.Tasks;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Management.HDInsight.Job;
using Microsoft.Azure.Management.HDInsight.Job.Models;

namespace Microsoft.Azure.Commands.HDInsight.Models
{
    public class AzureHdInsightJobManagementClient
    {
        public AzureHdInsightJobManagementClient(AzureContext context)
        {
            HdInsightJobManagementClient = AzureSession.ClientFactory.CreateClient<HDInsightJobManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
        }

        /// <summary>
        /// Parameterless constructor for mocking
        /// </summary>
        public AzureHdInsightJobManagementClient() { }

        private IHDInsightJobManagementClient HdInsightJobManagementClient { get; set; }

        public string ClusterName { get { return HdInsightJobManagementClient.ClusterDnsName; } }

        public Task<JobSubmissionResponse> SubmitHiveJob(AzureHDInsightHiveJobDefinition hiveJobDef)
        {
            var hiveJobParams = new HiveJobSubmissionParameters
            {
                Arguments = hiveJobDef.Arguments.ToString(),
                Defines = hiveJobDef.Defines.ToString(),
                File = hiveJobDef.File,
                Files = hiveJobDef.Files.ToString(),
                Query = hiveJobDef.Query,
                StatusDir = hiveJobDef.StatusFolder,
                UserName = HdInsightJobManagementClient.Credentials.Username
            };

            return HdInsightJobManagementClient.JobManagement.SubmitHiveJobAsync(hiveJobParams);
        }

        public Task<JobSubmissionResponse> SubmitMRJob(AzureHDInsightMapReduceJobDefinition mapredJobDef)
        {
            var mapredJobParams = new MapReduceJobSubmissionParameters
            {
                Arguments = mapredJobDef.Arguments.ToString(),
                Defines = mapredJobDef.Defines.ToString(),
                Files = mapredJobDef.Files.ToString(),
                JarClass = mapredJobDef.ClassName,
                LibJars = mapredJobDef.LibJars.ToString(),
                JarFile = mapredJobDef.JarFile,
                StatusDir = mapredJobDef.StatusFolder,
                UserName = HdInsightJobManagementClient.Credentials.Username
            };

            return HdInsightJobManagementClient.JobManagement.SubmitMapReduceJobAsync(mapredJobParams);
        }

        public Task<JobSubmissionResponse> SubmitPigJob(AzureHDInsightPigJobDefinition pigJobDef)
        {
            var pigJobParams = new PigJobSubmissionParameters
            {
                Arguments = pigJobDef.Arguments.ToString(),
                Files = pigJobDef.Files.ToString(),
                StatusDir = pigJobDef.StatusFolder,
                File = pigJobDef.File,
                Query = pigJobDef.Query,
                UserName = HdInsightJobManagementClient.Credentials.Username
            };

            return HdInsightJobManagementClient.JobManagement.SubmitPigJobAsync(pigJobParams);
        }

        public Task<JobSubmissionResponse> SubmitSqoopJob(AzureHDInsightSqoopJobDefinition sqoopJobDef)
        {
            throw new NotImplementedException();
        }

        public Task<JobSubmissionResponse> SubmitStreamingJob(
            AzureHDInsightStreamingMapReduceJobDefinition streamingJobDef)
        {
            var streamingJobParams = new MapReduceStreamingJobSubmissionParameters
            {
                Input = streamingJobDef.Input,
                Output = streamingJobDef.Output,
                Mapper = streamingJobDef.Mapper,
                Reducer = streamingJobDef.Reducer,
                File = streamingJobDef.File,
                Defines = streamingJobDef.Defines.ToString(),
                CmdEnv = streamingJobDef.CommandEnvironment.ToString(),
                Arguments = streamingJobDef.Arguments.ToString(),
                StatusDir = streamingJobDef.StatusFolder,
                UserName = HdInsightJobManagementClient.Credentials.Username
            };

            return HdInsightJobManagementClient.JobManagement.SubmitMapReduceStreamingJobAsync(streamingJobParams);
        }

        public Task<JobGetResponse> GetJob(string jobId)
        {
            return HdInsightJobManagementClient.JobManagement.GetJobAsync(jobId);
        }

        public Task<JobListResponse> ListJobs()
        {
            return HdInsightJobManagementClient.JobManagement.ListJobsAsync();
        }

        public Task<JobGetResponse> StopJob(string jobId)
        {
            throw new NotImplementedException();
        }

    }
}
