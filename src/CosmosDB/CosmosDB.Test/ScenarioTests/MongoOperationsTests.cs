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
    public class MongoOperationsTests : CosmosDBTestRunner
    {
        public MongoOperationsTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMongoOperationsCmdlets()
        {
            TestRunner.RunTestScript("Test-MongoOperationsCmdlets");
        }

        [Fact(Skip = "The MAC signature found in the HTTP request is not the same as the computed signature.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMongoOperationsCmdletsUsingInputObject()
        {
            TestRunner.RunTestScript("Test-MongoOperationsCmdletsUsingInputObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMongoThroughputCmdlets()
        {
            TestRunner.RunTestScript("Test-MongoThroughputCmdlets");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMongoMigrateThroughputCmdlets()
        {
            TestRunner.RunTestScript("Test-MongoMigrateThroughputCmdlets");
        }

        [Fact(Skip = "Cannot acquire token credential for a specific audience. No support from test framework. I have verified the tests manually.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMongoDBCollectionThroughputRedistributionCmdlet()
        {
            TestRunner.RunTestScript("Test-MongoDBCollectionAdaptiveRUCmdlets");
        }

        [Fact(Skip = "Cannot acquire token credential for a specific audience. No support from test framework. I have verified the tests manually.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMongoDBCollectionMergeCmdlet()
        {
            TestRunner.RunTestScript("Test-MongoDBCollectionMergeCmdlet");
        }
    }
}