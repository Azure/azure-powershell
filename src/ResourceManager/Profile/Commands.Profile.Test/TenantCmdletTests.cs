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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Profile.Test
{
    public class TenantCmdletTests
    {
        private MemoryDataStore dataStore;
        private MockCommandRuntime commandRuntimeMock;

        public TenantCmdletTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            commandRuntimeMock = new MockCommandRuntime();
            AzureRmProfileProvider.Instance.Profile = new AzureRMProfile();
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void GetTenantWithTenantParameter()
        {
            var cmdlt = new GetAzureRMTenantCommand();
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.TenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47";

            // Act
            Login("2c224e7e-3ef5-431d-a57b-e71f4662e3a6", null);
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            Assert.True(commandRuntimeMock.OutputPipeline.Count == 2);
            Assert.Equal("72f988bf-86f1-41af-91ab-2d7cd011db47", ((PSAzureTenant)commandRuntimeMock.OutputPipeline[1]).TenantId.ToString());
            Assert.Equal("microsoft.com", ((PSAzureTenant)commandRuntimeMock.OutputPipeline[1]).Domain);
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void GetTenantWithDomainParameter()
        {
            var cmdlt = new GetAzureRMTenantCommand();
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.TenantId = "microsoft.com";

            // Act
            Login("2c224e7e-3ef5-431d-a57b-e71f4662e3a6", null);
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            Assert.True(commandRuntimeMock.OutputPipeline.Count == 3);
            Assert.Equal("72f988bf-86f1-41af-91ab-2d7cd011db47", ((PSAzureTenant)commandRuntimeMock.OutputPipeline[1]).TenantId.ToString());
            Assert.Equal("microsoft.com", ((PSAzureTenant)commandRuntimeMock.OutputPipeline[1]).Domain);
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void GetTenantWithoutParameters()
        {
            var cmdlt = new GetAzureRMTenantCommand();
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;

            // Act
            Login("2c224e7e-3ef5-431d-a57b-e71f4662e3a6", null);
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            Assert.True(commandRuntimeMock.OutputPipeline.Count == 3);
            Assert.Equal("72f988bf-86f1-41af-91ab-2d7cd011db47", ((PSAzureTenant)commandRuntimeMock.OutputPipeline[1]).TenantId.ToString());
            Assert.Equal("microsoft.com", ((PSAzureTenant)commandRuntimeMock.OutputPipeline[1]).Domain);
        }

        private void Login(string subscriptionId, string tenantId)
        {
            var cmdlt = new AddAzureRMAccountCommand();
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.SubscriptionId = subscriptionId;
            cmdlt.TenantId = tenantId;

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            Assert.NotNull(AzureRmProfileProvider.Instance.Profile.Context);
        }
    }
}
