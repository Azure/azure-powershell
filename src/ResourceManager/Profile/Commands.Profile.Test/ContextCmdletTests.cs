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
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Profile;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Microsoft.Azure.Commands.ResourceManager.Profile.Test
{
    public class ContextCmdletTests : RMTestBase
    {
        private MemoryDataStore dataStore;
        private MockCommandRuntime commandRuntimeMock;
        const string guid1 = "a0cc8bd7-2c6a-47e9-a4c4-3f6ed136e240";
        const string guid2 = "eab635c0-a35a-4f70-9e46-e5351c7b5c8b";
        const string guid3 = "52f66548-2550-417b-941e-9d6e04f3ac8d";
        const string guid4 = "40e67ee2-1a1a-4517-9253-ab6f93c5710f";
        public ContextCmdletTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
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
            var context = (PSAzureContext)commandRuntimeMock.OutputPipeline[0];
            Assert.Equal("test", context.Subscription.SubscriptionName);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SelectAzureContextWithNoSubscriptionAndTenant()
        {
            var cmdlt = new SetAzureRMContextCommand();
            var tenantToSet = "72f988bf-86f1-41af-91ab-2d7cd011db47";

            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;

            // Make sure that the tenant ID we are attempting to set is
            // valid for the account
            var account = AzureRmProfileProvider.Instance.Profile.Context.Account;
            var existingTenants = account.GetProperty(AzureAccount.Property.Tenants);
            var allowedTenants = existingTenants == null ? tenantToSet : existingTenants + "," + tenantToSet;
            account.SetProperty(AzureAccount.Property.Tenants, allowedTenants);
            account.SetProperty(AzureAccount.Property.Subscriptions, new string[0]);

            cmdlt.TenantId = tenantToSet;

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            Assert.True(commandRuntimeMock.OutputPipeline.Count == 1);
            var context = (PSAzureContext)commandRuntimeMock.OutputPipeline[0];

            // TenantId is not sufficient to change the context.
            Assert.NotEqual(tenantToSet, context.Tenant.TenantId);
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
