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

using Microsoft.Azure.Commands.Sql.ManagedDatabaseBackup.Services;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Sql.Test.UnitTests
{
    public class AzureSqlManagedDatabaseBackupAdapterTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBackupModelMapsBackupStorageRedundancy()
        {
            const string resourceId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.Sql/locations/westcentralus/longTermRetentionManagedInstances/test-mi/longTermRetentionDatabases/test-db/longTermRetentionManagedInstanceBackups/test-backup";
            var backup = new ManagedInstanceLongTermRetentionBackup(
                id: resourceId,
                name: "test-backup",
                managedInstanceName: "test-mi",
                databaseName: "test-db",
                backupStorageRedundancy: "Geo");

            var result = AzureSqlManagedDatabaseBackupAdapter.GetBackupModel(backup, "westcentralus");

            Assert.Equal("Geo", result.BackupStorageRedundancy);
            Assert.Equal("test-rg", result.ResourceGroupName);
        }
    }
}
