using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.StorSimple
{
    internal static class StorSimpleCmdletHelpMessage
    {
        public const string HelpMessageACRName = "The access control record name.";
        public const string HelpMessageACRObject = "The access control record object.";
        public const string HelpMessageDataContainerBandwidth = "The data container bandwidth rate.";
        public const string HelpMessageDataContainerEncryptionEnabled = "Flag to encrypt the data container.";
        public const string HelpMessageDataContainerEncryptionkey = "The encryption key for the data container.";
        public const string HelpMessageDataContainerId = "The volume container identifier.";
        public const string HelpMessageDataContainerName = "The volume container name.";
        public const string HelpMessageDataContainerObject = "The volume container object.";
        public const string HelpMessageDeviceConfigRequired = "Return Configuration details of the device.";
        public const string HelpMessageDeviceId = "The device identifier.";
        public const string HelpMessageDeviceModel = "The device model.";
        public const string HelpMessageDeviceName = "Name of the StorSimple device on which the commandlet is to be run";
        public const string HelpMessageDeviceType = "The device type.";
        public const string HelpMessageForce = "User confirmation is not required.";
        public const string HelpMessageIQNforACR = "The iSCSI Qualified Name (IQN).";
        public const string HelpMessageJobId = "The job identifier.";
        public const string HelpMessageSACObject = "The storage account credential object.";
        public const string HelpMessageStorageAccountKey = "The storage account key.";
        public const string HelpMessageStorageAccountName = "The storage account name.";
        public const string HelpMessageUseSSL = "Flag to use SSL.";
        public const string HelpMessageVolumeAcrList = "List of access control records.";
        public const string HelpMessageVolumeAppType = "The application type of the volume.";
        public const string HelpMessageVolumeDefaultBackup = "Flag to enable default backup.";
        public const string HelpMessageVolumeId = "The volume identifier.";
        public const string HelpMessageVolumeMonitoring = "Flag to enable monitoring.";
        public const string HelpMessageVolumeName = "The volume name.";
        public const string HelpMessageVolumeOnline = "Is the volume online";
        public const string HelpMessageVolumeSize = "The size of volume in bytes.";
        public const string HelpMessageWaitTillComplete = "Wait till the async operation completes.";
        public const string HelpMessageBackupPolicyName = "Name of the Backup policy that you wish to retrieve. Skip this parameter to get all policies";
        public const string HelpMessageBackupIdToDelete = "InstanceId of the Backup that needs to be deleted";
        public const string HelpMessageBackupIdToRestore = "InstanceId of the Backup that needs to be restored";
        public const string HelpMessagesnapshotIdToRestore = "InstanceId of the Snapshot that needs to be restored";
        public const string HelpMessageBackupPolicyIdToDelete = "InstanceId of the BackupPolicy that needs to be deleted";
        public const string HelpMessageBackupPolicyToDelete = "The BackupPolicyDetails object that needs to be deleted";
        public const string HelpMessageBackupTypeDesc = "Enter LocalSnapshot or CloudSnapshot";
        public const string HelpMessageRecurrenceTypeDesc = "Enter \"Minutes or Hourly or Daily or Weekly\"";
        public const string HelpMessageRecurrenceValueDesc = "How often do you want a backup to be taken? Enter a numerical value";
        public const string HelpMessageRetentionCountDesc = "Number of days the backup should be retained before deleting";
        public const string HelpMessageBackupStartFromDesc = "Enter date from which you want to start taking backups. Default is now";
        public const string HelpMessageBackupEnabledDesc = "Set this parameter to false if you want to this backupschedule to be disabled";
        public const string HelpMessageNewBackupPolicyName = "The new name of the backup policy.";
        public const string HelpMessageBackupsToAddList = "List of BackupScheduleBase objects to be added to the policy";
        public const string HelpMessageVolumeIdsToAddList = "List of VolumeIds to be added";
        public const string HelpMessageBackupPolicyId = "InstanceId of the backupPolicy which created the backups";
        public const string HelpMessageVolumeIdForBackup = "InstanceId of the volume in which backups exist";
        public const string HelpMessageBackupPolicyDetailsObject = "Provide the BackupPolicyDetails object. The InstanceId of this object will be used as a filter for backups";
        public const string HelpMessageVolumeObject = "Provide the VirtualDisk object. The InstanceId of this object will be used as a filter for backups";
        public const string HelpMessageStartFrom = "The start date time for filtering backups";
        public const string HelpMessageEndTime = "The end date time for filtering backups";
        public const string HelpMessageFirstDesc = "Gets only the specified number of objects. Enter the number of objects to get";
        public const string HelpMessageSkipDesc = "Ignores the specified number of objects and then gets the remaining objects. Enter the number of objects to skip";
        public const string HelpMessageBackupPolicyIdForCreate = "Id of the backupPolicy which will be used to create backup";
        public const string HelpMessageBackupScheduleId = "Enter the InstanceId of the BackupSchedule object that you wish to update";
        public const string HelpMessageBackupPolicyIdToUpdate = "InstanceId of the backupPolicy which you are trying to update";
        public const string HelpMessageBackupPolicyNameChange = "Name of the backup policy. If you are changing the name, set -IsPolicyRenamed to 1";
        public const string HelpMessageIsPolicyRenamed = "If you are renaming the policy set this value to 1";
        public const string HelpMessageBackupScheduleBaseObjsToAdd = "List of BackupScheduleBase objects to be added to the policy";
        public const string HelpMessageBackupScheduleBaseObjsToUpdate = "List of BackupScheduleUpdateRequest objects to be updated";
        public const string HelpMessageBackupScheduleBaseObjsToDelete = "List of Instance Id of BackupSchedule objects to be deleted";
        public const string HelpMessageVolumeObjsToUpdate = "List of VolumeIds to be updated";
        public const string HelpMessageResourceName = "Name of the resource which needs to be retrieved";
    }
}
