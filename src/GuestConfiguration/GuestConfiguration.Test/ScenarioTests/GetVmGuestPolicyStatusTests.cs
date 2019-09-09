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

using Microsoft.Azure.ServiceManagement.Common.Models;

namespace Microsoft.Azure.Commands.GuestConfiguration.Test.ScenarioTests
{
    using Microsoft.Azure.Commands.ScenarioTest;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Xunit;


    public class GetVmGuestPolicyStatusTests
    {
        private readonly XunitTracingInterceptor _logger;

        public GetVmGuestPolicyStatusTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void VmNameScope()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzVMGuestPolicyStatus-VmNameScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void VmNameScope_Custom()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzVMGuestPolicyStatus-VmNameScope_Custom");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void InitiativeIdScope()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzVMGuestPolicyStatus-InitiativeIdScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void InitiativeIdScope_Custom()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzVMGuestPolicyStatus-InitiativeIdScope_Custom");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void InitiativeNameScope()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzVMGuestPolicyStatus-InitiativeNameScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void InitiativeNameScope_Custom()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzVMGuestPolicyStatus-InitiativeNameScope_Custom");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]       
        public void ReportIdScope()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzVMGuestPolicyStatus-ReportIdScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ReportIdScope_Custom()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzVMGuestPolicyStatus-ReportIdScope_Custom");
        }
    }
}