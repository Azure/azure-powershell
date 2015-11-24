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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Models;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.Commands.Utilities.Common;
using System;
using Xunit;

namespace Microsoft.Azure.Commands.Profile.Test
{
    public class CommonDataCmdletTests
    {
        public static AzureRMProfile CreateAzureRMProfile(string storageAccount)
        {
            var tenantId = Guid.NewGuid();
            var subscriptionId = Guid.NewGuid();
            var domain = "Contoso.com";
            var subscription = new AzureSubscription
            {
                Id = subscriptionId,
                Name = "Test Subscription 1"
            };
            subscription.SetProperty(AzureSubscription.Property.StorageAccount, storageAccount);
            subscription.SetProperty(AzureSubscription.Property.Tenants, tenantId.ToString());
            var context = new PSAzureContext()
            {
                Account = new PSAzureRmAccount
                {
                    Id = "user@contoso.com",
                    AccountType = "AccessToken",
                    AccessToken = Guid.NewGuid().ToString()
                },
                Environment = (PSAzureEnvironment)AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud],
                Subscription = 
                (PSAzureSubscription)subscription,

                Tenant = new PSAzureTenant
                {
                    Domain=domain,
                    TenantId = tenantId.ToString()
                }
            };
            return new AzureRMProfile() { Context = context};
        }

        public static AzureSMProfile CreateAzureSMProfile(string storageAccount)
        {
            var profile = new AzureSMProfile();
            var tenantId = Guid.NewGuid();
            var subscriptionId = Guid.NewGuid();
            var account = new AzureAccount
            {
                Id = "user@contoso.com",
                Type = AzureAccount.AccountType.User
            };
            account.SetProperty(AzureAccount.Property.Tenants, tenantId.ToString());
            account.SetProperty(AzureAccount.Property.Subscriptions, subscriptionId.ToString());
            var subscription = new AzureSubscription()
            {
                Id = subscriptionId,
                Name = "Test Subscription 1",
                Environment = EnvironmentName.AzureCloud,
                Account = account.Id,
            };
            subscription.SetProperty(AzureSubscription.Property.Tenants, tenantId.ToString());
            subscription.SetProperty(AzureSubscription.Property.StorageAccount, storageAccount);
            profile.Accounts[account.Id ] = account;
            profile.Subscriptions[subscription.Id] = subscription;
            subscription.SetProperty(AzureSubscription.Property.Default, "true");
            return profile;
        }

        public static void RunDataProfileTest(AzureRMProfile rmProfile, AzureSMProfile smProfile, Action<AzureRMProfile, AzureSMProfile> testAction)
        {
                testAction(rmProfile, smProfile);
       }

        //[Theory,
        //InlineData(null, null),
        //InlineData("", null),
        //InlineData("AccountName=myAccount","AccountName=myAccount")]
       // [Trait(Category.AcceptanceType, Category.CheckIn)]
       //public void CanClearStorageAccountForRMProfile(string connectionString, string expected)
       // {
       //     RunDataProfileTest(
       //         CreateAzureRMProfile(connectionString),
       //         CreateAzureSMProfile(null),
       //         (rm, sm) =>
       //         {
       //             Assert.Equal(expected, rm.Context.GetCurrentStorageAccountName());
       //             GeneralUtilities.ClearCurrentStorageAccount(new MemoryDataStore(), rm );
       //             Assert.True(string.IsNullOrEmpty(rm.Context.GetCurrentStorageAccountName()));
       //         });
       // }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
       public void CanClearStorageAccountForEmptyProfile()
        {
            var rmProfile = new AzureRMProfile();
            rmProfile.Context = new AzureContext(null, null, null, null);
           RunDataProfileTest(
                rmProfile, 
                new AzureSMProfile(), 
                (rm, sm) =>
                {
                    GeneralUtilities.ClearCurrentStorageAccount(new MemoryDataStore(), rm);
                });
        }
}
}
