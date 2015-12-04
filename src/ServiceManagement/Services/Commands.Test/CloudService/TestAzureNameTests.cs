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
using Xunit;
using Microsoft.WindowsAzure.Commands.CloudService;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.Utilities.ServiceBus;
using Microsoft.WindowsAzure.Commands.Utilities.Websites;
using Moq;

namespace Microsoft.WindowsAzure.Commands.Test.CloudService
{
    public class TestAzureNameTests : SMTestBase
    {
        private Mock<ICloudServiceClient> cloudServiceClientMock;
        private Mock<IWebsitesClient> websitesClientMock;
        MockCommandRuntime commandRuntimeMock;
        TestAzureNameCommand cmdlet;
        Mock<ServiceBusClientExtensions> serviceBusClientMock;
        string subscriptionId = "my subscription Id";

        public TestAzureNameTests()
        {
            cloudServiceClientMock = new Mock<ICloudServiceClient>();
            commandRuntimeMock = new MockCommandRuntime();
            serviceBusClientMock = new Mock<ServiceBusClientExtensions>();
            websitesClientMock = new Mock<IWebsitesClient>();

            cmdlet = new TestAzureNameCommand()
            {
                CommandRuntime = commandRuntimeMock,
                ServiceBusClient = serviceBusClientMock.Object,
                CloudServiceClient = cloudServiceClientMock.Object,
                WebsitesClient = websitesClientMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureServiceNameUsed()
        {
            string name = "test";
            cloudServiceClientMock.Setup(f => f.CheckHostedServiceNameAvailability(name)).Returns(false);

            cmdlet.IsDNSAvailable(null, name);

            bool actual = (bool)commandRuntimeMock.OutputPipeline[0];
            Assert.True(actual);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureServiceNameIsNotUsed()
        {
            string name = "test";
            cloudServiceClientMock.Setup(f => f.CheckHostedServiceNameAvailability(name)).Returns(true);

            cmdlet.IsDNSAvailable(null, name);

            bool actual = (bool)commandRuntimeMock.OutputPipeline[0];
            Assert.False(actual);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureStorageNameUsed()
        {
            string name = "test";
            cloudServiceClientMock.Setup(f => f.CheckStorageServiceAvailability(name)).Returns(false);

            cmdlet.IsStorageServiceAvailable(null, name);

            bool actual = (bool)commandRuntimeMock.OutputPipeline[0];
            Assert.True(actual);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureStorageNameIsNotUsed()
        {
            string name = "test";
            cloudServiceClientMock.Setup(f => f.CheckStorageServiceAvailability(name)).Returns(true);

            cmdlet.IsStorageServiceAvailable(null, name);

            bool actual = (bool)commandRuntimeMock.OutputPipeline[0];
            Assert.False(actual);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureServiceBusNamespaceUsed()
        {
            string name = "test";
            serviceBusClientMock.Setup(f => f.IsAvailableNamespace(name)).Returns(false);

            cmdlet.IsServiceBusNamespaceAvailable(subscriptionId, name);

            bool actual = (bool)commandRuntimeMock.OutputPipeline[0];

            Assert.True(actual);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureServiceBusNamespaceIsNotUsed()
        {
            string name = "test";
            serviceBusClientMock.Setup(f => f.IsAvailableNamespace(name)).Returns(true);

            cmdlet.IsServiceBusNamespaceAvailable(subscriptionId, name);

            bool actual = (bool)commandRuntimeMock.OutputPipeline[0];
            
            Assert.False(actual);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureWebsiteNameUsed()
        {
            string name = "test";
            websitesClientMock.Setup(f => f.CheckWebsiteNameAvailability(name)).Returns(false);

            cmdlet.IsWebsiteAvailable(name);

            bool actual = (bool)commandRuntimeMock.OutputPipeline[0];
            Assert.True(actual);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureWebsiteNameIsNotUsed()
        {
            string name = "test";
            websitesClientMock.Setup(f => f.CheckWebsiteNameAvailability(name)).Returns(true);

            cmdlet.IsWebsiteAvailable(name);

            bool actual = (bool)commandRuntimeMock.OutputPipeline[0];
            Assert.False(actual);
        }
    }
}
