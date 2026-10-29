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
* First preview release for module Az.Commvault
    - Added cmdlets to manage Commvault cloud accounts: `New-AzCommvaultCloudAccount`, `Get-AzCommvaultCloudAccount`, `Update-AzCommvaultCloudAccount` and `Remove-AzCommvaultCloudAccount`
    - Added `Initialize-AzCommvaultSaaS`, `Connect-AzCommvaultCloudAccountSaaS` and `Get-AzCommvaultCloudAccountLatestLinkedSaaS` cmdlets to activate and link the Commvault SaaS
    - Added cmdlets to manage backup plans (`*-AzCommvaultPlan`), storages (`*-AzCommvaultStorage`) and the role mapping (`*-AzCommvaultRoleMapping`) of a cloud account
    - Added `Enable-AzCommvaultStorageComplianceLock`, `Disable-AzCommvaultStorageComplianceLock` and `Sync-AzCommvaultStorage` cmdlets to manage the compliance lock and refresh a storage
    - Added cmdlets to manage protection groups (`*-AzCommvaultProtectionGroup`) and to run, stop and resume backups and restores: `Backup-AzCommvaultProtectionGroup`, `Stop-AzCommvaultProtectionGroupBackup`, `Resume-AzCommvaultProtectionGroupBackup`, `Restore-AzCommvaultProtectionGroup` and `Restore-AzCommvaultProtectedItem`
    - Added `Get-AzCommvaultProtectedItem`, `Get-AzCommvaultProtectedItemCount` and `Get-AzCommvaultProtectedItemRestorePoint` cmdlets to inspect protected items and restore points

