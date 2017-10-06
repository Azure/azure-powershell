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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Common.Authentication.ResourceManager;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using Xunit;

namespace Microsoft.Azure.Commands.Profile.Test
{
    public class ContextModelTests
    {
        static IAzureAccount account1 = new AzureAccount { Id="user1@contoso.org"};
        static IAzureSubscription subscription1 = new AzureSubscription { Id = Guid.NewGuid().ToString(), Name = "Contoso Subscription 1" };
        static IAzureTenant tenant1 = new AzureTenant { Id = Guid.NewGuid().ToString() };
        static IAzureTokenCache cache = new AzureTokenCache();
        IAzureContext context1 = new AzureContext {
            TokenCache = cache
            }.WithAccount(account1).WithSubscription(subscription1).WithTenant(tenant1);

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetContextCopiesAccountProperties()
        {
            TestExecutionHelpers.SetUpSessionAndProfile();
            var context = new AzureContext();
            var newContext = new AzureContext();
            context.CopyFrom(context1);
            newContext.CopyFrom(context1);
            var token = Guid.NewGuid().ToString();
            newContext.Account.SetProperty(AzureAccount.Property.AccessToken, token);
            var profile = new AzureRmProfile();
            profile.DefaultContext = context;
            string contextName;
            Assert.True(profile.TrySetContext(newContext, out contextName));
            Assert.NotNull(contextName);
            Assert.True(profile.DefaultContext.Account.IsPropertySet(AzureAccount.Property.AccessToken));
            Assert.Equal(token, profile.DefaultContext.Account.GetAccessToken());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetDefaultContextCopiesAccountProperties()
        {
            TestExecutionHelpers.SetUpSessionAndProfile();
            var context = new AzureContext();
            var newContext = new AzureContext();
            context.CopyFrom(context1);
            newContext.CopyFrom(context1);
            var token = Guid.NewGuid().ToString();
            newContext.Account.SetProperty(AzureAccount.Property.AccessToken, token);
            var profile = new AzureRmProfile();
            profile.DefaultContext = context;
            Assert.True(profile.TrySetDefaultContext(newContext));
            Assert.True(profile.DefaultContext.Account.IsPropertySet(AzureAccount.Property.AccessToken));
            Assert.Equal(token, profile.DefaultContext.Account.GetAccessToken());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetContextWithNameCopiesAccountProperties()
        {
            TestExecutionHelpers.SetUpSessionAndProfile();
            var context = new AzureContext();
            var newContext = new AzureContext();
            context.CopyFrom(context1);
            newContext.CopyFrom(context1);
            var token = Guid.NewGuid().ToString();
            newContext.Account.SetProperty(AzureAccount.Property.AccessToken, token);
            var profile = new AzureRmProfile();
            profile.DefaultContext = context;
            Assert.True(profile.TrySetContext(profile.DefaultContextKey, newContext));
            Assert.True(profile.DefaultContext.Account.IsPropertySet(AzureAccount.Property.AccessToken));
            Assert.Equal(token, profile.DefaultContext.Account.GetAccessToken());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetDefaultContextWithNameCopiesAccountProperties()
        {
            TestExecutionHelpers.SetUpSessionAndProfile();
            var context = new AzureContext();
            var newContext = new AzureContext();
            context.CopyFrom(context1);
            newContext.CopyFrom(context1);
            var token = Guid.NewGuid().ToString();
            newContext.Account.SetProperty(AzureAccount.Property.AccessToken, token);
            var profile = new AzureRmProfile();
            profile.DefaultContext = context;
            Assert.True(profile.TrySetDefaultContext(profile.DefaultContextKey, newContext));
            Assert.True(profile.DefaultContext.Account.IsPropertySet(AzureAccount.Property.AccessToken));
            Assert.Equal(token, profile.DefaultContext.Account.GetAccessToken());
        }

    }
}
