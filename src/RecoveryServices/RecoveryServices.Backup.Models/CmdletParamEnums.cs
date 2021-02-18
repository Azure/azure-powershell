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
    public enum VaultParams
    {
        VaultName,
        ResourceGroupName,
        VaultLocation,
    }

    public enum ContainerParams
    {
        Vault,
        ContainerType,
        BackupManagementType,
        BackupManagementServer,
        Name,
        ResourceGroupName,
        Status,
        Container,
        FriendlyName,
    }

    public enum RecoveryPointParams
    {
        StartDate,
        EndDate,
        Item,
        RecoveryPointId,
        RecoveryPoint,
        ILRAction,
        TargetLocation,
        KeyFileDownloadLocation,
        FileDownloadLocation,
        RestorePointQueryType
    }

    public enum RestoreBackupItemParams
    {
        RecoveryPoint,
        StorageAccountName,
        StorageAccountResourceGroupName
    }

    public enum RestoreVMBackupItemParams
    {
        TargetResourceGroupName,
<<<<<<< HEAD
        OsaOption
=======
        OsaOption,
        RestoreDiskList,
        RestoreOnlyOSDisk,
        RestoreAsUnmanagedDisks,
        DiskEncryptionSetId
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    }

    public enum RestoreFSBackupItemParams
    {
        ResolveConflict,
        SourceFilePath,
        SourceFileType,
        TargetStorageAccountName,
        TargetFileShareName,
<<<<<<< HEAD
        TargetFolder
=======
        TargetFolder,
        MultipleSourceFilePath
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    }
    public enum RestoreWLBackupItemParams
    {
        WLRecoveryConfig
    }

<<<<<<< HEAD
=======
    public enum CRRParams
    {
        UseSecondaryRegion,
        SecondaryRegion
    }

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    public enum WorkloadRecoveryConfigParams
    {
        PointInTime,
        RecoveryPoint,
        OriginalWorkloadRestore,
        AlternateWorkloadRestore,
        Item,
        TargetItem
    }

    public enum PolicyParams
    {
        WorkloadType,
        BackupManagementType,
        PolicyName,
        SchedulePolicy,
        RetentionPolicy,
        ProtectionPolicy,
        ResourceGroupName,
<<<<<<< HEAD
        ResourceName
=======
        ResourceName,
        FixForInconsistentItems
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    }

    public enum ItemParams
    {
        ItemName,
        AzureVMCloudServiceName,
        AzureVMResourceGroupName,
        WorkloadType,
        Policy,
        Item,
        ProtectableItem,
        ParameterSetName,
        Container,
        ProtectionStatus,
        ProtectionState,
        DeleteBackupData,
        BackupManagementType,
        ExpiryDateTimeUTC,
        StorageAccountName,
        BackupType,
<<<<<<< HEAD
        EnableCompression
=======
        EnableCompression,
        DeleteState,
        FriendlyName,
        InclusionDisksList,
        ExclusionDisksList,
        ResetExclusionSettings,
        ExcludeAllDataDisks
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    }

    public enum ProtectionCheckParams
    {
        Name,
        ResourceGroupName,
        ResourceType,
        ProtectableObjName
    }
}
