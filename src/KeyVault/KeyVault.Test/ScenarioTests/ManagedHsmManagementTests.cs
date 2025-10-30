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

namespace Microsoft.Azure.Commands.KeyVault.Test.ScenarioTests
{
    public class ManagedHsmManagementTests: KeyVaultTestRunner
    {
        public ManagedHsmManagementTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManagedHsmCRUD()
        {
            TestRunner.RunTestScript("Test-ManagedHsmCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManagedHsmSoftDelete()
        {
            TestRunner.RunTestScript("Test-ManagedHsmSoftDelete");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManagedHsmPurgeProtection()
        {
            TestRunner.RunTestScript("Test-ManagedHsmPurgeProtection");
        }

        [Fact(Skip = "Updating managedHsm with top level properties currently fails")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateManagedHsmWithDefaultPublicNetworkAccess()
        {
            TestRunner.RunTestScript("Test-CreateManagedHsmDefaultPublicNetworkAccess");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateManagedHsmWithDisabledPublicNetworkAccess()
        {
            TestRunner.RunTestScript("Test-CreateManagedHsmWithDisabledPublicNetworkAccess");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateManagedHsmWithEnabledPublicNetworkAccess()
        {
            TestRunner.RunTestScript("Test-CreateManagedHsmWithEnabledPublicNetworkAccess");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewManagedHsmWithManagedServiceIdentity()
        {
            TestRunner.RunTestScript("Test-NewManagedHsmWithManagedServiceIdentity");
        }

        [Fact(Skip = "Updating managedHsm with top level properties currently fails")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateManagedHsmWithManagedServiceIdentity()
        {
            TestRunner.RunTestScript("Test-UpdateManagedHsmWithManagedServiceIdentity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUndoManagedHsmRemoval()
        {
            TestRunner.RunTestScript("Test-UndoManagedHsmRemoval");
        }
    }
}
