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
    public class GetSubnetRouteTableTests
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

        private GetAzureSubnetRouteTable cmdlet;

        private NetworkClient client;
        private Mock<INetworkManagementClient> networkingClientMock;
        private Mock<IComputeManagementClient> computeClientMock;
        private Mock<IManagementClient> managementClientMock;

        public GetSubnetRouteTableTests()
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
                .Setup(c => c.Routes.GetRouteTableWithDetailsAsync(
                    RouteTableName,
                    NetworkClient.WithoutRoutesDetailLevel,
                    It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() =>
                    new Models.GetRouteTableResponse()
                    {
                        RouteTable = new Models.RouteTable()
                        {
                            Name = RouteTableName,
                            Location = RouteTableLocation,
                            Label = RouteTableLabel,
                        }
                    }));

            this.networkingClientMock
                .Setup(c => c.Routes.GetRouteTableWithDetailsAsync(
                    RouteTableName,
                    NetworkClient.WithRoutesDetailLevel,
                    It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() =>
                    new Models.GetRouteTableResponse()
                    {
                        RouteTable = new Models.RouteTable()
                        {
                            Name = RouteTableName,
                            Location = RouteTableLocation,
                            Label = RouteTableLabel,
                            RouteList = Routes
                        }
                    }));
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetRouteTableForSubnetNoDetails()
        {
            // Setup
            cmdlet = new GetAzureSubnetRouteTable
            {
                VirtualNetworkName = VirtualNetworkName,
                SubnetName = SubnetName,
                CommandRuntime = mockCommandRuntime,
                Client = this.client
            };

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            networkingClientMock.Verify(
                c => c.Routes.GetRouteTableForSubnetAsync(
                    VirtualNetworkName,
                    SubnetName,
                    It.IsAny<CancellationToken>()),
                Times.Once());

            networkingClientMock.Verify(
                c => c.Routes.GetRouteTableWithDetailsAsync(
                    RouteTableName,
                    NetworkClient.WithoutRoutesDetailLevel,
                    It.IsAny<CancellationToken>()),
                Times.Once);

            Assert.Equal(1, mockCommandRuntime.OutputPipeline.Count);
            Assert.IsType<SimpleRouteTable>(mockCommandRuntime.OutputPipeline.Single());
            var routeTable = (SimpleRouteTable)(mockCommandRuntime.OutputPipeline.Single());
            Assert.Equal(RouteTableName, routeTable.Name);
            Assert.Equal(RouteTableLabel, routeTable.Label);
            Assert.Equal(RouteTableLocation, routeTable.Location);
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetRouteTableForSubnetDetails()
        {
            // Setup
            cmdlet = new GetAzureSubnetRouteTable
            {
                VirtualNetworkName = VirtualNetworkName,
                SubnetName = SubnetName,
                CommandRuntime = mockCommandRuntime,
                Client = this.client,
                Detailed = new SwitchParameter(true)
            };

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            networkingClientMock.Verify(
                c => c.Routes.GetRouteTableForSubnetAsync(
                    VirtualNetworkName,
                    SubnetName,
                    It.IsAny<CancellationToken>()),
                Times.Once());

            networkingClientMock.Verify(
                c => c.Routes.GetRouteTableWithDetailsAsync(
                    RouteTableName,
                    NetworkClient.WithRoutesDetailLevel,
                    It.IsAny<CancellationToken>()),
                Times.Once);

            Assert.Equal(1, mockCommandRuntime.OutputPipeline.Count);
            Assert.IsType<RouteTableWithRoutes>(mockCommandRuntime.OutputPipeline.Single());
            var routeTable = (RouteTableWithRoutes)(mockCommandRuntime.OutputPipeline.Single());
            Assert.Equal(RouteTableName, routeTable.Name);
            Assert.Equal(RouteTableLabel, routeTable.Label);
            Assert.Equal(RouteTableLocation, routeTable.Location);
            Assert.NotEmpty(routeTable.Routes);
            Assert.Equal(Routes.First().Name, routeTable.Routes.First().Name);
            Assert.Equal(Routes.First().AddressPrefix, routeTable.Routes.First().AddressPrefix);
            Assert.Equal(Routes.First().NextHop.IpAddress, routeTable.Routes.First().NextHop.IpAddress);
            Assert.Equal(Routes.First().NextHop.Type, routeTable.Routes.First().NextHop.Type);
        }
    }
}
