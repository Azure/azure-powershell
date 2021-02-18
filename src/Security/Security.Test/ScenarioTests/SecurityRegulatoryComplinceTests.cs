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
    public class SecurityRegulatoryComplinceTests
    {
        private readonly XunitTracingInterceptor _logger;

        public SecurityRegulatoryComplinceTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetStandardSubscriptionScope()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmRegulatoryComplianceStandard-SubscriptionScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetStandardSubscriptionLevelResource()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmRegulatoryComplianceStandard-SubscriptionLevelResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetStandardResourceId()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmRegulatoryComplianceStandard-ResourceId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetControlSubscriptionScope()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmRegulatoryComplianceControl-SubscriptionScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetControlSubscriptionLevelResource()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmRegulatoryComplianceControl-SubscriptionLevelResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetControlResourceId()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmRegulatoryComplianceControl-ResourceId");
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAssessmentSubscriptionScope()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmRegulatoryComplianceAssessment-SubscriptionScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAssessmentSubscriptionLevelResource()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmRegulatoryComplianceAssessment-SubscriptionLevelResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAssessmentResourceId()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmRegulatoryComplianceAssessment-ResourceId");
        }

    }
}
