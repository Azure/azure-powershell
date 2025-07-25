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
using RestTestFramework = Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Microsoft.Azure.Commands.Sql.Test.ScenarioTests
{
    public class ManagedInstanceKeyVaultKeyTests : SqlTestRunner
    {
        public ManagedInstanceKeyVaultKeyTests(ITestOutputHelper output) : base(output)
        {

        }

        [Fact(Skip = "Requires manual set up.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManagedInstanceKeyVaultKeyCI()
        {
            TestRunner.RunTestScript("Test-ManagedInstanceKeyVaultKeyCI");
        }

        [Fact(Skip = "Requires manual set up.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManagedInstanceKeyVaultKey()
        {
            TestRunner.RunTestScript("Test-ManagedInstanceKeyVaultKey");
        }

        [Fact(Skip = "Requires manual set up.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManagedInstanceKeyVaultKeyInputObject()
        {
            TestRunner.RunTestScript("Test-ManagedInstanceKeyVaultKeyInputObject");
        }

        [Fact(Skip = "Requires manual set up.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManagedInstanceKeyVaultKeyResourceId()
        {
            TestRunner.RunTestScript("Test-ManagedInstanceKeyVaultKeyResourceId");
        }

        [Fact(Skip = "Requires manual set up.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManagedInstanceKeyVaultKeyPiping()
        {
            TestRunner.RunTestScript("Test-ManagedInstanceKeyVaultKeyPiping");
        }
    }
}
