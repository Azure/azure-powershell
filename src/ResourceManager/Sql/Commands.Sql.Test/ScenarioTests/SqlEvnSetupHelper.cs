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
                        Id = new Guid(csmEnvironment.SubscriptionId),
                        Name = AzureRmProfileProvider.Instance.Profile.Context.Subscription.Name,
                        Environment = AzureRmProfileProvider.Instance.Profile.Context.Subscription.Environment,
                        Account = user,
                        Properties = new Dictionary<AzureSubscription.Property, string>
                    {
                        {
                            AzureSubscription.Property.Default, "True"
                        },
                        {
                            AzureSubscription.Property.StorageAccount,
                            Environment.GetEnvironmentVariable("AZURE_STORAGE_ACCOUNT")
                        },
                        {
                            AzureSubscription.Property.Tenants, tenantId
                        },
                    }
                    };

                    var testAccount = new AzureAccount()
                    {
                        Id = user,
                        Type = AzureAccount.AccountType.User,
                        Properties = new Dictionary<AzureAccount.Property, string>
                    {
                        {
                            AzureAccount.Property.Subscriptions, csmEnvironment.SubscriptionId
                        },
                    }
                    };

                    AzureRmProfileProvider.Instance.Profile.Context.Subscription.Name = testSubscription.Name;
                    AzureRmProfileProvider.Instance.Profile.Context.Subscription.Id = testSubscription.Id;
                    AzureRmProfileProvider.Instance.Profile.Context.Subscription.Account = testSubscription.Account;

                    var environment = AzureRmProfileProvider.Instance.Profile.Environments[AzureRmProfileProvider.Instance.Profile.Context.Subscription.Environment];
                    environment.Endpoints[AzureEnvironment.Endpoint.Graph] = csmEnvironment.Endpoints.GraphUri.AbsoluteUri;
                    environment.Endpoints[AzureEnvironment.Endpoint.StorageEndpointSuffix] = "core.windows.net";
                    AzureRmProfileProvider.Instance.Profile.Save();
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