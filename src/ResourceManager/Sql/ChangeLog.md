<!--
    Please leave this section at the top of the change log.

    Changes for the current release should go under the section titled "Current Release", and should adhere to the following format:

    ## Current Release
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
## Current Release
* Get-AzureRmSqlServer, New-AzureRmSqlServer, and Remove-AzureRmSqlServer response now includes FullyQualifiedDomainName property.

## Version 4.2.0
* Update the Auditing commands parameters description
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription
* Added -AsJob parameter to long running cmdlets
* Obsoleted -DatabaseName parameter from Get-AzureRmSqlServiceObjective

## Version 4.1.1
* Added ability to rename database using Set-AzureRmSqlDatabase
* Fixed issue https://github.com/Azure/azure-powershell/issues/4974
	- Providing invalid AUDIT_CHANGED_GROUP value for auditing cmdlets no longer throws an error and will be removed in an upcoming release.
* Fixed issue https://github.com/Azure/azure-powershell/issues/5046
	- AuditAction parameter in auditing cmdlets is no longer being ignored
* Fixed an issue in Auditing cmdlets when 'Secondary' StorageKeyType is provided
	- When setting blob auditing, the primary storage account key was used instead of the secondary key when providing 'Secondary' value for StorageKeyType parameter.
* Changing the wording for confirmation message from Set-AzureRmSqlServerTransparentDataEncryptionProtector

## Version 4.0.1
* Fixed assembly loading issue that caused some cmdlets to fail when executing

## Version 4.0.0
* Adding support for list and cancel the asynchronous updateslo operation on the database
	- update existing cmdlet Get-AzureRmSqlDatabaseActivity to return DB updateslo operation status.
	- add new cmdlet Stop-AzureRmSqlDatabaseActivity for cancel the asynchronous updateslo operation on the database.
* Adding support for Zone Redundancy for databases and elastic pools
	- Adding ZoneRedundant switch parameter to New-AzureRmSqlDatabase
	- Adding ZoneRedundant switch parameter to Set-AzureRmSqlDatabase
	- Adding ZoneRedundant switch parameter to New-AzureRmSqlElasticPool
	- Adding ZoneRedundant switch parameter to Set-AzureRmSqlElasticPool
* Adding support for Server DNS Aliases
	- Adding Get-AzureRmSqlServerDnsAlias cmdlet which gets server dns aliases by server and alias name or a list of server dns aliases for an azure Sql Server.
	- Adding New-AzureRmSqlServerDnsAlias cmdlet which creates new server dns alias for a given Azure Sql server
	- Adding Set-AzurermSqlServerDnsAlias cmlet which allows updating a Azure Sql Server to which server dns alias is pointing
	- Adding Remove-AzureRmSqlServerDnsAlias cmdlet which removes a server dns alias for a Azure Sql Server
* Add support for online help
    - Run Get-Help with the -Online parameter to open the online help in your default Internet browser

## Version 3.4.1

## Version 3.4.0
* Adding support for Virtual Network Rules
	- Adding Get-AzureRmSqlServerVirtualNetworkRule cmdlet which gets the virtual network rules by a specific rule name or a list of virtual network rules in an Azure Sql server.
	- Adding Set-AzureRmSqlServerVirtualNetworkRule cmdlet which changes the virtual network that the rule points to.
	- Adding Remove-AzureRmSqlServerVirtualNetworkRule cmdlet which removes a virtual network rule for an Azure Sql server.
	- Adding New-AzureRmSqlServerVirtualNetworkRule cmdlet which creates a new virtual network rule for an Azure Sql server.

## Version 3.3.1

## Version 3.3.0
* Updating Set-AzureRmSqlServerTransparentDataEncryptionProtector to display a warning and require confirmation if the Encryption Protector Type is being set to AzureKeyVault
* Adding new updated cmdlets for Auditing settings
	- Adding Get-AzureRmSqlDatabaseAuditing cmdlet which gets the auditing settings of an Azure SQL database.
	- Adding Get-AzureRmSqlServerAuditing cmdlet which gets the auditing settings of an Azure SQL server.
	- Adding Set-AzureRmSqlDatabaseAuditing cmdlet which changes the auditing settings for an Azure SQL database.
	- Adding Set-AzureRmSqlServerAuditing cmdlet which changes the auditing settings of an Azure SQL server.
* Deprecating the existing Auditing policy cmdlets
	- Deprecating Get-AzureRmSqlDatabaseAuditingPolicy
	- Deprecating Get-AzureRmSqlServerAuditingPolicy
	- Deprecating Set-AzureRmSqlDatabaseAuditingPolicy
	- Deprecating Set-AzureRmSqlServerAuditingPolicy
	- Deprecating Use-AzureRmSqlServerAuditingPolicy
	- Deprecating Remove-AzureRmSqlDatabaseAuditing
	- Deprecating Remove-AzureRmSqlServerAuditing
* Schema file parsing for Update-AzureRmSqlSyncGroup is now case insensitive.

## Version 3.2.1

## Version 3.2.0
* Add Data Sync PowerShell Cmdlets to AzureRM.Sql
* Updated AzureRmSqlServer cmdlets to use new REST API version that avoids timeouts when creating server.
* Deprecated server upgrade cmdlets because the old server version (2.0) no longer exists.
* Add new optional switch paramter "AssignIdentity" to New-AzureRmSqlServer and Set-AzureRmSqlServer cmdlets to support provisioning of a resource identity for the SQL server resource
* The parameter ResourceGroupName is now optional for Get-AzureRmSqlServer
	- More information can be found in the following issue: https://github.com/Azure/azure-powershell/issues/635

## Version 3.1.0
* Restore-AzureRmSqlDatabase: Update documentation examples

## Version 3.0.1

## Version 3.0.0
* Added -SampleName parameter to New-AzureRmSqlDatabase
* Updates to Failover Group cmdlets
	- Remove 'Tag' parameters
	- Remove 'PartnerResourceGroupName' and 'PartnerServerName' parameters from Remove-AzureRmSqlDatabaseFailoverGroup cmdlet
	- Add 'GracePeriodWithDataLossHours' parameter to New- and Set- cmdlets, which shall eventually replace 'GracePeriodWithDataLossHour'
	- Documentation has been fleshed out and updated
	- Change formatting of returned objects and fix some bugs where fields were not always populated
	- Add 'DatabaseNames' and 'PartnerLocation' properties to Failover Group object
	- Fix bug causing Switch- cmdlet to return immediately rather than waiting for operation to complete
	- Fix integer overflow bug when high grace period values are used
	- Adjust grace period to a minimum of 1 hour if a lower one is provided
* Remove "Usage_Anomaly" from the accepted values for "ExcludedDetectionType" parameter of Set-AzureRmSqlDatabaseThreatDetectionPolicy cmdlet and Set-AzureRmSqlServerThreatDetectionPolicy cmdlet.

## Version 2.8.0
* Bug fixes on Azure Failover Group Cmdlets
	- Fix for operation polling
	- Fix GracePeriodWithDataLossHour value when setting FailoverPolicy to Manual
	- Adding obsolete warnings to upcoming parameter changes.

## Version 2.7.0
* Bug fix - Auditing and Threat Detection cmdlets now return a meangfull error instead of null refernce error.
* Updating Transparent Data Encryption (TDE) with Bring Your Own Key (BYOK) support cmdlets for updated API.

## Version 2.6.0
* Adding new cmdlets for support for Azure SQL feature Transparent Data Encryption (TDE) with Bring Your Own Key (BYOK) Support
	- TDE with BYOK support is a new feature in Azure SQL, which allows users to encrypt their database with a key from Azure Key Vault. This feature is currently in private preview.
	- Get-AzureRmSqlServerKeyVaultKey : This cmdlet returns a list of Azure Key Vault keys added to a Sql Server.
	- Add-AzureRmSqlServerKeyVaultKey : This cmdlet adds an Azure Key Vault key to a Sql Server.
	- Remove-AzureRmSqlServerKeyVaultKey : This cmdlet removes an Azure Key Vault key from a Sql Server.
	- Get-AzureRmSqlServerTransparentDataEncryptionProtector : This cmdlet returns the current encryption protector for a Sql Server.
	- Set-AzureRmSqlServerTransparentDataEncryptionProtector : This cmdlet sets the encryption protector for a Sql Server. The encryption protector can be set to a key from Azure Key Vault or a key that is managed by Azure Sql.
* New feature: Set--AzureRmSqlDatabaseAuditing  and Set-AzureRmSqlDatabaseServerAuditingPolicy supports setting secondary storage key for AuditType Blob
* Bug fix: Remove-AzureRmSqlDatabaseAuditing should set the UseServerDefault value to disabled
* Bug fix: Fixing an issue of selecting classic storage account when creating / updating Auditing or Threat Detection policies
* Bug fix: Set-AzureRmSqlDatabaseAuditing and Set-AzureRmSqlDatabaseServerAuditingPolicy commands use the AuditType value that was previously defined in case it has not been configured by the user.
* Bug fix: In case Blob Auditing is defined, Remove-AzureRmSqlDatabaseAuditing and Remove-AzureRmSqlDatabaseServerAuditingPolicy commands disable the Auditing settings.
* Adding new cmdlets for support for Azure SQL feature AutoDR:
	-This is a new feature in Azure SQL that supports failover of multiple Azure Sql Databases to the partner server at the same time during disaster and allows automatic failover
	- Add-AzureRmSqlDatabaseToFailoverGroup add Azure Sql Databases into a Failover Group
	- Get-AzureRmSqlDatabaseFailoverGroup get the Failover Group entity
	- New-AzureRmSqlDatabaseFailoverGroup creates a new Failover Group
	- Remove-AzureRmSqlDatabaseFromFailoverGroup removes Azure Sql Databases from a Failover Group
	- Remove-AzureRmSqlDatabaseFailoverGroup Failover Group deletes the Failover Group
	- Set-AzureRmSqlDatabaseFailoverGroup set Azure Sql Database Failover Policy and Grace Period entities of the Failover Group
	- Switch-AzureRmSqlDatabaseFailoverGroup issues the failover operation with data loss or without data loss

## Version 2.5.0
* Added new return parameter "AuditType" to Get-AzureRmSqlDatabaseAuditingPolicy and Get-AzureRmSqlServerAuditingPolicy returned object
    - This parameter value indicates the returned auditing policy type - Table or Blob.

## Version 2.4.0
* Added storage properties to cmdlets for Azure SQL threat detection policy management at database and server level
    - StorageAccountName
    - RetentionInDays
* Removed the unsupported param "AuditAction" from Set-AzureSqlDatabaseServerAuditingPolicy
* Added new param "AuditAction" to Set-AzureSqlDatabaseAuditingPolicy
* Fix for showing on GET and persisting Tags on SET (if not given) for Database, Server and Elastic Pool
    - If Tags is used in command it will save tags, if not it will not wipe out tags on resource.
* Fix for showing on GET and persisting Tags on SET (if not given) for Database, Server and Elastic Pool
    - If Tags is used in command it will save tags, if not it will not wipe out tags on resource.
* Changes for "New-AzureRmSqlDatabase", "Set-AzureRmSqlDatabase" and "Get-AzureRmSqlDatabase" cmdlets
    - Adding a new parameter called "ReadScale" for the 3 cmdlets above.
    - The "ReadScale" parameter has 2 possibl values: "Enabled" or "Disabled" to indicate whether the ReadScale option is turned on for the database.
* Functionality of ReadScale Feature.
    - ReadScale is a new feature in SQL Database, which allows the user to enabled/disable routing read-only requests to Geo-secondary Premium databases.
    - This feature allows the customer to scale up/down their read-only workload flexibly, and unlocked more DTUs for the premium database.
    - To configure ReadScale, user simply specify "ReadScale" paramter with "Enabled/Disabled" at database creation with New-AzureRmSqlDatabase cmdlet,

## Version 2.3.0
