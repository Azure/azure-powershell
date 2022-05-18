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
        private MockCommandRuntime CommandRuntimeMock { get; set; }
        private string TenantId { get; set; } = "72f988bf-86f1-41af-91ab-2d7cd011db47";
        private string SubscriptionId { get; set; } = "9e223dbe-3399-4e19-88eb-0975f02ac87f";

        public TenantCmdletTests(ITestOutputHelper output)
        {
            TestExecutionHelpers.SetUpSessionAndProfile();
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            CommandRuntimeMock = new MockCommandRuntime();

            AzureSessionTestInitializer.Initialize();
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void GetTenantWithTenantParameter()
        {
            var cmdlt = new GetAzureRMTenantCommand();
            // Setup
            cmdlt.CommandRuntime = CommandRuntimeMock;
            cmdlt.TenantId = TenantId;

            // Act
            Login(SubscriptionId, null);
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            Assert.True(CommandRuntimeMock.OutputPipeline.Count == 2);
            Assert.Equal(TenantId, ((PSAzureTenant)CommandRuntimeMock.OutputPipeline[1]).Id.ToString());
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void GetTenantWithDomainParameter()
        {
            var cmdlt = new GetAzureRMTenantCommand();
            // Setup
            cmdlt.CommandRuntime = CommandRuntimeMock;
            cmdlt.TenantId = "microsoft.com";

            // Act
            Login(SubscriptionId, null);
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            Assert.True(CommandRuntimeMock.OutputPipeline.Count >= 2);
            Assert.Equal(TenantId, ((PSAzureTenant)CommandRuntimeMock.OutputPipeline[1]).Id.ToString());
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void GetTenantWithoutParameters()
        {
            var cmdlt = new GetAzureRMTenantCommand();
            // Setup
            cmdlt.CommandRuntime = CommandRuntimeMock;

            // Act
            Login(SubscriptionId, null);
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            Assert.True(CommandRuntimeMock.OutputPipeline.Count >= 2);
            Assert.Equal(TenantId, ((PSAzureTenant)CommandRuntimeMock.OutputPipeline[1]).Id.ToString());
        }

        private void Login(string subscriptionId, string tenantId)
        {
            var cmdlt = new ConnectAzureRmAccountCommand();
            // Setup
            cmdlt.CommandRuntime = CommandRuntimeMock;
            cmdlt.Subscription = subscriptionId;
            cmdlt.MyInvocation.BoundParameters.Add(nameof(cmdlt.Subscription), subscriptionId);
            cmdlt.Tenant = tenantId;
            cmdlt.MyInvocation.BoundParameters.Add(nameof(cmdlt.Tenant), tenantId);

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            Assert.NotNull(AzureRmProfileProvider.Instance.Profile.DefaultContext);
        }
    }
}
