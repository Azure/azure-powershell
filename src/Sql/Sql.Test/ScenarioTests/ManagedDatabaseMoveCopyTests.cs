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
    public class ManagedDatabaseMoveCopyTests : SqlTestRunner
    {
        public ManagedDatabaseMoveCopyTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManagedDatabaseMove()
        {
            TestRunner.RunTestScript("Test-ManagedDatabaseMove");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestCrossSubscriptionManagedDatabaseMove()
        {
            TestRunner.RunTestScript("Test-CrossSubscriptionManagedDatabaseMove");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManagedDatabaseMoveByPiping()
        {
            TestRunner.RunTestScript("Test-ManagedDatabaseMovePiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManagedDatabaseCopy()
        {
            TestRunner.RunTestScript("Test-ManagedDatabaseCopy");
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestCrossSubscriptionManagedDatabaseCopy()
        {
            TestRunner.RunTestScript("Test-CrossSubscriptionManagedDatabaseCopy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManagedDatabaseCopyByPiping()
        {
            TestRunner.RunTestScript("Test-ManagedDatabaseCopyPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManagedDatabaseCopyUsingOperationObject()
        {
            TestRunner.RunTestScript("Test-ManagedDatabaseCopyUsingOperationObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManagedDatabaseMoveUsingOperationObject()
        {
            TestRunner.RunTestScript("Test-ManagedDatabaseMoveUsingOperationObject");
        }
    }
}
