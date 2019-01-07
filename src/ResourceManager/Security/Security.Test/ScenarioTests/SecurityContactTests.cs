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

using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Security.Test.ScenarioTests
{
    public class SecurityContactTests
    {
        private readonly XunitTracingInterceptor _logger;

        public SecurityContactTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetSubscriptionScope()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmSecurityContact-SubscriptionScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetSubscriptionLevelResource()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmSecurityContact-SubscriptionLevelResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetResourceId()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmSecurityContact-ResourceId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetSubscriptionLevelResource()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Set-AzureRmSecurityContact-SubscriptionLevelResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetSubscriptionLevelResourceSecondary()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Set-AzureRmSecurityContact-SubscriptionLevelResource-Secondary");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveSubscriptionLevelResource()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Remove-AzureRmSecurityContact-SubscriptionLevelResource");
        }
    }
}
