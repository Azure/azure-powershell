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
    public class ManagedInstanceKeyVaultKeyTests : SqlTestsBase
    {
        public ManagedInstanceKeyVaultKeyTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManagedInstanceKeyVaultKeyCI()
        {
            RunPowerShellTest("Test-ManagedInstanceKeyVaultKeyCI");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManagedInstanceKeyVaultKey()
        {
            RunPowerShellTest("Test-ManagedInstanceKeyVaultKey");
        }

        // Commenting out these tests because automated checks are failing when there 
        //is [fact] tag even when there is no trait tag 

        //public void TestManagedInstanceKeyVaultKeyInputObject()
        //{
        //    RunPowerShellTest("Test-ManagedInstanceKeyVaultKeyInputObject");
        //}

        //public void TestManagedInstanceKeyVaultKeyResourceId()
        //{
        //    RunPowerShellTest("Test-ManagedInstanceKeyVaultKeyResourceId");
        //}
        
        //public void TestManagedInstanceKeyVaultKeyPiping()
        //{
        //    RunPowerShellTest("Test-ManagedInstanceKeyVaultKeyPiping");
        //}
    }
}
