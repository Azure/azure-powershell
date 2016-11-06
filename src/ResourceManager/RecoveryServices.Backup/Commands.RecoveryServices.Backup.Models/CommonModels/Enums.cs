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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models
{
    /// <summary>
    /// Type of the container that maybe managed by the recovery services vault.
    /// </summary>
    public enum ContainerType
    {
        /// <summary>
        /// Represents the Azure Virtual Machine (both Classic and Compute versions).
        /// </summary>
        AzureVM = 1,

        /// <summary>
        /// Represents any windows containers such as those managed by the MAB device etc.
        /// </summary>
        Windows,

        /// <summary>
        /// Represents any Azure Sql containers.
        /// </summary>
        AzureSQL
    }

    /// <summary>
    /// Type of the backup management agent.
    /// </summary>
    public enum BackupManagementType
    {
        /// <summary>
        /// Represents the Azure Virtual Machine agent (both Classic and Compute versions).
        /// </summary>
        AzureVM = 1,

        /// <summary>
        /// Represents the Microsoft Azure Recovery Services agent.
        /// </summary>
        MARS,

        /// <summary>
        /// Represents the Service Center Data Protection Manager agent.
        /// </summary>
        SCDPM,

        /// <summary>
        /// Represents the Azure Backup Server agent.
        /// </summary>
        AzureBackupServer,
        AzureSQL,
    }

    /// <summary>
    /// Type of the backup engine.
    /// </summary>
    public enum BackupEngineType
    {
        /// <summary>
        /// Represents the Data Protection Manager backup engine.
        /// </summary>
        DpmBackupEngine = 1,

        /// <summary>
        /// Represents the Azure Backup Server backup engine.
        /// </summary>
        AzureBackupServerEngine
    }

    /// <summary>
    /// Type of the workload running in an item.
    /// </summary>
    public enum WorkloadType
    {
        /// <summary>
        /// Represents the Azure Virtual Machine (both Classic and Compute versions).
        /// </summary>
        AzureVM = 1,
        AzureSQLDatabase,
    }

    /// <summary>
    /// Types of the PowerShell providers for the cmdlet implementation.
    /// </summary>
    public enum PsBackupProviderTypes
    {
        /// <summary>
        /// Represents the IaaS VM provider for powershell cmdlets.
        /// </summary>
        IaasVm = 1,

        /// <summary>
        /// Represents the Azure SQL provider for powershell cmdlets.
        /// </summary>
        AzureSql,

        /// <summary>
        /// Represents the Microsoft Azure Backup provider for powershell cmdlets.
        /// </summary>
        Mab,

        /// <summary>
        /// Represents the Data Protection Manager provider for powershell cmdlets.
        /// </summary>
        Dpm
    }

    /// <summary>
    /// Status of the registration of the container with the recovery services vault.
    /// </summary>
    public enum ContainerRegistrationStatus
    {
        /// <summary>
        /// Represents the registered state of the container with the recovery services vault.
        /// </summary>
        Registered = 1,
    }

    /// <summary>
    /// Status of the registration of the backup engine with the recovery services vault.
    /// </summary>
    public enum BackupEngineRegistrationStatus
    {
        /// <summary>
        /// Represents the registered state of the backup engine with the recovery services vault.
        /// </summary>
        Registered = 1,

        /// <summary>
        /// Represents the state after the registration process has started but the registration 
        /// is not yet complete.
        /// </summary>
        Registering,
    }

    /// <summary>
    /// Status of the protection of the item by the recovery services vault.
    /// </summary>
    public enum ItemProtectionStatus
    {
        /// <summary>
        /// Represents the healthy state of the protection.
        /// </summary>
        Healthy = 1,

        /// <summary>
        /// Represents a state of the protection which is unhealthy.
        /// </summary>
        Unhealthy,
    }

    /// <summary>
    /// State of the protection of the item by the recovery services vault.
    /// </summary>
    public enum ItemProtectionState
    {
        /// <summary>
        /// Initial backup is pending
        /// </summary>
        IRPending = 1,

        /// <summary>
        /// Error during protection
        /// </summary>
        ProtectionError,

        /// <summary>
        /// Protected
        /// </summary>
        Protected,

        /// <summary>
        /// Protection was disabled
        /// </summary>
        ProtectionStopped
    }

    #region policy
    public enum WeekOfMonth
    {
        First = 1,
        Second = 2,
        Third = 3,
        Fourth = 4,
        Last = 5
    }
    public enum Month
    {
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12
    }

    /// <summary>
    /// Represents how the policy can be scheduled.
    /// </summary>
    public enum ScheduleRunType
    {    
        Daily = 1,
        Weekly = 2,
    }

    /// <summary>
    /// Type of the duration for which the recovery points can be retained.
    /// </summary>
    public enum RetentionDurationType
    {
        Days = 1,
        Weeks = 2,
        Months = 3,
        Years = 4
    }

    /// <summary>
    /// Represents the format of the schedule
    /// </summary>
    public enum RetentionScheduleFormat
    {
        Daily = 1,
        Weekly = 2
    }

    #endregion

    #region jobs

    /// <summary>
    /// Types of operations which create jobs
    /// </summary>
    public enum JobOperation
    {
        /// <summary>
        /// Trigger backup
        /// </summary>
        Backup,

        /// <summary>
        /// Trigger restore
        /// </summary>
        Restore,

        /// <summary>
        /// Enable protection
        /// </summary>
        ConfigureBackup,

        /// <summary>
        /// Disable protection with retain data
        /// </summary>
        DisableBackup,

        /// <summary>
        /// Disable protection with delete data
        /// </summary>
        DeleteBackupData
    }

    /// <summary>
    /// Status of the job
    /// </summary>
    public enum JobStatus
    {
        InProgress,
        Cancelling,
        Cancelled,
        Completed,
        CompletedWithWarnings,
        Failed
    }

    #endregion

    public enum ILRAction
    {
        Connect,
        Extend,
        Terminate,
    }
}
