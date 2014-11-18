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
using Microsoft.Azure.Commands.Resources.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using Xunit;

namespace Microsoft.Azure.Commands.Resources.Test
{
    public class RemoveAzureResourceCommandTests
    {
        private RemoveAzureResourceCommand cmdlet;

        private Mock<ResourcesClient> resourcesClientMock;

        private Mock<ICommandRuntime> commandRuntimeMock;

        private string resourceName = "myResource";

        private string resourceParentName = "myResourceParent";

        private string resourceGroupName = "myResourceGroup";

        private string resourceType = "Microsoft.Web/sites";

        public RemoveAzureResourceCommandTests()
        {
            resourcesClientMock = new Mock<ResourcesClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new RemoveAzureResourceCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                ResourcesClient = resourcesClientMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemovesResourceGroup()
        {
            BasePSResourceParameters actualParameters = new BasePSResourceParameters();
            BasePSResourceParameters expectedParameters = new BasePSResourceParameters()
            {
                Name = resourceName,
                ResourceType = resourceType,
                ResourceGroupName = resourceGroupName,
                ParentResource = resourceParentName,
            };

            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            resourcesClientMock
                .Setup(f => f.DeleteResource(It.IsAny<BasePSResourceParameters>()))
                .Callback((BasePSResourceParameters p) =>
                    {
                        actualParameters = p;
                    });

            cmdlet.Name = resourceName;
            cmdlet.ResourceType = resourceType;
            cmdlet.ResourceGroupName = resourceGroupName;
            cmdlet.ParentResource = resourceParentName;
            cmdlet.PassThru = true;
            cmdlet.Force = true;

            cmdlet.ExecuteCmdlet();

            Assert.Equal(expectedParameters.Name, actualParameters.Name);
            Assert.Equal(expectedParameters.ResourceGroupName, actualParameters.ResourceGroupName);
            Assert.Equal(expectedParameters.ResourceType, actualParameters.ResourceType);
            Assert.Equal(expectedParameters.ParentResource, actualParameters.ParentResource);

            commandRuntimeMock.Verify(f => f.WriteObject(true), Times.Once());
        }
    }
}
