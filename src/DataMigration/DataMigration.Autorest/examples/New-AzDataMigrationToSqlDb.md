### Example 1: Start a Database Migration from the on-premise Source Sql Server to target Sql Db
```powershell
New-AzDataMigrationToSqlDb -ResourceGroupName myRG -SqlDbInstanceName "mysqldb" -MigrationService  "/subscriptions/1111-2222-3333-4444/resourceGroups/myRG/providers/Microsoft.DataMigration/SqlMigrationServices/myDMS" -TargetSqlConnectionAuthentication "SqlAuthentication" -TargetSqlConnectionDataSource "mydb.windows.net" -TargetSqlConnectionPassword "pass" -TargetSqlConnectionUserName "user" -SourceSqlConnectionAuthentication "SqlAuthentication" -SourceSqlConnectionDataSource "xyz.MICROSOFT.COM" -SourceSqlConnectionUserName "user1" -SourceSqlConnectionPassword "password" -SourceDatabaseName "sourcedb" -TargetDbName "mydb1" -Scope  "/subscriptions/1111-2222-3333-4444/resourceGroups/myRG/providers/Microsoft.Sql/servers/mysqldb" 
```

```output
Name       Kind  ProvisioningState MigrationStatus
----       ----  ----------------- ---------------
mydb1 SqlDb Succeeded         InProgress
```

This command starts a Database Migration from the Source Sql Server to target SQL DB.

### Example 2: Start a Database Migration with some selcted tables from the on-premise Source Sql Server to target Sql Db
```powershell
New-AzDataMigrationToSqlDb -ResourceGroupName myRG -SqlDbInstanceName "mysqldb" -MigrationService  "/subscriptions/1111-2222-3333-4444/resourceGroups/myRG/providers/Microsoft.DataMigration/SqlMigrationServices/myDMS" -TargetSqlConnectionAuthentication "SqlAuthentication" -TargetSqlConnectionDataSource "mydb.windows.net" -TargetSqlConnectionPassword "pass" -TargetSqlConnectionUserName "user" -SourceSqlConnectionAuthentication "SqlAuthentication" -SourceSqlConnectionDataSource "xyz.MICROSOFT.COM" -SourceSqlConnectionUserName "user1" -SourceSqlConnectionPassword "password" -SourceDatabaseName "sourcedb" -TargetDbName "mydb1" -Scope  "/subscriptions/1111-2222-3333-4444/resourceGroups/myRG/providers/Microsoft.Sql/servers/mysqldb"  -TableList "table_1"
```

```output
Name       Kind  ProvisioningState MigrationStatus
----       ----  ----------------- ---------------
mydb1 SqlDb Succeeded         InProgress
```

Start a Database Migration with some selcted tables from the on-premise Source Sql Server to target Sql Db

