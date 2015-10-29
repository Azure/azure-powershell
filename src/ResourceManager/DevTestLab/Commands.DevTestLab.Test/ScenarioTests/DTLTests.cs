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

namespace Microsoft.Azure.Commands.DevTestLab.Test.ScenarioTests
{
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Microsoft.Azure.Test;
    using Xunit;

    // 1: ListAll: Lists all labs within current subscription, if no parameters are specified.
    // 2: ListAllWithinResourceGroup: Lists all labs within a resource group, if the -ResourceGroupName parameter is specified.
    // 3: GetSpecificWithinResourceGroup: Gets a specific lab within a resource group, if both the -LabName and -ResourceGroupName are specified. 

    public class DTLTests : DTLTestsBase
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Test_GetAzureDtlLab_ListAll()
        {
            RunPowerShellTest("Test-GetAzureDtlLab-ListAll");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Test_GetAzureDtlLab_ListAllWithinResourceGroup()
        {
            RunPowerShellTest("Test-GetAzureDtlLab-ListAllWithinResourceGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Test_GetAzureDtlLab_GetSpecificWithinResourceGroup()
        {
            RunPowerShellTest("Test-GetAzureDtlLab-GetSpecificWithinResourceGroup");
        }
    }
}
