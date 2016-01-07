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

using Microsoft.Azure.Commands.Common.Test.Mocks;
using Microsoft.Azure.Commands.Resources.Models;
using Microsoft.Azure.Commands.Resources.ResourceGroupDeployments;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.Management.Resources.Models;
using Moq;
using System.Collections.Generic;
using System.Management.Automation;
using Xunit;

namespace Microsoft.Azure.Commands.Resources.Test.Resources
{
    public class TestAzureResourceGroupDeploymentCommandTests
    {
        private TestAzureResourceGroupDeploymentCommand cmdlet;

        private Mock<ResourcesClient> resourcesClientMock;

        private Mock<ICommandRuntime> commandRuntimeMock;
        private MockCommandRuntime mockRuntime;

        private string resourceGroupName = "myResourceGroup";

        private string templateFile = @"Resources\sampleTemplateFile.json";

        public TestAzureResourceGroupDeploymentCommandTests()
        {
            resourcesClientMock = new Mock<ResourcesClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new TestAzureResourceGroupDeploymentCommand()
            {
                //CommandRuntime = commandRuntimeMock.Object,
                ResourcesClient = resourcesClientMock.Object
            };
            PSCmdletExtensions.SetCommandRuntimeMock(cmdlet, commandRuntimeMock.Object);
            mockRuntime = new MockCommandRuntime();
            commandRuntimeMock.Setup(f => f.Host).Returns(mockRuntime.Host);
        }

        [Fact]
        public void ValidatesPSResourceGroupDeploymentWithUserTemplate()
        {
            ValidatePSResourceGroupDeploymentParameters expectedParameters = new ValidatePSResourceGroupDeploymentParameters()
            {
                TemplateFile = templateFile
            };
            ValidatePSResourceGroupDeploymentParameters actualParameters = new ValidatePSResourceGroupDeploymentParameters();
            List<PSResourceManagerError> expected = new List<PSResourceManagerError>()
            {
                new PSResourceManagerError()
                {
                    Code = "202",
                    Message = "bad input",
                },
                new PSResourceManagerError()
                {
                    Code = "203",
                    Message = "bad input 2",
                },
                new PSResourceManagerError()
                {
                    Code = "203",
                    Message = "bad input 3",
                }
            };
            resourcesClientMock.Setup(f => f.ValidatePSResourceGroupDeployment(
                It.IsAny<ValidatePSResourceGroupDeploymentParameters>(), DeploymentMode.Incremental))
                .Returns(expected)
                .Callback((ValidatePSResourceGroupDeploymentParameters p, DeploymentMode m) => { actualParameters = p; m = DeploymentMode.Incremental; });

            cmdlet.ResourceGroupName = resourceGroupName;
            cmdlet.TemplateFile = expectedParameters.TemplateFile;

            cmdlet.ExecuteCmdlet();

            Assert.Equal(expectedParameters.TemplateFile, actualParameters.TemplateFile);
            Assert.NotNull(actualParameters.TemplateParameterObject);

            commandRuntimeMock.Verify(f => f.WriteObject(expected, true), Times.Once());
        }
    }
}
