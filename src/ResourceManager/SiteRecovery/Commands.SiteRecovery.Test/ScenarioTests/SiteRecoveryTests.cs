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

using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.SiteRecovery.Test.ScenarioTests
{
    public class SiteRecoveryTests : SiteRecoveryTestsBase
    {
        public SiteRecoveryTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnumerationTests()
        {
            this.RunPowerShellTest(Constants.NewModel, "Test-SiteRecoveryEnumerationTests");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreatePolicy()
        {
            this.RunPowerShellTest(Constants.NewModel, "Test-SiteRecoveryCreatePolicy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemovePolicy()
        {
            this.RunPowerShellTest(Constants.NewModel, "Test-SiteRecoveryRemovePolicy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateProtectionContainerMapping()
        {
            this.RunPowerShellTest(Constants.NewModel, "Test-CreateProtectionContainerMapping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveProtectionContainerMapping()
        {
            this.RunPowerShellTest(Constants.NewModel, "Test-RemoveProtectionContainerMapping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEnableDR()
        {
            this.RunPowerShellTest(Constants.NewModel, "Test-SiteRecoveryEnableDR");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDisableDR()
        {
            this.RunPowerShellTest(Constants.NewModel, "Test-SiteRecoveryDisableDR");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateRP()
        {
            this.RunPowerShellTest(Constants.NewModel, "Test-SiteRecoveryCreateRecoveryPlan");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEnumerateRP()
        {
            this.RunPowerShellTest(Constants.NewModel, "Test-SiteRecoveryEnumerateRecoveryPlan");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveRP()
        {
            this.RunPowerShellTest(Constants.NewModel, "Test-SiteRecoveryRemoveRecoveryPlan");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void VaultCRUDTests()
        {
            this.RunPowerShellTest(Constants.NewModel, "Test-SiteRecoveryVaultCRUDTests");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FabricTests()
        {
            this.RunPowerShellTest(Constants.NewModel, "Test-SiteRecoveryFabricTest");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewModelE2ETest()
        {
            this.RunPowerShellTest(Constants.NewModel, "Test-SiteRecoveryNewModelE2ETest");
        }
    }
}
