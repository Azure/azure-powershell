// ----------------------------------------------------------------------------------
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// You may not use this file except in compliance with the License.
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
    /// <summary>
    /// Four independent Facts for visibility/run selection. ONLY the New phase provisions the HSM.
    /// The other phases assume the same PowerShell global context (manual sequential run). When
    /// invoked individually via xUnit they will fail fast with a clear message if prerequisites are
    /// absent. This is intentional to avoid accidental reprovisioning of a long-lived Managed HSM.
    /// </summary>
    public class ManagedHsmNetworkRuleLifecycleTests : KeyVaultTestRunner
    {
        public ManagedHsmNetworkRuleLifecycleTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        // [Fact]
        // [Trait(Category.AcceptanceType, Category.CheckIn)]
        // public void TestManagedHsmNetworkRuleLifecycleNew()
        // {
        //     TestRunner.RunTestScript("Test-ManagedHsmNetworkRuleLifecycle-New");
        // }

        // [Fact]
        // [Trait(Category.AcceptanceType, Category.CheckIn)]
        // public void TestManagedHsmNetworkRuleLifecycleAdd()
        // {
        //     TestRunner.RunTestScript("Test-ManagedHsmNetworkRuleLifecycle-Add");
        // }

        // [Fact]
        // [Trait(Category.AcceptanceType, Category.CheckIn)]
        // public void TestManagedHsmNetworkRuleLifecycleRemove()
        // {
        //     TestRunner.RunTestScript("Test-ManagedHsmNetworkRuleLifecycle-Remove");
        // }

        // [Fact]
        // [Trait(Category.AcceptanceType, Category.CheckIn)]
        // public void TestManagedHsmNetworkRuleLifecycleUpdate()
        // {
        //     TestRunner.RunTestScript("Test-ManagedHsmNetworkRuleLifecycle-Update");
        // }

        /// <summary>
        /// Convenience end-to-end test that executes the four phase scripts in a single runspace so that
        /// the PowerShell global state (and our persisted JSON file) naturally flows without relying on
        /// xUnit test ordering. This does NOT modify the individual Facts above and can be opted into
        /// when a full lifecycle validation is desired (e.g. local debugging or CI gated scenario).
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManagedHsmNetworkRuleLifecycleFullSequence()
        {
            TestRunner.RunTestScript(
                "Test-ManagedHsmNetworkRuleLifecycle-New",
                "Test-ManagedHsmNetworkRuleLifecycle-Add",
                "Test-ManagedHsmNetworkRuleLifecycle-Remove",
                "Test-ManagedHsmNetworkRuleLifecycle-Update"
            );
        }
    }
}
