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
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Moq;
using System.Collections.Generic;
using System.Management.Automation;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Resources.Test
{
    public class GetAzureResourceGroupCommandTests : RMTestBase
    {
        private GetAzureResourceGroupCmdlet cmdlet;

        private Mock<ResourceManagerSdkClient> resourcesClientMock;

        private Mock<ICommandRuntime> commandRuntimeMock;

        private string resourceGroupName = "myResourceGroup";
        private string resourceGroupId = "/subscriptions/subId/resourceGroups/myResourceGroup";

        private string resourceGroupLocation = "West US";

        public GetAzureResourceGroupCommandTests(ITestOutputHelper output)
        {
            resourcesClientMock = new Mock<ResourceManagerSdkClient>();
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetAzureResourceGroupCmdlet()
            {
                CommandRuntime = commandRuntimeMock.Object,
                ResourceManagerSdkClient = resourcesClientMock.Object
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
                ResourceGroupName = resourceGroupName
            };
            result.Add(expected);
            resourcesClientMock.Setup(f => f.FilterResourceGroups(resourceGroupName, null, false, null)).Returns(result);

            cmdlet.Name = resourceGroupName;

            cmdlet.ExecuteCmdlet();

            Assert.Equal(1, result.Count);
            Assert.Equal(resourceGroupName, result[0].ResourceGroupName);
            Assert.Equal(resourceGroupLocation, result[0].Location);

            commandRuntimeMock.Verify(f => f.WriteObject(result, true), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetsResourcesGroupsById()
        {
            List<PSResourceGroup> result = new List<PSResourceGroup>();
            PSResourceGroup expected = new PSResourceGroup()
            {
                Location = resourceGroupLocation,
                ResourceGroupName = resourceGroupName
            };
            result.Add(expected);
            resourcesClientMock.Setup(f => f.FilterResourceGroups(null, null, true, null)).Returns(result);

            cmdlet.Id = resourceGroupId;

            cmdlet.ExecuteCmdlet();

            Assert.Equal(1, result.Count);
            Assert.Equal(resourceGroupName, result[0].ResourceGroupName);
            Assert.Equal(resourceGroupLocation, result[0].Location);
        }
    }
}
