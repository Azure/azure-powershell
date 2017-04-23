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
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ScenarioTest;
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
            TestExecutionHelpers.SetUpSessionAndProfile();
            ServiceManagementProfileProvider.InitializeServiceManagementProfile();
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        public static AzureRmProfile CreateAzureRMProfile(string storageAccount)
        {
            var tenantId = Guid.NewGuid();
            var subscriptionId = Guid.NewGuid();
            var domain = "Contoso.com";
            var context = new PSAzureContext()
            {
                Account = new PSAzureRmAccount
                {
                    Id = "user@contoso.com",
                    Type = "User"
                },
                Environment = (PSAzureEnvironment)AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud],
                Subscription =
                new PSAzureSubscription
                {
                    CurrentStorageAccount = storageAccount,
                    Id = subscriptionId.ToString(),
                    Name = "Test Subscription 1",
                    TenantId = tenantId.ToString()
                },
                Tenant = new PSAzureTenant
                {
                    Directory = domain,
                    Id = tenantId.ToString()
                }
            };
            return new AzureRmProfile() { DefaultContext = context };
        }

        public static AzureSMProfile CreateAzureSMProfile  (string storageAccount)
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
                Id = subscriptionId.ToString(),
                Name = "Test Subscription 1",
            };

            subscription.SetEnvironment(EnvironmentName.AzureCloud);
            subscription.SetAccount(account.Id);
            subscription.SetTenant(tenantId.ToString());
            subscription.SetStorageAccount(storageAccount);
            client.AddOrSetAccount(account);
            client.AddOrSetSubscription(subscription);
            client.SetSubscriptionAsDefault(subscriptionId, account.Id);
            return profile;
        }

        public static void RunDataProfileTest(AzureRmProfile rmProfile, AzureSMProfile smProfile, Action testAction)
        {
            AzureSession.Instance.DataStore = new MemoryDataStore();
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
                    Assert.Equal(expected, AzureSMProfileProvider.Instance.Profile.DefaultContext.GetCurrentStorageAccountName());
                    GeneralUtilities.ClearCurrentStorageAccount(true);
                    Assert.True(string.IsNullOrEmpty(AzureSMProfileProvider.Instance.Profile.DefaultContext.GetCurrentStorageAccountName()));
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
                    Assert.Equal(expected, AzureRmProfileProvider.Instance.Profile.DefaultContext.GetCurrentStorageAccountName());
                    GeneralUtilities.ClearCurrentStorageAccount();
                    Assert.True(string.IsNullOrEmpty(AzureRmProfileProvider.Instance.Profile.DefaultContext.GetCurrentStorageAccountName()));
                });
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanClearStorageAccountForEmptyProfile()
        {
            var rmProfile = new AzureRmProfile();
            rmProfile.DefaultContext = new AzureContext(null, null, null, null);
            RunDataProfileTest(
                 rmProfile,
                 new AzureSMProfile(),
                 () =>
                 {
                     GeneralUtilities.ClearCurrentStorageAccount(true);
                     Assert.True(string.IsNullOrEmpty(AzureSMProfileProvider.Instance.Profile.DefaultContext.GetCurrentStorageAccountName()));
                 });
        }
    }
}
