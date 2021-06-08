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
    public class InstanceFailoverGroupTests : SqlTestsBase
    {
        public InstanceFailoverGroupTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact(Skip = "Has manual setup, unable to re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateInstanceFailoverGroup_Named()
        {
            RunPowerShellTest("Test-CreateInstanceFailoverGroup-Named");
        }

        [Fact(Skip = "Has manual setup, unable to re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateInstanceFailoverGroup_Positional()
        {
            RunPowerShellTest("Test-CreateInstanceFailoverGroup-Positional");
        }

        [Fact(Skip = "Has manual setup, unable to re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateInstanceFailoverGroup_AutomaticPolicy()
        {
            RunPowerShellTest("Test-CreateInstanceFailoverGroup-AutomaticPolicy");
        }

        [Fact(Skip = "Has manual setup, unable to re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateInstanceFailoverGroup_AutomaticPolicyGracePeriodReadOnlyFailover()
        {
            RunPowerShellTest("Test-CreateInstanceFailoverGroup-AutomaticPolicyGracePeriodReadOnlyFailover");
        }

        [Fact(Skip = "Has manual setup, unable to re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateInstanceFailoverGroup_ManualPolicy()
        {
            RunPowerShellTest("Test-CreateInstanceFailoverGroup-ManualPolicy");
        }
        
        [Fact(Skip = "Has manual setup, unable to re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetInstanceFailoverGroup_Named()
        {
            RunPowerShellTest("Test-SetInstanceFailoverGroup-Named");
        }

        [Fact(Skip = "Has manual setup, unable to re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetInstanceFailoverGroup_Positional()
        {
            RunPowerShellTest("Test-SetInstanceFailoverGroup-Positional");
        }

        [Fact(Skip = "Has manual setup, unable to re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetInstanceFailoverGroup_AutomaticWithGracePeriodReadOnlyFailover()
        {
            RunPowerShellTest("Test-SetInstanceFailoverGroup-AutomaticWithGracePeriodReadOnlyFailover");
        }

        [Fact(Skip = "Has manual setup, unable to re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetInstanceFailoverGroup_AutomaticToManual()
        {
            RunPowerShellTest("Test-SetInstanceFailoverGroup-AutomaticToManual");
        }

        [Fact(Skip = "Has manual setup, unable to re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetInstanceFailoverGroup_ManualToAutomaticNoGracePeriod()
        {
            RunPowerShellTest("Test-SetInstanceFailoverGroup-ManualToAutomaticNoGracePeriod");
        }

        [Fact(Skip = "Has manual setup, unable to re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Test_SwitchInstanceFailoverGroup()
        {
            RunPowerShellTest("Test-SwitchInstanceFailoverGroup");
        }

        [Fact(Skip = "Has manual setup, unable to re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Test_SwitchInstanceFailoverGroupAllowDataLoss()
        {
            RunPowerShellTest("Test-SwitchInstanceFailoverGroupAllowDataLoss");
        }
    }
}


