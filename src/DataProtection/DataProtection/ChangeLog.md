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
* Added support for UAMI in Backup Instance

## Version 2.5.0
* Added support for vault tier backup and restore for AzureKubernetesService
* Added support for resource modifier reference
* Added a fix for Update-AzDataProtectionBackupInstance

## Version 2.4.0
* Added vault tier restore and update backup instance for blobs.
* Added CmkEnryption parameters to Get-AzDataProtectionBackupVault, New-AzDataProtectionBackupVault and Update-AzDataProtectionBackupVault cmdlets.
* Added MUA support for DisableVaultImmutability, Restore, Stop-Protection, Suspend-backup, Disable soft delete operations.

## Version 2.3.0
* Onboarded new workloads AzureDatabaseForPGFlexServer, AzureDatabaseForMySQL for data protection.

## Version 2.2.0
* Added support for Cross region restore for Backup vaults

## Version 2.1.0
* Added soft delete and MUA feature for Backup vaults

## Version 2.0.0
* Added support for Blob Hardened recovery points (VaultStore).
* Added Cross Subscription Restore for `AzureDisk`, `AzureDatabaseForPostgreSQL` and `AzureBlob`.
* Added `Get-AzDataProtectionOperationStatus` command for long running cmdlets async.

## Version 1.2.0
* Added support for AKS workload with Backup Vaults
* Added support for `Set-AzDataProtectionMSIPermission` during restore with AKS workload

## Version 1.1.0
* Added support for Immutable backup vaults
* Added Cross subscription restore flag for backup vaults
* Added Soft delete setting for backup vaults
* Fixed issue with Set-AzDataProtectionMSIPermission command
* Replaced Get-InstalledModule with Get-Module -ListAvailable
* Added New-AzDataProtectionSoftDeleteSettingObject command

## Version 1.0.1
* Fixed spacing issues in Set-AzDataProtectionMSIPermission.ps1

## Version 1.0.0
* Fixed list parameter set for `Get-AzDataProtectionBackupVault`

## Version 0.5.0
* Added support for automatic assignment of permissions for configure backup for DPP workloads - AzureDisk, AzureBlob, AzureDatabaseForPostgreSQL using Set-AzDataProtectionMSIPermission cmdlet
* Added support for adding custom tags for new backup instance using New-AzDataProtectionBackupInstance cmdlet

## Version 0.4.0
* Added support for CRUD of resource guard resource.
* Added support for protection related commands with swagger refresh
    - Resume-AzDataProtectionBackupInstanceProtection
    - Stop-AzDataProtectionBackupInstanceProtection
    - Suspend-AzDataProtectionBackupInstanceBackup
    - Sync-AzDataProtectionBackupInstance

## Version 0.3.1
* Fixed trigger schedule client for `New-AzDataProtectionPolicyTriggerScheduleClientObject`

## Version 0.3.0
* Added support for AzureDatabaseForPostgreSQL workload

## Version 0.2.0
* OnBoarded workload AzureBlobs

## Version 0.1.0
* First preview release for module Az.DataProtection

