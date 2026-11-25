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

using Microsoft.Azure.Commands.Batch;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;

namespace Microsoft.Azure.Commands.Batch.Test.Subscriptions
{
    public class GetSupportedVirtualMachineSkuTests : RMTestBase
    {
        private readonly GetSupportedVirtualMachineSkuCommand cmdlet;
        private readonly Mock<BatchClient> batchClientMock;
        private readonly Mock<ICommandRuntime> commandRuntimeMock;

        public GetSupportedVirtualMachineSkuTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetSupportedVirtualMachineSkuCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetSupportedSku()
        {
            string location = "westus";

            List<PSSupportedSku> sku = CreateSku();
            batchClientMock.Setup(client => client.GetSupportedVirtualMachineSku(location, default, default)).Returns(sku);

            cmdlet.Location = location;
            cmdlet.ExecuteCmdlet();

            commandRuntimeMock.Verify(r => r.WriteObject(sku, true), Times.Once());
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetSupportedSkusWithODataParameters()
        {
            string location = "westus";

            List<PSSupportedSku> sku = CreateSku();
            batchClientMock.Setup(client => client.GetSupportedVirtualMachineSku(location, 3, "testfilter")).Returns(sku);

            cmdlet.Location = location;
            cmdlet.MaxResultCount = 3;
            cmdlet.Filter = "testfilter";
            cmdlet.ExecuteCmdlet();

            commandRuntimeMock.Verify(r => r.WriteObject(sku, true), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MaxResultCountLimitsTheSizesReturned()
        {
            BatchClient client = ClientWithThreePagesOfSizes(out Mock<ILocationOperations> locations);

            List<PSSupportedSku> sizes = client.GetSupportedVirtualMachineSku("westus2", 5, null);

            Assert.Equal(new[] { "size1", "size2", "size3", "size4", "size5" }, sizes.Select(s => s.Name));
            locations.Verify(l => l.ListSupportedVirtualMachineSkusNextWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()), Times.Never());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MaxResultCountReadsMorePagesOnlyUntilItHasEnough()
        {
            BatchClient client = ClientWithThreePagesOfSizes(out Mock<ILocationOperations> locations);

            List<PSSupportedSku> sizes = client.GetSupportedVirtualMachineSku("westus2", 7, null);

            Assert.Equal(new[] { "size1", "size2", "size3", "size4", "size5", "size6", "size7" }, sizes.Select(s => s.Name));
            locations.Verify(l => l.ListSupportedVirtualMachineSkusNextWithHttpMessagesAsync("page3", It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()), Times.Never());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void WithoutMaxResultCountEveryPageIsRead()
        {
            BatchClient client = ClientWithThreePagesOfSizes(out _);

            List<PSSupportedSku> sizes = client.GetSupportedVirtualMachineSku("westus2", null, null);

            Assert.Equal(13, sizes.Count);
        }

        /// <summary>
        /// A BatchClient over a fake management client that lists 13 sizes on three pages (5, 5 and 3), whatever page
        /// size it is asked for, as the service can when a page holds fewer sizes than asked.
        /// </summary>
        private static BatchClient ClientWithThreePagesOfSizes(out Mock<ILocationOperations> locations)
        {
            locations = new Mock<ILocationOperations>();
            locations.Setup(l => l.ListSupportedVirtualMachineSkusWithHttpMessagesAsync("westus2", It.IsAny<int?>(), It.IsAny<string>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new Microsoft.Rest.Azure.AzureOperationResponse<IPage<SupportedSku>> { Body = new SkuPage("page2", 1, 5) }));
            locations.Setup(l => l.ListSupportedVirtualMachineSkusNextWithHttpMessagesAsync("page2", It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new Microsoft.Rest.Azure.AzureOperationResponse<IPage<SupportedSku>> { Body = new SkuPage("page3", 6, 5) }));
            locations.Setup(l => l.ListSupportedVirtualMachineSkusNextWithHttpMessagesAsync("page3", It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new Microsoft.Rest.Azure.AzureOperationResponse<IPage<SupportedSku>> { Body = new SkuPage(null, 11, 3) }));

            var managementClient = new Mock<IBatchManagementClient>();
            managementClient.Setup(c => c.Location).Returns(locations.Object);
            return new BatchClient(managementClient.Object, new Mock<IResourceManagementClient>().Object);
        }

        private class SkuPage : IPage<SupportedSku>
        {
            private readonly List<SupportedSku> sizes;

            public SkuPage(string nextPageLink, int firstNumber, int count)
            {
                NextPageLink = nextPageLink;
                sizes = Enumerable.Range(firstNumber, count)
                    .Select(n => new SupportedSku(name: "size" + n, familyName: "standardDSv3Family", capabilities: new List<SkuCapability>()))
                    .ToList();
            }

            public string NextPageLink { get; }

            public IEnumerator<SupportedSku> GetEnumerator() => sizes.GetEnumerator();

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
        }

        private List<PSSupportedSku> CreateSku()
        {
            List<PSSupportedSku> sku = new List<PSSupportedSku>()
            {
                new PSSupportedSku("testsku1", "testfamily", new List<PSSkuCapability>()
                {
                    new PSSkuCapability("cap1", "val1"),
                    new PSSkuCapability("cap2", "val2")
                }),
                new PSSupportedSku("testsku2", "testfamily", new List<PSSkuCapability>()
                {
                    new PSSkuCapability("cap1", "val1"),
                }),
                new PSSupportedSku("testsku3", "testfamily", new List<PSSkuCapability>()
                {
                    new PSSkuCapability("cap1", "val1"),
                    new PSSkuCapability("cap2", "val2"),
                    new PSSkuCapability("cap2", "val2")
                }),
                new PSSupportedSku("testsku4", "testfamily", new List<PSSkuCapability>()
                {
                    new PSSkuCapability("cap1", "val1"),
                }),
            };

            return sku;
        }
    }
}