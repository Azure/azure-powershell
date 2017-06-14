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

namespace Microsoft.Azure.Commands.KeyVault.Test
{
    public class KeyVaultEnvSetupHelper : EnvironmentSetupHelper
    {
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

                var testSubscription = new AzureSubscription()
                {
                    Id = csmEnvironment.SubscriptionId,
                    Name = AzureRmProfileProvider.Instance.Profile.DefaultContext.Subscription.Name,
                };
                testSubscription.SetAccount(user);
                testSubscription.SetEnvironment(AzureRmProfileProvider.Instance.Profile.DefaultContext.Environment.Name);
                testSubscription.SetDefault();
                testSubscription.SetStorageAccount(Environment.GetEnvironmentVariable("AZURE_STORAGE_ACCOUNT"));
                testSubscription.SetTenant(tenantId);
                var testAccount = new AzureAccount()
                {
                    Id = user,
                    Type = AzureAccount.AccountType.User,
                };
                testAccount.SetSubscriptions(csmEnvironment.SubscriptionId);
                AzureRmProfileProvider.Instance.Profile.DefaultContext = new AzureContext(testSubscription, testAccount, AzureRmProfileProvider.Instance.Profile.DefaultContext.Environment, new AzureTenant { Id = tenantId });
            }
        }

        private string GetTenantId(TestEnvironment environment)
        {
            if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Record)
            {
                HttpMockServer.Variables["TenantId"] = environment.AuthorizationContext.TenantId;
                return environment.AuthorizationContext.TenantId;
            }
            else
            {
                return HttpMockServer.Variables["TenantId"];
            }
        }

        private string GetUser(TestEnvironment environment)
        {
            if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Record)
            {
                HttpMockServer.Variables["User"] = environment.AuthorizationContext.UserId;
                return environment.AuthorizationContext.UserId;
            }
            else
            {
                return HttpMockServer.Variables["User"];
            }
        }

    }
}
