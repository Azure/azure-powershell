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

