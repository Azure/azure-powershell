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

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureRmDtlVMsPerLabPolicy()
        {
            _fixture.RunTest("Test-AzureRmDtlVMsPerLabPolicy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureRmDtlVMsPerUserPolicy()
        {
            _fixture.RunTest("Test-AzureRmDtlVMsPerUserPolicy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureRmDtlAllowedVMSizesPolicy()
        {
            _fixture.RunTest("Test-AzureRmDtlAllowedVMSizesPolicy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureRmDtlAutoShutdownPolicy()
        {
            _fixture.RunTest("Test-AzureRmDtlAutoShutdownPolicy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureRmDtlAutoStartPolicy()
        {
            _fixture.RunTest("Test-AzureRmDtlAutoStartPolicy");
        }
    }
}
