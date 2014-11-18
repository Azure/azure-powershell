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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Test.HDInsight.CmdLetTests;
using Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.PowerShellTestAbstraction.Interfaces;
using Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.Utilities;
using Microsoft.WindowsAzure.Management.HDInsight;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.ServiceLocation;

namespace Microsoft.WindowsAzure.Commands.Test.HDInsight.CommandTests
{
    [TestClass]
    public class ConnectClusterCommandTests : HDInsightTestCaseBase
    {
        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        [TestCategory("PowerShell")]
        public void CanConnectToValidCluster()
        {
            IHDInsightCertificateCredential creds = GetValidCredentials();
            IUseAzureHDInsightClusterCommand connectCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateUseCluster();
            connectCommand.CurrentSubscription = GetCurrentSubscription();
            connectCommand.Name = TestCredentials.WellKnownCluster.DnsName;
            connectCommand.EndProcessing();

            Assert.AreEqual(1, connectCommand.Output.Count);
            AzureHDInsightClusterConnection currentCluster = connectCommand.Output.First();
            Assert.IsNotNull(currentCluster);
            ValidateGetCluster(currentCluster.Cluster);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        [TestCategory("PowerShell")]

        public void CanConnectToValidClustersMoreThanOnce()
        {
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IHDInsightCertificateCredential creds = GetValidCredentials();
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.GetAzureHDInsightCluster)
                            .WithParameter(CmdletConstants.Name, TestCredentials.WellKnownCluster.DnsName)
                            .Invoke();
                IEnumerable<AzureHDInsightCluster> clusters = results.Results.ToEnumerable<AzureHDInsightCluster>();
                foreach (AzureHDInsightCluster cluster in clusters)
                {
                    IUseAzureHDInsightClusterCommand connectCommand =
                        ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateUseCluster();
                    connectCommand.CurrentSubscription = GetCurrentSubscription();
                    connectCommand.Name = cluster.Name;
                    connectCommand.EndProcessing();
                    Assert.AreEqual(1, connectCommand.Output.Count);
                    AzureHDInsightClusterConnection currentCluster = connectCommand.Output.First();
                    Assert.IsNotNull(currentCluster);
                    ValidateGetCluster(cluster, currentCluster.Cluster);
                }
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        [TestCategory("PowerShell")]

        public void CannotConnectToInvalidCluster()
        {
            IHDInsightCertificateCredential creds = GetValidCredentials();
            string errorMessage = string.Empty;
            string invalidCluster = Guid.NewGuid().ToString();
            try
            {
                IUseAzureHDInsightClusterCommand connectCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateUseCluster();
                connectCommand.CurrentSubscription = GetCurrentSubscription();
                connectCommand.Certificate = creds.Certificate;
                connectCommand.Name = invalidCluster;
                connectCommand.EndProcessing().Wait();
            }
            catch (AggregateException aex)
            {
                errorMessage = aex.InnerExceptions.FirstOrDefault().Message;
            }

            Assert.AreEqual("Failed to connect to cluster :" + invalidCluster, errorMessage);
        }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }

        private static void ValidateGetCluster(AzureHDInsightCluster expected, AzureHDInsightCluster actual)
        {
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Version, actual.Version);
            Assert.AreEqual(expected.HttpUserName, actual.HttpUserName);
            Assert.AreEqual(expected.HttpPassword, actual.HttpPassword);
        }

        private static void ValidateGetCluster(AzureHDInsightCluster cluster)
        {
            Assert.AreEqual(TestCredentials.WellKnownCluster.DnsName, cluster.Name);
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
