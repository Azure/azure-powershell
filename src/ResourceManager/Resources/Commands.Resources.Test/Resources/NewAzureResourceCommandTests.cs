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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Moq;
using Xunit;

namespace Microsoft.Azure.Commands.Resources.Test
{
    public class NewAzureResourceCommandTests
    {
        private NewAzureResourceCommand cmdlet;

        private Mock<ResourcesClient> resourcesClientMock;

        private Mock<ICommandRuntime> commandRuntimeMock;

        private string resourceName = "myResource";

        private string resourceParentName = "myResourceParent";

        private string resourceGroupName = "myResourceGroup";

        private string resourceType = "Microsoft.Web/sites";

        private string resourceGroupLocation = "West US";

        private Dictionary<string, object> properties;

        private Hashtable[] tags;

        public NewAzureResourceCommandTests()
        {
            resourcesClientMock = new Mock<ResourcesClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new NewAzureResourceCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                ResourcesClient = resourcesClientMock.Object
            };
            properties = new Dictionary<string, object>
                {
                    {"name", "site1"},
                    {"siteMode", "Standard"},
                    {"computeMode", "Dedicated"},
                    {"misc", new Dictionary<string, object>
                        {
                            {"key1", "value1"},
                            {"key2", "value2"}
                        }}
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
            CreatePSResourceParameters expectedParameters = new CreatePSResourceParameters()
            {
                Name = resourceName,
                ParentResource = resourceParentName,
                ResourceType = resourceType,
                ResourceGroupName = resourceGroupName,
                PropertyObject = properties.ToHashtable(),
                Tag = tags
            };
            CreatePSResourceParameters actualParameters = new CreatePSResourceParameters();
            PSResource expected = new PSResource()
            {
                Name = expectedParameters.Name,
                Location = resourceGroupLocation,
                ResourceGroupName = expectedParameters.ResourceGroupName,
                Properties = expectedParameters.PropertyObject,
                ResourceType = expectedParameters.ResourceType,
                Tags = expectedParameters.Tag
            };
            resourcesClientMock.Setup(f => f.CreatePSResource(It.IsAny<CreatePSResourceParameters>()))
                .Returns(expected)
                .Callback((CreatePSResourceParameters p) => { actualParameters = p; });

            cmdlet.Name = expectedParameters.Name;
            cmdlet.ResourceGroupName = expectedParameters.ResourceGroupName;
            cmdlet.ResourceType = expectedParameters.ResourceType;
            cmdlet.ParentResource = expectedParameters.ParentResource;
            cmdlet.PropertyObject = expectedParameters.PropertyObject;
            cmdlet.Tag = expectedParameters.Tag;

            cmdlet.ExecuteCmdlet();

            Assert.Equal(expectedParameters.Name, actualParameters.Name);
            Assert.Equal(expectedParameters.ResourceGroupName, actualParameters.ResourceGroupName);
            Assert.Equal(expectedParameters.ResourceType, actualParameters.ResourceType);
            Assert.Equal(expectedParameters.ParentResource, actualParameters.ParentResource);
            Assert.Equal(expectedParameters.PropertyObject, actualParameters.PropertyObject);
            Assert.Equal(expectedParameters.Tag, actualParameters.Tag);

            commandRuntimeMock.Verify(f => f.WriteObject(expected), Times.Once());
        }
    }
}
