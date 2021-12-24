### Example 1: Start a Database Migration from the on-premise Source Sql Server to target Managed Instance
```powershell
PS C:\> New-AzDataMigrationToSqlManagedInstance -ResourceGroupName "MyResourceGroup" -ManagedInstanceName "MyManagedInstance" -TargetDbName "MyDb" -Kind "SqlMI" -Scope "/subscriptions/f890983-56793-782e7-378-3563829e/resourceGroups/MyResourceGroup/providers/Microsoft.Sql/managedInstances/MyManagedInstance" -MigrationService "/subscriptions/f890983-56793-782e7-378-3563829e/resourceGroups/MyRG/providers/Microsoft.DataMigration/SqlMigrationServices/MySqlMigrationService" -TargetLocationStorageAccountResourceId "/subscriptions/f890983-56793-782e7-378-3563829e/resourceGroups/MyResourceGroup/providers/Microsoft.Storage/storageAccounts/MyStorageAccount" -TargetLocationAccountKey "dwidjwiwnnwiojnnmskoam==adnkdnwdnwknk" -FileSharePath "\\filesharepath.com\SharedBackup\MyBackUps" -FileShareUsername "filesharepath\User" -FileSharePassword "password" -SourceSqlConnectionAuthentication "SqlAuthentication" -SourceSqlConnectionDataSource "LabServer.database.net" -SourceSqlConnectionUserName "User" -SourceSqlConnectionPassword "password" -SourceDatabaseName "AdventureWorks"

Name               Type                                       Kind  ProvisioningState MigrationStatus
----               ----                                       ----  ----------------- ---------------
MyDb               Microsoft.DataMigration/databaseMigrations SqlMi Succeeded         InProgress
```

This command starts a Database Migration from the Source Sql Server to target Managed Instance. This example is for online migration. To make it offline add -OfflineConfigurationOffline to the parameters.


