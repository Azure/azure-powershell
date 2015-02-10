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
    public class VolumeContainerTests : StorSimpleTestBase
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVolumeContainerSync()
        {
            RunPowerShellTest("Test-VolumeContainerSync");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVolumeContainerAsync()
        {
            RunPowerShellTest("Test-VolumeContainerAsync");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVolumeContainerSync_RepetitiveDCName()
        {
            RunPowerShellTest("Test-VolumeContainerSync_RepetitiveDCName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVolumeContainerSync_InlineSac()
        {
            RunPowerShellTest("Test-VolumeContainerSync_InlineSac");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVolumeContainerSync_InlineSac_InvalidCreds()
        {
            RunPowerShellTest("Test-VolumeContainerSync_InlineSac_InvalidCreds");
        }
    }
}