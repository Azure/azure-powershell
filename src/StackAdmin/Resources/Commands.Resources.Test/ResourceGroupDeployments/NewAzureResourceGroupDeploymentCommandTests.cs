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

using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkClient;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Azure.ServiceManagemenet.Common.Models;

namespace Microsoft.Azure.Commands.Resources.Test
{
    public class NewAzureResourceGroupDeploymentCommandTests : RMTestBase
    {
        private NewAzureResourceGroupDeploymentCmdlet cmdlet;

        private Mock<ResourceManagerSdkClient> resourcesClientMock;

        private Mock<ICommandRuntime> commandRuntimeMock;

        private string resourceGroupName = "myResourceGroup";

        private string deploymentName = "fooDeployment";

        private string templateFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\sampleTemplateFile.json");

        private string storageAccountName = "myStorageAccount";

        public NewAzureResourceGroupDeploymentCommandTests(ITestOutputHelper output)
        {
            resourcesClientMock = new Mock<ResourceManagerSdkClient>();
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            commandRuntimeMock = new Mock<ICommandRuntime>();
            SetupConfirmation(commandRuntimeMock);
            cmdlet = new NewAzureResourceGroupDeploymentCmdlet()
            {
                CommandRuntime = commandRuntimeMock.Object,
                ResourceManagerSdkClient = resourcesClientMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreatesNewPSResourceGroupDeploymentWithUserTemplate()
        {
            PSCreateResourceGroupDeploymentParameters expectedParameters = new PSCreateResourceGroupDeploymentParameters()
            {
                TemplateFile = templateFile,
                DeploymentName = deploymentName,
            };
            PSCreateResourceGroupDeploymentParameters actualParameters = new PSCreateResourceGroupDeploymentParameters();
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
                ProvisioningState = ProvisioningState.Succeeded.ToString(),
                ResourceGroupName = resourceGroupName,
                TemplateLink = new TemplateLink()
                {
                    ContentVersion = "1.0",
                    Uri = "http://mytemplate.com"
                },
                Timestamp = new DateTime(2014, 2, 13)
            };
            resourcesClientMock.Setup(f => f.ExecuteDeployment(
                It.IsAny<PSCreateResourceGroupDeploymentParameters>()))
                .Returns(expected)
                .Callback((PSCreateResourceGroupDeploymentParameters p) => { actualParameters = p; });

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
