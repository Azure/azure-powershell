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
    }
}
