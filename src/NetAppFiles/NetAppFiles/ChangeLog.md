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
