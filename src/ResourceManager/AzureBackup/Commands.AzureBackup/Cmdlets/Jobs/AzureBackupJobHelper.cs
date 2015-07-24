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
using System.Management.Automation;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using Mgmt = Microsoft.Azure.Management.BackupServices.Models;


namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    public enum JobStatus
    {
        Invalid = 0,

        InProgress,

        Completed,

        Failed,

        CompletedWithWarnings,

        Cancelled,

        Cancelling
    }

    public enum JobOperationType
    {
        Invalid = 0,

        Register,

        ConfigureBackup,

        Backup,

        Restore,

        UnProtect,

        DeleteBackupData,

        Unregister
    }

    public static class AzureBackupJobHelper
    {
        public static bool IsValidStatus(string inputStatus)
        {
            JobStatus status;
            if(!Enum.TryParse<JobStatus>(inputStatus, out status) || status == JobStatus.Invalid)
            {
                return false;
            }
            return true;
        }

        public static bool IsValidOperationType(string inputOperationType)
        {
            JobOperationType operationType;
            if(!Enum.TryParse<JobOperationType>(inputOperationType, out operationType) || operationType == JobOperationType.Invalid)
            {
                return false;
            }
            return true;
        }

        public static bool IsJobRunning(string status)
        {
            return ((status.CompareTo("InProgress") == 0) || (status.CompareTo("Cancelling") == 0));
        }
    }
}
