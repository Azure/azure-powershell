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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Profile.Test
{
    public class TenantCmdletTests
    {
<<<<<<< HEAD
        private MemoryDataStore dataStore;
        private MockCommandRuntime commandRuntimeMock;
=======
        private MockCommandRuntime CommandRuntimeMock { get; set; }
        private string TenantId { get; set; } = "72f988bf-86f1-41af-91ab-2d7cd011db47";
        private string SubscriptionId { get; set; } = "9e223dbe-3399-4e19-88eb-0975f02ac87f";
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

        public TenantCmdletTests(ITestOutputHelper output)
        {
            TestExecutionHelpers.SetUpSessionAndProfile();
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
<<<<<<< HEAD
            dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            commandRuntimeMock = new MockCommandRuntime();
            AzureRmProfileProvider.Instance.Profile = new AzureRmProfile();
=======
            CommandRuntimeMock = new MockCommandRuntime();

            AzureSessionTestInitializer.Initialize();
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void GetTenantWithTenantParameter()
        {
            var cmdlt = new GetAzureRMTenantCommand();
            // Setup
<<<<<<< HEAD
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.TenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47";

            // Act
            Login("2c224e7e-3ef5-431d-a57b-e71f4662e3a6", null);
=======
            cmdlt.CommandRuntime = CommandRuntimeMock;
            cmdlt.TenantId = TenantId;

            // Act
            Login(SubscriptionId, null);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

<<<<<<< HEAD
            Assert.True(commandRuntimeMock.OutputPipeline.Count == 2);
            Assert.Equal("72f988bf-86f1-41af-91ab-2d7cd011db47", ((PSAzureTenant)commandRuntimeMock.OutputPipeline[1]).Id.ToString());
=======
            Assert.True(CommandRuntimeMock.OutputPipeline.Count == 2);
            Assert.Equal(TenantId, ((PSAzureTenant)CommandRuntimeMock.OutputPipeline[1]).Id.ToString());
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void GetTenantWithDomainParameter()
        {
            var cmdlt = new GetAzureRMTenantCommand();
            // Setup
<<<<<<< HEAD
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.TenantId = "microsoft.com";

            // Act
            Login("2c224e7e-3ef5-431d-a57b-e71f4662e3a6", null);
=======
            cmdlt.CommandRuntime = CommandRuntimeMock;
            cmdlt.TenantId = "microsoft.com";

            // Act
            Login(SubscriptionId, null);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

<<<<<<< HEAD
            Assert.True(commandRuntimeMock.OutputPipeline.Count == 3);
            Assert.Equal("72f988bf-86f1-41af-91ab-2d7cd011db47", ((PSAzureTenant)commandRuntimeMock.OutputPipeline[1]).Id.ToString());
=======
            Assert.True(CommandRuntimeMock.OutputPipeline.Count >= 2);
            Assert.Equal(TenantId, ((PSAzureTenant)CommandRuntimeMock.OutputPipeline[1]).Id.ToString());
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void GetTenantWithoutParameters()
        {
            var cmdlt = new GetAzureRMTenantCommand();
            // Setup
<<<<<<< HEAD
            cmdlt.CommandRuntime = commandRuntimeMock;

            // Act
            Login("2c224e7e-3ef5-431d-a57b-e71f4662e3a6", null);
=======
            cmdlt.CommandRuntime = CommandRuntimeMock;

            // Act
            Login(SubscriptionId, null);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

<<<<<<< HEAD
            Assert.True(commandRuntimeMock.OutputPipeline.Count == 3);
            Assert.Equal("72f988bf-86f1-41af-91ab-2d7cd011db47", ((PSAzureTenant)commandRuntimeMock.OutputPipeline[1]).Id.ToString());
=======
            Assert.True(CommandRuntimeMock.OutputPipeline.Count >= 2);
            Assert.Equal(TenantId, ((PSAzureTenant)CommandRuntimeMock.OutputPipeline[1]).Id.ToString());
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }

        private void Login(string subscriptionId, string tenantId)
        {
            var cmdlt = new ConnectAzureRmAccountCommand();
            // Setup
<<<<<<< HEAD
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.Subscription = subscriptionId;
            cmdlt.Tenant = tenantId;
=======
            cmdlt.CommandRuntime = CommandRuntimeMock;
            cmdlt.Subscription = subscriptionId;
            cmdlt.MyInvocation.BoundParameters.Add(nameof(cmdlt.Subscription), subscriptionId);
            cmdlt.Tenant = tenantId;
            cmdlt.MyInvocation.BoundParameters.Add(nameof(cmdlt.Tenant), tenantId);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            Assert.NotNull(AzureRmProfileProvider.Instance.Profile.DefaultContext);
        }
    }
}
