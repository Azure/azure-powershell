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
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Sql.Test.ScenarioTests
{
    public class AdvisorTests : SqlTestsBase
    {
        public AdvisorTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        #region Server Advisor Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListServerAdvisors()
        {
            RunPowerShellTest("Test-ListServerAdvisors");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListServerAdvisorsExpanded()
        {
            RunPowerShellTest("Test-ListServerAdvisorsExpanded");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetServerAdvisor()
        {
            RunPowerShellTest("Test-GetServerAdvisor");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateServerAdvisor()
        {
            RunPowerShellTest("Test-UpdateServerAdvisor");
        }

        #endregion

        #region Database Advisor Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListDatabaseAdvisors()
        {
            RunPowerShellTest("Test-ListDatabaseAdvisors");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListDatabaseAdvisorsExpanded()
        {
            RunPowerShellTest("Test-ListDatabaseAdvisorsExpanded");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetDatabaseAdvisor()
        {
            RunPowerShellTest("Test-GetDatabaseAdvisor");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateDatabaseAdvisor()
        {
            RunPowerShellTest("Test-UpdateDatabaseAdvisor");
        }

        #endregion

        #region Elastic Pool Advisor Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListElasticPoolAdvisors()
        {
            RunPowerShellTest("Test-ListElasticPoolAdvisors");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListElasticPoolAdvisorsExpanded()
        {
            RunPowerShellTest("Test-ListElasticPoolAdvisorsExpanded");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetElasticPoolAdvisor()
        {
            RunPowerShellTest("Test-GetElasticPoolAdvisor");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateElasticPoolAdvisor()
        {
            RunPowerShellTest("Test-UpdateElasticPoolAdvisor");
        }

        #endregion
    }
}
