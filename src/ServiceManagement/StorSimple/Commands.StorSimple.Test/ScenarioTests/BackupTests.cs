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

using Commands.StorSimple.Test;
using Xunit;

namespace Microsoft.Azure.Commands.StorSimple.Test.ScenarioTests
{
    public class BackupTests : StorSimpleTestBase
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateGetDeleteBackupPolicy()
        {
            RunPowerShellTest("Test-CreateGetDeleteBackupPolicy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRenameBackupPolicy()
        {
            RunPowerShellTest("Test-RenameBackupPolicy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddVolumeToBackupPolicy()
        {
            RunPowerShellTest("Test-AddVolumeToBackupPolicy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddUpdateDeleteScheduleInBackupPolicy()
        {
            RunPowerShellTest("Test-AddUpdateDeleteScheduleInBackupPolicy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateGetRestoreDeleteBackup()
        {
            RunPowerShellTest("Test-CreateGetRestoreDeleteBackup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetBackupByBackupPolicyId()
        {
            RunPowerShellTest("Test-GetBackupByBackupPolicyId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetBackupByBackupPolicyObject()
        {
            RunPowerShellTest("Test-GetBackupByBackupPolicyObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetBackupByVolumeId()
        {
            RunPowerShellTest("Test-GetBackupByVolumeId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetBackupByVolumeObject()
        {
            RunPowerShellTest("Test-GetBackupByVolumeObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetBackupByTimePeriod()
        {
            RunPowerShellTest("Test-GetBackupByTimePeriod");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetPaginatedBackup()
        {
            RunPowerShellTest("Test-GetPaginatedBackup");
        }
    }
}