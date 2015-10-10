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
using Hyak.Common;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.Azure.Commands.Profile.Test
{
    public class LoginCmdletTests
    {
        private MemoryDataStore dataStore;
        private MockCommandRuntime commandRuntimeMock;

        public LoginCmdletTests()
        {
            dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            commandRuntimeMock = new MockCommandRuntime();
            AzureRmProfileProvider.Instance.Profile = new AzureRMProfile();
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void LoginWithSubscriptionAndTenant()
        {
            var cmdlt = new AddAzureRMAccountCommand();
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.SubscriptionId = "2c224e7e-3ef5-431d-a57b-e71f4662e3a6";
            cmdlt.Tenant = "72f988bf-86f1-41af-91ab-2d7cd011db47";

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            Assert.NotNull(AzureRmProfileProvider.Instance.Profile.Context);
            Assert.Equal("microsoft.com", AzureRmProfileProvider.Instance.Profile.Context.Tenant.Domain);
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void LoginWithInvalidSubscriptionAndTenantThrowsCloudException()
        {
            var cmdlt = new AddAzureRMAccountCommand();
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.SubscriptionId = "2c224e7e-3ef5-431d-a57b-e71f4662e3a5";
            cmdlt.Tenant = "72f988bf-86f1-41af-91ab-2d7cd011db47";

            // Act
            cmdlt.InvokeBeginProcessing();
            Assert.Throws<PSInvalidOperationException>(() => cmdlt.ExecuteCmdlet());
            cmdlt.InvokeEndProcessing();
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void LoginWithSubscriptionAndNoTenant()
        {
            var cmdlt = new AddAzureRMAccountCommand();
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.SubscriptionId = "2c224e7e-3ef5-431d-a57b-e71f4662e3a6";

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            Assert.NotNull(AzureRmProfileProvider.Instance.Profile.Context);
            Assert.Equal("microsoft.com", AzureRmProfileProvider.Instance.Profile.Context.Tenant.Domain);
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void LoginWithNoSubscriptionAndNoTenant()
        {
            var cmdlt = new AddAzureRMAccountCommand();
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            Assert.NotNull(AzureRmProfileProvider.Instance.Profile.Context);
            Assert.Equal("microsoft.com", AzureRmProfileProvider.Instance.Profile.Context.Tenant.Domain);
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void LoginWithNoSubscriptionAndTenant()
        {
            var cmdlt = new AddAzureRMAccountCommand();
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.Tenant = "72f988bf-86f1-41af-91ab-2d7cd011db47";

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            Assert.NotNull(AzureRmProfileProvider.Instance.Profile.Context);
            Assert.Equal("microsoft.com", AzureRmProfileProvider.Instance.Profile.Context.Tenant.Domain);
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void LoginWithSubscriptionname()
        {
            var cmdlt = new AddAzureRMAccountCommand();
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.Tenant = "72f988bf-86f1-41af-91ab-2d7cd011db47";
            cmdlt.SubscriptionName = "Node CLI Test";

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            Assert.NotNull(AzureRmProfileProvider.Instance.Profile.Context);
            Assert.Equal("microsoft.com", AzureRmProfileProvider.Instance.Profile.Context.Tenant.Domain);
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void LoginWithBothSubscriptionIdAndNameThrowsCloudException()
        {
            var cmdlt = new AddAzureRMAccountCommand();
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.Tenant = "72f988bf-86f1-41af-91ab-2d7cd011db47";
            cmdlt.SubscriptionName = "Node CLI Test";
            cmdlt.SubscriptionId = "2c224e7e-3ef5-431d-a57b-e71f4662e3a6";

            // Act
            cmdlt.InvokeBeginProcessing();
            Assert.Throws<PSInvalidOperationException>(() => cmdlt.ExecuteCmdlet());
            cmdlt.InvokeEndProcessing();
        }
    }
}
