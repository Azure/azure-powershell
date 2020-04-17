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

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System.Management.Automation;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;

namespace Microsoft.Azure.Commands.Batch.Test.PrivateEndpointConnections
{
    public class SetBatchPrivateEndpointConnectionCommandTests
    {
        private SetBatchPrivateEndpointConnectionCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public SetBatchPrivateEndpointConnectionCommandTests()
        {
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new SetBatchPrivateEndpointConnectionCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object
            };
        }

        [Theory]
        [InlineData(null)]
        [InlineData("This is a description")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetBatchPrivateEndpointConnectionWithDescriptionsTest(string description)
        {
            string accountName = "account01";
            string resourceGroup = "resourceGroup";
            string privateEndpointConnectionName = "conn1";

            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>())).Returns(true);

            cmdlet.AccountName = accountName;
            cmdlet.ResourceGroupName = resourceGroup;
            cmdlet.Name = privateEndpointConnectionName;
            cmdlet.Status = Management.Batch.Models.PrivateLinkServiceConnectionStatus.Approved;
            cmdlet.Description = description;

            cmdlet.ExecuteCmdlet();

            batchClientMock.Verify(b => b.UpdatePrivateEndpointConnection(resourceGroup, accountName, privateEndpointConnectionName, cmdlet.Status, description), Times.Once());
        }

        [Theory]
        [InlineData(null)]
        [InlineData("This is a description")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetBatchPrivateEndpointConnectionByResourceIdTest(string description)
        {
            string accountName = "account01";
            string resourceGroup = "resourceGroup";
            string privateEndpointConnectionName = "conn1";

            var resourceId = $"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/{resourceGroup}/providers/Microsoft.Batch/batchAccounts/{accountName}/privateEndpointConnections/{privateEndpointConnectionName}";

            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>())).Returns(true);

            cmdlet.ResourceId = resourceId;
            cmdlet.Status = Management.Batch.Models.PrivateLinkServiceConnectionStatus.Approved;
            cmdlet.Description = description;

            cmdlet.ExecuteCmdlet();

            batchClientMock.Verify(b => b.UpdatePrivateEndpointConnection(resourceGroup, accountName, privateEndpointConnectionName, cmdlet.Status, description), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetBatchPrivateEndpointConnectionFromPipelineTest()
        {
            string accountName = "account01";
            string resourceGroup = "resourceGroup";
            string privateEndpointConnectionName = "conn1";
            var conn = GetBatchPrivateEndpointConnectionCommandTests.CreateMockPrivateEndpointConnection(resourceGroup, accountName, privateEndpointConnectionName);

            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>())).Returns(true);

            cmdlet.PrivateEndpointConnection = conn;

            cmdlet.ExecuteCmdlet();

            batchClientMock.Verify(
                b => b.UpdatePrivateEndpointConnection(
                    resourceGroup,
                    accountName,
                    privateEndpointConnectionName,
                    conn.PrivateLinkServiceConnectionState.Status,
                    conn.PrivateLinkServiceConnectionState.Description),
                Times.Once());
        }
    }
}
