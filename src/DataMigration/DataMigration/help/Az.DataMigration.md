---
Module Name: Az.DataMigration
Module Guid: 150d9544-6348-4373-806f-10cd0b4de4cb
Download Help Link: https://learn.microsoft.com/powershell/module/az.datamigration
Help Version: 0.1.0.0
Locale: en-US
---

# Az.DataMigration Module
## Description
{{Azure DataMigration Service Module}}

## Az.DataMigration Cmdlets
### [Get-AzDataMigrationAssessment](Get-AzDataMigrationAssessment.md)
Start assessment on SQL Server instance(s)

### [Get-AzDataMigrationPerformanceDataCollection](Get-AzDataMigrationPerformanceDataCollection.md)
Collect performance data for given SQL Server instance(s)

### [Get-AzDataMigrationProject](Get-AzDataMigrationProject.md)
Retrieves the properties of an Azure Database Migration Service (classic) project.

### [Get-AzDataMigrationService](Get-AzDataMigrationService.md)
Retrieves the properties associated with an instance of the Azure Database Migration Service (classic). 

### [Get-AzDataMigrationSkuRecommendation](Get-AzDataMigrationSkuRecommendation.md)
Gives SKU recommendations for Azure SQL offerings

### [Get-AzDataMigrationSqlService](Get-AzDataMigrationSqlService.md)
Retrieve the Database Migration Service.

### [Get-AzDataMigrationSqlServiceAuthKey](Get-AzDataMigrationSqlServiceAuthKey.md)
Retrieve the List of Authentication Keys for Self Hosted Integration Runtime.

### [Get-AzDataMigrationSqlServiceIntegrationRuntimeMetric](Get-AzDataMigrationSqlServiceIntegrationRuntimeMetric.md)
Retrieve the registered Integration Runtime nodes and their monitoring data for a given Database Migration Service

### [Get-AzDataMigrationSqlServiceMigration](Get-AzDataMigrationSqlServiceMigration.md)
Retrieve the List of database migrations attached to the service.

### [Get-AzDataMigrationTask](Get-AzDataMigrationTask.md)
Retrieves the PSProjectTask object associated with an Azure Database Migration Service (classic) migration task.

### [Get-AzDataMigrationToSqlDb](Get-AzDataMigrationToSqlDb.md)
Retrieve the specified database migration for a given SQL Db.

### [Get-AzDataMigrationToSqlManagedInstance](Get-AzDataMigrationToSqlManagedInstance.md)
Retrieve the specified database migration for a given SQL Managed Instance.

### [Get-AzDataMigrationToSqlVM](Get-AzDataMigrationToSqlVM.md)
Retrieve the specified database migration for a given SQL VM.

### [Invoke-AzDataMigrationCommand](Invoke-AzDataMigrationCommand.md)
Creates a new command to be executed on an existing DMS (classic) task.

### [Invoke-AzDataMigrationCutoverToSqlManagedInstance](Invoke-AzDataMigrationCutoverToSqlManagedInstance.md)
Initiate cutover for in-progress online database migration to SQL Managed Instance.

### [Invoke-AzDataMigrationCutoverToSqlVM](Invoke-AzDataMigrationCutoverToSqlVM.md)
Initiate cutover for in-progress online database migration to SQL VM.

### [New-AzDataMigrationAzureActiveDirectoryApp](New-AzDataMigrationAzureActiveDirectoryApp.md)
Create a new instance DataMigration Azure ActiveDirectory Application details.

### [New-AzDataMigrationConnectionInfo](New-AzDataMigrationConnectionInfo.md)
Creates a new Connection Info object specifying the server type and name for connection.

### [New-AzDataMigrationDatabaseInfo](New-AzDataMigrationDatabaseInfo.md)
Creates the DatabaseInfo object for the Azure Database Migration Service, which specifies the database source for migration.

### [New-AzDataMigrationFileShare](New-AzDataMigrationFileShare.md)
Creates the FileShare object for the Azure Database Migration Service (classic), which specifies the local network share to take the source database backups to.

### [New-AzDataMigrationLoginsMigration](New-AzDataMigrationLoginsMigration.md)
Migrate logins from the source Sql Servers to the target Azure Sql Servers.

### [New-AzDataMigrationMongoDbCollectionSetting](New-AzDataMigrationMongoDbCollectionSetting.md)
Creates collection setting for migration according for the mongoDb migration

### [New-AzDataMigrationMongoDbDatabaseSetting](New-AzDataMigrationMongoDbDatabaseSetting.md)
Creates database setting for migration for the mongoDb migration

### [New-AzDataMigrationProject](New-AzDataMigrationProject.md)
Creates a new Azure Database Migration Service (classic) project.

### [New-AzDataMigrationSelectedDBObject](New-AzDataMigrationSelectedDBObject.md)
Creates a database input object that contains information about source and target databases for migration.

### [New-AzDataMigrationService](New-AzDataMigrationService.md)
Creates a new instance of the Azure Database Migration Service (classic).

### [New-AzDataMigrationSqlServerSchema](New-AzDataMigrationSqlServerSchema.md)
Migrate Sql Server Schema from the source Sql Servers to the target Azure Sql Servers.

### [New-AzDataMigrationSqlService](New-AzDataMigrationSqlService.md)
Create or Update Database Migration Service.

### [New-AzDataMigrationSqlServiceAuthKey](New-AzDataMigrationSqlServiceAuthKey.md)
Regenerate a new set of Authentication Keys for Self Hosted Integration Runtime.

### [New-AzDataMigrationSyncSelectedDBObject](New-AzDataMigrationSyncSelectedDBObject.md)
Creates a database info object specific to the sync scenario to be used for a migration task.

### [New-AzDataMigrationTask](New-AzDataMigrationTask.md)
Creates and starts a data migration task in the Azure Database Migration Service (classic).

### [New-AzDataMigrationTdeCertificateMigration](New-AzDataMigrationTdeCertificateMigration.md)
Migrate TDE certificate(s) from source SQL Server to the target Azure SQL Server.

### [New-AzDataMigrationToSqlDb](New-AzDataMigrationToSqlDb.md)
Create a new database migration to a given SQL Db.
This command can migrate data from the selected source database tables to the target database tables.
If the target database have no table existing, please use [New-AzDataMigrationSqlServerSchema](https://learn.microsoft.com/powershell/module/az.datamigration/new-azdatamigrationsqlserverschema) command to migrate schema objects from source database to target databse.

### [New-AzDataMigrationToSqlManagedInstance](New-AzDataMigrationToSqlManagedInstance.md)
Create a new database migration to a given SQL Managed Instance.

### [New-AzDataMigrationToSqlVM](New-AzDataMigrationToSqlVM.md)
Create a new database migration to a given SQL VM.

### [Register-AzDataMigrationIntegrationRuntime](Register-AzDataMigrationIntegrationRuntime.md)
Registers Sql Migration Service on Integration Runtime

### [Remove-AzDataMigrationProject](Remove-AzDataMigrationProject.md)
Removes an Azure Database Migration Service (classic) project from Azure.

### [Remove-AzDataMigrationService](Remove-AzDataMigrationService.md)
Removes an instance of the Azure Database Migration Service (classic) from Azure.

### [Remove-AzDataMigrationSqlService](Remove-AzDataMigrationSqlService.md)
Delete Database Migration Service.

### [Remove-AzDataMigrationSqlServiceNode](Remove-AzDataMigrationSqlServiceNode.md)
Delete the integration runtime node.

### [Remove-AzDataMigrationTask](Remove-AzDataMigrationTask.md)
Removes an Azure Database Migration Service (classic) task from Azure.

### [Remove-AzDataMigrationToSqlDb](Remove-AzDataMigrationToSqlDb.md)
Remove the specified database migration for a given SQL Db.

### [Start-AzDataMigrationService](Start-AzDataMigrationService.md)
Starts an instance of the Azure Database Migration Service (classic) in a stopped state. 

### [Stop-AzDataMigrationService](Stop-AzDataMigrationService.md)
Stops an instance of the Azure Database Migration Service (classic) that is in a running state.

### [Stop-AzDataMigrationTask](Stop-AzDataMigrationTask.md)
Stops an  Azure Database Migration Service (classic) task that is in a running state.

### [Stop-AzDataMigrationToSqlDb](Stop-AzDataMigrationToSqlDb.md)
Stop in-progress database migration to SQL Db.

### [Stop-AzDataMigrationToSqlManagedInstance](Stop-AzDataMigrationToSqlManagedInstance.md)
Stop in-progress database migration to SQL Managed Instance.

### [Stop-AzDataMigrationToSqlVM](Stop-AzDataMigrationToSqlVM.md)
Stop in-progress database migration to SQL VM.

### [Update-AzDataMigrationSqlService](Update-AzDataMigrationSqlService.md)
Update Database Migration Service.

