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
using System.Management.Automation;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Test.IPForwarding
{
    public class SetIPForwardingTests
    {
        private const string ServiceName = "serviceName";
        private const string DeploymentName = "deploymentName";
        private const string RoleName = "roleName";
        private const string NetworkInterfaceName = "networkInterfaceName";

        private PersistentVMRoleContext VM = new PersistentVMRoleContext()
        {
            // these are the only 2 properties being used in the cmdlet
            Name = RoleName,
            DeploymentName = DeploymentName
        };

        private MockCommandRuntime mockCommandRuntime;

        private SetAzureIPForwarding cmdlet;

        private NetworkClient client;
        private Mock<INetworkManagementClient> networkingClientMock;
        private Mock<IComputeManagementClient> computeClientMock;
        private Mock<IManagementClient> managementClientMock;

        public SetIPForwardingTests()
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
                .Setup(c => c.IPForwarding.SetOnRoleAsync(
                    ServiceName,
                    DeploymentName,
                    RoleName,
                    It.IsAny<IPForwardingSetParameters>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() => new Azure.OperationStatusResponse()));
        }

        #region Enable

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnableIPForwardingOnRoleSucceeds()
        {
            SetIPForwardingOnRole(enable: true, disable: false);
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnableIPForwardingOnVMSucceeds()
        {
            SetIPForwardingOnVM(enable: true, disable: false);
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnableIPForwardingOnVMNicSucceeds()
        {
            SetIPForwardingOnVMNic(enable: true, disable: false);
        }

        #endregion

        #region Disable

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DisableIPForwardingOnRoleSucceeds()
        {
            SetIPForwardingOnRole(enable: false, disable: true);
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DisableIPForwardingOnVMSucceeds()
        {
            SetIPForwardingOnVM(enable: false, disable: true);
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DisbableIPForwardingOnVMNicSucceeds()
        {
            SetIPForwardingOnVMNic(enable: false, disable: true);
        }

        #endregion

        #region helpers

        private void SetIPForwardingOnRole(bool enable, bool disable)
        {
            // Setup
            cmdlet = new SetAzureIPForwarding
            {
                ServiceName = ServiceName,
                RoleName = RoleName,
                Enable = new SwitchParameter(enable),
                Disable = new SwitchParameter(disable),
                CommandRuntime = mockCommandRuntime,
                Client = this.client
            };
            cmdlet.SetParameterSet(enable
                ? SetAzureIPForwarding.EnableSlotIPForwardingParamSet
                : SetAzureIPForwarding.DisableSlotIPForwardingParamSet);

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
                c => c.IPForwarding.SetOnRoleAsync(
                    cmdlet.ServiceName,
                    DeploymentName,
                    cmdlet.RoleName,
                    It.Is<IPForwardingSetParameters>(ip => enable ? ip.State == "Enabled" : (disable ? ip.State == "Disabled" : ip.State == "Invalid")),
                    It.IsAny<CancellationToken>()),
                Times.Once());

            Assert.Equal(0, mockCommandRuntime.OutputPipeline.Count);
        }

        private void SetIPForwardingOnVM(bool enable, bool disable)
        {
            // Setup
            cmdlet = new SetAzureIPForwarding
            {
                ServiceName = ServiceName,
                VM = VM,
                Enable = new SwitchParameter(enable),
                Disable = new SwitchParameter(disable),
                CommandRuntime = mockCommandRuntime,
                Client = this.client,
            };
            cmdlet.SetParameterSet(enable
                ? SetAzureIPForwarding.EnableIaaSIPForwardingParamSet
                : SetAzureIPForwarding.DisableIaaSIPForwardingParamSet);

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
                c => c.IPForwarding.SetOnRoleAsync(
                    cmdlet.ServiceName,
                    DeploymentName,
                    VM.Name,
                    It.Is<IPForwardingSetParameters>(ip => enable ? ip.State == "Enabled" : (disable ? ip.State == "Disabled" : ip.State == "Invalid")),
                    It.IsAny<CancellationToken>()),
                Times.Once());

            Assert.Equal(0, mockCommandRuntime.OutputPipeline.Count);
        }

        private void SetIPForwardingOnVMNic(bool enable, bool disable)
        {
            // Setup

            cmdlet = new SetAzureIPForwarding
            {
                ServiceName = ServiceName,
                VM = VM,
                NetworkInterfaceName = NetworkInterfaceName,
                Enable = new SwitchParameter(enable),
                Disable = new SwitchParameter(disable),
                CommandRuntime = mockCommandRuntime,
                Client = this.client,
            };
            cmdlet.SetParameterSet(enable
                ? SetAzureIPForwarding.EnableIaaSIPForwardingParamSet
                : SetAzureIPForwarding.DisableIaaSIPForwardingParamSet);

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
                c => c.IPForwarding.SetOnNetworkInterfaceAsync(
                    cmdlet.ServiceName,
                    DeploymentName,
                    VM.Name,
                    cmdlet.NetworkInterfaceName,
                    It.Is<IPForwardingSetParameters>(ip => enable ? ip.State == "Enabled" : (disable ? ip.State == "Disabled" : ip.State == "Invalid")),
                    It.IsAny<CancellationToken>()),
                Times.Once());

            Assert.Equal(0, mockCommandRuntime.OutputPipeline.Count);
        }

        #endregion
    }
}
