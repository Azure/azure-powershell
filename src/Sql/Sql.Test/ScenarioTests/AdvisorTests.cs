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
    public class AdvisorTests : SqlTestRunner
    {
        public AdvisorTests(ITestOutputHelper output) : base(output)
        {

        }

        #region Server Advisor Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListServerAdvisors()
        {
            TestRunner.RunTestScript("Test-ListServerAdvisors");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListServerAdvisorsExpanded()
        {
            TestRunner.RunTestScript("Test-ListServerAdvisorsExpanded");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetServerAdvisor()
        {
            TestRunner.RunTestScript("Test-GetServerAdvisor");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateServerAdvisor()
        {
            TestRunner.RunTestScript("Test-UpdateServerAdvisor");
        }

        #endregion

        #region Database Advisor Tests

        [Fact(Skip = "unable to re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListDatabaseAdvisors()
        {
            TestRunner.RunTestScript("Test-ListDatabaseAdvisors");
        }

        [Fact(Skip = "unable to re-record")]
        public void TestListDatabaseAdvisorsExpanded()
        {
            TestRunner.RunTestScript("Test-ListDatabaseAdvisorsExpanded");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetDatabaseAdvisor()
        {
            TestRunner.RunTestScript("Test-GetDatabaseAdvisor");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateDatabaseAdvisor()
        {
            TestRunner.RunTestScript("Test-UpdateDatabaseAdvisor");
        }

        #endregion

        #region Elastic Pool Advisor Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListElasticPoolAdvisors()
        {
            TestRunner.RunTestScript("Test-ListElasticPoolAdvisors");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListElasticPoolAdvisorsExpanded()
        {
            TestRunner.RunTestScript("Test-ListElasticPoolAdvisorsExpanded");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetElasticPoolAdvisor()
        {
            TestRunner.RunTestScript("Test-GetElasticPoolAdvisor");
        }

        #endregion
    }
}
