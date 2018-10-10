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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Resources.Test
{
    public class SetAzureResourceGroupCommandTests : RMTestBase
    {
        private SetAzureResourceGroupCmdlet cmdlet;

        private Mock<ResourceManagerSdkClient> resourcesClientMock;

        private Mock<ICommandRuntime> commandRuntimeMock;

        private string resourceGroupName = "myResourceGroup";
        private string resourceGroupId = "/subscriptions/subId/resourceGroups/myResourceGroup";

        private Hashtable tags;

        public SetAzureResourceGroupCommandTests(ITestOutputHelper output)
        {
            resourcesClientMock = new Mock<ResourceManagerSdkClient>();
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new SetAzureResourceGroupCmdlet()
            {
                CommandRuntime = commandRuntimeMock.Object,
                ResourceManagerSdkClient = resourcesClientMock.Object
            };

            tags = new Hashtable
                {
                    {"value1", ""}
                };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdatesSetPSResourceGroupWithTag()
        {
            PSUpdateResourceGroupParameters expectedParameters = new PSUpdateResourceGroupParameters()
            {
                ResourceGroupName = resourceGroupName,
                Tag = tags
            };
            PSUpdateResourceGroupParameters actualParameters = new PSUpdateResourceGroupParameters();
            PSResourceGroup expected = new PSResourceGroup()
            {
                ResourceGroupName = expectedParameters.ResourceGroupName,
                Tags = expectedParameters.Tag
            };
            resourcesClientMock.Setup(f => f.UpdatePSResourceGroup(It.IsAny<PSUpdateResourceGroupParameters>()))
                .Returns(expected)
                .Callback((PSUpdateResourceGroupParameters p) => { actualParameters = p; });

            cmdlet.Name = expectedParameters.ResourceGroupName;
            cmdlet.Tag = expectedParameters.Tag;

            cmdlet.ExecuteCmdlet();

            Assert.Equal(expectedParameters.ResourceGroupName, actualParameters.ResourceGroupName);
            Assert.Equal(expectedParameters.Tag, actualParameters.Tag);

            commandRuntimeMock.Verify(f => f.WriteObject(expected), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdatesSetPSResourceGroupWithTagFromId()
        {
            PSUpdateResourceGroupParameters expectedParameters = new PSUpdateResourceGroupParameters()
            {
                ResourceGroupName = resourceGroupName,
                Tag = tags
            };
            PSUpdateResourceGroupParameters actualParameters = new PSUpdateResourceGroupParameters();
            PSResourceGroup expected = new PSResourceGroup()
            {
                ResourceGroupName = expectedParameters.ResourceGroupName,
                Tags = expectedParameters.Tag
            };
            resourcesClientMock.Setup(f => f.UpdatePSResourceGroup(It.IsAny<PSUpdateResourceGroupParameters>()))
                .Returns(expected)
                .Callback((PSUpdateResourceGroupParameters p) => { actualParameters = p; });

            cmdlet.Id = resourceGroupId;
            cmdlet.Tag = expectedParameters.Tag;

            cmdlet.ExecuteCmdlet();

            Assert.Equal(expectedParameters.ResourceGroupName, actualParameters.ResourceGroupName);
            Assert.Equal(expectedParameters.Tag, actualParameters.Tag);

            commandRuntimeMock.Verify(f => f.WriteObject(expected), Times.Once());
        }
    }
}
