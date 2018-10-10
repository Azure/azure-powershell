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

namespace Microsoft.Azure.Commands.DevTestLabs.Test.ScenarioTests
{
    public class PolicyTests : IClassFixture<DevTestLabsTestFixture>
    {
        private DevTestLabsTestFixture _fixture;

        public PolicyTests(DevTestLabsTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact(Skip = "New ResourceManager version. Needs re-recorded. DevTestLab tests need to be re-enabled, as outlined in issue https://github.com/Azure/azure-powershell/issues/6677")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureRmDtlVMsPerLabPolicy()
        {
            _fixture.RunTest("Test-AzureRmDtlVMsPerLabPolicy");
        }

        [Fact(Skip = "New ResourceManager version. Needs re-recorded. DevTestLab tests need to be re-enabled, as outlined in issue https://github.com/Azure/azure-powershell/issues/6677")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureRmDtlVMsPerUserPolicy()
        {
            _fixture.RunTest("Test-AzureRmDtlVMsPerUserPolicy");
        }

        [Fact(Skip = "New ResourceManager version. Needs re-recorded. DevTestLab tests need to be re-enabled, as outlined in issue https://github.com/Azure/azure-powershell/issues/6677")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureRmDtlAllowedVMSizesPolicy()
        {
            _fixture.RunTest("Test-AzureRmDtlAllowedVMSizesPolicy");
        }

        [Fact(Skip = "New ResourceManager version. Needs re-recorded. DevTestLab tests need to be re-enabled, as outlined in issue https://github.com/Azure/azure-powershell/issues/6677")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureRmDtlAutoShutdownPolicy()
        {
            _fixture.RunTest("Test-AzureRmDtlAutoShutdownPolicy");
        }

        [Fact(Skip = "New ResourceManager version. Needs re-recorded. DevTestLab tests need to be re-enabled, as outlined in issue https://github.com/Azure/azure-powershell/issues/6677")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureRmDtlAutoStartPolicy()
        {
            _fixture.RunTest("Test-AzureRmDtlAutoStartPolicy");
        }
    }
}
