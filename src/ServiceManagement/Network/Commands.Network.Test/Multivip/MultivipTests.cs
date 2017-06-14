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

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Test.Multivip
{
    using Microsoft.Azure;
    using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS;
    using Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Network;
    using Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Test.TestInterfaces;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using Microsoft.WindowsAzure.Management;
    using Microsoft.WindowsAzure.Management.Compute;
    using Microsoft.WindowsAzure.Management.Compute.Models;
    using Microsoft.WindowsAzure.Management.Network;
    using Microsoft.WindowsAzure.Management.Storage;
    using Moq;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;
    using Assert = Xunit.Assert;

    public class MultivipTests
    {
        private Mock<NetworkManagementClient> networkingClientMock;
        private Mock<ComputeManagementClient> computeClientMock;
        private Mock<ManagementClient> managementClientMock;
        private Mock<StorageManagementClient> storageClientMock;
        private IClientProvider testClientProvider;
        private MockCommandRuntime mockCommandRuntime;
        public const string ServiceName = "ServiceName";
        public const string DeploymentName = "DeploymentName";
        public const string VipName = "VipName";

        public MultivipTests()
        {
            this.networkingClientMock = new Mock<NetworkManagementClient>();
            this.computeClientMock = new Mock<ComputeManagementClient>();
            this.managementClientMock = new Mock<ManagementClient>();
            this.storageClientMock = new Mock<StorageManagementClient>();
            this.mockCommandRuntime = new MockCommandRuntime();
            testClientProvider = new TestClientProvider(this.managementClientMock.Object, this.computeClientMock.Object,
                this.storageClientMock.Object, this.networkingClientMock.Object);

            testClientProvider = new TestClientProvider(this.managementClientMock.Object,
                this.computeClientMock.Object, this.storageClientMock.Object, this.networkingClientMock.Object);

            this.computeClientMock
                .Setup(c => c.Deployments.GetBySlotAsync(ServiceName, DeploymentSlot.Production, It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() => new DeploymentGetResponse()
                {
                    Name = DeploymentName
                }));

            this.networkingClientMock
                .Setup(c => c.VirtualIPs.AddAsync(
                    ServiceName,
                    DeploymentName,
                    VipName,
                    It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() => new OperationStatusResponse()
                {
                    Status = OperationStatus.Succeeded
                }));


            this.networkingClientMock
                .Setup(c => c.VirtualIPs.RemoveAsync(
                    ServiceName,
                    DeploymentName,
                    VipName,
                    It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() => new OperationStatusResponse()
                {
                    Status = OperationStatus.Succeeded
                }));
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AddAzureVirtualIP()
        {
            AddAzureVirtualIP cmdlet = new AddAzureVirtualIP(testClientProvider)
            {
                ServiceName = ServiceName,
                VirtualIPName = VipName,
                CommandRuntime = mockCommandRuntime,
            };

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            computeClientMock.Verify(
                c => c.Deployments.GetBySlotAsync(
                    ServiceName,
                    DeploymentSlot.Production,
                    It.IsAny<CancellationToken>()),
                Times.Once);

            networkingClientMock.Verify(
                c => c.VirtualIPs.AddAsync(
                    ServiceName,
                    DeploymentName,
                    VipName,
                    It.IsAny<CancellationToken>()),
                Times.Once());

            Assert.Equal(1, mockCommandRuntime.OutputPipeline.Count);
            Assert.Equal("Succeeded", ((ManagementOperationContext)mockCommandRuntime.OutputPipeline[0]).OperationStatus);
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveAzureVirtualIP()
        {
            RemoveAzureVirtualIP cmdlet = new RemoveAzureVirtualIP(testClientProvider)
            {
                ServiceName = ServiceName,
                VirtualIPName = VipName,
                CommandRuntime = mockCommandRuntime,
            };

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            computeClientMock.Verify(
                c => c.Deployments.GetBySlotAsync(
                    ServiceName,
                    DeploymentSlot.Production,
                    It.IsAny<CancellationToken>()),
                Times.Once);

            networkingClientMock.Verify(
                c => c.VirtualIPs.RemoveAsync(
                    ServiceName,
                    DeploymentName,
                    VipName,
                    It.IsAny<CancellationToken>()),
                Times.Once());

            Assert.Equal(1, mockCommandRuntime.OutputPipeline.Count);
            Assert.Equal("Succeeded", ((ManagementOperationContext)mockCommandRuntime.OutputPipeline[0]).OperationStatus);
        }
    }
}
