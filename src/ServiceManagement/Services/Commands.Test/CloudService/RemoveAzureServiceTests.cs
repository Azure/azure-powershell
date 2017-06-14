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
using Moq;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.Test.CloudService
{
    public class RemoveAzureServiceTests : SMTestBase
    {
        private Mock<ICloudServiceClient> clientMock;

        private Mock<ICommandRuntime> commandRuntimeMock;

        private RemoveAzureServiceCommand removeAzureServiceCmdlet;

        private string serviceName = "cloudService";

        public RemoveAzureServiceTests()
        {
            clientMock = new Mock<ICloudServiceClient>();
            clientMock.Setup(f => f.RemoveCloudService(serviceName, false));

            commandRuntimeMock = new Mock<ICommandRuntime>();
            commandRuntimeMock.Setup(f => f.WriteObject(true));
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            removeAzureServiceCmdlet = new RemoveAzureServiceCommand()
            {
                CloudServiceClient = clientMock.Object,
                CommandRuntime = commandRuntimeMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAzureService()
        {
            // Setup
            removeAzureServiceCmdlet.PassThru = true;
            removeAzureServiceCmdlet.Force = true;
            removeAzureServiceCmdlet.ServiceName = serviceName;

            // Test
            removeAzureServiceCmdlet.ExecuteCmdlet();

            // Assert
            clientMock.Verify(f => f.RemoveCloudService(serviceName, false), Times.Once());
            commandRuntimeMock.Verify(f => f.WriteObject(true), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAzureServiceNoForce()
        {
            // Setup
            removeAzureServiceCmdlet.PassThru = true;
            removeAzureServiceCmdlet.ServiceName = serviceName;

            // Test
            removeAzureServiceCmdlet.ExecuteCmdlet();

            // Assert
            clientMock.Verify(f => f.RemoveCloudService(serviceName, false), Times.Never());
            commandRuntimeMock.Verify(f => f.WriteObject(true), Times.Never());
        }
    }
}