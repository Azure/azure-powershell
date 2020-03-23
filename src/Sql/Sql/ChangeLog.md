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
* Added readable secondary parameter to `Invoke-AzSqlDatabaseFailover`
* Added cmdlet `Disable-AzSqlServerActiveDirectoryOnlyAuthentication`
* Saved sensitivity rank when classifying columns in the database.

## Version 2.4.0
* Added PublicNetworkAccess to `New-AzSqlServer` and `Set-AzSqlServer`
* Added support for Long Term Retention backup configuration for Managed Databases
    - Get/Set LTR policy on a managed database 
    - Get LTR backup(s) by managed database, managed instance, or by location 
    - Remove an LTR backup 
    - Restore an LTR backup to create a new managed database
* Added MinimalTlsVersion to `New-AzSqlServer` and `Set-AzSqlServer`
* Added MinimalTlsVersion to `New-AzSqlInstance` and `Set-AzSqlInstance`
* Bumped SQL SDK version for Az.Network

## Version 2.3.0
* Added support for cross subscription point in time restore on Managed Instances.
* Added support for changing existing Sql Managed Instance hardware generation
* Fixed `Update-AzSqlServerVulnerabilityAssessmentSetting` help examples: parameter/property output - EmailAdmins
* Updating Azure SQL Server Active Azure administrator API to use 2019-06-01-preview api version.

## Version 2.2.0
Fix New-AzSqlDatabaseSecondary cmdlet to check for PartnerDatabaseName existence instead of DatabaseName existence.

## Version 2.1.2
* Fix vulnerability assessment set baseline cmdlets functionality to work on master db for azure database and limit it on managed instance system databases.
* Fix an error when creating SQL instance failover group
* Added PartnerDatabaseName parameter to New-AzSqlDatabaseSecondary cmdlet.

## Version 2.1.1
* Update references in .psd1 to use relative path
* Upgraded storage creation in Vulnerability Assessment auto enablement to StorageV2

## Version 2.1.0
* Added support for database ReadReplicaCount.
* Fixed Set-AzSqlDatabase when zone redundancy not set

## Version 2.0.0
* Added support for restore of dropped databases on Managed Instances.
* Deprecated from code old auditing cmdlets.
* Removed deprecated aliases:
* Get-AzSqlDatabaseIndexRecommendations (use Get-AzSqlDatabaseIndexRecommendation instead)
* Get-AzSqlDatabaseRestorePoints (use Get-AzSqlDatabaseRestorePoint instead)
* Remove Get-AzSqlDatabaseSecureConnectionPolicy cmdlet
* Remove aliases for deprecated Vulnerability Assessment Settings cmdlets
* Deprecate Advanced Threat Detection Settings cmdlets
* Adding cmdlets to Disable and enable sensitivity recommendations on columns in a database.
* Fix a small bug when reading auditing settings of a server or a database.

## Version 1.15.0
* Add support for setting Active Directory Administrator on Managed Instance

## Version 1.14.2
* Update example in reference documentation for `Get-AzSqlElasticPool`
* Added vCore example to creating an elastic pool (New-AzSqlElasticPool).
* Remove the validation of EmailAddresses and the check that EmailAdmins is not false in case EmailAddresses is empty in Set-AzSqlServerAdvancedThreatProtectionPolicy and Set-AzSqlDatabaseAdvancedThreatProtectionPolicy
* Enabled removal of server/database auditing settings when multiple diagnostic settings that enable audit category exist.
* Fix email addresses validation in multiple Sql Vulnerability Assessment cmdlets (Update-AzSqlDatabaseVulnerabilityAssessmentSetting, Update-AzSqlServerVulnerabilityAssessmentSetting, Update-AzSqlInstanceDatabaseVulnerabilityAssessmentSetting and Update-AzSqlInstanceVulnerabilityAssessmentSetting).

## Version 1.14.1
* Update documentation of old Auditing cmdlets.

## Version 1.14.0
* Add Azure Sql Instance pools cmdlets
* Add Azure Sql Instance pool usages cmdlets
* Update Azure Sql Managed instance cmdlets to support instance pools
* Fixed miscellaneous typos across module
* Add failover database and elastic pool new cmdlets.
* Add optional resource group parameter to Get-DatabaseLongTermRetentionBackup and Remove-DatabaseLongTermRetentionBackup cmdlets
* Add Azure Sql Elastic Jobs cmdlets

## Version 1.13.1
* Fix missing examples for Set-AzSqlDatabaseSecondary cmdlet
* Fix set Vulnerability Assessment recurring scans without providing any email addresses
* Fix a small typo in a warining message.

## Version 1.13.0
* Add Instance Failover Group cmdlets from preview release to public release
* Support Azure SQL Server\Database Auditing with new cmdlets.
    - Set-AzSqlServerAudit
    - Get-AzSqlServerAudit
    - Remove-AzSqlServerAudit
    - Set-AzSqlDatabaseAudit
    - Get-AzSqlDatabaseAudit
    - Remove-AzSqlDatabaseAudit
* Remove email constraints from Vulnerability Assessment settings

## Version 1.12.0
* Fix Advanced Threat Protection storage endpoint suffix
* Fix Advanced Data Security enable overrides Advanced Threat Protection policy
* New Cmdlets for Management.Sql to allow customers to add TDE keys and set TDE protector for managed instances
   - Add-AzSqlInstanceKeyVaultKey
   - Get-AzSqlInstanceKeyVaultKey
   - Remove-AzSqlInstanceKeyVaultKey
   - Get-AzSqlInstanceTransparentDataEncryptionProtector
   - Set-AzSqlInstanceTransparentDataEncryptionProtector

## Version 1.11.0
* Add DnsZonePartner Parameter for New-AzureSqlInstance cmdlet to support AutoDr for Managed Instance.
* Deprecating Get-AzSqlDatabaseSecureConnectionPolicy cmdlet
* Rename Threat Detection cmdlets to Advanced Threat Protection
* New-AzSqlInstance -StorageSizeInGB and -LicenseType parameters are now optional.
* Fix issue in reference documentation for `Enable-AzSqlServerAdvancedDataSecurity`

## Version 1.10.0
* Rename Advanced Threat Protection cmdlets to Advanced Data Security and enable Vulnerability Assessment by default

## Version 1.9.0
* Replace dependency on Monitor SDK with common code
* Updated cmdlets with plural nouns to singular, and deprecated plural names.
* Enhanced process of multiple columns classification.
* Include sku properties (sku name, family, capacity) in response from Get-AzSqlServerServiceObjective and format as table by default.
* Ability to Get-AzSqlServerServiceObjective by location without needing a preexisting server in the region.
* Support for time zone parameter in Managed Instance create.
* Fix documentation for wildcards
* Support of Serverless specific parameters in New-AzSqlDatabase and Set-AzSqlDatabase

## Version 1.8.0
* Support Database Data Classification.
* Add Get/Remove AzSqlVirtualCluster cmdlets.

## Version 1.7.0
* Add Vulnerability Assessment cmdlets on Server and Managed Instance

## Version 1.6.0
* changed Threat Detection's cmdlets param (ExcludeDetectionType) from DetectionType to string[] to make it future proof when new DetectionTypes are added and to support autocomplete as well.

## Version 1.5.0
* Updating AuditingEndpointsCommunicator.
    - Fixing the behavior of an edge case while creating new diagnostic settings.

## Version 1.4.0
* Add support for restore an instance database from geo-redundant backups
* Add support for backup short term retention on Managed Instance

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
