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
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using Xunit;

namespace Microsoft.Azure.Commands.Resources.Test
{
    public class GetAzureResourceGroupCommandTests
    {
        private GetAzureResourceGroupCommand cmdlet;

        private Mock<ResourcesClient> resourcesClientMock;

        private Mock<ICommandRuntime> commandRuntimeMock;

        private string resourceGroupName = "myResourceGroup";

        private string resourceGroupLocation = "West US";

        public GetAzureResourceGroupCommandTests()
        {
            resourcesClientMock = new Mock<ResourcesClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetAzureResourceGroupCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                ResourcesClient = resourcesClientMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetsResourcesGroups()
        {
            List<PSResourceGroup> result = new List<PSResourceGroup>();
            PSResourceGroup expected = new PSResourceGroup()
            {
                Location = resourceGroupLocation,
                ResourceGroupName = resourceGroupName,
                Resources = new List<PSResource>() { new PSResource() { Name = "resource1" } }
            };
            result.Add(expected);
            resourcesClientMock.Setup(f => f.FilterResourceGroups(resourceGroupName, null, true)).Returns(result);

            cmdlet.Name = resourceGroupName;

            cmdlet.ExecuteCmdlet();

            Assert.Equal(1, result.Count);
            Assert.Equal(resourceGroupName, result[0].ResourceGroupName);
            Assert.Equal(resourceGroupLocation, result[0].Location);
            Assert.Equal(1, result[0].Resources.Count);

            commandRuntimeMock.Verify(f => f.WriteObject(result, true), Times.Once());
        }
    }
}
