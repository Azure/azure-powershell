<!--
    Please leave this section at the top of the change log.

    Changes for the upcoming release should go under the section titled "Upcoming Release", and should adhere to the following format:

    ## Upcoming Release
    * Overview of change #1
        - Additional information about change #1
    * Overview of change #2
        - Additional information about change #2
        - Additional information about change #2
    * Overview of change #3
    * Overview of change #4
        - Additional information about change #4

    ## YYYY.MM.DD - Version X.Y.Z (Previous Release)
    * Overview of change #1
        - Additional information about change #1
-->
## Upcoming Release
* upgraded nuget package to signed package.

## Version 0.20.0
* Removed parameters `Location`, `PoolName`, `VolumeName` from `Get-AzNetAppFilesBackup`, `New-AzNetAppFilesBackup`, `Update-AzNetAppFilesBackup`, `Remove-AzNetAppFilesBackup` and `Restore-AzNetAppFilesBackupFile`

## Version 0.19.0
* Added new cmdLets for on-prem volume migration `Start-AnfPeerExternalCluster`, `Start-AnfFinalizeExternalReplication`, `Start-AnfPerformExternalReplication`, `Start-AnfAuthorizeExternalReplication`
* Added new cmdLets `Get-AzNetAppFilesQuotaAvailability`, `Get-AzNetAppFilesNameAvailability` and `Get-AzNetAppFilesFileNameAvailability`
* Added `RemotePath` to `PSNetAppFilesReplicationObject`
* Added `EffectiveNetworkFeatures` to `PSNetAppFilesVolume`

## Version 0.18.0
* Fixed some minor issues
* Added `SnapshotName` to `New-AzNetAppFilesBackup`
* Fixed `New-AzNetAppFilesBackup`, `Label` is not a requred parameter

## Version 0.17.0
* Updated to api-version 2024-03-01

## Version 0.16.0
* Updated to api-version 2023-11-01
* Fixed some minor issues

## Version 0.15.2
* Upgraded Azure.Core to 1.37.0.

## Version 0.15.1
* Fixed some minor issues

## Version 0.15.0
* Fixed some minor issues
* Updated to api-version 2023-07-01

## Version 0.14.0
* Fixed some minor issues
* Updated to api-version 2023-05-01
* Added `EncryptionKeySource`, `KeyVaultKeyName`, `KeyVaultResourceId`, `KeyVaultUri`, `IdentityType`, `UserAssignedIdentity` to `New-AzNetAppFilesAccount` and `Update-AzNetAppFilesAccount`
* Added new cmdlets `Get-AzNetAppFilesNetworkSiblingSet` and `Update-AzNetAppFilesNetworkSiblingSet` to query and update the network features of a network sibling set
* Added `CoolAccessRetrievalPolicy` to `New-AzNetAppFilesVolume` and `Update-AzNetAppFilesVolume`
* Added `SmbNonBrowsable` and `SmbAccessBasedEnumeration` to `Update-AzNetAppFilesVolume`

## Version 0.13.2
* Fixed some minor issues
* Upgraded Azure.Core to 1.35.0.

## Version 0.13.1
* Updated Azure.Core to 1.34.0.

## Version 0.13.0
* Updated to api-version 2022-11-01        
* Added `Identity` to NetAppAccountPatch
* Added `ActualThroughputMibps` and `OriginatingResourceId`
* Added `SnapshotDirectoryVisible` to Update-AzNetAppFilesVolume
    - If enabled (true) the volume will contain a read-only .snapshot directory which provides access to each of the volume's snapshots (default to true)
* Updated Azure.Core to 1.33.0.


## Version 0.12.0
* Updated Azure.Core to 1.31.0.
* Added cmdLet `Restore-AzNetAppFilesBackupFile`                 
* Added cmdLet `Unlock-AzNetAppFilesVolumeFileLock`
* Added parameter `LdapSearchScope` and `PreferredServersForLdapClient` to `New-AzNetAppFilesActiveDirectory`
* Added parameter `IsLargeVolume` to `NewAzNetAppFilesVolume`
* Added property `PreferredServersForLdapClient` to `PSNetAppFilesActiveDirectory`
* Added property `TennantId` and `Type` to `PSNetAppFilesActiveDirectory`
* Added property `FileAccessLogs`, `DataStoreResourceId`, `ProvisionedAvailabilityZone`, `IsLargeVolume` to `PSNetAppFilesVolume`
* Added property `TenantId`, `Type` to `PSEncryptionIdentity`
* Added property `Name`, `Tags`, `location` to `PSNetAppFilesVolumeQuotaRule`
Breaking change:
* Removed `Get-AzNetAppFilesVault` this cmdLet is no longer needed
* Removed `vaultId` from `PSNetAppFilesVolumeBackupProperties`
* `YearlyBackupsToKeep` property is not supported by the service and has been removed from `New-AzNetAppFilesBackupPolicy`, `Set-AzNetAppFilesBackupPolicy` and `Update-AzNetAppFilesBackupPolicy` deprecation warning removed

## Version 0.11.1
* Updated Azure.Core to 1.28.0.

## Version 0.11.0
* Added cmdlet `Reset-AzNetAppFilesVolumeCifsPassword`
* Added cmdlet `Get-AzNetAppFilesVolumeReplications` and `Restore-AzNetAppFilesVolume`
* Added cmdLet `Get-AzNetAppFilesVolumeQuotaRule`, `Get-AzNetAppFilesVolumeQuotaRule`, `New-AzNetAppFilesVolumeQuotaRule`, `Update-AzNetAppFilesVolumeQuotaRule` and `Remove-AzNetAppFilesVolumeQuotaRule`
* Added cmdLet `Update-NetAppFilesAccountCredential`
* Added properties `Identity`, `Encryption` and `DisableShowmount` to `PSNetAppFilesAccount`
* Added properties `Encrypted` and `Zones`, `DeleteBaseSnapshot`, `KeyVaultPrivateEndpointResourceId`,`SmbAccessBasedEnumeration`, `SmbNonBrowsable`, `EncryptionKeySource`, `VolumeSpecName` to `PSNetAppFilesVolume`
* Added paramter `CoolAccess` to `Update-AzNetAppFilesPool`
* Added paramter `DeleteBaseSnapshot`, `SmbAccessBasedEnumeration`, `SmbNonBrowsable`, `EncryptionKeySource` and `KeyVaultPrivateEndpointResourceId` to `New-AzNetAppFilesVolume`
* Added paramter `CoolAccess`, `CoolnessPeriod`, `EncryptionKeySource` and `KeyVaultPrivateEndpointResourceId` to `Update-AzNetAppFilesVolume`
* Planning to deprecate the cmdLet `Get-AzNetAppFilesVault` as it will not be needed 

## Version 0.10.0
* Added cmdlet `New/Remove/Get/Update-AzNetAppFilesSubvolume` and `Get-AzNetAppFilesSubvolumeMetadata`
* Added cmdlet `New/Remove/Get-AzNetAppFilesVolumeGroup`
* Added cmdlet `New-AzNetAppFilesExportPolicyRuleObject` and `New-AzNetAppFilesExportPolicyObject`
* Added `Restore-AzNetAppFilesSnapshot` to restore the specified files from the specified snapshot to the active filesystem
* Added property `LdapSearchScope` to `PSNetAppFilesActiveDirectory`
* Added property `SystemData` to `PSNetAppFilesBackupPolicy`, `PSNetAppFilesAccount` and `PSNetAppFilesPool` 
* Added property `SystemData` and `MonthlySchedule` to output type `PSNetAppFilesSnapshotPolicy` 
* Added property `SystemData`, `MaximumNumberOfFiles` and `EnableSubvolumes` to output type `PSNetAppFilesVolume` 
* Added parameter `EnableSubvolume` and `UnixPermission` to `Update-AzNetAppFilesVolume`
* Added parameter `ForceDelete' to `Remove-AzNetAppFilesVolume`

## Version 0.9.0
* Added `Administrators` and `EncryptDCConnections` to `ActiveDirectory`
* Added `Get-AzNetAppFilesQuotaLimit` to get the default and current limits for quotas
* Added `CapacityPoolResourceId`, `ProximityPlacementGroup`, `VolumeSpecName` and `PlacementRules` to `Volume`

Breaking change:
* The `Administrators` parameter in `New-AzNetAppFilesActiveDirectory` and `Update-AzNetAppFilesActiveDirectory` is changed to singularform `Administrator` to follow Powrshell convetion

## Version 0.8.0
* Added list NetAppAccounts by subscription
* Added etags to response PSNetAppFilesVolume, PSNetAppFilesPool, PSNetAppFilesAccount, PSNetAppFilesBackupPolicy, PSNetAppFilesSnapshotPolicy
* Added EncryptionType to New-AzNetAppFilesPool and PSNetAppFilesPool
* Added CloneProgress, AvsDataStore,IsDefaultQuotaEnabled, DefaultUserQuotaInKiBs, DefaultGroupQuotaInKiBs, NetworkFeatures, NetworkSiblingSetId, StorageToNetworkProximity to PSNetAppFilesVolume 
* Added CloneProgress, AvsDataStore,IsDefaultQuotaEnabled, DefaultUserQuotaInKiBs, DefaultGroupQuotaInKiBs, NetworkFeatures to New-AzNetAppFilesVolume
* Added IsDefaultQuotaEnabled, DefaultUserQuotaInKiBs, DefaultGroupQuotaInKiBs  Update-AzNetAppFilesVolume
* Service level now supports StandardZRS
Breaking change:
         - YearlyBackupsToKeep property is not supported by the service and has been removed from New-AzNetAppFilesBackupPolicy, Set-AzNetAppFilesBackupPolicy and output

## Version 0.7.0
* Added Administrators to ActiveDirectory
* Added LastTransferSize, LastTransferType,TotalTransferBytes to BackupStatus
* Added CoolAccess and QosType to CapacityPool
* Added CoolAccess, CoolnessPeriod and UnixPermissions to Volume
* Added ChownMode to ExportPolicyRule
* Added Get-Az-NetAppFilesVolumeRestoreStatus to get the status of a restore operation for a volume

## Version 0.6.0
* Added UseExistingSnapshot to Backups 
* SnapshotPolicyId to UpdateAnfNetAppFilesVolume, this can be used to apply a snapshot policy to an existing volume

## Version 0.5.0
* Added AllowLocalNfsUsersWithLdap to ActiveDirectory
* Added VolumeName to Backup
* Added LdapEnabled to Volume
* Added Get-AzNetAppFilesVolumeBackupStatus to get the status of the backup for a volume

## Version 0.4.0
* Added SecurityOperators to ActiveDirectory
* Volume list now gets all volumes instead of first over 100 volumes
* Added SnapshotPolicyId to NewAzNetAppFilesVolume to set snapshot policy to volume
* Added AesEncryption, LdapOverTLS, LdapSigning to ActiveDirectory
* Added FailureReason to Backup and backup patch  
* Added Encryption and systemData to NetAppAccount
* Added EncryptionKeySource to volume

## Version 0.3.0
* Added aesEncryption, ldapSigning properties to ActiveDirectory
* Fixed Tags in UpdateAzNetAppFilesBackupPolicy
* Return backupId in Backup and BackupPatch models

## Version 0.2.0

* Add new Backup Policy cmdlets:
    - `Get-AzNetAppFilesBackupPolicy`
    - `New-AzNetAppFilesBackupPolicy`
    - `Remove-AzNetAppFilesBackupPolicy`
    - `Update-AzNetAppFilesBackupPolicy`    
* Add new Snapshot Policy cmdlets:
    - `Get-AzNetAppFilesBackupPolicy`
    - `New-AzNetAppFilesBackupPolicy`
    - `Remove-AzNetAppFilesBackupPolicy`
    - `Update-AzNetAppFilesBackupPolicy`    
* Add new Backup cmdlets:
    - `Get-AzNetAppFilesBackup`
    - `New-AzNetAppFilesBackup`
    - `Remove-AzNetAppFilesBackup`
    - `Update-AzNetAppFilesBackup`
* Add new Active Directory cmdlets:
    - `Get-AzNetAppFilesActiveDirectory`
    - `New-AzNetAppFilesActiveDirectory`
    - `Remove-AzNetAppFilesActiveDirectory`
    - `Update-AzNetAppFilesActiveDirectory`
* Add new `Get-AzNetAppFilesVault` cmdlet (use for backups, vaults currently only support getting list of vaults):
* Add new Set-AzNetAppFilesVolumePool cmdlet, to move volume to another pool
* Add parameters to `New-AzNetAppFilesVolume` 
     - Backup to to enable Backups and Backup Policy 
     - Snapshot to enable Snapshot Policy 
     - totalThroughputMips
     - SnapshotDirectoryVisible
     - BackupId
     - SecurityStyle
     - KerberosEnabled
* Add paramters to `Update-AzNetAppFilesVolume`
     - Backup to to enable Backups and Backup Policy
     - totalThroughputMips
* Add property StatusDetails to Account
* Add properties to support LDAP over SSL/TLS to ActiveDirectory
* Add properties to support Kerberos to ExportPolicy rule
* Add QosType parameter to Pool `New-AzNetAppFilesPool` and `Update-AzNetAppFilesPool`
* Breaking Removed ServiecLevel from `Update-AzNetAppFilesPool` as that updating servie level is not supported
* Add `Initialize-AzNetAppFilesReplication` cmdLet
* Add ForceBreak parameter to `Suspend-AzNetAppFilesReplication` to force break the replication if replication is in status transferring


## Version 0.1.6
* Added SnapshotId parameter to New-NetAppFilesVolume to create volume from a snapshot
* Added Restore-AzNetAppFilesVolume to restore/revert a volume to one of its snapshots
* FileSystemId removed from Snapshot
* Added BackupOperators to ActiveDirectory, list of users to add to Backup Operator active directory group
* Added Status, OrganizationalUnit and Site properties to ActiveDirectory
* Added SnapshotDirectoryVisible to Volume, If enabled (true) the volume will contain a read-only .snapshot directory which provides access to each of the volume's snapshots (default to true)
* Added Snapshot to Volume DataProtection
 
## Version 0.1.5
* Includes replication operations

## Version 0.1.4
* Update references in .psd1 to use relative path
* Includes some additional volume properties associated with upcoming replication operations

## Version 0.1.3
* Volume creation --protocol-types accepts now "NFSv4.1" not "NFSv4"
* Volume export policy property now named 'nfsv41' not 'nfsv4'
* Snapshot creation date now named just 'created'

## Version 0.1.2
* Addition of ProtocolTypes and MountTargets to volume properties
* Addition of ProtocolType parameter for new volume creation
* Pool size and Volume usageThreshold required on creation

* Fixed miscellaneous typos across module

## Version 0.1.1
* Add new cmdlets:
    - `Set-AzNetAppFilesAccount`
    - `Update-AzNetAppFilesAccount`
* Account:
    * Active Directory `PSNetAppFilesActiveDirectory` added to account methods `New-AnfAccount`, `Set-AnfAccount` and `Update-AnfAccount`
* Volume:
    * Export Policy `PSNetAppFilesVolumeExportPolicy` added to volume methods `New-AnfVolume` and `Update-AnfVolume`
* Snapshot:
    * FileSystemId is now optional during snapshot creation `New-AnfSnapshot`

## Version 0.1.0
* Preview of `Az.NetAppFiles` module
