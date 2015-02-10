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

namespace Microsoft.WindowsAzure.Commands.StorSimple.Test.ScenarioTests
{
    public class ResourceTests : StorSimpleTestBase
    {
        #region Get-AzureStorSimpleResource
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourceCheckCount()
        {
            RunPowerShellTest("Test-GetResourcesCheckCount");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResource()
        {
            RunPowerShellTest("Test-GetResources");
        }

        #endregion Get-AzureStorSimpleResource

        #region Select-AzureStorSimpleResource
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetResource_IncorrectName()
        {
            RunPowerShellTest("Test-SetResources-IncorrectResourceName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetResource_DirectInput()
        {
            RunPowerShellTest("Test-SetResources-DirectInput");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetResource_PipedInput()
        {
            RunPowerShellTest("Test-SetResources-PipedInput");
        }
        #endregion Select-AzureStorSimpleResource

        #region Get-AzureStorSimpleResourceContext
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourceContext()
        {
            RunPowerShellTest("Test-GetResourceContext");
        }
        #endregion Get-AzureStorSimpleResourceContext
    }
}
