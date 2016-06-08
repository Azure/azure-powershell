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

using Microsoft.Azure.Commands.AzureBackup.Models;
using System;


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
        public static DateTime MinimumAllowedDate = new DateTime(DateTime.MinValue.Year, DateTime.MinValue.Month, DateTime.MinValue.Day, DateTime.MinValue.Hour, DateTime.MinValue.Minute, DateTime.MinValue.Second, DateTimeKind.Utc);

        public static string GetTypeForPS(string itemType)
        {
            AzureBackupItemType managedContainerType = (AzureBackupItemType)Enum.Parse(typeof(AzureBackupItemType), itemType, true);

            string returnType = string.Empty;

            switch (managedContainerType)
            {
                case AzureBackupItemType.IaasVM:
                    returnType = "AzureVM";
                    break;
            }

            return returnType;
        }

        public static string GetTypeForService(string itemType)
        {
            if (itemType.CompareTo("AzureVM") == 0)
                return AzureBackupItemType.IaasVM.ToString();
            throw new ArgumentException("Invalid value", "itemType");
        }


        public static bool IsValidStatus(string inputStatus)
        {
            JobStatus status;
            if (!Enum.TryParse<JobStatus>(inputStatus, out status) || status == JobStatus.Invalid)
            {
                return false;
            }
            return true;
        }

        public static bool IsValidOperationType(string inputOperationType)
        {
            JobOperationType operationType;
            if (!Enum.TryParse<JobOperationType>(inputOperationType, out operationType) || operationType == JobOperationType.Invalid)
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
