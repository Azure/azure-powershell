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

using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.CloudService;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService.Model;
using Moq;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.Test.CloudService
{
    public class PublishAzureServiceTests : SMTestBase
    {
        private Mock<ICloudServiceClient> clientMock;

        private Mock<ICommandRuntime> commandRuntimeMock;

        private PublishAzureServiceProjectCommand publishAzureServiceCmdlet;

        private string serviceName = "cloudService";

        public PublishAzureServiceTests()
        {
            clientMock = new Mock<ICloudServiceClient>();
            clientMock.Setup(f => f.PublishCloudService(serviceName, null, null, null, null, null, false, false))
                .Returns(new Deployment());

            commandRuntimeMock = new Mock<ICommandRuntime>();

            publishAzureServiceCmdlet = new PublishAzureServiceProjectCommand()
            {
                CloudServiceClient = clientMock.Object,
                CommandRuntime = commandRuntimeMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPublishAzureService()
        {
            // Setup
            publishAzureServiceCmdlet.ServiceName = serviceName;

            // Test
            publishAzureServiceCmdlet.ExecuteCmdlet();

            // Assert
            clientMock.Verify(f => f.PublishCloudService(serviceName, null, null, null, null, null, false, false), Times.Once());
            commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<Deployment>()), Times.Once());
        }
    }
}