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
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.Commands.Test.Utilities.Common;
using Microsoft.Azure.Management.Resources.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using Xunit;

namespace Microsoft.Azure.Commands.Resources.Test
{
    public class NewAzureResourceGroupDeploymentCommandTests : RMTestBase
    {
        private NewAzureResourceGroupDeploymentCommand cmdlet;

        private Mock<ResourcesClient> resourcesClientMock;

        private Mock<ICommandRuntime> commandRuntimeMock;
        private MockCommandRuntime mockRuntime;

        private string resourceGroupName = "myResourceGroup";

        private string deploymentName = "fooDeployment";

        private string templateFile = @"Resources\sampleTemplateFile.json";

        //private string storageAccountName = "myStorageAccount";

        public NewAzureResourceGroupDeploymentCommandTests()
        {
            resourcesClientMock = new Mock<ResourcesClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new NewAzureResourceGroupDeploymentCommand()
            {
                //CommandRuntime = commandRuntimeMock.Object,
                ResourcesClient = resourcesClientMock.Object
            };
            PSCmdletExtensions.SetCommandRuntimeMock(cmdlet, commandRuntimeMock.Object);
            mockRuntime = new MockCommandRuntime();
            commandRuntimeMock.Setup(f => f.Host).Returns(mockRuntime.Host);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreatesNewPSResourceGroupDeploymentWithUserTemplate()
        {
            CreatePSResourceGroupDeploymentParameters expectedParameters = new CreatePSResourceGroupDeploymentParameters()
            {
                TemplateFile = templateFile,
                DeploymentName = deploymentName,
            };
            CreatePSResourceGroupDeploymentParameters actualParameters = new CreatePSResourceGroupDeploymentParameters();
            PSResourceGroupDeployment expected = new PSResourceGroupDeployment()
            {
                Mode = DeploymentMode.Incremental,
                DeploymentName = deploymentName,
                CorrelationId = "123",
                Outputs = new Dictionary<string, DeploymentVariable>()
                {
                    { "Variable1", new DeploymentVariable() { Value = "true", Type = "bool" } },
                    { "Variable2", new DeploymentVariable() { Value = "10", Type = "int" } },
                    { "Variable3", new DeploymentVariable() { Value = "hello world", Type = "string" } }
                },
                Parameters = new Dictionary<string, DeploymentVariable>()
                {
                    { "Parameter1", new DeploymentVariable() { Value = "true", Type = "bool" } },
                    { "Parameter2", new DeploymentVariable() { Value = "10", Type = "int" } },
                    { "Parameter3", new DeploymentVariable() { Value = "hello world", Type = "string" } }
                },
                ProvisioningState = "Succeeded",
                ResourceGroupName = resourceGroupName,
                TemplateLink = new TemplateLink()
                {
                    ContentVersion = "1.0",
                    Uri = "http://mytemplate.com"
                },
                Timestamp = new DateTime(2014, 2, 13)
            };
            resourcesClientMock.Setup(f => f.ExecuteDeployment(
                It.IsAny<CreatePSResourceGroupDeploymentParameters>()))
                .Returns(expected)
                .Callback((CreatePSResourceGroupDeploymentParameters p) => { actualParameters = p; });

            cmdlet.ResourceGroupName = resourceGroupName;
            cmdlet.Name = expectedParameters.DeploymentName;
            cmdlet.TemplateFile = expectedParameters.TemplateFile;

            cmdlet.ExecuteCmdlet();

            Assert.Equal(expectedParameters.DeploymentName, actualParameters.DeploymentName);
            Assert.Equal(expectedParameters.TemplateFile, actualParameters.TemplateFile);
            Assert.NotNull(actualParameters.TemplateParameterObject);

            commandRuntimeMock.Verify(f => f.WriteObject(expected), Times.Once());
        }
    }
}
