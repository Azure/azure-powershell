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

namespace Microsoft.Azure.Commands.Sql.Test.ScenarioTests
{
    public class RecommendedElasticPoolTests : SqlTestsBase
    {
        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestRecommendedElasticPoolList()
        {
            RunPowerShellTest("Test-ListRecommendedElasticPools");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestRecommendedElasticPoolGet()
        {
            RunPowerShellTest("Test-GetRecommendedElasticPool");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestRecommendedElasticPoolListDatabase()
        {
            RunPowerShellTest("Test-ListRecommendedElasticPoolDatabases");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestRecommendedElasticPoolGetDatabase()
        {
            RunPowerShellTest("Test-GetRecommendedElasticPoolDatabase");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestRecommendedElasticPoolGetMetrics()
        {
            RunPowerShellTest("Test-GetRecommendedElasticPoolMetrics");
        }
    }
}
