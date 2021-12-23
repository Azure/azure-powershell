### Example 1: Start a Database Migration from the on-premise Source Sql Server to target Sql VM
```powershell
PS C:\> New-AzDataMigrationToSqlVM -ResourceGroupName "MyRG" -SqlVirtualMachineName "MyVM" -TargetDbName "MyDb" -Kind "SqlVm" -Scope "/subscriptions/f890983-56793-782e7-378-3563829e/resourceGroups/MyRG/providers/Microsoft.Sql/managedInstances/MyMI" -MigrationService "/subscriptions/f890983-56793-782e7-378-3563829e/resourceGroups/MyRG/providers/Microsoft.DataMigration/SqlMigrationServices/MySqlMS" -TargetLocationStorageAccountResourceId "/subscriptions/f890983-56793-782e7-378-3563829e/resourceGroups/MyRG/providers/Microsoft.Storage/storageAccounts/MyStorageAccount" -TargetLocationAccountKey "dwidjwiwnnwiojnnmskoam==adnkdnwdnwknk" -FileSharePath "\\filesharepath.com\SharedBackup\MyBackUps" -FileShareUsername "filesharepath\User" -FileSharePassword "password" -SourceSqlConnectionAuthentication "SqlAuthentication" -SourceSqlConnectionDataSource "LabServer.database.net" -SourceSqlConnectionUserName "User" -SourceSqlConnectionPassword "password" -SourceDatabaseName "AdventureWorks"

Name                 Type                                       Kind  ProvisioningState MigrationStatus
----                 ----                                       ----  ----------------- ---------------
MyDb                 Microsoft.DataMigration/databaseMigrations SqlVm Succeeded         InProgress
```

This command starts a Database Migration from the Source Sql Server to target Sql VM. This example is for online migration. To make it offline add -OfflineConfigurationOffline to the parameters. 


