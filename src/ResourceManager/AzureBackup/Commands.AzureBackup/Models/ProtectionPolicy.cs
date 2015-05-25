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

using Microsoft.WindowsAzure.Management.BackupServices.Models;
using System;
using System.Collections.Generic;
namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    /// <summary>
    /// Represents ProtectionPolicy object
    /// </summary>
    public class AzureBackupProtectionPolicy : AzureBackupVaultContextObject
    {
        /// <summary>
        /// InstanceId of the azurebackup object
        /// </summary>
        public string InstanceId { get; set; }

        /// <summary>
        /// Name of the azurebackup object
        /// </summary>
        public string Name { get; set; }

        public string WorkloadType { get; set; }

        public string BackupType { get; set; }

        public DateTime ScheduleStartTime { get; set; }

        public IList<DateTime> ScheduleRunTimes { get; set; }

        public string RetentionType { get; set; }

        public int RetentionDuration { get; set; }

        public AzureBackupProtectionPolicy()
        {
        }

        public AzureBackupProtectionPolicy(string resourceGroupName, string resourceName, ProtectionPolicyInfo sourcePolicy) : base(resourceGroupName, resourceName)
        {
            InstanceId = sourcePolicy.InstanceId;
            Name = sourcePolicy.Name;
            WorkloadType = sourcePolicy.WorkloadType;
            
            BackupType = sourcePolicy.Schedule.BackupType;
            ScheduleStartTime = sourcePolicy.Schedule.ScheduleStartTime;
            ScheduleRunTimes = sourcePolicy.Schedule.ScheduleRunTimes;

            RetentionType = sourcePolicy.Schedule.RetentionPolicy.RetentionType.ToString();
            RetentionDuration = sourcePolicy.Schedule.RetentionPolicy.RetentionDuration;
        }
    }
}
