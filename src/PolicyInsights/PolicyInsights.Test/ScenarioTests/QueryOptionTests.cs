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

namespace Microsoft.Azure.Commands.PolicyInsights.Test.ScenarioTests
{
    public class QueryOptionTests : PolicyInsightsTestRunner
    {
        public QueryOptionTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void QueryResultsWithFrom()
        {
            TestRunner.RunTestScript("QueryOptions-QueryResultsWithFrom");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void QueryResultsWithTo()
        {
            TestRunner.RunTestScript("QueryOptions-QueryResultsWithTo");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void QueryResultsWithTop()
        {
            TestRunner.RunTestScript("QueryOptions-QueryResultsWithTop");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void QueryResultsWithOrderBy()
        {
            TestRunner.RunTestScript("QueryOptions-QueryResultsWithOrderBy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void QueryResultsWithSelect()
        {
            TestRunner.RunTestScript("QueryOptions-QueryResultsWithSelect");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void QueryResultsWithFilter()
        {
            TestRunner.RunTestScript("QueryOptions-QueryResultsWithFilter");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void QueryResultsWithApply()
        {
            TestRunner.RunTestScript("QueryOptions-QueryResultsWithApply");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void QueryResultsWithExpandPolicyEvaluationDetails()
        {
            TestRunner.RunTestScript("QueryOptions-QueryResultsWithExpandPolicyEvaluationDetails");
        }
    }
}
