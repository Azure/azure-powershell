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
        public void TestFailoverGroup()
        {
            RunPowerShellTest("Test-FailoverGroup");
        }

        [Fact]
        public void TestCreateFailoverGroup_Named()
        {
            RunPowerShellTest("Test-CreateFailoverGroup-Named");
        }

        [Fact]
        public void TestCreateFailoverGroup_Positional()
        {
            RunPowerShellTest("Test-CreateFailoverGroup-Positional");
        }

        [Fact]
        public void TestCreateFailoverGroup_AutomaticPolicy()
        {
            RunPowerShellTest("Test-CreateFailoverGroup-AutomaticPolicy");
        }

        [Fact]
        public void TestCreateFailoverGroup_AutomaticPolicyGracePeriodReadOnlyFailover()
        {
            RunPowerShellTest("Test-CreateFailoverGroup-AutomaticPolicyGracePeriodReadOnlyFailover");
        }

        [Fact]
        public void TestCreateFailoverGroup_ZeroGracePeriod()
        {
            RunPowerShellTest("Test-CreateFailoverGroup-ZeroGracePeriod");
        }

        [Fact]
        public void TestCreateFailoverGroup_ManualPolicy()
        {
            RunPowerShellTest("Test-CreateFailoverGroup-ManualPolicy");
        }

        [Fact]
        public void TestCreateFailoverGroup_Overflow()
        {
            RunPowerShellTest("Test-CreateFailoverGroup-Overflow");
        }

        [Fact]
        public void TestSetFailoverGroup_Named()
        {
            RunPowerShellTest("Test-SetFailoverGroup-Named");
        }

        [Fact]
        public void TestSetFailoverGroup_Positional()
        {
            RunPowerShellTest("Test-SetFailoverGroup-Positional");
        }

        [Fact]
        public void TestSetFailoverGroup_PipeServer()
        {
            RunPowerShellTest("Test-SetFailoverGroup-PipeServer");
        }

        [Fact]
        public void TestSetFailoverGroup_AutomaticWithGracePeriodReadOnlyFailover()
        {
            RunPowerShellTest("Test-SetFailoverGroup-AutomaticWithGracePeriodReadOnlyFailover");
        }

        [Fact]
        public void TestSetFailoverGroup_AutomaticWithGracePeriodZero()
        {
            RunPowerShellTest("Test-SetFailoverGroup-AutomaticWithGracePeriodZero");
        }

        [Fact]
        public void TestSetFailoverGroup_AutomaticToManual()
        {
            RunPowerShellTest("Test-SetFailoverGroup-AutomaticToManual");
        }

        [Fact]
        public void TestSetFailoverGroup_ManualToAutomaticNoGracePeriod()
        {
            RunPowerShellTest("Test-SetFailoverGroup-ManualToAutomaticNoGracePeriod");
        }

        [Fact]
        public void TestSetFailoverGroup_Overflow()
        {
            RunPowerShellTest("Test-SetFailoverGroup-Overflow");
        }

        [Fact]
        public void Test_AddRemoveDatabasesToFromFailoverGroup()
        {
            RunPowerShellTest("Test-AddRemoveDatabasesToFromFailoverGroup");
        }

        [Fact]
        public void TestSwitchFailoverGroup()
        {
            RunPowerShellTest("Test-SwitchFailoverGroup");
        }

        [Fact]
        public void TestSwitchFailoverGroupAllowDataLoss()
        {
            RunPowerShellTest("Test-SwitchFailoverGroupAllowDataLoss");
        }
    }
}
