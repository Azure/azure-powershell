<!--
    Please leave this section at the top of the change log.

    Changes for the upcoming release should go under the section titled "Upcoming Release", and should adhere to the following format:

    ## Upcoming Release
    * Overview of change #1
        - Additional information about change #1
    * Overview of change #2
        - Additional information about change #4
        - Additional information about change #2
    * Overview of change #3
    * Overview of change #4
        - Additional information about change #4

    ## YYYY.MM.DD - Version X.Y.Z (Previous Release)
    * Overview of change #1
        - Additional information about change #1
-->
## Upcoming Release
* Add support for restore an instance database from geo-redundant backups

## Version 1.3.0
* Add support for SQL DB Hyperscale tier
* Fixed bug where restore could fail due to setting unnecessary properties in restore request


## Version 1.2.0
* Add Get/Set AzSqlDatabaseBackupShortTermRetentionPolicy
* Fix issue where not being logged into Azure account would result in nullref exception when executing SQL cmdlets
* Fixed null ref exception in Get-AzSqlCapability
* Support Database/Server auditing to event hub and log analytics.

## Version 1.1.0
* Update incorrect online help URLs
* Updated parameter description for LicenseType parameter with possible values
* Fix for updating managed instance identity not working when it is the only updated property
* Support for custom collation on managed instance

## Version 1.0.1
* Converted the Storage management client dependency to the common SDK implementation.

## Version 1.0.0
* General availability of `Az.Sql` module
* Added new Data_Exfiltration and Unsafe_Action detection types to Threat Detection's cmdlets
* Removed -State and -ResourceId parameters from Set-AzSqlDatabaseBackupLongTermRetentionPolicy
* Removed deprecated cmdlets: Get/Set-AzSqlServerBackupLongTermRetentionVault, Get/Start/Stop-AzSqlServerUpgrade, Get/Set-AzSqlDatabaseAuditingPolicy, Get/Set-AzSqlServerAuditingPolicy, Remove-AzSqlDatabaseAuditing, Remove-AzSqlServerAuditing
* Removed deprecated parameter "Current" from Get-AzSqlDatabaseBackupLongTermRetentionPolicy
* Removed deprecated parameter "DatabaseName" from Get-AzSqlServerServiceObjective
* Removed deprecated parameter "PrivilegedLogin" from Set-AzSqlDatabaseDataMaskingPolicy
* Modified documentation of examples related to SQL Auditing cmdlets.
