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

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Test.ReservedIP
{
    using Microsoft.Azure;
    using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS;
    using Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Test.TestInterfaces;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using Microsoft.WindowsAzure.Management;
    using Microsoft.WindowsAzure.Management.Compute;
    using Microsoft.WindowsAzure.Management.Compute.Models;
    using Microsoft.WindowsAzure.Management.Network;
    using Microsoft.WindowsAzure.Management.Network.Models;
    using Microsoft.WindowsAzure.Management.Storage;
    using Moq;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;
    using Assert = Xunit.Assert;

    public class ReservedIPTest
    {
        private MockCommandRuntime mockCommandRuntime;

        public const string ServiceName = "ServiceName";
        public const string DeploymentName = "DeploymentName";
        public const string ReservedIPName = "ReservedIPName";
        public const string ReservedIPLocation = "West US";
        public const string ReservedIPLabel = "SomeLabel";
        public const string VipName = "VipName";
        private Mock<NetworkManagementClient> networkingClientMock;
        private Mock<ComputeManagementClient> computeClientMock;
        private Mock<ManagementClient> managementClientMock;
        private Mock<StorageManagementClient> storageClientMock;
        private IClientProvider testClientProvider;


        public ReservedIPTest()
        {
            this.networkingClientMock = new Mock<NetworkManagementClient>();
            this.computeClientMock = new Mock<ComputeManagementClient>();
            this.managementClientMock = new Mock<ManagementClient>();
            this.storageClientMock = new Mock<StorageManagementClient>();
            this.mockCommandRuntime = new MockCommandRuntime();
            
            testClientProvider = new TestClientProvider(this.managementClientMock.Object,
                this.computeClientMock.Object, this.storageClientMock.Object, this.networkingClientMock.Object);

            this.computeClientMock
                .Setup(c => c.Deployments.GetBySlotAsync(ServiceName, DeploymentSlot.Production, It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() => new DeploymentGetResponse()
                {
                    Name = DeploymentName
                }));

            this.computeClientMock
                .Setup(
                    c =>
                        c.Deployments.GetBySlotAsync(ServiceName, DeploymentSlot.Staging,
                            It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() => new DeploymentGetResponse()
                {
                    Name = DeploymentName
                }));

            // Reserve IP simple
            this.networkingClientMock
                .Setup(c => c.ReservedIPs.CreateAsync(
                    It.Is<NetworkReservedIPCreateParameters>(
                        p =>
                            string.Equals(p.Name, ReservedIPName) && string.IsNullOrEmpty(p.ServiceName) &&
                            string.IsNullOrEmpty(p.VirtualIPName) && string.IsNullOrEmpty(p.DeploymentName)),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() => new OperationStatusResponse()
                {
                    Status = OperationStatus.Succeeded
                }));

            // Reserve in use IP single vip
            this.networkingClientMock
                .Setup(c => c.ReservedIPs.CreateAsync(
                    It.Is<NetworkReservedIPCreateParameters>(
                        p =>
                            string.Equals(p.Name, ReservedIPName) && string.Equals(p.ServiceName, ServiceName) &&
                            string.IsNullOrEmpty(p.VirtualIPName) && string.Equals(p.DeploymentName, DeploymentName)),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() => new OperationStatusResponse()
                {
                    Status = OperationStatus.Succeeded
                }));

            // Reserve in use IP named vip
            this.networkingClientMock
                .Setup(c => c.ReservedIPs.CreateAsync(
                    It.Is<NetworkReservedIPCreateParameters>(
                        p =>
                            string.Equals(p.Name, ReservedIPName) && string.Equals(p.ServiceName, ServiceName) &&
                            string.Equals(p.VirtualIPName, VipName) && string.Equals(p.DeploymentName, DeploymentName)),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() => new OperationStatusResponse()
                {
                    Status = OperationStatus.Succeeded
                }));

            // Associate a reserved IP with a deployment
            this.networkingClientMock
                .Setup(c => c.ReservedIPs.AssociateAsync(
                    ReservedIPName,
                    It.Is<NetworkReservedIPMobilityParameters>(
                        p => string.Equals(p.ServiceName, ServiceName) &&
                            string.IsNullOrEmpty(p.VirtualIPName) && string.Equals(p.DeploymentName, DeploymentName)),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() => new OperationStatusResponse()
                {
                    Status = OperationStatus.Succeeded
                }));


            // Associate a reserved IP with a vip
            this.networkingClientMock
                .Setup(c => c.ReservedIPs.AssociateAsync(
                    ReservedIPName,
                    It.Is<NetworkReservedIPMobilityParameters>(
                        p => string.Equals(p.ServiceName, ServiceName) &&
                            string.Equals(p.VirtualIPName, VipName) && string.Equals(p.DeploymentName, DeploymentName)),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() => new OperationStatusResponse()
                {
                    Status = OperationStatus.Succeeded
                }));


            // Remove Azure Reserved IP
            this.networkingClientMock
                .Setup(c => c.ReservedIPs.DeleteAsync(
                   ReservedIPName,
                    It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() => new OperationStatusResponse()
                {
                    Status = OperationStatus.Succeeded
                }));
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureReservedIPSimple()
        {
            NewAzureReservedIPCmdlet cmdlet = new NewAzureReservedIPCmdlet(testClientProvider)
            {
                ReservedIPName = ReservedIPName,
                Location = "WestUS",
                Label = ReservedIPLabel,
                CommandRuntime = mockCommandRuntime,
            };

            cmdlet.SetParameterSet(NewAzureReservedIPCmdlet.ReserveNewIPParamSet);

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            computeClientMock.Verify(
                c => c.Deployments.GetBySlotAsync(
                    ServiceName,
                    DeploymentSlot.Production,
                    It.IsAny<CancellationToken>()),
                Times.Never);

            networkingClientMock.Verify(
                c => c.ReservedIPs.CreateAsync(
                    It.Is<NetworkReservedIPCreateParameters>(
                        p =>
                            string.Equals(p.Name, ReservedIPName) && string.IsNullOrEmpty(p.ServiceName) &&
                            string.IsNullOrEmpty(p.VirtualIPName) && string.IsNullOrEmpty(p.DeploymentName)),
                    It.IsAny<CancellationToken>()),
                Times.Once());

            Assert.Equal(1, mockCommandRuntime.OutputPipeline.Count);
            Assert.Equal("Succeeded", ((ManagementOperationContext)mockCommandRuntime.OutputPipeline[0]).OperationStatus);
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ReservedExistingIPSingleVip()
        {
            ReserveExistingDeploymentIPBySlot(DeploymentSlot.Production);
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ReservedExistingIPSingleVipStaging()
        {
            ReserveExistingDeploymentIPBySlot(DeploymentSlot.Staging);
        }

        private void ReserveExistingDeploymentIPBySlot(DeploymentSlot slot)
        {
            NewAzureReservedIPCmdlet cmdlet = new NewAzureReservedIPCmdlet(testClientProvider)
            {
                ReservedIPName = ReservedIPName,
                Location = "WestUS",
                ServiceName = ServiceName,
                Label = ReservedIPLabel,
                Slot = slot.ToString(),
                CommandRuntime = mockCommandRuntime,
            };

            cmdlet.SetParameterSet(NewAzureReservedIPCmdlet.ReserveInUseIPParamSet);

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            computeClientMock.Verify(
                c => c.Deployments.GetBySlotAsync(
                    ServiceName,
                    slot,
                    It.IsAny<CancellationToken>()),
                Times.Once);

            networkingClientMock.Verify(
                c => c.ReservedIPs.CreateAsync(
                    It.Is<NetworkReservedIPCreateParameters>(
                        p =>
                            string.Equals(p.Name, ReservedIPName) && string.Equals(p.ServiceName, ServiceName) &&
                            string.IsNullOrEmpty(p.VirtualIPName) && string.Equals(p.DeploymentName, DeploymentName)),
                    It.IsAny<CancellationToken>()),
                Times.Once());

            Assert.Equal(1, mockCommandRuntime.OutputPipeline.Count);
            Assert.Equal("Succeeded", ((ManagementOperationContext) mockCommandRuntime.OutputPipeline[0]).OperationStatus);
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveAzureReservedIP()
        {
            RemoveAzureReservedIPCmdlet removeCmdlet = new RemoveAzureReservedIPCmdlet(testClientProvider)
            {
                ReservedIPName = ReservedIPName,
                Force = true,
                CommandRuntime = mockCommandRuntime,
            };

            // Action
            removeCmdlet.ExecuteCmdlet();

            networkingClientMock.Verify(
                c => c.ReservedIPs.DeleteAsync(
                    ReservedIPName,
                    It.IsAny<CancellationToken>()),
                Times.Once());

            Assert.Equal(1, mockCommandRuntime.OutputPipeline.Count);
            Assert.Equal("Succeeded", ((ManagementOperationContext)mockCommandRuntime.OutputPipeline[0]).OperationStatus);
        }


        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ReserveExistingIPNamedVip()
        {
            NewAzureReservedIPCmdlet cmdlet = new NewAzureReservedIPCmdlet(testClientProvider)
            {
                ReservedIPName = ReservedIPName,
                Location = "WestUS",
                ServiceName = ServiceName,
                Label = ReservedIPLabel,
                VirtualIPName = VipName,
                CommandRuntime = mockCommandRuntime,
            };

            cmdlet.SetParameterSet(NewAzureReservedIPCmdlet.ReserveInUseIPParamSet);

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
                c => c.ReservedIPs.CreateAsync(
                    It.Is<NetworkReservedIPCreateParameters>(
                        p =>
                            string.Equals(p.Name, ReservedIPName) && string.Equals(p.ServiceName, ServiceName) &&
                            string.Equals(p.VirtualIPName, VipName) && string.Equals(p.DeploymentName, DeploymentName)),
                    It.IsAny<CancellationToken>()),
                Times.Once());

            Assert.Equal(1, mockCommandRuntime.OutputPipeline.Count);
            Assert.Equal("Succeeded", ((ManagementOperationContext)mockCommandRuntime.OutputPipeline[0]).OperationStatus);
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureReservedIPAssociationSimple()
        {
            SetAzureReservedIPAssociationSimpleBySlot(DeploymentSlot.Production);   
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureReservedIPAssociationSimpleStaging()
        {
            SetAzureReservedIPAssociationSimpleBySlot(DeploymentSlot.Staging);
        }

        private void SetAzureReservedIPAssociationSimpleBySlot(DeploymentSlot slot)
        {
            SetAzureReservedIPAssociationCmdlet setassociation = new SetAzureReservedIPAssociationCmdlet(testClientProvider)
            {
                ReservedIPName = ReservedIPName,
                ServiceName = ServiceName,
                Slot = slot.ToString(),
                CommandRuntime = mockCommandRuntime,
            };

            // Action
            setassociation.ExecuteCmdlet();

            // Assert
            computeClientMock.Verify(
                c => c.Deployments.GetBySlotAsync(
                    ServiceName,
                    slot,
                    It.IsAny<CancellationToken>()),
                Times.Once);

            networkingClientMock.Verify(
                c => c.ReservedIPs.AssociateAsync(
                    ReservedIPName,
                    It.Is<NetworkReservedIPMobilityParameters>(
                        p =>
                            string.Equals(p.ServiceName, ServiceName) &&
                            string.IsNullOrEmpty(p.VirtualIPName) && string.Equals(p.DeploymentName, DeploymentName)),
                    It.IsAny<CancellationToken>()),
                Times.Once());
            Assert.Equal(1, mockCommandRuntime.OutputPipeline.Count);
            Assert.Equal("Succeeded", ((ManagementOperationContext) mockCommandRuntime.OutputPipeline[0]).OperationStatus);
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureReservedIPAssociationMultivip()
        {
            SetAzureReservedIPAssociationCmdlet setassociation = new SetAzureReservedIPAssociationCmdlet(testClientProvider)
            {
                ReservedIPName = ReservedIPName,
                ServiceName = ServiceName,
                VirtualIPName = VipName,
                CommandRuntime = mockCommandRuntime,
            };

            setassociation.ExecuteCmdlet();

            // Assert
            computeClientMock.Verify(
                c => c.Deployments.GetBySlotAsync(
                    ServiceName,
                    DeploymentSlot.Production,
                    It.IsAny<CancellationToken>()),
                Times.Once);

            networkingClientMock.Verify(
                c => c.ReservedIPs.AssociateAsync(
                    ReservedIPName,
                    It.Is<NetworkReservedIPMobilityParameters>(
                        p =>
                            string.Equals(p.ServiceName, ServiceName) &&
                            string.Equals(p.VirtualIPName, VipName) && string.Equals(p.DeploymentName, DeploymentName)),
                    It.IsAny<CancellationToken>()),
                Times.Once());

            Assert.Equal(1, mockCommandRuntime.OutputPipeline.Count);
            Assert.Equal("Succeeded", ((ManagementOperationContext)mockCommandRuntime.OutputPipeline[0]).OperationStatus);
        }
    }
}
