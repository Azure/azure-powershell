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
    /// <summary>
    /// These tests depends on the existing resources. Please contact MDCSSQLCustomerExp@microsoft.com for instructions.
    /// </summary>
    public class ManagedDatabaseCrudScenarioTests : SqlTestRunner
    {
        public ManagedDatabaseCrudScenarioTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateManagedDatabase()
        {
            TestRunner.RunTestScript("Test-CreateManagedDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetManagedDatabase()
        {
            TestRunner.RunTestScript("Test-GetManagedDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveManagedDatabase()
        {
            TestRunner.RunTestScript("Test-RemoveManagedDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRestoreManagedDatabase()
        {
            TestRunner.RunTestScript("Test-RestoreManagedDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRestoreDeletedManagedDatabase()
        {
            TestRunner.RunTestScript("Test-RestoreDeletedManagedDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetManagedDatabaseGeoBackup()
        {
            TestRunner.RunTestScript("Test-GetManagedDatabaseGeoBackup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGeoRestoreManagedDatabase()
        {
            TestRunner.RunTestScript("Test-GeoRestoreManagedDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetManagedDatabase()
        {
            TestRunner.RunTestScript("Test-SetManagedDatabase");
        }
    }
}
