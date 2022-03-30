### Example 1: Start a Database Migration from the on-premise Source Sql Server to target SQL DB
```powershell
New-AzDataMigrationDatabaseMigrationSqlDb -ResourceGroupName "myRG" -SqlDbInstanceName "mySqlDb" -MigrationService  "/subscriptions/1111-2222-3333-4444/resourceGroups/myRG/providers/Microsoft.DataMigration/SqlMigrationServices/mydms" -TargetSqlConnectionAuthentication "SqlAuthentication" -TargetSqlConnectionDataSource "mySqlDb.database.windows.net" -TargetSqlConnectionPassword "password" -TargetSqlConnectionUserName "user" -SourceSqlConnectionAuthentication "SqlAuthentication" -SourceSqlConnectionDataSource "Server.COM" -SourceSqlConnectionUserName "testuser" -SourceSqlConnectionPassword "password" -SourceDatabaseName "AdventureWorks" -Scope  "/subscriptions/1111-222-3333-4444/resourceGroups/myRG/providers/Microsoft.Sql/servers/mySqlDb" -TargetDbName "mydb1"
```

```output
Name          Kind  ProvisioningState MigrationStatus
----          ----  ----------------- ---------------
mydb1 SqlDb Succeeded         InProgress          
```

This command starts a Database Migration from the Source Sql Server to target SQL DB. 