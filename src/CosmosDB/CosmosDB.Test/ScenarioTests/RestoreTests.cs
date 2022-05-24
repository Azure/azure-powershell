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
    public class RestoreTests : CosmosDBTestRunner
    {
        public RestoreTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact(Skip = "Unrecognized time format for linux/mac.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRestoreAccountCmdlets()
        {
            TestRunner.RunTestScript("Test-RestoreAccountCmdlets");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRestoreFromNewAccountCmdlets()
        {
            TestRunner.RunTestScript("Test-RestoreFromNewAccountCmdlets");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMongoRestoreAccountCmdlets()
        {
            TestRunner.RunTestScript("Test-MongoRestoreAccountCmdlets");
        }

        [Fact(Skip = "Unrecognized time format for linux/mac.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRestoreFailuresAccountCmdlets()
        {
            TestRunner.RunTestScript("Test-RestoreFailuresAccountCmdlets");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSqlContainerBackupInformationCmdLets()
        {
            TestRunner.RunTestScript("Test-SqlContainerBackupInformationCmdLets");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMongoDBCollectionBackupInformationCmdLets()
        {
            TestRunner.RunTestScript("Test-MongoDBCollectionBackupInformationCmdLets");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateCosmosDBAccountBackupPolicyCmdLet()
        {
            TestRunner.RunTestScript("Test-UpdateCosmosDBAccountBackupPolicyCmdLet");
        }
    }
}
