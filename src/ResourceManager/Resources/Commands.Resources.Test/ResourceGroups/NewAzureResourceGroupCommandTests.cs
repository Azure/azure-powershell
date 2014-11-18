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

using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Resources.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using Xunit;

namespace Microsoft.Azure.Commands.Resources.Test
{
    public class NewAzureResourceGroupCommandTests
    {
        private NewAzureResourceGroupCommand cmdlet;

        private Mock<ResourcesClient> resourcesClientMock;

        private Mock<ICommandRuntime> commandRuntimeMock;

        private string resourceGroupName = "myResourceGroup";

        private string resourceGroupLocation = "West US";

        private string deploymentName = "fooDeployment";

        private string templateFile = @"Resources\sampleTemplateFile.json";

        private string storageAccountName = "myStorageAccount";

        private Hashtable[] tags;

        public NewAzureResourceGroupCommandTests()
        {
            resourcesClientMock = new Mock<ResourcesClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new NewAzureResourceGroupCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                ResourcesClient = resourcesClientMock.Object
            };

            tags = new[]
            {
                new Hashtable
                {
                    {"Name", "value1"},
                    {"Value", ""}
                }
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreatesNewPSResourceGroupWithUserTemplate()
        {
            CreatePSResourceGroupParameters expectedParameters = new CreatePSResourceGroupParameters()
            {
                ResourceGroupName = resourceGroupName,
                Location = resourceGroupLocation,
                TemplateFile = templateFile,
                DeploymentName = deploymentName,
                StorageAccountName = storageAccountName,
                TemplateVersion = "1.0",
                Tag = tags
            };
            CreatePSResourceGroupParameters actualParameters = new CreatePSResourceGroupParameters();
            PSResourceGroup expected = new PSResourceGroup()
            {
                Location = expectedParameters.Location,
                ResourceGroupName = expectedParameters.ResourceGroupName,
                Resources = new List<PSResource>() { new PSResource() { Name = "resource1" } },
                Tags = expectedParameters.Tag
            };
            resourcesClientMock.Setup(f => f.CreatePSResourceGroup(It.IsAny<CreatePSResourceGroupParameters>()))
                .Returns(expected)
                .Callback((CreatePSResourceGroupParameters p) => { actualParameters = p; });

            cmdlet.Name = expectedParameters.ResourceGroupName;
            cmdlet.Location = expectedParameters.Location;
            cmdlet.TemplateFile = expectedParameters.TemplateFile;
            cmdlet.DeploymentName = expectedParameters.DeploymentName;
            cmdlet.TemplateVersion = expectedParameters.TemplateVersion;
            cmdlet.Tag = expectedParameters.Tag;

            cmdlet.ExecuteCmdlet();

            Assert.Equal(expectedParameters.ResourceGroupName, actualParameters.ResourceGroupName);
            Assert.Equal(expectedParameters.Location, actualParameters.Location);
            Assert.Equal(expectedParameters.DeploymentName, actualParameters.DeploymentName);
            Assert.Equal(expectedParameters.GalleryTemplateIdentity, actualParameters.GalleryTemplateIdentity);
            Assert.Equal(expectedParameters.TemplateFile, actualParameters.TemplateFile);
            Assert.NotNull(actualParameters.TemplateParameterObject);
            Assert.Equal(expectedParameters.TemplateVersion, actualParameters.TemplateVersion);
            Assert.Equal(null, actualParameters.StorageAccountName);
            Assert.Equal(expectedParameters.Tag, actualParameters.Tag);

            commandRuntimeMock.Verify(f => f.WriteObject(expected), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreatesNewPSResourceGroupWithGalleryTemplate()
        {
            CreatePSResourceGroupParameters expectedParameters = new CreatePSResourceGroupParameters()
            {
                ResourceGroupName = resourceGroupName,
                Location = resourceGroupLocation,
                GalleryTemplateIdentity = "sqlServer",
                DeploymentName = deploymentName,
                StorageAccountName = storageAccountName,
                TemplateVersion = "1.0"
            };
            CreatePSResourceGroupParameters actualParameters = new CreatePSResourceGroupParameters();
            PSResourceGroup expected = new PSResourceGroup()
            {
                Location = expectedParameters.Location,
                ResourceGroupName = expectedParameters.ResourceGroupName,
                Resources = new List<PSResource>() { new PSResource() { Name = "resource1" } }
            };
            resourcesClientMock.Setup(f => f.CreatePSResourceGroup(It.IsAny<CreatePSResourceGroupParameters>()))
                .Returns(expected)
                .Callback((CreatePSResourceGroupParameters p) => { actualParameters = p; });

            cmdlet.Name = expectedParameters.ResourceGroupName;
            cmdlet.Location = expectedParameters.Location;
            cmdlet.GalleryTemplateIdentity = expectedParameters.GalleryTemplateIdentity;
            cmdlet.DeploymentName = expectedParameters.DeploymentName;
            cmdlet.TemplateVersion = expectedParameters.TemplateVersion;

            cmdlet.ExecuteCmdlet();

            Assert.Equal(expectedParameters.ResourceGroupName, actualParameters.ResourceGroupName);
            Assert.Equal(expectedParameters.Location, actualParameters.Location);
            Assert.Equal(expectedParameters.DeploymentName, actualParameters.DeploymentName);
            Assert.Equal(expectedParameters.GalleryTemplateIdentity, actualParameters.GalleryTemplateIdentity);
            Assert.Equal(expectedParameters.TemplateFile, actualParameters.TemplateFile);
            Assert.NotNull(actualParameters.TemplateParameterObject);
            Assert.Equal(expectedParameters.TemplateVersion, actualParameters.TemplateVersion);
            Assert.Equal(null, actualParameters.StorageAccountName);

            commandRuntimeMock.Verify(f => f.WriteObject(expected), Times.Once());
        }
    }
}
