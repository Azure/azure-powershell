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
using Microsoft.Azure.Management.HDInsight.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

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
<<<<<<< HEAD
            var cluster = new Cluster
            {
                Id = "id",
                Name = ClusterName,
                Location = Location,
                Properties = new ClusterGetProperties
                {
                    ClusterVersion = "3.1",
                    ClusterState = "Running",
                    ClusterDefinition = new ClusterDefinition
                    {
                        ClusterType = ClusterType
=======
            var cluster = new Cluster(id: "id", name: ClusterName)
            {
                Location = Location,
                Properties = new ClusterGetProperties
                {
                    ClusterVersion = "3.6",
                    ClusterState = "Running",
                    ClusterDefinition = new ClusterDefinition
                    {
                        Kind = ClusterType
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                    },
                    QuotaInfo = new QuotaInfo
                    {
                        CoresUsed = 24
                    },
<<<<<<< HEAD
                    OperatingSystemType = OSType.Windows
                }
            };

            var getresponse = new ClusterGetResponse { Cluster = cluster };
            hdinsightManagementMock.Setup(c => c.Get(ResourceGroupName, ClusterName))
                .Returns(getresponse)
=======
                    OsType = OSType.Linux
                }
            };

            hdinsightManagementMock.Setup(c => c.Get(ResourceGroupName, ClusterName))
                .Returns(cluster)
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
<<<<<<< HEAD
            var cluster1 = new Cluster
            {
                Id = "id",
                Name = ClusterName + "1",
                Location = Location,
                Properties = new ClusterGetProperties
                {
                    ClusterVersion = "3.1",
                    ClusterState = "Running",
                    ClusterDefinition = new ClusterDefinition
                    {
                        ClusterType = ClusterType
=======
            var cluster1 = new Cluster(id: "id", name: ClusterName + "1")
            {
                Location = Location,
                Properties = new ClusterGetProperties
                {
                    ClusterVersion = "3.6",
                    ClusterState = "Running",
                    ClusterDefinition = new ClusterDefinition
                    {
                        Kind = ClusterType
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                    },
                    QuotaInfo = new QuotaInfo
                    {
                        CoresUsed = 24
                    },
<<<<<<< HEAD
                    OperatingSystemType = OSType.Windows
                }
            };

            var cluster2 = new Cluster
            {
                Id = "id",
                Name = ClusterName + "2",
                Location = Location,
                Properties = new ClusterGetProperties
                {
                    ClusterVersion = "3.1",
                    ClusterState = "Running",
                    ClusterDefinition = new ClusterDefinition
                    {
                        ClusterType = ClusterType
=======
                    OsType = OSType.Linux
                }
            };

            var cluster2 = new Cluster(id: "id", name: ClusterName + "2")
            {
                Location = Location,
                Properties = new ClusterGetProperties
                {
                    ClusterVersion = "3.6",
                    ClusterState = "Running",
                    ClusterDefinition = new ClusterDefinition
                    {
                        Kind = ClusterType
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                    },
                    QuotaInfo = new QuotaInfo
                    {
                        CoresUsed = 24
                    },
<<<<<<< HEAD
                    OperatingSystemType = OSType.Windows
                }
            };

            var listresponse = new ClusterListResponse { Clusters = new[] { cluster1, cluster2 } };
=======
                    OsType = OSType.Linux
                }
            };

            var listresponse = new[] { cluster1, cluster2 };
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
<<<<<<< HEAD
            var cluster1 = new Cluster
            {
                Id = "id",
                Name = ClusterName + "1",
                Location = Location,
                Properties = new ClusterGetProperties
                {
                    ClusterVersion = "3.1",
                    ClusterState = "Running",
                    ClusterDefinition = new ClusterDefinition
                    {
                        ClusterType = ClusterType
=======
            var cluster1 = new Cluster(id: "id", name: ClusterName + "1")
            {
                Location = Location,
                Properties = new ClusterGetProperties
                {
                    ClusterVersion = "3.6",
                    ClusterState = "Running",
                    ClusterDefinition = new ClusterDefinition
                    {
                        Kind = ClusterType
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                    },
                    QuotaInfo = new QuotaInfo
                    {
                        CoresUsed = 24
                    },
<<<<<<< HEAD
                    OperatingSystemType = OSType.Windows
                }
            };

            var cluster2 = new Cluster
            {
                Id = "id",
                Name = ClusterName + "2",
                Location = Location,
                Properties = new ClusterGetProperties
                {
                    ClusterVersion = "3.1",
                    ClusterState = "Running",
                    ClusterDefinition = new ClusterDefinition
                    {
                        ClusterType = ClusterType
=======
                    OsType = OSType.Linux
                }
            };

            var cluster2 = new Cluster(id: "id", name: ClusterName + "2")
            {
                Location = Location,
                Properties = new ClusterGetProperties
                {
                    ClusterVersion = "3.6",
                    ClusterState = "Running",
                    ClusterDefinition = new ClusterDefinition
                    {
                        Kind = ClusterType
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                    },
                    QuotaInfo = new QuotaInfo
                    {
                        CoresUsed = 24
                    },
<<<<<<< HEAD
                    OperatingSystemType = OSType.Windows
                }
            };

            var listresponse = new ClusterListResponse { Clusters = new[] { cluster1, cluster2 } };
=======
                    OsType = OSType.Linux
                }
            };

            var listresponse = new[] { cluster1, cluster2 };
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
