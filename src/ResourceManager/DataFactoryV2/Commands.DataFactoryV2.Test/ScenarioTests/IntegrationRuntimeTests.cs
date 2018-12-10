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
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.DataFactoryV2.Test
{
    public class IntegrationRuntimeTests : DataFactoriesScenarioTestsBase
    {
        public XunitTracingInterceptor _logger;

        public IntegrationRuntimeTests(ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSelfHostedIntegrationRuntime()
        {
            RunPowerShellTest(_logger, "Test-SelfHosted-IntegrationRuntime");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureIntegrationRuntime()
        {
            RunPowerShellTest(_logger, "Test-Azure-IntegrationRuntime");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestIntegrationRuntimePiping()
        {
            RunPowerShellTest(_logger, "Test-IntegrationRuntime-Piping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSsisAzureIntegrationRuntime()
        {
            RunPowerShellTest(_logger, "Test-SsisAzure-IntegrationRuntime");
        }

        [Fact(Skip = "New-AzureRMRoleAssignmentWithId and Remove-AzureRmRoleAssignment rely on Resources module. Needs fixed in AzureRM.Resources.ps1.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSharedIntegrationRuntime()
        {
            RunPowerShellTest(_logger, "Test-Shared-IntegrationRuntime");
        }
    }
}
