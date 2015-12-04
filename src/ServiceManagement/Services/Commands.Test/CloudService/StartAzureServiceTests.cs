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

using Microsoft.WindowsAzure.Commands.CloudService;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Moq;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.Test.CloudService
{
    public class StartAzureServiceTests : SMTestBase
    {
        private const string serviceName = "AzureService";

        string slot = DeploymentSlotType.Production;

        private MockCommandRuntime mockCommandRuntime;

        private StartAzureServiceCommand stopServiceCmdlet;

        private Mock<ICloudServiceClient> cloudServiceClientMock;

        public StartAzureServiceTests()
        {
            AzurePowerShell.ProfileDirectory = Test.Utilities.Common.Data.AzureSdkAppDir;
            mockCommandRuntime = new MockCommandRuntime();
            cloudServiceClientMock = new Mock<ICloudServiceClient>();

            stopServiceCmdlet = new StartAzureServiceCommand()
            {
                CloudServiceClient = cloudServiceClientMock.Object,
                CommandRuntime = mockCommandRuntime
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStartAzureService()
        {
            stopServiceCmdlet.ServiceName = serviceName;
            stopServiceCmdlet.Slot = slot;
            cloudServiceClientMock.Setup(f => f.StartCloudService(serviceName, slot));

            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                files.CreateAzureSdkDirectoryAndImportPublishSettings();
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                stopServiceCmdlet.ExecuteCmdlet();

                Assert.Equal<int>(0, mockCommandRuntime.OutputPipeline.Count);
                cloudServiceClientMock.Verify(f => f.StartCloudService(serviceName, slot), Times.Once());
            }
        }
    }
}
