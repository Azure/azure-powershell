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
using System.Linq;
using System.Management.Automation;
using System.Threading;
using System.Threading.Tasks;
using Hyak.Common;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Network.NetworkSecurityGroup.Association;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Network.NetworkSecurityGroup.Model;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Network;
using Microsoft.WindowsAzure.Management;
using Models = Microsoft.WindowsAzure.Management.Network.Models;
using Moq;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Test.NetworkSecurityGroups
{
    public class GetNetworkSecurityGroupAssociationTests
    {
        private const string ServiceName = "serviceName";
        private const string DeploymentName = "deploymentName";
        private const string RoleName = "roleName";
        private const string NetworkInterfaceName = "networkInterfaceName";
        private const string NetworkSecurityGroupName = "networkSecurityGroupName";
        private const string NSGLocation = "usnorth";
        private const string NSGLabel = "My NSG label";
        private const string VirtualNetworkName = "virtualNetworkName";
        private const string SubnetName = "subnetName";

        private PersistentVMRoleContext VM = new PersistentVMRoleContext()
        {
            // these are the only 2 properties being used in the cmdlet
            Name = RoleName,
            DeploymentName = DeploymentName,
        };

        private IList<Models.NetworkSecurityRule> Rules = new List<Models.NetworkSecurityRule>()
        {
            new Models.NetworkSecurityRule()
            {
                Name = "rule1",
                Action = "Allow",
                Type = "Inbound",
                Protocol = "TCP",
                IsDefault = true,
                DestinationAddressPrefix = "*",
                DestinationPortRange = "*",
                SourceAddressPrefix = "*",
                SourcePortRange = "*",
                Priority = 100
            },
        };

        private MockCommandRuntime mockCommandRuntime;

        private GetAzureNetworkSecurityGroupAssociation cmdlet;

        private NetworkClient client;
        private Mock<INetworkManagementClient> networkingClientMock;
        private Mock<IComputeManagementClient> computeClientMock;
        private Mock<IManagementClient> managementClientMock;

        public GetNetworkSecurityGroupAssociationTests()
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

            this.networkingClientMock
                .Setup(c =>
                    c.NetworkSecurityGroups.GetForSubnetAsync(
                        VirtualNetworkName,
                        SubnetName,
                        It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() =>
                    new Models.NetworkSecurityGroupGetAssociationResponse()
                    {
                        Name = NetworkSecurityGroupName
                    }));

            this.networkingClientMock
                .Setup(c =>
                    c.NetworkSecurityGroups.GetForRoleAsync(
                        ServiceName,
                        DeploymentName,
                        RoleName,
                        It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() =>
                    new Models.NetworkSecurityGroupGetAssociationResponse()
                    {
                        Name = NetworkSecurityGroupName
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
                    new Models.NetworkSecurityGroupGetAssociationResponse()
                    {
                        Name = NetworkSecurityGroupName
                    }));

            this.networkingClientMock
                .Setup(c =>
                    c.NetworkSecurityGroups.GetAsync(
                    NetworkSecurityGroupName,
                    null,
                    It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() =>
                    new Models.NetworkSecurityGroupGetResponse()
                    {
                        Name = NetworkSecurityGroupName,
                        Location = NSGLocation,
                        Label = NSGLabel
                    }));

            this.networkingClientMock
                .Setup(c =>
                    c.NetworkSecurityGroups.GetAsync(
                    NetworkSecurityGroupName,
                    "Full",
                    It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() =>
                    new Models.NetworkSecurityGroupGetResponse()
                    {
                        Name = NetworkSecurityGroupName,
                        Location = NSGLocation,
                        Label = NSGLabel,
                        Rules = Rules
                    }));
        }

        #region No Details

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetNSGForSubnetNoDetails()
        {
            // Setup
            cmdlet = new GetAzureNetworkSecurityGroupAssociation
            {
                VirtualNetworkName = VirtualNetworkName,
                SubnetName = SubnetName,
                CommandRuntime = mockCommandRuntime,
                Client = this.client
            };
            cmdlet.SetParameterSet(GetAzureNetworkSecurityGroupAssociation.GetNetworkSecurityGroupAssociationForSubnet);

            // Action
            cmdlet.ExecuteCmdlet();

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.GetForSubnetAsync(
                    VirtualNetworkName,
                    SubnetName,
                    It.IsAny<CancellationToken>()),
                Times.Once);

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.GetAsync(
                    NetworkSecurityGroupName,
                    null,
                    It.IsAny<CancellationToken>()),
                Times.Once);

            Assert.Equal(1, mockCommandRuntime.OutputPipeline.Count);
            Assert.IsType<SimpleNetworkSecurityGroup>(mockCommandRuntime.OutputPipeline.Single());
            var nsg = (SimpleNetworkSecurityGroup)(mockCommandRuntime.OutputPipeline.Single());
            Assert.Equal(NetworkSecurityGroupName, nsg.Name);
            Assert.Equal(NSGLocation, nsg.Location);
            Assert.Equal(NSGLabel, nsg.Label);
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetNSGForVMRoleNoDetails()
        {
            // Setup
            cmdlet = new GetAzureNetworkSecurityGroupAssociation
            {
                VM = VM,
                ServiceName = ServiceName,
                CommandRuntime = mockCommandRuntime,
                Client = this.client
            };
            cmdlet.SetParameterSet(GetAzureNetworkSecurityGroupAssociation.GetNetworkSecurityGroupAssociationForIaaSRole);

            // Action
            cmdlet.ExecuteCmdlet();

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.GetForRoleAsync(
                    ServiceName,
                    DeploymentName,
                    RoleName,
                    It.IsAny<CancellationToken>()),
                Times.Once);

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.GetAsync(
                    NetworkSecurityGroupName,
                    null,
                    It.IsAny<CancellationToken>()),
                Times.Once);

            Assert.Equal(1, mockCommandRuntime.OutputPipeline.Count);
            Assert.IsType<SimpleNetworkSecurityGroup>(mockCommandRuntime.OutputPipeline.Single());
            var nsg = (SimpleNetworkSecurityGroup)(mockCommandRuntime.OutputPipeline.Single());
            Assert.Equal(NetworkSecurityGroupName, nsg.Name);
            Assert.Equal(NSGLocation, nsg.Location);
            Assert.Equal(NSGLabel, nsg.Label);
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetNSGForVMNicNoDetails()
        {
            // Setup
            cmdlet = new GetAzureNetworkSecurityGroupAssociation
            {
                VM = VM,
                ServiceName = ServiceName,
                NetworkInterfaceName = NetworkInterfaceName,
                CommandRuntime = mockCommandRuntime,
                Client = this.client
            };
            cmdlet.SetParameterSet(GetAzureNetworkSecurityGroupAssociation.GetNetworkSecurityGroupAssociationForIaaSRole);

            // Action
            cmdlet.ExecuteCmdlet();

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.GetForNetworkInterfaceAsync(
                    ServiceName,
                    DeploymentName,
                    RoleName,
                    NetworkInterfaceName,
                    It.IsAny<CancellationToken>()),
                Times.Once);

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.GetAsync(
                    NetworkSecurityGroupName,
                    null,
                    It.IsAny<CancellationToken>()),
                Times.Once);

            Assert.Equal(1, mockCommandRuntime.OutputPipeline.Count);
            Assert.IsType<SimpleNetworkSecurityGroup>(mockCommandRuntime.OutputPipeline.Single());
            var nsg = (SimpleNetworkSecurityGroup)(mockCommandRuntime.OutputPipeline.Single());
            Assert.Equal(NetworkSecurityGroupName, nsg.Name);
            Assert.Equal(NSGLocation, nsg.Location);
            Assert.Equal(NSGLabel, nsg.Label);
        }

        #endregion

        #region With Details

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetNSGForSubnetWithDetails()
        {
            // Setup
            cmdlet = new GetAzureNetworkSecurityGroupAssociation
            {
                VirtualNetworkName = VirtualNetworkName,
                SubnetName = SubnetName,
                CommandRuntime = mockCommandRuntime,
                Detailed = new SwitchParameter(true),
                Client = this.client
            };
            cmdlet.SetParameterSet(GetAzureNetworkSecurityGroupAssociation.GetNetworkSecurityGroupAssociationForSubnet);

            // Action
            cmdlet.ExecuteCmdlet();

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.GetForSubnetAsync(
                    VirtualNetworkName,
                    SubnetName,
                    It.IsAny<CancellationToken>()),
                Times.Once);

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.GetAsync(
                    NetworkSecurityGroupName,
                    "Full",
                    It.IsAny<CancellationToken>()),
                Times.Once);

            Assert.Equal(1, mockCommandRuntime.OutputPipeline.Count);
            Assert.IsType<NetworkSecurityGroupWithRules>(mockCommandRuntime.OutputPipeline.Single());
            var nsg = (NetworkSecurityGroupWithRules)(mockCommandRuntime.OutputPipeline.Single());
            Assert.Equal(NetworkSecurityGroupName, nsg.Name);
            Assert.Equal(NSGLabel, nsg.Label);
            Assert.Equal(NSGLocation, nsg.Location);
            Assert.NotEmpty(nsg.Rules);
            Assert.Equal(Rules.First().Name, nsg.Rules.First().Name);
            Assert.Equal(Rules.First().Action, nsg.Rules.First().Action);
            Assert.Equal(Rules.First().Protocol, nsg.Rules.First().Protocol);
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetNSGForVMRoleDetails()
        {
            // Setup
            cmdlet = new GetAzureNetworkSecurityGroupAssociation
            {
                VM = VM,
                ServiceName = ServiceName,
                CommandRuntime = mockCommandRuntime,
                Detailed = new SwitchParameter(true),
                Client = this.client
            };
            cmdlet.SetParameterSet(GetAzureNetworkSecurityGroupAssociation.GetNetworkSecurityGroupAssociationForIaaSRole);

            // Action
            cmdlet.ExecuteCmdlet();

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.GetForRoleAsync(
                    ServiceName,
                    DeploymentName,
                    RoleName,
                    It.IsAny<CancellationToken>()),
                Times.Once);

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.GetAsync(
                    NetworkSecurityGroupName,
                    "Full",
                    It.IsAny<CancellationToken>()),
                Times.Once);

            Assert.Equal(1, mockCommandRuntime.OutputPipeline.Count);
            Assert.IsType<NetworkSecurityGroupWithRules>(mockCommandRuntime.OutputPipeline.Single());
            var nsg = (NetworkSecurityGroupWithRules)(mockCommandRuntime.OutputPipeline.Single());
            Assert.Equal(NetworkSecurityGroupName, nsg.Name);
            Assert.Equal(NSGLabel, nsg.Label);
            Assert.Equal(NSGLocation, nsg.Location);
            Assert.NotEmpty(nsg.Rules);
            Assert.Equal(Rules.First().Name, nsg.Rules.First().Name);
            Assert.Equal(Rules.First().Action, nsg.Rules.First().Action);
            Assert.Equal(Rules.First().Protocol, nsg.Rules.First().Protocol);
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetNSGForVMNicDetails()
        {
            // Setup
            cmdlet = new GetAzureNetworkSecurityGroupAssociation
            {
                VM = VM,
                ServiceName = ServiceName,
                NetworkInterfaceName = NetworkInterfaceName,
                CommandRuntime = mockCommandRuntime,
                Detailed = new SwitchParameter(true),
                Client = this.client
            };
            cmdlet.SetParameterSet(GetAzureNetworkSecurityGroupAssociation.GetNetworkSecurityGroupAssociationForIaaSRole);

            // Action
            cmdlet.ExecuteCmdlet();

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.GetForNetworkInterfaceAsync(
                    ServiceName,
                    DeploymentName,
                    RoleName,
                    NetworkInterfaceName,
                    It.IsAny<CancellationToken>()),
                Times.Once);

            networkingClientMock.Verify(
                c => c.NetworkSecurityGroups.GetAsync(
                    NetworkSecurityGroupName,
                    "Full",
                    It.IsAny<CancellationToken>()),
                Times.Once);

            Assert.Equal(1, mockCommandRuntime.OutputPipeline.Count);
            Assert.IsType<NetworkSecurityGroupWithRules>(mockCommandRuntime.OutputPipeline.Single());
            var nsg = (NetworkSecurityGroupWithRules)(mockCommandRuntime.OutputPipeline.Single());
            Assert.Equal(NetworkSecurityGroupName, nsg.Name);
            Assert.Equal(NSGLabel, nsg.Label);
            Assert.Equal(NSGLocation, nsg.Location);
            Assert.NotEmpty(nsg.Rules);
            Assert.Equal(Rules.First().Name, nsg.Rules.First().Name);
            Assert.Equal(Rules.First().Action, nsg.Rules.First().Action);
            Assert.Equal(Rules.First().Protocol, nsg.Rules.First().Protocol);
        }

        #endregion
    }
}
