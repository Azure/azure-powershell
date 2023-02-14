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

using System;
using Microsoft.Azure.Management.CosmosDB.Models;

namespace Microsoft.Azure.Commands.CosmosDB.Models
{
    public class PSBackupPolicyMigrationState
    {
        public PSBackupPolicyMigrationState()
        {
        }

        public PSBackupPolicyMigrationState(BackupPolicyMigrationState backupPolicyMigrationState)
        {
            Status = backupPolicyMigrationState.Status;
            TargetType = backupPolicyMigrationState.TargetType;
            StartTime = backupPolicyMigrationState.StartTime;
        }

        //
        // Summary:
        //     Gets or sets describes the status of migration between backup policy types. Possible
        //     values include: 'Invalid', 'InProgress', 'Completed', 'Failed'
        public string Status { get; set; }
        //
        // Summary:
        //     Gets or sets describes the target backup policy type of the backup policy migration.
        //     Possible values include: 'Periodic', 'Continuous'
        public string TargetType { get; set; }
        //
        // Summary:
        //     Gets or sets time at which the backup policy migration started (ISO-8601 format).
        public DateTime? StartTime { get; set; }

        public BackupPolicyMigrationState ToSDKModel()
        {
            BackupPolicyMigrationState backupPolicyMigrationState = new BackupPolicyMigrationState
            {
                StartTime = StartTime,
                Status = Status,
                TargetType = TargetType
            };

            return backupPolicyMigrationState;
        }
    }
}
