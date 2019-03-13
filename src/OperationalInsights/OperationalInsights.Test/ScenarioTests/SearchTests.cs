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

using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.OperationalInsights.Test
{
    public class SearchTests : OperationalInsightsScenarioTestBase
    {
        public XunitTracingInterceptor _logger;

        public SearchTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSearchGetSchema()
        {
            RunPowerShellTest(_logger, "Test-SearchGetSchema");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSearchGetSearchResultsAndUpdate()
        {
            RunPowerShellTest(_logger, "Test-SearchGetSearchResultsAndUpdate");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSearchGetSavedSearchesAndResults()
        {
            RunPowerShellTest(_logger, "Test-SearchGetSavedSearchesAndResults");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSearchSetAndRemoveSavedSearches()
        {
            RunPowerShellTest(_logger, "Test-SearchSetAndRemoveSavedSearches");
        }

    }
}
