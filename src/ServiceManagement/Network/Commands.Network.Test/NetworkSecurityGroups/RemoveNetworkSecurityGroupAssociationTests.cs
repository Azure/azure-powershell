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

using Hyak.Common;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Network.NetworkSecurityGroup.Subnet;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;
using Microsoft.WindowsAzure.Management.Network;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Test.NetworkSecurityGroups
{
    public class RemoveNetworkSecurityGroupAssociationTests
    {
        private const string ServiceName = "serviceName";
        private const string DeploymentName = "deploymentName";
        private const string RoleName = "roleName";
        private const string NetworkInterfaceName = "networkInterfaceName";
        private const string NetworkSecurityGroupName = "networkSecurityGroupName";
        private const string CurrentNetworkSecurityGroup = "currentNetworkSecurityGroup";
        private const string VirtualNetworkName = "virtualNetworkName";
        private const string SubnetName = "subnetName";

        private PersistentVMRoleContext VM = new PersistentVMRoleContext()
        {
            // these are the only 2 properties being used in the cmdlet
            Name = RoleName,
            DeploymentName = DeploymentName,
        };

        private CloudException AlreadySetException = new CloudException("already set exception")
        {
            Error = new CloudError()
            {
                Code = "BadRequest",
                Message = "is already mapped to network security group"
            }
        };

        private MockCommandRuntime mockCommandRuntime;

        private RemoveAzureNetworkSecurityGroupAssociation cmdlet;

        private NetworkClient client;
        private Mock<INetworkManagementClient> networkingClientMock;
        private Mock<IComputeManagementClient> computeClientMock;
        private Mock<IManagementClient> managementClientMock;

        public RemoveNetworkSecurityGroupAssociationTests()
        {
            this.networkingClientMock = new Mock<INetworkManagementClient>();
            this.computeClientMock = new Mock<IComputeManagementClient>();
            this.managementClientMock = new Mock<IManagementClient>();
            this.mockCommandRuntime = new MockCommandRuntime();
            this.client = new NetworkClient(
                networkingClientMock.Object,
                computeClientMock.Object,
                managementClientMock.Object,
                mockCommandRuntime);

            this.computeClientMock
                .Setup(c => c.Deployments.GetBySlotAsync(ServiceName, DeploymentSlot.Production, It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() => new DeploymentGetResponse()
                {
                    Name = DeploymentName
                }));

            this.networkingClientMock
                .Setup(c =>
                    c.NetworkSecurityGroups.RemoveFromSubnetAsync(
                        VirtualNetworkName,
                        SubnetName,
                        NetworkSecurityGroupName,
                        It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() => new Azure.OperationStatusResponse()));

            this.networkingClientMock
                .Setup(c =>
                    c.NetworkSecurityGroups.RemoveFromRoleAsync(
                        ServiceName,
                        DeploymentName,
                        RoleName,
                        NetworkSecurityGroupName,
                        It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() => new Azure.OperationStatusResponse()));

            this.networkingClientMock
                .Setup(c =>
                    c.NetworkSecurityGroups.RemoveFromNetworkInterfaceAsync(
                        ServiceName,
                        DeploymentName,
                        RoleName,
                        NetworkInterfaceName,
                        NetworkSecurityGroupName,
                        It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() => new Azure.OperationStatusResponse()));
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveNSGFromSubnet()
        {
            // Setup
            cmdlet = new RemoveAzureNetworkSecurityGroupAssociation()
            {
                Name = NetworkSecurityGroupName,
                VirtualNetworkName = VirtualNetworkName,
                SubnetName = SubnetName,
                CommandRuntime = mockCommandRuntime,
                Client = this.client
            };
            cmdlet.SetParameterSet(RemoveAzureNetworkSecurityGroupAssociation.RemoveNetworkSecurityGroupAssociationFromSubnet);

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            #region Never called
            computeClientMock.Verify(
                c => c.Deployments.GetBySlotAsync(
                    It.IsAny<string>(),
                    It.IsAny<DeploymentSlot>(),
                    It.IsAny<CancellationToken>()),
                Times.Never);

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.RemoveFromRoleAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()),
                Times.Never);

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.RemoveFromNetworkInterfaceAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()),
                Times.Never);
            #endregion

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.RemoveFromSubnetAsync(
                    cmdlet.VirtualNetworkName,
                    cmdlet.SubnetName,
                    NetworkSecurityGroupName,
                    It.IsAny<CancellationToken>()),
                Times.Once);

            Assert.Equal(0, mockCommandRuntime.OutputPipeline.Count);
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveNSGFromVMRole()
        {
            // Setup
            cmdlet = new RemoveAzureNetworkSecurityGroupAssociation()
            {
                Name = NetworkSecurityGroupName,
                ServiceName = ServiceName,
                VM = VM,
                CommandRuntime = mockCommandRuntime,
                Client = this.client
            };
            cmdlet.SetParameterSet(RemoveAzureNetworkSecurityGroupAssociation.RemoveNetworkSecurityGroupAssociationFromIaaSRole);

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            #region Never called
            computeClientMock.Verify(
                c => c.Deployments.GetBySlotAsync(
                    It.IsAny<string>(),
                    It.IsAny<DeploymentSlot>(),
                    It.IsAny<CancellationToken>()),
                Times.Never);

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.RemoveFromSubnetAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()),
                Times.Never);

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.RemoveFromNetworkInterfaceAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()),
                Times.Never);
            #endregion

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.RemoveFromRoleAsync(
                    cmdlet.ServiceName,
                    DeploymentName,
                    RoleName,
                    NetworkSecurityGroupName,
                    It.IsAny<CancellationToken>()),
                Times.Once);

            Assert.Equal(0, mockCommandRuntime.OutputPipeline.Count);
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveNSGFromVMNic()
        {
            // Setup
            cmdlet = new RemoveAzureNetworkSecurityGroupAssociation()
            {
                Name = NetworkSecurityGroupName,
                ServiceName = ServiceName,
                VM = VM,
                NetworkInterfaceName = NetworkInterfaceName,
                CommandRuntime = mockCommandRuntime,
                Client = this.client
            };
            cmdlet.SetParameterSet(RemoveAzureNetworkSecurityGroupAssociation.RemoveNetworkSecurityGroupAssociationFromIaaSRole);

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            #region Never called
            computeClientMock.Verify(
                c => c.Deployments.GetBySlotAsync(
                    It.IsAny<string>(),
                    It.IsAny<DeploymentSlot>(),
                    It.IsAny<CancellationToken>()),
                Times.Never);

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.RemoveFromSubnetAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()),
                Times.Never);

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.RemoveFromRoleAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()),
                Times.Never);
            #endregion

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.RemoveFromNetworkInterfaceAsync(
                    cmdlet.ServiceName,
                    DeploymentName,
                    RoleName,
                    NetworkInterfaceName,
                    NetworkSecurityGroupName,
                    It.IsAny<CancellationToken>()),
                Times.Once);

            Assert.Equal(0, mockCommandRuntime.OutputPipeline.Count);
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveNSGFromVMRoleByName()
        {
            // Setup
            cmdlet = new RemoveAzureNetworkSecurityGroupAssociation()
            {
                Name = NetworkSecurityGroupName,
                ServiceName = ServiceName,
                RoleName = RoleName,
                CommandRuntime = mockCommandRuntime,
                Client = this.client
            };
            cmdlet.SetParameterSet(RemoveAzureNetworkSecurityGroupAssociation.RemoveNetworkSecurityGroupAssociationFromPaaSRole);

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            #region Never called
            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.RemoveFromSubnetAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()),
                Times.Never);

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.RemoveFromNetworkInterfaceAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()),
                Times.Never);
            #endregion

            computeClientMock.Verify(
                c => c.Deployments.GetBySlotAsync(
                    It.IsAny<string>(),
                    DeploymentSlot.Production,
                    It.IsAny<CancellationToken>()),
                Times.Once);


            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.RemoveFromRoleAsync(
                    cmdlet.ServiceName,
                    DeploymentName,
                    RoleName,
                    NetworkSecurityGroupName,
                    It.IsAny<CancellationToken>()),
                Times.Once);

            Assert.Equal(0, mockCommandRuntime.OutputPipeline.Count);
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveNSGFromVMNicByName()
        {
            // Setup
            cmdlet = new RemoveAzureNetworkSecurityGroupAssociation()
            {
                Name = NetworkSecurityGroupName,
                ServiceName = ServiceName,
                RoleName = RoleName,
                NetworkInterfaceName = NetworkInterfaceName,
                CommandRuntime = mockCommandRuntime,
                Client = this.client
            };
            cmdlet.SetParameterSet(RemoveAzureNetworkSecurityGroupAssociation.RemoveNetworkSecurityGroupAssociationFromPaaSRole);

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            #region Never called
            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.RemoveFromSubnetAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()),
                Times.Never);

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.RemoveFromRoleAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()),
                Times.Never);
            #endregion

            computeClientMock.Verify(
                c => c.Deployments.GetBySlotAsync(
                    It.IsAny<string>(),
                    DeploymentSlot.Production,
                    It.IsAny<CancellationToken>()),
                Times.Once);


            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.RemoveFromNetworkInterfaceAsync(
                    cmdlet.ServiceName,
                    DeploymentName,
                    RoleName,
                    NetworkInterfaceName,
                    NetworkSecurityGroupName,
                    It.IsAny<CancellationToken>()),
                Times.Once);

            Assert.Equal(0, mockCommandRuntime.OutputPipeline.Count);
        }
    }
}
