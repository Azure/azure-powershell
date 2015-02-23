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

namespace Microsoft.WindowsAzure.Commands.StorSimple
{
    
    internal static class StorSimpleCmdletHelpMessage
    {
        public const string ACRName = "The access control record name.";
        public const string ACRObject = "The access control record object.";
        public const string DataContainerBandwidth = "The data container bandwidth rate.";
        public const string DataContainerEncryptionEnabled = "Flag to encrypt the data container.";
        public const string DataContainerEncryptionkey = "The encryption key for the data container.";
        public const string DataContainerId = "The volume container identifier.";
        public const string DataContainerName = "The volume container name.";
        public const string DataContainerObject = "The volume container object.";
        public const string DeviceConfigRequired = "Return Configuration details of the device.";
        public const string DeviceId = "The device identifier.";
        public const string DeviceModel = "The device model.";
        public const string DeviceName = "Name of the StorSimple device on which the commandlet is to be run";
        public const string DeviceType = "The device type.";
        public const string Force = "User confirmation is not required.";
        public const string IQNforACR = "The iSCSI Qualified Name (IQN).";
        public const string TaskId = "The task identifier.";
        public const string SACObject = "The storage account credential object.";
        public const string StorageAccountKey = "The storage account key.";
        public const string StorageAccountName = "The storage account name.";
        public const string UseSSL = "Flag to use SSL.";
        public const string Endpoint = "Azure storage endpoint.";
        public const string VolumeAcrList = "List of access control records.";
        public const string VolumeAppType = "The application type of the volume.";
        public const string VolumeDefaultBackup = "Flag to enable default backup.";
        public const string VolumeId = "The volume identifier.";
        public const string VolumeMonitoring = "Flag to enable monitoring.";
        public const string VolumeName = "The volume name.";
        public const string VolumeOnline = "Is the volume online";
        public const string VolumeSize = "The size of volume in bytes.";
        public const string WaitTillComplete = "Wait till the async operation completes.";
        public const string BackupPolicyName = "Name of the Backup policy that you wish to retrieve. Skip this parameter to get all policies";
        public const string BackupIdToDelete = "InstanceId of the Backup that needs to be deleted";
        public const string BackupIdToRestore = "InstanceId of the Backup that needs to be restored";
        public const string snapshotIdToRestore = "InstanceId of the Snapshot that needs to be restored";
        public const string BackupPolicyIdToDelete = "InstanceId of the BackupPolicy that needs to be deleted";
        public const string BackupPolicyToDelete = "The BackupPolicyDetails object that needs to be deleted";
        public const string BackupTypeDesc = "Enter LocalSnapshot or CloudSnapshot";
        public const string RecurrenceTypeDesc = "Enter \"Minutes or Hourly or Daily or Weekly\"";
        public const string RecurrenceValueDesc = "How often do you want a backup to be taken? Enter a numerical value";
        public const string RetentionCountDesc = "Number of days the backup should be retained before deleting";
        public const string BackupStartFromDesc = "Enter date from which you want to start taking backups. Default is now";
        public const string BackupEnabledDesc = "Set this parameter to false if you want to this backupschedule to be disabled";
        public const string NewBackupPolicyName = "The new name of the backup policy.";
        public const string BackupsToAddList = "List of BackupScheduleBase objects to be added to the policy";
        public const string VolumeIdsToAddList = "List of VolumeIds to be added";
        public const string BackupPolicyId = "InstanceId of the backupPolicy which created the backups";
        public const string VolumeIdForBackup = "InstanceId of the volume in which backups exist";
        public const string BackupPolicyDetailsObject = "Provide the BackupPolicyDetails object. The InstanceId of this object will be used as a filter for backups";
        public const string VolumeObject = "Provide the VirtualDisk object. The InstanceId of this object will be used as a filter for backups";
        public const string StartFrom = "The start date time for filtering backups";
        public const string EndTime = "The end date time for filtering backups";
        public const string FirstDesc = "Gets only the specified number of objects. Enter the number of objects to get";
        public const string SkipDesc = "Ignores the specified number of objects and then gets the remaining objects. Enter the number of objects to skip";
        public const string BackupPolicyIdForCreate = "Id of the backupPolicy which will be used to create backup";
        public const string BackupScheduleId = "Enter the InstanceId of the BackupSchedule object that you wish to update";
        public const string BackupPolicyIdToUpdate = "InstanceId of the backupPolicy which you are trying to update";
        public const string BackupPolicyNameChange = "Name of the backup policy. If you are changing the name, set -IsPolicyRenamed to 1";
        public const string IsPolicyRenamed = "If you are renaming the policy set this value to 1";
        public const string BackupScheduleBaseObjsToAdd = "List of BackupScheduleBase objects to be added to the policy";
        public const string BackupScheduleBaseObjsToUpdate = "List of BackupScheduleUpdateRequest objects to be updated";
        public const string BackupScheduleBaseObjsToDelete = "List of Instance Id of BackupSchedule objects to be deleted";
        public const string VolumeObjsToUpdate = "List of VolumeIds to be updated";
        public const string ResourceName = "Name of the resource which needs to be retrieved";
        public const string SourceDeviceId = "The device identifier of the source device";
        public const string SourceDeviceName = "Name of the source device";
        public const string BackupIdToClone = "The identifier of the backup to clone";
        public const string TargetDeviceId = "The device identifier of the target device";
        public const string TargetDeviceName = "Name of the target device";
        public const string CloneVolumeName = "The name to be assigned to the newly cloned volume on the target device";
        public const string SnapshotIdToClone = "The identifier of the backup snapshot to clone";
        public const string SnapshotToClone = "The snapshot object to be cloned";
    }
}
