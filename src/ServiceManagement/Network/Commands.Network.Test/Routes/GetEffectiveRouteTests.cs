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
using Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Routes;
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

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Test.Routes
{
    public class GetEffectiveRouteTests
    {
        private const string ServiceName = "serviceName";
        private const string DeploymentName = "deploymentName";
        private const string RoleInstanceName = "roleInstanceName";
        private const string NetworkInterfaceName = "networkInterfaceName";

        private PersistentVMRoleContext VM = new PersistentVMRoleContext()
        {
            // these are the only 2 properties being used in the cmdlet
            InstanceName = RoleInstanceName,
            DeploymentName = DeploymentName
        };

        private MockCommandRuntime mockCommandRuntime;

        private GetAzureEffectiveRouteTable cmdlet;

        private NetworkClient client;
        private Mock<INetworkManagementClient> networkingClientMock;
        private Mock<IComputeManagementClient> computeClientMock;
        private Mock<IManagementClient> managementClientMock;

        public GetEffectiveRouteTests()
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
                .Setup(c => c.Routes.GetEffectiveRouteTableForRoleInstanceAsync(
                    ServiceName,
                    DeploymentName,
                    RoleInstanceName,
                    It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() => new GetEffectiveRouteTableResponse()
                {
                    EffectiveRouteTable = new EffectiveRouteTable()
                    {
                        EffectiveRoutes = new List<EffectiveRoute>()
                    }
                }));

            this.networkingClientMock
                .Setup(c => c.Routes.GetEffectiveRouteTableForNetworkInterfaceAsync(
                    ServiceName,
                    DeploymentName,
                    RoleInstanceName,
                    NetworkInterfaceName,
                    It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() => new GetEffectiveRouteTableResponse()
                {
                    EffectiveRouteTable = new EffectiveRouteTable()
                    {
                        EffectiveRoutes = new List<EffectiveRoute>()
                    }
                }));
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetEffectiveRouteTableOnRole()
        {
            GetEffectiveRouteTableForRoleInstance();
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetEffectiveRouteTableOnVM()
        {
            GetEffectiveRouteTableForVM();
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetEffectiveRouteTableOnVMNic()
        {
            GetEffectiveRouteTableForVMNic();
        }

        #region helpers

        private void GetEffectiveRouteTableForRoleInstance()
        {
            // Setup
            cmdlet = new GetAzureEffectiveRouteTable
            {
                ServiceName = ServiceName,
                RoleInstanceName = RoleInstanceName,
                CommandRuntime = mockCommandRuntime,
                Client = this.client
            };
            cmdlet.SetParameterSet(GetAzureEffectiveRouteTable.SlotGetEffectiveRouteTableParamSet);

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            computeClientMock.Verify(
                c => c.Deployments.GetBySlotAsync(
                    ServiceName,
                    DeploymentSlot.Production,
                    It.IsAny<CancellationToken>()),
                Times.Once());

            networkingClientMock.Verify(
                c => c.Routes.GetEffectiveRouteTableForRoleInstanceAsync(
                    cmdlet.ServiceName,
                    DeploymentName,
                    cmdlet.RoleInstanceName,
                    It.IsAny<CancellationToken>()),
                Times.Once());

            Assert.Equal(1, mockCommandRuntime.OutputPipeline.Count);
            Assert.IsType<EffectiveRouteTable>(mockCommandRuntime.OutputPipeline[0]);
        }

        private void GetEffectiveRouteTableForVM()
        {
            // Setup

            cmdlet = new GetAzureEffectiveRouteTable
            {
                ServiceName = ServiceName,
                VM = VM,
                CommandRuntime = mockCommandRuntime,
                Client = this.client,
            };
            cmdlet.SetParameterSet(GetAzureEffectiveRouteTable.IaaSGetEffectiveRouteTableParamSet);

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            computeClientMock.Verify(
                c => c.Deployments.GetBySlotAsync(
                    ServiceName,
                    DeploymentSlot.Production,
                    It.IsAny<CancellationToken>()),
                Times.Never());

            networkingClientMock.Verify(
                c => c.Routes.GetEffectiveRouteTableForRoleInstanceAsync(
                    cmdlet.ServiceName,
                    DeploymentName,
                    VM.InstanceName,
                    It.IsAny<CancellationToken>()),
                Times.Once());

            Assert.Equal(1, mockCommandRuntime.OutputPipeline.Count);
            Assert.IsType<EffectiveRouteTable>(mockCommandRuntime.OutputPipeline[0]);
        }

        private void GetEffectiveRouteTableForVMNic()
        {
            // Setup
            cmdlet = new GetAzureEffectiveRouteTable
            {
                ServiceName = ServiceName,
                VM = VM,
                NetworkInterfaceName = NetworkInterfaceName,
                CommandRuntime = mockCommandRuntime,
                Client = this.client,
            };
            cmdlet.SetParameterSet(GetAzureEffectiveRouteTable.IaaSGetEffectiveRouteTableParamSet);

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            computeClientMock.Verify(
                c => c.Deployments.GetBySlotAsync(
                    ServiceName,
                    DeploymentSlot.Production,
                    It.IsAny<CancellationToken>()),
                Times.Never());

            networkingClientMock.Verify(
                c => c.Routes.GetEffectiveRouteTableForNetworkInterfaceAsync(
                    cmdlet.ServiceName,
                    DeploymentName,
                    VM.InstanceName,
                    cmdlet.NetworkInterfaceName,
                    It.IsAny<CancellationToken>()),
                Times.Once());

            Assert.Equal(1, mockCommandRuntime.OutputPipeline.Count);
            Assert.IsType<EffectiveRouteTable>(mockCommandRuntime.OutputPipeline[0]);
        }

        #endregion
    }
}