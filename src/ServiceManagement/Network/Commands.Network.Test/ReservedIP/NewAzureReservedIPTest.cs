using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Test.TestInterfaces;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Network;
using Moq;
using Microsoft.WindowsAzure.Management.Compute.Models;
using Microsoft.WindowsAzure.Management.Network.Models;
using Microsoft.WindowsAzure.Management;
using Microsoft.WindowsAzure.Management.Storage;
using Xunit;
using Assert = Xunit.Assert;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Test.ReservedIP
{
    public class NewAzureReservedIPTest
    {
        private MockCommandRuntime mockCommandRuntime;

        public const string ServiceName = "ServiceName";
        public const string DeploymentName = "DeploymentName";
        public const string ReservedIPName = "ReservedIPName";
        public const string ReservedIPLocation = "West US";
        public const string ReservedIPLabel = "SomeLabel";
        public const string VipName = "VipName";
        private NewAzureReservedIPCmdlet cmdlet;
        private NetworkClient client;
        private Mock<NetworkManagementClient> networkingClientMock;
        private Mock<ComputeManagementClient> computeClientMock;
        private Mock<ManagementClient> managementClientMock;
        private Mock<StorageManagementClient> storageClientMock;
        private Mock<ServiceManagementBaseCmdlet> svcmgmt;
        private IClientProvider testClientProvider;


        public NewAzureReservedIPTest()
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
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureReservedIPSimple()
        {
            cmdlet = new NewAzureReservedIPCmdlet(testClientProvider)
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
            cmdlet = new NewAzureReservedIPCmdlet(testClientProvider)
            {
                ReservedIPName = ReservedIPName,
                Location = "WestUS",
                ServiceName = ServiceName,
                Label = ReservedIPLabel,
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
                            string.IsNullOrEmpty(p.VirtualIPName) && string.Equals(p.DeploymentName, DeploymentName)),
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
            cmdlet = new NewAzureReservedIPCmdlet(testClientProvider)
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
    }
}
