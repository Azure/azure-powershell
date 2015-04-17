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
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.WindowsAzure.Commands.Test.HDInsight.CmdLetTests;
using Microsoft.WindowsAzure.Management.HDInsight;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.ServiceLocation;

namespace Microsoft.WindowsAzure.Commands.Test.HDInsight.CommandTests
{
    public class ManageAzureHDInsightRdpAccessCommandTests : HDInsightTestCaseBase, IDisposable
    {
        public void Dispose()
        {
            base.TestCleanup();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanGrantHDInsightRdpAccess()
        {
            var rdpUserName = "rdpuser";
            IHDInsightCertificateCredential creds = GetValidCredentials();
            AzureHDInsightCluster testCluster = GetClusterWithRdpAccessDisabled(creds);
            AzureHDInsightCluster cluster = EnableRdpAccessToCluster(
                creds, testCluster, rdpUserName, TestCredentials.AzurePassword, DateTime.UtcNow.AddDays(6));
            Assert.NotNull(cluster);
            Assert.Equal(cluster.RdpUserName, rdpUserName);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanRevokeAccessToRdpServices()
        {
            IHDInsightCertificateCredential creds = GetValidCredentials();
            AzureHDInsightCluster testCluster = GetClusterWithRdpAccessDisabled(creds);
            EnableRdpAccessToCluster(creds, testCluster, TestCredentials.AzureUserName, TestCredentials.AzurePassword,
                DateTime.UtcNow.AddDays(6));
            AzureHDInsightCluster cluster = DisableRdpAccessToCluster(creds, testCluster);
            Assert.NotNull(cluster);
            Assert.True(string.IsNullOrEmpty(cluster.RdpUserName));
        }

        public ManageAzureHDInsightRdpAccessCommandTests()
        {
            base.Initialize();
        }

        private static AzureHDInsightCluster GetClusterWithRdpAccessDisabled(IHDInsightCertificateCredential creds)
        {
            IGetAzureHDInsightClusterCommand client = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGet();
            client.CurrentSubscription = GetCurrentSubscription();
            client.EndProcessing();
            List<AzureHDInsightCluster> clusters = client.Output.ToList();
            AzureHDInsightCluster containerWithRdpAccessDisabled = clusters.FirstOrDefault(cluster => cluster.RdpUserName.IsNullOrEmpty());
            if (containerWithRdpAccessDisabled == null)
            {
                containerWithRdpAccessDisabled = clusters.Last();
                DisableRdpAccessToCluster(creds, containerWithRdpAccessDisabled);
            }

            return containerWithRdpAccessDisabled;
        }

        private static AzureHDInsightCluster DisableRdpAccessToCluster(
            IHDInsightCertificateCredential creds, AzureHDInsightCluster containerWithRdpAccessDisabled)
        {
            IManageAzureHDInsightRdpAccessCommand rdpManagementClient =
                ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateManageRdpAccess();
            rdpManagementClient.CurrentSubscription = GetCurrentSubscription();
            rdpManagementClient.RdpCredential = GetAzurePsCredentials();
            rdpManagementClient.Name = containerWithRdpAccessDisabled.Name;
            rdpManagementClient.Location = containerWithRdpAccessDisabled.Location;
            rdpManagementClient.Enable = false;
            rdpManagementClient.EndProcessing();
            return rdpManagementClient.Output.First();
        }

        private static AzureHDInsightCluster EnableRdpAccessToCluster(
            IHDInsightCertificateCredential creds, AzureHDInsightCluster containerWithRdpAccessDisabled, string rdpUserName, string rdpPassword, DateTime expiry)
        {
            IManageAzureHDInsightRdpAccessCommand rdpManagementClient =
                ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateManageRdpAccess();
            rdpManagementClient.CurrentSubscription = GetCurrentSubscription();
            rdpManagementClient.RdpCredential = GetPSCredential(rdpUserName, rdpPassword);
            rdpManagementClient.Name = containerWithRdpAccessDisabled.Name;
            rdpManagementClient.Location = containerWithRdpAccessDisabled.Location;
            rdpManagementClient.RdpAccessExpiry = expiry;
            rdpManagementClient.Enable = true;

            rdpManagementClient.EndProcessing();
            return rdpManagementClient.Output.First();
        }
    }
}
