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

## Version 2.16.0
* Added MaintenanceConfigurationId to 'New-AzSqlDatabase', 'Set-AzSqlDatabase', 'New-AzSqlElasticPool' and 'Set-AzSqlElasticPool'
* Fixed regression in 'Set-AzSqlServerAudit' when PredicateExpression argument is provided

## Version 2.15.0
* Made `Start-AzSqlInstanceDatabaseLogReplay` cmdlet synchronous, added -AsJob flag

## Version 2.14.0
* Fixed parameter description for `InstanceFailoverGroup` command.
* Updated the logic in which schemaName, tableName and columnName are being extracted from the id of SQL Data Classification commands.
* Fixed Status and StatusMessage fields in `Get-AzSqlDatabaseImportExportStatus` to conform to documentation
* Added Microsoft support operations (DevOps) auditing cmdlets: Get-AzSqlServerMSSupportAudit, Set-AzSqlServerMSSupportAudit, Remove-AzSqlServerMSSupportAudit

## Version 2.13.0
* Added SecondaryType to the following: 
    - `New-AzSqlDatabase`
    - `Set-AzSqlDatabase`
    - `New-AzSqlDatabaseSecondary`
* Added HighAvailabilityReplicaCount to the following: 
    - `New-AzSqlDatabase`
    - `Set-AzSqlDatabase`
* Made ReadReplicaCount an alias of HighAvailabilityReplicaCount in the following: 
    - `New-AzSqlDatabase`
    - `Set-AzSqlDatabase`

## Version 2.12.0
* Fixed issues where Set-AzSqlDatabaseAudit were not support Hyperscale database and database edition cannot be determined
* Added MaintenanceConfigurationId to 'New-AzSqlInstance' and 'Set-AzSqlInstance'
* Fixed a bug in GetAzureSqlDatabaseReplicationLink.cs where PartnerServerName parameter was being checked for by value instead of key

## Version 2.11.1
* Fixed issue where New-AzSqlDatabaseExport fails if networkIsolation not specified [#13097]
* Fixed issue where New-AzSqlDatabaseExport and New-AzSqlDatabaseImport were not returning OperationStatusLink in the result object [#13097]
* Update Azure Paired Regions URL in Backup Storage Redundancy Warnings

## Version 2.11.0
* Added BackupStorageRedundancy to the following: 
    - `Restore-AzureRmSqlDatabase`
    - `New-AzSqlDatabaseCopy`
    - `New-AzSqlDatabaseSecondary`
* Removed case sensitivity for BackupStorageRedundancy parameter for all SQL DB references 
* Updated BackupStorageRedundancy warning message names
* Added support for Managed HSM Uris for SQL DB and Managed Instance

## Version 2.10.1
* Added warning for BackupStorageRedundancy configuration in select regions in `New-AzSqlDatabase` (Ignore Case for BackupStorageRedundancy configuration input)
* Fixed for bug in `New-AzSqlDatabaseExport`
* Removed case sensitivity for BackupStorageRedundancy parameter for `New-AzSqlInstance` 

## Version 2.10.0
* Added BackupStorageRedundancy to `New-AzSqlInstance` and `Get-AzSqlInstance`
* Added cmdlet `Get-AzSqlServerActiveDirectoryOnlyAuthentication`
* Added cmdlet `Enable-AzSqlServerActiveDirectoryOnlyAuthentication`
* Added Force parameter to `New-AzSqlInstance`
* Added cmdlets for Managed Database Log Replay service
	- `Start-AzSqlInstanceDatabaseLogReplay`
	- `Get-AzSqlInstanceDatabaseLogReplay`
	- `Complete-AzSqlInstanceDatabaseLogReplay`
	- `Stop-AzSqlInstanceDatabaseLogReplay`
* Added cmdlet `Get-AzSqlInstanceActiveDirectoryOnlyAuthentication`
* Added cmdlet `Enable-AzSqlInstanceActiveDirectoryOnlyAuthentication`
* Added cmdlet `Disable-AzSqlInstanceActiveDirectoryOnlyAuthentication`
* Updated cmdlets `New-AzSqlDatabaseImport` and `New-AzSqlDatabaseExport` to support network isolation functionality
* Added cmdlet `New-AzSqlDatabaseImportExisting`
* Updated Databases cmdlets to support backup storage type specification
* Added Force parameter to `New-AzSqlDatabase`
* Updated ActiveDirectoryOnlyAuthentication cmdlets for server and instance to include ResourceId and InputObject
* Added support for Managed HSM Uris for SQL DB and Managed Instance

## Version 2.9.1
* Fixed potential server name case insensitive error in `New-AzSqlServer` and `Set-AzSqlServer`
* Fixed wrong database name returned on existing database error in `New-AzSqlDatabaseSecondary`
* Added operation parameters and steps in `Get-AzSqlInstanceOperation`

## Version 2.9.0
* Added support for Service principal and guest users in Set-AzSqlInstanceActiveDirectoryAdministrator cmdlet`
* Fixed a bug in Data Classification cmdlets.`
* Added support for Azure SQL Managed Instance failover: `Invoke-AzSqlInstanceFailover`

## Version 2.8.0
* Added support for service principal for Set SQL Server Azure Active Directory Admin cmdlet
* Fixed sync issue in Data Classification cmdlets.
* Supported searching user by mail on `Set-AzSqlServerActiveDirectoryAdministrator` [#12192]

## Version 2.7.0
* Added UsePrivateLinkConnection to `New-AzSqlSyncGroup`, `Update-AzSqlSyncGroup`, `New-AzSqlSyncMember` and `Update-AzSqlSyncMember`
* Added SyncMemberAzureDatabaseResourceId to `New-AzSqlSyncMember` and `Update-AzSqlSyncMember`
* Added Guest user lookup support to Set SQL Server Azure Active Directory Admin cmdlet
* Remove IsAzureADOnlyAuthentication parameter from Set-AzSqlServerActiveDirectoryAdministrator as it is not usable. 

## Version 2.6.1
* Enhance performance of:
    - `Set-AzSqlDatabaseSensitivityClassification`
    - `Set-AzSqlInstanceDatabaseSensitivityClassification`
    - `Remove-AzSqlDatabaseSensitivityClassification`
    - `Remove-AzSqlInstanceDatabaseSensitivityClassification`
    - `Enable-AzSqlDatabaseSensitivityRecommendation`
    - `Enable-AzSqlInstanceDatabaseSensitivityRecommendation`
    - `Disable-AzSqlDatabaseSensitivityRecommendation`
    - `Disable-AzSqlInstanceDatabaseSensitivityRecommendation`
* Removed client-side validation of 'RetentionDays' parameter from cmdlet `Set-AzSqlDatabaseBackupShortTermRetentionPolicy`
* Auditing to a storage account in Vnet, fixing a bug when creating a Storage Blob Data Contributor role.
* Allow Azure Active Directory applications to be set as SQL Server Azure Active Directory admin.

## Version 2.6.0
* Added cmdlets `Get-AzSqlInstanceOperation` and `Stop-AzSqlInstanceOperation`
* Supported auditing to a storage account in VNet.
* Assign 'None' value as StorageKeyKind when a storage account under VNet is a target for the audit records. 

## Version 2.5.0
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
