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

using System.Collections.Generic;
using System.Management.Automation;
using System.Net;
using Microsoft.Azure.Commands.HDInsight.Models;
using Microsoft.Azure.Management.HDInsight.Job.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using Xunit;

namespace Microsoft.Azure.Commands.HDInsight.Test
{
    public class JobTests : HDInsightTestBase
    {
        public JobTests()
        {
            base.SetupTestsForData();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateHiveJob()
        {
            var args = new[] {"arg1", "arg2"};
            var defines = new Dictionary<string, string>
                {
                    {"hive.1", "val1"},
                    {"hive.2", "val2"}
                };
            const string query = "show tables;";
            const string name = "hivejob";
            const string file = "file";
            const string status = "folder";
            var files = new[] {"file1", "file2"};
            var cmdlet = new NewAzureHDInsightHiveJobDefinitionCommand
            {
                CommandRuntime = commandRuntimeMock.Object,
                HDInsightJobClient = hdinsightJobManagementMock.Object,
                Arguments = args,
                JobName = name,
                Query = query,
                File = file,
                Files = files,
                RunAsFileJob = false,
                StatusFolder = status
            };
            foreach (var define in defines)
            {
                cmdlet.Defines.Add(define.Key, define.Value);
            }
            cmdlet.ExecuteCmdlet();
            commandRuntimeMock.VerifyAll();
            commandRuntimeMock.Verify(
                f =>
                    f.WriteObject(
                        It.Is<AzureHDInsightHiveJobDefinition>(
                            job =>
                                job.Defines.Count == defines.Count && job.Query == query && job.JobName == name &&
                                job.RunAsFileJob == false && job.File == file && job.Files.Count == files.Length &&
                                job.StatusFolder == status)));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreatePigJob()
        {
            var args = new[] { "arg1", "arg2" };
            const string file = "file";
            const string status = "folder";
            const string query = "pigquery";
            var files = new[] {"file1", "file2"};
            var cmdlet = new NewAzureHDInsightPigJobDefinitionCommand
            {
                CommandRuntime = commandRuntimeMock.Object,
                HDInsightJobClient = hdinsightJobManagementMock.Object,
                Arguments = args,
                Query = query,
                File = file,
                Files = files,
                StatusFolder = status
            };

            cmdlet.ExecuteCmdlet();
            commandRuntimeMock.VerifyAll();
            commandRuntimeMock.Verify(
                f =>
                    f.WriteObject(
                        It.Is<AzureHDInsightPigJobDefinition>(
                            job =>
                                job.Query == query && job.Arguments.Count == args.Length &&
                                job.Files.Count == files.Length && job.File == file && job.StatusFolder == status)));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateMRJob()
        {
            var args = new[] { "arg1", "arg2" };
            var defines = new Dictionary<string, string>
                {
                    {"hive.1", "val1"},
                    {"hive.2", "val2"}
                };
            const string name = "mrjob";
            const string status = "folder";
            const string classname = "class";
            const string jar = "jar";
            var jars = new[] {"jar1"};
            var files = new[] { "file1", "file2" };
            var cmdlet = new NewAzureHDInsightMapReduceJobDefinitionCommand
            {
                CommandRuntime = commandRuntimeMock.Object,
                HDInsightJobClient = hdinsightJobManagementMock.Object,
                Arguments = args,
                Files = files,
                JobName = name,
                ClassName = classname,
                JarFile = jar,
                LibJars = jars,
                StatusFolder = status
            };
            foreach (var define in defines)
            {
                cmdlet.Defines.Add(define.Key, define.Value);
            }

            cmdlet.ExecuteCmdlet();
            commandRuntimeMock.VerifyAll();
            commandRuntimeMock.Verify(
                f =>
                    f.WriteObject(
                        It.Is<AzureHDInsightMapReduceJobDefinition>(
                            job =>
                                job.Arguments.Count == args.Length && job.Files.Count == files.Length &&
                                job.JobName == name && job.ClassName == classname && job.JarFile == jar &&
                                job.LibJars.Count == jars.Length && job.StatusFolder == status)));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateStreamingJob()
        {
            var args = new[] { "arg1", "arg2" };
            var defines = new Dictionary<string, string>
                {
                    {"hive.1", "val1"},
                    {"hive.2", "val2"}
                };
            const string status = "folder";
            const string inputpath = "input";
            const string outputpath = "output";
            const string mapper = "mapper.exe";
            const string reducer = "reducer.exe";
            const string file = "file";
            var cmdlet = new NewAzureHDInsightStreamingMapReduceJobDefinitionCommand
            {
                CommandRuntime = commandRuntimeMock.Object,
                HDInsightJobClient = hdinsightJobManagementMock.Object,
                Arguments = args,
                File = file,
                StatusFolder = status,
                InputPath = inputpath,
                OutputPath = outputpath,
                Mapper = mapper,
                Reducer = reducer
            };
            foreach (var define in defines)
            {
                cmdlet.Defines.Add(define.Key, define.Value);
            }

            cmdlet.ExecuteCmdlet();
            commandRuntimeMock.VerifyAll();
            commandRuntimeMock.Verify(
                f =>
                    f.WriteObject(
                        It.Is<AzureHDInsightStreamingMapReduceJobDefinition>(
                            job =>
                                job.Arguments.Count == args.Length && job.File == file && job.StatusFolder == status &&
                                job.Input == inputpath && job.Output == outputpath && job.Mapper == mapper &&
                                job.Reducer == reducer && job.Defines.Count == defines.Count)));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void StartJob()
        {
            var cmdlet = new StartAzureHDInsightJobCommand
            {
                CommandRuntime = commandRuntimeMock.Object,
                HDInsightJobClient = hdinsightJobManagementMock.Object,
                ClusterCredential = new PSCredential("httpuser", string.Format("Password1!").ConvertToSecureString()),
                ClusterName = ClusterName
            };

            var args = new[] {"arg1", "arg2"};
            const string query = "show tables;";
            const string name = "hivejob";
            var hivedef = new AzureHDInsightHiveJobDefinition
            {
                JobName = name,
                Query = query,
            };
            foreach (var arg in args)
            {
                hivedef.Arguments.Add(arg);
            }

            cmdlet.JobDefinition = hivedef;

            const string jobid = "jobid_1984120_001";
            var jobsub = new JobSubmissionResponse
            {
                JobSubmissionJsonResponse = new JobSubmissionJsonResponse
                {
                    Id = jobid
                },
                StatusCode = HttpStatusCode.OK
            };
            hdinsightJobManagementMock.Setup(
                c =>
                    c.SubmitHiveJob(
                        It.Is<AzureHDInsightHiveJobDefinition>(
                            def => def.JobName == name && def.Query == query && def.Arguments.Count == args.Length)))
                .Returns(jobsub)
                .Verifiable();

            var getresponse = new JobGetResponse
            {
                StatusCode = HttpStatusCode.OK,
                JobDetail = new JobDetailRootJsonObject
                {
                    Completed = "false",
                    User = cmdlet.ClusterCredential.UserName,
                    Id = jobid
                }
            };
            hdinsightJobManagementMock.Setup(c => c.GetJob(jobsub.JobSubmissionJsonResponse.Id)).Returns(getresponse).Verifiable();

            cmdlet.ExecuteCmdlet();
            commandRuntimeMock.VerifyAll();
            commandRuntimeMock.Verify(
                f =>
                    f.WriteObject(
                        It.Is<AzureHDInsightJob>(
                            job => job.Cluster == ClusterName && job.JobId == jobid && job.Completed == "false")));
        }
    }
}
