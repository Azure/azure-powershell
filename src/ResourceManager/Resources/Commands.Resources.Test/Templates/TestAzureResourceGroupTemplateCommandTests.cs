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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Resources.Models;
using Microsoft.Azure.Commands.Resources.ResourceGroupDeployments;
using Moq;
using Xunit;

namespace Microsoft.Azure.Commands.Resources.Test.Resources
{
    public class TestAzureResourceGroupTemplateCommandTests
    {
        private TestAzureResourceGroupTemplateCommand cmdlet;

        private Mock<ResourcesClient> resourcesClientMock;

        private Mock<ICommandRuntime> commandRuntimeMock;

        private string resourceGroupName = "myResourceGroup";

        private string templateFile = @"Resources\sampleTemplateFile.json";

        private string storageAccountName = "myStorageAccount";

        public TestAzureResourceGroupTemplateCommandTests()
        {
            resourcesClientMock = new Mock<ResourcesClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new TestAzureResourceGroupTemplateCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                ResourcesClient = resourcesClientMock.Object
            };
        }

        [Fact]
        public void ValidatesPSResourceGroupDeploymentWithUserTemplate()
        {
            ValidatePSResourceGroupDeploymentParameters expectedParameters = new ValidatePSResourceGroupDeploymentParameters()
            {
                TemplateFile = templateFile,
                StorageAccountName = storageAccountName,
                TemplateVersion = "1.0"
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
                It.IsAny<ValidatePSResourceGroupDeploymentParameters>()))
                .Returns(expected)
                .Callback((ValidatePSResourceGroupDeploymentParameters p) => { actualParameters = p; });

            cmdlet.ResourceGroupName = resourceGroupName;
            cmdlet.TemplateFile = expectedParameters.TemplateFile;
            cmdlet.TemplateVersion = expectedParameters.TemplateVersion;

            cmdlet.ExecuteCmdlet();

            Assert.Equal(expectedParameters.GalleryTemplateIdentity, actualParameters.GalleryTemplateIdentity);
            Assert.Equal(expectedParameters.TemplateFile, actualParameters.TemplateFile);
            Assert.NotNull(actualParameters.TemplateParameterObject);
            Assert.Equal(expectedParameters.TemplateVersion, actualParameters.TemplateVersion);
            Assert.Equal(null, actualParameters.StorageAccountName);

            commandRuntimeMock.Verify(f => f.WriteObject(expected), Times.Once());
        }

        [Fact]
        public void ValidatesPSResourceGroupDeploymentWithGalleryTemplate()
        {
            ValidatePSResourceGroupDeploymentParameters expectedParameters = new ValidatePSResourceGroupDeploymentParameters()
            {
                GalleryTemplateIdentity = "sqlServer",
                StorageAccountName = storageAccountName,
                TemplateVersion = "1.0"
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
                It.IsAny<ValidatePSResourceGroupDeploymentParameters>()))
                .Returns(expected)
                .Callback((ValidatePSResourceGroupDeploymentParameters p) => { actualParameters = p; });

            cmdlet.ResourceGroupName = resourceGroupName;
            cmdlet.GalleryTemplateIdentity = expectedParameters.GalleryTemplateIdentity;
            cmdlet.TemplateVersion = expectedParameters.TemplateVersion;

            cmdlet.ExecuteCmdlet();

            Assert.Equal(expectedParameters.GalleryTemplateIdentity, actualParameters.GalleryTemplateIdentity);
            Assert.Equal(expectedParameters.TemplateFile, actualParameters.TemplateFile);
            Assert.NotNull(actualParameters.TemplateParameterObject);
            Assert.Equal(expectedParameters.TemplateVersion, actualParameters.TemplateVersion);
            Assert.Equal(null, actualParameters.StorageAccountName);

            commandRuntimeMock.Verify(f => f.WriteObject(expected), Times.Once());
        }
    }
}
