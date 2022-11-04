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

