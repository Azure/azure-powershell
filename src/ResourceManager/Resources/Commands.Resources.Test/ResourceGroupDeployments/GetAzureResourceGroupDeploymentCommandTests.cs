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
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using Xunit;

namespace Microsoft.Azure.Commands.Resources.Test
{
    public class GetAzureResourceGroupDeploymentCommandTests
    {
        private GetAzureResourceGroupDeploymentCommand cmdlet;

        private Mock<ResourcesClient> resourcesClientMock;

        private Mock<ICommandRuntime> commandRuntimeMock;

        private string resourceGroupName = "myResourceGroup";

        private string deploymentName = "TheDeploymentName";

        public GetAzureResourceGroupDeploymentCommandTests()
        {
            resourcesClientMock = new Mock<ResourcesClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetAzureResourceGroupDeploymentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                ResourcesClient = resourcesClientMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetsResourcesGroupDeployments()
        {
            List<PSResourceGroupDeployment> result = new List<PSResourceGroupDeployment>();
            PSResourceGroupDeployment expected = new PSResourceGroupDeployment()
            {
                DeploymentName = deploymentName,
                CorrelationId = "123",
                ResourceGroupName = resourceGroupName,
                Mode = DeploymentMode.Incremental
            };
            FilterResourceGroupDeploymentOptions options = new FilterResourceGroupDeploymentOptions()
            {
                ResourceGroupName = resourceGroupName
            };
            FilterResourceGroupDeploymentOptions actual = new FilterResourceGroupDeploymentOptions();
            result.Add(expected);
            resourcesClientMock.Setup(f => f.FilterResourceGroupDeployments(It.IsAny<FilterResourceGroupDeploymentOptions>()))
                .Returns(result)
                .Callback((FilterResourceGroupDeploymentOptions o) => { actual = o; });

            cmdlet.ResourceGroupName = resourceGroupName;

            cmdlet.ExecuteCmdlet();

            commandRuntimeMock.Verify(f => f.WriteObject(result, true), Times.Once());
            Assert.Equal(options.DeploymentName, actual.DeploymentName);
            Assert.Equal(options.ExcludedProvisioningStates, actual.ExcludedProvisioningStates);
            Assert.Equal(options.ProvisioningStates, actual.ProvisioningStates);
            Assert.Equal(options.ResourceGroupName, actual.ResourceGroupName);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetSepcificResourcesGroupDeployment()
        {
            FilterResourceGroupDeploymentOptions options = new FilterResourceGroupDeploymentOptions()
            {
                DeploymentName = deploymentName,
                ResourceGroupName = resourceGroupName
            };
            FilterResourceGroupDeploymentOptions actual = new FilterResourceGroupDeploymentOptions();
            List<PSResourceGroupDeployment> result = new List<PSResourceGroupDeployment>();
            PSResourceGroupDeployment expected = new PSResourceGroupDeployment()
            {
                DeploymentName = deploymentName,
                CorrelationId = "123",
                ResourceGroupName = resourceGroupName,
                Mode = DeploymentMode.Incremental
            };
            result.Add(expected);
            resourcesClientMock.Setup(f => f.FilterResourceGroupDeployments(It.IsAny<FilterResourceGroupDeploymentOptions>()))
                .Returns(result)
                .Callback((FilterResourceGroupDeploymentOptions o) => { actual = o; });

            cmdlet.ResourceGroupName = resourceGroupName;
            cmdlet.Name = deploymentName;

            cmdlet.ExecuteCmdlet();

            commandRuntimeMock.Verify(f => f.WriteObject(result, true), Times.Once());
            Assert.Equal(options.DeploymentName, actual.DeploymentName);
            Assert.Equal(options.ExcludedProvisioningStates, actual.ExcludedProvisioningStates);
            Assert.Equal(options.ProvisioningStates, actual.ProvisioningStates);
            Assert.Equal(options.ResourceGroupName, actual.ResourceGroupName);
        }
    }
}
