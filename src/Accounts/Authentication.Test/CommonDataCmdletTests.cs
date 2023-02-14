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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core;
using Microsoft.Azure.Commands.Profile.Models.Core;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Common.Authentication.Test
{
    public class CommonDataCmdletTests
    {
        public CommonDataCmdletTests(ITestOutputHelper output)
        {
            TestExecutionHelpers.SetUpSessionAndProfile();
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        public static AzureRmProfile CreateAzureRMProfile(string storageAccount)
        {
            var tenantId = Guid.NewGuid();
            var subscriptionId = Guid.NewGuid();
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
                    Id = tenantId.ToString()
                }
            };
            return new AzureRmProfile() { DefaultContext = context };
        }

        public static IAzureContextContainer CreateAzureSMProfile(string storageAccount)
        {
            return null;
        }

        private static void RunDataProfileTest(IAzureContextContainer rmProfile, IAzureContextContainer smProfile, Action testAction)
        {
            AzureSession.Instance.DataStore = new MemoryDataStore();
            var savedRmProfile = AzureRmProfileProvider.Instance.Profile;
            try
            {
                AzureRmProfileProvider.Instance.Profile = rmProfile;
                testAction();
            }
            finally
            {
                AzureRmProfileProvider.Instance.Profile = savedRmProfile;
            }
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
    }
}
