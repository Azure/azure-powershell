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
using System.Linq;
using Microsoft.Hadoop.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.PowerShellTestAbstraction.Interfaces;
using Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.Utilities;
using Microsoft.WindowsAzure.Management.HDInsight;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;

namespace Microsoft.WindowsAzure.Commands.Test.HDInsight.CmdLetTests
{
    [TestClass]
    public class WaitCmdletTest : HDInsightTestCaseBase
    {
        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Jobs")]
        public virtual void WaitForInvalidJobDoesNotThrow()
        {
            var jobDetails = new JobDetails { JobId = Guid.NewGuid().ToString() };
            var invalidJob = new AzureHDInsightJob(jobDetails, TestCredentials.WellKnownCluster.DnsName);

            // IHadoopClientExtensions.GetPollingInterval = () => 0;
            ClusterDetails cluster = CmdletScenariosTestCaseBase.GetHttpAccessEnabledCluster();
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                runspace.NewPipeline()
                                      .AddCommand(CmdletConstants.WaitAzureHDInsightJob)
                        .WithParameter(CmdletConstants.Credential, GetPSCredential(cluster.HttpUserName, cluster.HttpPassword))
                        .WithParameter(CmdletConstants.Job, invalidJob)
                                      .Invoke();
            }
        }


        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Jobs")]
        public virtual void WaitForJobWithId()
        {
            var hiveJobDefinition = new HiveJobCreateParameters()
            {
                JobName = "show tables jobDetails",
                Query = "show tables"
            };

            var cluster = CmdletScenariosTestCaseBase.GetHttpAccessEnabledCluster();
            using (var runspace = this.GetPowerShellRunspace())
            {
                var results = runspace.NewPipeline()
                                      .AddCommand(CmdletConstants.NewAzureHDInsightHiveJobDefinition)
                                      .WithParameter(CmdletConstants.JobName, hiveJobDefinition.JobName)
                                      .WithParameter(CmdletConstants.Query, hiveJobDefinition.Query)
                                      .AddCommand(CmdletConstants.StartAzureHDInsightJob)
                                      .WithParameter(CmdletConstants.Cluster, cluster.ConnectionUrl)
                                      .WithParameter(CmdletConstants.Credential, IntegrationTestBase.GetPSCredential(cluster.HttpUserName, cluster.HttpPassword))
                                      .Invoke();
                Assert.AreEqual(1, results.Results.Count);
                var job = results.Results.First().BaseObject as Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects.AzureHDInsightJob;

                results = runspace.NewPipeline()
                                      .AddCommand(CmdletConstants.WaitAzureHDInsightJob)
                                      .WithParameter(CmdletConstants.Credential, IntegrationTestBase.GetPSCredential(cluster.HttpUserName, cluster.HttpPassword))
                                      .WithParameter(CmdletConstants.JobId, job.JobId)
                                      .WithParameter(CmdletConstants.Cluster, job.Cluster)
                                      .Invoke();
                var completedJob = results.Results.ToEnumerable<AzureHDInsightJob>().FirstOrDefault();
                Assert.IsNotNull(completedJob);
                Assert.AreEqual(job.JobId, completedJob.JobId);
                Assert.AreEqual("Completed", completedJob.State);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Jobs")]
        public virtual void WaitForJob()
        {
            var hiveJobDefinition = new HiveJobCreateParameters { JobName = "show tables jobDetails", Query = "show tables" };

            // IHadoopClientExtensions.GetPollingInterval = () => 0;
            ClusterDetails cluster = CmdletScenariosTestCaseBase.GetHttpAccessEnabledCluster();
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IPipelineResult results =
                runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightHiveJobDefinition)
                            .WithParameter(CmdletConstants.JobName, hiveJobDefinition.JobName)
                            .WithParameter(CmdletConstants.Query, hiveJobDefinition.Query)
                            .AddCommand(CmdletConstants.StartAzureHDInsightJob)
                            .WithParameter(CmdletConstants.Cluster, cluster.ConnectionUrl)
                            .WithParameter(CmdletConstants.Credential, GetPSCredential(cluster.HttpUserName, cluster.HttpPassword))
                .AddCommand(CmdletConstants.WaitAzureHDInsightJob)
                            .WithParameter(CmdletConstants.Credential, GetPSCredential(cluster.HttpUserName, cluster.HttpPassword))
                .Invoke();
                Assert.AreEqual(1, results.Results.Count);
                Assert.AreEqual("Completed", results.Results.ToEnumerable<AzureHDInsightJob>().First().State);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Jobs")]
        public virtual void WaitForInvalidJobIdDoesNotThrow()
        {
            var jobDetails = new JobDetails()
            {
                JobId = Guid.NewGuid().ToString()
            };

            var cluster = CmdletScenariosTestCaseBase.GetHttpAccessEnabledCluster();
            using (var runspace = this.GetPowerShellRunspace())
            {
                runspace.NewPipeline()
                .AddCommand(CmdletConstants.WaitAzureHDInsightJob)
                .WithParameter(CmdletConstants.Credential, IntegrationTestBase.GetPSCredential(cluster.HttpUserName, cluster.HttpPassword))
                .WithParameter(CmdletConstants.JobId, jobDetails.JobId)
                .WithParameter(CmdletConstants.Cluster, jobDetails.JobId)
                .Invoke();
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Jobs")]
        public virtual void WaitForJobWithTimeout()
        {
            var hiveJobDefinition = new HiveJobCreateParameters { JobName = "show tables jobDetails", Query = "show tables" };

            // IHadoopClientExtensions.GetPollingInterval = () => 0;
            ClusterDetails cluster = CmdletScenariosTestCaseBase.GetHttpAccessEnabledCluster();
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IPipelineResult results =
                    runspace.NewPipeline()
                                      .AddCommand(CmdletConstants.NewAzureHDInsightHiveJobDefinition)
                                      .WithParameter(CmdletConstants.JobName, hiveJobDefinition.JobName)
                                      .WithParameter(CmdletConstants.Query, hiveJobDefinition.Query)
                                      .AddCommand(CmdletConstants.StartAzureHDInsightJob)
                                      .WithParameter(CmdletConstants.Cluster, cluster.ConnectionUrl)
                            .WithParameter(CmdletConstants.Credential, GetPSCredential(cluster.HttpUserName, cluster.HttpPassword))
                                      .AddCommand(CmdletConstants.WaitAzureHDInsightJob)
                            .WithParameter(CmdletConstants.Credential, GetPSCredential(cluster.HttpUserName, cluster.HttpPassword))
                                      .WithParameter(CmdletConstants.WaitTimeoutInSeconds, 0.01)
                                      .Invoke();
                Assert.AreEqual(1, results.Results.Count);
                Assert.AreEqual("Completed", results.Results.ToEnumerable<AzureHDInsightJob>().First().State);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Jobs")]
        public void WaitForJobs()
        {
            // IHadoopClientExtensions.GetPollingInterval = () => 0;
            var hiveJobDefinition = new HiveJobCreateParameters { JobName = "show tables jobDetails", Query = "show tables" };

            ClusterDetails cluster = CmdletScenariosTestCaseBase.GetHttpAccessEnabledCluster();
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IPipelineResult results =
                    runspace.NewPipeline()
                                      .AddCommand(CmdletConstants.GetAzureHDInsightJob)
                                      .WithParameter(CmdletConstants.Cluster, cluster.ConnectionUrl)
                            .WithParameter(CmdletConstants.Credential, GetPSCredential(cluster.HttpUserName, cluster.HttpPassword))
                                      .Invoke();

                int startingCount = results.Results.Count;

                results =
                    runspace.NewPipeline()
                                  .AddCommand(CmdletConstants.NewAzureHDInsightHiveJobDefinition)
                                  .WithParameter(CmdletConstants.JobName, hiveJobDefinition.JobName)
                                  .WithParameter(CmdletConstants.Query, hiveJobDefinition.Query)
                                  .AddCommand(CmdletConstants.StartAzureHDInsightJob)
                                  .WithParameter(CmdletConstants.Cluster, cluster.ConnectionUrl)
                            .WithParameter(CmdletConstants.Credential, GetPSCredential(cluster.HttpUserName, cluster.HttpPassword))
                                  .AddCommand(CmdletConstants.NewAzureHDInsightHiveJobDefinition)
                                  .WithParameter(CmdletConstants.JobName, hiveJobDefinition.JobName)
                                  .WithParameter(CmdletConstants.Query, hiveJobDefinition.Query)
                                  .AddCommand(CmdletConstants.StartAzureHDInsightJob)
                                  .WithParameter(CmdletConstants.Cluster, cluster.ConnectionUrl)
                            .WithParameter(CmdletConstants.Credential, GetPSCredential(cluster.HttpUserName, cluster.HttpPassword))
                                  .AddCommand(CmdletConstants.NewAzureHDInsightHiveJobDefinition)
                                  .WithParameter(CmdletConstants.JobName, hiveJobDefinition.JobName)
                                  .WithParameter(CmdletConstants.Query, hiveJobDefinition.Query)
                                  .AddCommand(CmdletConstants.StartAzureHDInsightJob)
                                  .WithParameter(CmdletConstants.Cluster, cluster.ConnectionUrl)
                            .WithParameter(CmdletConstants.Credential, GetPSCredential(cluster.HttpUserName, cluster.HttpPassword))
                                  .Invoke();

                results =
                    runspace.NewPipeline()
                                  .AddCommand(CmdletConstants.GetAzureHDInsightJob)
                                  .WithParameter(CmdletConstants.Cluster, cluster.ConnectionUrl)
                            .WithParameter(CmdletConstants.Credential, GetPSCredential(cluster.HttpUserName, cluster.HttpPassword))
                                  .AddCommand(CmdletConstants.WaitAzureHDInsightJob)
                            .WithParameter(CmdletConstants.Credential, GetPSCredential(cluster.HttpUserName, cluster.HttpPassword))
                                  .Invoke();
                Assert.AreEqual(startingCount + 3, results.Results.Count);
                foreach (AzureHDInsightJob entity in results.Results.ToEnumerable<AzureHDInsightJob>())
                {
                    Assert.IsTrue(entity.State == "Completed" || entity.State == "Canceled" || entity.State == "Failed");
                }
            }
        }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }
    }
}
