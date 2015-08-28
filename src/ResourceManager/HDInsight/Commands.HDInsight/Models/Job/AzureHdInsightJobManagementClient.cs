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
using System.Threading.Tasks;
using Hyak.Common;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Management.HDInsight.Job;
using Microsoft.Azure.Management.HDInsight.Job.Models;

namespace Microsoft.Azure.Commands.HDInsight.Models
{
    public class AzureHdInsightJobManagementClient
    {
        public AzureHdInsightJobManagementClient(string clusterName, BasicAuthenticationCloudCredentials credential)
        {
            HdInsightJobManagementClient = AzureSession.ClientFactory.CreateCustomClient<HDInsightJobManagementClient>(clusterName, credential);
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
                Arguments = ConvertListToString(hiveJobDef.Arguments, "arg"),
                Defines = ConvertDefinesToString(hiveJobDef.Defines),
                File = hiveJobDef.File,
                Files = ConvertListToString(hiveJobDef.Files, "file"),
                Query = hiveJobDef.Query,
                StatusDir = hiveJobDef.StatusFolder,
                UserName = HdInsightJobManagementClient.Credentials.Username
            };
            return HdInsightJobManagementClient.JobManagement.SubmitHiveJob(hiveJobParams);
        }

        public virtual JobSubmissionResponse SubmitMRJob(AzureHDInsightMapReduceJobDefinition mapredJobDef)
        {
            var mapredJobParams = new MapReduceJobSubmissionParameters
            {
                Arguments = ConvertListToString(mapredJobDef.Arguments, "arg"),
                Defines = ConvertDefinesToString(mapredJobDef.Defines),
                Files = ConvertListToString(mapredJobDef.Files, "file"),
                JarClass = mapredJobDef.ClassName,
                LibJars = ConvertListToString(mapredJobDef.LibJars, "jar"),
                JarFile = mapredJobDef.JarFile,
                StatusDir = mapredJobDef.StatusFolder,
                UserName = HdInsightJobManagementClient.Credentials.Username
            };

            return HdInsightJobManagementClient.JobManagement.SubmitMapReduceJob(mapredJobParams);
        }

        public virtual JobSubmissionResponse SubmitPigJob(AzureHDInsightPigJobDefinition pigJobDef)
        {
            var pigJobParams = new PigJobSubmissionParameters
            {
                Arguments = ConvertListToString(pigJobDef.Arguments, "arg"),
                Files = ConvertListToString(pigJobDef.Files, "file"),
                StatusDir = pigJobDef.StatusFolder,
                File = pigJobDef.File,
                Query = pigJobDef.Query,
                UserName = HdInsightJobManagementClient.Credentials.Username
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
                Defines = ConvertDefinesToString(streamingJobDef.Defines),
                CmdEnv = ConvertListToString(streamingJobDef.CommandEnvironment, "cmdenv"),
                Arguments = ConvertListToString(streamingJobDef.Arguments, "arg"),
                StatusDir = streamingJobDef.StatusFolder,
                UserName = HdInsightJobManagementClient.Credentials.Username
            };

            return HdInsightJobManagementClient.JobManagement.SubmitMapReduceStreamingJob(streamingJobParams);
        }

        public virtual JobGetResponse GetJob(string jobId)
        {
            return HdInsightJobManagementClient.JobManagement.GetJob(jobId);
        }

        public virtual JobListResponse ListJobs()
        {
            return HdInsightJobManagementClient.JobManagement.ListJobs();
        }

        public void StopJob(string jobId)
        {
            HdInsightJobManagementClient.JobManagement.KillJob(jobId);
        }

        public Stream GetJobOutput(string jobid, string storageAccountName, string storageAccountKey, string containerName)
        {
            var joboutput = HdInsightJobManagementClient.JobManagement.GetJobOutput(jobid, storageAccountName, storageAccountKey, containerName);
            return joboutput;
        }

        public Stream GetJobError(string jobid, string storageAccountName, string storageAccountKey, string containerName)
        {
            var joboutput = HdInsightJobManagementClient.JobManagement.GetJobErrorLogs(jobid, storageAccountName, storageAccountKey, containerName);
            return joboutput;
        }

        public static string ConvertDefinesToString(IDictionary<string, string> defines)
        {
            return defines.Count == 0 ? null : string.Format("&define={0}", string.Join("&define=", defines.Select(x => x.Key + "%3D" + x.Value).ToArray()));
        }

        public static string ConvertListToString(IList<string> list, string argtype)
        {
            var prefix = "&" + argtype + "=";
            return list.Count == 0 ? null : string.Join(prefix, list.ToArray());
        }
    }
}
