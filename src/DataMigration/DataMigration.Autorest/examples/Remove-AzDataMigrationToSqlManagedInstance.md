### Example 1: Delete the SQL MI Database Migration resource.
```powershell
Remove-AzDataMigrationToSqlManagedInstance -ResourceGroupName myRG -managedInstanceName sqlmi -TargetDbName myDB
```

Delete the SQL DB Database Migration resource.

### Example 2: Delete the SQL MI Database Migration resource even if it is in progress 
```powershell
Remove-AzDataMigrationToSqlManagedInstance -ResourceGroupName myRG -managedInstanceName sqlmi -TargetDbName myDB -Force
```

Forcibly deletes an ongoing Migration to SQL MI by adding the optional "Force" parameter