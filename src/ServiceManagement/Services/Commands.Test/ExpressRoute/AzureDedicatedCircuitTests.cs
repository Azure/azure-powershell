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
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.Test.ExpressRoute
{
    
    public class AzureDedicatedCircuitTests : SMTestBase
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
        public void NewAzureDedicatedCircuitSuccessful()
        {
            // Setup

            string circuitName = "TestCircuit";
            uint bandwidth = 10;
            string serviceProviderName = "TestProvider";
            string location = "us-west";
            string serviceKey = "aa28cd19-b10a-41ff-981b-53c6bbf15ead";
            BillingType billingType = BillingType.MeteredData;
            CircuitSku sku = CircuitSku.Premium;

            MockCommandRuntime mockCommandRuntime = new MockCommandRuntime();
            Mock<ExpressRouteManagementClient> client = InitExpressRouteManagementClient();
            var dcMock = new Mock<IDedicatedCircuitOperations>();

            DedicatedCircuitGetResponse expected =
                new DedicatedCircuitGetResponse()
                {
                    DedicatedCircuit = new AzureDedicatedCircuit()
                    {
                        CircuitName = circuitName,
                        Bandwidth = bandwidth,
                        BillingType = billingType.ToString(),
                        Location = location,
                        ServiceProviderName = serviceProviderName,
                        ServiceKey = serviceKey,
                        ServiceProviderProvisioningState = ProviderProvisioningState.NotProvisioned,
                        Status = DedicatedCircuitState.Enabled,
                        Sku = sku
                    },
                    RequestId = "",
                    StatusCode = new HttpStatusCode()
                };
            var tGet = new Task<DedicatedCircuitGetResponse>(() => expected);
            tGet.Start();

            ExpressRouteOperationStatusResponse expectedStatus = new ExpressRouteOperationStatusResponse()
            {
                HttpStatusCode = HttpStatusCode.OK,
                Data = serviceKey
            };

            var tNew = new Task<ExpressRouteOperationStatusResponse>(() => expectedStatus);
            tNew.Start();

            ExpressRouteOperationStatusResponse expectedUpdateStatus = new ExpressRouteOperationStatusResponse()
            {
                HttpStatusCode = HttpStatusCode.OK,
                Data = serviceKey
            };

            var tUpdate = new Task<ExpressRouteOperationStatusResponse>(() => expectedUpdateStatus);
            tUpdate.Start();

            dcMock.Setup(f => f.NewAsync(It.Is<DedicatedCircuitNewParameters>(x => x.Bandwidth == bandwidth && 
                x.CircuitName == circuitName && x.Location == location && x.ServiceProviderName == serviceProviderName), 
                It.IsAny<CancellationToken>())).Returns((DedicatedCircuitNewParameters param, CancellationToken cancellation) => tNew);
            
            dcMock.Setup(f => f.GetAsync(It.Is<string>(sKey => sKey == serviceKey), It.IsAny<CancellationToken>())).Returns((string sKey, CancellationToken cancellation) => tGet);
            
            dcMock.Setup(f => f.UpdateAsync(It.Is<string>(sKey => sKey == serviceKey), 
                It.Is<DedicatedCircuitUpdateParameters>(y => y.Bandwidth == bandwidth.ToString() && y.BillingType == billingType && y.Sku == sku.ToString()),
                It.IsAny<CancellationToken>())).Returns((string sKey, DedicatedCircuitUpdateParameters updateParam, 
                    CancellationToken cancellation) => tUpdate);
            client.SetupGet(f => f.DedicatedCircuits).Returns(dcMock.Object);

            NewAzureDedicatedCircuitCommand cmdlet = new NewAzureDedicatedCircuitCommand()
            {
                CircuitName = circuitName,
                Bandwidth = bandwidth,
                BillingType = billingType,
                Location = location,
                ServiceProviderName = serviceProviderName,
                Sku = sku,
                CommandRuntime = mockCommandRuntime,
                ExpressRouteClient = new ExpressRouteClient(client.Object)
            };

            cmdlet.ExecuteCmdlet();

            // Assert
            AzureDedicatedCircuit actual = mockCommandRuntime.OutputPipeline[0] as AzureDedicatedCircuit;
            Assert.Equal<string>(expected.DedicatedCircuit.CircuitName, actual.CircuitName);
            Assert.Equal<string>(expected.DedicatedCircuit.BillingType, actual.BillingType);
            Assert.Equal<uint>(expected.DedicatedCircuit.Bandwidth, actual.Bandwidth);
            Assert.Equal<string>(expected.DedicatedCircuit.Location, actual.Location);
            Assert.Equal<string>(expected.DedicatedCircuit.ServiceProviderName, actual.ServiceProviderName);
            Assert.Equal(expected.DedicatedCircuit.ServiceProviderProvisioningState, actual.ServiceProviderProvisioningState);
            Assert.Equal(expected.DedicatedCircuit.Status, actual.Status);
            Assert.Equal<string>(expected.DedicatedCircuit.ServiceKey, actual.ServiceKey);
            Assert.Equal<CircuitSku>(expected.DedicatedCircuit.Sku, actual.Sku);

            SetAzureDedicatedCircuitPropertiesCommand setCmdlet = new SetAzureDedicatedCircuitPropertiesCommand()
                                                                      {
                                                                          ServiceKey = Guid.Parse(actual.ServiceKey),
                                                                          Bandwidth =  bandwidth,
                                                                          BillingType = billingType,
                                                                          Sku = sku,
                                                                          CommandRuntime = mockCommandRuntime,
                                                                          ExpressRouteClient = new ExpressRouteClient(client.Object)
                                                                      };
            setCmdlet.ExecuteCmdlet();
            actual = mockCommandRuntime.OutputPipeline[0] as AzureDedicatedCircuit;
            Assert.Equal<string>(expected.DedicatedCircuit.CircuitName, actual.CircuitName);
            Assert.Equal<string>(expected.DedicatedCircuit.BillingType, actual.BillingType);
            Assert.Equal<uint>(expected.DedicatedCircuit.Bandwidth, actual.Bandwidth);
            Assert.Equal<string>(expected.DedicatedCircuit.Location, actual.Location);
            Assert.Equal<string>(expected.DedicatedCircuit.ServiceProviderName, actual.ServiceProviderName);
            Assert.Equal(expected.DedicatedCircuit.ServiceProviderProvisioningState, actual.ServiceProviderProvisioningState);
            Assert.Equal(expected.DedicatedCircuit.Status, actual.Status);
            Assert.Equal<string>(expected.DedicatedCircuit.ServiceKey, actual.ServiceKey);
            Assert.Equal<CircuitSku>(expected.DedicatedCircuit.Sku, actual.Sku);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureDedicatedCircuitSuccessful()
        {
            // Setup

            string circuitName = "TestCircuit";
            uint bandwidth = 10;
            string serviceProviderName = "TestProvider";
            string location = "us-west";
            string serviceKey = "aa28cd19-b10a-41ff-981b-53c6bbf15ead";
            BillingType billingType = BillingType.MeteredData;

            MockCommandRuntime mockCommandRuntime = new MockCommandRuntime();
            Mock<ExpressRouteManagementClient> client = InitExpressRouteManagementClient();
            var dcMock = new Mock<IDedicatedCircuitOperations>();

            DedicatedCircuitGetResponse expected =
                new DedicatedCircuitGetResponse()
                {
                    DedicatedCircuit = new AzureDedicatedCircuit()
                    {
                        CircuitName = circuitName,
                        Bandwidth = bandwidth,
                        BillingType = billingType.ToString(),
                        Location = location,
                        ServiceProviderName = serviceProviderName,
                        ServiceKey = serviceKey,
                        ServiceProviderProvisioningState = ProviderProvisioningState.NotProvisioned,
                        Status = DedicatedCircuitState.Enabled,
                    },
                    RequestId = "",
                    StatusCode = new HttpStatusCode()
                };
            var t = new Task<DedicatedCircuitGetResponse>(() => expected);
            t.Start();

            dcMock.Setup(f => f.GetAsync(It.Is<string>(sKey => sKey == serviceKey), It.IsAny<CancellationToken>())).Returns((string sKey, CancellationToken cancellation) => t);
            client.SetupGet(f => f.DedicatedCircuits).Returns(dcMock.Object);

            GetAzureDedicatedCircuitCommand cmdlet = new GetAzureDedicatedCircuitCommand()
            {
                ServiceKey = Guid.Parse(serviceKey),
                CommandRuntime = mockCommandRuntime,
                ExpressRouteClient = new ExpressRouteClient(client.Object)
            };

            cmdlet.ExecuteCmdlet();

            // Assert
            AzureDedicatedCircuit actual = mockCommandRuntime.OutputPipeline[0] as AzureDedicatedCircuit;
            Assert.Equal<string>(expected.DedicatedCircuit.BillingType, actual.BillingType);
            Assert.Equal<string>(expected.DedicatedCircuit.CircuitName, actual.CircuitName);
            Assert.Equal<uint>(expected.DedicatedCircuit.Bandwidth, actual.Bandwidth);
            Assert.Equal<string>(expected.DedicatedCircuit.Location, actual.Location);
            Assert.Equal<string>(expected.DedicatedCircuit.ServiceProviderName, actual.ServiceProviderName);
            Assert.Equal(expected.DedicatedCircuit.ServiceProviderProvisioningState, actual.ServiceProviderProvisioningState);
            Assert.Equal(expected.DedicatedCircuit.Status, actual.Status);
            Assert.Equal<string>(expected.DedicatedCircuit.ServiceKey, actual.ServiceKey);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveAzureDedicatedCircuitSuccessful()
        {
            string serviceKey = "aa28cd19-b10a-41ff-981b-53c6bbf15ead";
            ExpressRouteOperationStatusResponse expected =
                new ExpressRouteOperationStatusResponse()
                {
                    Status = ExpressRouteOperationStatus.Successful,
                    HttpStatusCode = HttpStatusCode.OK
                };
            
            MockCommandRuntime mockCommandRuntime = new MockCommandRuntime();
            Mock<ExpressRouteManagementClient> client = InitExpressRouteManagementClient();
            var dcMock = new Mock<IDedicatedCircuitOperations>();

            var t = new Task<ExpressRouteOperationStatusResponse>(() => expected);
            t.Start();

            dcMock.Setup(f => f.RemoveAsync(It.Is<string>(sKey => sKey == serviceKey), It.IsAny<CancellationToken>())).Returns((string sKey, CancellationToken cancellation) => t);
            client.SetupGet(f => f.DedicatedCircuits).Returns(dcMock.Object);

            RemoveAzureDedicatedCircuitCommand cmdlet = new RemoveAzureDedicatedCircuitCommand()
            {
                ServiceKey = Guid.Parse(serviceKey),
                CommandRuntime = mockCommandRuntime,
                ExpressRouteClient = new ExpressRouteClient(client.Object)
            };

            cmdlet.ExecuteCmdlet();

            Assert.True(mockCommandRuntime.VerboseStream[0].Contains(serviceKey));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListAzureDedicatedCircuitSuccessful()
        {
            // Setup

            string circuitName1 = "TestCircuit";
            uint bandwidth1 = 10;
            string serviceProviderName1 = "TestProvider";
            string location1 = "us-west";
            string serviceKey1 = "aa28cd19-b10a-41ff-981b-53c6bbf15ead";
            BillingType billingType1 = BillingType.MeteredData;

            string circuitName2 = "TestCircuit2";
            uint bandwidth2 = 10;
            string serviceProviderName2 = "TestProvider";
            string location2 = "us-north";
            string serviceKey2 = "bc28cd19-b10a-41ff-981b-53c6bbf15ead";
            BillingType billingType2 = BillingType.UnlimitedData;

            MockCommandRuntime mockCommandRuntime = new MockCommandRuntime();
            Mock<ExpressRouteManagementClient> client = InitExpressRouteManagementClient();
            var dcMock = new Mock<IDedicatedCircuitOperations>();

            List<AzureDedicatedCircuit> dedicatedCircuits = new List<AzureDedicatedCircuit>(){ 
                new AzureDedicatedCircuit(){ Bandwidth = bandwidth1, BillingType = billingType1.ToString(), CircuitName = circuitName1, ServiceKey = serviceKey1, Location = location1, ServiceProviderName = serviceProviderName1, ServiceProviderProvisioningState = ProviderProvisioningState.NotProvisioned, Status = DedicatedCircuitState.Enabled}, 
                new AzureDedicatedCircuit(){ Bandwidth = bandwidth2, BillingType = billingType2.ToString(), CircuitName = circuitName2, ServiceKey = serviceKey2, Location = location2, ServiceProviderName = serviceProviderName2, ServiceProviderProvisioningState = ProviderProvisioningState.Provisioned, Status = DedicatedCircuitState.Enabled}
            };
                 
            DedicatedCircuitListResponse expected =
                new DedicatedCircuitListResponse()
                {
                    DedicatedCircuits = dedicatedCircuits,
                    StatusCode = HttpStatusCode.OK                 
                };

            var t = new Task<DedicatedCircuitListResponse>(() => expected);
            t.Start();

            dcMock.Setup(f => f.ListAsync(It.IsAny<CancellationToken>())).Returns((CancellationToken cancellation) => t);
            client.SetupGet(f => f.DedicatedCircuits).Returns(dcMock.Object);

             GetAzureDedicatedCircuitCommand cmdlet = new GetAzureDedicatedCircuitCommand()
            {
                CommandRuntime = mockCommandRuntime,
                ExpressRouteClient = new ExpressRouteClient(client.Object)
            };

            cmdlet.ExecuteCmdlet();

            // Assert
            IEnumerable<AzureDedicatedCircuit> actual = LanguagePrimitives.GetEnumerable(mockCommandRuntime.OutputPipeline).Cast<AzureDedicatedCircuit>();

            Assert.Equal(actual.Count(), 2);
        }
    }
}
