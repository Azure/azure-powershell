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

namespace Microsoft.Azure.Commands.GuestConfiguration.Test.ScenarioTests
{
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Xunit;

    public class GetVmGuestPolicyStatusHistoryTests : GuestConfigurationTestRunner
    {
        public GetVmGuestPolicyStatusHistoryTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void VmNameScope()
        {
            TestRunner.RunTestScript("Get-AzVMGuestPolicyStatusHistory-VmNameScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void InitiativeIdScope()
        {
            TestRunner.RunTestScript("Get-AzVMGuestPolicyStatusHistory-InitiativeIdScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void InitiativeNameScope()
        {
            TestRunner.RunTestScript("Get-AzVMGuestPolicyStatusHistory-InitiativeNameScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ShowOnlyChangeSwitchVmNameScope()
        {
            TestRunner.RunTestScript("Get-AzVMGuestPolicyStatusHistory-ShowOnlyChangeSwitch-VmNameScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void VmNameScope_Custom()
        {
            TestRunner.RunTestScript("Get-AzVMGuestPolicyStatusHistory-VmNameScope_Custom");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void InitiativeIdScope_Custom()
        {
            TestRunner.RunTestScript("Get-AzVMGuestPolicyStatusHistory-InitiativeIdScope_Custom");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void InitiativeNameScope_Custom()
        {
            TestRunner.RunTestScript("Get-AzVMGuestPolicyStatusHistory-InitiativeNameScope_Custom");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ShowOnlyChangeSwitchVmNameScope_Custom()
        {
            TestRunner.RunTestScript("Get-AzVMGuestPolicyStatusHistory-ShowOnlyChangeSwitch-VmNameScope_Custom");
        }
    }
}