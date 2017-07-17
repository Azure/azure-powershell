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
using System.Net;
using Xunit;

namespace Microsoft.Azure.Commands.HDInsight.Test
{
    public class OMSTests : HDInsightTestBase
    {
        public OMSTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            base.SetupTestsForManagement();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnableOMS()
        {
            SetupConfirmation(commandRuntimeMock);

            var enableOMScmdlet = new EnableAzureHDInsightOMSCommand
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
                c => c.EnableOMS(ResourceGroupName, ClusterName,
                It.Is<ClusterMonitoringRequest>(
                    param => param.WorkspaceId == clusterMonitoringParams.WorkspaceId &&
                                param.PrimaryKey == clusterMonitoringParams.PrimaryKey)))
                .Returns(new OperationResource
                {
                    ErrorInfo = null,
                    StatusCode = HttpStatusCode.OK,
                    State = AsyncOperationState.Succeeded
                })
                .Verifiable();

            enableOMScmdlet.ExecuteCmdlet();

            commandRuntimeMock.Verify(f => f.WriteObject(It.Is<OperationResource>(
                omsout =>
                    omsout.ErrorInfo == null &&
                    omsout.StatusCode == HttpStatusCode.OK &&
                    omsout.State == AsyncOperationState.Succeeded)),
                    Times.Once);

        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetOMS()
        {
            var getOMScmdlet = new GetAzureHDInsightOMSCommand
            {
                CommandRuntime = commandRuntimeMock.Object,
                HDInsightManagementClient = hdinsightManagementMock.Object,
                Name = ClusterName,
                ResourceGroupName = ResourceGroupName
            };

            hdinsightManagementMock.Setup(c => c.GetOMS(ResourceGroupName, ClusterName))
                .Returns(new ClusterMonitoringResponse
                {
                    ClusterMonitoringEnabled = "{ 'ClusterMonitoringEnabled':'true', 'workspaceId':'1d364e89-bb71-4503-aa3d-a23535aea7bd' }"
                })
                .Verifiable();

            getOMScmdlet.ExecuteCmdlet();

            commandRuntimeMock.Verify(f => f.WriteObject(It.Is<AzureHDInsightOMS>(
                omsout =>
                    omsout.ClusterMonitoringEnabled.Contains("1d364e89-bb71-4503-aa3d-a23535aea7bd"))),
                    Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DisableOMS()
        {
            SetupConfirmation(commandRuntimeMock);

            var disableOMScmdlet = new DisableAzureHDInsightOMSCommand
            {
                CommandRuntime = commandRuntimeMock.Object,
                HDInsightManagementClient = hdinsightManagementMock.Object,
                Name = ClusterName,
                ResourceGroupName = ResourceGroupName
            };

            hdinsightManagementMock.Setup(c => c.DisableOMS(ResourceGroupName, ClusterName))
                .Returns(new OperationResource
                {
                    ErrorInfo = null,
                    StatusCode = HttpStatusCode.OK,
                    State = AsyncOperationState.Succeeded
                })
                .Verifiable();

            disableOMScmdlet.ExecuteCmdlet();

            commandRuntimeMock.Verify(f => f.WriteObject(It.Is<OperationResource>(
                omsout =>
                    omsout.ErrorInfo == null &&
                    omsout.StatusCode == HttpStatusCode.OK &&
                    omsout.State == AsyncOperationState.Succeeded)),
                    Times.Once);

        }
    }
}
