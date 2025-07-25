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
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkClient;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Resources.Test.Resources
{
    public class StopAzureResourceGroupDeploymentCommandTests : RMTestBase
    {
        private StopAzureResourceGroupDeploymentCmdlet cmdlet;

        private Mock<NewResourceManagerSdkClient> resourcesClientMock;

        private Mock<ICommandRuntime> commandRuntimeMock;

        private string resourceGroupName = "myResourceGroup";

        private string deploymentName = "myDeployment";

        public StopAzureResourceGroupDeploymentCommandTests(ITestOutputHelper output)
        {
            resourcesClientMock = new Mock<NewResourceManagerSdkClient>();
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new StopAzureResourceGroupDeploymentCmdlet()
            {
                CommandRuntime = commandRuntimeMock.Object,
                NewResourceManagerSdkClient = resourcesClientMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void StopsActiveDeployment()
        {
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            resourcesClientMock.Setup(f => f.CancelDeployment(It.IsAny<FilterDeploymentOptions>()));

            cmdlet.ResourceGroupName = resourceGroupName;
            cmdlet.Name = deploymentName;

            cmdlet.ExecuteCmdlet();

            resourcesClientMock.Verify(
                f => f.CancelDeployment(It.Is<FilterDeploymentOptions>(
                    options => options.ScopeType == DeploymentScopeType.ResourceGroup
                        && options.ResourceGroupName == resourceGroupName
                        && options.DeploymentName == deploymentName)),
                Times.Once());
        }
    }
}
