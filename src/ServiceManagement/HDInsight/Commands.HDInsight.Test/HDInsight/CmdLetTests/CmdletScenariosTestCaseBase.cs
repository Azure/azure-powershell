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
using System.Linq;
using System.Management.Automation;
using Microsoft.Hadoop.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.PowerShellTestAbstraction.Interfaces;
using Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.Simulators;
using Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.Utilities;
using Microsoft.WindowsAzure.Management.HDInsight;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;

namespace Microsoft.WindowsAzure.Commands.Test.HDInsight.CmdLetTests
{
    [TestClass]
    public class CmdletScenariosTestCaseBase : HDInsightTestCaseBase
    {
        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Jobs")]
        public virtual void NewHiveJob_StartJob_GetJob()
        {
            var hiveJobDefinition = new HiveJobCreateParameters { JobName = "show tables", Query = "show tables" };

            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                ClusterDetails testCluster = GetHttpAccessEnabledCluster();
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightHiveJobDefinition)
                            .WithParameter(CmdletConstants.JobName, hiveJobDefinition.JobName)
                            .WithParameter(CmdletConstants.Query, hiveJobDefinition.Query)
                            .AddCommand(CmdletConstants.StartAzureHDInsightJob)
                            .WithParameter(CmdletConstants.Cluster, testCluster.Name)
                            .AddCommand(CmdletConstants.WaitAzureHDInsightJob)
                            .WithParameter(CmdletConstants.WaitTimeoutInSeconds, 10)
                            .AddCommand(CmdletConstants.GetAzureHDInsightJobOutput)
                            .WithParameter(CmdletConstants.Cluster, testCluster.Name)
                            .Invoke();

                Assert.IsNotNull(results.Results.ToEnumerable<string>());
                Assert.IsTrue(results.Results.ToEnumerable<string>().Any(str => str == "hivesampletable"));
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Jobs")]
        public virtual void NewMapReduceJob_StartJob_GetJob()
        {
            var mapReduceJobDefinition = new MapReduceJobCreateParameters
            {
                JobName = "pi estimation jobDetails",
                ClassName = "pi",
                JarFile = "/example/hadoop-examples.jar"
            };

            mapReduceJobDefinition.Arguments.Add("16");
            mapReduceJobDefinition.Arguments.Add("10000");

            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightMapReduceJobDefinition)
                            .WithParameter(CmdletConstants.JobName, mapReduceJobDefinition.JobName)
                            .WithParameter(CmdletConstants.JarFile, mapReduceJobDefinition.JarFile)
                            .WithParameter(CmdletConstants.ClassName, mapReduceJobDefinition.ClassName)
                            .WithParameter(CmdletConstants.Arguments, mapReduceJobDefinition.Arguments)
                            .Invoke();
                Assert.AreEqual(1, results.Results.Count);
                AzureHDInsightMapReduceJobDefinition mapReduceJobFromPowershell =
                    results.Results.ToEnumerable<AzureHDInsightMapReduceJobDefinition>().First();
                RunJobAndGetWithId(runspace, mapReduceJobFromPowershell);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Jobs")]
        public virtual void NewPigJob_StartJob_GetJob()
        {
            var pigJobDefinition = new PigJobCreateParameters { Query = "load 'passwd' using PigStorage(':'); B = foreach A generate $0 as id;" };

            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightPigJobDefinition)
                            .WithParameter(CmdletConstants.Query, pigJobDefinition.Query)
                            .Invoke();
                Assert.AreEqual(1, results.Results.Count);
                AzureHDInsightPigJobDefinition pigJobFromPowershell = results.Results.ToEnumerable<AzureHDInsightPigJobDefinition>().First();
                AzureHDInsightJob pigJobfromHistory = RunJobAndGetWithId(runspace, pigJobFromPowershell);
                Assert.AreEqual(pigJobfromHistory.Query, pigJobDefinition.Query, "Failed to retrieve query for executed pig jobDetails");
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Jobs")]
        public virtual void NewStreamingJob_StartJob_GetJob()
        {
            var streamingMapReduceJobDefinition = new StreamingMapReduceJobCreateParameters
            {
                JobName = "pi estimation jobDetails",
                Input = TestConstants.WabsProtocolSchemeName + "input",
                Output = TestConstants.WabsProtocolSchemeName + "input",
                Mapper = TestConstants.WabsProtocolSchemeName + "combiner",
                Reducer = TestConstants.WabsProtocolSchemeName + "combiner",
                StatusFolder = TestConstants.WabsProtocolSchemeName + "someotherlocation"
            };

            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightStreamingMapReduceJobDefinition)
                            .WithParameter(CmdletConstants.JobName, streamingMapReduceJobDefinition.JobName)
                            .WithParameter(CmdletConstants.Input, streamingMapReduceJobDefinition.Input)
                            .WithParameter(CmdletConstants.Output, streamingMapReduceJobDefinition.Output)
                            .WithParameter(CmdletConstants.Mapper, streamingMapReduceJobDefinition.Mapper)
                            .WithParameter(CmdletConstants.Reducer, streamingMapReduceJobDefinition.Reducer)
                            .WithParameter(CmdletConstants.StatusFolder, streamingMapReduceJobDefinition.StatusFolder)
                            .Invoke();
                Assert.AreEqual(1, results.Results.Count);
                AzureHDInsightStreamingMapReduceJobDefinition streamingMapReduceJobFromPowershell =
                    results.Results.ToEnumerable<AzureHDInsightStreamingMapReduceJobDefinition>().First();

                RunJobAndGetWithId(runspace, streamingMapReduceJobFromPowershell);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Jobs")]
        public virtual void NewStreamingMapReduceJob_StartJob_GetJob()
        {
            var streamingMapReduceJobDefinition = new StreamingMapReduceJobCreateParameters
            {
                JobName = "environment variable jobDetails",
                Mapper = "environmentvariables.exe",
                Input = "/example/apps/environmentvariables.exe",
                Output = Guid.NewGuid().ToString()
            };

            var files = new List<string> { streamingMapReduceJobDefinition.Mapper };
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightStreamingMapReduceJobDefinition)
                            .WithParameter(CmdletConstants.JobName, streamingMapReduceJobDefinition.JobName)
                            .WithParameter(CmdletConstants.Mapper, streamingMapReduceJobDefinition.Mapper)
                            .WithParameter(CmdletConstants.Input, streamingMapReduceJobDefinition.Input)
                            .WithParameter(CmdletConstants.Output, streamingMapReduceJobDefinition.Output)
                            .WithParameter(CmdletConstants.Files, files)
                            .Invoke();
                Assert.AreEqual(1, results.Results.Count);
                AzureHDInsightStreamingMapReduceJobDefinition streamingMapReduceJobFromPowershell =
                    results.Results.ToEnumerable<AzureHDInsightStreamingMapReduceJobDefinition>().First();
                RunJobAndGetWithId(runspace, streamingMapReduceJobFromPowershell);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Jobs")]
        public virtual void PipeliningHiveJobExecution()
        {
            var hiveJobDefinition = new HiveJobCreateParameters { JobName = "show tables", Query = "show tables" };

            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                ClusterDetails testCluster = GetHttpAccessEnabledCluster();
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightHiveJobDefinition)
                            .WithParameter(CmdletConstants.JobName, hiveJobDefinition.JobName)
                            .WithParameter(CmdletConstants.Query, hiveJobDefinition.Query)
                            .AddCommand(CmdletConstants.StartAzureHDInsightJob)
                            .WithParameter(CmdletConstants.Cluster, testCluster.Name)
                            .AddCommand(CmdletConstants.WaitAzureHDInsightJob)
                            .WithParameter(CmdletConstants.WaitTimeoutInSeconds, 10)
                            .AddCommand(CmdletConstants.GetAzureHDInsightJobOutput)
                            .Invoke();

                Assert.IsNotNull(results.Results.ToEnumerable<string>());
                Assert.IsTrue(results.Results.ToEnumerable<string>().Any(str => str == "hivesampletable"));
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Jobs")]
        public virtual void PipeliningHiveJobExecution_FlowCluster()
        {
            var hiveJobDefinition = new HiveJobCreateParameters { JobName = "show tables", Query = "show tables" };

            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                ClusterDetails testCluster = GetHttpAccessEnabledCluster();
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightHiveJobDefinition)
                            .WithParameter(CmdletConstants.JobName, hiveJobDefinition.JobName)
                            .WithParameter(CmdletConstants.Query, hiveJobDefinition.Query)
                            .AddCommand(CmdletConstants.StartAzureHDInsightJob)
                            .WithParameter(CmdletConstants.Cluster, testCluster.Name)
                            .AddCommand(CmdletConstants.WaitAzureHDInsightJob)
                            .WithParameter(CmdletConstants.WaitTimeoutInSeconds, 10)
                            .AddCommand(CmdletConstants.GetAzureHDInsightJobOutput)
                            .Invoke();

                Assert.IsNotNull(results.Results.ToEnumerable<string>());
                Assert.IsTrue(results.Results.ToEnumerable<string>().Any(str => str == "hivesampletable"));
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Jobs")]
        public virtual void PipeliningHiveJobExecution_Start_GetJob()
        {
            var hiveJobDefinition = new HiveJobCreateParameters { JobName = "show tables", Query = "show tables" };

            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                ClusterDetails testCluster = GetHttpAccessEnabledCluster();
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightHiveJobDefinition)
                            .WithParameter(CmdletConstants.JobName, hiveJobDefinition.JobName)
                            .WithParameter(CmdletConstants.Query, hiveJobDefinition.Query)
                            .AddCommand(CmdletConstants.StartAzureHDInsightJob)
                            .WithParameter(CmdletConstants.Cluster, testCluster.Name)
                            .AddCommand(CmdletConstants.GetAzureHDInsightJob)
                            .Invoke();

                Assert.IsNotNull(results.Results.ToEnumerable<AzureHDInsightJob>());
                Assert.IsTrue(results.Results.ToEnumerable<AzureHDInsightJob>().Any(job => job.Name == "show tables"));
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Jobs")]
        public virtual void PipeliningMapReduceJobExecution()
        {
            var mapReduceJobDefinition = new MapReduceJobCreateParameters
            {
                JobName = "pi estimation job",
                ClassName = "pi",
                JarFile = "/example/hadoop-examples.jar"
            };

            mapReduceJobDefinition.Arguments.Add("16");
            mapReduceJobDefinition.Arguments.Add("10000");

            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                ClusterDetails testCluster = GetHttpAccessEnabledCluster();
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightMapReduceJobDefinition)
                            .WithParameter(CmdletConstants.JobName, mapReduceJobDefinition.JobName)
                            .WithParameter(CmdletConstants.JarFile, mapReduceJobDefinition.JarFile)
                            .WithParameter(CmdletConstants.ClassName, mapReduceJobDefinition.ClassName)
                            .WithParameter(CmdletConstants.Arguments, mapReduceJobDefinition.Arguments)
                            .AddCommand(CmdletConstants.StartAzureHDInsightJob)
                            .WithParameter(CmdletConstants.Cluster, testCluster.Name)
                            .AddCommand(CmdletConstants.WaitAzureHDInsightJob)
                            .WithParameter(CmdletConstants.WaitTimeoutInSeconds, 10)
                            .AddCommand(CmdletConstants.GetAzureHDInsightJobOutput)
                            .WithParameter(CmdletConstants.Cluster, testCluster.Name)
                            .Invoke();

                Assert.IsNotNull(results.Results.ToEnumerable<string>());
                Assert.IsTrue(results.Results.ToEnumerable<string>().Any(str => str == "3.142"));
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Jobs")]
        public virtual void PipeliningStreamingMapReduceJobExecution()
        {
            var streamingMapReduceJobDefinition = new StreamingMapReduceJobCreateParameters
            {
                JobName = "pi estimation job",
                Mapper = "environmentvariables.exe",
                Input = "/example/apps/environmentvariables.exe",
                Output = Guid.NewGuid().ToString()
            };

            var files = new List<string> { streamingMapReduceJobDefinition.Mapper };

            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                ClusterDetails testCluster = GetHttpAccessEnabledCluster();
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightStreamingMapReduceJobDefinition)
                            .WithParameter(CmdletConstants.JobName, streamingMapReduceJobDefinition.JobName)
                            .WithParameter(CmdletConstants.Mapper, streamingMapReduceJobDefinition.Mapper)
                            .WithParameter(CmdletConstants.Input, streamingMapReduceJobDefinition.Input)
                            .WithParameter(CmdletConstants.Output, streamingMapReduceJobDefinition.Output)
                            .WithParameter(CmdletConstants.Files, files)
                            .AddCommand(CmdletConstants.StartAzureHDInsightJob)
                            .WithParameter(CmdletConstants.Cluster, testCluster.Name)
                            .AddCommand(CmdletConstants.WaitAzureHDInsightJob)
                            .WithParameter(CmdletConstants.WaitTimeoutInSeconds, 10)
                            .AddCommand(CmdletConstants.GetAzureHDInsightJobOutput)
                            .WithParameter(CmdletConstants.Cluster, testCluster.Name)
                            .Invoke();

                Assert.IsNotNull(results.Results.ToEnumerable<string>());
                Assert.IsTrue(results.Results.ToEnumerable<string>().Any(str => str == "3.142"));
            }
        }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }

        private static AzureHDInsightJob RunJobAndGetWithId<TJobType>(IRunspace runspace, TJobType jobDefinition)
            where TJobType : AzureHDInsightJobDefinition
        {
            ClusterDetails testCluster = GetHttpAccessEnabledCluster();
            PSCredential testClusterCredentials = GetPSCredential(testCluster.HttpUserName, testCluster.HttpPassword);
            IPipelineResult jobWithIdResults =
                runspace.NewPipeline()
                        .AddCommand(CmdletConstants.StartAzureHDInsightJob)
                        .WithParameter(CmdletConstants.Cluster, testCluster.ConnectionUrl)
                        .WithParameter(CmdletConstants.Credential, testClusterCredentials)
                        .WithParameter(CmdletConstants.JobDefinition, jobDefinition)
                        .AddCommand(CmdletConstants.WaitAzureHDInsightJob)
                        .WithParameter(CmdletConstants.Credential, testClusterCredentials)
                        .Invoke();

            AzureHDInsightJob jobWithId = jobWithIdResults.Results.ToEnumerable<AzureHDInsightJob>().First();
            Assert.AreEqual(jobWithId.State, JobStatusCode.Completed.ToString(), "jobDetails failed.");
            return jobWithId;
        }

        internal static ClusterDetails GetHttpAccessEnabledCluster()
        {
            return AzureHDInsightClusterManagementClientSimulator.GetClusterInternal("HttpAccessCluster").Cluster;
        }

        internal static ClusterDetails GetHttpAccessDisabledCluster()
        {
            return AzureHDInsightClusterManagementClientSimulator.GetClusterInternal("NoHttpAccessCluster").Cluster;
        }
    }
}
