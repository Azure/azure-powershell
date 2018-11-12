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

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models
{
    /// <summary>
    /// Azure Db Workload specific backup policy class.
    /// </summary>
    public class AzureDbPolicy : PolicyBase
    {
        /// <summary>
        /// Is compression enabled
        /// </summary>
        public bool? IsCompression { get; set; }

        /// <summary>
        /// Object defining is differential backup is enabled.
        /// </summary>
        public bool IsDifferentialBackupEnabled { get; set; }

        /// <summary>
        /// Object defining if log backup is enabled.
        /// </summary>
        public bool IsLogBackupEnabled { get; set; }

        /// <summary>
        /// Object defining the schedule associated with full backup policy.
        /// </summary>
        public SchedulePolicyBase FullBackupSchedulePolicy { get; set; }

        /// <summary>
        /// Object defining the schedule associated with differential backup policy.
        /// </summary>
        public SchedulePolicyBase DifferentialBackupSchedulePolicy { get; set; }

        /// <summary>
        /// Object defining the schedule associated with Log backup policy.
        /// </summary>
        public SchedulePolicyBase LogBackupSchedulePolicy { get; set; }

        /// <summary>
        /// Object defining the retention behavior of full backup policy.
        /// </summary>
        public RetentionPolicyBase FullBackupRetentionPolicy { get; set; }

        /// <summary>
        /// Object defining the retention behavior of differential backup policy.
        /// </summary>
        public RetentionPolicyBase DifferentialBackupRetentionPolicy { get; set; }

        /// <summary>
        /// Object defining the retention behavior of log backup policy.
        /// </summary>
        public RetentionPolicyBase LogBackupRetentionPolicy { get; set; }

        public override void Validate()
        {
            base.Validate();

            FullBackupSchedulePolicy.Validate();
            if (DifferentialBackupSchedulePolicy != null)
            {
                DifferentialBackupSchedulePolicy.Validate();
            }
            if (LogBackupSchedulePolicy != null)
            {
                LogBackupSchedulePolicy.Validate();
            }

            FullBackupRetentionPolicy.Validate();
            if (DifferentialBackupRetentionPolicy != null)
            {
                DifferentialBackupRetentionPolicy.Validate();
            }
            if (LogBackupRetentionPolicy != null)
            {
                LogBackupRetentionPolicy.Validate();
            }
        }
    }

}
