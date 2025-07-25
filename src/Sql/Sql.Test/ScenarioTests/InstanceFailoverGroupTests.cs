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
    public class InstanceFailoverGroupTests : SqlTestRunner
    {
        public InstanceFailoverGroupTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateInstanceFailoverGroup_Named()
        {
            TestRunner.RunTestScript("Test-CreateInstanceFailoverGroup-Named");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateInstanceFailoverGroup_Positional()
        {
            TestRunner.RunTestScript("Test-CreateInstanceFailoverGroup-Positional");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateInstanceFailoverGroup_AutomaticPolicy()
        {
            TestRunner.RunTestScript("Test-CreateInstanceFailoverGroup-AutomaticPolicy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateInstanceFailoverGroup_AutomaticPolicyGracePeriodReadOnlyFailover()
        {
            TestRunner.RunTestScript("Test-CreateInstanceFailoverGroup-AutomaticPolicyGracePeriodReadOnlyFailover");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateInstanceFailoverGroup_ManualPolicy()
        {
            TestRunner.RunTestScript("Test-CreateInstanceFailoverGroup-ManualPolicy");
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetInstanceFailoverGroup_Named()
        {
            TestRunner.RunTestScript("Test-SetInstanceFailoverGroup-Named");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetInstanceFailoverGroup_Positional()
        {
            TestRunner.RunTestScript("Test-SetInstanceFailoverGroup-Positional");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetInstanceFailoverGroup_AutomaticWithGracePeriodReadOnlyFailover()
        {
            TestRunner.RunTestScript("Test-SetInstanceFailoverGroup-AutomaticWithGracePeriodReadOnlyFailover");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetInstanceFailoverGroup_AutomaticToManual()
        {
            TestRunner.RunTestScript("Test-SetInstanceFailoverGroup-AutomaticToManual");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetInstanceFailoverGroup_ManualToAutomaticNoGracePeriod()
        {
            TestRunner.RunTestScript("Test-SetInstanceFailoverGroup-ManualToAutomaticNoGracePeriod");
        }

        [Fact(Skip = "Command Swith should be executed on secondary.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Test_SwitchInstanceFailoverGroup()
        {
            TestRunner.RunTestScript("Test-SwitchInstanceFailoverGroup");
        }

        [Fact(Skip = "Command Swith should be executed on secondary.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Test_SwitchInstanceFailoverGroupAllowDataLoss()
        {
            TestRunner.RunTestScript("Test-SwitchInstanceFailoverGroupAllowDataLoss");
        }
    }
}


