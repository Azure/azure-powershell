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

//using Microsoft.Azure.Commands.Common.Test.Mocks;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkClient;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System.Management.Automation;
using Xunit;

namespace Microsoft.Azure.Commands.Resources.Test.Resources
{
    public class StopAzureResourceGroupDeploymentCommandTests
    {
        private StopAzureResourceGroupDeploymentCmdlet cmdlet;

        private Mock<ResourceManagerSdkClient> resourcesClientMock;

        private Mock<ICommandRuntime> commandRuntimeMock;
        private MockCommandRuntime mockRuntime;

        private string resourceGroupName = "myResourceGroup";

        public StopAzureResourceGroupDeploymentCommandTests()
        {
            resourcesClientMock = new Mock<ResourceManagerSdkClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new StopAzureResourceGroupDeploymentCmdlet()
            {
                //CommandRuntime = commandRuntimeMock.Object,
                ResourceManagerSdkClient = resourcesClientMock.Object
            };
            PSCmdletExtensions.SetCommandRuntimeMock(cmdlet, commandRuntimeMock.Object); 
            mockRuntime = new MockCommandRuntime(); 
            commandRuntimeMock.Setup(f => f.Host).Returns(mockRuntime.Host); 

        }

        [Fact]
        public void StopsActiveDeployment()
        {
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            
            cmdlet.ResourceGroupName = resourceGroupName;
            cmdlet.Force = true;

            cmdlet.ExecuteCmdlet();

            commandRuntimeMock.Verify(f => f.WriteObject(true), Times.Once());
        }
    }
}
