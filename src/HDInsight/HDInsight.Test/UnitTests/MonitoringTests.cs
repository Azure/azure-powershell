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

using Microsoft.Azure.Management.HDInsight.Models;
using Microsoft.Azure.Commands.HDInsight.Models.Management;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using Xunit;

namespace Microsoft.Azure.Commands.HDInsight.Test
{
    public class MonitoringTests : HDInsightTestBase
    {
        public MonitoringTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagement.Common.Models.XunitTracingInterceptor(output));
            base.SetupTestsForManagement();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnableMonitoring()
        {
            SetupConfirmation(commandRuntimeMock);

            var enableMonitoringcmdlet = new EnableAzureHDInsightMonitoringCommand
            {
                CommandRuntime = commandRuntimeMock.Object,
                HDInsightManagementClient = hdinsightManagementMock.Object,
                Name = ClusterName,
                ResourceGroupName = ResourceGroupName, 
                WorkspaceId = "",
                PrimaryKey = ""
            };

            var clusterMonitoringParams = new ClusterMonitoringRequest
            {
                WorkspaceId = "",
                PrimaryKey = ""
            };

            hdinsightManagementMock.Setup(
                c => c.EnableMonitoring(ResourceGroupName, ClusterName,
                It.Is<ClusterMonitoringRequest>(
                    param => param.WorkspaceId == clusterMonitoringParams.WorkspaceId &&
                                param.PrimaryKey == clusterMonitoringParams.PrimaryKey)))
                .Verifiable();

            enableMonitoringcmdlet.ExecuteCmdlet();

            commandRuntimeMock.Verify(f => f.WriteObject(It.Is<bool>(omsout => omsout == true)), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetMonitoring()
        {
            var getMonitoringcmdlet = new GetAzureHDInsightMonitoringCommand
            {
                CommandRuntime = commandRuntimeMock.Object,
                HDInsightManagementClient = hdinsightManagementMock.Object,
                Name = ClusterName,
                ResourceGroupName = ResourceGroupName
            };

            hdinsightManagementMock.Setup(c => c.GetMonitoring(ResourceGroupName, ClusterName))
                .Returns(new ClusterMonitoringResponse
                {
                    ClusterMonitoringEnabled = true,
                    WorkspaceId = "1d364e89-bb71-4503-aa3d-a23535aea7bd"
                })
                .Verifiable();

            getMonitoringcmdlet.ExecuteCmdlet();

            commandRuntimeMock.Verify(f => f.WriteObject(It.Is<AzureHDInsightMonitoring>(
                omsout =>
                    omsout.ClusterMonitoringEnabled == true &&
                    omsout.WorkspaceId == "1d364e89-bb71-4503-aa3d-a23535aea7bd")),
                    Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DisableMonitoring()
        {
            SetupConfirmation(commandRuntimeMock);

            var disableMonitoringcmdlet = new DisableAzureHDInsightMonitoringCommand
            {
                CommandRuntime = commandRuntimeMock.Object,
                HDInsightManagementClient = hdinsightManagementMock.Object,
                Name = ClusterName,
                ResourceGroupName = ResourceGroupName
            };

            hdinsightManagementMock.Setup(c => c.DisableMonitoring(ResourceGroupName, ClusterName)).Verifiable();

            disableMonitoringcmdlet.ExecuteCmdlet();

            commandRuntimeMock.Verify(f => f.WriteObject(It.Is<bool>(omsout => omsout == true)), Times.Once);

        }
    }
}
