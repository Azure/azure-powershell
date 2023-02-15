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
    public class ElasticJobAgentCrudTests : SqlTestRunner
    {
        public ElasticJobAgentCrudTests(ITestOutputHelper output) : base(output)
        {
        }

        #region Create Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAgentCreate()
        {
            TestRunner.RunTestScript("Test-CreateAgent");
        }

        #endregion

        #region Update Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAgentUpdate()
        {
            TestRunner.RunTestScript("Test-UpdateAgent");
        }

        #endregion

        #region Get Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAgentGet()
        {
            TestRunner.RunTestScript("Test-GetAgent");
        }

        #endregion

        #region Remove Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAgentRemove()
        {
            TestRunner.RunTestScript("Test-RemoveAgent");
        }

        #endregion
    }
}