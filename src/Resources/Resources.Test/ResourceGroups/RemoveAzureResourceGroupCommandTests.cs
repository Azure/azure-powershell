﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkClient;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Moq;
using System;
using System.Management.Automation;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Resources.Test
{
    public class RemoveAzureResourceGroupCommandTests : RMTestBase
    {
        private RemoveAzureResourceGroupCmdlet cmdlet;

        private Mock<ResourceManagerSdkClient> resourcesClientMock;

        private Mock<ICommandRuntime> commandRuntimeMock;

        private string resourceGroupName = "myResourceGroup";
        private string resourceGroupId = "/subscriptions/subId/resourceGroups/myResourceGroup";
        private string resourceId = "/subscriptions/subId/resourceGroups/myResourceGroup/providers/myResourceProvider/resourceType/myResource";

        public RemoveAzureResourceGroupCommandTests(ITestOutputHelper output)
        {
            resourcesClientMock = new Mock<ResourceManagerSdkClient>();
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new RemoveAzureResourceGroupCmdlet()
            {
                CommandRuntime = commandRuntimeMock.Object,
                ResourceManagerSdkClient = resourcesClientMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemovesResourceGroup()
        {
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            resourcesClientMock.Setup(f => f.DeleteResourceGroup(resourceGroupName));

            cmdlet.Name = resourceGroupName;
            cmdlet.Force = true;

            cmdlet.ExecuteCmdlet();

            resourcesClientMock.Verify(f => f.DeleteResourceGroup(resourceGroupName), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemovesResourceGroupFromId()
        {
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            resourcesClientMock.Setup(f => f.DeleteResourceGroup(resourceGroupName));

            cmdlet.Id = resourceGroupId;
            cmdlet.Force = true;

            cmdlet.ExecuteCmdlet();

            resourcesClientMock.Verify(f => f.DeleteResourceGroup(resourceGroupName), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemovesResourceGroupFromResourceId()
        {
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            resourcesClientMock.Setup(f => f.DeleteResourceGroup(resourceGroupName));

            cmdlet.Id = resourceId;
            cmdlet.Force = true;

            try
            {
                cmdlet.ExecuteCmdlet();
            }
            catch (System.ArgumentException)
            {
                Console.WriteLine("The id should be resourceGroup id");
            }

            resourcesClientMock.Verify(f => f.DeleteResourceGroup(resourceGroupName), Times.Never());
        }
    }
}
