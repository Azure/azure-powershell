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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Test.HDInsight.CmdLetTests;
using Microsoft.WindowsAzure.Management.HDInsight;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.ServiceLocation;

namespace Microsoft.WindowsAzure.Commands.Test.HDInsight.CommandTests
{
    [TestClass]
    public class ManageAzureHDInsightHttpAccessCommandTests : HDInsightTestCaseBase
    {
        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        [TestCategory("Rdfe")]
        public void CanGrantAccessToHttpServices()
        {
            IHDInsightCertificateCredential creds = GetValidCredentials();
            AzureHDInsightCluster testCluster = GetClusterWithHttpAccessDisabled(creds);
            AzureHDInsightCluster cluster = EnableHttpAccessToCluster(
                creds, testCluster, TestCredentials.AzureUserName, TestCredentials.AzurePassword);
            Assert.IsNotNull(cluster);
            Assert.AreEqual(cluster.HttpUserName, TestCredentials.AzureUserName);
            Assert.AreEqual(cluster.HttpPassword, TestCredentials.AzurePassword);
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("CheckIn")]
        [TestCategory("Rdfe")]
        public void CanRevokeAccessToHttpServices()
        {
            IHDInsightCertificateCredential creds = GetValidCredentials();
            AzureHDInsightCluster testCluster = GetClusterWithHttpAccessDisabled(creds);
            EnableHttpAccessToCluster(creds, testCluster, TestCredentials.AzureUserName, TestCredentials.AzurePassword);
            AzureHDInsightCluster cluster = DisableHttpAccessToCluster(creds, testCluster);
            Assert.IsNotNull(cluster);
            Assert.IsTrue(string.IsNullOrEmpty(cluster.HttpUserName));
            Assert.IsTrue(string.IsNullOrEmpty(cluster.HttpPassword));
        }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }

        private static AzureHDInsightCluster GetClusterWithHttpAccessDisabled(IHDInsightCertificateCredential creds)
        {
            IGetAzureHDInsightClusterCommand client = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGet();
            client.CurrentSubscription = GetCurrentSubscription();
            client.EndProcessing();
            List<AzureHDInsightCluster> clusters = client.Output.ToList();
            AzureHDInsightCluster containerWithHttpAccessDisabled = clusters.FirstOrDefault(cluster => cluster.HttpUserName.IsNullOrEmpty());
            if (containerWithHttpAccessDisabled == null)
            {
                containerWithHttpAccessDisabled = clusters.Last();
                DisableHttpAccessToCluster(creds, containerWithHttpAccessDisabled);
            }

            return containerWithHttpAccessDisabled;
        }

        private static AzureHDInsightCluster DisableHttpAccessToCluster(
            IHDInsightCertificateCredential creds, AzureHDInsightCluster containerWithHttpAccessDisabled)
        {
            IManageAzureHDInsightHttpAccessCommand httpManagementClient =
                ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateManageHttpAccess();
            httpManagementClient.CurrentSubscription = GetCurrentSubscription();
            httpManagementClient.Credential = GetAzurePsCredentials();
            httpManagementClient.Name = containerWithHttpAccessDisabled.Name;
            httpManagementClient.Location = containerWithHttpAccessDisabled.Location;
            httpManagementClient.Enable = false;
            httpManagementClient.EndProcessing();
            return httpManagementClient.Output.First();
        }

        private static AzureHDInsightCluster EnableHttpAccessToCluster(
            IHDInsightCertificateCredential creds, AzureHDInsightCluster containerWithHttpAccessDisabled, string httpUserName, string httpPassword)
        {
            IManageAzureHDInsightHttpAccessCommand httpManagementClient =
                ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateManageHttpAccess();
            httpManagementClient.CurrentSubscription = GetCurrentSubscription();
            httpManagementClient.Credential = GetPSCredential(httpUserName, httpPassword);
            httpManagementClient.Name = containerWithHttpAccessDisabled.Name;
            httpManagementClient.Location = containerWithHttpAccessDisabled.Location;
            httpManagementClient.Enable = true;
            httpManagementClient.EndProcessing();
            return httpManagementClient.Output.First();
        }
    }
}
