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
using System.Linq;

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

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanAuthenticateWithAccessToken()
        {
            AzureSessionInitializer.InitializeAzureSession();
            string tenant = Guid.NewGuid().ToString();
            string userId = "user1@contoso.org";
            var armToken = Guid.NewGuid().ToString();
            var graphToken = Guid.NewGuid().ToString();
            var kvToken = Guid.NewGuid().ToString();
            var account = new AzureAccount
            {
                Id = userId,
                Type = AzureAccount.AccountType.AccessToken
            };
            account.SetTenants(tenant);
            account.SetAccessToken(armToken);
            account.SetProperty(AzureAccount.Property.GraphAccessToken, graphToken);
            account.SetProperty(AzureAccount.Property.KeyVaultAccessToken, kvToken);
            var authFactory = new AuthenticationFactory();
            var environment = AzureEnvironment.PublicEnvironments.Values.First();
            var checkArmToken = authFactory.Authenticate(account, environment, tenant, new System.Security.SecureString(), "Never", null);
            VerifyToken(checkArmToken, armToken, userId, tenant);
            checkArmToken = authFactory.Authenticate(account, environment, tenant, new System.Security.SecureString(), "Never", null, environment.ActiveDirectoryServiceEndpointResourceId);
            VerifyToken(checkArmToken, armToken, userId, tenant);
            var checkGraphToken = authFactory.Authenticate(account, environment, tenant, new System.Security.SecureString(), "Never", null, AzureEnvironment.Endpoint.GraphEndpointResourceId);
            VerifyToken(checkGraphToken, graphToken, userId, tenant);
            checkGraphToken = authFactory.Authenticate(account, environment, tenant, new System.Security.SecureString(), "Never", null, environment.GraphEndpointResourceId);
            VerifyToken(checkGraphToken, graphToken, userId, tenant);
            var checkKVToken = authFactory.Authenticate(account, environment, tenant, new System.Security.SecureString(), "Never", null, environment.AzureKeyVaultServiceEndpointResourceId);
            VerifyToken(checkKVToken, kvToken, userId, tenant);
            checkKVToken = authFactory.Authenticate(account, environment, tenant, new System.Security.SecureString(), "Never", null, AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId);
            VerifyToken(checkKVToken, kvToken, userId, tenant);
        }

        void VerifyToken(IAccessToken checkToken, string expectedAccessToken, string expectedUserId, string expectedTenant)
        {

            Assert.True(checkToken is RawAccessToken);
            Assert.Equal(expectedAccessToken, checkToken.AccessToken);
            Assert.Equal(expectedUserId, checkToken.UserId);
            Assert.Equal(expectedTenant, checkToken.TenantId);
            checkToken.AuthorizeRequest((type, token) =>
            {
                Assert.Equal(expectedAccessToken, token);
                Assert.Equal("Bearer", type);
            });
        }

    }
}
