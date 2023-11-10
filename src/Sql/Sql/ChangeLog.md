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

## Version 4.11.0
* Added new parameters to `New-AzSqlDatabaseFailoverGroup`, `Set-AzSqlDatabaseFailoverGroup`
    - PartnerServers
    - ReadOnlyEndpointTargetServer
* Added `UseFreeLimit` and `FreeLimitExhaustionBehavior` parameters to `New-AzSqlDatabase`, `Get-AzSqlDatabase`, `Set-AzSqlDatabase`
* Added new cmdlets for Elastic Job Private Endpoints `Get-AzSqlElasticJobPrivateEndpoint`, `New-AzSqlElasticJobPrivateEndpoint`, `Remove-AzSqlElasticJobPrivateEndpoint`
* Added new parameters `WorkerCount`, `SkuName`, `Identity` to `AzSqlElasticJobAgent` cmdlets
* Added support for optional SQL auth for Elastic Job Agent cmdlets
*   - The following parameters are now optional: `CredentialName`, `OutputCredentialName`, `RefreshCredentialName`

## Version 4.10.0
* Fixed cmdlets to use 2018-06-01-preview api version
    - 'Set-AzSqlInstanceDatabaseSensitivityClassification',
    - 'Remove-AzSqlInstanceDatabaseSensitivityClassification',
    - 'Enable-AzSqlInstanceDatabaseSensitivityRecommendation',
    - 'Disable-AzSqlInstanceDatabaseSensitivityRecommendation',
* Added `EncryptionProtectorAutoRotation` parameter to `New-AzSqlDatabase`, `Get-AzSqlDatabase`, `Set-AzSqlDatabase`, `New-AzSqlDatabaseCopy`, `New-AzSqlDatabaseSecondary`, `Restore-AzSqlDatabase` cmdlets

## Version 4.9.0
* Added new cmdlets for Azure SQL Managed Instance start/stop schedule
    - 'Start-AzSqlInstance',
    - 'Stop-AzSqlInstance',
    - 'Get-AzSqlInstanceStartStopSchedule',
    - 'New-AzSqlInstanceStartStopSchedule',
    - 'Remove-AzSqlInstanceStartStopSchedule',
    - 'New-AzSqlInstanceScheduleItem'

## Version 4.8.0
* Added `TryPlannedBeforeForcedFailover` parameter to `Switch-AzSqlDatabaseFailoverGroup`
* Added new cmdlets for managed database move and copy operations
    - 'Copy-AzSqlInstanceDatabase'
    - 'Move-AzSqlInstanceDatabase'
    - 'Complete-AzSqlInstanceDatabaseCopy'
    - 'Stop-AzSqlInstanceDatabaseCopy'
    - 'Complete-AzSqlInstanceDatabaseMove'
    - 'Stop-AzSqlInstanceDatabaseMove'
    - 'Get-AzSqlInstanceDatabaseMoveOperation'
    - 'Get-AzSqlInstanceDatabaseCopyOperation'


## Version 4.7.0
* Added new cmdlets `Get-AzSqlInstanceDatabaseLedgerDigestUpload`, `Disable-AzSqlInstanceDatabaseLedgerDigestUpload`, and `Enable-AzSqlInstanceDatabaseLedgerDigestUpload`
* Added `EnableLedger` parameter to `New-AzSqlInstanceDatabase`
* Added `PreferredEnclaveType` parameter to `NewAzureSqlElasticPool` and `SetAzureSqlElasticPool` cmdlet
* Added "None" as an option for -MinimalTlsVersion for the cmdlet 'Set-AzSqlServer'

## Version 4.6.0
* Added new cmdlets for managing server configuration options
    - 'Set-AzSqlServerConfigurationOption'
    - 'Get-AzSqlServerConfigurationOption'

## Version 4.5.0
* Added a new cmdlet to refresh external governance status
    - 'Invoke-AzSqlServerExternalGovernanceStatusRefresh'

## Version 4.4.0
* Fixed identity assignment in `Set-AzSqlDatabase` cmdlet
* Added new parameters to `New-AzSqlDatabase`, `Get-AzSqlDatabase`, `Set-AzSqlDatabase`, `New-AzSqlDatabaseCopy`, `New-AzSqlDatabaseSecondary` cmdlets
   - AssignIdentity
   - EncryptionProtector
   - UserAssignedIdentityId
   - KeyList
   - KeysToRemove
   - FederatedClientId
* Added 'ExpandKeyList' and 'KeysFilter' parameters to `Get-AzSqlDatabaseGeoBackup` and `Get-SqlDeletedDatabaseBackup`
* Added new cmdlets for Per DB CMK
   - 'Revalidate-AzSqlDatabaseTransparentDataEncryptionProtector'
   - 'Revert-AzSqlDatabaseTransparentDataEncryptionProtector'
   - 'Revalidate-AzSqlServerTransparentDataEncryptionProtector'
   - 'Revalidate-AzSqlInstanceTransparentDataEncryptionProtector'
* Added an optional parameter 'SecondaryType' to:
    'Set-AzSqlDatabaseInstanceFailoverGroup'
    'New-AzSqlDatabaseInstanceFailoverGroup'

## Version 4.3.0
* Added an optional parameter `HAReplicaCount` to `Restore-AzSqlDatabase`
* Added new cmdlets for managed instance DTC
    `Get-AzSqlInstanceDtc`
    `Set-AzSqlInstanceDtc`
* Added `TargetSubscriptionId` to `Restore-AzSqlInstanceDatabase` in order to enable cross subscription restore
* Enabled support for UserAssignedManagedIdentity in Auditing
* Fixed WorkspaceResourceId parameter value in `Set-AzSqlServerAudit`

## Version 4.2.0
* Added a parameter named `UseIdentity` for `Set-AzSqlServerAudit`, `Set-AzSqlDatabaseAudit`, `Set-AzSqlServerMSSupportAudit`
* Added `IsManagedIdentityInUse` property to the output of `Get-AzSqlServerMSSupportAudit`
* Added `PreferredEnclaveType` parameter to `New-AzSqlDatabase`, `Get-AzSqlDatabase` and `Set-AzSqlDatabase` cmdlet

## Version 4.1.0
* Added new cmdlets for CRUD operations on SQL server IPv6 Firewall rules
      `Get-AzSqlServerIpv6FirewallRule`
      `New-AzSqlServerIpv6FirewallRule`
      `Remove-AzSqlServerIpv6FirewallRule`
      `Set-AzSqlServerIpv6FirewallRule`
* StorageContainerSasToken parameter in the `Start-AzSqlInstanceDatabaseLogReplay` cmdlet is now optional

## Version 4.0.0
* Added new fields to the `Get-AzSqlInstanceDatabaseLogReplay` cmdlet
* Improved error handling in the `Stop-AzSqlInstanceDatabaseLogReplay` cmdlet
* Added StorageContainerIdentity parameter in the `Start-AzSqlInstanceDatabaseLogReplay` cmdlet
* Removed the following cmdlets: `Clear-AzSqlServerAdvancedThreatProtectionSetting` and `Clear-AzSqlDatabaseAdvancedThreatProtectionSetting`
* Added the following cmdlets: `Get-AzSqlInstanceDatabaseAdvancedThreatProtectionSetting`, `Get-AzSqlInstanceAdvancedThreatProtectionSetting`, `Update-AzSqlInstanceDatabaseAdvancedThreatProtectionSetting` and `Update-AzSqlInstanceAdvancedThreatProtectionSetting`
* Removed the following aliases: `Enable-AzSqlServerAdvancedThreatProtection`, `Disable-AzSqlServerAdvancedThreatProtection`, `Get-AzSqlServerThreatDetectionSetting`, `Remove-AzSqlServerThreatDetectionSetting`, `Set-AzSqlServerThreatDetectionSetting`, `Get-AzSqlDatabaseThreatDetectionSetting`, `Set-AzSqlDatabaseThreatDetectionSetting` and `Remove-AzSqlDatabaseThreatDetectionSetting`
* Changed the returned object for the following cmdlets: `Get-AzSqlServerAdvancedThreatProtectionSetting` and `Get-AzSqlDatabaseAdvancedThreatProtectionSetting`
* Changed the parameters for the following cmdlets: `Update-AzSqlServerAdvancedThreatProtectionSetting` and `Update-AzSqlDatabaseAdvancedThreatProtectionSetting`. Only `Enable` parameter is now supported.
* Changed endpoint used in SQL Server and SQL Instance from AD Graph to MS Graph
* Added `Standby` option to `SecondaryType` parameter to `New-AzSqlDatabaseSecondary`.

## Version 3.11.0
* Removed the warning messages for MSGraph migration [#18856] 
* Moved SQL Server and SQL Instance from ActiveDirectoryClient to MicrosoftGraphClient
* Supported cross-subscription Failover Group creation using `PartnerSubscriptionId` parameter in `New-AzSqlDatabaseFailoverGroup` cmdlet
* Added `PausedDate` and `ResumedDate` for cmdlet `Get-AzSqlDatabase`

## Version 3.10.0
* Added `GeoZone` option to `BackupStorageRedundancy` parameter to `New-AzSqlDatabase`, `Set-AzSqlDatabase`, `New-AzSqlDatabaseCopy`, `New-AzSqlDatabaseSecondary`, and `Restore-AzSqlDatabase` to enable create, update, copy, geo secondary and PITR support for GeoZone hyperscale databases
* Added additional input validation to `Stop-AzSqlInstanceDatabaseLogReplay` cmdlet to ensure the target database was created by log replay service
* Bug fix for cmdlet `Restore-AzSqlDatabase`. The optional property `Tags` was not working as expected
* Added isManagedIdentityInUse get parameter for `Get-AzSqlServerAudit` and `Get-AzSqlDatabaseAudit`
* Added new cmdlet `Set-AzSqlInstanceDatabase`

## Version 3.9.0
* Added new cmdlet `Get-AzSqlInstanceEndpointCertificate`
* Added parameter `HighAvailabilityReplicaCount` to `New-AzSqlElasticPool` and `Set-AzSqlElasticPool`

## Version 3.8.0
* Added parameter `ServicePrincipalType` to `New-AzSqlInstance` and `Set-AzSqlInstance`
* [Breaking change] Removed `Get-AzSqlDatabaseTransparentDataEncryptionActivity`
* Added property `CurrentBackupStorageRedundancy` and `RequestedBackupStorageRedundancy` in  the outputs of Managed Instance CRUD commands
* Added optional property `Tag` to `Restore-AzSqlDatabase`
* Added new cmdlets for managing Server Trust Certificates
    - `New-AzSqlInstanceServerTrustCertificate`
    - `Get-AzSqlInstanceServerTrustCertificate`
    - `Remove-AzSqlInstanceServerTrustCertificate`
* Added new cmdlets for managing Managed Instance Link
    - `New-AzSqlInstanceLink`
    - `Get-AzSqlInstanceLink`
    - `Remove-AzSqlInstanceLink`
    - `Set-AzSqlInstanceLink`
* Added support for DataWarehouse cross tenant and cross subscription restore operations to `Restore-AzSqlDatabase` cmdlet
* Upgrading to usage of .NET SDK 3.1.0-preview
* Declare breaking changes for the AdvancedDataSecurity and AdvancedThreatProtection cmdlets to be effective from 9.0.0.

## Version 3.7.1
* Deprecation of Get-AzSqlDatabaseTransparentDataEncryptionActivity cmdlet
* Fixed cmdlets for Azure Active Directory Admin `AzureSqlServerActiveDirectoryAdministratorAdapter` and `AzureSqlInstanceActiveDirectoryAdministratorAdapter` migrate from `AzureEnvironment.Endpoint.AzureEnvironment.Endpoint.Graph` to `AzureEnvironment.ExtendedEndpoint.MicrosoftGraphUrl`

## Version 3.7.0
* Added `ZoneRedundant` parameter to `New-AzSqlDatabaseCopy`, `New-AzSqlDatabaseSecondary` and `Restore-AzSqlDatabase` to enable zone redundant copy, geo secondary and PITR support for hyperscale databases

## Version 3.6.0
* Fixed FirewallRuleName wildcard filtering in `Get-AzSqlServerFirewallRule` [#16199]

* Moved SQL Server and SQL Instance AAD from ActiveDirectoryClient to MicrosoftGraphClient 

## Version 3.5.1
* Fixed `Get-AzSqlDatabaseImportExportStatus` to report the error encountered

## Version 3.5.0
* Changed the underlying implementation of `Get-AzSqlDatabase` to support a paginated response from the server
* Added `ZoneRedundant` parameter to `New-AzSqlInstance` and `Set-AzSqlInstance` to enable the creation and the update of zone - redundant instances.
* Added ZoneRedundant field to the model of the managed instance so that it displays information about zone - redundancy for instance that are returned by `Get-AzSqlInstance`.
* Extended AuditActionGroups enum in server & database audit. Added DBCC_GROUP, DATABASE_OWNERSHIP_CHANGE_GROUP and DATABASE_CHANGE_GROUP.
* Added `AsJob` flag to `Remove-AzSqlInstance`
* Added `SubnetId` parameter to `Set-AzSqlInstance` to support the cross-subnet update SLO
* Upgraded to newest SDK version

## Version 3.4.1
* Fixed identity logic in `Set-AzSqlServer` and `Set-AzSqlInstance`

## Version 3.4.0
* Added `RestrictOutboundNetworkAccess` parameter to following cmdlets
    - `New-AzSqlServer`
    - `Set-AzSqlServer`
* Added new cmdlets for CRUD operations on Allowed FQDNs of Outbound Firewall rules
      `Get-AzSqlServerOutboundFirewallRule`
      `New-AzSqlServerOutboundFirewallRule`
      `Remove-AzSqlServerOutboundFirewallRule`
* Fixed the identity logic for SystemAssigned,UserAssigned identities for New-AzSqlServer, New-AzSqlInstance
* Updated cmdlets for getting and updating SQL database's differential backup frequency
      `Get-AzSqlDatabaseBackupShortTermRetentionPolicy`
      `Set-AzSqlDatabaseBackupShortTermRetentionPolicy`
* Fixed Partial PUT issue for Azure Policy in `Set-AzSqlServer` and `Set-AzSqlInstance`

## Version 3.3.0
* Changed the type of parameter `AutoRotationEnabled` in `Set-AzSqlInstanceTransparentDataEncryptionProtector` to bool?.
* Fixed Update-AzSqlDatabaseAdvancedThreatProtectionSetting with StorageAccount as an optional parameter instead of required.

## Version 3.2.0
* Added option to support short version of maintenance configuration id for Managed Instance in `New-AzSqlInstance` and `Set-AzSqlInstance` cmdlets
* Added HighAvailabilityReplicaCount to `New-AzSqlDatabaseSecondary`
* Added External Administrator and AAD Only Properties to AzSqlServer and AzSqlInstance
    - Added option to specify `-ExternalAdminName`, `-ExternalAdminSid`, `-EnableActiveDirectoryOnlyAuthentication` in `New-AzSqlInstance` and `Set-AzSqlInstance` cmdlets
    - Added option to expand external administrators information using `-ExpandActiveDirectoryAdministrator` in `Get-AzSqlServer` and `Get-AzSqlInstance` cmdlets
* Fixed `Set-AzSqlDatabase` to no longer default ReadScale to Disabled when not specified
* Fixed `Set-AzSqlServer` and `Set-AzSqlInstance` for partial PUT with only identity and null properties
* Added parameters related to UMI in `New-AzSqlServer`, `New-AzSqlInstance`, `Set-AzSqlServer` and `Set-AzSqlInstance` cmdlets.
* Added -AutoRotationEnabled parameter to following cmdlets:
    - `Set-AzSqlServerTransparentDataEncryptionProtector`
    - `Get-AzSqlServerTransparentDataEncryptionProtector`
    - `Set-AzSqlInstanceTransparentDataEncryptionProtector`
    - `Get-AzSqlInstanceTransparentDataEncryptionProtector`

## Version 3.1.0
* Updated `Set-AzSqlDatabaseVulnerabilityAssessmentRuleBaseline` documentation to include example of define array of array with one inner array.
* Added cmdlet `Copy-AzSqlDatabaseLongTermRetentionBackup`
    - Copy LTR backups to different servers
* Added cmdlet `Update-AzSqlDatabaseLongTermRetentionBackup`
    - Update Backup Storage Redundancy values for LTR backups
* Added CurrentBackupStorageRedundancy, RequestedBackupStorageRedundancy to `Get-AzSqlDatabase`, `New-AzSqlDatabase`, `Set-AzSqlDatabase`, `New-AzSqlDatabaseSecondary`, `Set-AzSqlDatabaseSecondary`, `New-AzSqlDatabaseCopy`
    - Changed BackupStorageRedundancy value to CurrentBackupStorageRedundancy, RequestedBackupStorageRedundancy to reflect both the current value and what has been requested if a change was made
* Added new cmdlets `Get-AzSqlDatabaseLedgerDigestUpload`, `Disable-AzSqlDatabaseLedgerDigestUpload`, and `Enable-AzSqlDatabaseLedgerDigestUpload`
* Added -EnableLedger parameter to `New-AzSqlDatabase`

## Version 2.17.1
* Added cmdlet output breaking change warnings to the following:
    - `New-AzSqlDatabase`
    - `Get-AzSqlDatabase`
    - `Set-AzSqlDatabase`
    - `Remove-AzSqlDatabase`
    - `New-AzSqlDatabaseSecondary`
    - `Remove-AzSqlDatabaseSecondary`
    - `Get-AzSqlDatabaseReplicationLink`
    - `New-AzSqlDatabaseCopy`
    - `Set-AzSqlDatabaseSecondary`

## Version 2.17.0
* Added cmdlet `New-AzSqlServerTrustGroup`
* Added cmdlet `Remove-AzSqlServerTrustGroup`
* Added cmdlet `Get-AzSqlServerTrustGroup`

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
