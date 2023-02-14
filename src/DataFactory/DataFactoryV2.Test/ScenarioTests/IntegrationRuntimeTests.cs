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

using Microsoft.Azure.Commands.DataFactoryV2.Test.ScenarioTests;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.DataFactoryV2.Test
{
    public class IntegrationRuntimeTests : DataFactoryV2TestRunner
    {
        public IntegrationRuntimeTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSelfHostedIntegrationRuntime()
        {
            TestRunner.RunTestScript("Test-SelfHosted-IntegrationRuntime");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureIntegrationRuntime()
        {
            TestRunner.RunTestScript("Test-Azure-IntegrationRuntime");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestIntegrationRuntimePiping()
        {
            TestRunner.RunTestScript("Test-IntegrationRuntime-Piping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSsisAzureIntegrationRuntime()
        {
            TestRunner.RunTestScript("Test-SsisAzure-IntegrationRuntime");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSsisAzureIntegrationRuntimeWithSubnetId()
        {
            TestRunner.RunTestScript("Test-Azure-IntegrationRuntime-SubnetId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestExpressSsisAzureIntegrationRuntime()
        {
            TestRunner.RunTestScript("Test-Azure-Express-IntegrationRuntime");
        }

        [Fact(Skip = "New-AzureRMRoleAssignmentWithId and Remove-AzureRmRoleAssignment rely on Resources module. Needs fixed in AzureRM.Resources.ps1.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSharedIntegrationRuntime()
        {
            TestRunner.RunTestScript("Test-Shared-IntegrationRuntime");
        }
    }
}
