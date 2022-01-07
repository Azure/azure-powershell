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

## Version 1.5.1
* Exposed BackupPolicyMigrationState as a part of Get-AzCosmosDBAccount response.
  - This shew the status of a backup policy migration state when an account was being converted from peroidic backup mode to continuous.

## Version 1.5.0
* Fixed when a warning about the value of AnalyticalStorageSchemaType is displayed when no value was given.
* Added support for managed Cassandra.

## Version 1.4.0
* Introduced Get-AzCosmosDBMongoDBBackupInformation to retrieve latest backup information for MongoDB.
* Updated New-AzCosmosDBAccount, Update-AzCosmosDBAccount to accept BackupStorageRedundancy
* Introduced Get-AzCosmosDBLocation to list Azure CosmosDB Account and its locations properties.

## Version 1.3.1
* Fixed a bug where the restore of deleted database accounts fail.

## Version 1.3.0
* This release introduces the cmdlets for the features of Continuous Backup(Point in time restore):
  - Introduced support for creating accounts with continuous mode backup policy.
  - Introduced support for Point in time restore for accounts with continuous mode backup policy.
  - Introduced support to update the backup interval and backup retention for accounts with periodic mode backup policy.
  - Introduced support to list the restorable resources in a live database account.
  - Introduces support to specify analytical storage schema type on account creation/update.
  - The following cmdlets are added:
    - Restore-AzCosmosDBAccount, New-AzCosmosDBDatabaseToRestore, Get-AzCosmosDBRestorableDatabaseAccount,
    - Get-AzCosmosDBSqlRestorableDatabase, Get-AzCosmosDBSqlRestorableContainer, Get-AzCosmosDBSqlRestorableResource,
    - Get-AzCosmosDBMongoDBRestorableDatabase, Get-AzCosmosDBMongoDBRestorableCollection, Get-AzCosmosDBMongoDBRestorableResource.

## Version 1.2.0
* Introduced support for Sql data plane RBAC, allowing the creation, updating, removal, and retrieval of Role Definitions and Role Assignments
  - The following cmdlets are added:
    - Get-AzCosmosDBSqlRoleDefinition, Get-AzCosmosDBSqlRoleAssignment,
    - New-AzCosmosDBSqlRoleDefinition, New-AzCosmosDBSqlRoleAssignment,
    - Remove-AzCosmosDBSqlRoleDefinition, Remove-AzCosmosDBSqlRoleAssignment,
    - Update-AzCosmosDBSqlRoleDefinition, Update-AzCosmosDBSqlRoleAssignment,
    - New-AzCosmosDBSqlPermission

## Version 1.1.0
* Introduced NetworkAclBypass and NetworkAclBypassResourceIds for Database Account cmdlets.
* Introduced ServerVersion parameter to Update-AzCosmosDBAccount.
* Introduced BackupInterval and BackupRetention for Database Account cmdlets

## Version 1.0.0
* General availability of 'Az.CosmosDB' module
* Restricting New-AzCosmosDBAccount cmdlet to make update calls to existing Database Accounts.
* Introducing AnalyticalStorageTTL in SqlContainer.

## Version 0.2.0
* Introduced support for throughput Migration, allowing custoers to migrate their resources from manually provisioned throughput to autoscaled throughput. Customers can use this feature using the following cmdlets:
    - 'Invoke-AzCosmosDBSqlContainerThroughputMigration', 
    - 'Invoke-AzCosmosDBSqlDatabaseThroughputMigration', 
    - 'Invoke-AzCosmosDBMongoDBCollectionThroughputMigration', 
    - 'Invoke-AzCosmosDBMongoDBDatabaseThroughputMigration', 
    - 'Invoke-AzCosmosDBGremlinGraphThroughputMigration', 
    - 'Invoke-AzCosmosDBGremlinDatabaseThroughputMigration', 
    - 'Invoke-AzCosmosDBCassandraTableThroughputMigration', 
    - 'Invoke-AzCosmosDBCassandraKeyspaceThroughputMigration', 
    - 'Invoke-AzCosmosDBTableThroughputMigration'

## Version 0.1.6
* Introduced support for Autoscale, as a result of which all cmdlets which create or modify resources with throughput have an additional parameter called AutoscaleMaxThroughput. 
* New-AzCosmosDBAccount cmdlet was updated with new paramters: EnableFreeTier, EnableAnalyticalStorage, ServerVersion, IpRule.
* Update-AzCosmosDBAccount was updated with: EnableAnalyticalStorage and IpRule.
* IpRangeFilter is deprecated, IpRule should be used, for both New-AzCosmosDBAccount and Update-AzCosmosDBAccount.
* New-AzCosmosDBMongoDBCollection, Update-AzCosmosDBMongoDBCollection, New-AzCosmosDBCassandraTable and Update-AzCosmosDBCassandraTable cmdlets allow specifying AnalyticalStorageTTL. 

## Version 0.1.5
* PSDatabaseAccount is renamed to PSDatabaseAccountGetResults
* Detailed parameter is deprecated in the following cmdlets:
    Get-AzCosmosDBSqlContainer,
    Get-AzCosmosDBSqlDatabase, Get-AzCosmosDBGremlinDatabase,
    Get-AzCosmosDBGremlinGraph, Get-AzCosmosDBTable,
    Get-AzCosmosDBCassandraKeyspace, Get-AzCosmosDBCassandraTable,
    Get-AzCosmosDBMongoDBCollection, Get-AzCosmosDBMongoDBDatabase
* Introduces KeyVaultKeyUri as a paramter in PSCosmosDBAccount, enabling BYOK feature
* Updates the Azure.Management.CosmosDB Sdk Version to 1.1.1 
* Replaces Set-AzCosmosDB* cmdlets with New-AzCosmosDB* and Update-AzComsosDB* cmdlets.
The following cmdlets are added: 
    New-AzCosmosDBSqlStoredProcedure, New-AzCosmosDBSqlTrigger, 
    New-AzCosmosDBSqlUserDefinedFunction, 
    Update-AzCosmosDBSqlStoredProcedure, Update-AzCosmosDBSqlTrigger, 
    Update-AzCosmosDBSqlUserDefinedFunction, New-AzCosmosDBSqlContainer,
    New-AzCosmosDBSqlDatabase, Update-AzCosmosDBSqlContainer,
    Update-AzCosmosDBSqlDatabase,
    New-AzCosmosDBGremlinDatabase, New-AzCosmosDBGremlinGraph,
    Update-AzCosmosDBGremlinDatabase, Update-AzCosmosDBGremlinGraph,
    New-AzCosmosDBTable, Update-AzCosmosDBTable,
    Update-AzCosmosDBCassandraKeyspace, Update-AzCosmosDBCassandraTable,
    New-AzCosmosDBCassandraKeyspace, New-AzCosmosDBCassandraTable,
    Update-AzCosmosDBMongoDBCollection, Update-AzCosmosDBMongoDBDatabase, 
    New-AzCosmosDBMongoDBCollection, New-AzCosmosDBMongoDBDatabase  
The following cmdlets are deprecated and would no longer be maintained: 
    Set-AzCosmosDBSqlStoredProcedure, Set-AzCosmosDBSqlTrigger,
    Set-AzCosmosDBSqlUserDefinedFunction, Set-AzCosmosDBSqlContainer,
    Set-AzCosmosDBSqlDatabase, Set-AzCosmosDBGremlinDatabase,
    Set-AzCosmosDBGremlinGraph, Set-AzCosmosDBTable,
    Set-AzCosmosDBCassandraKeyspace, Set-AzCosmosDBCassandraTable,
    Set-AzCosmosDBMongoDBCollection, Set-AzCosmosDBMongoDBDatabase

## Version 0.1.4
* Changes in New-AzCosmosDBAccount and Update-AzCosmosDBAccount
    - Allows empty string as a value for IpRangeFilter
    - Renamed ApiKind value GlobalDocumentDB to Sql.
    - Added parameter DisableKeyBasedMetadataWriteAccess, PublicNetworkAccess
* Introduces cmdlets to update throughput for Sql Database and Container, Cassandra Keyspace and Table, MongoDB Database and Collection, Gremlin Database and Graph and Table.
    - Update-AzCosmosDBSqlContainerThroughput, Update-AzCosmosDBSqlDatabaseThroughput,
        Update-AzCosmosDBMongoDBCollectionThroughput, Update-AzCosmosDBMongoDBDatabaseThroughput,
        Update-AzCosmosDBGremlinGraphThroughput, Update-AzCosmosDBGremlinDatabaseThroughput,
        Update-AzCosmosDBCassandraTableThroughput, Update-AzCosmosDBCassandraKeyspaceThroughput,
        Update-AzCosmosDBTableThroughput
## Version 0.1.3
* Allowing Account Creation for API Types: Gremlin, Cassandra and Table.
* Bug Fixes

## Version 0.1.2
* Updated the Azure.Management.CosmosDB Sdk Version to 1.0.2 
    -Fix bugs related to https://github.com/Azure/azure-sdk-for-net/issues/10639

## Version 0.1.2
* Updated the Azure.Management.CosmosDB Sdk Version to 1.0.2 
    - Fix bugs related to https://github.com/Azure/azure-sdk-for-net/issues/10639

## Version 0.1.1
* Added cmdlets for Gremlin, MongoDB, Cassandra and Table APIs.
* Updated .NET SDK Version to 1.0.1
    - .NET SDK Version used in the CosmosDB-Account and SQL cmdlets is updated to 1.0.1
* Added parameters ConflictResolutionPolicyMode, ConflictResolutionPolicyPath and ConflictResolutionPolicyPath in Set-AzCosmosDBSqlContainer.
* Added new cmdlets for Sql API : New-CosmosDBSqlSpatialSpec, New-CosmosDBSqlCompositePath, New-CosmosDBSqlIncludedPathIndex, New-CosmosDBSqlIncludedPath

## Version 0.1.0
* Preview release of `Az.CosmosDB` module

