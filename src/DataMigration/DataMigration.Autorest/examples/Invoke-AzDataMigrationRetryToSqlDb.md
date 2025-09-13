### Example 1: Retry an ongoing SQL DB migration
```powershell
$sqlDBMigration = Get-AzDataMigrationToSqlDb -ResourceGroupName "myRG" -SqlDbInstanceName "mySqlDb" -TargetDbName "mydb1"
Invoke-AzDataMigrationRetryToSqlDb -ResourceGroupName myRG -SqlDbInstanceName sqldb -TargetDbName sqldb -MigrationOperationId $sqlDBMigration.MigrationOperationId
```

This command retries the specified failed migration to a SQL database.