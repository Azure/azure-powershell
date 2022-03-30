### Example 1: Get the details of a given Database Migration to a SQL DB
```powershell
Get-AzDataMigrationDatabaseMigrationsSqlDb -ResourceGroupName "MyResourceGroup" -SqlDbInstanceName "MySqlDb" -TargetDbName "MyDatabase"
```

```output
Name          Kind  ProvisioningState MigrationStatus
----          ----  ----------------- ---------------
MyDatabase SqlDb Succeeded         Succeeded     
```

This command gets the details of a given Database Migration to a SQL DB.

### Example 2: Get the expanded details of a given Database Migration to a SQL DB
```powershell
$dbMigration = Get-AzDataMigrationDatabaseMigrationsSqlDb -ResourceGroupName "MyResourceGroup" -SqlDbInstanceName "MySqlDb" -TargetDbName "MyDatabase" -Expand MigrationStatusDetails
$dbMigration.MigrationStatusDetail
```

```output
 Succeeded                       
```

This command gets the expanded details of a given Database Migration to a SQL DB.


