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

namespace Microsoft.Azure.Commands.DataLakeAnalytics.Test.ScenarioTests
{
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Xunit;

    public class AdlaTests : DataLakeAnalyticsTestRunner
    {
        internal const string ResourceGroupLocation = "eastus2";
        public AdlaTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact(Skip = "Updated Storage client, test needs rerecorded")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlaAccount()
        {
            TestRunner.RunTestScript(string.Format(
                "Test-DataLakeAnalyticsAccount -blobAccountKey -location '{0}'",
                ResourceGroupLocation));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlaAccountTiers()
        {
            TestRunner.RunTestScript(string.Format(
                "Test-DataLakeAnalyticsAccountTiers -location '{0}'",
                ResourceGroupLocation));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlaFirewallRules()
        {
            TestRunner.RunTestScript(string.Format(
                "Test-DataLakeAnalyticsFirewall -location '{0}'",
                ResourceGroupLocation));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlaComputePolicy()
        {
            TestRunner.RunTestScript(string.Format(
                "Test-DataLakeAnalyticsComputePolicy -location '{0}'",
                ResourceGroupLocation));
        }

#if NETSTANDARD
        [Fact(Skip = "Fails on NetStandard, needs investigation: 'UserId' cannot be null")]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlaCatalog()
        {
            TestRunner.RunTestScript(string.Format(
                "Test-DataLakeAnalyticsCatalog -location '{0}'",
                ResourceGroupLocation));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlaJob()
        {
            TestRunner.RunTestScript(string.Format(
                "Test-DataLakeAnalyticsJob -location '{0}'",
                ResourceGroupLocation));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlaJobRelationships()
        {
            TestRunner.RunTestScript(string.Format(
                "Test-DataLakeAnalyticsJobRelationships -location '{0}'",
                ResourceGroupLocation));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNegativeAdlaAccount()
        {
            TestRunner.RunTestScript(string.Format(
                "Test-NegativeDataLakeAnalyticsAccount -location '{0}'",
                ResourceGroupLocation));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNegativeAdlaJob()
        {
            TestRunner.RunTestScript(string.Format(
                "Test-NegativeDataLakeAnalyticsJob -location '{0}'",
                ResourceGroupLocation));
        }
    }
}
