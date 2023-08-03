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

using Microsoft.Azure.Commands.HDInsight.Models;
using Azure.ResourceManager.HDInsight.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using System;
using Azure.Core;

namespace Microsoft.Azure.Commands.HDInsight.Test
{
    public class GetClusterTests : HDInsightTestBase
    {
        private GetAzureHDInsightCommand cmdlet;

        public GetClusterTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagement.Common.Models.XunitTracingInterceptor(output));
            base.SetupTestsForManagement();

            cmdlet = new GetAzureHDInsightCommand
            {
                CommandRuntime = commandRuntimeMock.Object,
                HDInsightManagementClient = hdinsightManagementMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanGetHDInsightCluster()
        {
            cmdlet.ClusterName = ClusterName;
            cmdlet.ResourceGroupName = ResourceGroupName;

            var cluster = ArmHDInsightModelFactory.HDInsightClusterData(id: new ResourceIdentifier("id"), name: ClusterName, location: Location);
            cluster.Properties = new HDInsightClusterProperties(new HDInsightClusterDefinition());
            cluster.Properties.ClusterVersion = "3.6";
            cluster.Properties.ClusterState = "Running";
            cluster.Properties.ClusterDefinition.Kind = ClusterType;
            cluster.Properties.QuotaInfoCoresUsed = 24;
            cluster.Properties.OSType = "Linux";

            hdinsightManagementMock.Setup(c => c.Get(ResourceGroupName, ClusterName))
                .Returns(cluster)
                .Verifiable();

            hdinsightManagementMock.Setup(c => c.GetCluster(It.IsAny<string>(), It.IsAny<string>()))
                .CallBase()
                .Verifiable();

            cmdlet.ExecuteCmdlet();

            commandRuntimeMock.VerifyAll();
            commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<List<AzureHDInsightCluster>>(), true), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanListHDInsightClustersInRG()
        {
            cmdlet.ResourceGroupName = ResourceGroupName;

            var cluster1 = ArmHDInsightModelFactory.HDInsightClusterData(id: new ResourceIdentifier("id"), name: ClusterName + "1", location: Location);
            cluster1.Properties = new HDInsightClusterProperties(new HDInsightClusterDefinition());

            cluster1.Properties.ClusterVersion = "3.6";
            cluster1.Properties.ClusterState = "Running";
            cluster1.Properties.ClusterDefinition.Kind = ClusterType;
            cluster1.Properties.QuotaInfoCoresUsed = 24;
            cluster1.Properties.OSType = "Linux";

            var cluster2 = ArmHDInsightModelFactory.HDInsightClusterData(id: new ResourceIdentifier("id"), name: ClusterName + "2", location: Location);
            cluster2.Properties = new HDInsightClusterProperties(new HDInsightClusterDefinition());

            cluster2.Properties.ClusterVersion = "3.6";
            cluster2.Properties.ClusterState = "Running";
            cluster2.Properties.ClusterDefinition.Kind = ClusterType;
            cluster2.Properties.QuotaInfoCoresUsed = 24;
            cluster2.Properties.OSType = "Linux";

            var listresponse = new[] { cluster1, cluster2 };
            hdinsightManagementMock.Setup(c => c.ListClusters(ResourceGroupName))
                .Returns(listresponse)
                .Verifiable();

            hdinsightManagementMock.Setup(c => c.GetCluster(It.IsAny<string>(), It.IsAny<string>()))
                .CallBase()
                .Verifiable();

            cmdlet.ExecuteCmdlet();

            commandRuntimeMock.VerifyAll();
            commandRuntimeMock.Verify(
                f =>
                    f.WriteObject(
                        It.Is<List<AzureHDInsightCluster>>(
                            list =>
                                list.Count == 2 &&
                                list.Any(c => c.Name == cluster1.Name) &&
                                list.Any(c => c.Name == cluster2.Name)), true), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanListHDInsightClusters()
        {
            var cluster1 = ArmHDInsightModelFactory.HDInsightClusterData(id: new ResourceIdentifier("id"), name: ClusterName + "1", location: Location);

            cluster1.Properties = new HDInsightClusterProperties(new HDInsightClusterDefinition());
            cluster1.Properties.ClusterVersion = "3.6";
            cluster1.Properties.ClusterState = "Running";
            cluster1.Properties.ClusterDefinition.Kind = ClusterType;
            cluster1.Properties.QuotaInfoCoresUsed = 24;
            cluster1.Properties.OSType = "Linux";

            var cluster2 = ArmHDInsightModelFactory.HDInsightClusterData(id: new ResourceIdentifier("id"), name: ClusterName + "2", location: Location);

            cluster2.Properties = new HDInsightClusterProperties(new HDInsightClusterDefinition());
            cluster2.Properties.ClusterVersion = "3.6";
            cluster2.Properties.ClusterState = "Running";
            cluster2.Properties.ClusterDefinition.Kind = ClusterType;
            cluster2.Properties.QuotaInfoCoresUsed = 24;
            cluster2.Properties.OSType = "Linux";

            var listresponse = new[] { cluster1, cluster2 };
            hdinsightManagementMock.Setup(c => c.ListClusters())
                .Returns(listresponse)
                .Verifiable();

            hdinsightManagementMock.Setup(c => c.GetCluster(It.IsAny<string>(), It.IsAny<string>()))
                .CallBase()
                .Verifiable();

            cmdlet.ExecuteCmdlet();

            commandRuntimeMock.VerifyAll();
            commandRuntimeMock.Verify(
                f =>
                    f.WriteObject(
                        It.Is<List<AzureHDInsightCluster>>(
                            list =>
                                list.Count == 2 &&
                                list.Any(c => c.Name == cluster1.Name) &&
                                list.Any(c => c.Name == cluster2.Name)), true), Times.Once);
        }
    }
}
