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
using System.Net;
using Xunit;

namespace Microsoft.Azure.Commands.HDInsight.Test
{
    public class ResizeClusterTests : HDInsightTestBase
    {
        private SetAzureHDInsightClusterSizeCommand cmdlet;
        private int targetcount = 4;

        public ResizeClusterTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            base.SetupTestsForManagement();

            cmdlet = new SetAzureHDInsightClusterSizeCommand
            {
                CommandRuntime = commandRuntimeMock.Object,
                HDInsightManagementClient = hdinsightManagementMock.Object,
                ClusterName = ClusterName,
                ResourceGroupName = ResourceGroupName,
                TargetInstanceCount = targetcount
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanResizeCluster()
        {
            var cluster = new Cluster
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
                    },
                    QuotaInfo = new QuotaInfo
                    {
                        CoresUsed = 24
                    },
                    OperatingSystemType = OSType.Windows
                },
            };

            var getresponse = new ClusterGetResponse { Cluster = cluster };
            hdinsightManagementMock.Setup(c => c.Get(ResourceGroupName, ClusterName))
                .Returns(getresponse)
                .Verifiable();

            hdinsightManagementMock.Setup(c => c.GetCluster(It.IsAny<string>(), It.IsAny<string>()))
                .CallBase()
                .Verifiable();

            hdinsightManagementMock.Setup(
                c =>
                    c.ResizeCluster(ResourceGroupName, ClusterName,
                        It.Is<ClusterResizeParameters>(
                            param => param.TargetInstanceCount == targetcount)))
                .Returns(new OperationResource
                {
                    ErrorInfo = null,
                    StatusCode = HttpStatusCode.OK,
                    State = AsyncOperationState.Succeeded
                })
                .Verifiable();

            cmdlet.ExecuteCmdlet();

            commandRuntimeMock.VerifyAll();
            commandRuntimeMock.Verify(f => f.WriteObject(It.Is<AzureHDInsightCluster>(c => c.Name == cluster.Name)),
                Times.Once);
        }
    }
}
