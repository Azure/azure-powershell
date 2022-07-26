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

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.ResourceGraph.Test.ScenarioTests
{
    public class ResourceGraphQueryTests : ResourceGraphTestRunner
    {
        public ResourceGraphQueryTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Query()
        {
            TestRunner.RunTestScript("Search-AzureRmGraph-Query");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PagedQuery()
        {
            TestRunner.RunTestScript("Search-AzureRmGraph-PagedQuery");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Subscriptions()
        {
            TestRunner.RunTestScript("Search-AzureRmGraph-Subscriptions");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ManagementGroups()
        {
            TestRunner.RunTestScript("Search-AzureRmGraph-ManagementGroups");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Tenant()
        {
            TestRunner.RunTestScript("Search-AzureRmGraph-Tenant");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SkipTokenQuery()
        {
            TestRunner.RunTestScript("Search-AzureRmGraph-SkipTokenQuery");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void QueryError()
        {
            TestRunner.RunTestScript("Search-AzureRmGraph-QueryError");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SubscriptionAndManagementGroupQueryError()
        {
            TestRunner.RunTestScript("Search-AzureRmGraph-SubscriptionAndManagementGroupQueryError");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SubscriptionAndTenantQueryError()
        {
            TestRunner.RunTestScript("Search-AzureRmGraph-SubscriptionAndTenantQueryError");
        }
    }
}
