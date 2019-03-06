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

using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using System.Collections.Generic;
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using CmdletModel = Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers
{
    /// <summary>
    /// Backup policy conversion helper
    /// </summary>
    public partial class PolicyHelpers
    {
        public static List<ServiceClientModel.SubProtectionPolicy> GetServiceClientSubProtectionPolicy(
            SQLRetentionPolicy retentionPolicy,
            SQLSchedulePolicy schedulePolicy)
        {
            List<ServiceClientModel.SubProtectionPolicy> subProtectionPolicy =
                new List<ServiceClientModel.SubProtectionPolicy>();
            if (schedulePolicy.FullBackupSchedulePolicy != null &&
                retentionPolicy.FullBackupRetentionPolicy != null)
            {
                subProtectionPolicy.Add(new ServiceClientModel.SubProtectionPolicy("Full",
                    GetServiceClientSimpleSchedulePolicy(schedulePolicy.FullBackupSchedulePolicy),
                    GetServiceClientLongTermRetentionPolicy(retentionPolicy.FullBackupRetentionPolicy)));
            }
            if (schedulePolicy.DifferentialBackupSchedulePolicy != null &&
                retentionPolicy.DifferentialBackupRetentionPolicy != null &&
                schedulePolicy.IsDifferentialBackupEnabled)
            {
                subProtectionPolicy.Add(new ServiceClientModel.SubProtectionPolicy("Differential",
                    GetServiceClientSimpleSchedulePolicy(schedulePolicy.DifferentialBackupSchedulePolicy),
                    GetServiceClientSimpleRetentionPolicy(retentionPolicy.DifferentialBackupRetentionPolicy)));
            }
            if (schedulePolicy.LogBackupSchedulePolicy != null &&
                retentionPolicy.LogBackupRetentionPolicy != null &&
                schedulePolicy.IsLogBackupEnabled)
            {
                subProtectionPolicy.Add(new ServiceClientModel.SubProtectionPolicy("Log",
                    GetServiceClientLogSchedulePolicy(schedulePolicy.LogBackupSchedulePolicy),
                    GetServiceClientSimpleRetentionPolicy(retentionPolicy.LogBackupRetentionPolicy)));
            }
            return subProtectionPolicy;
        }

        public static List<ServiceClientModel.SubProtectionPolicy> GetServiceClientSubProtectionPolicy(
            AzureVmWorkloadPolicy policy)
        {
            List<ServiceClientModel.SubProtectionPolicy> subProtectionPolicy =
                new List<ServiceClientModel.SubProtectionPolicy>();
            if (policy.FullBackupSchedulePolicy != null &&
                policy.FullBackupRetentionPolicy != null)
            {
                subProtectionPolicy.Add(new ServiceClientModel.SubProtectionPolicy("Full",
                    GetServiceClientSimpleSchedulePolicy((SimpleSchedulePolicy)policy.FullBackupSchedulePolicy),
                    GetServiceClientLongTermRetentionPolicy((LongTermRetentionPolicy)policy.FullBackupRetentionPolicy)));
            }
            if (policy.DifferentialBackupSchedulePolicy != null &&
                policy.DifferentialBackupRetentionPolicy != null &&
                policy.IsDifferentialBackupEnabled)
            {
                subProtectionPolicy.Add(new ServiceClientModel.SubProtectionPolicy("Differential",
                    GetServiceClientSimpleSchedulePolicy((SimpleSchedulePolicy)policy.DifferentialBackupSchedulePolicy),
                    GetServiceClientSimpleRetentionPolicy((SimpleRetentionPolicy)policy.DifferentialBackupRetentionPolicy)));
            }
            if (policy.LogBackupSchedulePolicy != null &&
                policy.LogBackupRetentionPolicy != null &&
                policy.IsLogBackupEnabled)
            {
                subProtectionPolicy.Add(new ServiceClientModel.SubProtectionPolicy("Log",
                    GetServiceClientLogSchedulePolicy((LogSchedulePolicy)policy.LogBackupSchedulePolicy),
                    GetServiceClientSimpleRetentionPolicy((SimpleRetentionPolicy)policy.LogBackupRetentionPolicy)));
            }
            return subProtectionPolicy;
        }
    }
}