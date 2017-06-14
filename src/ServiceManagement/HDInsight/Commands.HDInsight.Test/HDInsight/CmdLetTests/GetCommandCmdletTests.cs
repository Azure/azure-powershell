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
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.PowerShellTestAbstraction.Interfaces;
using Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.Simulators;
using Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.Utilities;
using Microsoft.WindowsAzure.Management.HDInsight;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Logging;

namespace Microsoft.WindowsAzure.Commands.Test.HDInsight.CmdLetTests
{
    [TestClass]
    public class GetCommandCmdletTests : HDInsightTestCaseBase
    {
        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ICanCallThe_Get_ClusterHDInsightClusterCmdlet()
        {
            IHDInsightCertificateCredential creds = GetValidCredentials();
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.GetAzureHDInsightCluster)
                            .Invoke();

                IEnumerable<AzureHDInsightCluster> clusters = results.Results.ToEnumerable<AzureHDInsightCluster>();
                AzureHDInsightCluster wellKnownCluster = clusters.FirstOrDefault(cluster => cluster.Name == TestCredentials.WellKnownCluster.DnsName);
                Assert.IsNotNull(wellKnownCluster);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ICanCallThe_Get_ClusterHDInsightClusterCmdlet_WithADnsName()
        {
            IHDInsightCertificateCredential creds = GetValidCredentials();
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.GetAzureHDInsightCluster)
                            .WithParameter(CmdletConstants.Name, TestCredentials.WellKnownCluster.DnsName)
                            .Invoke();
                Assert.AreEqual(1, results.Results.Count);
                AzureHDInsightCluster cluster = results.Results.ToEnumerable<AzureHDInsightCluster>().Last();
                ValidateGetCluster(cluster);
            }
        }

        //[TestMethod]
        [TestCategory("CheckIn")]
        public void ICanCallThe_Get_ClusterHDInsightClusterCmdlet_WithDebug()
        {
            IHDInsightCertificateCredential creds = GetValidCredentials();
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                var logWriter = new PowershellLogWriter();
                BufferingLogWriterFactory.Instance = logWriter;
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.GetAzureHDInsightCluster)
                            .WithParameter(CmdletConstants.Debug, null)
                            .Invoke();
                IEnumerable<AzureHDInsightCluster> clusters = results.Results.ToEnumerable<AzureHDInsightCluster>();
                AzureHDInsightCluster wellKnownCluster = clusters.FirstOrDefault(cluster => cluster.Name == TestCredentials.WellKnownCluster.DnsName);
                Assert.IsNotNull(wellKnownCluster);
                ValidateGetCluster(wellKnownCluster);

                string expectedLogMessage = "Getting hdinsight clusters for subscriptionid : ";
                Assert.IsTrue(logWriter.Buffer.Any(message => message.Contains(expectedLogMessage)));
                BufferingLogWriterFactory.Reset();
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ICanCallThe_Get_ClusterHDInsightClusterCmdlet_WithoutCertificate()
        {
            IHDInsightCertificateCredential creds = GetValidCredentials();
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.GetAzureHDInsightCluster)
                            .Invoke();
                IEnumerable<AzureHDInsightCluster> clusters = results.Results.ToEnumerable<AzureHDInsightCluster>();
                AzureHDInsightCluster wellKnownCluster = clusters.FirstOrDefault(cluster => cluster.Name == TestCredentials.WellKnownCluster.DnsName);
                Assert.IsNotNull(wellKnownCluster);
                ValidateGetCluster(wellKnownCluster);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ICanCallThe_Get_ClusterHDInsightClusterCmdlet_WithSubscriptionId()
        {
            IHDInsightCertificateCredential creds = GetValidCredentials();
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.GetAzureHDInsightCluster)
                            .WithParameter(CmdletConstants.Subscription, IntegrationTestBase.TestCredentials.SubscriptionId)
                            .Invoke();
                IEnumerable<AzureHDInsightCluster> clusters = results.Results.ToEnumerable<AzureHDInsightCluster>();
                AzureHDInsightCluster wellKnownCluster = clusters.FirstOrDefault(cluster => cluster.Name == TestCredentials.WellKnownCluster.DnsName);
                Assert.IsNotNull(wellKnownCluster);
                ValidateGetCluster(wellKnownCluster);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ICanCallThe_Get_ClusterHDInsightClusterCmdlet_WithInvalidSubscriptionId()
        {
            IHDInsightCertificateCredential creds = GetValidCredentials();
            var invalidSubscriptionId = Guid.NewGuid().ToString();
            var expectedErrorMessage =
                string.Format(
                    "Failed to retrieve Certificate for the subscription '{0}'.Please use Select-AzureSubscription -Current to select a subscription.",
                    invalidSubscriptionId);
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                try
                {
                    IPipelineResult results =
                runspace.NewPipeline()
                        .AddCommand(CmdletConstants.GetAzureHDInsightCluster)
                        .WithParameter(CmdletConstants.Subscription, invalidSubscriptionId)
                        .Invoke();
                    Assert.Fail("Test should have failed.");
                }
                catch (CmdletInvocationException cmdException)
                {
                    var innerException = cmdException.GetBaseException();
                    Assert.IsInstanceOfType(innerException, typeof(ArgumentException));
                    Assert.AreEqual(expectedErrorMessage, innerException.Message);
                }
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ICannotCallThe_Get_ClusterHDInsightClusterCmdlet_WithNonExistantCluster()
        {
            IHDInsightCertificateCredential creds = GetValidCredentials();
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                try
                {
                    IPipelineResult results =
                        runspace.NewPipeline()
                                .AddCommand(CmdletConstants.GetAzureHDInsightCluster)
                                .WithParameter(CmdletConstants.Name, Guid.NewGuid().ToString())
                                .Invoke();
                }
                catch (CmdletInvocationException cmdException)
                {
                    var baseHttpException = cmdException.GetBaseException() as HttpRequestException;
                    Assert.IsNotNull(baseHttpException, "expected httpException for invalid cluster name");
                }
            }
        }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }

        private static void ValidateGetCluster(AzureHDInsightCluster cluster)
        {
            Assert.AreEqual(TestCredentials.WellKnownCluster.DnsName, cluster.Name);
            Assert.AreEqual(TestCredentials.HadoopUserName, cluster.HttpUserName);
            Assert.AreEqual(TestCredentials.AzurePassword, cluster.HttpPassword);
            Assert.AreEqual(ClusterState.Running, cluster.State);
            Assert.IsFalse(string.IsNullOrEmpty(cluster.ConnectionUrl));
            Assert.AreEqual(VersionStatus.Compatible.ToString(), cluster.VersionStatus);
            Assert.AreEqual(TestCredentials.WellKnownCluster.Version, cluster.Version);
            WabStorageAccountConfiguration defaultStorageAccount = GetWellKnownStorageAccounts().First();
            Assert.AreEqual(defaultStorageAccount.Key, cluster.DefaultStorageAccount.StorageAccountKey);
            Assert.AreEqual(defaultStorageAccount.Name, cluster.DefaultStorageAccount.StorageAccountName);
            Assert.AreEqual(defaultStorageAccount.Container, cluster.DefaultStorageAccount.StorageContainerName);
            foreach (WabStorageAccountConfiguration account in GetWellKnownStorageAccounts().Skip(1))
            {
                AzureHDInsightStorageAccount deserializedAccount =
                    cluster.StorageAccounts.FirstOrDefault(acc => acc.StorageAccountName == account.Name);
                Assert.IsNotNull(deserializedAccount, account.Name);
                Assert.AreEqual(account.Key, deserializedAccount.StorageAccountKey);
            }
        }
    }
}
