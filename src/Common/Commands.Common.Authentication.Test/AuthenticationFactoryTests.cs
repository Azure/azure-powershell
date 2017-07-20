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
using Microsoft.Azure.Commands.Common.Authentication.Factories;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Common.Authentication.Test
{
    public class AuthenticationFactoryTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void VerifySubscriptionTokenCacheRemove()
        {
            AzureSessionInitializer.InitializeAzureSession();
            var authFactory = new AuthenticationFactory
            {
                TokenProvider = new MockAccessTokenProvider("testtoken", "testuser")
            };

            var subscriptionId = Guid.NewGuid();
            var account = new AzureAccount
            {
                Id = "testuser",
                Type = AzureAccount.AccountType.User,
            };
            account.SetTenants("123");
            var sub = new AzureSubscription
            {
                Id = subscriptionId.ToString(),
            };
            sub.SetTenant("123");
            var credential = authFactory.GetSubscriptionCloudCredentials(new AzureContext
            (
                sub,
               account,
                AzureEnvironment.PublicEnvironments["AzureCloud"]
            ));

            Assert.True(credential is AccessTokenCredential);
            Assert.Equal(subscriptionId, new Guid(((AccessTokenCredential)credential).SubscriptionId));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
       public void VerifyValidateAuthorityFalseForOnPremise()
        {
            AzureSessionInitializer.InitializeAzureSession();
            var authFactory = new AuthenticationFactory
            {
                TokenProvider = new MockAccessTokenProvider("testtoken", "testuser")
            };

            var subscriptionId = Guid.NewGuid();
            var account = new AzureAccount
            {
                Id = "testuser",
                Type = AzureAccount.AccountType.User,
            };
            account.SetTenants("123");
            var sub = new AzureSubscription
            {
                Id = subscriptionId.ToString(),
            };
            sub.SetTenant("123");
            var context = new AzureContext
            (
                sub,
                account,
                new AzureEnvironment
                {
                    Name = "Katal",
                    OnPremise = true,
                    ActiveDirectoryAuthority = "http://ad.com",
                    ActiveDirectoryServiceEndpointResourceId = "http://adresource.com"
                }
            );

            var credential = authFactory.Authenticate(context.Account, context.Environment, "common", null, ShowDialog.Always, null);
           
            Assert.False(((MockAccessTokenProvider)authFactory.TokenProvider).AdalConfiguration.ValidateAuthority);            
        }
    }
}
