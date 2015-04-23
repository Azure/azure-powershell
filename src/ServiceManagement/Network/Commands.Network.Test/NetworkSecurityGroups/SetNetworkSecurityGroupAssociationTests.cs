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
using Microsoft.WindowsAzure.Commands.ServiceManagement.Network.NetworkSecurityGroup.Association;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;
using Microsoft.WindowsAzure.Management.Network;
using Microsoft.WindowsAzure.Management.Network.Models;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Test.NetworkSecurityGroups
{
    public class SetNetworkSecurityGroupAssociationTests
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

        private SetAzureNetworkSecurityGroupAssociation cmdlet;

        private NetworkClient client;
        private Mock<INetworkManagementClient> networkingClientMock;
        private Mock<IComputeManagementClient> computeClientMock;
        private Mock<IManagementClient> managementClientMock;

        public SetNetworkSecurityGroupAssociationTests()
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
                    c.NetworkSecurityGroups.AddToSubnetAsync(
                        VirtualNetworkName,
                        SubnetName,
                        It.IsAny<NetworkSecurityGroupAddAssociationParameters>(),
                        It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() => new Azure.OperationStatusResponse()));

            this.networkingClientMock
                .Setup(c =>
                    c.NetworkSecurityGroups.AddToRoleAsync(
                        ServiceName,
                        DeploymentName,
                        RoleName,
                        It.IsAny<NetworkSecurityGroupAddAssociationParameters>(),
                        It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() => new Azure.OperationStatusResponse()));

            this.networkingClientMock
                .Setup(c =>
                    c.NetworkSecurityGroups.AddToNetworkInterfaceAsync(
                        ServiceName,
                        DeploymentName,
                        RoleName,
                        NetworkInterfaceName,
                        It.IsAny<NetworkSecurityGroupAddAssociationParameters>(),
                        It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() => new Azure.OperationStatusResponse()));

            this.networkingClientMock
                .Setup(c =>
                    c.NetworkSecurityGroups.GetForSubnetAsync(
                        VirtualNetworkName,
                        SubnetName,
                        It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() =>
                    new NetworkSecurityGroupGetAssociationResponse()
                    {
                        Name = CurrentNetworkSecurityGroup
                    }));

            this.networkingClientMock
                .Setup(c =>
                    c.NetworkSecurityGroups.GetForRoleAsync(
                        ServiceName,
                        DeploymentName,
                        RoleName,
                        It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() =>
                    new NetworkSecurityGroupGetAssociationResponse()
                    {
                        Name = CurrentNetworkSecurityGroup
                    }));

            this.networkingClientMock
                .Setup(c =>
                    c.NetworkSecurityGroups.GetForNetworkInterfaceAsync(
                        ServiceName,
                        DeploymentName,
                        RoleName,
                        NetworkInterfaceName,
                        It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() =>
                    new NetworkSecurityGroupGetAssociationResponse()
                    {
                        Name = CurrentNetworkSecurityGroup
                    }));

        }

        #region No previous NSG association is set

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetNSGOnSubnetNoPreviousNSG()
        {
            // Setup
            cmdlet = new SetAzureNetworkSecurityGroupAssociation
            {
                Name = NetworkSecurityGroupName,
                VirtualNetworkName = VirtualNetworkName,
                SubnetName = SubnetName,
                CommandRuntime = mockCommandRuntime,
                Client = this.client
            };
            cmdlet.SetParameterSet(SetAzureNetworkSecurityGroupAssociation.AddNetworkSecurityGroupAssociationToSubnet);

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
                c => c.NetworkSecurityGroups.AddToRoleAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<NetworkSecurityGroupAddAssociationParameters>(),
                    It.IsAny<CancellationToken>()),
                Times.Never);

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.AddToNetworkInterfaceAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<NetworkSecurityGroupAddAssociationParameters>(),
                    It.IsAny<CancellationToken>()),
                Times.Never);
            #endregion

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.AddToSubnetAsync(
                    cmdlet.VirtualNetworkName,
                    cmdlet.SubnetName,
                    It.Is<NetworkSecurityGroupAddAssociationParameters>(
                        parameters => string.Equals(NetworkSecurityGroupName, parameters.Name)),
                    It.IsAny<CancellationToken>()),
                Times.Once);

            Assert.Equal(0, mockCommandRuntime.OutputPipeline.Count);
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetNSGOnVMRoleNoPreviousNSG()
        {
            // Setup
            cmdlet = new SetAzureNetworkSecurityGroupAssociation
            {
                Name = NetworkSecurityGroupName,
                ServiceName = ServiceName,
                VM = VM,
                CommandRuntime = mockCommandRuntime,
                Client = this.client
            };
            cmdlet.SetParameterSet(SetAzureNetworkSecurityGroupAssociation.AddNetworkSecurityGroupAssociationToIaaSRole);

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert

            #region Never called
            computeClientMock.Verify(
                c => c.Deployments.GetBySlotAsync(
                    ServiceName,
                    DeploymentSlot.Production,
                    It.IsAny<CancellationToken>()),
                Times.Never);

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.AddToNetworkInterfaceAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<NetworkSecurityGroupAddAssociationParameters>(),
                    It.IsAny<CancellationToken>()),
                Times.Never);

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.AddToSubnetAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<NetworkSecurityGroupAddAssociationParameters>(),
                    It.IsAny<CancellationToken>()),
                Times.Never);
            #endregion

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.AddToRoleAsync(
                    ServiceName,
                    DeploymentName,
                    RoleName,
                    It.Is<NetworkSecurityGroupAddAssociationParameters>(
                        parameters => string.Equals(NetworkSecurityGroupName, parameters.Name)),
                    It.IsAny<CancellationToken>()),
                Times.Once);

            Assert.Equal(0, mockCommandRuntime.OutputPipeline.Count);
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetNSGOnVMNicNoPreviousNSG()
        {
            // Setup
            cmdlet = new SetAzureNetworkSecurityGroupAssociation
            {
                Name = NetworkSecurityGroupName,
                ServiceName = ServiceName,
                VM = VM,
                NetworkInterfaceName = NetworkInterfaceName,
                CommandRuntime = mockCommandRuntime,
                Client = this.client
            };
            cmdlet.SetParameterSet(SetAzureNetworkSecurityGroupAssociation.AddNetworkSecurityGroupAssociationToIaaSRole);

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert

            #region Never called
            computeClientMock.Verify(
                c => c.Deployments.GetBySlotAsync(
                    ServiceName,
                    DeploymentSlot.Production,
                    It.IsAny<CancellationToken>()),
                Times.Never);

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.AddToRoleAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<NetworkSecurityGroupAddAssociationParameters>(),
                    It.IsAny<CancellationToken>()),
                Times.Never);

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.AddToSubnetAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<NetworkSecurityGroupAddAssociationParameters>(),
                    It.IsAny<CancellationToken>()),
                Times.Never);
            #endregion

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.AddToNetworkInterfaceAsync(
                    ServiceName,
                    DeploymentName,
                    RoleName,
                    NetworkInterfaceName,
                    It.Is<NetworkSecurityGroupAddAssociationParameters>(
                        parameters => string.Equals(NetworkSecurityGroupName, parameters.Name)),
                    It.IsAny<CancellationToken>()),
                Times.Once);

            Assert.Equal(0, mockCommandRuntime.OutputPipeline.Count);
        }


        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetNSGOnRoleByNameNoPreviousNSG()
        {
            // Setup
            cmdlet = new SetAzureNetworkSecurityGroupAssociation
            {
                Name = NetworkSecurityGroupName,
                ServiceName = ServiceName,
                RoleName = RoleName,
                CommandRuntime = mockCommandRuntime,
                Client = this.client
            };
            cmdlet.SetParameterSet(SetAzureNetworkSecurityGroupAssociation.AddNetworkSecurityGroupAssociationToPaaSRole);

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            computeClientMock.Verify(
                c => c.Deployments.GetBySlotAsync(
                    ServiceName,
                    DeploymentSlot.Production,
                    It.IsAny<CancellationToken>()),
                Times.Once);

            #region Never called
            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.AddToNetworkInterfaceAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<NetworkSecurityGroupAddAssociationParameters>(),
                    It.IsAny<CancellationToken>()),
                Times.Never);

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.AddToSubnetAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<NetworkSecurityGroupAddAssociationParameters>(),
                    It.IsAny<CancellationToken>()),
                Times.Never);
            #endregion

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.AddToRoleAsync(
                    ServiceName,
                    DeploymentName,
                    RoleName,
                    It.Is<NetworkSecurityGroupAddAssociationParameters>(
                        parameters => string.Equals(NetworkSecurityGroupName, parameters.Name)),
                    It.IsAny<CancellationToken>()),
                Times.Once);

            Assert.Equal(0, mockCommandRuntime.OutputPipeline.Count);
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetNSGOnNicByNameNoPreviousNSG()
        {
            // Setup
            cmdlet = new SetAzureNetworkSecurityGroupAssociation
            {
                Name = NetworkSecurityGroupName,
                ServiceName = ServiceName,
                RoleName = RoleName,
                NetworkInterfaceName = NetworkInterfaceName,
                CommandRuntime = mockCommandRuntime,
                Client = this.client
            };
            cmdlet.SetParameterSet(SetAzureNetworkSecurityGroupAssociation.AddNetworkSecurityGroupAssociationToPaaSRole);

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert

            #region Never called
            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.AddToRoleAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<NetworkSecurityGroupAddAssociationParameters>(),
                    It.IsAny<CancellationToken>()),
                Times.Never);

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.AddToSubnetAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<NetworkSecurityGroupAddAssociationParameters>(),
                    It.IsAny<CancellationToken>()),
                Times.Never);
            #endregion

            computeClientMock.Verify(
                c => c.Deployments.GetBySlotAsync(
                    ServiceName,
                    DeploymentSlot.Production,
                    It.IsAny<CancellationToken>()),
                Times.Once);

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.AddToNetworkInterfaceAsync(
                    ServiceName,
                    DeploymentName,
                    RoleName,
                    NetworkInterfaceName,
                    It.Is<NetworkSecurityGroupAddAssociationParameters>(
                        parameters => string.Equals(NetworkSecurityGroupName, parameters.Name)),
                    It.IsAny<CancellationToken>()),
                Times.Once);

            Assert.Equal(0, mockCommandRuntime.OutputPipeline.Count);
        }

        #endregion


        #region A previous NSG association is set

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetNSGOnSubnetWithPreviousNSG()
        {
            // Setup

            this.networkingClientMock
                .Setup(c =>
                    c.NetworkSecurityGroups.AddToSubnetAsync(
                        VirtualNetworkName,
                        SubnetName,
                        It.IsAny<NetworkSecurityGroupAddAssociationParameters>(),
                        It.IsAny<CancellationToken>()))
                .ThrowsAsync(AlreadySetException);

            this.networkingClientMock
                .Setup(c =>
                    c.NetworkSecurityGroups.RemoveFromSubnetAsync(
                        VirtualNetworkName,
                        SubnetName,
                        CurrentNetworkSecurityGroup,
                        It.IsAny<CancellationToken>()))
                .Returns(() =>
                {
                    // after we remove the current association, Set shouldn't throw an exception any more
                    this.networkingClientMock
                    .Setup(c =>
                        c.NetworkSecurityGroups.AddToSubnetAsync(
                        VirtualNetworkName,
                        SubnetName,
                        It.IsAny<NetworkSecurityGroupAddAssociationParameters>(),
                        It.IsAny<CancellationToken>()))
                    .Returns(Task.Factory.StartNew(() => new Azure.OperationStatusResponse()));

                    return Task.Factory.StartNew(() => new Azure.OperationStatusResponse());
                });

            cmdlet = new SetAzureNetworkSecurityGroupAssociation
            {
                Name = NetworkSecurityGroupName,
                VirtualNetworkName = VirtualNetworkName,
                SubnetName = SubnetName,
                CommandRuntime = mockCommandRuntime,
                Client = this.client
            };
            cmdlet.SetParameterSet(SetAzureNetworkSecurityGroupAssociation.AddNetworkSecurityGroupAssociationToSubnet);

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
                c => c.NetworkSecurityGroups.AddToRoleAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<NetworkSecurityGroupAddAssociationParameters>(),
                    It.IsAny<CancellationToken>()),
                Times.Never);

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.AddToNetworkInterfaceAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<NetworkSecurityGroupAddAssociationParameters>(),
                    It.IsAny<CancellationToken>()),
                Times.Never);
            #endregion

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.AddToSubnetAsync(
                    cmdlet.VirtualNetworkName,
                    cmdlet.SubnetName,
                    It.Is<NetworkSecurityGroupAddAssociationParameters>(
                        parameters => string.Equals(NetworkSecurityGroupName, parameters.Name)),
                    It.IsAny<CancellationToken>()),
                Times.Exactly(2));

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.RemoveFromSubnetAsync(
                    cmdlet.VirtualNetworkName,
                    cmdlet.SubnetName,
                    CurrentNetworkSecurityGroup,
                    It.IsAny<CancellationToken>()),
                Times.Once);

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.GetForSubnetAsync(
                    cmdlet.VirtualNetworkName,
                    cmdlet.SubnetName,
                    It.IsAny<CancellationToken>()),
                Times.Once);

            Assert.Equal(0, mockCommandRuntime.OutputPipeline.Count);
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetNSGOnVMRoleWithPreviousNSG()
        {
            // Setup

            this.networkingClientMock
                .Setup(c =>
                    c.NetworkSecurityGroups.AddToRoleAsync(
                        ServiceName,
                        DeploymentName,
                        RoleName,
                        It.IsAny<NetworkSecurityGroupAddAssociationParameters>(),
                        It.IsAny<CancellationToken>()))
                .ThrowsAsync(AlreadySetException);

            this.networkingClientMock
                .Setup(c =>
                    c.NetworkSecurityGroups.RemoveFromRoleAsync(
                        ServiceName,
                        DeploymentName,
                        RoleName,
                        CurrentNetworkSecurityGroup,
                        It.IsAny<CancellationToken>()))
                .Returns(() =>
                {
                    // after we remove the current association, Set shouldn't throw an exception any more
                    this.networkingClientMock
                    .Setup(c =>
                        c.NetworkSecurityGroups.AddToRoleAsync(
                        ServiceName,
                        DeploymentName,
                        RoleName,
                        It.IsAny<NetworkSecurityGroupAddAssociationParameters>(),
                        It.IsAny<CancellationToken>()))
                    .Returns(Task.Factory.StartNew(() => new Azure.OperationStatusResponse()));

                    return Task.Factory.StartNew(() => new Azure.OperationStatusResponse());
                });

            cmdlet = new SetAzureNetworkSecurityGroupAssociation
            {
                ServiceName = ServiceName,
                VM = VM,
                Name = NetworkSecurityGroupName,
                CommandRuntime = mockCommandRuntime,
                Client = this.client
            };
            cmdlet.SetParameterSet(SetAzureNetworkSecurityGroupAssociation.AddNetworkSecurityGroupAssociationToIaaSRole);

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
                c => c.NetworkSecurityGroups.AddToSubnetAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<NetworkSecurityGroupAddAssociationParameters>(),
                    It.IsAny<CancellationToken>()),
                Times.Never);

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.AddToNetworkInterfaceAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<NetworkSecurityGroupAddAssociationParameters>(),
                    It.IsAny<CancellationToken>()),
                Times.Never);
            #endregion

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.AddToRoleAsync(
                    cmdlet.ServiceName,
                    DeploymentName,
                    RoleName,
                    It.Is<NetworkSecurityGroupAddAssociationParameters>(
                        parameters => string.Equals(NetworkSecurityGroupName, parameters.Name)),
                    It.IsAny<CancellationToken>()),
                Times.Exactly(2));

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.RemoveFromRoleAsync(
                    cmdlet.ServiceName,
                    DeploymentName,
                    RoleName,
                    CurrentNetworkSecurityGroup,
                    It.IsAny<CancellationToken>()),
                Times.Once);

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.GetForRoleAsync(
                    cmdlet.ServiceName,
                    DeploymentName,
                    RoleName,
                    It.IsAny<CancellationToken>()),
                Times.Once);

            Assert.Equal(0, mockCommandRuntime.OutputPipeline.Count);
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetNSGOnVMNicWithPreviousNSG()
        {
            // Setup

            this.networkingClientMock
                .Setup(c =>
                    c.NetworkSecurityGroups.AddToNetworkInterfaceAsync(
                        ServiceName,
                        DeploymentName,
                        RoleName,
                        NetworkInterfaceName,
                        It.IsAny<NetworkSecurityGroupAddAssociationParameters>(),
                        It.IsAny<CancellationToken>()))
                .ThrowsAsync(AlreadySetException);

            this.networkingClientMock
                .Setup(c =>
                    c.NetworkSecurityGroups.RemoveFromNetworkInterfaceAsync(
                        ServiceName,
                        DeploymentName,
                        RoleName,
                        NetworkInterfaceName,
                        CurrentNetworkSecurityGroup,
                        It.IsAny<CancellationToken>()))
                .Returns(() =>
                {
                    // after we remove the current association, Set shouldn't throw an exception any more
                    this.networkingClientMock
                    .Setup(c =>
                        c.NetworkSecurityGroups.AddToNetworkInterfaceAsync(
                        ServiceName,
                        DeploymentName,
                        RoleName,
                        NetworkInterfaceName,
                        It.IsAny<NetworkSecurityGroupAddAssociationParameters>(),
                        It.IsAny<CancellationToken>()))
                    .Returns(Task.Factory.StartNew(() => new Azure.OperationStatusResponse()));

                    return Task.Factory.StartNew(() => new Azure.OperationStatusResponse());
                });

            cmdlet = new SetAzureNetworkSecurityGroupAssociation
            {
                ServiceName = ServiceName,
                VM = VM,
                NetworkInterfaceName = NetworkInterfaceName,
                Name = NetworkSecurityGroupName,
                CommandRuntime = mockCommandRuntime,
                Client = this.client
            };
            cmdlet.SetParameterSet(SetAzureNetworkSecurityGroupAssociation.AddNetworkSecurityGroupAssociationToIaaSRole);

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
                c => c.NetworkSecurityGroups.AddToSubnetAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<NetworkSecurityGroupAddAssociationParameters>(),
                    It.IsAny<CancellationToken>()),
                Times.Never);

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.AddToRoleAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<NetworkSecurityGroupAddAssociationParameters>(),
                    It.IsAny<CancellationToken>()),
                Times.Never);
            #endregion

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.AddToNetworkInterfaceAsync(
                    cmdlet.ServiceName,
                    DeploymentName,
                    RoleName,
                    NetworkInterfaceName,
                    It.Is<NetworkSecurityGroupAddAssociationParameters>(
                        parameters => string.Equals(NetworkSecurityGroupName, parameters.Name)),
                    It.IsAny<CancellationToken>()),
                Times.Exactly(2));

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.RemoveFromNetworkInterfaceAsync(
                    cmdlet.ServiceName,
                    DeploymentName,
                    RoleName,
                    NetworkInterfaceName,
                    CurrentNetworkSecurityGroup,
                    It.IsAny<CancellationToken>()),
                Times.Once);

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.GetForNetworkInterfaceAsync(
                    cmdlet.ServiceName,
                    DeploymentName,
                    RoleName,
                    NetworkInterfaceName,
                    It.IsAny<CancellationToken>()),
                Times.Once);

            Assert.Equal(0, mockCommandRuntime.OutputPipeline.Count);
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetNSGOnRoleByNameWithPreviousNSG()
        {
            // Setup

            this.networkingClientMock
                .Setup(c =>
                    c.NetworkSecurityGroups.AddToRoleAsync(
                        ServiceName,
                        DeploymentName,
                        RoleName,
                        It.IsAny<NetworkSecurityGroupAddAssociationParameters>(),
                        It.IsAny<CancellationToken>()))
                .ThrowsAsync(AlreadySetException);

            this.networkingClientMock
                .Setup(c =>
                    c.NetworkSecurityGroups.RemoveFromRoleAsync(
                        ServiceName,
                        DeploymentName,
                        RoleName,
                        CurrentNetworkSecurityGroup,
                        It.IsAny<CancellationToken>()))
                .Returns(() =>
                {
                    // after we remove the current association, Set shouldn't throw an exception any more
                    this.networkingClientMock
                    .Setup(c =>
                        c.NetworkSecurityGroups.AddToRoleAsync(
                        ServiceName,
                        DeploymentName,
                        RoleName,
                        It.IsAny<NetworkSecurityGroupAddAssociationParameters>(),
                        It.IsAny<CancellationToken>()))
                    .Returns(Task.Factory.StartNew(() => new Azure.OperationStatusResponse()));

                    return Task.Factory.StartNew(() => new Azure.OperationStatusResponse());
                });

            cmdlet = new SetAzureNetworkSecurityGroupAssociation
            {
                ServiceName = ServiceName,
                RoleName = RoleName,
                Name = NetworkSecurityGroupName,
                CommandRuntime = mockCommandRuntime,
                Client = this.client
            };
            cmdlet.SetParameterSet(SetAzureNetworkSecurityGroupAssociation.AddNetworkSecurityGroupAssociationToPaaSRole);

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            #region Never called
            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.AddToSubnetAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<NetworkSecurityGroupAddAssociationParameters>(),
                    It.IsAny<CancellationToken>()),
                Times.Never);

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.AddToNetworkInterfaceAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<NetworkSecurityGroupAddAssociationParameters>(),
                    It.IsAny<CancellationToken>()),
                Times.Never);
            #endregion

            computeClientMock.Verify(
                c => c.Deployments.GetBySlotAsync(
                    It.IsAny<string>(),
                    It.IsAny<DeploymentSlot>(),
                    It.IsAny<CancellationToken>()),
                Times.Once);

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.AddToRoleAsync(
                    cmdlet.ServiceName,
                    DeploymentName,
                    RoleName,
                    It.Is<NetworkSecurityGroupAddAssociationParameters>(
                        parameters => string.Equals(NetworkSecurityGroupName, parameters.Name)),
                    It.IsAny<CancellationToken>()),
                Times.Exactly(2));

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.RemoveFromRoleAsync(
                    cmdlet.ServiceName,
                    DeploymentName,
                    RoleName,
                    CurrentNetworkSecurityGroup,
                    It.IsAny<CancellationToken>()),
                Times.Once);

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.GetForRoleAsync(
                    cmdlet.ServiceName,
                    DeploymentName,
                    RoleName,
                    It.IsAny<CancellationToken>()),
                Times.Once);

            Assert.Equal(0, mockCommandRuntime.OutputPipeline.Count);
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetNSGOnNicByNameWithPreviousNSG()
        {
            // Setup

            this.networkingClientMock
                .Setup(c =>
                    c.NetworkSecurityGroups.AddToNetworkInterfaceAsync(
                        ServiceName,
                        DeploymentName,
                        RoleName,
                        NetworkInterfaceName,
                        It.IsAny<NetworkSecurityGroupAddAssociationParameters>(),
                        It.IsAny<CancellationToken>()))
                .ThrowsAsync(AlreadySetException);

            this.networkingClientMock
                .Setup(c =>
                    c.NetworkSecurityGroups.RemoveFromNetworkInterfaceAsync(
                        ServiceName,
                        DeploymentName,
                        RoleName,
                        NetworkInterfaceName,
                        CurrentNetworkSecurityGroup,
                        It.IsAny<CancellationToken>()))
                .Returns(() =>
                {
                    // after we remove the current association, Set shouldn't throw an exception any more
                    this.networkingClientMock
                    .Setup(c =>
                        c.NetworkSecurityGroups.AddToNetworkInterfaceAsync(
                        ServiceName,
                        DeploymentName,
                        RoleName,
                        NetworkInterfaceName,
                        It.IsAny<NetworkSecurityGroupAddAssociationParameters>(),
                        It.IsAny<CancellationToken>()))
                    .Returns(Task.Factory.StartNew(() => new Azure.OperationStatusResponse()));

                    return Task.Factory.StartNew(() => new Azure.OperationStatusResponse());
                });

            cmdlet = new SetAzureNetworkSecurityGroupAssociation
            {
                ServiceName = ServiceName,
                RoleName = RoleName,
                NetworkInterfaceName = NetworkInterfaceName,
                Name = NetworkSecurityGroupName,
                CommandRuntime = mockCommandRuntime,
                Client = this.client
            };
            cmdlet.SetParameterSet(SetAzureNetworkSecurityGroupAssociation.AddNetworkSecurityGroupAssociationToPaaSRole);

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            #region Never called
            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.AddToSubnetAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<NetworkSecurityGroupAddAssociationParameters>(),
                    It.IsAny<CancellationToken>()),
                Times.Never);

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.AddToRoleAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<NetworkSecurityGroupAddAssociationParameters>(),
                    It.IsAny<CancellationToken>()),
                Times.Never);
            #endregion

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.AddToNetworkInterfaceAsync(
                    cmdlet.ServiceName,
                    DeploymentName,
                    RoleName,
                    NetworkInterfaceName,
                    It.Is<NetworkSecurityGroupAddAssociationParameters>(
                        parameters => string.Equals(NetworkSecurityGroupName, parameters.Name)),
                    It.IsAny<CancellationToken>()),
                Times.Exactly(2));

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.RemoveFromNetworkInterfaceAsync(
                    cmdlet.ServiceName,
                    DeploymentName,
                    RoleName,
                    NetworkInterfaceName,
                    CurrentNetworkSecurityGroup,
                    It.IsAny<CancellationToken>()),
                Times.Once);

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.GetForNetworkInterfaceAsync(
                    cmdlet.ServiceName,
                    DeploymentName,
                    RoleName,
                    NetworkInterfaceName,
                    It.IsAny<CancellationToken>()),
                Times.Once);

            computeClientMock.Verify(
                c => c.Deployments.GetBySlotAsync(
                    It.IsAny<string>(),
                    It.IsAny<DeploymentSlot>(),
                    It.IsAny<CancellationToken>()),
                Times.Once);

            Assert.Equal(0, mockCommandRuntime.OutputPipeline.Count);
        }

        #endregion

    }
}
