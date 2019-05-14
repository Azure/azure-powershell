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

## Version 1.4.0
* Support for Cross subscription Azure to Azure site recovery.
* Marking upcoming breaking changes for Azure Site Recovery.
* Fix for Azure Site Recovery recovery plan end action plan.
* Fix for Azure Site Recovery Update network mapping for Azure to Azure.
* Fix for Azure Site Recovery update protection direction for Azure to Azure for managed disk.
* Other minor fixes.

## Version 1.3.0
* Updated cmdlets with plural nouns to singular, and deprecated plural names.
* Updated table format for SQL in azure VM
* Added alternate method to fetch location in AzureFileShare
* Updated ScheduleRunDays in SchedulePolicy object according to timezone
* Made some attibutes read-only in Get-AzRecoveryServicesBackupWorkloadRecoveryConfig 

## Version 1.2.0
* Added SnapshotRetentionInDays in Azure VM policy to support Instant RP
* Added pipe support for unregister container
 
## Version 1.1.0
* Added Sql server in Azure VM support
* SDK Update
* Removed VMappContainer check in Get-ProtectableItem
* Added Name and ServerName as parameters for Get-ProtectableItem
* Updated internal API for triggering adhoc inquiry

## Version 1.0.1
* Release with updated Authentication dependency

## Version 1.0.0
* General availability of `Az.RecoveryServices` module
