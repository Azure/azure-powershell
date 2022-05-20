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

namespace Microsoft.Azure.Commands.CosmosDB.Test.ScenarioTests.ScenarioTest
{
    public class SqlOperationsTests : CosmosDBTestRunner
    {
        public SqlOperationsTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSqlOperationsCmdlets()
        {
            TestRunner.RunTestScript("Test-SqlOperationsCmdlets");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSqlOperationsCmdletsUsingInputObject()
        {
            TestRunner.RunTestScript("Test-SqlOperationsCmdletsUsingInputObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSqlThroughputCmdlets()
        {
            TestRunner.RunTestScript("Test-SqlThroughputCmdlets");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSqlMigrateThroughputCmdlets()
        {
            TestRunner.RunTestScript("Test-SqlMigrateThroughputCmdlets");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSqlRoleCmdlets()
        {
            TestRunner.RunTestScript("Test-SqlRoleCmdlets");
        }

        [Fact(Skip = "Cannot acquire token credential for a specific audience. No support from test framework. I have verified the tests manually.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestClientEncryptionKeyCmdlets()
        {
            TestRunner.RunTestScript("Test-ClientEncryptionKeyCmdlets");
        }

        [Fact(Skip = "Cannot acquire token credential for a specific audience. No support from test framework. I have verified the tests manually.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestClientEncryptionKeyCmdletsUsingInputObject()
        {
            TestRunner.RunTestScript("Test-ClientEncryptionKeyCmdletsUsingInputObject");
        }

        [Fact(Skip = "Cannot acquire token credential for a specific audience. No support from test framework. I have verified the tests manually.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSqlContainerMergeCmdlet()
        {
            TestRunner.RunTestScript("Test-SqlContainerMergeCmdlet");
        }

        [Fact(Skip = "Cannot acquire token credential for a specific audience. No support from test framework. I have verified the tests manually.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSqlContainerAdaptiveRUCmdlets()
        {
            TestRunner.RunTestScript("Test-SqlContainerAdaptiveRUCmdlets");
        }
    }
}