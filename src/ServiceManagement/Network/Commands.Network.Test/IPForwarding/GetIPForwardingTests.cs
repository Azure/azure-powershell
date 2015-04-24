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

using Microsoft.WindowsAzure.Commands.ServiceManagement.Network.IPForwarding;
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

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Test.IPForwarding
{
    public class GetIPForwardingTests
    {
        private const string ServiceName = "serviceName";
        private const string DeploymentName = "deploymentName";
        private const string RoleName = "roleName";
        private const string NetworkInterfaceName = "networkInterfaceName";

        private MockCommandRuntime mockCommandRuntime;

        private GetAzureIPForwarding cmdlet;

        private NetworkClient client;
        private Mock<INetworkManagementClient> networkingClientMock;
        private Mock<IComputeManagementClient> computeClientMock;
        private Mock<IManagementClient> managementClientMock;

        public GetIPForwardingTests()
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
                .Setup(c => c.IPForwarding.GetForRoleAsync(
                    ServiceName,
                    DeploymentName,
                    RoleName,
                    It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() => new IPForwardingGetResponse()
                {
                    State = "Enabled"
                }));

            this.networkingClientMock
                .Setup(c => c.IPForwarding.GetForNetworkInterfaceAsync(
                    ServiceName,
                    DeploymentName,
                    RoleName,
                    NetworkInterfaceName,
                    It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() => new IPForwardingGetResponse()
                {
                    State = "Disabled"
                }));
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetIPForwardingOnRoleSucceeds()
        {
            // Setup
            cmdlet = new GetAzureIPForwarding
            {
                ServiceName = ServiceName,
                RoleName = RoleName,
                CommandRuntime = mockCommandRuntime,
                Client = this.client
            };
            cmdlet.SetParameterSet(GetAzureIPForwarding.SlotIPForwardingParamSet);

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
                c => c.IPForwarding.GetForRoleAsync(
                    cmdlet.ServiceName,
                    DeploymentName,
                    cmdlet.RoleName,
                    It.IsAny<CancellationToken>()),
                Times.Once());

            Assert.Equal(1, mockCommandRuntime.OutputPipeline.Count);
            Assert.Equal("Enabled", mockCommandRuntime.OutputPipeline[0]);
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetIPForwardingOnVMSucceeds()
        {
            // Setup
            var VM = new PersistentVMRoleContext()
            {
                // these are the only 2 properties being used in the cmdlet
                Name = RoleName,
                DeploymentName = DeploymentName
            };

            cmdlet = new GetAzureIPForwarding
            {
                ServiceName = ServiceName,
                VM = VM,
                CommandRuntime = mockCommandRuntime,
                Client = this.client,
            };
            cmdlet.SetParameterSet(GetAzureIPForwarding.IaaSIPForwardingParamSet);

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
                c => c.IPForwarding.GetForRoleAsync(
                    cmdlet.ServiceName,
                    DeploymentName,
                    VM.Name,
                    It.IsAny<CancellationToken>()),
                Times.Once());

            Assert.Equal(1, mockCommandRuntime.OutputPipeline.Count);
            Assert.Equal("Enabled", mockCommandRuntime.OutputPipeline[0]);
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetIPForwardingOnVMNicSucceeds()
        {
            // Setup
            var VM = new PersistentVMRoleContext()
            {
                // these are the only 2 properties being used in the cmdlet
                Name = RoleName,
                DeploymentName = DeploymentName
            };

            cmdlet = new GetAzureIPForwarding
            {
                ServiceName = ServiceName,
                VM = VM,
                NetworkInterfaceName = NetworkInterfaceName,
                CommandRuntime = mockCommandRuntime,
                Client = this.client,
            };
            cmdlet.SetParameterSet(GetAzureIPForwarding.IaaSIPForwardingParamSet);

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
                c => c.IPForwarding.GetForNetworkInterfaceAsync(
                    cmdlet.ServiceName,
                    DeploymentName,
                    VM.Name,
                    cmdlet.NetworkInterfaceName,
                    It.IsAny<CancellationToken>()),
                Times.Once());

            Assert.Equal(1, mockCommandRuntime.OutputPipeline.Count);
            Assert.Equal("Disabled", mockCommandRuntime.OutputPipeline[0]);
        }
    }
}
