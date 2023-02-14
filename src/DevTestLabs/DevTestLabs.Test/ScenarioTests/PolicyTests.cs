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
    public class PolicyTests : DevTestLabsTestRunner
    {

        public PolicyTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
            
        }

        [Fact(Skip = "New ResourceManager version. Needs re-recorded. DevTestLab tests need to be re-enabled, as outlined in issue https://github.com/Azure/azure-powershell/issues/6677")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureRmDtlVMsPerLabPolicy()
        {
            TestRunner.RunTestScript("Test-AzureRmDtlVMsPerLabPolicy");
        }

        [Fact(Skip = "New ResourceManager version. Needs re-recorded. DevTestLab tests need to be re-enabled, as outlined in issue https://github.com/Azure/azure-powershell/issues/6677")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureRmDtlVMsPerUserPolicy()
        {
            TestRunner.RunTestScript("Test-AzureRmDtlVMsPerUserPolicy");
        }

        [Fact(Skip = "New ResourceManager version. Needs re-recorded. DevTestLab tests need to be re-enabled, as outlined in issue https://github.com/Azure/azure-powershell/issues/6677")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureRmDtlAllowedVMSizesPolicy()
        {
            TestRunner.RunTestScript("Test-AzureRmDtlAllowedVMSizesPolicy");
        }

        [Fact(Skip = "New ResourceManager version. Needs re-recorded. DevTestLab tests need to be re-enabled, as outlined in issue https://github.com/Azure/azure-powershell/issues/6677")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureRmDtlAutoShutdownPolicy()
        {
            TestRunner.RunTestScript("Test-AzureRmDtlAutoShutdownPolicy");
        }

        [Fact(Skip = "New ResourceManager version. Needs re-recorded. DevTestLab tests need to be re-enabled, as outlined in issue https://github.com/Azure/azure-powershell/issues/6677")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureRmDtlAutoStartPolicy()
        {
            TestRunner.RunTestScript("Test-AzureRmDtlAutoStartPolicy");
        }
    }
}
