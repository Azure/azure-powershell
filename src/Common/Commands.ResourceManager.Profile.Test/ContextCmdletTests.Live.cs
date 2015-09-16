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
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System.Linq;
using Xunit;
using System;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ResourceManager.Profile.Test
{
    public class ContextCmdletTestsLive 
    {
        private MemoryDataStore dataStore;
        private MockCommandRuntime commandRuntimeMock;

        public ContextCmdletTestsLive()
        {
            dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            commandRuntimeMock = new MockCommandRuntime();
            AzureRMCmdlet.DefaultProfile = new AzureRMProfile();
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void SelectAzureContextWithSubscriptionAndTenant()
        {
            var cmdlt = new SelectAzureRMContextCommand();
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.SubscriptionId = "db1ab6f0-4769-4b27-930e-01e2ef9c123c";
            cmdlt.Tenant = "72f988bf-86f1-41af-91ab-2d7cd011db47";

            // Act
            Login("2c224e7e-3ef5-431d-a57b-e71f4662e3a6", null);
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            Assert.True(commandRuntimeMock.OutputPipeline.Count == 2);
            var context = (AzureContext)commandRuntimeMock.OutputPipeline[1];
            Assert.Equal("db1ab6f0-4769-4b27-930e-01e2ef9c123c", context.Subscription.Id.ToString());
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void SelectAzureContextWithSubscriptionAndNoTenant()
        {
            var cmdlt = new SelectAzureRMContextCommand();
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.SubscriptionId = "db1ab6f0-4769-4b27-930e-01e2ef9c123c";

            // Act
            Login("2c224e7e-3ef5-431d-a57b-e71f4662e3a6", null);
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            Assert.True(commandRuntimeMock.OutputPipeline.Count == 2);
            var context = (AzureContext)commandRuntimeMock.OutputPipeline[1];
            Assert.Equal("db1ab6f0-4769-4b27-930e-01e2ef9c123c", context.Subscription.Id.ToString());
            Assert.Equal("72f988bf-86f1-41af-91ab-2d7cd011db47", context.Tenant.Id.ToString());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void SelectAzureContextWithNoSubscriptionAndTenant()
        {
            var cmdlt = new SelectAzureRMContextCommand();
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.Tenant = "72f988bf-86f1-41af-91ab-2d7cd011db47";

            // Act
            Login("2c224e7e-3ef5-431d-a57b-e71f4662e3a6", null);
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            Assert.True(commandRuntimeMock.OutputPipeline.Count == 2);
            var context = (AzureContext)commandRuntimeMock.OutputPipeline[1];
            Assert.Null(context.Subscription);
            Assert.Equal("72f988bf-86f1-41af-91ab-2d7cd011db47", context.Tenant.Id.ToString());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void SelectAzureContextWithNoSubscriptionAndNoTenant()
        {
            var cmdlt = new SelectAzureRMContextCommand();
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;

            // Act
            Login("2c224e7e-3ef5-431d-a57b-e71f4662e3a6", null);
            cmdlt.InvokeBeginProcessing();
            
            // Verify
            Assert.Throws<PSNotSupportedException>(() => cmdlt.ExecuteCmdlet());
            cmdlt.InvokeEndProcessing();
        }

        private void Login(string subscriptionId, string tenantId)
        {
            var cmdlt = new LoginAzureRMAccountCommand();
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.SubscriptionId = subscriptionId;
            cmdlt.Tenant = tenantId;

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            Assert.NotNull(AzureRMCmdlet.DefaultProfile.Context);
        }
    }
}
