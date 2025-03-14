﻿// ----------------------------------------------------------------------------------
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
    public class TableOperationsTests : CosmosDBTestRunner
    {
        public TableOperationsTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestTableOperationsCmdlets()
        {
            TestRunner.RunTestScript("Test-TableOperationsCmdlets");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestTableOperationsCmdletsUsingInputObject()
        {
            TestRunner.RunTestScript("Test-TableOperationsCmdletsUsingInputObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestTableThroughputCmdlets()
        {
            TestRunner.RunTestScript("Test-TableThroughputCmdlets");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestTableMigrateThroughputCmdlets()
        {
            TestRunner.RunTestScript("Test-TableMigrateThroughputCmdlets");
        }

        [Fact(Skip = "Output of DateTime.ToString() is different in MacOs.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestTableInAccountCoreFunctionalityNoTimestampBasedRestoreCmdletsV2()
        {
            TestRunner.RunTestScript("Test-TableInAccountCoreFunctionalityNoTimestampBasedRestoreCmdletsV2");
        }

        [Fact(Skip = "Output of DateTime.ToString() is different in MacOs.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestTableInAccountRestoreOperationsCmdlets()
        {
            TestRunner.RunTestScript("Test-TableInAccountRestoreOperationsCmdlets");
        }

        [Fact(Skip = "Resource groups need to be recreated.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestTableRoleCmdlets()
        {
            TestRunner.RunTestScript("Test-TableRoleCmdlets");
        }
    }
}