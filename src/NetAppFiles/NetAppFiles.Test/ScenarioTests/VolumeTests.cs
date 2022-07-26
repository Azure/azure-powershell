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

namespace Microsoft.Azure.Commands.NetAppFiles.Test.ScenarioTests.ScenarioTest
{
    public class VolumeTests : NetAppFilesTestRunner
    {
        public VolumeTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVolumeCrud()
        {
            TestRunner.RunTestScript("Test-VolumeCrud");
        }

        //---Note This test will be added to the next (2019-11-01) version ---
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVolumeReplication()
        {
            TestRunner.RunTestScript("Test-VolumeReplication");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetVolumePool()
        {
            TestRunner.RunTestScript("Test-SetVolumePool");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVolumePipelines()
        {
            TestRunner.RunTestScript("Test-VolumePipelines");
        }
    }
}
