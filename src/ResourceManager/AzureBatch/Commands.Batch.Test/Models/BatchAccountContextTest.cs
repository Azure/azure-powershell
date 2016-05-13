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
        public void BatchAccountContextConstructorTest()
        {
            string endpoint = new UriBuilder(Uri.UriSchemeHttps, "account.batch-test.windows-int.net").Uri.AbsoluteUri.ToString();
            var acctContext = new BatchAccountContext(endpoint);

            Assert.Equal<string>(endpoint, acctContext.AccountEndpoint);
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

            AccountResource resource = new AccountResource(
                coreQuota: BatchTestHelpers.DefaultQuotaCount,
                poolQuota: BatchTestHelpers.DefaultQuotaCount,
                activeJobAndJobScheduleQuota: BatchTestHelpers.DefaultQuotaCount,
                id: id,
                type: "type")
            {
                Location = "location",
                AccountEndpoint = endpoint,
                ProvisioningState = AccountProvisioningState.Succeeded,
            };
            BatchAccountContext context = BatchAccountContext.ConvertAccountResourceToNewAccountContext(resource);

            Assert.Equal<string>(context.Id, resource.Id);
            Assert.Equal<string>(context.AccountEndpoint, resource.AccountEndpoint);
            Assert.Equal<string>(context.Location, resource.Location);
            Assert.Equal<string>(context.State, resource.ProvisioningState.ToString());
            Assert.Equal<string>(context.AccountName, account);
            Assert.Equal<string>(context.TaskTenantUrl, string.Format("https://{0}", endpoint));
            Assert.Equal<string>(context.Subscription, subscription);
            Assert.Equal<string>(context.ResourceGroupName, resourceGroup);
        }
    }
}
