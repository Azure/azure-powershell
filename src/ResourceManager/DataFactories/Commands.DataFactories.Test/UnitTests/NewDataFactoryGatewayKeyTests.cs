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

using Hyak.Common;
using Microsoft.Azure.Commands.DataFactories;
using Microsoft.Azure.Commands.DataFactories.Models;
using Microsoft.Azure.Commands.DataFactories.Test;
using Microsoft.Azure.Management.DataFactories.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Net;
using System.Net.Http;
using Xunit;


namespace Microsoft.WindowsAzure.Commands.Test.Gateway
{

    public class NewAzureDataFactoryGatewayKeyTests : DataFactoryUnitTestBase
    {
        private NewAzureDataFactoryGatewayKeyCommand _cmdlet;

        public NewAzureDataFactoryGatewayKeyTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            base.SetupTest();

            _cmdlet = new NewAzureDataFactoryGatewayKeyCommand
            {
                CommandRuntime = commandRuntimeMock.Object,
                DataFactoryClient = dataFactoriesClientMock.Object,
                ResourceGroupName = ResourceGroupName,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanNewGatewayKey()
        {
            var gatewaykey = new PSDataFactoryGatewayKey("FakedKey");

            var expectedOutput = new PSDataFactoryGateway
            {
                Name = GatewayName,
                Status = GatewayStatus.Online,
                Description = "New gateway description for test"
            };

            var fakeRequest = new HttpRequestMessage(HttpMethod.Get, "https://www.microsoft.com");

            dataFactoriesClientMock.Setup(
                f => f.RegenerateGatewayKey(ResourceGroupName, DataFactoryName, GatewayName))
                                   .Returns(gatewaykey)
                                   .Verifiable();

            _cmdlet.GatewayName = GatewayName;
            _cmdlet.DataFactoryName = DataFactoryName;

            _cmdlet.ExecuteCmdlet();

            dataFactoriesClientMock.VerifyAll();
            commandRuntimeMock.Verify(f => f.WriteObject(gatewaykey), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanThrowWhenCreateKeyOnNonExistingGateway()
        {
            var gatewaykey = new PSDataFactoryGatewayKey("FakedKey");

            var fakeRequest = new HttpRequestMessage(HttpMethod.Get, "https://www.microsoft.com");
            var fakeResponse = new HttpResponseMessage(HttpStatusCode.NotFound);

            dataFactoriesClientMock.Setup(
                f => f.RegenerateGatewayKey(ResourceGroupName, DataFactoryName, GatewayName))
                                   .Returns(() =>
                                   {
                                       throw CloudException.Create(fakeRequest, String.Empty, fakeResponse, String.Empty);
                                   }).Verifiable();

            _cmdlet.GatewayName = GatewayName;
            _cmdlet.DataFactoryName = DataFactoryName;

            Assert.Throws<CloudException>(() => _cmdlet.ExecuteCmdlet());

            dataFactoriesClientMock.VerifyAll();
        }

    }
}
