### Example 1: Stop in-progress migration to SQL DB
```powershell
$dbMigration = Get-AzDataMigrationDatabaseMigrationsSqlDb -ResourceGroupName "myRG" -SqlDbInstanceName "mySqlDb" -TargetDbName "mydb1"
Stop-AzDataMigrationDatabaseMigrationsSqlDb -ResourceGroupName "myRG" -SqlDbInstanceName "mySqlDb" -TargetDbName "mydb1" -MigrationOperationId $dbMigration.MigrationOperationId
Get-AzDataMigrationToSqlManagedInstance -InputObject $dbMigration 
```

```output
 Name               Type                                       Kind  ProvisioningState MigrationStatus
----               ----                                       ----  ----------------- ---------------
mydb1         Microsoft.DataMigration/databaseMigrations SqlMi Canceling         Canceling    
```

This command stops the in-progress migration to SQL DB.

