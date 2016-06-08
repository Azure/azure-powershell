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
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Routes;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Routes.Model;
using Microsoft.WindowsAzure.Management;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Network;
using Moq;
using Xunit;
using Models = Microsoft.WindowsAzure.Management.Network.Models;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Test.Routes
{
    public class SetSubnetRouteTableTests
    {
        private const string RouteTableName = "routeTableName";
        private const string VirtualNetworkName = "virtualNetworkName";
        private const string SubnetName = "subnetName";
        private const string RouteTableLocation = "usnorth";
        private const string RouteTableLabel = "My Route Table label";

        private IList<Models.Route> Routes = new List<Models.Route>()
        {
            new Models.Route()
            {
                Name = "rule1",
                AddressPrefix = "0.0.0.0/0",
                NextHop = new Models.NextHop()
                {
                    Type = "VPNGateway"
                },
                State = Models.RouteState.Created
            },
        };

        private MockCommandRuntime mockCommandRuntime;

        private SetAzureSubnetRouteTable cmdlet;

        private NetworkClient client;
        private Mock<INetworkManagementClient> networkingClientMock;
        private Mock<IComputeManagementClient> computeClientMock;
        private Mock<IManagementClient> managementClientMock;

        public SetSubnetRouteTableTests()
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
                .Setup(c => c.Routes.GetRouteTableForSubnetAsync(
                    VirtualNetworkName,
                    SubnetName,
                    It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() =>
                    new Models.GetRouteTableForSubnetResponse()
                    {
                        RouteTableName = RouteTableName
                    }));

            this.networkingClientMock
                .Setup(c => c.Routes.AddRouteTableToSubnetAsync(
                    VirtualNetworkName,
                    SubnetName,
                    It.Is<Models.AddRouteTableToSubnetParameters>(
                        p => string.Equals(p.RouteTableName, RouteTableName)),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() => new Azure.OperationStatusResponse()));
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetRouteTableForSubnetNoDetails()
        {
            // Setup
            cmdlet = new SetAzureSubnetRouteTable
            {
                VirtualNetworkName = VirtualNetworkName,
                SubnetName = SubnetName,
                RouteTableName = RouteTableName,
                CommandRuntime = mockCommandRuntime,
                Client = this.client
            };

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            networkingClientMock.Verify(
                c => c.Routes.AddRouteTableToSubnetAsync(
                    VirtualNetworkName,
                    SubnetName,
                    It.Is<Models.AddRouteTableToSubnetParameters>(
                        p => string.Equals(p.RouteTableName, RouteTableName)),
                    It.IsAny<CancellationToken>()),
                Times.Once());

            Assert.Equal(0, mockCommandRuntime.OutputPipeline.Count);
        }
    }
}
