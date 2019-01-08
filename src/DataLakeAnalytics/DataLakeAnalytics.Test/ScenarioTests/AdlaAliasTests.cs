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
    using ServiceManagement.Common.Models;
    using Xunit;

    public class AdlaAliasTests : AdlaTestsBase
    {
        public XunitTracingInterceptor _logger;

        public AdlaAliasTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact(Skip = "Updated Storage client, test needs rerecorded")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlaAccount()
        {
            AdlaTestsBase.NewInstance.RunPsTest(true,
                _logger,
                string.Format(
                    "Test-DataLakeAnalyticsAccount -blobAccountKey -location '{0}'",
                    AdlaTestsBase.ResourceGroupLocation));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlaAccountTiers()
        {
            AdlaTestsBase.NewInstance.RunPsTest(false,
                _logger,
                string.Format(
                    "Test-DataLakeAnalyticsAccountTiers -location '{0}'",
                    AdlaTestsBase.ResourceGroupLocation));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlaFirewallRules()
        {
            AdlaTestsBase.NewInstance.RunPsTest(false,
                _logger,
                string.Format(
                    "Test-DataLakeAnalyticsFirewall -location '{0}'",
                    AdlaTestsBase.ResourceGroupLocation));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlaComputePolicy()
        {
            AdlaTestsBase.NewInstance.RunPsTest(false,
                _logger,
                string.Format(
                    "Test-DataLakeAnalyticsComputePolicy -location '{0}'",
                    AdlaTestsBase.ResourceGroupLocation));
        }

#if NETSTANDARD
        [Fact(Skip = "Fails on NetStandard, needs investigation: 'UserId' cannot be null")]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlaCatalog()
        {
            AdlaTestsBase.NewInstance.RunPsTest(false,
                _logger,
                string.Format(
                    "Test-DataLakeAnalyticsCatalog -location '{0}'",
                    AdlaTestsBase.ResourceGroupLocation));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlaJob()
        {
            AdlaTestsBase.NewInstance.RunPsTest(false,
                _logger,
                string.Format(
                    "Test-DataLakeAnalyticsJob -location '{0}'",
                    AdlaTestsBase.ResourceGroupLocation));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAdlaJobRelationships()
        {
            AdlaTestsBase.NewInstance.RunPsTest(false,
                _logger,
                string.Format(
                    "Test-DataLakeAnalyticsJobRelationships -location '{0}'",
                    AdlaTestsBase.ResourceGroupLocation));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNegativeAdlaAccount()
        {
            AdlaTestsBase.NewInstance.RunPsTest(false,
                _logger,
                string.Format(
                    "Test-NegativeDataLakeAnalyticsAccount -location '{0}'",
                    AdlaTestsBase.ResourceGroupLocation));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNegativeAdlaJob()
        {
            AdlaTestsBase.NewInstance.RunPsTest(false,
                _logger,
                string.Format(
                    "Test-NegativeDataLakeAnalyticsJob -location '{0}'",
                    AdlaTestsBase.ResourceGroupLocation));
        }
    }
}
