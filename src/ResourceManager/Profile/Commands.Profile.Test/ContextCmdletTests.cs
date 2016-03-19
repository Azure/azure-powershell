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

using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Profile;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;

namespace Microsoft.Azure.Commands.ResourceManager.Profile.Test
{
    public class ContextCmdletTests : RMTestBase
    {
        private MemoryDataStore dataStore;
        private MockCommandRuntime commandRuntimeMock;

        public ContextCmdletTests()
        {
            dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            commandRuntimeMock = new MockCommandRuntime();
            AzureSession.AuthenticationFactory = new MockTokenAuthenticationFactory();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureContext()
        {
            var cmdlt = new GetAzureRMContextCommand();
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            Assert.True(commandRuntimeMock.OutputPipeline.Count == 1);
            var context = (PSAzureContext) commandRuntimeMock.OutputPipeline[0];
            Assert.Equal("test", context.Subscription.SubscriptionName);
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SelectAzureContextWithNoSubscriptionAndTenant()
        {
            var cmdlt = new SetAzureRMContextCommand();
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.TenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47";

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            Assert.True(commandRuntimeMock.OutputPipeline.Count == 1);
            var context = (PSAzureContext)commandRuntimeMock.OutputPipeline[0];
            // TenantId is not sufficient to change the context.
            Assert.NotEqual("72f988bf-86f1-41af-91ab-2d7cd011db47", context.Tenant.TenantId);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SelectAzureContextWithNoSubscriptionAndNoTenant()
        {
            var cmdlt = new SetAzureRMContextCommand();
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            Assert.True(commandRuntimeMock.OutputPipeline.Count == 1);
            var context = (PSAzureContext)commandRuntimeMock.OutputPipeline[0];
            Assert.NotNull(context);
        }
    }
}
