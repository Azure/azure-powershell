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
    public enum ContainerType
    {
        AzureVM,
    }

    public enum BackupManagementType
    {
    }

    public enum WorkloadType
    {
    }

    public enum PsBackupProviderTypes
    {
        IaasVm = 1,
    }

    public enum ContainerRegistrationStatus
    {
        Registered = 1,
        Registering,
    }

    #region policy
    public enum WeekOfMonth
    {
        Invalid = 0,
        First = 1,
        Second = 2,
        Third = 3,
        Fourth = 4,
        Last = 5
    }
    public enum Month
    {
        Invalid = 0,
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

    public enum ScheduleRunType
    {    
        Invalid = 0,
        Daily = 1,
        Weekly = 2,
    }

    public enum RetentionDurationType
    {
        Invalid = 0,
        Days = 1,
        Weeks = 2,
        Months = 3,
        Years = 4
    }

    public enum RetentionScheduleFormat
    {
        Invalid = 0,
        Daily = 1,
        Weekly = 2
    }  

    #endregion

}
