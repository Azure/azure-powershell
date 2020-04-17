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
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System.Collections.Generic;
using System.Management.Automation;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;

namespace Microsoft.Azure.Commands.Batch.Test.PrivateEndpointConnections
{
    public class GetBatchPrivateEndpointConnectionCommandTests : RMTestBase
    {
        private GetBatchPrivateEndpointConnectionCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public GetBatchPrivateEndpointConnectionCommandTests()
        {
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetBatchPrivateEndpointConnectionCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object
            };
        }

        public static PSPrivateEndpointConnection CreateMockPrivateEndpointConnection(string resourceGroupName, string accountName, string name)
        {
            return new PSPrivateEndpointConnection(
                $"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/privateEndpointConnections/{name}",
                name,
                Management.Batch.Models.PrivateEndpointConnectionProvisioningState.Succeeded,
                new PSPrivateEndpoint("subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myrg/providers/Microsoft.Networking/privateEndpoints/myPrivateEndpoint"),
                new PSPrivateLinkServiceConnectionState(Management.Batch.Models.PrivateLinkServiceConnectionStatus.Approved));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListBatchPrivateEndpointConnectionsTest()
        {
            string accountName = "account01";
            string resourceGroup = "resourceGroup";

            PSPrivateEndpointConnection connection1 = CreateMockPrivateEndpointConnection(resourceGroup, accountName, "conn1");
            PSPrivateEndpointConnection connection2 = CreateMockPrivateEndpointConnection(resourceGroup, accountName, "conn2");

            batchClientMock.Setup(b => b.ListPrivateEndpointConnections(resourceGroup, accountName, cmdlet.MaxCount)).Returns(new [] { connection1, connection2 });

            cmdlet.AccountName = accountName;
            cmdlet.ResourceGroupName = resourceGroup;

            cmdlet.ExecuteCmdlet();

            commandRuntimeMock.Verify(r => r.WriteObject(connection1), Times.Once());
            commandRuntimeMock.Verify(r => r.WriteObject(connection2), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchPrivateEndpointConnectionsByResourceIdTest()
        {
            string accountName = "account01";
            string resourceGroup = "resourceGroup";
            string privateEndpointConnectionName = "conn1";

            var expected = CreateMockPrivateEndpointConnection(resourceGroup, accountName, privateEndpointConnectionName);
            var resourceId = expected.Id;

            batchClientMock.Setup(b => b.GetPrivateEndpointConnection(resourceGroup, accountName, privateEndpointConnectionName)).Returns(expected);

            cmdlet.ResourceId = resourceId;
            cmdlet.ExecuteCmdlet();

            commandRuntimeMock.Verify(r => r.WriteObject(expected), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchPrivateEndpointConnectionsByNameTest()
        {
            string accountName = "account01";
            string resourceGroup = "resourceGroup";
            string privateEndpointConnectionName = "conn1";

            var expected = CreateMockPrivateEndpointConnection(resourceGroup, accountName, privateEndpointConnectionName);
            batchClientMock.Setup(b => b.GetPrivateEndpointConnection(resourceGroup, accountName, privateEndpointConnectionName)).Returns(expected);

            cmdlet.AccountName = accountName;
            cmdlet.ResourceGroupName = resourceGroup;
            cmdlet.Name = privateEndpointConnectionName;

            cmdlet.ExecuteCmdlet();

            commandRuntimeMock.Verify(r => r.WriteObject(expected), Times.Once());
        }
    }
}
