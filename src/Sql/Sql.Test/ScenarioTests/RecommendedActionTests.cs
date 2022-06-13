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

using Microsoft.Azure.Commands.ScenarioTest.SqlTests;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Sql.Test.ScenarioTests
{
    public class RecommendedActionTests : SqlTestRunner
    {
        public RecommendedActionTests(ITestOutputHelper output) : base(output)
        {
        }

        #region Server Recommended Action Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListServerRecommendedActions()
        {
            TestRunner.RunTestScript("Test-ListServerRecommendedActions");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetServerRecommendedAction()
        {
            TestRunner.RunTestScript("Test-GetServerRecommendedAction");
        }

        [Fact(Skip = "This action is not supported on backend. Verified with feature owners.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateServerRecommendedAction()
        {
            TestRunner.RunTestScript("Test-UpdateServerRecommendedAction");
        }

        #endregion

        #region Database Recommended Action Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListDatabaseRecommendedActions()
        {
            TestRunner.RunTestScript("Test-ListDatabaseRecommendedActions");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetDatabaseRecommendedAction()
        {
            TestRunner.RunTestScript("Test-GetDatabaseRecommendedAction");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateDatabaseRecommendedAction()
        {
            TestRunner.RunTestScript("Test-UpdateDatabaseRecommendedAction");
        }

        #endregion

        #region Elastic Pool Recommended Action Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListElasticPoolRecommendedActions()
        {
            TestRunner.RunTestScript("Test-ListElasticPoolRecommendedActions");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetElasticPoolRecommendedAction()
        {
            TestRunner.RunTestScript("Test-GetElasticPoolRecommendedAction");
        }

        [Fact(Skip = "This action is not supported on backend. Verified with feature owners.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateElasticPoolRecommendedAction()
        {
            TestRunner.RunTestScript("Test-UpdateElasticPoolRecommendedAction");
        }

        #endregion
    }
}
