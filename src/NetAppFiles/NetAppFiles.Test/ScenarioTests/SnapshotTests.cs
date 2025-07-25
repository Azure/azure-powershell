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
    public class SnapshotTests : NetAppFilesTestRunner
    {
        public SnapshotTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSnapshotCrud()
        {
            TestRunner.RunTestScript("Test-SnapshotCrud");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSnapshotPipelines()
        {
            TestRunner.RunTestScript("Test-SnapshotPipelines");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateVolumeFromSnapshot()
        {
            TestRunner.RunTestScript("Test-CreateVolumeFromSnapshot");
        }
               

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRestoreVolumeFromSnapshot()
        {
            TestRunner.RunTestScript("Test-RestoreVolumeFromSnapshot");
        }
    }
}
