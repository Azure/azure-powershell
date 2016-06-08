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
using System.Linq;
using Microsoft.Hadoop.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.PowerShellTestAbstraction.Interfaces;
using Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.Simulators;
using Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.Utilities;
using Microsoft.WindowsAzure.Management.HDInsight;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Logging;

namespace Microsoft.WindowsAzure.Commands.Test.HDInsight.CmdLetTests
{
    public class StartJobsCmdletTestCaseBase : HDInsightTestCaseBase
    {
        public virtual void ICanCallThe_NewHiveJob_Then_Start_HDInsightJobsCmdlet()
        {
            var hiveJobDefinition = new HiveJobCreateParameters { JobName = "show tables jobDetails", Query = "show tables" };

            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightHiveJobDefinition)
                            .WithParameter(CmdletConstants.JobName, hiveJobDefinition.JobName)
                            .WithParameter(CmdletConstants.Query, hiveJobDefinition.Query)
                            .Invoke();
                Assert.AreEqual(1, results.Results.Count);
                AzureHDInsightHiveJobDefinition hiveJobFromPowershell = results.Results.ToEnumerable<AzureHDInsightHiveJobDefinition>().First();
                ClusterDetails testCluster = CmdletScenariosTestCaseBase.GetHttpAccessEnabledCluster();
                AzureHDInsightJob jobCreationDetails = RunJobInPowershell(runspace, hiveJobFromPowershell, testCluster);
                AzureHDInsightJob jobHistoryResult = GetJobsCmdletTests.GetJobWithID(runspace, jobCreationDetails.JobId, testCluster);
            }
        }

        public virtual void ICanCallThe_NewMapReduceJob_Then_Start_HDInsightJobsCmdlet()
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

                RunJobInPowershell(runspace, mapReduceJobFromPowershell);
            }
        }

        public virtual void ICanCallThe_NewPigJob_Then_Start_HDInsightJobsCmdlet()
        {
            var pigJobDefinition = new PigJobCreateParameters { Query = "load table from 'A'" };

            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightPigJobDefinition)
                            .WithParameter(CmdletConstants.Query, pigJobDefinition.Query)
                            .Invoke();
                Assert.AreEqual(1, results.Results.Count);
                AzureHDInsightPigJobDefinition pigJobFromPowershell = results.Results.ToEnumerable<AzureHDInsightPigJobDefinition>().First();

                RunJobInPowershell(runspace, pigJobFromPowershell);
            }
        }

        public virtual void ICanCallThe_NewSqoopJob_Then_Start_HDInsightJobsCmdlet()
        {
            var sqoopJobDefinition = new SqoopJobCreateParameters { Command = "load table from 'A'" };

            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightSqoopJobDefinition)
                            .WithParameter(CmdletConstants.Command, sqoopJobDefinition.Command)
                            .Invoke();
                Assert.AreEqual(1, results.Results.Count);
                AzureHDInsightSqoopJobDefinition sqoopJobFromPowershell = results.Results.ToEnumerable<AzureHDInsightSqoopJobDefinition>().First();

                RunJobInPowershell(runspace, sqoopJobFromPowershell);
            }
        }

        public virtual void ICanCallThe_NewStreamingJob_Then_Start_HDInsightJobsCmdlet()
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
                AzureHDInsightStreamingMapReduceJobDefinition streamingJobFromPowershell =
                    results.Results.ToEnumerable<AzureHDInsightStreamingMapReduceJobDefinition>().First();

                RunJobInPowershell(runspace, streamingJobFromPowershell);
            }
        }

        public virtual void ICanCallThe_Start_HDInsightJobsCmdlet()
        {
            var mapReduceJobDefinition = new AzureHDInsightMapReduceJobDefinition
            {
                JobName = "pi estimation jobDetails",
                ClassName = "pi",
                JarFile = TestConstants.WabsProtocolSchemeName + "container@hostname/examples.jar"
            };

            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                RunJobInPowershell(runspace, mapReduceJobDefinition);
            }
        }

        public virtual void ICanCallThe_Start_HDInsightJobsCmdlet_WithoutName()
        {
            var mapReduceJobDefinition = new AzureHDInsightMapReduceJobDefinition
            {
                ClassName = "pi",
                JarFile = TestConstants.WabsProtocolSchemeName + "container@hostname/examples.jar"
            };

            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                RunJobInPowershell(runspace, mapReduceJobDefinition);
            }
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        internal static AzureHDInsightJob RunJobInPowershell(IRunspace runspace, AzureHDInsightJobDefinition mapReduceJobDefinition)
        {
            return RunJobInPowershell(runspace, mapReduceJobDefinition, CmdletScenariosTestCaseBase.GetHttpAccessEnabledCluster());
        }

        internal static AzureHDInsightJob RunJobInPowershell(
            IRunspace runspace, AzureHDInsightJobDefinition mapReduceJobDefinition, ClusterDetails cluster)
        {
            IPipelineResult results =
                runspace.NewPipeline()
                        .AddCommand(CmdletConstants.StartAzureHDInsightJob)
                        .WithParameter(CmdletConstants.Cluster, cluster.ConnectionUrl)
                        .WithParameter(CmdletConstants.Credential, GetPSCredential(cluster.HttpUserName, cluster.HttpPassword))
                        .WithParameter(CmdletConstants.JobDefinition, mapReduceJobDefinition)
                        .Invoke();
            Assert.AreEqual(1, results.Results.Count);
            IEnumerable<AzureHDInsightJob> jobCreationCmdletResults = results.Results.ToEnumerable<AzureHDInsightJob>();
            AzureHDInsightJob jobCreationResults = jobCreationCmdletResults.First();
            Assert.IsNotNull(jobCreationResults.JobId, "Should get a non-null jobDetails id");

            return jobCreationResults;
        }


        internal static AzureHDInsightJob RunJobInPowershell(
            IRunspace runspace, AzureHDInsightJobDefinition mapReduceJobDefinition, ClusterDetails cluster, bool debug, string expectedLogMessage)
        {
            IPipelineResult result = null;
            if (debug)
            {
                var logWriter = new PowershellLogWriter();
                BufferingLogWriterFactory.Instance = logWriter;
                result =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.StartAzureHDInsightJob)
                            .WithParameter(CmdletConstants.Cluster, cluster.ConnectionUrl)
                            .WithParameter(CmdletConstants.Credential, GetPSCredential(cluster.HttpUserName, cluster.HttpPassword))
                            .WithParameter(CmdletConstants.JobDefinition, mapReduceJobDefinition)
                            .WithParameter(CmdletConstants.Debug, null)
                            .Invoke();

                Assert.IsTrue(logWriter.Buffer.Any(message => message.Contains(expectedLogMessage)));
                BufferingLogWriterFactory.Reset();
            }
            else
            {
                result =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.StartAzureHDInsightJob)
                            .WithParameter(CmdletConstants.Cluster, cluster.ConnectionUrl)
                            .WithParameter(CmdletConstants.Credential, GetPSCredential(cluster.HttpUserName, cluster.HttpPassword))
                            .WithParameter(CmdletConstants.JobDefinition, mapReduceJobDefinition)
                            .Invoke();
            }
            Assert.AreEqual(1, result.Results.Count);
            IEnumerable<AzureHDInsightJob> jobCreationCmdletResults = result.Results.ToEnumerable<AzureHDInsightJob>();
            AzureHDInsightJob jobCreationResults = jobCreationCmdletResults.First();
            Assert.IsNotNull(jobCreationResults.JobId, "Should get a non-null jobDetails id");

            return jobCreationResults;
        }
    }
}
