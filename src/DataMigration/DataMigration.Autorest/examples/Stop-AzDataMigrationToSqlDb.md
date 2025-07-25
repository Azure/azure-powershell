### Example 1: Stop in-progress migration to SQL DB
```powershell
$dbMigration = Get-AzDataMigrationToSqlDb -ResourceGroupName "myRG" -SqlDbInstanceName "mySqlDb" -TargetDbName "mydb1"
Stop-AzDataMigrationToSqlDb -ResourceGroupName "myRG" -SqlDbInstanceName "mySqlDb" -TargetDbName "mydb1" -MigrationOperationId $dbMigration.MigrationOperationId

Get-AzDataMigrationToSqlDb -InputObject $dbMigration 
```

```output
Name               Type                                       Kind  ProvisioningState MigrationStatus
----               ----                                       ----  ----------------- ---------------
mydb1         Microsoft.DataMigration/databaseMigrations SqlDb Canceling         Canceling
```

This command stops the in-progress migration to SQL Managed Instance.