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
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Profile.Test
{
    public class CommonDataCmdletTests
    {
        public CommonDataCmdletTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        public static AzureRMProfile CreateAzureRMProfile(string storageAccount)
        {
            var tenantId = Guid.NewGuid();
            var subscriptionId = Guid.NewGuid();
            var domain = "Contoso.com";
            var context = new PSAzureContext()
            {
                Account = new PSAzureRmAccount
                {
                    Id = "user@contoso.com",
                    AccountType = "User"
                },
                Environment = (PSAzureEnvironment)AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud],
                Subscription =
                new PSAzureSubscription
                {
                    CurrentStorageAccount = storageAccount,
                    CurrentStorageAccountName = PSAzureSubscription.GetAccountName(storageAccount),
                    SubscriptionId = subscriptionId.ToString(),
                    SubscriptionName = "Test Subscription 1",
                    TenantId = tenantId.ToString()
                },
                Tenant = new PSAzureTenant
                {
                    Domain = domain,
                    TenantId = tenantId.ToString()
                }
            };
            return new AzureRMProfile() { Context = context };
        }

        public static AzureSMProfile CreateAzureSMProfile(string storageAccount)
        {
            var profile = new AzureSMProfile();
            var client = new ProfileClient(profile);
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
            client.AddOrSetAccount(account);
            client.AddOrSetSubscription(subscription);
            client.SetSubscriptionAsDefault(subscriptionId, account.Id);
            return profile;
        }

        public static void RunDataProfileTest(AzureRMProfile rmProfile, AzureSMProfile smProfile, Action testAction)
        {
            var savedRmProfile = AzureRmProfileProvider.Instance.Profile;
            var savedSmProfile = AzureSMProfileProvider.Instance.Profile;
            try
            {
                AzureRmProfileProvider.Instance.Profile = rmProfile;
                AzureSMProfileProvider.Instance.Profile = smProfile;
                testAction();
            }
            finally
            {
                AzureRmProfileProvider.Instance.Profile = savedRmProfile;
                AzureSMProfileProvider.Instance.Profile = savedSmProfile;
            }
        }

        [Theory,
        InlineData(null, null),
        InlineData("", null),
        InlineData("AccountName=myAccount", "AccountName=myAccount")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanClearStorageAccountForSMProfile(string connectionString, string expected)
        {
            RunDataProfileTest(
                CreateAzureRMProfile(null),
                CreateAzureSMProfile(connectionString),
                () =>
                {
                    Assert.Equal(expected, AzureSMProfileProvider.Instance.Profile.Context.GetCurrentStorageAccountName());
                    GeneralUtilities.ClearCurrentStorageAccount(true);
                    Assert.True(string.IsNullOrEmpty(AzureSMProfileProvider.Instance.Profile.Context.GetCurrentStorageAccountName()));
                });
        }

        [Theory,
        InlineData(null, null),
        InlineData("", null),
        InlineData("AccountName=myAccount", "AccountName=myAccount")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanClearStorageAccountForRMProfile(string connectionString, string expected)
        {
            RunDataProfileTest(
                CreateAzureRMProfile(connectionString),
                CreateAzureSMProfile(null),
                () =>
                {
                    Assert.Equal(expected, AzureRmProfileProvider.Instance.Profile.Context.GetCurrentStorageAccountName());
                    GeneralUtilities.ClearCurrentStorageAccount();
                    Assert.True(string.IsNullOrEmpty(AzureRmProfileProvider.Instance.Profile.Context.GetCurrentStorageAccountName()));
                });
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanClearStorageAccountForEmptyProfile()
        {
            var rmProfile = new AzureRMProfile();
            rmProfile.Context = new AzureContext(null, null, null, null);
            RunDataProfileTest(
                 rmProfile,
                 new AzureSMProfile(),
                 () =>
                 {
                     GeneralUtilities.ClearCurrentStorageAccount(true);
                     Assert.True(string.IsNullOrEmpty(AzureSMProfileProvider.Instance.Profile.Context.GetCurrentStorageAccountName()));
                 });
        }
    }
}
