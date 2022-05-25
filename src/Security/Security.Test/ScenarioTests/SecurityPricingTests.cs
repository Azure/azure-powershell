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

namespace Microsoft.Azure.Commands.Security.Test.ScenarioTests
{
    public class SecurityPricingTests : SecurityTestRunner
    {
        public SecurityPricingTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetSubscriptionScope()
        {
            TestRunner.RunTestScript("Get-AzureRmSecurityPricing-SubscriptionScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetSubscriptionLevelResource()
        {
            TestRunner.RunTestScript("Get-AzureRmSecurityPricing-SubscriptionLevelResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetResourceId()
        {
            TestRunner.RunTestScript("Get-AzureRmSecurityPricing-ResourceId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetSubscriptionLevelResource()
        {
            TestRunner.RunTestScript("Set-AzureRmSecurityPricing-SubscriptionLevelResource");
        }
    }
}
