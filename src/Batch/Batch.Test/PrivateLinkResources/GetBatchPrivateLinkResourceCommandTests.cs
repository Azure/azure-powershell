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

namespace Microsoft.Azure.Commands.Batch.Test.PrivateLinkResources
{
    public class GetBatchPrivateLinkResourceCommandTests : RMTestBase
    {
        private GetBatchPrivateLinkResourceCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public GetBatchPrivateLinkResourceCommandTests()
        {
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetBatchPrivateLinkResourceCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object
            };
        }

        public static PSPrivateLinkResource CreateMockPrivateLinkResource(string resourceGroupName, string accountName, string name)
        {
            return new PSPrivateLinkResource(
                $"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/privateLinkResources/{name}",
                name,
                "batchAccount",
                new List<string> { "batchAccount" },
                new List<string> { "privatelink.japaneast.batch.azure.com" });
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListBatchPrivateEndpointConnectionsTest()
        {
            string accountName = "account01";
            string resourceGroup = "resourceGroup";

            var pls1 = CreateMockPrivateLinkResource(resourceGroup, accountName, "pls1");
            var pls2 = CreateMockPrivateLinkResource(resourceGroup, accountName, "pls2");

            batchClientMock.Setup(b => b.ListPrivateLinkResources(resourceGroup, accountName, cmdlet.MaxCount)).Returns(new [] { pls1, pls2});

            cmdlet.AccountName = accountName;
            cmdlet.ResourceGroupName = resourceGroup;

            cmdlet.ExecuteCmdlet();

            commandRuntimeMock.Verify(r => r.WriteObject(pls1), Times.Once());
            commandRuntimeMock.Verify(r => r.WriteObject(pls2), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchPrivateEndpointConnectionsByResourceIdTest()
        {
            string accountName = "account01";
            string resourceGroup = "resourceGroup";
            string privateLinkResourceName = "pls1";

            var expected = CreateMockPrivateLinkResource(resourceGroup, accountName, privateLinkResourceName);
            var resourceId = expected.Id;

            batchClientMock.Setup(b => b.GetPrivateLinkResource(resourceGroup, accountName, privateLinkResourceName)).Returns(expected);

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
            string privateLinkResourceName = "pls1";

            var expected = CreateMockPrivateLinkResource(resourceGroup, accountName, privateLinkResourceName);
            batchClientMock.Setup(b => b.GetPrivateLinkResource(resourceGroup, accountName, privateLinkResourceName)).Returns(expected);

            cmdlet.AccountName = accountName;
            cmdlet.ResourceGroupName = resourceGroup;
            cmdlet.Name = privateLinkResourceName;

            cmdlet.ExecuteCmdlet();

            commandRuntimeMock.Verify(r => r.WriteObject(expected), Times.Once());
        }
    }
}
