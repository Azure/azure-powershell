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

using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CosmosDB.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.CosmosDB.Models
{
    public class PSBackupPolicy
    {
        public static readonly string PeriodicModeBackupType = "Periodic";

        public PSBackupPolicy()
        {
        }

        public PSBackupPolicy(BackupPolicy backupPolicy)
        {
            if (backupPolicy is PeriodicModeBackupPolicy)
            {
                PeriodicModeBackupPolicy periodicModeBackupPolicy = backupPolicy as PeriodicModeBackupPolicy;
                BackupIntervalInMinutes = periodicModeBackupPolicy.PeriodicModeProperties.BackupIntervalInMinutes;
                BackupRetentionIntervalInHours = periodicModeBackupPolicy.PeriodicModeProperties.BackupRetentionIntervalInHours;
                BackupType = PeriodicModeBackupType;
            }
            else
            {
                return;
            }
        }

        public int? BackupIntervalInMinutes { get; set; }

        public int? BackupRetentionIntervalInHours { get; set; }

        public string BackupType { get; set; }

        public BackupPolicy ToSDKModel()
        {
            if (BackupType.Equals(PSBackupPolicy.PeriodicModeBackupType))
            {
                PeriodicModeBackupPolicy periodicModeBackupPolicy = new PeriodicModeBackupPolicy
                {
                    PeriodicModeProperties = new PeriodicModeProperties()
                    {
                        BackupIntervalInMinutes = BackupIntervalInMinutes,
                        BackupRetentionIntervalInHours = BackupRetentionIntervalInHours
                    }
                };

                return periodicModeBackupPolicy;
            }
            else
            {
                return null;
            }
        }
    }
}
