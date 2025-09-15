### Example 1: Delete the Database Migration resource.
```powershell
Remove-AzDataMigrationToSqlVM -ResourceGroupName myRG -SqlVirtualMachineName myVM -TargetDbName myDB
```

Delete the SQL DB Database Migration resource.

### Example 2: Delete the Database Migration resource even if it is in progress 
```powershell
Remove-AzDataMigrationToSqlVM -ResourceGroupName myRG -SqlVirtualMachineName myVM -TargetDbName myDB -Force
```

Forcibly deletes an ongoing Migration by adding the optional "Force" parameter