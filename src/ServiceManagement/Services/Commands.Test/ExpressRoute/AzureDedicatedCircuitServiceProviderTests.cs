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
    
    public class AzureDedicatedCircuitServiceProviderTests : SMTestBase
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
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListAzureDedicatedCircuitServiceProviderSuccessful()
        {
            // Setup

            var serviceProviderName = "TestServiceProvider1";
            var serviceProviderName2 = "TestServiceProvier2";
            var type1 = "IXP";
            var type2 = "Telco";
           
            MockCommandRuntime mockCommandRuntime = new MockCommandRuntime();
            Mock<ExpressRouteManagementClient> client = InitExpressRouteManagementClient();
            var dcsMock = new Mock<IDedicatedCircuitServiceProviderOperations>();

            List<AzureDedicatedCircuitServiceProvider>
                dedicatedCircuitServiceProviders = new List
                    <AzureDedicatedCircuitServiceProvider>()
                {
                    new AzureDedicatedCircuitServiceProvider()
                    {
                        DedicatedCircuitBandwidths =
                            new DedicatedCircuitBandwidth[1]
                            {
                                new DedicatedCircuitBandwidth()
                                {
                                    Bandwidth = 10,
                                    Label = "T1"
                                }
                            },
                        DedicatedCircuitLocations = "us-west",
                        Name = serviceProviderName,
                        Type = type1
                    },
                    new AzureDedicatedCircuitServiceProvider()
                    {
                        DedicatedCircuitBandwidths =
                            new DedicatedCircuitBandwidth[1]
                            {
                                new DedicatedCircuitBandwidth()
                                {
                                    Bandwidth = 10,
                                    Label = "T1"
                                }
                            },
                        DedicatedCircuitLocations = "us-west",
                        Name = serviceProviderName2,
                        Type = type2
                    }
                };
            DedicatedCircuitServiceProviderListResponse expected =
                new DedicatedCircuitServiceProviderListResponse()
                {
                    DedicatedCircuitServiceProviders = dedicatedCircuitServiceProviders,
                    StatusCode = HttpStatusCode.OK
                };

            var t = new Task<DedicatedCircuitServiceProviderListResponse>(() => expected);
            t.Start();

            dcsMock.Setup(f => f.ListAsync(It.IsAny<CancellationToken>())).Returns((CancellationToken cancellation) => t);
            client.SetupGet(f => f.DedicatedCircuitServiceProviders).Returns(dcsMock.Object);

            GetAzureDedicatedCircuitServiceProviderCommand cmdlet = new GetAzureDedicatedCircuitServiceProviderCommand()
            {
                CommandRuntime = mockCommandRuntime,
                ExpressRouteClient = new ExpressRouteClient(client.Object)
            };

            cmdlet.ExecuteCmdlet();

            // Assert
            IEnumerable<AzureDedicatedCircuitServiceProvider> actual = 
                System.Management.Automation.LanguagePrimitives.GetEnumerable(mockCommandRuntime.OutputPipeline).Cast<AzureDedicatedCircuitServiceProvider>();

            Assert.Equal(actual.Count(), 2);
        }
    }
}
