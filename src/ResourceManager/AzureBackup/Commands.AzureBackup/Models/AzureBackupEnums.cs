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

namespace Microsoft.Azure.Commands.AzureBackup.Models
{
    public enum AzureBackupVaultStorageType
    {
        GeoRedundant = 1,
        LocallyRedundant,
    }

    public enum AzureBackupContainerType
    {
        Windows = 1,
        SCDPM,
        AzureVM,
        AzureBackupServer,
        Other,
    }

    public enum DataSourceType
    {
        Invalid = 0,

        VM
    }

    public enum AzureBackupContainerRegistrationStatus
    {
        Registered = 1,
        Registering,
        NotRegistered,
    }

    public enum ScheduleType
    {
        Invalid = 0,
        Daily = 1,
        Weekly = 2
    }

    public enum BackupType
    {
        Invalid = 0,
        Full = 1
    }

    public enum CSMAzureBackupOperationStatus
    {

        Invalid = 0,


        InProgress,


        Cancelled,


        Succeeded,


        Failed,


        PartialSuccess
    }

    public enum AzureBackupOperationErrorCode
    {
        BMSUserErrorObjectLocked = 390026,
        DiscoveryInProgress = 410002,
    }

    public enum ManagedContainerType
    {
        Invalid = 0,
        IaasVM,
        IaasVMService,
    }

    public enum RetentionType
    {
        Invalid = 0,
        Daily = 1,
        Weekly = 2,
        Monthly = 3,
        Yearly = 4
    }

    public enum WorkloadType
    {
        Invalid = 0,
        AzureVM = 1
    }

    public enum RetentionFormat
    {
        Daily,
        Weekly
    }

    public enum AzureBackupItemType
    {
        IaasVM = 0
    }
}
