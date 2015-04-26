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

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Routes;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Routes.Model;
using Microsoft.WindowsAzure.Management;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Network;
using Microsoft.WindowsAzure.Management.Network.Models;
using Moq;
using Xunit;
using Models = Microsoft.WindowsAzure.Management.Network.Models;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Test.Routes
{
    public class RemoveRouteTests
    {
        private const string RouteTableName = "routeTableName";
        private const string RouteTableLocation = "usnorth";
        private const string RouteTableLabel = "My Route Table label";
        private const string RouteName = "routeName";
        private IRouteTable RouteTable = new SimpleRouteTable(
            RouteTableName,
            RouteTableLocation,
            RouteTableLabel);

        private MockCommandRuntime mockCommandRuntime;

        private RemoveAzureRoute cmdlet;

        private NetworkClient client;
        private Mock<INetworkManagementClient> networkingClientMock;
        private Mock<IComputeManagementClient> computeClientMock;
        private Mock<IManagementClient> managementClientMock;

        public RemoveRouteTests()
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
                .Setup(c => c.Routes.CreateRouteTableAsync(
                    It.Is<CreateRouteTableParameters>(p =>
                        string.Equals(p.Name, RouteTableName) &&
                        string.Equals(p.Location, RouteTableLocation) &&
                        string.Equals(p.Label, RouteTableLabel)),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() => new Azure.OperationStatusResponse()));

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
                        }
                    }));
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveRoute()
        {
            // Setup
            cmdlet = new RemoveAzureRoute()
            {
                RouteTable = RouteTable,
                RouteName = RouteName,
                CommandRuntime = mockCommandRuntime,
                Client = this.client
            };

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            networkingClientMock.Verify(
                c => c.Routes.DeleteRouteAsync(
                    RouteTableName,
                    RouteName,
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
        }
    }
}
