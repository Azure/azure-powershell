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
    public class RecommendedActionTests : SqlTestsBase
    {
        public RecommendedActionTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        #region Server Recommended Action Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListServerRecommendedActions()
        {
            RunPowerShellTest("Test-ListServerRecommendedActions");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetServerRecommendedAction()
        {
            RunPowerShellTest("Test-GetServerRecommendedAction");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateServerRecommendedAction()
        {
            RunPowerShellTest("Test-UpdateServerRecommendedAction");
        }

        #endregion

        #region Database Recommended Action Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListDatabaseRecommendedActions()
        {
            RunPowerShellTest("Test-ListDatabaseRecommendedActions");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetDatabaseRecommendedAction()
        {
            RunPowerShellTest("Test-GetDatabaseRecommendedAction");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateDatabaseRecommendedAction()
        {
            RunPowerShellTest("Test-UpdateDatabaseRecommendedAction");
        }

        #endregion

        #region Elastic Pool Recommended Action Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListElasticPoolRecommendedActions()
        {
            RunPowerShellTest("Test-ListElasticPoolRecommendedActions");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetElasticPoolRecommendedAction()
        {
            RunPowerShellTest("Test-GetElasticPoolRecommendedAction");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateElasticPoolRecommendedAction()
        {
            RunPowerShellTest("Test-UpdateElasticPoolRecommendedAction");
        }

        #endregion
    }
}
