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
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.ScenarioTest.SqlTests
{
    public class SqlEvnSetupHelper : EnvironmentSetupHelper
    {
        /// <summary>
        /// This overrides the default subscription and default account. This allows the 
        /// test to get the tenant id in the test.
        /// </summary>
        public void SetupEnvironment()
        {
            base.SetupEnvironment(AzureModule.AzureResourceManager);

            TestEnvironment csmEnvironment = new CSMTestEnvironmentFactory().GetTestEnvironment();

            if (csmEnvironment.SubscriptionId != null)
            {
                //Overwrite the default subscription and default account
                //with ones using user ID and tenant ID from auth context
                var user = GetUser(csmEnvironment);
                var tenantId = GetTenantId(csmEnvironment);

                // Existing test will not have a user or tenant id set
                if (tenantId != null && user != null)
                {
                    var testSubscription = new AzureSubscription()
                    {
                        Id = csmEnvironment.SubscriptionId,
                        Name = AzureRmProfileProvider.Instance.Profile.DefaultContext.Subscription.Name,
                    };

                    testSubscription.SetAccount(user);
                    testSubscription.SetEnvironment(AzureRmProfileProvider.Instance.Profile.DefaultContext.Subscription.GetEnvironment());
                    testSubscription.SetDefault();
                    testSubscription.SetStorageAccount(Environment.GetEnvironmentVariable("AZURE_STORAGE_ACCOUNT"));
                    testSubscription.SetTenant(tenantId);
                    var testAccount = new AzureAccount()
                    {
                        Id = user,
                        Type = AzureAccount.AccountType.User,
                    };

                    testAccount.SetSubscriptions(csmEnvironment.SubscriptionId);

                    AzureRmProfileProvider.Instance.Profile.DefaultContext.Subscription.Name = testSubscription.Name;
                    AzureRmProfileProvider.Instance.Profile.DefaultContext.Subscription.Id = testSubscription.Id;
                    AzureRmProfileProvider.Instance.Profile.DefaultContext.Subscription.SetAccount(testSubscription.GetAccount());

                    var environment = AzureRmProfileProvider.Instance.Profile.GetEnvironment(AzureRmProfileProvider.Instance.Profile.DefaultContext.Subscription.GetEnvironment());
                    environment.SetEndpoint(AzureEnvironment.Endpoint.Graph, csmEnvironment.Endpoints.GraphUri.AbsoluteUri);
                    environment.SetEndpoint(AzureEnvironment.Endpoint.StorageEndpointSuffix, "core.windows.net");
                    AzureRmProfileProvider.Instance.GetProfile<AzureRmProfile>().Save();
                }
            }
        }

        /// <summary>
        /// Helper function to get the tenant id if it was set in the test
        /// </summary>
        /// <param name="environment">Test environment</param>
        /// <returns>The tenant id or null if not tenant id could be found.</returns>
        private string GetTenantId(TestEnvironment environment)
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                HttpMockServer.Variables["TenantId"] = environment.AuthorizationContext.TenantId;
                return environment.AuthorizationContext.TenantId;
            }
            else
            {
                if (HttpMockServer.Variables.ContainsKey("TenantId"))
                {
                    return HttpMockServer.Variables["TenantId"];
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Helper function to get the user id if it was set in the test
        /// </summary>
        /// <param name="environment">Test environment</param>
        /// <returns>The user id or null if not tenant id could be found.</returns>
        private string GetUser(TestEnvironment environment)
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                HttpMockServer.Variables["User"] = environment.AuthorizationContext.UserId;
                return environment.AuthorizationContext.UserId;
            }
            else
            {
                if (HttpMockServer.Variables.ContainsKey("User"))
                {
                    return HttpMockServer.Variables["User"];
                }
                else
                {
                    return null;
                }

            }
        }

    }
}
