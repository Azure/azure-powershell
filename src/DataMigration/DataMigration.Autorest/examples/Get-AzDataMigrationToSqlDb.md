### Example 1: Get the details of a given Database Migration to a SQL DB
```powershell
Get-AzDataMigrationToSqlDb -ResourceGroupName "myRG" -SqlDbInstanceName "mySqlDb" -TargetDbName "mydb1"
```

```output
Name       Kind  ProvisioningState MigrationStatus
----       ----  ----------------- ---------------
mydb1 SqlDb Succeeded         InProgress
```

Get the details of a given Database Migration to a SQL DB

### Example 2: Get the expanded details of a given Database Migration to a SQL DB
```powershell
$dbMigration = Get-AzDataMigrationToSqlDb -ResourceGroupName "myRG" -SqlDbInstanceName "mySqlDb" -TargetDbName "mydb1" -Expand MigrationStatusDetails
$dbMigration.MigrationStatusDetailMigrationState
```

```output
MonitorMigration
```

Get the expanded details of a given Database Migration to a SQL DB

