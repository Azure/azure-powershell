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

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Security.Test.ScenarioTests
{
    public class SecurityRegulatoryComplinceTests : SecurityTestRunner
    {
        public SecurityRegulatoryComplinceTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetStandardSubscriptionScope()
        {
            TestRunner.RunTestScript("Get-AzureRmRegulatoryComplianceStandard-SubscriptionScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetStandardSubscriptionLevelResource()
        {
            TestRunner.RunTestScript("Get-AzureRmRegulatoryComplianceStandard-SubscriptionLevelResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetStandardResourceId()
        {
            TestRunner.RunTestScript("Get-AzureRmRegulatoryComplianceStandard-ResourceId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetControlSubscriptionScope()
        {
            TestRunner.RunTestScript("Get-AzureRmRegulatoryComplianceControl-SubscriptionScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetControlSubscriptionLevelResource()
        {
            TestRunner.RunTestScript("Get-AzureRmRegulatoryComplianceControl-SubscriptionLevelResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetControlResourceId()
        {
            TestRunner.RunTestScript("Get-AzureRmRegulatoryComplianceControl-ResourceId");
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAssessmentSubscriptionScope()
        {
            TestRunner.RunTestScript("Get-AzureRmRegulatoryComplianceAssessment-SubscriptionScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAssessmentSubscriptionLevelResource()
        {
            TestRunner.RunTestScript("Get-AzureRmRegulatoryComplianceAssessment-SubscriptionLevelResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAssessmentResourceId()
        {
            TestRunner.RunTestScript("Get-AzureRmRegulatoryComplianceAssessment-ResourceId");
        }
    }
}
