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
using Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.PowerShellTestAbstraction.Interfaces;
using Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.Utilities;
using Microsoft.WindowsAzure.Management.HDInsight;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions;

namespace Microsoft.WindowsAzure.Commands.Test.HDInsight.CmdLetTests
{
    public class GrantRdpAccessCmdletTests : HDInsightTestCaseBase, IDisposable
    {
        public new void Dispose()
        {
            base.TestCleanup();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanGrantRdpAccessToHDInsightCluster()
        {
            IHDInsightCertificateCredential creds = GetValidCredentials();
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                AzureHDInsightCluster cluster = GetClusterWithRdpAccessDisabled(runspace);
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.GrantAzureHDInsightRdpAccess)
                            .WithParameter(CmdletConstants.Location, cluster.Location)
                            .WithParameter(CmdletConstants.Name, cluster.Name)
                            .WithParameter(CmdletConstants.RdpCredential, GetAzurePsCredentials())
                            .WithParameter(CmdletConstants.RdpAccessExpiry, DateTime.UtcNow.AddDays(6))
                            .Invoke();

                AzureHDInsightCluster accessgrantedCluster = GetCluster(creds, cluster.Name, runspace);
                Assert.NotNull(accessgrantedCluster);
                Assert.Equal(accessgrantedCluster.RdpUserName, TestCredentials.AzureUserName);
            }
        }

        public GrantRdpAccessCmdletTests()
        {
            base.Initialize();
        }

        internal static AzureHDInsightCluster GetClusterWithRdpAccessDisabled(IRunspace runspace)
        {
            IHDInsightCertificateCredential creds = GetValidCredentials();
            IPipelineResult results =
                runspace.NewPipeline()
                        .AddCommand(CmdletConstants.GetAzureHDInsightCluster)
                        .Invoke();

            List<AzureHDInsightCluster> testClusters = results.Results.ToEnumerable<AzureHDInsightCluster>().ToList();
            AzureHDInsightCluster testCluster = testClusters.FirstOrDefault(cluster => cluster.RdpUserName.IsNullOrEmpty());
            if (testCluster == null)
            {
                testCluster = testClusters.Last();
                RevokeRdpAccessToCluster(creds, testCluster, runspace);
            }

            return testCluster;
        }

        internal static void RevokeRdpAccessToCluster(
            IHDInsightCertificateCredential connectionCredentials, AzureHDInsightCluster cluster, IRunspace runspace)
        {
            IPipelineResult results =
                runspace.NewPipeline()
                        .AddCommand(CmdletConstants.RevokeAzureHDInsightRdpAccess)
                        .WithParameter(CmdletConstants.Location, cluster.Location)
                        .WithParameter(CmdletConstants.Name, cluster.Name)
                        .Invoke();

            AzureHDInsightCluster accessRevokedCluster = GetCluster(connectionCredentials, cluster.Name, runspace);
            Assert.NotNull(accessRevokedCluster);
            Assert.True(string.IsNullOrEmpty(accessRevokedCluster.RdpUserName));
        }

        internal static AzureHDInsightCluster GetCluster(
            IHDInsightCertificateCredential connectionCredentials, string clusterName, IRunspace runspace)
        {
            IPipelineResult results =
                runspace.NewPipeline()
                        .AddCommand(CmdletConstants.GetAzureHDInsightCluster)
                        .WithParameter(CmdletConstants.Name, clusterName)
                        .Invoke();

            List<AzureHDInsightCluster> clusters = results.Results.ToEnumerable<AzureHDInsightCluster>().ToList();
            return clusters.FirstOrDefault();
        }
    }
}
