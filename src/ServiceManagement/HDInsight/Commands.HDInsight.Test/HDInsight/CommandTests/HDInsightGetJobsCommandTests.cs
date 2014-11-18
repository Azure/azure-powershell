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
using System.Management.Automation;
using System.Net;
using Microsoft.Hadoop.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Test.HDInsight.CmdLetTests;
using Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.Simulators;
using Microsoft.WindowsAzure.Management.HDInsight;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandImplementations;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.ServiceLocation;

namespace Microsoft.WindowsAzure.Commands.Test.HDInsight.CommandTests
{
    [TestClass]
    public class HDInsightGetJobsCommandTests : HDInsightTestCaseBase
    {
        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Jobs")]
        [TestCategory("GetAzureHDInsightJobCommand")]
        public void CanListJobsForAValidCluster()
        {
            ClusterDetails cluster = CmdletScenariosTestCaseBase.GetHttpAccessEnabledCluster();
            IGetAzureHDInsightJobCommand getJobsCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGetJobs();
            getJobsCommand.Credential = GetPSCredential(cluster.HttpUserName, cluster.HttpPassword);
            getJobsCommand.Cluster = cluster.ConnectionUrl;
            getJobsCommand.EndProcessing();

            JobList history = GetJobHistory(getJobsCommand.Cluster);

            Assert.AreEqual(history.Jobs.Count, getJobsCommand.Output.Count, "Should have {0} jobs.", history.Jobs.Count);
            foreach (AzureHDInsightJob job in getJobsCommand.Output)
            {
                Assert.IsFalse(string.IsNullOrEmpty(job.PercentComplete));
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Jobs")]
        [TestCategory("GetAzureHDInsightJobCommand")]
        public void CanListJobsForAValidClusterWithJobId()
        {
            ClusterDetails cluster = CmdletScenariosTestCaseBase.GetHttpAccessEnabledCluster();
            PSCredential psCredentials = GetPSCredential(cluster.HttpUserName, cluster.HttpPassword);
            IGetAzureHDInsightJobCommand getJobsCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGetJobs();
            getJobsCommand.Credential = psCredentials;
            getJobsCommand.Cluster = cluster.ConnectionUrl;
            getJobsCommand.EndProcessing();

            if (!getJobsCommand.Output.Any())
            {
                return;
            }

            AzureHDInsightJob jobDetail = getJobsCommand.Output.First();

            IGetAzureHDInsightJobCommand getJobWithIdCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGetJobs();
            getJobWithIdCommand.Credential = psCredentials;
            getJobWithIdCommand.Cluster = cluster.ConnectionUrl;
            getJobWithIdCommand.JobId = jobDetail.JobId;
            getJobWithIdCommand.EndProcessing();

            Assert.AreEqual(1, getJobWithIdCommand.Output.Count, "Should have only one jobDetails when called with jobId.");
            Assert.AreEqual(jobDetail.JobId, getJobsCommand.Output.First().JobId, "Should get jobDetails with the same jobId as the one requested.");
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Jobs")]
        [TestCategory("GetAzureHDInsightJobCommand")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetClientWithoutCredentialsorSubscriptionCertificateThrows()
        {
            ClusterDetails cluster = CmdletScenariosTestCaseBase.GetHttpAccessEnabledCluster();
            using (var cmd = new GetAzureHDInsightJobCommand())
            {
                cmd.Cluster = cluster.Name;

                cmd.GetClient(cmd.Cluster);
            }
        }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }

        internal static JobList GetJobHistory(string clusterEndpoint)
        {
            string clusterGatewayUri = GatewayUriResolver.GetGatewayUri(clusterEndpoint).AbsoluteUri.ToUpperInvariant();
            var manager = ServiceLocator.Instance.Locate<IServiceLocationSimulationManager>();
            if (manager.MockingLevel == ServiceLocationMockingLevel.ApplyFullMocking)
            {
                if (AzureHDInsightJobSubmissionClientSimulatorFactory.jobSubmissionClients.ContainsKey(clusterGatewayUri))
                {
                    return AzureHDInsightJobSubmissionClientSimulatorFactory.jobSubmissionClients[clusterGatewayUri].ListJobs();
                }
            }

            return new JobList { ErrorCode = HttpStatusCode.NotFound.ToString() };
        }
    }
}
