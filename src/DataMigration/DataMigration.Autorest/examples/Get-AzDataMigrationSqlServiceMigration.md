### Example 1: Get the list of database migrations attached to a given Sql Migration Service
```powershell
Get-AzDataMigrationSqlServiceMigration -ResourceGroupName "MyResourceGroup" -SqlMigrationServiceName "MySqlMigrationService"
```

```output
Name                                   Type                                       Kind  ProvisioningState MigrationStatus
----                                   ----                                       ----  ----------------- ---------------
MyDatabase                             Microsoft.DataMigration/databaseMigrations SqlMi Succeeded         InProgress
MyDatabaseSqlMi                        Microsoft.DataMigration/databaseMigrations SqlMi Succeeded         Succeeded
MyDatabaseSqlVM                        Microsoft.DataMigration/databaseMigrations SqlVm Succeeded         Succeeded
```

This command gets the list of database migrations attached to a given Sql Migration service.


