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

using System.Collections.Generic;
using Xunit;
using System;
using Microsoft.Azure.Commands.Common.Authentication.Factories;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit.Abstractions;
using Microsoft.WindowsAzure.ServiceManagemenet.Common.Models;

namespace Microsoft.WindowsAzure.Commands.Common.Test.Common
{
    public class AuthenticationFactoryTests
    {
        public AuthenticationFactoryTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void VerifySubscriptionTokenCacheRemove()
        {
            var authFactory = new AuthenticationFactory
            {
                TokenProvider = new MockAccessTokenProvider("testtoken", "testuser")
            };

            var subscriptionId = Guid.NewGuid();

            var credential = authFactory.GetSubscriptionCloudCredentials(new AzureContext(
                new AzureSubscription
                {
                    Id = subscriptionId,
                    Properties = new Dictionary<AzureSubscription.Property, string>
                    {
                        { AzureSubscription.Property.Tenants, "123"}
                    }
                },
                new AzureAccount
                {
                    Id = "testuser",
                    Type = AzureAccount.AccountType.User,
                    Properties = new Dictionary<AzureAccount.Property, string>
                    {
                        { AzureAccount.Property.Tenants, "123" }
                    }
                },
                AzureEnvironment.PublicEnvironments["AzureCloud"]
                
            ));

            Assert.True(credential is AccessTokenCredential);
            Assert.Equal(subscriptionId, new Guid(((AccessTokenCredential)credential).SubscriptionId));

        }
    }
}
