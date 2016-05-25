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

using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkClient;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.Azure.Management.ResourceManager.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Azure.ServiceManagemenet.Common.Models;

namespace Microsoft.Azure.Commands.Resources.Test.Resources
{
    public class TestAzureResourceGroupDeploymentCommandTests
    {
        private TestAzureResourceGroupDeploymentCmdlet cmdlet;

        private Mock<ResourceManagerSdkClient> resourcesClientMock;

        private Mock<ICommandRuntime> commandRuntimeMock;

        private string resourceGroupName = "myResourceGroup";

        private string templateFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\sampleTemplateFile.json");

        public TestAzureResourceGroupDeploymentCommandTests(ITestOutputHelper output)
        {
            resourcesClientMock = new Mock<ResourceManagerSdkClient>();
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new TestAzureResourceGroupDeploymentCmdlet()
            {
                CommandRuntime = commandRuntimeMock.Object,
                ResourceManagerSdkClient = resourcesClientMock.Object
            };
        }

        [Fact]
        public void ValidatesPSResourceGroupDeploymentWithUserTemplate()
        {
            PSValidateResourceGroupDeploymentParameters expectedParameters = new PSValidateResourceGroupDeploymentParameters()
            {
                TemplateFile = templateFile
            };
            PSValidateResourceGroupDeploymentParameters actualParameters = new PSValidateResourceGroupDeploymentParameters();
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
                It.IsAny<PSValidateResourceGroupDeploymentParameters>(), DeploymentMode.Incremental))
                .Returns(expected)
                .Callback((PSValidateResourceGroupDeploymentParameters p, DeploymentMode m) => { actualParameters = p; m = DeploymentMode.Incremental; });

            cmdlet.ResourceGroupName = resourceGroupName;
            cmdlet.TemplateFile = expectedParameters.TemplateFile;

            cmdlet.ExecuteCmdlet();

            Assert.Equal(expectedParameters.TemplateFile, actualParameters.TemplateFile);
            Assert.NotNull(actualParameters.TemplateParameterObject);

            commandRuntimeMock.Verify(f => f.WriteObject(expected), Times.Once());
        }
    }
}
