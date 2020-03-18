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

namespace Microsoft.Azure.Commands.PolicyInsights.Test.ScenarioTests
{
    /// <summary>
    /// Remediation scenario tests.
    /// </summary>
    /// <remarks>
    /// Recorded with the following details:
    /// TEST_CSM_ORGID_AUTHENTICATION=SubscriptionId=f67cc918-f64f-4c3f-aa24-a855465f9d41;ServicePrincipal=20f84e2b-2ca6-4035-a118-6105027fce93;ServicePrincipalSecret=****;AADTenant=72f988bf-86f1-41af-91ab-2d7cd011db47;Environment=Prod;
    /// See ../EnvSetup/RemediationSetup.ps1 for a helper script to get the appropriate policies and resources created in your subscription
    /// </remarks>
    public class RemediationTests
    {
        private readonly XunitTracingInterceptor _logger;

        public RemediationTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SubscriptionScopeCrud()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Remediation-SubscriptionScope-Crud");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResourceGroupScopeCrud()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Remediation-ResourceGroupScope-Crud");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResourceScopeCrud()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Remediation-ResourceScope-Crud");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ManagementGroupScopeCrud()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Remediation-ManagementGroupScope-Crud");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void BackgroundJobs()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Remediation-BackgroundJobs");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ReEvaluateCompliance()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Remediation-ReEvaluateCompliance");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ErrorHandling()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Remediation-ErrorHandling");
        }
    }
}
