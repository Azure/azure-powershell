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
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ExpressRoute;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Management.ExpressRoute;
using Microsoft.WindowsAzure.Management.ExpressRoute.Models;
using Moq;

namespace Microsoft.WindowsAzure.Commands.Test.ExpressRoute
{
    
    public class AzureDedicatedCircuitLinkTests : TestBase
    {
        private const string SubscriptionId = "foo";

        private static Mock<ExpressRouteManagementClient> InitExpressRouteManagementClient()
        {
            return
                (new Mock<ExpressRouteManagementClient>(
                    new CertificateCloudCredentials(SubscriptionId, new X509Certificate2(new byte[] { })),
                    new Uri("http://someValue")));
        }

        [Fact]
        public void NewAzureDedicatedCircuitLinkSuccessful()
        {
            // Setup

            string serviceKey = "aa28cd19-b10a-41ff-981b-53c6bbf15ead";
            string vNetName = "DedicatedCircuitNetwork";

            MockCommandRuntime mockCommandRuntime = new MockCommandRuntime();
            Mock<ExpressRouteManagementClient> client = InitExpressRouteManagementClient();
            var dclMock = new Mock<IDedicatedCircuitLinkOperations>();

            DedicatedCircuitLinkGetResponse expected =
                new DedicatedCircuitLinkGetResponse()
                {
                    DedicatedCircuitLink = new AzureDedicatedCircuitLink()
                    {
                        VnetName = vNetName,
                        State = DedicatedCircuitLinkState.Provisioned
                    },
                    RequestId = "",               
                    StatusCode = new HttpStatusCode()
                };
            var t = new Task<DedicatedCircuitLinkGetResponse>(() => expected);
            t.Start();

            dclMock.Setup(f => f.NewAsync(It.Is<string>(x => x == serviceKey), It.Is<string>(y => y == vNetName), It.IsAny<CancellationToken>())).Returns((string sKey, string vNet, CancellationToken cancellation) => t);
            client.SetupGet(f => f.DedicatedCircuitLinks).Returns(dclMock.Object);

            NewAzureDedicatedCircuitLinkCommand cmdlet = new NewAzureDedicatedCircuitLinkCommand()
            {
                ServiceKey = serviceKey,
                VNetName = vNetName,
                CommandRuntime = mockCommandRuntime,
                ExpressRouteClient = new ExpressRouteClient(client.Object)
            };

            cmdlet.ExecuteCmdlet();

            // Assert
            AzureDedicatedCircuitLink actual = mockCommandRuntime.OutputPipeline[0] as AzureDedicatedCircuitLink;
            Assert.Equal<string>(expected.DedicatedCircuitLink.VnetName, actual.VnetName);
            Assert.Equal(expected.DedicatedCircuitLink.State.ToString(), actual.State.ToString());
        }

        [Fact]
        public void GetAzureDedicatedCircuitLinkSuccessful()
        {
            // Setup

            string serviceKey = "aa28cd19-b10a-41ff-981b-53c6bbf15ead";
            string vNetName = "DedicatedCircuitNetwork";

            MockCommandRuntime mockCommandRuntime = new MockCommandRuntime();
            Mock<ExpressRouteManagementClient> client = InitExpressRouteManagementClient();
            var dclMock = new Mock<IDedicatedCircuitLinkOperations>();

            DedicatedCircuitLinkGetResponse expected =
                new DedicatedCircuitLinkGetResponse()
                {
                    DedicatedCircuitLink = new AzureDedicatedCircuitLink()
                    {
                        VnetName = vNetName,
                        State = DedicatedCircuitLinkState.Provisioned
                    },
                    RequestId = "",
                    StatusCode = new HttpStatusCode()
                };
            var t = new Task<DedicatedCircuitLinkGetResponse>(() => expected);
            t.Start();

            dclMock.Setup(f => f.GetAsync(It.Is<string>(skey => skey == serviceKey), It.Is<string>(vnet => vnet == vNetName), It.IsAny<CancellationToken>())).Returns((string skey, string vnet, CancellationToken cancellation) => t);
            client.SetupGet(f => f.DedicatedCircuitLinks).Returns(dclMock.Object);

            GetAzureDedicatedCircuitLinkCommand cmdlet = new GetAzureDedicatedCircuitLinkCommand()
            {
                ServiceKey = serviceKey,
                VNetName = vNetName,
                CommandRuntime = mockCommandRuntime,
                ExpressRouteClient = new ExpressRouteClient(client.Object)
            };

            cmdlet.ExecuteCmdlet();

            // Assert
            AzureDedicatedCircuitLink actual = mockCommandRuntime.OutputPipeline[0] as AzureDedicatedCircuitLink;
            Assert.Equal<string>(expected.DedicatedCircuitLink.VnetName, actual.VnetName);
            Assert.Equal(expected.DedicatedCircuitLink.State.ToString(), actual.State.ToString());

        }

        [Fact]
        public void RemoveAzureDedicatedCircuitSuccessful()
        {
            string serviceKey = "aa28cd19-b10a-41ff-981b-53c6bbf15ead";
            string vNetName = "DedicatedCircuitNetwork";
            ExpressRouteOperationStatusResponse expected =
                new ExpressRouteOperationStatusResponse()
                {
                    Status = ExpressRouteOperationStatus.Successful,
                    HttpStatusCode = HttpStatusCode.OK
                };

            MockCommandRuntime mockCommandRuntime = new MockCommandRuntime();
            Mock<ExpressRouteManagementClient> client = InitExpressRouteManagementClient();
            var dclMock = new Mock<IDedicatedCircuitLinkOperations>();

            var t = new Task<ExpressRouteOperationStatusResponse>(() => expected);
            t.Start();

            dclMock.Setup(f => f.RemoveAsync(It.Is<string>(sKey => sKey == serviceKey), It.Is<string>(vnet => vnet == vNetName), It.IsAny<CancellationToken>())).Returns((string sKey, string vnet, CancellationToken cancellation) => t);
            client.SetupGet(f => f.DedicatedCircuitLinks).Returns(dclMock.Object);

            RemoveAzureDedicatedCircuitLinkCommand cmdlet = new RemoveAzureDedicatedCircuitLinkCommand()
            {
                ServiceKey = serviceKey,
                VNetName = vNetName,
                CommandRuntime = mockCommandRuntime,
                ExpressRouteClient = new ExpressRouteClient(client.Object)
            };

            cmdlet.ExecuteCmdlet();

            Assert.True(mockCommandRuntime.VerboseStream[0].Contains(serviceKey));
        }



        [Fact]
        public void ListAzureDedicatedCircuitLinkSuccessful()
        {
            // Setup

            
            string serviceKey = "aa28cd19-b10a-41ff-981b-53c6bbf15ead";

            string vnet1 = "DedicatedCircuitNetwork";
            string vnet2 = "AzureNetwork";

            MockCommandRuntime mockCommandRuntime = new MockCommandRuntime();
            Mock<ExpressRouteManagementClient> client = InitExpressRouteManagementClient();
            var dclMock = new Mock<IDedicatedCircuitLinkOperations>();

            List<AzureDedicatedCircuitLink> dedicatedCircuitLinks = new List<AzureDedicatedCircuitLink>(){ 
                new AzureDedicatedCircuitLink(){ VnetName = vnet1, State = DedicatedCircuitLinkState.Provisioned}, 
                new AzureDedicatedCircuitLink(){ VnetName = vnet2, State = DedicatedCircuitLinkState.NotProvisioned}};

            DedicatedCircuitLinkListResponse expected =
                new DedicatedCircuitLinkListResponse()
                {
                    DedicatedCircuitLinks = dedicatedCircuitLinks,
                    StatusCode = HttpStatusCode.OK
                };

            var t = new Task<DedicatedCircuitLinkListResponse>(() => expected);
            t.Start();

            dclMock.Setup(f => f.ListAsync(It.Is<string>(skey => skey == serviceKey), It.IsAny<CancellationToken>())).Returns((string skey, CancellationToken cancellation) => t);
            client.SetupGet(f => f.DedicatedCircuitLinks).Returns(dclMock.Object);

            GetAzureDedicatedCircuitLinkCommand cmdlet = new GetAzureDedicatedCircuitLinkCommand()
            {
                ServiceKey = serviceKey,
                CommandRuntime = mockCommandRuntime,
                ExpressRouteClient = new ExpressRouteClient(client.Object)
            };

            cmdlet.ExecuteCmdlet();

            // Assert
            IEnumerable<AzureDedicatedCircuitLink> actual =
                mockCommandRuntime.OutputPipeline[0] as IEnumerable<AzureDedicatedCircuitLink>;
            Assert.Equal(actual.ToArray().Count(), 2);
        }
    }
}
