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
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Sql.Test.ScenarioTests
{
    public class FailoverGroupTests : SqlTestsBase
    {
        public FailoverGroupTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFailoverGroup()
        {
            RunPowerShellTest("Test-FailoverGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateFailoverGroup_Named()
        {
            RunPowerShellTest("Test-CreateFailoverGroup-Named");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateFailoverGroup_Positional()
        {
            RunPowerShellTest("Test-CreateFailoverGroup-Positional");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateFailoverGroup_AutomaticPolicy()
        {
            RunPowerShellTest("Test-CreateFailoverGroup-AutomaticPolicy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateFailoverGroup_AutomaticPolicyGracePeriodReadOnlyFailover()
        {
            RunPowerShellTest("Test-CreateFailoverGroup-AutomaticPolicyGracePeriodReadOnlyFailover");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateFailoverGroup_ZeroGracePeriod()
        {
            RunPowerShellTest("Test-CreateFailoverGroup-ZeroGracePeriod");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateFailoverGroup_ManualPolicy()
        {
            RunPowerShellTest("Test-CreateFailoverGroup-ManualPolicy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateFailoverGroup_Overflow()
        {
            RunPowerShellTest("Test-CreateFailoverGroup-Overflow");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetFailoverGroup_Named()
        {
            RunPowerShellTest("Test-SetFailoverGroup-Named");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetFailoverGroup_Positional()
        {
            RunPowerShellTest("Test-SetFailoverGroup-Positional");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetFailoverGroup_PipeServer()
        {
            RunPowerShellTest("Test-SetFailoverGroup-PipeServer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetFailoverGroup_AutomaticWithGracePeriodReadOnlyFailover()
        {
            RunPowerShellTest("Test-SetFailoverGroup-AutomaticWithGracePeriodReadOnlyFailover");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetFailoverGroup_AutomaticWithGracePeriodZero()
        {
            RunPowerShellTest("Test-SetFailoverGroup-AutomaticWithGracePeriodZero");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetFailoverGroup_AutomaticToManual()
        {
            RunPowerShellTest("Test-SetFailoverGroup-AutomaticToManual");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetFailoverGroup_ManualToAutomaticNoGracePeriod()
        {
            RunPowerShellTest("Test-SetFailoverGroup-ManualToAutomaticNoGracePeriod");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetFailoverGroup_Overflow()
        {
            RunPowerShellTest("Test-SetFailoverGroup-Overflow");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Test_AddRemoveDatabasesToFromFailoverGroup()
        {
            RunPowerShellTest("Test-AddRemoveDatabasesToFromFailoverGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSwitchFailoverGroup()
        {
            RunPowerShellTest("Test-SwitchFailoverGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSwitchFailoverGroupAllowDataLoss()
        {
            RunPowerShellTest("Test-SwitchFailoverGroupAllowDataLoss");
        }
    }
}
