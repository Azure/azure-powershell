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

using Microsoft.Azure.Commands.Batch;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.Azure.Commands.Batch.Test;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using Xunit;

namespace Microsoft.Azure.Commands.BatchManager.Test
{
    public class BatchAccountContextTest : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        public BatchAccountContextTest(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void BatchAccountContextFromResourceTest()
        {
            string account = "account";
            string tenantUrlEnding = "batch-test.windows-int.net";
            string endpoint = string.Format("{0}.{1}", account, tenantUrlEnding);
            string subscription = "00000000-0000-0000-0000-000000000000";
            string resourceGroup = "resourceGroup";
            string id = string.Format("id/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Batch/batchAccounts/abc", subscription, resourceGroup);
            PoolAllocationMode allocationMode = PoolAllocationMode.UserSubscription;
            KeyVaultReference keyVault = new KeyVaultReference(
                string.Format("/subscriptions{0}/resourceGroups/{1}/providers/Microsoft.KeyVault/vaults/foo", subscription, resourceGroup),
                "https://foo.vaults.azure.com");

            BatchAccount resource = new BatchAccount(
                coreQuota: BatchTestHelpers.DefaultQuotaCount,
                poolQuota: BatchTestHelpers.DefaultQuotaCount,
                activeJobAndJobScheduleQuota: BatchTestHelpers.DefaultQuotaCount,
                accountEndpoint: endpoint,
                id: id,
                type: "type",
                location: "location",
                provisioningState: ProvisioningState.Succeeded,
                poolAllocationMode: allocationMode,
                keyVaultReference: keyVault);

            BatchAccountContext context = BatchAccountContext.ConvertAccountResourceToNewAccountContext(resource, null);

            Assert.Equal(resource.Id, context.Id);
            Assert.Equal(resource.AccountEndpoint, context.AccountEndpoint);
            Assert.Equal(resource.Location, context.Location);
            Assert.Equal(resource.ProvisioningState.ToString(), context.State);
            Assert.Equal(account, context.AccountName);
            Assert.Equal(string.Format("https://{0}", endpoint), context.TaskTenantUrl);
            Assert.Equal(subscription, context.Subscription);
            Assert.Equal(resourceGroup, context.ResourceGroupName);
            Assert.Equal(allocationMode, context.PoolAllocationMode);
            Assert.Equal(keyVault.Id, context.KeyVaultReference.Id);
            Assert.Equal(keyVault.Url, context.KeyVaultReference.Url);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void HasKeysPropertyIsCorrect()
        {
            BatchAccountContext context = new BatchAccountContext(null);
            Assert.False(context.HasKeys);

            context.PrimaryAccountKey = "key1";
            Assert.True(context.HasKeys);

            context.PrimaryAccountKey = null;
            context.SecondaryAccountKey = "key2";
            Assert.True(context.HasKeys);

            context.PrimaryAccountKey = "key1";
            context.SecondaryAccountKey = "key2";
            Assert.True(context.HasKeys);
        }
    }
}
