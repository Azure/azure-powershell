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

using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ExpressRoute;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Management.ExpressRoute;
using Microsoft.WindowsAzure.Management.ExpressRoute.Models;
using Moq;
using Microsoft.Azure;

namespace Microsoft.WindowsAzure.Commands.Test.ExpressRoute
{
    
    public class AzureBgpPeeringTests : SMTestBase
    {
        private const string SubscriptionId = "foo";

        private static Mock<ExpressRouteManagementClient> InitExpressRouteManagementClient()
        {
            return
                (new Mock<ExpressRouteManagementClient>(
                    new CertificateCloudCredentials(SubscriptionId, new X509Certificate2(new byte[] {})),
                    new Uri("http://someValue")));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureBgpPeeringSuccessful()
        {
            // Setup

            string serviceKey = "aa28cd19-b10a-41ff-981b-53c6bbf15ead";
            UInt32 peerAsn = 64496;
            string primaryPeerSubnet = "aaa";
            string secondayPeerSubnet = "bbb";
            UInt32 azureAsn = 64494;
            string primaryAzurePort = "8081";
            string secondaryAzurePort = "8082";
            var state = BgpPeeringState.Enabled;
            uint vlanId = 2;
            var accessType = BgpPeeringAccessType.Private;

            MockCommandRuntime mockCommandRuntime = new MockCommandRuntime();
            Mock<ExpressRouteManagementClient> client = InitExpressRouteManagementClient();
            var bgpMock = new Mock<IBorderGatewayProtocolPeeringOperations>();
          
            BorderGatewayProtocolPeeringGetResponse expectedBgp =
                new BorderGatewayProtocolPeeringGetResponse
                {
                    BgpPeering = new AzureBgpPeering()
                    {
                        AzureAsn = azureAsn,
                        PeerAsn = peerAsn,
                        PrimaryAzurePort = primaryAzurePort,
                        PrimaryPeerSubnet = primaryPeerSubnet,   
                        SecondaryAzurePort = secondaryAzurePort,
                        SecondaryPeerSubnet = secondayPeerSubnet,
                        State = state,         
                        VlanId = vlanId
                    },
                    RequestId = "",
                    StatusCode = new HttpStatusCode()
                };

            ExpressRouteOperationStatusResponse expectedStatus = new ExpressRouteOperationStatusResponse()
            {
                HttpStatusCode = HttpStatusCode.OK
            };

            var tGet = new Task<BorderGatewayProtocolPeeringGetResponse>(() => expectedBgp);
            tGet.Start();

            var tNew = new Task<ExpressRouteOperationStatusResponse>(() => expectedStatus);
            tNew.Start();
            
            bgpMock.Setup(
                f =>
                    f.NewAsync(It.Is<string>(x => x == serviceKey),
                        It.Is<BgpPeeringAccessType>(
                            y => y == accessType),
                        It.Is<BorderGatewayProtocolPeeringNewParameters>(
                            z =>
                                z.PeerAutonomousSystemNumber == peerAsn && z.PrimaryPeerSubnet == primaryPeerSubnet &&
                                z.SecondaryPeerSubnet == secondayPeerSubnet && z.VirtualLanId == vlanId),
                        It.IsAny<CancellationToken>()))
                .Returns((string sKey, BgpPeeringAccessType atype, BorderGatewayProtocolPeeringNewParameters param, CancellationToken cancellation) => tNew);
            client.SetupGet(f => f.BorderGatewayProtocolPeerings).Returns(bgpMock.Object);

            bgpMock.Setup(
               f =>
                   f.GetAsync(It.Is<string>(x => x == serviceKey),
                       It.Is<BgpPeeringAccessType>(
                           y => y == accessType),
                       It.IsAny<CancellationToken>()))
               .Returns((string sKey, BgpPeeringAccessType atype, CancellationToken cancellation) => tGet);
            client.SetupGet(f => f.BorderGatewayProtocolPeerings).Returns(bgpMock.Object);

            NewAzureBGPPeeringCommand cmdlet = new NewAzureBGPPeeringCommand()
            {
                ServiceKey = Guid.Parse(serviceKey),
                AccessType = accessType,
                PeerAsn = peerAsn,
                PrimaryPeerSubnet = primaryPeerSubnet,
                SecondaryPeerSubnet = secondayPeerSubnet,
                SharedKey = null,
                VlanId = vlanId,
                CommandRuntime = mockCommandRuntime,
                ExpressRouteClient = new ExpressRouteClient(client.Object)
            };

            cmdlet.ExecuteCmdlet();

            // Assert
            AzureBgpPeering actual = mockCommandRuntime.OutputPipeline[0] as AzureBgpPeering;
            Assert.Equal(expectedBgp.BgpPeering.State, actual.State);
            Assert.Equal(expectedBgp.BgpPeering.PrimaryAzurePort, actual.PrimaryAzurePort);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureBgpPeeringSuccessful()
        {
            // Setup

            string serviceKey = "aa28cd19-b10a-41ff-981b-53c6bbf15ead";
            UInt32 peerAsn = 64496;
            string primaryPeerSubnet = "aaa";
            string secondayPeerSubnet = "bbb";
            UInt32 azureAsn = 64494;
            string primaryAzurePort = "8081";
            string secondaryAzurePort = "8082";
            var state = BgpPeeringState.Enabled;
            uint vlanId = 2;
            var accessType = BgpPeeringAccessType.Private;

            MockCommandRuntime mockCommandRuntime = new MockCommandRuntime();
            Mock<ExpressRouteManagementClient> client = InitExpressRouteManagementClient();
            var bgpMock = new Mock<IBorderGatewayProtocolPeeringOperations>();

            BorderGatewayProtocolPeeringGetResponse expected =
                new BorderGatewayProtocolPeeringGetResponse()
                {
                    BgpPeering = new AzureBgpPeering()
                    {
                        AzureAsn = azureAsn,
                        PeerAsn = peerAsn,
                        PrimaryAzurePort = primaryAzurePort,
                        PrimaryPeerSubnet = primaryPeerSubnet,
                        SecondaryAzurePort = secondaryAzurePort,
                        SecondaryPeerSubnet = secondayPeerSubnet,
                        State = state,
                        VlanId = vlanId
                    },
                    RequestId = "",
                    StatusCode = new HttpStatusCode()
                };
            var t = new Task<BorderGatewayProtocolPeeringGetResponse>(() => expected);
            t.Start();

            bgpMock.Setup(
                f =>
                    f.GetAsync(It.Is<string>(x => x == serviceKey),
                        It.Is<BgpPeeringAccessType>(
                            y => y == accessType),
                        It.IsAny<CancellationToken>()))
                .Returns((string sKey, BgpPeeringAccessType atype, CancellationToken cancellation) => t);
            client.SetupGet(f => f.BorderGatewayProtocolPeerings).Returns(bgpMock.Object);

            GetAzureBGPPeeringCommand cmdlet = new GetAzureBGPPeeringCommand()
            {
                ServiceKey = Guid.Parse(serviceKey),
                AccessType = accessType,
                CommandRuntime = mockCommandRuntime,
                ExpressRouteClient = new ExpressRouteClient(client.Object)
            };

            cmdlet.ExecuteCmdlet();

            // Assert
            AzureBgpPeering actual = mockCommandRuntime.OutputPipeline[0] as AzureBgpPeering;
            Assert.Equal(expected.BgpPeering.State, actual.State);
            Assert.Equal(expected.BgpPeering.PrimaryAzurePort, actual.PrimaryAzurePort);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveAzureBgpPeeringSuccessful()
        {
            // Setup

            string serviceKey = "aa28cd19-b10a-41ff-981b-53c6bbf15ead";
            BgpPeeringAccessType accessType = BgpPeeringAccessType.Private;

            MockCommandRuntime mockCommandRuntime = new MockCommandRuntime();
            Mock<ExpressRouteManagementClient> client = InitExpressRouteManagementClient();
            var bgpMock = new Mock<IBorderGatewayProtocolPeeringOperations>();

            ExpressRouteOperationStatusResponse expected =
                new ExpressRouteOperationStatusResponse()
                {
                    Status = ExpressRouteOperationStatus.Successful,
                    HttpStatusCode = HttpStatusCode.OK
                };

            var t = new Task<ExpressRouteOperationStatusResponse>(() => expected);
            t.Start();

            bgpMock.Setup(f => f.RemoveAsync(It.Is<string>(sKey => sKey == serviceKey), It.Is<BgpPeeringAccessType>(
                y => y == accessType),
                It.IsAny<CancellationToken>()))
                .Returns((string sKey, BgpPeeringAccessType aType, CancellationToken cancellation) => t);
            client.SetupGet(f => f.BorderGatewayProtocolPeerings).Returns(bgpMock.Object);

            RemoveAzureBGPPeeringCommand cmdlet = new RemoveAzureBGPPeeringCommand()
            {
                ServiceKey = Guid.Parse(serviceKey),
                AccessType = accessType,
                CommandRuntime = mockCommandRuntime,
                ExpressRouteClient = new ExpressRouteClient(client.Object)
            };

            cmdlet.ExecuteCmdlet();

            Assert.True(mockCommandRuntime.VerboseStream[0].Contains(serviceKey));
        }
    }
}
